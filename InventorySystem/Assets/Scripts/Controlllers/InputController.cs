using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Item item = Player.Instance.Inventory.Items[0];
            item.Use();
            Player.Instance.Inventory.RemoveItem(item);
        }
    }
}
