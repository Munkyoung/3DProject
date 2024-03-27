using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalValue
{
    static float CurHp = 200.0f;
    public static float curHp
    {
        get { return curHp; }
        set { curHp = value; }
    }
    static float MaxHp = 200;
    public static float maxHp
    {
        get { return maxHp * level * 10; }

    }
    static float Level;
    public static float level
    {
        get { return Level; }
        set
        {
            Level = value;
        }
    }

    static float AttStat = 10;
    static float DefStat;
    static float SpdStat;

    static float CurAtt;
    static float CurDef;
    static float CurSpeed;

    public static float curAtt
    {
        get
        {
            UpdateAtt();
            return CurAtt;
        }
    }
    public static float curDef
    {
        get
        {
            UpdateDef();
            return CurDef;
        }
    }
    public static float curSpeed
    {
        get
        {
            UpdateSpd();
            return CurSpeed;
        }
    }

    public static List<SOEquipment> g_EquipItemList = new List<SOEquipment>();
    public static List<SOConsum> g_ConsumItemList = new List<SOConsum>();
    public static List<SOEtc> g_EtcItemList = new List<SOEtc>();

    public static int layerMask = (1 << LayerMask.NameToLayer("Item")) + (1 << LayerMask.NameToLayer("Ground")) + (1 << LayerMask.NameToLayer("Enemy"));

    //플레이어의 스킬 트리
    public static SkillNode SkillTree = RootSkill.CreateRoot();

    //플레이어가 장착하고있는 스킬
    public static ActiveSkill[] PlayerSkill = new ActiveSkill[4];

    //장착하고 있는 아이템 리스트
    public static SOEquipment[] g_PlayerEquipment = new SOEquipment[6];

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
    private static void UpdateAtt()
    {
        int att = (int)AttStat;
        for (int i = 0; i < g_PlayerEquipment.Length; i++)
        {
            if (g_PlayerEquipment[i] != null)
                att += g_PlayerEquipment[i].Offense;
        }
        CurAtt = att;
    }
    private static void UpdateDef()
    {
        int def = 0;
        for (int i = 0; i < g_PlayerEquipment.Length; i++)
        {
            def += g_PlayerEquipment[i].Defense;
        }
        CurDef = def;

    }
    private static void UpdateSpd()
    {
        int spd = 0;
        for (int i = 0; i < g_PlayerEquipment.Length; i++)
        {
            spd += g_PlayerEquipment[i].Defense;
        }
        CurDef = spd;
    }

}
