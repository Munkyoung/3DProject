using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface IUseable
{

}
public abstract class Item
{
    string ItemName;
    string SpriteName;
    int Price;
    int SalePrice;
    string Desc;
    int Count;
    int MaxCount;

    public string itemName { get => ItemName; set => ItemName = value; }
    public string spriteName { get => SpriteName; set => SpriteName = value; }
    public int price { get => Price; set => Price = value; }
    public int salePrice { get => SalePrice; set => SalePrice = value; }
    public string desc { get => Desc; set => Desc = value; }
    public int maxCount { get => MaxCount; set => MaxCount = value; }
    public int count { get => Count; set => Count = value; }

    // Item
    protected Item()
    {
        ItemName = string.Empty;
        SpriteName = "Sprites/Item/Empty";
        Price = 0;
        SalePrice = 0;
        Desc = string.Empty;
        Count = 0;
        MaxCount = 0;
    }
    protected Item(string itemName, string spriteName, int price, int salePrice, string desc, int count, int maxCount)
    {
        ItemName = itemName;
        SpriteName = spriteName;
        Price = price;
        SalePrice = salePrice;
        Desc = desc;
        Count = count;
        MaxCount = maxCount;
    }


    public string PrintData()
    {
        string Data =
        "ItemName : " + ItemName +
        "\nSpriteName : " + SpriteName +
        "\nPrice : " + Price +
        "\nSalePrice : " + SalePrice +
        "\nDesc : " + Desc +
        "\nMaxCount : " + MaxCount;
        return Data;
    }
    //item
}


public class ConsumItem : Item
{
    float CoolTime;
    float Timer;
    bool IsCooling;

    public ConsumItem()
    {
        CoolTime = 0;
        Timer = CoolTime;
        IsCooling = false;
    }
    public ConsumItem(float time)
    {
        CoolTime = time;
        Timer = CoolTime;
        IsCooling = false;
    }
    public IEnumerator ItemCool()
    {
        if (IsCooling == false)
        {
            IsCooling = true;
            while (0.0f < Timer)
            {
                Timer -= 0.1f;
                Debug.Log(Timer);
                yield return new WaitForSeconds(0.1f);
            }
            Timer = CoolTime;
            IsCooling = false;
            Debug.Log("코루틴 종료");
        }
    }
}
public class Potion : ConsumItem
{
    float value;


    public float UsePotion()
    {
        return value;
    }


}
public class Scroll : ConsumItem
{

}


public class EquipItem : Item
{
    public enum EquipType
    {
        Helmet = 0,
        Armor,
        Boot,
        Ring,
        Glove,
        Sword,
        EuqipCount
    }
    int Lv;
    int Grade;
    int Att;
    int Def;
    EquipType Type;

    public int lv { get => Lv; set => Lv = value; }
    public int grade { get => Grade; set => Grade = value; }
    public int att { get => Att; set => Att = value; }
    public int def { get => Def; set => Def = value; }
    public EquipType type { get => Type; set => Type = value; }

    public EquipItem()
    {
        Lv = 0;
        Grade = 0;
        Att = 0;
        Def = 0;
        Type = EquipType.EuqipCount;
    }
    public EquipItem(int lv, int grade, int att, int def, EquipType type)
    {
        Lv = lv;
        Grade = grade;
        Att = att;
        Def = def;
        Type = type;
    }
}
public class OtherItem : Item
{


}
