using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
	[SerializeField] private string interactKey = "r";
	public Collider2D lastTouched;
	public InteractableType target;
	
	// Update is called once per frame
    void Update()
    {
		if(Input.GetKeyDown(interactKey) && target != null)
		{
			target.Interact(this.gameObject);
		}
    }
	
	//notices when an interactable object enters the player's detection radius
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Plant" || collision.gameObject.tag == "Robot" || collision.gameObject.tag == "Ship")
		{
			lastTouched = collision;
			target = (InteractableType)collision.gameObject.GetComponent(typeof(InteractableType));
		}
	}
	
	//notices if the player walks away from an interactable object
	private void OnTriggerExit2D(Collider2D collision)
    {
        if(lastTouched == collision)
		{
			target = null;
		}
    }
	
	
}
