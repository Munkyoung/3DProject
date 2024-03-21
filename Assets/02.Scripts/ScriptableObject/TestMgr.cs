using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public SOItem A;
    public SOItem B;
    public SOItem C;
    public SOItem D;

    Transform T;

    // Start is called before the first frame update
    void Start()
    {
        T = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void SpawnItem(SOItem a)
    {
        Instantiate(a.Prefab, T.position, Quaternion.identity);
        Debug.Log(a.itemName);
    }
}
