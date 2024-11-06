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

            // Set up the item for usage
            UseItem newItem = newItemSlot.GetComponent<UseItem>();
            newItem.item = item;
            newItem.inventory = inventory;

            // Retrieve TMP_Text components (assuming the first is for quantity, the second for item name)
            TMP_Text[] textComponents = newItemSlot.GetComponentsInChildren<TMP_Text>();

            if (textComponents.Length >= 2)
            {
                TMP_Text quantityText = textComponents[0];  // First TMP_Text for quantity
                TMP_Text nameText = textComponents[1];      // Second TMP_Text for item name

                // Set quantity text based on whether the item is acumulable
                if (item.acumulable)
                {
                    quantityText.text = item.quantity.ToString();
                }
                else
                {
                    quantityText.text = null;
                }

                // Set name text to the item's name
                nameText.text = item.itemName;
            }

            // Set the item icon
            newItemSlot.GetComponentInChildren<Image>().sprite = item.icon;
        }
    }
}
