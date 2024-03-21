using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalValue
{
    public static string g_UserName;

    //�κ��丮�� ����ִ� ������ ����Ʈ
    public static List<SOEquipment> g_EquipItemList = new List<SOEquipment>();
    public static List<SOConsum> g_ConsumItemList = new List<SOConsum>();
    public static List<SOEtc> g_EtcItemList = new List<SOEtc>();


    //�÷��̾��� ��ų Ʈ��
    public static SkillNode SkillTree = RootSkill.TestMakeRoot();

    //�÷��̾ �����ϰ��ִ� ��ų
    public static ActiveSkill[] PlayerSkill = new ActiveSkill[4];

    //�����ϰ� �ִ� ������ ����Ʈ


    //������ ����Ʈ�� �߰�
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
    //������ ���� ���Ȱ��


}
