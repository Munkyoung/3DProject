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

//부모 노드 
//자식 노드들을 List형으로 갖고있음
//Evaluate가상함수를 갖고 있음
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
        //추적 범위
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
//AND 역할 자식의 모든 노드가 True(Success or Running을 리턴해야) True 리턴
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

public class Decorate : Node
{
    public override NodeState Evaluate()
    {
        return base.Evaluate();
    }

}

