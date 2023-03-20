using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by Aidan and Ben

public class PlayerInteract : MonoBehaviour
{
	[SerializeField] private string interactKey = "r";
	public Collider2D lastTouched;
	public List<InteractableType> targets = new List<InteractableType>();
	
	// Update is called once per frame
    void Update()
    {
		List<InteractableType> interactables = new List<InteractableType>();
		if(Input.GetKeyDown(interactKey))
		{
			foreach(InteractableType target in targets)
				if(target != null)
					interactables.Add(target);
			
			foreach(InteractableType interactable in interactables)
				interactable.Interact(this.gameObject);
		}
    }
	
	//notices when an interactable object enters the player's detection radius
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Plant" || collision.gameObject.tag == "Robot" || collision.gameObject.tag == "Ship")
		{
			targets.Add((InteractableType)collision.gameObject.GetComponent(typeof(InteractableType)));
		}
	}
	
	//notices if the player walks away from an interactable object
	private void OnTriggerExit2D(Collider2D collision)
    {
		if(collision.gameObject.tag == "Plant" || collision.gameObject.tag == "Robot" || collision.gameObject.tag == "Ship")
		{
			targets.Remove((InteractableType)collision.gameObject.GetComponent(typeof(InteractableType)));
		}
    }
	
	
}
