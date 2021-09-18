using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    #region Fields


    #endregion

    #region Props

    public List<Item> Items { get; private set; }

    public int MaxItemCount { get; private set; }


    #endregion

    public Inventory(int maxItemCount)
    {
        MaxItemCount = maxItemCount;

        Items = new List<Item>();
    }

    public bool AddItem(Item item)
    {
        if (Items.Count >= MaxItemCount)
            return false;

        Items.Add(item);
        
        return true;
    }

    public void RemoveItem(Item item)
    {
        if (Items.Contains(item))
            Items.Remove(item);
    }
}
