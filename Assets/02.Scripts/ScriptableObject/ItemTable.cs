using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class ItemTable : MonoBehaviour
{
    //�����۰� ����ġ�� ���� TableŬ����
    [Serializable]
    public class Element
    {
        public SOItem item;
        public float Weight;
    }

    public List<Element> ItemTabes = new List<Element>();

    //����ġ���
    public SOItem GetItem()
    {
        //����Ʈ�� ��� ����ġ�� ���� ���� ����
        float total = 0.0f;

        //�� ����ġ���� ������ ���� ���� ����
        float Pivot = 0.0f;

        //����Ʈ�� ������������ ����
        List<Element> test = ItemTabes.OrderBy(t => t.Weight).ToList();

        //return�� item�� ���� SOitem�� ����
        SOItem item = test[test.Count - 1].item;


        foreach (Element element in ItemTabes)
        {
            total += element.Weight;
        }
        Pivot = UnityEngine.Random.Range(0, total);

        foreach (Element element in test)
        {
            if (element.Weight <= Pivot)
            {
                Pivot -= element.Weight;
            }
            else
            {
                item = element.item;
                break;
            }
        }
        return item;

    }

}
