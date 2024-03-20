using Unity.VisualScripting;
using UnityEngine;

public abstract class Skill
{
    string SkillName;
    string SpriteName;
    string SkillInfo;
    float Value;
    int SkillPoint;
    int MaxSkillPoint;

    protected Skill()
    {
        SkillName = string.Empty;
        SkillPoint = 0;
        SpriteName = string.Empty;
    }

    protected Skill(string skillName, string spriteName, string skillInfo, float value, int skillPoint, int maxSkillPoint)
    {
        SkillName = skillName;
        SpriteName = spriteName;
        SkillInfo = skillInfo;
        this.value = value;
        SkillPoint = skillPoint;
        MaxSkillPoint = maxSkillPoint;
    }


    public bool PointUpDown(int value)
    {
        int skPoint = skillPoint + value;
        if (0 <= skPoint && skPoint <= MaxSkillPoint)
        {
            SkillPoint = skPoint;
            return true;
        }
        return false;
    }

    public string GetSkPoint()
    {
        return SkillPoint.ToString() + "/" + MaxSkillPoint.ToString();
    }


    public string skillName { get => SkillName; set => SkillName = value; }
    public int skillPoint { get => SkillPoint; set { SkillPoint = value; } }
    public string spriteName { get => SpriteName; set => SpriteName = value; }
    public string skillInfo { get => SkillInfo; set => SkillInfo = value; }
    public int maxSkillPoint { get => MaxSkillPoint; set => MaxSkillPoint = value; }
    public float value { get => Value; set => Value = value; }

}
public class PassiveSkill : Skill
{
    protected PassiveSkill()
    {

    }
}
public class ActiveSkill : Skill
{
    float CoolTime;
    protected float cooltime { get => CoolTime; set => CoolTime = value; }

    protected ActiveSkill()
    {

    }

    public ActiveSkill(float coolTime, float cooltime)
    {
        CoolTime = coolTime;
        this.cooltime = cooltime;
    }

    public virtual void UseActiveSkill(GameObject User, Transform Target)
    {
        Debug.Log("부모 스킬 사용");
    }

}
public class SkillList
{

}
public class ActiveSkill_Swing : ActiveSkill
{
    public ActiveSkill_Swing()
    {
        base.skillName = "베기";
        base.spriteName = "Skill_Icon/Bash";
        base.skillPoint = 0;
        base.maxSkillPoint = 5;
        base.skillInfo = $"SkillPoint : {skillPoint} 전방으로 스킬을 사용합니다";
        base.value = 100;
        cooltime = 7.0f;
    }

    public override void UseActiveSkill(GameObject User, Transform Target)
    {
        if (skillPoint > 0)
        {
            base.UseActiveSkill(User, Target);
            Debug.Log(skillName);
            Debug.Log(value);
        }
        else
        {
            Debug.Log("스킬포인트 부족");
        }
    }
}

public class ActiveSkill_Rush : ActiveSkill
{
    public ActiveSkill_Rush()
    {
        base.skillName = "돌진";
        base.spriteName = "Skill_Icon/Rush";
        base.skillInfo = "전방으로 스킬을 사용합니다";
        base.skillPoint = 0;
        base.maxSkillPoint = 5;
        cooltime = 10.0f;
    }

    public override void UseActiveSkill(GameObject User, Transform Target)
    {
        if (skillPoint > 0)
        {
            base.UseActiveSkill(User, Target);
            Debug.Log(skillName);
            Debug.Log(value);
        }
        else
        {
            Debug.Log("스킬포인트 부족");
        }
    }
}


public class ActiveSkill_Heal : ActiveSkill
{
    public ActiveSkill_Heal()
    {
        base.skillName = "힐";
        base.spriteName = "Skill_Icon/Heal";
        base.skillInfo = "체력을 100회복합니다";
        base.skillPoint = 0;
        base.maxSkillPoint = 5;
        cooltime = 15.0f;
    }
    public override void UseActiveSkill(GameObject User, Transform Target)
    {
        if (skillPoint > 0)
        {
            base.UseActiveSkill(User, Target);
            Debug.Log(skillName);
            Debug.Log(value);
        }
        else
        {
            Debug.Log("스킬포인트 부족");
        }
    }
}
public class PassiveSkill_PowerUp : PassiveSkill
{
    public PassiveSkill_PowerUp()
    {
        base.skillName = "힘 증가";
        base.spriteName = "Skill_Icon/PowerUp";
        base.skillInfo = "공격력이 5증가 합니다";
        base.skillPoint = 0;
        base.maxSkillPoint = 5;
    }
}
public class PassiveSkill_DefUp : PassiveSkill
{
    public PassiveSkill_DefUp()
    {
        base.skillName = "방어력 증가";
        base.spriteName = "Skill_Icon/DefUp";
        base.skillInfo = "방어력이 5증가  합니다";
        base.skillPoint = 0;
        base.maxSkillPoint = 5;
    }
}
public class PassiveSkill_SpeedUp : PassiveSkill
{
    public PassiveSkill_SpeedUp()
    {
        base.skillName = "이동속도 증가";
        base.spriteName = "Skill_Icon/SpeedUp";
        base.skillInfo = "이동속도가 10증가  합니다";
        base.skillPoint = 0;
        base.maxSkillPoint = 5;
    }
}
public class PassiveSkill_HpUp : PassiveSkill
{
    public PassiveSkill_HpUp()
    {
        base.skillName = "최대체력 증가";
        base.spriteName = "Skill_Icon/HpUp";
        base.skillInfo = "최대 체력이 20증가  합니다";
        base.skillPoint = 0;
        base.maxSkillPoint = 5;
    }
}
