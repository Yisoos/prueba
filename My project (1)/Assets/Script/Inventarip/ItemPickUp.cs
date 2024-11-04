using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class ItemPickUp : MonoBehaviour
{
    public Item item;
    public Inventory playerInventory;

    public void OnTriggerEnter()
    {
        if (!playerInventory.IsInventoryFull(item))
        {
        playerInventory.AddItem(item);
        gameObject.SetActive(false);
        }
    }
}
