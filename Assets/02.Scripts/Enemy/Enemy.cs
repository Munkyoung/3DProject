using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Selector root;

    public NodeState Trace()
    {
        //추적 구현

        Debug.Log("추적");
        return NodeState.Success;
    }
    public NodeState Attack()
    {
        //공격구현
        Debug.Log("공격");
        return NodeState.Success;
    }
    public NodeState Idle()
    {
        //정지 상태 구현
        Debug.Log("정지");
        return NodeState.Success;
    }


    // Start is called before the first frame update
    void Start()
    {
        root = new Selector();
        ActionNode actionNode = new ActionNode(Trace);
    }

    // Update is called once per frame
    void Update()
    {
        root.Evaluate();
    }
}
