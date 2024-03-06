using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour ,IDropHandler
{
    public EquipItem equipItem;
    public EquipItem dragItem;
    [SerializeField] EquipItem.EquipType equipType;

    public Image SlotImage;

    public void OnDrop(PointerEventData eventData)
    {
        if (InventoryMgr.inst.OnDragItem is EquipItem)
        {
            dragItem = InventoryMgr.inst.OnDragItem as EquipItem;
            if (dragItem.type == equipType)
            {
                InventoryMgr.inst.IsDrop = true;
                equipItem = dragItem;
                SlotImage.sprite = Resources.Load<Sprite>(equipItem.spriteName);
            }
            else
            {
                //장비 타입이 다를때
                InventoryMgr.inst.IsDrop = false;
                return;
            }
        }
        else
        {
            //장비 아이템이 아닌경우
            InventoryMgr.inst.IsDrop = false;
            return;
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
