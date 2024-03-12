using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeState
{
    Success,
    Failure,
    Running
}

//�θ� ��� 
//�ڽ� ������ List������ ��������
//Evaluate�����Լ��� ���� ����
public abstract class Node
{
    protected List<Node> child = new List<Node>();

    public void AddNode(Node node)
    {
        this.child.Add(node);
    }

    public virtual NodeState Evaluate()
    {
        return NodeState.Failure;
    }

}


//�׼ǳ��
//���� �ൿ�� �ϴ� ���
//Tree������ Leaf�� �ش� �Ǿ�� �Ѵ�
public class ActionNode : Node
{
    Func<NodeState> action;
    public ActionNode(Func<NodeState> action)
    {
        this.action = action;
    }

    public override NodeState Evaluate()
    {
        return action();
    }
}
public class IsNearPlayer : Node
{
    Transform transform;
    Transform PlayerTr;
    float dist;
    Animator anim;


    public IsNearPlayer(Transform transform, Transform playerTr)
    {
        this.transform = transform;
        PlayerTr = playerTr;
        dist = (transform.position - playerTr.position).magnitude;
        this.anim = this.transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        //���� ����
        if (dist < 5.0f)
            return NodeState.Success;
        else
            return NodeState.Failure;
    }
}
public class TraceAction : Node
{
    Transform transform;
    Transform PlayerTr;
    float dist;
    Animator anim;


    public TraceAction(Transform transform, Transform playerTr)
    {
        this.transform = transform;
        PlayerTr = playerTr;
        dist = (transform.position - playerTr.position).magnitude;
        this.anim = this.transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        this.transform.LookAt(PlayerTr);
        this.transform.position = Vector3.Lerp(transform.position, PlayerTr.position, Time.deltaTime);

        return NodeState.Running;
    }
}

public class AttackAction : Node
{
    Animator anim;


    public override NodeState Evaluate()
    {

        return NodeState.Running;
    }
}


//SequenceNode
//AND ���� �ڽ��� ��� ��尡 True(Success or Running�� �����ؾ�) True ����
public class Sequence : Node
{
    public override NodeState Evaluate()
    {
        bool isChildRunning = false;
        foreach (Node node in child)
        {
            NodeState result = node.Evaluate();
            if (result == NodeState.Failure)
                return result;
            else if (result == NodeState.Running)
                isChildRunning = true;
        }
        if (isChildRunning)
            return NodeState.Running;
        else
            return NodeState.Success;
    }
}


//������ ���
//�ڽ� ������ Success�� �����ϴ°��� ������ ���� �ݺ�
//ex)idle , move, att �������� �ݵ�� �����ؾ��Ѵ�
public class Selector : Node
{
    public override NodeState Evaluate()
    {
        foreach (Node node in child)
        {
            NodeState result = node.Evaluate();
            if (result == NodeState.Success)
                return NodeState.Success;
            else if (result == NodeState.Running)
                return NodeState.Running;
        }
        return NodeState.Failure;
    }
}

public class Decorate : Node
{
    public override NodeState Evaluate()
    {
        return base.Evaluate();
    }

}

