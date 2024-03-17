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
    public const int MaxInventoryCount = 28;
    public const int PlayerEquipment = 6;




    //==================================//
    //------------Status----------------//
    [Header("------------Status------------")]
    public GameObject StatusPanel;


    //statusâ�� ��ġ ����
    public Text HpText;
    public Text AttText;
    public Text DefText;

    //statusâ�� ��� ����
    public GameObject[] PlayerEquip = new GameObject[PlayerEquipment];//
    public static EquipItem[] equipItems; //�÷��̾� ��� ����ƽ
    //------------Status----------------//
    //==================================//





    //==================================//
    //------------Inventory-------------//
    [Header("------------Inventory------------")]
    public GameObject InventoryPanel;
    //��忡 ��� equipment�迭
    ItemSlot[] ItemSlots = new ItemSlot[MaxInventoryCount];
    Item[] ItemArr = new Item[MaxInventoryCount];

    //Player�� ������ �ִ� ������ ����Ʈ
    public static List<EquipItem> EquipItemList = new List<EquipItem>();
    public static List<ConsumItem> ConsumItemList = new List<ConsumItem>();
    public static List<OtherItem> OtheritemList = new List<OtherItem>();

    //------------Inventory-------------//
    //==================================//







    //==================================//
    //------------TabType-------------//
    [Header("------------TabButton------------")]
    public InventoryTabType TabType = InventoryTabType.equipment;
    public Button EquipmentTab;
    public Button ConsumTab;
    public Button OtherTab;
    //------------TabType-------------//
    //==================================//

    //DragDrop
    public bool IsDrop = false;
    public Item OnDragItem = null;
    int TestInt = 0;
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
        //------�׽�Ʈ��-------
        if (Input.GetKeyDown(KeyCode.Q))
        {
            EquipItem Testequip = new EquipItem();
            Testequip.count = TestInt;
            Testequip.type = EquipItem.EquipType.Helmet;
            TestInt++;
            EquipItemList.Add(Testequip);
            Refreshslot();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            ConsumItemList.Add(new ConsumItem(5.0f));
            Debug.Log("������ �̸� = " + ConsumItemList[0].itemName);
            StartCoroutine(ConsumItemList[0].ItemCool());
        }

        //------�׽�Ʈ��-------
    }

    public void WearEquip(EquipItem equip)
    {
        //PlayerEquip = StatusPanel.GetComponentsInChildren<ItemSlot>();


    }

    //���Կ� ������ �ֱ�
    //������ �迭�� 
    public void Refreshslot()
    {
        for (int i = 0; i < MaxInventoryCount; i++)
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
            ItemSlots[i].SetSlot(ItemArr[i]);
        }
    }

    public bool WearEquip()
    {
        return false;
    }


}
