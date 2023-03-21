using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

// Original class by: Ben
//RoboType is used to make bots that will help the player in various ways.

public abstract class RoboType : MonoBehaviour, InteractableType
{
	[SerializeField]private ItemInfo[] resources; //the types of items the bot will contain
	[SerializeField]private float speed = 3; //the speed of the robot
	[SerializeField]private GameObject background; //Sets the object to later find the bounds of, to limit the robot's movement
	
	[HideInInspector]public InvPacker inventory; //the bot's inventory
	[HideInInspector]public PlantType target; //The plant the robot is currently going after (to interact with)
	
	private int[] resQuants; //the number of each resource (automatically initiated to 0)
	private BoxCollider2D brBounds; //The bounds of the game object above
	private Vector3 destination; //Where the bot is going
	private bool cooldown; //If the bot is engaged in an activity that should not be interrupted
	private Vector3 wanderTarget; //TEMPORARY wander target
	
    public RoboType(){	}
	
	public abstract RoboType Clone();
	
	
	public virtual void Awake()
	{
		inventory = new InvPacker();
		resQuants = new int[resources.Length];
		target = null;
		brBounds = background.GetComponent<BoxCollider2D>();
		destination = this.transform.position;
    }
	
	public void Update()
	{
		if(!cooldown)
		{
			Wander();
		}
		MoveTo();
	}	
	
	//notices when a grown plant is within the robots detection radius
	private void OnTriggerStay2D(Collider2D collision)
	{
		if(!cooldown)
		{
			if(collision.gameObject.tag == "Plant")
			{
				target = (PlantType)collision.gameObject.GetComponent(typeof(PlantType));
				if(target.CheckIfGrown())
				{
					cooldown = true;
					destination = target.transform.position;
				}
				else
					target = null;
			}
		}
	}
	
	
	//moves the robot towards its destination	
	public void MoveTo()
	{
		Vector3 transformPos = new Vector3();
		transformPos = destination - this.transform.position;
		transform.Translate(transformPos.normalized * Time.deltaTime * speed);
		
		if(!brBounds.bounds.Contains(this.transform.position))
		{
			transform.Translate(-1 * transformPos.normalized * Time.deltaTime * speed);
		}
		
		//to be replaced with collect later
		if(CheckArrived())
		{
			destination = this.transform.position;
			if(target != null)
				Collect();
			target = null;
			cooldown = false;
		}
	}
	
	//sets a random direction for the robot while wandering WORK IN PROGRESS / NEEDS FIX
	public void Wander()
	{
		float wanderRadius = 20;
		float wanderDistance = 30;
		float wanderJitter = 5;
		
		wanderTarget += new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitter,
									Random.Range(-1.0f, 1.0f) * wanderJitter,
									0);
		
		wanderTarget.Normalize();
		wanderTarget *= wanderRadius;
		
		//Vector3 targetLocal = wanderTarget + new Vector3(wanderDistance, wanderDistance, 0);
		Vector3 targetWorld = this.gameObject.transform.InverseTransformVector(wanderTarget);
		
		destination = targetWorld;
	}
	
	//checks if the robot is close to its destination
	public bool CheckArrived()
	{
		return (Vector3.Distance(destination,this.transform.position) <= Time.deltaTime * speed);
	}
	
	void BehaviourCooldown()
	{
		cooldown = false;
	}
	
	public abstract void Interact(GameObject player);
	
	public abstract void Collect();
	
	public abstract string GetDetails();
}