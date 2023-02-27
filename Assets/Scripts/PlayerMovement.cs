using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// By Katen + Jose

public class PlayerMovement : MonoBehaviour
{
    //speed of the player
    public float speed;
    //player goes left or right
    private float horizontalInput;
    //player goes up or down
    private float verticalInput;
    //Rigid Body of the player
    private Rigidbody2D playerRb;
	//Sprites the player uses
	[SerializeField] private Sprite[] sprites;
	//used to help with sprites
	private int direction;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        //get player input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //sets the sprite of the player
        if (verticalInput > 0)
            direction = 2;
        else if (verticalInput < 0)
            direction = 0;
        if (horizontalInput > 0)
            direction = 3;
        else if (horizontalInput < 0)
            direction = 1;
        GetComponent<SpriteRenderer>().sprite = sprites[direction];

        //Make the player move horizontally
        if (horizontalInput > 0)
            playerRb.velocity = new Vector2(speed, playerRb.velocity.y);
        else if (horizontalInput < 0)
            playerRb.velocity = new Vector2(-speed, playerRb.velocity.y);
        else
            playerRb.velocity = new Vector2(0, playerRb.velocity.y);

        //Make the player move vertically
        if (verticalInput > 0)
            playerRb.velocity = new Vector2(playerRb.velocity.x, speed);
        else if (verticalInput < 0)
            playerRb.velocity = new Vector2(playerRb.velocity.x, -speed);
        else
            playerRb.velocity = new Vector2(playerRb.velocity.x, 0);


        /*transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);*/
    }

    private void OnCollisionEnter(Collision collision)
    {
		
    }
}
