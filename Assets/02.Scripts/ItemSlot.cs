using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class ItemSlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, Wearalbe
{
    //아이템 이미지
    EquipItem Slot_equip;
    OtherItem Slot_Other;
    ConsumItem Slot_Consum;

    public Image IconImage;
    public Text CountText;
    Item SlotItem;

    //-------------drop------------//
    Vector3 startPositon = Vector3.zero;
    Transform onDragParent;
    Transform startParent;
    //-------------drop------------//

    public void WearEquip()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPositon = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = startPositon;
    }

    public void TestSetting(Item item = null)
    {
        
        if (item is EquipItem)
        {
            SlotItem = item as EquipItem;
        }
        else if (item is ConsumItem)
        {
            SlotItem = item as ConsumItem;
        }
        else if (item is OtherItem)
        {
            SlotItem = item as OtherItem;
        }
        if (SlotItem != null)
        {
            //빈 처리
            IconImage.sprite = Resources.Load<Sprite>(SlotItem.spriteName);
            CountText.text = SlotItem.count.ToString();
        }
        else
        {
            IconImage.sprite = Resources.Load<Sprite>("Sprites/Item/Empty");
            CountText.text = string.Empty;
        }
    }

   /* public void SetSlot(EquipItem equip = null, ConsumItem consum = null, OtherItem other = null, bool IsEmpty = false)
    {
        if (equip != null)
        {
            Debug.Log("장비 업데이트");
            Slot_equip = equip;
            Debug.Log("스프라이트" + Slot_equip.spriteName);
            IconImage.sprite = Resources.Load<Sprite>(Slot_equip.spriteName);
            CountText.text = Slot_equip.count.ToString();
        }
        else if (consum != null)
        {
            Slot_Consum = consum;
            IconImage.sprite = Resources.Load<Sprite>(Slot_Consum.spriteName);
            CountText.text = Slot_Consum.count.ToString();
        }
        else if (other != null)
        {
            Slot_Other = other;
            IconImage.sprite = Resources.Load<Sprite>(Slot_Other.spriteName);
            CountText.text = Slot_Other.count.ToString();
        }
        else if (IsEmpty == true)
        {
            IconImage.sprite = Resources.Load<Sprite>("Sprites/Item/Empty");
            CountText.text = string.Empty;
        }
    }*/

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
