using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Selector root;

    public NodeState Trace()
    {
        //���� ����

        Debug.Log("����");
        return NodeState.Success;
    }
    public NodeState Attack()
    {
        //���ݱ���
        Debug.Log("����");
        return NodeState.Success;
    }
    public NodeState Idle()
    {
        //���� ���� ����
        Debug.Log("����");
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
