using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public event Action listChanged;
    public int maxCount;
    public DataBase data;
    public bool canAdd = false;
    public List<Item> items = new();
    public Inventory anotherInventory;

    public void AddItem(Item item)
    {
        if (canAdd)
        {
            items.Add(item);
            listChanged?.Invoke();
            canAdd = items.Count < maxCount;
        }
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        listChanged?.Invoke();
        canAdd = items.Count < maxCount;
    }

    public void Clear()
    {
        items = new List<Item>();
        listChanged?.Invoke();
        canAdd = items.Count < maxCount;
    }

    public void GiveItem(Item item)
    {
        if (anotherInventory != null && anotherInventory.canAdd)
        {
            RemoveItem(item);
            anotherInventory.AddItem(item);
        }
    }

    public List<Item> GetItems()
    {
        return items;
    }

    private void Start()
    {
        canAdd = items.Count < maxCount;
    }
}