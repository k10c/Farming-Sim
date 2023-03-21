using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
//Wander + Move To made by Ben
// Class created by: Katen

public abstract class PestManager : MonoBehaviour
{
	// for code review: these are currently not private for convenience but could be made so if necessary
	public Vector3 wanderDir; //for wandering
	public float wanderRad; //for wandering
	public float speed; //the speed of the robot
	public GameObject background; //Sets the object to later find the bounds of, to limit the robot's movement
	[HideInInspector]public BoxCollider2D brBounds; //The bounds of the game object above
	public PlantType target; //The plant the robot is currently going after (to interact with)
	public Vector3 destination; //Where the bot is going
	public bool cooldown; //If the bot is engaged in an activity that should not be interrupted
	public Vector3 wanderTarget; //TEMPORARY wander target
    public Transform chaser; //the player that makes the pestBot flee
    public Transform chaser2;
    public bool  chaserInRange, chaser2InRange, plantInRange; //Checks if chaser or plant in range, then it will execute the action it is given
    
    //Flee
	public float distance;
	public float distanceBetweenPlayer; //sets how much distance in between player and PestBot
	
    public PestManager(){	}
	
	public abstract PestManager Clone();
	
	
	public virtual void Awake()
	{
		target = null;
		brBounds = background.GetComponent<BoxCollider2D>();
		destination = new Vector3(0,0,0);
        chaserInRange = false;
        chaser2InRange = false;
        cooldown = false;
    }
	
	public void Update()
	{
		if(!cooldown && !chaserInRange && !chaser2InRange && !plantInRange)
		{
			Wander();
		}

        if(chaserInRange || chaser2InRange )
        {
            Flee();
        }

        if(plantInRange && !chaserInRange || !chaser2InRange)
        {
            AttackPlants();
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
                    Debug.LogWarning("Plant is in Range");
                    plantInRange = true;
				}
				else
					{
                        plantInRange = false;
                        Debug.LogWarning("Plant is not in Range");
                        target = null;
                        cooldown = false;
                    }
			}
            if (collision.gameObject.tag == "Player")
            {
                chaserInRange = true;
                chaser2InRange = true;
                cooldown = true;
                Debug.LogWarning("Player is In Range, Pest Should Flee");
            }
            else 
                {
                    cooldown = false;
                    chaserInRange = false;
                    chaser2InRange = false;
                    Debug.LogWarning("Player is Not In Range, Pest Should Continute Wandering");

                }
		}
		}
	
    public void OnTriggerExit2D(Collider2D other)
    {
        chaserInRange = false;
        chaser2InRange = false;
        cooldown = false;
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
			{
				AttackPlants();	
			}
            else
            {
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
	
	public abstract void Flee();
	
	public abstract void AttackPlants();

}
