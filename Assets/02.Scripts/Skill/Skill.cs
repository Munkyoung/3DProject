using UnityEngine;

public abstract class Skill
{
    string SkillName;
    int SkillPoint;
    string SpriteName;
    string SkillInfo;

    protected Skill()
    {
        SkillName = string.Empty;
        SkillPoint = 0;
        SpriteName = string.Empty;
    }

    protected Skill(string skillName, string spriteName, string skillInfo, int skillPoint = 0)
    {
        SkillName = skillName;
        SpriteName = spriteName;
        SkillInfo = skillInfo;
        SkillPoint = skillPoint;

    }

    public string skillName { get => SkillName; set => SkillName = value; }
    public int skillPoint { get => SkillPoint; set => SkillPoint = value; }
    public string spriteName { get => SpriteName; set => SpriteName = value; }
    public string skillInfo { get => SkillInfo; set => SkillInfo = value; }

}
public class PassiveSkill : Skill
{
    protected PassiveSkill()
    {

    }
    protected PassiveSkill(string skillName, string spriteName, string skillInfo, int skillPoint = 0) : base(skillName, spriteName, skillInfo, skillPoint)
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
    protected ActiveSkill(string skillName, string spriteName, string skillInfo, int skillPoint = 0) : base(skillName, spriteName, skillInfo, skillPoint)
    {

    }

    public virtual void UseSkill()
    {
        Debug.Log("스킬 사용");
    }

}
public class ActiveSkill_Swing : ActiveSkill
{
    public ActiveSkill_Swing()
    {
        base.skillName = "베기";
        base.skillPoint = 0;
        base.spriteName = string.Empty;
        base.skillInfo = "전방으로 스킬을 사용합니다";
        cooltime = 7.0f;
    }

    public override void UseSkill()
    {

    }
}
public class ActiveSkill_Rush : ActiveSkill
{
    public ActiveSkill_Rush()
    {
        base.skillName = "돌진";
        base.skillPoint = 0;
        base.spriteName = string.Empty;
        base.skillInfo = "전방으로 스킬을 사용합니다";
        cooltime = 10.0f;
    }
}
public class ActiveSkill_Heal : ActiveSkill
{
    public ActiveSkill_Heal()
    {
        base.skillName = "힐";
        base.skillPoint = 0;
        base.spriteName = string.Empty;
        base.skillInfo = "체력을 100회복합니다";
        cooltime = 15.0f;
    }
}
public class PassiveSkill_PowerUp : PassiveSkill
{
    public PassiveSkill_PowerUp()
    {
        base.skillName = "힘 증가";
        base.skillPoint = 0;
        base.spriteName = string.Empty;
        base.skillInfo = "공격력이 5증가 합니다";
    }
}
public class PassiveSkill_DefUp : PassiveSkill
{
    public PassiveSkill_DefUp()
    {
        base.skillName = "방어력 증가";
        base.skillPoint = 0;
        base.spriteName = string.Empty;
        base.skillInfo = "방어력이 5증가  합니다";
    }
}
public class PassiveSkill_SpeedUp : PassiveSkill
{
    public PassiveSkill_SpeedUp()
    {
        base.skillName = "이동속도 증가";
        base.skillPoint = 0;
        base.spriteName = string.Empty;
        base.skillInfo = "이동속도가 10증가  합니다";
    }
}
public class PassiveSkill_HpUp : PassiveSkill
{
    public PassiveSkill_HpUp()
    {
        base.skillName = "최대체력 증가";
        base.skillPoint = 0;
        base.spriteName = string.Empty;
        base.skillInfo = "최대 체력이 20증가  합니다";
    }
}
