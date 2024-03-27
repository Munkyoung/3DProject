using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillMgr : MonoBehaviour
{
    //스킬 슬롯들의 배열
    SkillSlot[] Slots = null;
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
        Slots[SlotIndex].SetNode(root);
        SlotIndex++;
        foreach (SkillNode node in root.child)
        {
            GetSkillList(node);
        }
    }


    public void ShowSkillInfoOnOff(bool isOn, SkillNode node = null)
    {
        if (isOn)
        {
            if (node == null)
            {
                Debug.Log("skill null");
            }
            else
            {
                Debug.Log(node.skill.skillName);
                SkillInfoPanel.transform.position = Input.mousePosition;
                SkillInfoPanel.gameObject.SetActive(true);
                SkInfoIconImage.sprite = Resources.Load<Sprite>(node.skill.spriteName);
                SkInfoSkillPoint.text = node.skill.GetSkPoint();
                SkInfoSkillDesc.text = node.skill.skillInfo;
            }
        }
        else
        {
            SkillInfoPanel.gameObject.SetActive(false);
        }
    }

}
