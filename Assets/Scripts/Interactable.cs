using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Written by Aidan and Ben
// Used by interactable interface elements (like the ship)

public class Interactable : MonoBehaviour, InteractableType

{
    [SerializeField] private UnityEvent<GameObject> interaction;
    
	public void Interact(GameObject player)
	{
		interaction.Invoke(player);
	}
}
