using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerController : MonoBehaviour {
	//[SerializeField]
	private float PlayerSpeed = 400f;             //Floating point variable to store the player's movement speed.
	public static RuntimePlatform platform;

	private float MoveThreshold = 0.5f;
	private Rigidbody2D myRigidbody;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

	private Animator anim;
	private bool playerMoving;
	public Vector2 lastMove;


	public Transform dust;
	private float DustBounceLow = -0.09f;
	private float DustBounceHigh = 0.16f;

	//Dust stuff
	private float DustOffXRightLeft = 0.25f;
	private float DustOffYRightLeft = -0.45f;
	private float DustOffXUpDown = 0; //not used
	private float DustOffYUpDown = -0.64f;
	private float DustTime = 2f;
	private float dustSpeed = 200;

	private float DustTimeCurrent;

	private float DustDirectionX;
	private float DustDirectionY;

	private bool DustdirectionLockRightLeft = false;
	private bool DustdirectionLockUpDown = false;

	//works on all players created of more than one
	private static bool playerExists;
	//private GameObject myDust;

	//private Vector2 direction;
	// Use this for initialization
	void Start()
	{
		//When a new level is loaded doesn't Destroy On Load 
		if (!playerExists) {
			playerExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (transform.gameObject);
		}
		//Screen.orientation = ScreenOrientation.Portrait;
		//Screen.orientation = ScreenOrientation.LandscapeLeft;
		//Debug.Log ("Device: " + Application.platform);
		anim = GetComponent<Animator> ();
		myRigidbody = GetComponent<Rigidbody2D> ();
		DustTimeCurrent = DustTime;
	}

	void Update() {
		//Move ();
		//Move2 ();
		Move3 ();
	}

	void OnCollisionEnter2D (Collision2D col){
		//Debug.Log("Player has collided with " + col.collider.name);
		//Debug.Log(col.gameObject.tag);
	}

	void AnimnationMovement(){
			float moveX = Input.GetAxis ("Horizontal");
			float moveXMoble = CrossPlatformInputManager.GetAxis("Horizontal");
			float moveYMoble = CrossPlatformInputManager.GetAxis("Vertical");
			float moveY = Input.GetAxis ("Vertical");
			/*
		float moveX = CrossPlatformInputManager ("Horizontal");
		float moveY = CrossPlatformInputManager ("Vertical");
	*/
			//Animation
			//Left and right animation
			if (moveX != 0 || moveXMoble != 0) {
				GetComponent<Animator> ().SetBool ("IsRunningRight", true);
			} else {
				//Debug.Log ("Unset Right");
				GetComponent<Animator> ().SetBool ("IsRunningRight", false);
			}
			//Down and Up animation
			//Down
			if (moveY != 0 && moveY < 0 ||moveYMoble != 0 && moveYMoble < 0 ){
				GetComponent<Animator> ().SetBool ("IsRunningUp", false);
				GetComponent<Animator> ().SetBool ("IsRunningDown", true);
				//Debug.Log ("Down");
				//Up
			} else if (moveY != 0 && moveY > 0 ||moveYMoble != 0 && moveYMoble > 0) {
				GetComponent<Animator> ().SetBool ("IsRunningUp", true);
				GetComponent<Animator> ().SetBool ("IsRunningDown", false);
				//Debug.Log ("Up");

			} else {
				GetComponent<Animator> ().SetBool ("IsRunningUp", false);
				GetComponent<Animator> ().SetBool ("IsRunningDown", false);
			}

			//Left and Right
			if(moveX < 0.0f ||moveXMoble < 0.0f){
				GetComponent<SpriteRenderer> ().flipX = true;
				//Debug.Log ("Moving left");
				//GetComponent<Animator>().SetBool ("IsRunningRight", true);

			}
			else if (moveX > 0.0f||moveXMoble > 0.0f){
				GetComponent<SpriteRenderer> ().flipX = false;
				//Debug.Log ("Moving right");
				//GetComponent<Animator>().SetBool ("IsRunningRight", true);
			}
			//Up and Down
			if(moveY > 0.0f||moveYMoble > 0.0f ){
				//GetComponent<Animator>().SetBool ("IsRunningUp", true);
				//Debug.Log ("Moving Up");
			}
			else if (moveY < 0.0f||moveYMoble < 0.0f){
				//Debug.Log ("Moving Down");
				//GetComponent<Animator>().SetBool ("IsRunningDown", true);
			}



	}

	//FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate()
	{
		//AnimnationMovement ();
	}
		

	private void Move(){
		float Currentspeed = PlayerSpeed*Time.deltaTime;
		playerMoving = false;

		//Set controller input
		#region
		float moveHorizontal = 0f;
		float moveVertical = 0f;
		//Horizontal movement
		if (Input.GetAxis ("Horizontal") != 0){
			moveHorizontal = Input.GetAxis ("Horizontal");
		} else if  (CrossPlatformInputManager.GetAxis("Horizontal") != 0){
			//Moblie Horizontal
			moveHorizontal = CrossPlatformInputManager.GetAxis ("Horizontal");
		}

		//Vertical movement
		if (Input.GetAxis ("Vertical") != 0){
			moveVertical = Input.GetAxis ("Vertical");
		} else if  (CrossPlatformInputManager.GetAxis("Vertical") != 0){
			//Moblie Vertical
			moveVertical = CrossPlatformInputManager.GetAxis ("Vertical");
		}
		#endregion

		//Check if movement not null 
		if (moveHorizontal != 0 || moveVertical != 0 ) {
			//movement not null, now check
			if (moveHorizontal > MoveThreshold || moveHorizontal < - MoveThreshold) { 
				//transform.Translate (new Vector3 (moveHorizontal * Currentspeed, 0f, 0f));
				myRigidbody.velocity = new Vector2(moveHorizontal * Currentspeed, myRigidbody.velocity.y);
				playerMoving = true;
				lastMove = new Vector2 (moveHorizontal, 0f);

				//dusting for left and right
				DustDirectionX = moveHorizontal;
				DustdirectionLockRightLeft = true;
				dusty();
				DustdirectionLockRightLeft = false;
				}
		
			if (moveVertical > MoveThreshold || moveVertical < - MoveThreshold) { 
				//transform.Translate (new Vector3 (0f, moveVertical * Currentspeed, 0f));
				myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, moveVertical * Currentspeed);

				playerMoving = true;
				lastMove = new Vector2 (0f, moveVertical);

				//dusting for up and down
				DustDirectionY = moveVertical;

				DustdirectionLockUpDown = true;
				dusty();
				DustdirectionLockUpDown = false;



			} 
			//stop player from drifting
			if (moveHorizontal < 0.51f && moveHorizontal > -0.51f) {
				myRigidbody.velocity = new Vector2 (0f, myRigidbody.velocity.y);
			}
			if (moveVertical < 0.51f && moveVertical > -0.51f) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, 0f);
			}

		} else {
			//stops movement on the spot 
			//Debug.Log ("Last Direction "+ direction);
			//rb2d.velocity = Vector2.zero;
			//transform.Translate (new Vector3 (0f, 0f, 0f));

			playerMoving = false;
		}
	anim.SetFloat ("MoveXanim", moveHorizontal);
	anim.SetFloat ("MoveYanim", moveVertical);
	anim.SetBool ("PlayerMoving", playerMoving);
	anim.SetFloat ("LastMoveX", lastMove.x);
	anim.SetFloat ("LastMoveY", lastMove.y);
		playerMoving = false;
	}

	private void Move2(){
		playerMoving = false;
		//float Currentspeed = PlayerSpeed*Time.deltaTime;
		float Currentspeed = PlayerSpeed*Time.fixedDeltaTime;

		//Cross platform Input
		#region
		float moveHorizontal = 0f;
		float moveVertical = 0f;
		//Horizontal movement
		if (Input.GetAxis ("Horizontal") != 0){
			moveHorizontal = Input.GetAxis ("Horizontal");
		} else if  (CrossPlatformInputManager.GetAxis("Horizontal") != 0){
			//Moblie Horizontal
			moveHorizontal = CrossPlatformInputManager.GetAxis ("Horizontal");
		}

		//Vertical movement
		if (Input.GetAxis ("Vertical") != 0){
			moveVertical = Input.GetAxis ("Vertical");
		} else if  (CrossPlatformInputManager.GetAxis("Vertical") != 0){
			//Moblie Vertical
			moveVertical = CrossPlatformInputManager.GetAxis ("Vertical");
		}
		#endregion

		//Movement
		#region
		//left and right
		if(moveHorizontal > 0.5f || moveHorizontal < -0.5f)
		{
			//transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
			myRigidbody.velocity = new Vector2(moveHorizontal * Currentspeed, myRigidbody.velocity.y);
			playerMoving = true;
			lastMove = new Vector2(moveHorizontal, 0f);


			//dusting for left and right
			DustDirectionX = moveHorizontal;
			DustdirectionLockRightLeft = true;
			dusty();
			DustdirectionLockRightLeft = false;

		}
		else
		{
			myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
		}

		//up and down
		if (moveVertical > 0.5f || moveVertical < -0.5f)
		{
			//transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
			myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * Currentspeed);
			playerMoving = true;
			lastMove = new Vector2(0f, moveVertical);

			//dusting for up and down
			DustDirectionY = moveVertical;
			DustdirectionLockUpDown = true;
			dusty();
			DustdirectionLockUpDown = false;
		}
		else
		{
			myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
		}﻿

			
		
		#endregion

		//Animation
		#region
		anim.SetFloat ("MoveXanim", moveHorizontal);
		anim.SetFloat ("MoveYanim", moveVertical);
		anim.SetBool ("PlayerMoving", playerMoving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);
		#endregion
		playerMoving = false;
	}


	private void Move3(){
		float Currentspeed = PlayerSpeed*Time.deltaTime;
		playerMoving = false;
		//moveHorizontal
		//moveVertical
		//Set controller input
		#region
		float moveHorizontal = 0f;
		float moveVertical = 0f;
		//Horizontal movement
		if (Input.GetAxis ("Horizontal") != 0){
			moveHorizontal = Input.GetAxis ("Horizontal");
		} else if  (CrossPlatformInputManager.GetAxis("Horizontal") != 0){
			//Moblie Horizontal
			moveHorizontal = CrossPlatformInputManager.GetAxis ("Horizontal");
		}

		//Vertical movement
		if (Input.GetAxis ("Vertical") != 0){
			moveVertical = Input.GetAxis ("Vertical");
		} else if  (CrossPlatformInputManager.GetAxis("Vertical") != 0){
			//Moblie Vertical
			moveVertical = CrossPlatformInputManager.GetAxis ("Vertical");
		}
		#endregion

		//left right input
		if (moveHorizontal > 0.5f || moveHorizontal < -0.5f) {
			myRigidbody.velocity = new Vector2(moveHorizontal * Currentspeed, myRigidbody.velocity.y);
			playerMoving = true;
			lastMove = new Vector2 (moveHorizontal, 0f);

			//dusting for left and right
			DustDirectionX = moveHorizontal;
			DustdirectionLockRightLeft = true;
			dusty();
			DustdirectionLockRightLeft = false;
		}
		//up down input
		if (moveVertical > 0.5f || moveVertical < -0.5f) {
			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, moveVertical * Currentspeed);
			playerMoving = true;
			lastMove = new Vector2 (0f, moveVertical);

			//dusting for left and right
			DustDirectionY = moveVertical;
			DustdirectionLockUpDown = true;
			dusty ();
			DustdirectionLockUpDown = false;
		}

		if (moveHorizontal < 0.5f && moveHorizontal > -0.5f) {
			myRigidbody.velocity = new Vector2 (0f, myRigidbody.velocity.y);
		}
		if (moveVertical < 0.5f && moveVertical > -0.5f) {
			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, 0f);
		}

		anim.SetFloat ("MoveXanim", moveHorizontal);
		anim.SetFloat ("MoveYanim", moveVertical);
		anim.SetBool ("PlayerMoving", playerMoving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);
		//playerMoving = false;
	}


	void dusty(){
		
		DustTime--;
		if (DustTime <= 0) {
			DustTime = DustTimeCurrent;

				if (DustdirectionLockRightLeft == true && DustdirectionLockUpDown == false) {
				float DustBounceX = Random.Range (DustBounceLow, DustBounceHigh);
				float DustBounceY = Random.Range (DustBounceLow, DustBounceHigh);
					if (DustDirectionX > 0) {
						//left dust
					Transform LeftDust = Instantiate (dust, new Vector3 (this.gameObject.transform.position.x - DustOffXRightLeft + DustBounceX, this.gameObject.transform.position.y + DustOffYRightLeft + DustBounceY, 0f), Quaternion.identity);
					LeftDust.gameObject.AddComponent<Rigidbody2D>();
					LeftDust.transform.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0;
					LeftDust.gameObject.GetComponent<Rigidbody2D>().AddForce (Vector2.right * dustSpeed);
				/*	GameObject box = Instantiate(rayUp.collider.gameObject, new Vector3(boxPostionX , boxPostionY, 0), Quaternion.identity);
					box.transform.localScale = new Vector3 (0.2f, 0.2f, 0);
					box.gameObject.AddComponent<Rigidbody2D>();
					box.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * foceNumber);
				*/
				
				} else {
						//right dust
						//Instantiate (dust, new Vector3 (this.gameObject.transform.position.x + DustOffXRightLeft, this.gameObject.transform.position.y + DustOffYRightLeft, 0f), Quaternion.identity);
					Transform RightDust = Instantiate (dust, new Vector3 (this.gameObject.transform.position.x + DustOffXRightLeft + DustBounceX, this.gameObject.transform.position.y + DustOffYRightLeft + DustBounceY, 0f), Quaternion.identity);
					RightDust.gameObject.AddComponent<Rigidbody2D>();
					RightDust.transform.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0;
					RightDust.gameObject.GetComponent<Rigidbody2D>().AddForce (Vector2.left * dustSpeed);
					}
				}


			//DustOffXUpDown
				if (DustdirectionLockUpDown == true && DustdirectionLockRightLeft == false) {
				float DustBounceX = Random.Range (DustBounceLow, DustBounceHigh);
				float DustBounceY = Random.Range (DustBounceLow, DustBounceHigh);
				//Transform UpDust = Instantiate (dust, new Vector3 (this.gameObject.transform.position.x + DustBounceX, this.gameObject.transform.position.y - DustOffYUpDown + DustBounceY, 0f), Quaternion.identity);

				//Debug.Log ("Y: " + DustDirectionY);
			//	Debug.Log ("X: " + DustDirectionX);
					if (DustDirectionY > 0) {
						//up
					Transform UpDust = Instantiate (dust, new Vector3 (this.gameObject.transform.position.x + DustBounceX, this.gameObject.transform.position.y + DustOffYUpDown + DustBounceY, 0f), Quaternion.identity);
					UpDust.gameObject.AddComponent<Rigidbody2D>();
					UpDust.transform.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0;
					UpDust.gameObject.GetComponent<Rigidbody2D>().AddForce (Vector2.up * dustSpeed);
				}

				if (DustDirectionY < 0) {
						//down
					Transform DownDust = Instantiate (dust, new Vector3 (this.gameObject.transform.position.x + DustBounceX, this.gameObject.transform.position.y - DustOffYUpDown + DustBounceY, 0f), Quaternion.identity);
					DownDust.gameObject.AddComponent<Rigidbody2D>();
					DownDust.transform.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0;
					DownDust.gameObject.GetComponent<Rigidbody2D>().AddForce (Vector2.down * dustSpeed);
					}


				}
				





		}
	}

}