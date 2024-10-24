using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public InventoryUI updateInventory;
    // Start is called before the first frame update
   
    public void AddItem(Item newItem) 
    {
        Item item = items.Find(i=> i.itemName == newItem.itemName);
        if (item != null && item.acumulable) 
        {
            item.quantity += newItem.quantity;
        }
        else
        {
            items.Add(newItem);
        }
        updateInventory.UpdateUI();

    }
    public void RemoveItem(Item itemRemoved, int quantity)
    {
        Item item = items.Find(i => i.itemName == itemRemoved.itemName);
        Debug.Log(item.quantity);
        if (item != null)
        {
            if (item.quantity-quantity >= 1) 
            {
                item.quantity -= quantity; 
                Debug.Log($"Eliminado {itemRemoved.quantity} item/s del inventario");
            }
            else
            {
            items.Remove(item);
            Debug.Log("Eliminado el item del inventario");
            }
        }
        else
        {
            Debug.Log("El objeto no existe en el inventario");
        }
        updateInventory.UpdateUI();
    }
}
