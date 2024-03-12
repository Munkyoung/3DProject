using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillNode
{
    // Skill형 대신 string
    public Skill skill;
    public List<SkillNode> child;

    public SkillNode(Skill skill)
    {
        this.skill = skill;
        child = new List<SkillNode>();
    }
}

class RootSkill
{
    int index = 0;
    List<Skill> list = new List<Skill>();
    public void Treeee(List<string> skname, List<int> skPoint)
    {
    }
    public static SkillNode TestMakeRoot()
    {
        SkillNode TestRoot = new SkillNode(new PassiveSkill_HpUp());
        {
            {
                SkillNode node = new SkillNode(new PassiveSkill_PowerUp());
                node.child.Add(new SkillNode(new ActiveSkill_Swing()));
                TestRoot.child.Add(node);
            }

            {
                SkillNode node = new SkillNode(new PassiveSkill_DefUp());
                node.child.Add(new SkillNode(new ActiveSkill_Heal()));
                TestRoot.child.Add(node);
            }

            {
                SkillNode node = new SkillNode(new PassiveSkill_SpeedUp());
                node.child.Add(new SkillNode(new ActiveSkill_Rush()));
                TestRoot.child.Add(node);
            }

        }
        return TestRoot;
    }


    public static void PrintData(SkillNode root)
    {
        Debug.Log(root.skill.skillName + " : " + root.skill.skillInfo);
        foreach (SkillNode node in root.child)
        {
            PrintData(node);
        }
    }


    public static void SkillPointUpDown(SkillNode root, Skill skill, int value)
    {
        if (root.skill.skillName == skill.skillName)
        {
            root.skill.skillPoint += 1 * value;
            Debug.Log(root.skill.skillName);
            Debug.Log(root.skill.skillPoint);
            return;
        }
        else
        {
            if (0 < root.skill.skillPoint)
            {
                foreach (SkillNode node in root.child)
                {
                    SkillPointUpDown(node, skill, value);
                }
            }
            else
            {
                Debug.Log("root Point 부족");
            }
        }
    }

    public static void LoadSkillData(SkillNode root)
    {

    }
}

