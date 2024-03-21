using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalValue
{
    public static string g_UserName;

    //인벤토리에 들어있는 아이템 리스트
    public static List<SOEquipment> g_EquipItemList = new List<SOEquipment>();
    public static List<SOConsum> g_ConsumItemList = new List<SOConsum>();
    public static List<SOEtc> g_EtcItemList = new List<SOEtc>();


    //플레이어의 스킬 트리
    public static SkillNode SkillTree = RootSkill.TestMakeRoot();

    //플레이어가 장착하고있는 스킬
    public static ActiveSkill[] PlayerSkill = new ActiveSkill[4];

    //장착하고 있는 아이템 리스트


    //아이템 리스트에 추가
    public static bool AddItem(SOItem item)
    {
        if (item is SOEquipment && g_EquipItemList.Count < 28)
        {
            g_EquipItemList.Add(item as SOEquipment);
            return true;
        }
        else if (item is SOConsum && g_ConsumItemList.Count < 28)
        {
            g_ConsumItemList.Add(item as SOConsum);
            return true;
        }
        else if (item is SOEtc && g_EtcItemList.Count < 28)
        {
            g_EtcItemList.Add(item as SOEtc);
            return true;
        }
        else
            return false;
    }
    //보유한 장비로 스탯계산


}
