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
        if (GameMgr.inst.OnDragSkill != null && 0 < GameMgr.inst.OnDragSkill.skillPoint)
        {
            Debug.Log(GameMgr.inst.OnDragSkill.skillName);
            Skill = GameMgr.inst.OnDragSkill;
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
