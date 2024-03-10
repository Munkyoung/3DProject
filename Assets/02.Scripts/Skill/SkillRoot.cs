using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkillNode
{
    // Skill형 대신 string
    public string SkillName { get; set; }
    public int skillPoint { get; set; } = 0;
    public List<SkillNode> child { get; set; } = new List<SkillNode>();

    // 이름 포인트
}

class RootSkill
{
    public static SkillNode TestMakeRoot()
    {
        SkillNode TestRoot = new SkillNode() { SkillName = "A" };
        {
            {
                SkillNode node = new SkillNode() { SkillName = "A-A" };
                node.child.Add(new SkillNode() { SkillName = "A-A-A" });
                node.child.Add(new SkillNode() { SkillName = "A-A-B" });
                node.child.Add(new SkillNode() { SkillName = "A-A-C" });
                TestRoot.child.Add(node);
            }

            {
                SkillNode node = new SkillNode() { SkillName = "A-B" };
                node.child.Add(new SkillNode() { SkillName = "A-B-A" });
                node.child.Add(new SkillNode() { SkillName = "A-B-B" });
                node.child.Add(new SkillNode() { SkillName = "A-B-C" });
                TestRoot.child.Add(node);
            }

            {
                SkillNode node = new SkillNode() { SkillName = "A-C" };
                node.child.Add(new SkillNode() { SkillName = "A-C-A" });
                node.child.Add(new SkillNode() { SkillName = "A-C-B" });
                node.child.Add(new SkillNode() { SkillName = "A-C-C" });
                TestRoot.child.Add(node);
            }
        }
        return TestRoot;
    }


    public static void PrintData(SkillNode root)
    {
        Debug.Log(root.SkillName + " = " + root.skillPoint);
        foreach (SkillNode node in root.child)
        {
            PrintData(node);
        }
    }


    public static void SkillPointUpDown(SkillNode root, string skillname, int value)
    {
        if (root.SkillName == skillname)
        {
            root.skillPoint += 1 * value;
            Debug.Log(root.SkillName);
            Debug.Log(root.skillPoint);
            return;
        }
        else
        {
            if (0 < root.skillPoint)
            {
                foreach (SkillNode node in root.child)
                {
                    SkillPointUpDown(node, skillname, value);
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

