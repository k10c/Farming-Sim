using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// By Katen

public class PlayerMovement : MonoBehaviour
{
    //speed of the player
    public float speed;
    //player goes left or right
    private float horizontalInput;
    //player goes up or down
    private float verticalInput;
    //Rigid Body of the player
    private Rigidbody playerRb;
	//Sprites the player uses
	[SerializeField] private Sprite[] sprites;
	//used to help with sprites
	private int direction;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //get player input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
		
		//sets the sprite of the player
		if(verticalInput > 0)
			direction = 2;
		else
			direction = 0;
		if(horizontalInput > 0)
			direction = 3;
		else if(horizontalInput < 0)
			direction = 1;
		GetComponent<SpriteRenderer>().sprite = sprites[direction];
		
        //Make the player move forward
        transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }
    private void OnCollisionEnter(Collision collision)
    {
		
    }
}
