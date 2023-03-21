using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class created by Katen
public class PestBot2 : PestManager2
{
    PestBot2(){ }

	override public PestManager2 Clone()
	{
		return (PestBot2)this.Clone();
	}

	override public void FleePlayer1()
	{
       distance = Vector2.Distance(transform.position, chaser1.transform.position);
	   Vector2 direction =  transform.position + chaser1.transform.position ;
	   direction.Normalize();
	   float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

	   if(distance < distanceBetweenPlayer)
	   {
		transform.position = Vector2.MoveTowards(this.transform.position, chaser1.transform.position, speed * Time.deltaTime);
		transform.rotation = Quaternion.Euler(Vector3.forward * angle);
	   }
	}
	override public void FleePlayer2()
	{
       distance = Vector2.Distance(transform.position, chaser2.transform.position);
	   Vector2 direction =  transform.position + chaser2.transform.position ;
	   direction.Normalize();
	   float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

	   if(distance < distanceBetweenPlayer)
	   {
		transform.position = Vector2.MoveTowards(this.transform.position, chaser2.transform.position, speed * Time.deltaTime);
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

