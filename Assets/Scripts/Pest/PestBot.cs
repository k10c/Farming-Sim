using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PestBot : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    private Transform chaser = null;
    public PlantType target;
    public float speed;

    //Wandering
    /*public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    */
    public Vector3 wanderTarget;
    public Vector3 destination;
    public Vector3 wanderDir; 
	public float wanderRad;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    
    //Flee
    private float displacementDist = 5.0f;

    //states
    public float inRangeChaser, inRangePlant;
    public bool  chaserInRange, plantInRange;

    public void Awake()
    {
        //chaser = GameObject.Find("Player").transform;
        //plantType = GameObject.Find("Plant").transform;
        agent = GetComponent<NavMeshAgent>();
        chaserInRange = false;
        

    }

    public void Update()
    {
        
        if (!chaserInRange && !plantInRange)
        {
            Wander();
        }
        if (chaserInRange && !plantInRange)
        {
            Flee();
        }
        if(!chaserInRange && plantInRange)
        {
            AttackPlants();
           // target = null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Check if player is in range of the Pest
        if (collision.gameObject.tag == "Player")
        {
            chaserInRange = true;
        }
        else chaserInRange = false;

        //Check if plant is in range of the Pest
        if (collision.gameObject.tag == "Plant")
        {
            target = (PlantType)collision.gameObject.GetComponent(typeof(PlantType));
            plantInRange = true;
            destination = target.transform.position;
        }
        else 
            plantInRange = false;
            
    }
    public void Wander()
    {
        float wanderRadius = 20;
		float wanderDistance = 30;
		float wanderJitter = 5;
		

        //Wanders a random range
		wanderTarget += new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitter,
									Random.Range(-1.0f, 1.0f) * wanderJitter,
									0);
		
		wanderTarget.Normalize();
		wanderTarget *= wanderRadius;
		
		Vector3 targetLocal = wanderTarget + new Vector3(wanderDistance, wanderDistance, 0);
		Vector3 targetWorld = this.gameObject.transform.InverseTransformVector(wanderTarget);
		
		destination = targetWorld;
       
       //alternative Wander/patrol doesnt work
       /* if(!walkPointSet) 
            SearchWalkPoint();

        if(walkPointSet)
            agent.SetDestination(walkPoint);
        //calc distance to walkpoint
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached, find a new walkpoint
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

            
    }
    public void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ );
*/
    }
    public void MoveTo()
	{
        //moves pest to destination
		Vector3 transformPos = new Vector3();
		transformPos = destination - this.transform.position;
		transform.Translate(transformPos.normalized * Time.deltaTime * speed);
		
        
    }

    public void AttackPlants()
    {
        //Destroys plant on collision and resets the target value
        if(target != null)
			{
				Destroy(target.gameObject);
				target = null;
                Debug.LogWarning("Pest has destroyed PlantType");
            }
        

    }
    void Flee()
    {
        //when player is within range, flee
        Vector3 normDir = (chaser.position - transform.position).normalized;

        normDir = Quaternion.AngleAxis(45, Vector3.up) * normDir;

        agent.SetDestination(transform.position - (normDir * displacementDist));
    }


}
