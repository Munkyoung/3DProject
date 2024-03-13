using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Skill SlotSkill;

    public Image slotImage;
    public Text skillCountText;

    float ShowInfoTimer;
    const float ShowInfoTime = 0.5f;
    bool isMouseOn = false;

    public Button SkPointUpBtn;
    public Button SkPointDownBtn;



    // Start is called before the first frame update
    void Start()
    {
        ShowInfoTimer = ShowInfoTime;

        if (SkPointUpBtn != null)
            SkPointUpBtn.onClick.AddListener(() =>
            {
                SlotSkill.PointUpDown(1);
                RefreshSlot();
            });
        if (SkPointDownBtn != null)
            SkPointDownBtn.onClick.AddListener(() =>
            {
                SlotSkill.PointUpDown(-1);
                RefreshSlot();
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

    public void RefreshSlot(Skill skill = null)
    {
        if (skill != null)
            this.SlotSkill = skill;
        slotImage.sprite = Resources.Load<Sprite>(SlotSkill.spriteName);
        skillCountText.text = SlotSkill.skillPoint + "/" + SlotSkill.maxSkillPoint.ToString();
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

}
