using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    
    public void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -15f, 18f),
            Mathf.Clamp(transform.position.y,-10f, 10f), transform.position.z);
    }
}