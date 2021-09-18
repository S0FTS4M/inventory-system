using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string Name { get; private set; }

    public bool IsConsumable { get; private set;}

    public Item(string name, bool isConsumable)
    {
        this.Name = name;
        this.IsConsumable = isConsumable;
    }

    public virtual void Use()
    {
        UnityEngine.Debug.Log("Item with name " + Name + " is being used");
    }


}
