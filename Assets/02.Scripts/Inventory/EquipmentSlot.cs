using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour, IDropHandler
{
    public SOEquipment equipItem;
    public SOEquipment dragItem;
    [SerializeField] EquipItem.EquipType equipType;

    public Image SlotImage;

    public void OnDrop(PointerEventData eventData)
    {
        if (InventoryMgr.inst.OnDragItem is SOEquipment)
        {
           /* dragItem = InventoryMgr.inst.OnDragItem as SOEquipment;
            InventoryMgr.inst.IsDrop = true;
            equipItem = dragItem;
            SlotImage.sprite = Resources.Load<Sprite>(equipItem.spriteName);
            if ()
            {

            }
            else
            {
                //��� Ÿ���� �ٸ���
                InventoryMgr.inst.IsDrop = false;
                return;
            }*/
        }
        else
        {
            //��� �������� �ƴѰ��
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
