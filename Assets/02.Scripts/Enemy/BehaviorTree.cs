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


//액션노드
//직접 행동을 하는 노드
//Tree구조에 Leaf에 해당 되어야 한다
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


//셀랙터 노드
//자식 노드들중 Success를 리턴하는것이 있을때 까지 반복
//ex)idle , move, att 가있을때 반드시 선택해야한다
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

