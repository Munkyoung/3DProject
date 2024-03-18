using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class ItemTable : MonoBehaviour
{
    [Serializable]
    public class Table
    {
        public SOItem item;
        public float Weight;
    }

    public List<Table> ItemTabes = new List<Table>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    //가중치계산
    public SOItem GetItem()
    {
        //리스트의 모든 가중치의 합을 담을 변수
        float total = 0.0f;

        //총 가중치에서 랜덤한 값을 담을 변수
        float Pivot = 0.0f;

        //리스트를 오름차순으로 정렬
        List<Table> test = ItemTabes.OrderBy(t => t.Weight).ToList();

        //return할 item을 담을 SOitem형 변수
        SOItem item = test[test.Count - 1].item;


        foreach (Table table in ItemTabes)
        {
            total += table.Weight;
        }
        Pivot = UnityEngine.Random.Range(0, total);

        foreach (Table table in test)
        {
            if (table.Weight <= Pivot)
            {
                Pivot -= table.Weight;
            }
            else
            {
                item = table.item;
                break;
            }
        }
        return item;

    }

}
