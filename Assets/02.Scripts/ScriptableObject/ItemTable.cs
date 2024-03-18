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

    //����ġ���
    public SOItem GetItem()
    {
        //����Ʈ�� ��� ����ġ�� ���� ���� ����
        float total = 0.0f;

        //�� ����ġ���� ������ ���� ���� ����
        float Pivot = 0.0f;

        //����Ʈ�� ������������ ����
        List<Table> test = ItemTabes.OrderBy(t => t.Weight).ToList();

        //return�� item�� ���� SOitem�� ����
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
