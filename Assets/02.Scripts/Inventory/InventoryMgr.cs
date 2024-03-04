using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum InventoryTabType
{
    equipment,
    consumable,
    Other
}

public interface Wearalbe
{
    void WearEquip();

}

public class InventoryMgr : MonoBehaviour
{


    //인벤토리에 아이템 최댓값
    public const int MaxItemCount = 28;
    public const int PlayerEquipment = 6;


    //------------Status----------------//
    [Header("------------Status------------")]
    public GameObject StatusPanel;


    //status창의 수치 조절
    public Text HpText;
    public Text AttText;
    public Text DefText;

    //status창의 장비 슬롯
    public static GameObject[] PlayerEquip = new GameObject[PlayerEquipment];





    //------------Status----------------//





    //------------Inventory-------------//
    [Header("------------Inventory------------")]
    public GameObject InventoryPanel;
    //노드에 담길 equipment배열
    ItemSlot[] ItemSlots = new ItemSlot[MaxItemCount];
    Item[] ItemArr = new Item[MaxItemCount];

    //Player가 가지고 있는 아이템 리스트
    public static List<EquipItem> EquipItemList = new List<EquipItem>();
    public static List<ConsumItem> ConsumItemList = new List<ConsumItem>();
    public static List<OtherItem> OtheritemList = new List<OtherItem>();




    //------------Inventory-------------//

    //------------TabType-------------//
    [Header("------------TabButton------------")]
    public InventoryTabType TabType = InventoryTabType.equipment;
    public Button EquipmentTab;
    public Button ConsumTab;
    public Button OtherTab;



    //싱글톤
    public static InventoryMgr inst = null;


    private void Awake()
    {
        inst = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        ItemSlots = this.GetComponentsInChildren<ItemSlot>();


        //TabButton 처리
        if (EquipmentTab != null)
            EquipmentTab.onClick.AddListener(() =>
            {
                TabType = InventoryTabType.equipment;
                Refreshslot();
            });
        if (ConsumTab != null)
            ConsumTab.onClick.AddListener(() =>
            {
                TabType = InventoryTabType.consumable;
                Refreshslot();
            });
        if (OtherTab != null)
            OtherTab.onClick.AddListener(() =>
            {
                TabType = InventoryTabType.Other;
                Refreshslot();
            });
        //TabButton 처리


        Refreshslot();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            EquipItemList.Add(new EquipItem());
            Refreshslot();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            ConsumItemList.Add(new ConsumItem(5.0f));
            Debug.Log("아이템 이름 = " + ConsumItemList[0].itemName);
            StartCoroutine(ConsumItemList[0].ItemCool());
        }
    }

    public void WearEquip(EquipItem equip)
    {
        //PlayerEquip = StatusPanel.GetComponentsInChildren<ItemSlot>();


    }

    //슬롯에 아이템 넣기
    //아이템 배열에 
    void Refreshslot()
    {
        for (int i = 0; i < MaxItemCount; i++)
        {
            ItemArr[i] = null;
        }
        if (TabType == InventoryTabType.equipment)
        {
            for (int i = 0; i < EquipItemList.Count; i++)
            {
                ItemArr[i] = EquipItemList[i];
            }
        }
        else if (TabType == InventoryTabType.consumable)
        {
            for (int i = 0; i < ConsumItemList.Count; i++)
            {
                ItemArr[i] = ConsumItemList[i];
            }
        }
        else if (TabType == InventoryTabType.Other)
        {
            for (int i = 0; i < OtheritemList.Count; i++)
            {
                ItemArr[i] = OtheritemList[i];
            }
        }
        for (int i = 0; i < ItemSlots.Length; i++)
        {
            ItemSlots[i].TestSetting(ItemArr[i]);
        }

    }

    /*   void Refreshslot()
       {
           //Debug.Log("슬롯 갯수 : " + ItemSlots.Length);

           int endNum = 0;
           if (TabType == InventoryTabType.equipment)
           {
               for (int i = 0; i < EquipItemList.Count; i++)
               {
                   ItemSlots[i].SetSlot(EquipItemList[i]);
               }
               endNum = EquipItemList.Count;
           }

           else if (TabType == InventoryTabType.consumable)
           {
               for (int i = 0; i < ConsumItemList.Count; i++)
               {
                   ItemSlots[i].SetSlot(null, ConsumItemList[i]);
               }
               endNum = ConsumItemList.Count;
           }

           else if (TabType == InventoryTabType.Other)
           {
               for (int i = 0; i < OtheritemList.Count; i++)
               {
                   ItemSlots[i].SetSlot(null, null, OtheritemList[i]);
               }
               endNum = OtheritemList.Count;
           }
           //빈 아이템 슬롯 설정
           if (endNum < ItemSlots.Length)
           {
               for (int i = endNum; i < ItemSlots.Length; i++)
               {
                   ItemSlots[i].SetSlot(null, null, null, true);
               }
           }
       }*/


}
