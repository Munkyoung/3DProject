using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillNode
{
    // SkillÇü ´ë½Å string
    public Skill skill;
    public List<SkillNode> child;

    public SkillNode(Skill skill)
    {
        this.skill = skill;
        child = new List<SkillNode>();
    }

    public void ChangeSkillPoint(int value)
    {
        if (value == 0) return;
        if (value > 0)
        {
            if (CheckSkillPointUp(GlobalValue.SkillTree))
                skill.PointUpDown(value);
        }
        else
        {
            if (CheckSkillPointDown())
                skill.PointUpDown(value);
        }
    }
    public bool CheckSkillPointDown()
    {
        if (1 < skill.skillPoint) return true;
        bool anyChildHasSkillPoint = true;
        foreach (SkillNode node in child)
        {
            if (0 < node.skill.skillPoint)
            {
                anyChildHasSkillPoint = false;
                break;
            }
            node.CheckSkillPointDown();
        }
        return anyChildHasSkillPoint;
    }
    public bool CheckSkillPointUp(SkillNode root)
    {
        if (root.skill == skill)
        {
            return true;
        }
        else
        {
            if (0 < root.skill.skillPoint)
            {
                foreach (SkillNode node in root.child)
                {
                    if (CheckSkillPointUp(node))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}


class RootSkill
{
    public static SkillNode CreateRoot()
    {
        SkillNode Root = new SkillNode(new PassiveSkill_HpUp());
        {
            {
                SkillNode node = new SkillNode(new PassiveSkill_PowerUp());
                node.child.Add(new SkillNode(new ActiveSkill_Swing()));
                Root.child.Add(node);
            }

            {
                SkillNode node = new SkillNode(new PassiveSkill_DefUp());
                node.child.Add(new SkillNode(new ActiveSkill_Heal()));
                Root.child.Add(node);
            }

            {
                SkillNode node = new SkillNode(new PassiveSkill_SpeedUp());
                node.child.Add(new SkillNode(new ActiveSkill_Rush()));
                Root.child.Add(node);
            }

        }
        return Root;
    }
}



