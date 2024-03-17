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
public class CheckNearbyTarget : Node
{
    GameObject Subject;
    GameObject Target;

    float dist;
    Animator animator;

    public CheckNearbyTarget(GameObject subject, GameObject target, Animator Anim)
    {
        Subject = subject;
        Target = target;
        this.animator = Anim;
    }
    public override NodeState Evaluate()
    {
        dist = (Subject.transform.position - Target.transform.position).magnitude;
        //추적 범위
        if (dist < 5.0f)
            return NodeState.Success;
        else
        {
            animator.SetBool("IsTrace", false);
            return NodeState.Failure;
        }
    }
}
public class TraceAction : Node
{
    GameObject Subject;
    GameObject Target;
    float dist;
    Animator Animator;

    public TraceAction(GameObject subject, GameObject target, Animator anim)
    {
        Subject = subject;
        Target = target;
        this.Animator = anim;
    }

    public override NodeState Evaluate()
    {
        Debug.Log("Treacing");
        Animator.SetBool("IsTrace", true);
        Subject.transform.LookAt(Target.transform);
        Subject.transform.position = Vector3.Lerp(Subject.transform.position, Target.transform.position, Time.deltaTime);
        return NodeState.Running;
    }
}
public class CheckInAttackRange : Node
{
    GameObject Subject;
    GameObject Target;
    Animator Animator;
    float AttRange = 1.5f;
    float dist;
    public CheckInAttackRange(GameObject subject, GameObject target, Animator anim)
    {
        Subject = subject;
        Target = target;
        Animator = anim;
    }

    public override NodeState Evaluate()
    {
        dist = (Subject.transform.position - Target.transform.position).magnitude;

        if (dist < AttRange)
            return NodeState.Success;
        else
        {
            Animator.SetBool("Attack", false);
            return NodeState.Failure;
        }
        
    }
}
public class AttackAction : Node
{
    Animator Anim;
  
    public AttackAction(Animator anim)
    {
        Anim = anim;
    }
    public override NodeState Evaluate()
    {
        Debug.Log("Attack");
        Anim.SetBool("Attack", true);
        
        return NodeState.Running;
    }
}
public class CheckDie : Node
{
    GameObject Subject;
    Animator animator;
    public CheckDie(GameObject subject, Animator anim)
    {
        Subject = subject;
        animator = anim;
    }

    public override NodeState Evaluate()
    {
        if (Subject.GetComponent<Enemy>().hp < 0.0f)
        {
            animator.SetTrigger("Die");
            return NodeState.Success;
        }
        else
            return NodeState.Failure;
    }
}
public class DieAction
{

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
            {
                return result;
            }
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



