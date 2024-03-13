using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public GameObject MiniMap;
    public GameObject Inventory;
    public GameObject SkillTree;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            MiniMap.SetActive(!MiniMap.activeSelf);

        if (Input.GetKeyDown(KeyCode.I))
            Inventory.SetActive(!Inventory.activeSelf);

        if (Input.GetKeyDown(KeyCode.K))
            SkillTree.SetActive(!SkillTree.activeSelf);

    }
}
