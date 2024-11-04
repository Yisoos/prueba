using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public InventoryUI updateInventory;
    public int maxInventorySlots;
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
        //Debug.Log(item.quantity);
        if (item != null)
        {
            if (item.quantity-quantity >= 1) 
            {
                item.quantity -= quantity; 
               // Debug.Log($"Eliminado {itemRemoved.quantity} item/s del inventario");
            }
            else
            {
            items.Remove(item);
           // Debug.Log("Eliminado el item del inventario");
            }
        }
        else
        {
            Debug.Log("El objeto no existe en el inventario");
        }
        updateInventory.UpdateUI();
    }
    public bool IsInventoryFull(Item checkItem) 
    {
        if ((items.Count >= maxInventorySlots && !items.Exists(item => item.itemName == checkItem.itemName)))
        {
            Debug.Log("tu inventario está lleno!");
            return true;
        }
        else
        {
            if (items.Count >= maxInventorySlots && !checkItem.acumulable)
            {
                Debug.Log("tu inventario está lleno!");
                return true; 
            }
            else
            {
                return false; 
            }
        }
    }
}
