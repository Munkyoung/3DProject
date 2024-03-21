using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //행동 트리 루트
    Selector BehaviourRoot;

    //드랍 테이블에서 가져온 아이템을 담을 변수
    SOItem DropItem;

    //플레이어 게임 오브젝트
    GameObject Target;
    public Animator Animator;

    float Hp = 200;
    public float hp { get => Hp; set => Hp = value; }
    float MaxHp = 200;


    // Start is called before the first frame update
    void Start()
    {
        //Animator = GetComponent<Animator>();
        Target = GameObject.Find("Player");

        BehaviourRoot = new Selector();
        //BehaviourRoot.AddNode(new CheckDie(this.gameObject, Animator));

        Sequence InAttRange = new Sequence();
        InAttRange.AddNode(new CheckInAttackRange(this.gameObject, Target, Animator));
        InAttRange.AddNode(new AttackAction(Animator));
        BehaviourRoot.AddNode(InAttRange);

        //추적 시퀀스안에 
        Sequence InTraceRange = new Sequence();
        InTraceRange.AddNode(new CheckNearbyTarget(this.gameObject, Target, Animator));
        InTraceRange.AddNode(new TraceAction(this.gameObject, Target, Animator));
        BehaviourRoot.AddNode(InTraceRange);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            EnemyDie();
        }
        if (0.0f < hp)
        {
            BehaviourRoot.Evaluate();
        }
    }

    public void EnemyDie()
    {
        hp = -1.0f;
        Animator.SetTrigger("Die");
        DropItem = this.GetComponent<ItemTable>().GetItem();
        this.GetComponent<CapsuleCollider>().enabled = false;
        float randx = Random.Range(-1, 1);
        float randz = Random.Range(-1, 1);
        Instantiate(DropItem);
        Vector3 DropPositon = new Vector3(transform.position.x - randx, transform.position.y, transform.position.z + randz);
        GameObject dropitem = Instantiate(DropItem.Prefab, DropPositon, Quaternion.identity) as GameObject;
        dropitem.GetComponent<ItemCtrl>().item = DropItem;
        Destroy(dropitem, 10.0f);
        Destroy(this.gameObject, 5.0f);
    }

}
