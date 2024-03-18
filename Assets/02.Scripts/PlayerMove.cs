
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float MoveSpeed = 5.0f;
    float RotSpeed = 5.0f;
    Vector3 WayPointPos = Vector3.zero;

    bool IsMove = false;
    float dist = 0;

    //마우스 클릭감지를 위한 변수
    Ray ray;
    RaycastHit hit;
    int layerMask;
    public Animator PlayerAnim;


    //WayPointMark관련 변수
    public GameObject WayPointMark = null;
    float WPMarkTimer = 0.0f;
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

        if (Input.GetMouseButtonDown(1))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.red, 1f);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                IsMove = true;
                WayPointPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                WayPointMark.transform.position = WayPointPos;
                WpMarkAnimator.Play("WayPointAnim", -1, 0f);
            }
        }
        if (IsMove)
        {
            dist = (transform.position - WayPointPos).magnitude;
            if (0.1f < dist)
            {
                Quaternion targetRot = Quaternion.LookRotation(WayPointPos - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, RotSpeed * Time.deltaTime);

                transform.position = Vector3.MoveTowards(transform.position, WayPointPos, MoveSpeed * Time.deltaTime);
            }
        }

    }
}
