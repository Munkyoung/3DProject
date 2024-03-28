using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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


    public void PointUpDown(int value)
    {
        int skPoint = skillPoint + value;
        if (0 <= skPoint && skPoint <= MaxSkillPoint)
        {
            SkillPoint = skPoint;
        }
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
    bool IsCooling = false;

    public bool isCooling { get => IsCooling; set => IsCooling = value; }
    protected float cooltime { get => CoolTime; set => CoolTime = value; }

    protected ActiveSkill()
    {

    }

    public ActiveSkill(float coolTime, float cooltime)
    {
        CoolTime = coolTime;
        this.cooltime = cooltime;
    }

    public virtual void UseActiveSkill(GameObject User, Vector3 pos)
    {
        Debug.Log("�θ� ��ų ���");
    }
    public IEnumerator SkillCoolTime(Image image)
    {
        IsCooling = true;
        Debug.Log(cooltime);
        float cool = 0.0f;
        while (cool < cooltime)
        {
            cool += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
            image.fillAmount = cool / cooltime;
        }
        IsCooling = false;
        Debug.Log("��");
    }
}

public class ActiveSkill_Swing : ActiveSkill
{
    public ActiveSkill_Swing()
    {
        base.skillName = "���� ����";
        base.spriteName = "Skill_Icon/Bash";
        base.skillPoint = 0;
        base.maxSkillPoint = 5;
        base.skillInfo = $"���� ����";
        base.value = 100;
        cooltime = 3.0f;
    }

    public override void UseActiveSkill(GameObject User, Vector3 Pos)
    {
        if (skillPoint > 0)
        {
            Debug.Log(skillName);
            GameObject sword = User.GetComponent<PlayerCtrl>().SwingSkillObj;
            sword.gameObject.SetActive(true);
            sword.transform.position = Pos;
            Collider[] colls = Physics.OverlapSphere(Pos, 10.0f);
            foreach (var obj in colls)
            {
                ITakeDamagealbe damage = obj.gameObject.GetComponent<ITakeDamagealbe>();
                if (damage != null)
                    damage.TakeDamage(100.0f);
            }
        }
        else
        {
            Debug.Log("��ų����Ʈ ����");
        }
    }
}

public class ActiveSkill_Rush : ActiveSkill
{
    public ActiveSkill_Rush()
    {
        base.skillName = "���ݷ� ����";
        base.spriteName = "Skill_Icon/Rush";
        base.skillInfo = "���ݷ��� �����մϴ�";
        base.skillPoint = 0;
        base.maxSkillPoint = 5;
        cooltime = 5.0f;
    }


    public override void UseActiveSkill(GameObject user, Vector3 pos)
    {
        if (skillPoint > 0)
        {
            base.UseActiveSkill(user, pos);
            Debug.Log(skillName);
            Debug.Log(value);
        }
        else
        {
            Debug.Log("��ų����Ʈ ����");
        }
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
        cooltime = 10.0f;
    }

    public override void UseActiveSkill(GameObject user, Vector3 pos)
    {
        if (skillPoint > 0)
        {
            base.UseActiveSkill(user, pos);
            user.GetComponent<PlayerCtrl>().hp += 100;
            Debug.Log("��");
        }
        else
        {
            Debug.Log("��ų����Ʈ ����");
        }
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
