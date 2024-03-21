using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    enum PlayerState
    {
        Idle = 0,
        Run,
        Attack,
        PickUp
    }

    List<GameObject> PickItemList = new List<GameObject>();
    float MoveSpeed = 5.0f;
    float RotSpeed = 5.0f;
    float dist = 0;
    public Animator PlayerAnim;

    float AttackRange = 2.0f;
    float PickUpRange = 1.0f;
    GameObject TargetObj = null;
    Vector3 TargetVec;

    //마우스 클릭감지를 위한 변수
    Ray ray;
    RaycastHit hit;

    //WayPointMark관련 변수
    [Header("------WayPoint------")]
    public GameObject WayPointMark = null;
    public Animator WpMarkAnimator = null;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        TargetVec = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            PickUpItem();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UseSkill(0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            UseSkill(1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            UseSkill(2);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            UseSkill(3);
        }

        if (GameMgr.inst.IsAnyPanelOff())
        {
            if (Input.GetMouseButtonDown(1))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    TargetVec = hit.point;
                    TargetVec.y = transform.position.y;
                    WayPointMark.transform.position = TargetVec;
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                    {
                        WpMarkAnimator.Play("WayPointAnim", -1, 0f);
                        TargetObj = null;
                    }
                    else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                    {
                        Debug.Log("에너");
                        TargetObj = hit.collider.gameObject;
                    }
                    else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Item"))
                    {
                        TargetObj = hit.collider.gameObject;
                    }
                }
            }

            if (AttackEnemy())
                MoveUpdate();
        }
    }
    public void MoveUpdate()
    {
        dist = (transform.position - TargetVec).magnitude;
        if (0.1f < dist)
        {

            Quaternion targetRot = Quaternion.LookRotation(TargetVec - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, RotSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, TargetVec, MoveSpeed * Time.deltaTime);
        }
        else
        {
            PlayerAnim.SetBool("IsRun", false);
        }
    }
    public bool AttackEnemy()
    {
        if (TargetObj != null && (transform.position - TargetObj.transform.position).magnitude < AttackRange)
        {
            PlayerAnim.SetBool("IsRun", false);
            Quaternion targetRot = Quaternion.LookRotation(TargetObj.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, RotSpeed * Time.deltaTime);
            Debug.Log("공격");
            PlayerAnim.SetBool("IsAttack", true);
            return false;
        }
        else
        {
            PlayerAnim.SetBool("IsAttack", false);
            return true;
        }
    }

    public void UseSkill(int index)
    {
        if (GlobalValue.PlayerSkill[index] != null)
        {
            Debug.Log(GlobalValue.PlayerSkill[index].skillName);
            GlobalValue.PlayerSkill[index].UseActiveSkill(this.gameObject, this.transform);
        }
        else
        {
            Debug.Log("Null");
        }
    }
    public void ChangeSkill(ActiveSkill newSkill, int index)
    {
        if (newSkill != null && 0 <= index && index < GlobalValue.PlayerSkill.Length)
            GlobalValue.PlayerSkill[index] = newSkill;
    }

    public void PickUpItem()
    {
        if (0 < PickItemList.Count)
        {
            GlobalValue.AddItem(PickItemList[0].GetComponent<ItemCtrl>().item);
            Destroy(PickItemList[0]);
            PickItemList.RemoveAt(0);
            InventoryMgr.inst.Refreshslot();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

    }
    private void OnTriggerExit(Collider other)
    {

    }
    private void OnTriggerStay(Collider other)
    {

    }


}
