using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by Ben
//Used / Inherited by objects that the player can interact with

public interface InteractableType
{
	public abstract void Interact(GameObject player);
}
