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
            Debug.Log(item.itemName);
            PickItemList.Add(other.gameObject);
            Debug.Log(PickItemList[0]);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("³ª°¨");
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
