using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    Skill SlotSkill;

    public Image IconImage;
    public Text SkillPointText;

    float ShowInfoTimer;
    const float ShowInfoTime = 0.5f;
    bool isMouseOn = false;

    public Button SkPointUpBtn;
    public Button SkPointDownBtn;

    Vector3 startPos;
    Image DragItem;
    // Start is called before the first frame update
    void Start()
    {
        ShowInfoTimer = ShowInfoTime;

        if (SkPointUpBtn != null)
            SkPointUpBtn.onClick.AddListener(() =>
            {
                RootSkill.CheckSkillPoint(GlobalValue.SkillTree, SlotSkill.skillName, 1);
                SetSlot();
            });
        if (SkPointDownBtn != null)
            SkPointDownBtn.onClick.AddListener(() =>
            {
                RootSkill.CheckSkillPoint(GlobalValue.SkillTree, SlotSkill.skillName, -1);
                SetSlot();
            });
    }

    // Update is called once per frame
    void Update()
    {
        if (isMouseOn)
        {
            if (0.0f < ShowInfoTimer)
                ShowInfoTimer -= Time.deltaTime;
            else
            {
                SkillMgr.inst.ShowSkillInfoOnOff(isMouseOn, SlotSkill);
                isMouseOn = false;
            }
        }
    }

    public void SetSlot(Skill skill = null)
    {
        if (skill != null)
            this.SlotSkill = skill;

        IconImage.sprite = Resources.Load<Sprite>(SlotSkill.spriteName);
        if (SlotSkill.skillPoint <= 0)
        {
            IconImage.color = new Color32(100, 100, 100, 255);
        }
        else
        {
            IconImage.color = new Color32(255, 255, 255, 255);
        }
        SkillPointText.text = SlotSkill.skillPoint + "/" + SlotSkill.maxSkillPoint.ToString();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOn = false;
        ShowInfoTimer = ShowInfoTime;
        SkillMgr.inst.ShowSkillInfoOnOff(isMouseOn);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOn = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        IconImage.transform.position = Input.mousePosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = transform.position;
        GameMgr.inst.OnDragSkill = SlotSkill;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        IconImage.transform.position = startPos;
        GameMgr.inst.OnDragSkill = null;
    }


}
