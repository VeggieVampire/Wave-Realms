﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCfallowPLayer : MonoBehaviour {
	public float NPCSpeed = 1;
	public float DistanceFromTarget = 5;
	private Rigidbody2D MyRigidbody;

	private int DurectionRadomNumber;
	private float Currentspeed;
	private float Rotation = 0;


	private Transform NPC;
	private Transform followTarget;


	//private Vector3 startLine;
	//private GameObject followTarget; 
	//private Vector3 TargetLine;
	public float waitToReload;
	private bool reloading;
	private CameraSystem theCamera;
	private GameObject thePlayer;

	private void Awake(){
		NPC = this.transform;
		followTarget = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	// Use this for initialization
	void Start () {
		
		reloading = false;
		waitToReload = 5;

		MyRigidbody = GetComponent<Rigidbody2D>();
		//DurectionRadomNumber = Random.Range (1, 4);
		DurectionRadomNumber = 3;
		NPCSpeed = NPCSpeed * Time.deltaTime;
		Currentspeed = NPCSpeed;

		//startLine = (this.gameObject.GetComponent<Transform> ().position.x, this.gameObject.GetComponent<Transform> ().position.y, this.gameObject.GetComponent<Transform> ().position.z);
		//1 left
		//2 right
		//3 up
		//4 down
		//followTarget = GameObject.Find("PLayer");

	}
		/*
	void LocalPos (){
		//Vector3 startLine = gameObject.GetComponent<Rigidbody2D>().velocity.x, gameObject.GetComponent<Rigidbody2D>().velocity.y ;
		startLine = new Vector3(this.gameObject.GetComponent<Transform> ().position.x,this.gameObject.GetComponent<Transform> ().position.y,this.gameObject.GetComponent<Transform> ().position.z);
	}

	void GetPlayersPos(){
	//	gameObject.FindWithTag ("Player").gameObject.GetComponentsInParent<Transform>().
		Transform followTargetTransform = followTarget.transform;
		Debug.Log (followTargetTransform.position);
		//TargetLine = new Vector3 (followTargetTransform.position);
	}*/

	// Update is called once per frame
	void Update () {
		
		//Check if the NPC found a target
		if (followTarget) {

			//Turns on the animation
			GetComponent<Animator> ().SetBool ("IsMoving", false);
			//Debug.Log (followTarget.name + "is " + Distance().ToString () + " units from" + NPC.name);

			//checks distance from followTarget and NPC
			if(Distance() <= DistanceFromTarget){
				
				//Makes NPC face followTarget
				transform.up = followTarget.position - transform.position;
				//MyRigidbody.velocity = new Vector2 (MyRigidbody.velocity.x, followTarget.position.y * Currentspeed);
				//moves NPC
				Moving();	
			}
			//transform.LookAt (player);

		} else {
		//	Debug.Log ("Player not found");
		}


		//LocalPos ();
		//GetPlayersPos ();
		//Debug.DrawLine(startLine, new Vector3(0f,500f,0f), Color.white, 0.1f);
	}

	private float Distance(){
		return Vector3.Distance (NPC.position, followTarget.position);
	}
	void Moving(){


		if (reloading) { // if reloading is true
			waitToReload -= Time.deltaTime;
			if (waitToReload < 0) {
				Application.LoadLevel (Application.loadedLevel);
				thePlayer.SetActive (true);
				theCamera.followTarget = thePlayer;
			}
		}
		GetComponent<Animator> ().SetBool ("IsMoving", true);
		//transform.Translate (new Vector3 (Currentspeed, 0f, 0f));
		//NewDurection ();

		switch (DurectionRadomNumber) {
		case 1: //Left
			//gameObject.transform.Rotate (Vector3.right *Currentspeed);
			transform.Translate (new Vector3 (-Currentspeed, 0f, 5f));
			//MyRigidbody.velocity = (new Vector2(-Currentspeed,0f));
		//	Debug.Log ("NPC left");
			break;
		case 2: //Right
			//gameObject.transform.Rotate (Vector3.right *Currentspeed);
			transform.Translate (new Vector3 (Currentspeed, 0f, 0f));
			//MyRigidbody.velocity = (new Vector2(Currentspeed,0f));
		//	Debug.Log ("NPC right");
			break;
		case 3://up
			//gameObject.transform.Rotate (Vector3.right *Currentspeed);
			transform.Translate (new Vector3 (0f, Currentspeed, 0f));
			//MyRigidbody.velocity = (new Vector2(0f,Currentspeed));
	//		Debug.Log ("NPC up");
			break;
		case 4://down
			//gameObject.transform.Rotate (Vector3.right *Currentspeed);
			transform.Translate (new Vector3 (0f, -Currentspeed, 0f));
			//MyRigidbody.velocity = (new Vector2(0f,-Currentspeed));
	//		Debug.Log ("NPC down");
			break;
		}
	
//GetComponent<Animator> ().SetBool ("IsMoving", false);



		// Move in direction of DurectionRadomNumber

		//OnCollisionEnter2D
		//NewDurection();

	}

	void OnCollisionEnter2D (Collision2D col){
		Debug.Log(this.gameObject.name + " has collided with " + col.collider.name);
		GetComponent<Animator> ().SetBool ("IsMoving", false);
		/*
		Rotation = Rotation + 1;
		if (Rotation == 360) {
			Rotation = 0;
		}

*/
		//transform.Translate (new Vector3 (0f, -Currentspeed, Rotation));

		if (col.gameObject.tag == "walls" ) {
			NewDurection ();
			}
		if(col.gameObject.tag == "Player"){
			//Instantiate (gameObject, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
			reloading = true;

			//theCamera gets a new Object to follow.
			theCamera = FindObjectOfType<CameraSystem> ();
			theCamera.followTarget = this.gameObject;
			thePlayer = col.gameObject;
			col.gameObject.SetActive (false);


			//NewDurection ();
		}
		if(col.gameObject.tag == "Item"){
			//Instantiate (gameObject, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
			NewDurection ();
		}
		Moving();
	}

	void NewDurection(){
		int oldDurection = DurectionRadomNumber;
		while (oldDurection == DurectionRadomNumber) {
			DurectionRadomNumber = Random.Range (1, 4);
			}

		//	Debug.Log ("Old:" + oldDurection);
		//	Debug.Log ("NEW:" + DurectionRadomNumber);

		}
		


		/*
		 if(Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.5f), Vector3.down,out hit)) //Left
		  */

}
