using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

// Written by Katen, Jose, and Ben
// Used to make online players and control their movement (so that players don't control eachother by accident).

public class OnlinePlayerMovement : MonoBehaviourPun, IPunObservable
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
	//Used to show if the local player is in the scene
	public static GameObject LocalPlayerInstance;
	//Used to activate the proper player's camera
	[SerializeField] private GameObject camera;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
	
	//Awake is called when the gameobject is created in the scene
	void Awake()
	{
		if(photonView.IsMine)
		{
			OnlinePlayerMovement.LocalPlayerInstance = this.gameObject;
			camera.SetActive(true);
		}
		DontDestroyOnLoad(this.gameObject);
	}

    // Update is called once per frame
    void Update()
    {
		if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
		{
			return;
		}
		
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
	
	//neccessary for implementation, used to pass variables if needed
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
		if (stream.IsWriting)
		{
			stream.SendNext(speed);
		}
		else
		{
			// Network player, receive data
			//this. = (bool)stream.ReceiveNext();
			this.speed = (float)stream.ReceiveNext();
		}
    }
}
