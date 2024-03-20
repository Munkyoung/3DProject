
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float MoveSpeed = 5.0f;
    float RotSpeed = 5.0f;
    Vector3 WayPointPos = Vector3.zero;
    float dist = 0;

    //마우스 클릭감지를 위한 변수
    Ray ray;
    RaycastHit hit;
    int layerMask;

    //WayPointMark관련 변수
    [Header("------WayPoint------")]
    public GameObject WayPointMark = null;
    public Animator WpMarkAnimator = null;


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        layerMask = 1 << LayerMask.NameToLayer("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMgr.inst.IsPanelOn() == false)
        {
            if (Input.GetMouseButtonDown(1))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    WayPointPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                    WayPointMark.transform.position = WayPointPos;
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                    {
                        MoveUpdate();
                    }
                    else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                    {

                    }
                    else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Item"))
                    {

                    }
                }
            }
        }

    }

    public void MoveUpdate()
    {
        WpMarkAnimator.Play("WayPointAnim", -1, 0f);
        dist = (transform.position - WayPointPos).magnitude;
        if (0.1f < dist)
        {
            Quaternion targetRot = Quaternion.LookRotation(WayPointPos - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, RotSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, WayPointPos, MoveSpeed * Time.deltaTime);
        }
    }
    public void AttackEnemy()
    {

    }
    public void PickUpItem()
    {

    }
}
