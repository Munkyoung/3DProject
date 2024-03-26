using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum InventoryTabType
{
    Tab_Equip,
    Tab_Consum,
    Tab_Etc
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

    //statusâ�� ������ ���� �ؽ�Ʈ
    public Text HpText;
    public Text AttText;
    public Text DefText;

    //statusâ�� ��� ����
    public GameObject[] PlayerEquip = new GameObject[PlayerEquipment];//
    public static SOEquipment[] equipItems; //�÷��̾� ��� ����ƽ
    //------------Status----------------//
    //==================================//


    //==================================//
    //------------Inventory-------------//
    [Header("------------Inventory------------")]
    public GameObject InventoryPanel;
    //��忡 ��� equipment�迭
    ItemSlot[] ItemSlots = new ItemSlot[MaxInventoryCount];
    SOItem[] ItemArr = new SOItem[MaxInventoryCount];

    //------------Inventory-------------//
    //==================================//





    //==================================//
    //------------TabType-------------//
    [Header("------------TabButton------------")]
    public Button EquipmentTab;
    public Button ConsumTab;
    public Button EtcTab;
    InventoryTabType TabType = InventoryTabType.Tab_Consum;
    InventoryTabType tabType
    {
        get => TabType;
        set
        {
            TabType = value;
            Refreshslot();
        }
    }
    //------------TabType-------------//
    //==================================//

    //DragDrop
    //public bool IsDrop = false;
    [HideInInspector]
    public SOEquipment OnDragItem = null;

    //�̱��� ����
    public static InventoryMgr inst = null;

    private void Awake()
    {
        inst = this;
        ItemSlots = this.GetComponentsInChildren<ItemSlot>();
    }
    private void OnEnable()
    {
        Refreshslot();
    }


    // Start is called before the first frame update
    void Start()
    {
        //TabButton ó��
        if (EquipmentTab != null)
            EquipmentTab.onClick.AddListener(() =>
            {
                tabType = InventoryTabType.Tab_Equip;
            });
        if (ConsumTab != null)
            ConsumTab.onClick.AddListener(() =>
            {
                tabType = InventoryTabType.Tab_Consum;
            });
        if (EtcTab != null)
            EtcTab.onClick.AddListener(() =>
            {
                tabType = InventoryTabType.Tab_Etc;
            });
        //TabButton ó��
        Refreshslot();
    }

    //���Կ� ������ �ֱ�
    //������ �迭�� 
    public void Refreshslot()
    {
        Debug.Log(TabType);
        for (int i = 0; i < ItemArr.Length; i++)
        {
            ItemArr[i] = null;
        }
        switch (TabType)
        {
            case InventoryTabType.Tab_Equip:
                {
                    for (int i = 0; i < GlobalValue.g_EquipItemList.Count; i++)
                    {
                        ItemArr[i] = GlobalValue.g_EquipItemList[i];
                    }
                }
                break;
            case InventoryTabType.Tab_Consum:
                {
                    for (int i = 0; i < GlobalValue.g_ConsumItemList.Count; i++)
                    {
                        ItemArr[i] = GlobalValue.g_ConsumItemList[i];
                    }
                }
                break;
            case InventoryTabType.Tab_Etc:
                {
                    for (int i = 0; i < GlobalValue.g_EtcItemList.Count; i++)
                    {
                        ItemArr[i] = GlobalValue.g_EtcItemList[i];
                    }
                }
                break;
        }
        for (int i = 0; i < ItemSlots.Length; i++)
        {
            ItemSlots[i].SetSlot(ItemArr[i]);
        }
    }

    public SOEquipment WearEquip(EquipType type)
    {
        if (OnDragItem.EquipType == type)
        {
            GlobalValue.g_EquipItemList.Remove(OnDragItem);
            return OnDragItem;
        }
        else
        {
            return null;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

}
