using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public Transform itemsParent;
    public GameObject itemSlotPrefab;

    public void UpdateUI() 
    {
    foreach (Transform child in itemsParent) 
        {
            Destroy(child.gameObject);
        }
        foreach (Item item in inventory.items)
        {
            GameObject newItemSlot = Instantiate(itemSlotPrefab, itemsParent);
            UseItem newItem = newItemSlot.GetComponent<UseItem>();
            newItem.item = item;
            newItem.inventory = inventory;
            if(item.acumulable)
            { 
                newItemSlot.GetComponentInChildren<TMP_Text>().text = item.quantity.ToString();
            }
            else
            {
                newItemSlot.GetComponentInChildren<TMP_Text>().text = null;
            }
            newItemSlot.GetComponentInChildren<Image>().sprite = item.icon;
        }
    }
}
