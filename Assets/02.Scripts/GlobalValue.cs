using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalValue
{
    public static string g_UserName;

    //Inventory ÀúÀå¿ë 
    public static List<SOEquipment> g_EquipItemList;
    public static List<SOConsum> g_ConsumItemList;
    public static List<SOEtc> g_EtcItemList;

    public static void AddItem(SOItem item)
    {
        if (item is SOEquipment)
            g_EquipItemList.Add(item as SOEquipment);
        else if (item is SOConsum)
            g_ConsumItemList.Add(item as SOConsum);
        else if (item is SOEtc)
            g_EtcItemList.Add(item as SOEtc);
        else
            return;
    }

}
