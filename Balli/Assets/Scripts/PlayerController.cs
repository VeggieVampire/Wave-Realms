using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	private float PlayerSpeed = 10f;             //Floating point variable to store the player's movement speed.

	private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

	// Use this for initialization
	void Start()
	{
		//Get and store a reference to the Rigidbody2D component so that we can access it.
		rb2d = GetComponent<Rigidbody2D> ();
		//Anim = GetComponent<Animator> ();
	}

	void Update() {


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

	void OnCollisionEnter2D (Collision2D col){
		Debug.Log("Player has collided with " + col.collider.name);
		Debug.Log(col.gameObject.tag);
	}

	//FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate()
	{
		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis ("Horizontal");

		float moveHorizontalMoble = CrossPlatformInputManager.GetAxis("Horizontal");
		//Store the current vertical input in the float moveVertical.
		float moveVertical = Input.GetAxis ("Vertical");
		float moveVerticalMoble = CrossPlatformInputManager.GetAxis("Vertical");
		//Use the two store floats to create a new Vector2 variable movement.
		if (moveHorizontal != 0 || moveVertical != 0) {
			rb2d.velocity = new Vector2 (moveHorizontal * PlayerSpeed, moveVertical * PlayerSpeed);
		}
		if (moveHorizontalMoble != 0 || moveVerticalMoble != 0) {
			rb2d.velocity = new Vector2 (moveHorizontalMoble * PlayerSpeed, moveVerticalMoble * PlayerSpeed);
		}
		//Debug.Log ("H & V: " + movement);
		//Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
		//rb2d.AddForce (movement * speed);

		//GetComponentInParent<Rigidbody2D>().velocity = new Vector2 (moveVertical*speed, GetComponentInParent<Rigidbody2D>().velocity.x);
		//rb2d.velocity = new Vector2 (moveHorizontal*5, rb2d.velocity.x);
		//Debug.Log (movement * speed);

	}
}