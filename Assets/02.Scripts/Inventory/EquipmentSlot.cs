using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour, IDropHandler
{
    public SOEquipment equipItem;
    public SOEquipment dragItem;
    [SerializeField]
    EquipType EquipType;

    public Image SlotImage;

    public void OnDrop(PointerEventData eventData)
    {
        dragItem = InventoryMgr.inst.WearEquip(EquipType);
        if (dragItem != null)
        {
            equipItem = dragItem;
        }
        else
        {
            return;
        }
        RefreshSlot();

    }
    public void RefreshSlot()
    {
        SlotImage.sprite = Resources.Load<Sprite>(equipItem.spriteName);
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
