using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillPanel : MonoBehaviour, IDropHandler
{
    Skill Skill;
    [SerializeField]
    int SlotIndex;
    public Image SkillIcon;

    public void OnDrop(PointerEventData eventData)
    {
        SetSkillPanel();
    }



    public void SetSkillPanel()
    {
        if (GameMgr.inst.OnDragNode != null && 0 < GameMgr.inst.OnDragNode.skill.skillPoint)
        {
            Debug.Log(GameMgr.inst.OnDragNode.skill.skillName);
            Skill = GameMgr.inst.OnDragNode.skill;
            GlobalValue.PlayerSkill[SlotIndex] = Skill as ActiveSkill;
            Refresh();
            Debug.Log("¼Â");
        }
    }

    public void Refresh()
    {
        Skill = GlobalValue.PlayerSkill[SlotIndex];
        if (Skill != null)
        {
            SkillIcon.sprite = Resources.Load<Sprite>(Skill.spriteName);
        }
    }

    // Start is called before the first frame update    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
