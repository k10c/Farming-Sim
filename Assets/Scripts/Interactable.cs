using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Written by Aidan

public class Interactable : MonoBehaviour

{
    [SerializeField] private KeyCode interactKey;
    [SerializeField] private UnityEvent<GameObject> interaction;

    private bool isInRange = false;
    private GameObject whichPlayer;
    

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            if(Input.GetKeyDown(interactKey))
            {
                interaction.Invoke(whichPlayer);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            whichPlayer = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
