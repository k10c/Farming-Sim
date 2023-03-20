using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Written by Katen, Jose, and Ben
//Used to let the players move their characters. Also controls the animator.

public class PlayerMovement : MonoBehaviour
{
    //speed of the player
    public float speed = 5;
    //player goes left or right
	[SerializeField] private string upButton = "w";
	[SerializeField] private string leftButton = "a";
	[SerializeField] private string downButton = "s";
	[SerializeField] private string rightButton = "d";
    private float horizontalInput;
    //player goes up or down
    private float verticalInput;
    //Rigid Body of the player
    private Rigidbody playerRb;
	//Sprites the player uses
	private Animator animator;
	//???
	private const float DISTANCEFROMPLAYER = 0.3f;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //get player input, set sprite
        if(Input.GetKey(leftButton) && !Input.GetKey(rightButton))
		{
			horizontalInput = -1;
			animator.SetInteger("Direction", 1);
		}
		else if(Input.GetKey(rightButton) && !Input.GetKey(leftButton))
		{
			horizontalInput = 1;
			animator.SetInteger("Direction", 3);
		}
		else
			horizontalInput = 0;
		if(Input.GetKey(upButton) && !Input.GetKey(downButton))
		{
			verticalInput = 1;
			animator.SetInteger("Direction", 2);
		}
		else if(Input.GetKey(downButton) && !Input.GetKey(upButton))
		{
			verticalInput = -1;
			animator.SetInteger("Direction", 0);
		}
			else verticalInput = 0;
		
        //Make the player move forward
        transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }
    private void OnCollisionEnter(Collision collision)
    {
		
    }
}
