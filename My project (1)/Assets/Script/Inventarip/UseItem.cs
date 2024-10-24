using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public Item item;
    public Inventory inventory;
    public void Use() 
    {
        switch (item.type) 
        {
            case ObjectType.Food:
                Debug.Log("Ñam Ñam Ñam");
               
                break;
            case ObjectType.Potion:
               
                Debug.Log("Refrescante pero sin efecto");
                break;
            case ObjectType.Weapon:
                Debug.Log($"Ataque con {item.itemName}");
               
                break;
            case ObjectType.Coin:
                Debug.Log("Dinerillo, toma");
                
                break;
            default: 
                break;
        }
        inventory.RemoveItem(item, 1);
    }
}
