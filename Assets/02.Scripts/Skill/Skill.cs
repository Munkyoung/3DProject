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
        Debug.Log("��ų ���");
    }

}
public class ActiveSkill_Swing : ActiveSkill
{
    public ActiveSkill_Swing()
    {
        base.skillName = "����";
        base.skillPoint = 0;
        base.spriteName = string.Empty;
        base.skillInfo = "�������� ��ų�� ����մϴ�";
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
        base.skillName = "����";
        base.skillPoint = 0;
        base.spriteName = string.Empty;
        base.skillInfo = "�������� ��ų�� ����մϴ�";
        cooltime = 10.0f;
    }
}
public class ActiveSkill_Heal : ActiveSkill
{
    public ActiveSkill_Heal()
    {
        base.skillName = "��";
        base.skillPoint = 0;
        base.spriteName = string.Empty;
        base.skillInfo = "ü���� 100ȸ���մϴ�";
        cooltime = 15.0f;
    }
}
public class PassiveSkill_PowerUp : PassiveSkill
{
    public PassiveSkill_PowerUp()
    {
        base.skillName = "�� ����";
        base.skillPoint = 0;
        base.spriteName = string.Empty;
        base.skillInfo = "���ݷ��� 5���� �մϴ�";
    }
}
public class PassiveSkill_DefUp : PassiveSkill
{
    public PassiveSkill_DefUp()
    {
        base.skillName = "���� ����";
        base.skillPoint = 0;
        base.spriteName = string.Empty;
        base.skillInfo = "������ 5����  �մϴ�";
    }
}
public class PassiveSkill_SpeedUp : PassiveSkill
{
    public PassiveSkill_SpeedUp()
    {
        base.skillName = "�̵��ӵ� ����";
        base.skillPoint = 0;
        base.spriteName = string.Empty;
        base.skillInfo = "�̵��ӵ��� 10����  �մϴ�";
    }
}
public class PassiveSkill_HpUp : PassiveSkill
{
    public PassiveSkill_HpUp()
    {
        base.skillName = "�ִ�ü�� ����";
        base.skillPoint = 0;
        base.spriteName = string.Empty;
        base.skillInfo = "�ִ� ü���� 20����  �մϴ�";
    }
}
