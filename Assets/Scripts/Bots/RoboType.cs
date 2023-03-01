using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

// Original class by: Ben

public abstract class RoboType : MonoBehaviour, IPointerDownHandler
{
	// for code review: these are currently not private for convenience but could be made so if necessary
	public ItemSO[] resources; //the types of items the bot will contain
	[HideInInspector]public int[] resQuants; //the number of each resource (automatically initiated to 0)
	public Sprite[] spriteArr; //the sprites the object will change between
	[HideInInspector]public SpriteRenderer sprite; //the sprite component of the robot
	public InventoryManager playerInv;//TEMP
	public InvPacker inventory; //the bot's inventory
	

	public float speed; //the speed of the robot
	public GameObject background; //Sets the object to later find the bounds of, to limit the robot's movement
	[HideInInspector]public BoxCollider2D brBounds; //The bounds of the game object above
	public PlantType target; //The plant the robot is currently going after (to interact with)
	public Vector3 destination; //Where the bot is going
	public bool cooldown; //If the bot is engaged in an activity that should not be interrupted
	public Vector3 wanderTarget; //TEMPORARY wander target
	
    public RoboType(){	}
	
	public abstract RoboType Clone();
	
	
	public virtual void Awake()
	{
		AddPhysics2DRaycaster();
        sprite = GetComponent<SpriteRenderer>();
		inventory = new InvPacker();
		playerInv = FindObjectOfType<InventoryManager>();//TEMP
		resQuants = new int[resources.Length];
        sprite.sprite = spriteArr[0];
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
	
	//detects when the robot is clicked
	public void OnPointerDown(PointerEventData eventData)
    {
		Collect();
    }
	
	//determines whether a raycaster has already been created (ensures it is only loaded once)
    private void AddPhysics2DRaycaster()
    {
        Physics2DRaycaster physicsRaycaster = FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
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
				Interact();
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
	
	public abstract void Interact();
	
	public abstract void Collect();
	
	public abstract string GetDetails();
}