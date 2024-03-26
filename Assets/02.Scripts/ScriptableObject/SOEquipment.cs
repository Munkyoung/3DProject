using UnityEngine;
public enum EquipType
{
    Helmet = 0,
    Armor,
    Boots,
    Pants,
    Gloves,
    Weapon,
    EuqipCount
}

[CreateAssetMenu(fileName = "NewEquipItem", menuName = "NewItem/EquipmentItem")]
public class SOEquipment : SOItem
{
    [SerializeField]
    public EquipType EquipType;
    [Header("------STATS------")]
    [SerializeField]
    public int Offense;
    [SerializeField]
    public int Defense;
    [SerializeField]
    public int Speed;


    public override void UseItem()
    {
        base.UseItem();
    }
}