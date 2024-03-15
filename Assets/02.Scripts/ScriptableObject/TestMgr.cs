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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnItem(A);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpawnItem(B);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SpawnItem(C);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SpawnItem(D);
        }
    }
    public void SpawnItem(SOItem a)
    {
        Instantiate(a.Prefab, T.position, Quaternion.identity);
        Debug.Log(a.itemName);
    }
}
