using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    SkillNode SkNode;

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
                SkNode.ChangeSkillPoint(1);
                RefreshUI();
            });
        if (SkPointDownBtn != null)
            SkPointDownBtn.onClick.AddListener(() =>
            {
                SkNode.ChangeSkillPoint(-1);
                RefreshUI();
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
                SkillMgr.inst.ShowSkillInfoOnOff(isMouseOn, SkNode);
                isMouseOn = false;
            }
        }
    }
    void RefreshUI()
    {
        IconImage.sprite = Resources.Load<Sprite>(SkNode.skill.spriteName);
        if (SkNode.skill.skillPoint <= 0)
        {
            IconImage.color = new Color32(100, 100, 100, 255);
            this.gameObject.GetComponent<Image>().raycastTarget = false;
        }
        else
        {
            IconImage.color = new Color32(255, 255, 255, 255);
            this.gameObject.GetComponent<Image>().raycastTarget = true;
        }

        SkillPointText.text = SkNode.skill.skillPoint + "/" + SkNode.skill.maxSkillPoint;
    }

    public void SetNode(SkillNode node)
    {
        SkNode = node;
        RefreshUI();
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
        GameMgr.inst.OnDragNode = SkNode;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        IconImage.transform.position = startPos;
        GameMgr.inst.OnDragNode = null;
    }


}
