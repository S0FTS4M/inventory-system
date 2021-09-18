using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : Item
{
    public float HealAmount { get; private set; }
    public Fruit(string name, float healAmount) : base(name, true)
    {
        this.HealAmount = healAmount;
    }

    public override void Use()
    {
        base.Use();
        
        Player.Instance.Heal(HealAmount);
    }
}
