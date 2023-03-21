using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    
    public void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -15f, 15f),
            Mathf.Clamp(transform.position.y,-9f, 9f), transform.position.z);
    }
}