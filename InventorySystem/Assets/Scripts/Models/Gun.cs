using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Item
{
    public int BulletCount { get; private set; }

    public Gun(string name, int bulletCount) : base(name, false)
    {
        this.BulletCount = bulletCount;
    }

    public override void Use()
    {
        Debug.Log("Gun used");

        base.Use();
    }
}
