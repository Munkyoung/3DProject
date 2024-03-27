using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour, ITakeDamagealbe
{
    float MaxHp = 300.0f;
    float Hp = 300.0f;
    public float hp
    {
        get { return Hp; }
        set
        {
            Hp = value;
            if (MaxHp < Hp)
            {
                Hp = MaxHp;
            }
        }
    }
    enum AnimStates
    {
        Idle = 0,
        Run,
        Attack,
        PickUp
    }
    AnimStates AnimState = AnimStates.Idle;

    float MoveSpeed = 5.0f;
    float RotSpeed = 5.0f;
    float dist = 0;
    public Animator PlayerAnim;

    float AttackRange = 2.5f;
    float PickUpRange = 2.0f;
    GameObject TargetObj = null;
    Vector3 TargetVec;

    float attDelay = 0.0f;

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


    public Transform MiniMapCamera;
    float MiniMapCamOffset = 10.0f;

    public Image[] SkPanelImages;

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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            hp -= 30.0f;
            Debug.Log(hp);
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
                        TargetObj = hit.collider.gameObject;
                    }
                    if (TargetObj != null)
                    {
                        dist = (transform.position - TargetObj.transform.position).magnitude;
                    }
                }
            }

            if (TargetObj == null)
            {
                MoveUpdate();
            }
            else if (TargetObj != null && TargetObj.gameObject.tag == "Enemy" && dist < AttackRange)
            {
                AttackEnemy();
            }
            else if (TargetObj != null && TargetObj.gameObject.tag == "Item" && dist < PickUpRange)
            {
                PickUpItem();
            }
            else
            {
                MoveUpdate();
            }

        }
        MiniMapCamera.position = this.transform.position + Vector3.up * MiniMapCamOffset;

        if (0.0f < attDelay)
            attDelay -= Time.deltaTime;
    }
    public void MoveUpdate()
    {

        dist = (transform.position - TargetVec).magnitude;
        if (0.1f < dist)
        {
            animState = AnimStates.Run;
            Quaternion targetRot = Quaternion.LookRotation(TargetVec - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, RotSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, TargetVec, MoveSpeed * Time.deltaTime);
        }
        else
        {
            animState = AnimStates.Idle;
        }

    }
    public void AttackEnemy()
    {
        if (attDelay < 0.1f)
        {
            animState = AnimStates.Attack;
            TargetObj.GetComponent<Enemy>().TakeDamage(50);
            Quaternion targetRot = Quaternion.LookRotation(TargetObj.transform.position - transform.position);
            transform.rotation = targetRot;
            attDelay = 2.0f;
        }
    }
    public void PickUpItem()
    {
        Debug.Log(TargetObj.GetComponent<ItemCtrl>().item.itemName);
        GlobalValue.AddItem(TargetObj.GetComponent<ItemCtrl>().item);
        Destroy(TargetObj);
        if (InventoryMgr.inst != null)
            InventoryMgr.inst.Refreshslot();
    }

    public void UseSkill(int index)
    {
        ActiveSkill skill = GlobalValue.PlayerSkill[index];
        if (skill != null)
        {
            if (skill.isCooling == false)
            {
                skill.UseActiveSkill(this.gameObject, transform);
                StartCoroutine(skill.SkillCoolTime(SkPanelImages[index]));
            }
        }
        else
        {
            Debug.Log("Skill Is Empty");
        }
    }
    public void ChangeSkill(ActiveSkill newSkill, int index)
    {
        if (newSkill != null && 0 < newSkill.skillPoint && 0 <= index && index < GlobalValue.PlayerSkill.Length)
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
