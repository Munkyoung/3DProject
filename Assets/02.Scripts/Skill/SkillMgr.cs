using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMgr : MonoBehaviour
{
    //스킬 슬롯들의 배열
    SkillSlot[] Slots = null;

    //미정
    List<Skill> skillList = new List<Skill>();

    //스킬루트 
    SkillNode SkillRoot;
    int testIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        Slots = GetComponentsInChildren<SkillSlot>();
        SkillRoot = RootSkill.TestMakeRoot();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            GetSkillList(SkillRoot);
            testIndex = 0;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            RootSkill.PrintData(SkillRoot);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            RootSkill.SkillPointUpDown(SkillRoot, new PassiveSkill_HpUp(), 1);
        }
    }
    public void GetSkillList(SkillNode root)
    {
        Slots[testIndex].RefreshSlot(root.skill);
        testIndex++;
        foreach (SkillNode node in root.child)
        {
            GetSkillList(node);
        }
    }

    public void SetSlots()
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            Slots[i].RefreshSlot(skillList[i]);
        }
    }
}
