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
        //���� ����
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



