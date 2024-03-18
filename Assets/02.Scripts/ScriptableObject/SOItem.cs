using UnityEngine;
using UnityEngine.UI;

public abstract class SOItem : ScriptableObject
{
    [Header("------INFO------")]
    [SerializeField]
    string ItemName;
    [SerializeField]
    string SpriteName;
    [SerializeField]
    int Price;
    [SerializeField]
    [Multiline]
    string Desc;
    [SerializeField]
    public GameObject Prefab;
    [SerializeField]
    int Count;
    [SerializeField]
    int MaxCount;
    public string itemName { get => ItemName; set => ItemName = value; }
    public string spriteName { get => SpriteName; set => SpriteName = value; }
    public int price { get => Price; set => Price = value; }
    public string desc { get => Desc; set => Desc = value; }
    public int maxCount { get => MaxCount; set => MaxCount = value; }
    public int count { get => Count; set => Count = value; }

    public virtual void UseItem()
    {

    }
}
