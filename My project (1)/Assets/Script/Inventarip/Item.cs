using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum  ObjectType
       {
           Food,
           Potion,
           Weapon,
           Coin
       }
[System.Serializable]
public class Item
{
    public string itemName;
    public string description;
    public ObjectType type;
    public Sprite icon;
    public int quantity;
    public bool acumulable;
    // Start is called before the first frame update
    public Item(string name, string desc, Sprite iconSprite, int qty, ObjectType tipo) 
    {
        itemName = name;
        description = desc;
        type = tipo;
        icon = iconSprite;
        quantity = qty;
    }
}
