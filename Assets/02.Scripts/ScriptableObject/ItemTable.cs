using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class ItemTable : MonoBehaviour
{
    //아이템과 가중치를 담을 Table클래스
    [Serializable]
    public class Element
    {
        public SOItem item;
        public float Weight;
    }

    public List<Element> ItemTabes = new List<Element>();

    //가중치계산
    public SOItem GetItem()
    {
        //리스트의 모든 가중치의 합을 담을 변수
        float total = 0.0f;

        //총 가중치에서 랜덤한 값을 담을 변수
        float Pivot = 0.0f;

        //리스트를 오름차순으로 정렬
        List<Element> test = ItemTabes.OrderBy(t => t.Weight).ToList();

        //return할 item을 담을 SOitem형 변수
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
