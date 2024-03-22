using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour, ITakeDamagealbe
{
    float Hp;
    float MaxHp = 300.0f;
    enum AnimStates
    {
        Idle = 0,
        Run,
        Attack,
        PickUp
    }

    AnimStates AnimState = AnimStates.Idle;

    List<GameObject> PickItemList = new List<GameObject>();
    float MoveSpeed = 5.0f;
    float RotSpeed = 5.0f;
    float dist = 0;
    public Animator PlayerAnim;

    float AttackRange = 2.5f;
    float PickUpRange = 2.0f;
    GameObject TargetObj = null;
    GameObject TargetItem = null;
    Vector3 TargetVec;

    float attDelay = 1.0f;

    private AnimStates animState
    {
        get => AnimState;
        set
        {
            AnimState = value;
            PlayerAnim.SetInteger("Test", (int)AnimState);
        }
    }

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
        if (Input.GetKeyDown(KeyCode.G))
        {
            SOItem DropItem = this.GetComponent<ItemTable>().GetItem();

            GlobalValue.AddItem(DropItem);
        }

        if (GameMgr.inst.IsAnyPanelOff())
        {
            if (Input.GetMouseButtonDown(1))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, GlobalValue.layerMask))
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
                        TargetObj = hit.collider.gameObject;
                    }
                    else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Item"))
                    {
                        TargetItem = hit.collider.gameObject;
                        Debug.Log(TargetItem.name);
                    }
                }
            }

            if (TargetObj = null)
            {
                return;
            }
            
                // move(target) 포인트까지
            
            else
            {
                //hit.gameobject.tag == enemy
                //attrange 까지 접근
                //정지
                //회전
                //애니메이션
                //takeDamage
            }

            if (PickUpItem())
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
            animState = AnimStates.Idle;
        }

    }
    public bool AttackEnemy()
    {

        if (TargetObj != null && (transform.position - TargetObj.transform.position).magnitude < AttackRange)
        {
            if (0.0f < attDelay)
            {
                animState = AnimStates.Attack;
                attDelay -= Time.deltaTime;
                return true;
            }
            else
            {
                Debug.Log("공격");
                TargetObj.GetComponent<Enemy>().TakeDamage(GlobalValue.curAtt);
                Quaternion targetRot = Quaternion.LookRotation(TargetObj.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, RotSpeed * Time.deltaTime);
                attDelay = 1.0f;
                return false;

            }
        }
        else
        {
            attDelay = 1.0f;
            return true;
        }
    }
    public bool PickUpItem()
    {
        if (TargetItem != null && (transform.position - TargetItem.transform.position).magnitude < PickUpRange)
        {
            Debug.Log("destroy!");
            GlobalValue.AddItem(TargetItem.GetComponent<ItemCtrl>().item);
            Destroy(TargetItem);
            if (InventoryMgr.inst != null)
                InventoryMgr.inst.Refreshslot();
            return false;
        }
        else
        {
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
            Debug.Log("Skill Is Empty");
        }
    }
    public void ChangeSkill(ActiveSkill newSkill, int index)
    {
        if (newSkill != null && 0 <= index && index < GlobalValue.PlayerSkill.Length)
            GlobalValue.PlayerSkill[index] = newSkill;
    }

    public void TakeDamage(float value)
    {
        if (0f < Hp) return;

        Hp -= value;
        if (0f < Hp)
        {
            PlayerDie();
        }
    }


    private void PlayerDie()
    {

    }
}
