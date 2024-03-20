using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    List<GameObject> PickItemList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            PickUpItem();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UseSkill(0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            UseSkill(1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            UseSkill(2);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            UseSkill(3);
        }

    }
    public void UseSkill(int index)
    {
        if (GlobalValue.PlayerSkill[index] != null)
        {
            Debug.Log(GlobalValue.PlayerSkill[index].skillName);
            GlobalValue.PlayerSkill[index].UseActiveSkill(this.gameObject, this.transform);
        }
        else
        {
            Debug.Log("Null");
        }
    }
    public void ChangeSkill(ActiveSkill newSkill, int index)
    {
        if (newSkill != null && 0 <= index && index < GlobalValue.PlayerSkill.Length)
            GlobalValue.PlayerSkill[index] = newSkill;
    }

    public void PickUpItem()
    {
        if (0 < PickItemList.Count)
        {
            GlobalValue.AddItem(PickItemList[0].GetComponent<ItemCtrl>().item);
            Destroy(PickItemList[0]);
            PickItemList.RemoveAt(0);
            InventoryMgr.inst.Refreshslot();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        SOItem item = other.GetComponent<ItemCtrl>().item;
        Debug.Log(item.name);
        if (item != null)
        {
            PickItemList.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        SOItem item = other.GetComponent<ItemCtrl>().item;
        if (item != null)
        {
            Debug.Log(item.itemName);
            PickItemList.Remove(other.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {

    }


}
