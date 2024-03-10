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

public abstract class Node
{
    protected List<Node> child = new List<Node>();

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
            else if (result == NodeState.Failure)
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

