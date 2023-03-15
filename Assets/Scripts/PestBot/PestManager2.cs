using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
//Wander + Move To made by Ben
// Class created by: Katen

public abstract class PestManager2 : MonoBehaviour
{
	// for code review: these are currently not private for convenience but could be made so if necessary
	public ItemSO[] resources; //the types of items the bot will contain
	[HideInInspector]public int[] resQuants; //the number of each resource (automatically initiated to 0)
	public Sprite[] spriteArr; //the sprites the object will change between
	[HideInInspector]public SpriteRenderer sprite; //the sprite component of the robot
	[HideInInspector]public InventoryManager inventory; //the player's inventory object (to deposit resources in)
	public Vector3 wanderDir; //for wandering
	public float wanderRad; //for wandering
	public float speed; //the speed of the robot
	public GameObject background; //Sets the object to later find the bounds of, to limit the robot's movement
	[HideInInspector]public BoxCollider2D brBounds; //The bounds of the game object above
	public PlantType target; //The plant the robot is currently going after (to interact with)
	public Vector3 destination; //Where the bot is going
	public bool cooldown; //If the bot is engaged in an activity that should not be interrupted
	public Vector3 wanderTarget; //TEMPORARY wander target
    public Transform chaser1; //the player that makes the pestBot flee
    public Transform chaser2; // the second player that makes the pestBot flee
	public bool  chaser1InRange, chaser2InRange, plantInRange; //Checks if chaser1 or plant in range, then it will execute the action it is given
    
	//Flee
	public float distance;
	public float distanceBetweenPlayer; //sets how much distance in between player and PestBot
	
    public PestManager2(){	}
	
	public abstract PestManager2 Clone();
	
	
	public virtual void Awake()
	{
		AddPhysics2DRaycaster();
        sprite = GetComponent<SpriteRenderer>();
		inventory = FindObjectOfType<InventoryManager>();
		resQuants = new int[resources.Length];
        sprite.sprite = spriteArr[0];
		target = null;
		brBounds = background.GetComponent<BoxCollider2D>();
		destination = this.transform.position;
        chaser1InRange = false; 
		chaser2InRange = false;
    }
	
	public void Update()
	{
		if(!cooldown && !chaser1InRange && !chaser2InRange && !plantInRange)
		{
			Wander();
		}
		MoveTo();

        if(chaser1InRange)
        {
            FleePlayer1();
        }
        MoveTo();

		if(chaser2InRange)
		{
			FleePlayer2();
		}
		MoveTo();

        if(plantInRange)
        {
            AttackPlants();
        }
        MoveTo();
	}
	
	/*//detects when the robot is clicked
	public void OnPointerDown(PointerEventData eventData)
    {
		AttackPLants();
    }*/
	
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
            if (collision.gameObject.tag == "Player")
            {
                chaser1InRange = true;
				chaser2InRange = true;
            }
            else 
                chaser1InRange = false;
				chaser2InRange = false;
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
		
		
		if(CheckArrived())
		{
			destination = this.transform.position;
            if(target != null)
			{
				AttackPlants();
				target = null;
				cooldown = false;
			}
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
	
	public abstract void FleePlayer1();

	public abstract void FleePlayer2();
	
	public abstract void AttackPlants();
	
}

