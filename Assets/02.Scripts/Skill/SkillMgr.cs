using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillMgr : MonoBehaviour
{

    public SkillNode TestRoot;
    // Start is called before the first frame update
    void Start()
    {
        TestRoot = RootSkill.TestMakeRoot();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RootSkill.PrintData(TestRoot);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            RootSkill.SkillPointUpDown(TestRoot, "A-B-C", 1);
        }

    }

}
