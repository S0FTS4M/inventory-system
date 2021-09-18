using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerController : MonoBehaviour
{
    public GameObject gunPrefab;

    public GameObject fruitPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            float rnd = Random.Range(0f, 1f);
            if(rnd > 0.5f)
            {
                GameObject fruitGO = Instantiate(
                    fruitPrefab,
                    transform.GetChild(i).position,
                    Quaternion.identity
                );

                Item item = new Fruit("Çilek", 15);

                fruitGO.GetComponent<ItemController>().Item = item;
            }
            else
            {
                GameObject gunGO = Instantiate(
                    gunPrefab,
                    transform.GetChild(i).position,
                    Quaternion.identity
                );

                Item item = new Gun("Pistol", 10);

                gunGO.GetComponent<ItemController>().Item = item;
            }

        }
    }
}
