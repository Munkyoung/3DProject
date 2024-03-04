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


    //�κ��丮�� ������ �ִ�
    public const int MaxItemCount = 28;
    public const int PlayerEquipment = 6;


    //------------Status----------------//
    [Header("------------Status------------")]
    public GameObject StatusPanel;


    //statusâ�� ��ġ ����
    public Text HpText;
    public Text AttText;
    public Text DefText;

    //statusâ�� ��� ����
    public static GameObject[] PlayerEquip = new GameObject[PlayerEquipment];





    //------------Status----------------//





    //------------Inventory-------------//
    [Header("------------Inventory------------")]
    public GameObject InventoryPanel;
    //��忡 ��� equipment�迭
    ItemSlot[] ItemSlots = new ItemSlot[MaxItemCount];
    Item[] ItemArr = new Item[MaxItemCount];

    //Player�� ������ �ִ� ������ ����Ʈ
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



    //�̱���
    public static InventoryMgr inst = null;


    private void Awake()
    {
        inst = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        ItemSlots = this.GetComponentsInChildren<ItemSlot>();


        //TabButton ó��
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
        //TabButton ó��


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
            Debug.Log("������ �̸� = " + ConsumItemList[0].itemName);
            StartCoroutine(ConsumItemList[0].ItemCool());
        }
    }

    public void WearEquip(EquipItem equip)
    {
        //PlayerEquip = StatusPanel.GetComponentsInChildren<ItemSlot>();


    }

    //���Կ� ������ �ֱ�
    //������ �迭�� 
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
           //Debug.Log("���� ���� : " + ItemSlots.Length);

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
           //�� ������ ���� ����
           if (endNum < ItemSlots.Length)
           {
               for (int i = endNum; i < ItemSlots.Length; i++)
               {
                   ItemSlots[i].SetSlot(null, null, null, true);
               }
           }
       }*/


}
