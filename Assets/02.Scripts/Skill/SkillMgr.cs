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
    static SkillNode SkillRoot;
    int SlotIndex = 0;


    public GameObject SkillInfoPanel;
    public Image SkInfoIconImage;
    public Text SkInfoSkillName;
    public Text SkInfoSkillPoint;
    public Text SkInfoSkillDesc;


    public static SkillMgr inst = null;

    private void Awake()
    {
        inst = this;
        Slots = GetComponentsInChildren<SkillSlot>();
    }
    // Start is called before the first frame update
    void Start()
    {
        GetSkillList(GlobalValue.SkillTree);
        SlotIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {

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
            if (skill == null)
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
            SkInfoSkillPoint.text = skill.GetSkPoint();
            SkInfoSkillDesc.text = skill.skillInfo;
        }
        else
        {
            SkillInfoPanel.gameObject.SetActive(false);
        }
    }

}
