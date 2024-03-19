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

    public virtual void UseActiveSkill(GameObject User, Transform Target)
    {
        Debug.Log("��ų ���");
    }

}
public class ActiveSkill_Swing : ActiveSkill
{
    public ActiveSkill_Swing()
    {
        base.skillName = "����";
        base.spriteName = "Skill_Icon/Bash";
        base.skillPoint = 0;
        base.maxSkillPoint = 5;
        base.skillInfo = $"SkillPoint : {skillPoint} �������� ��ų�� ����մϴ�";
        base.value = 100;
        cooltime = 7.0f;
    }

    public override void UseActiveSkill(GameObject User, Transform Target)
    {
        base.UseActiveSkill(User, Target);
        Debug.Log(skillName);
        Debug.Log(value);
    }
}

public class ActiveSkill_Rush : ActiveSkill
{
    public ActiveSkill_Rush()
    {
        base.skillName = "����";
        base.spriteName = "Skill_Icon/Rush";
        base.skillInfo = "�������� ��ų�� ����մϴ�";
        base.skillPoint = 0;
        base.maxSkillPoint = 5;
        cooltime = 10.0f;
    }

    public override void UseActiveSkill(GameObject User, Transform Target)
    {
        base.UseActiveSkill(User, Target);
        Debug.Log(skillName);
        Debug.Log(value);
    }
}


public class ActiveSkill_Heal : ActiveSkill
{
    public ActiveSkill_Heal()
    {
        base.skillName = "��";
        base.spriteName = "Skill_Icon/Heal";
        base.skillInfo = "ü���� 100ȸ���մϴ�";
        base.skillPoint = 0;
        base.maxSkillPoint = 5;
        cooltime = 15.0f;
    }
}
public class PassiveSkill_PowerUp : PassiveSkill
{
    public PassiveSkill_PowerUp()
    {
        base.skillName = "�� ����";
        base.spriteName = "Skill_Icon/PowerUp";
        base.skillInfo = "���ݷ��� 5���� �մϴ�";
        base.skillPoint = 0;
        base.maxSkillPoint = 5;
    }
}
public class PassiveSkill_DefUp : PassiveSkill
{
    public PassiveSkill_DefUp()
    {
        base.skillName = "���� ����";
        base.spriteName = "Skill_Icon/DefUp";
        base.skillInfo = "������ 5����  �մϴ�";
        base.skillPoint = 0;
        base.maxSkillPoint = 5;
    }
}
public class PassiveSkill_SpeedUp : PassiveSkill
{
    public PassiveSkill_SpeedUp()
    {
        base.skillName = "�̵��ӵ� ����";
        base.spriteName = "Skill_Icon/SpeedUp";
        base.skillInfo = "�̵��ӵ��� 10����  �մϴ�";
        base.skillPoint = 0;
        base.maxSkillPoint = 5;
    }
}
public class PassiveSkill_HpUp : PassiveSkill
{
    public PassiveSkill_HpUp()
    {
        base.skillName = "�ִ�ü�� ����";
        base.spriteName = "Skill_Icon/HpUp";
        base.skillInfo = "�ִ� ü���� 20����  �մϴ�";
        base.skillPoint = 0;
        base.maxSkillPoint = 5;
    }
}
