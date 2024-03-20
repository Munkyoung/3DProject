using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameMgr : MonoBehaviour
{
    public GameObject MiniMap;
    public GameObject Inventory;
    public GameObject SkillTree;

    public Skill OnDragSkill;
    public SkillPanel[] PlayerSkill = new SkillPanel[4];

    public static GameMgr inst;

    private void Awake()
    {
        inst = this;
    }


    // Start is called before the first frame update
    void Start()
    {

    }
    public void RefreshSkillPanel()
    {
        for (int i = 0; i < PlayerSkill.Length; i++)
            PlayerSkill[i].SetSkillPanel();
    }
    public bool IsPanelOn()
    {
        if (MiniMap.activeSelf || Inventory.activeSelf || SkillTree.activeSelf)
            return true;
        else
            return false;
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
