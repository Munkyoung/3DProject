using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillMgr : MonoBehaviour
{
    //스킬 슬롯들의 배열
    SkillSlot[] Slots = null;

    //미정
    List<Skill> skillList = new List<Skill>();

    //스킬루트 
    SkillNode SkillRoot;
    int SlotIndex = 0;

    public GameObject SkillInfoPanel;
    public Text SkInfoText;
    public Text SkInfoPointText;
    public Image SkInfoIconImage;

    public static SkillMgr inst = null;

    private void Awake()
    {
        inst = this;
        Slots = GetComponentsInChildren<SkillSlot>();
        SkillRoot = RootSkill.TestMakeRoot();
    }
    // Start is called before the first frame update
    void Start()
    {
        GetSkillList(SkillRoot);
        SlotIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            GetSkillList(SkillRoot);
            SlotIndex = 0;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            RootSkill.PrintData(SkillRoot);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            //RootSkill.SkillPointUpDown(SkillRoot, new PassiveSkill_HpUp(), 1);
        }
    }
    public void GetSkillList(SkillNode root)
    {
        Slots[SlotIndex].RefreshSlot(root.skill);
        SlotIndex++;
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

    public void ShowSkillInfoOnOff(bool isOn, Skill skill = null)
    {
        if (isOn)
        {
            if(skill == null)
            {
                Debug.Log("skill null");
            }
            else
            {
                Debug.Log(skill.skillName);
            }
            SkillInfoPanel.transform.position = Input.mousePosition;
            SkillInfoPanel.gameObject.SetActive(true);
            SkInfoIconImage.sprite = Resources.Load<Sprite>(skill.spriteName);
            SkInfoPointText.text = skill.GetSkPoint();
            SkInfoText.text = skill.skillInfo;
        }
        else
        {
            SkillInfoPanel.gameObject.SetActive(false);
        }
    }

}
