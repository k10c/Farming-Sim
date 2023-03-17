using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private PlantType plant;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        plant = collision.GetComponent<PlantType>();    

        // Gets the ICollectable interface of the object collided with. Only objects that implement the interface will return not null
        ICollectable collectable = collision.GetComponent<ICollectable>();
        if(collectable != null && plant.CheckIfGrown())
        {
            collectable.Collect();
        }
    }
}
