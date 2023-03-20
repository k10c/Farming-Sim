using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class created by Katen
public class PestBot : PestManager
{
    PestBot(){ }

	override public PestManager Clone()
	{
		return (PestBot)this.Clone();
	}

	override public void Flee()
	{
       distance = Vector2.Distance(transform.position, chaser.transform.position);
	   Vector3 direction =  (chaser.transform.position - transform.position).normalized;
	   float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

	   if(distance > distanceBetweenPlayer)
	   {
		transform.position = Vector2.MoveTowards(this.transform.position, chaser.transform.position, speed * Time.deltaTime);
		transform.rotation = Quaternion.Euler(Vector3.forward * angle);
	   }
	}
	
	override public void AttackPlants()
	{
		if(target != null)
        {
                Destroy(target.gameObject);
                Debug.LogWarning("Pest has destroyed PlantType");
                
        }
        else 
        {
            plantInRange = false;
            target = null;
            cooldown = false;
        }
	}

}
