using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class ItemSlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    //아이템 이미지
    public Image IconImage;
    public Text CountText;
    SOItem SlotItem;

    //-------------drop------------//
    Vector3 startPositon = Vector3.zero;
    Transform onDragParent;
    Transform startParent;
    //-------------drop------------//


    public void OnBeginDrag(PointerEventData eventData)
    {
        startPositon = transform.position;
        if (SlotItem is SOEquipment)
            InventoryMgr.inst.OnDragItem = SlotItem as SOEquipment;
    }

    public void OnDrag(PointerEventData eventData)
    {
        IconImage.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        InventoryMgr.inst.Refreshslot();
        IconImage.transform.position = startPositon;
    }

    public void SetSlot(SOItem item = null)
    {

        if (item is SOEquipment)
        {
            SlotItem = item as SOEquipment;
        }
        else if (item is SOConsum)
        {
            SlotItem = item as SOConsum;
        }
        else if (item is SOEtc)
        {
            SlotItem = item as SOEtc;
        }
        else
        {
            SlotItem = null;
        }
        SlotItem = item;
        RefreshSlot();
    }
    public void RefreshSlot()
    {
        if (SlotItem != null)
        {
            //빈 처리
            Debug.Log(SlotItem.itemName);
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
