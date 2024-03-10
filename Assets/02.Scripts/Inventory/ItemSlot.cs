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
        InventoryMgr.inst.OnDragItem = SlotItem;
    }

    public void OnDrag(PointerEventData eventData)
    {
        IconImage.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (InventoryMgr.inst.IsDrop)
        {
            InventoryMgr.inst.IsDrop = false;
            InventoryMgr.EquipItemList.Remove(SlotItem as EquipItem);
            InventoryMgr.inst.Refreshslot();
        }
        else
        {

        }
        IconImage.transform.position = startPositon;
    }

    public void SetSlot(Item item = null)
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
        else
        {
            SlotItem = null;
        }
        RefreshSlot();
    }
    public void RefreshSlot()
    {
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
