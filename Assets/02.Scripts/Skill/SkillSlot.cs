using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    Skill skill;
    public Image slotImage;
    public Text skillCountText;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RefreshSlot(Skill skill)
    {
        //slotImage.sprite = Resources.Load<Sprite>(skill.spriteName);
        skillCountText.text = skill.skillPoint.ToString();

    }
}
