using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugoController : MonoBehaviour {

	public float moveSpeed;
	private Rigidbody2D myRigidbody;
	private bool moving;

	public float timeBetweenMove;
	private float timeBetweenMoveCounter;

	public float timeToMove;
	private float timeToMoveCounter;

	private Vector3 MoveDirection;



	private CameraSystem theCamera;
	// Use this for initialization
	void Start () {
		moving = false;
		myRigidbody = GetComponent<Rigidbody2D> ();

		//timeBetweenMoveCounter = timeBetweenMove;
		//timeToMoveCounter = timeToMove;
		timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
		timeToMoveCounter = Random.Range(timeToMove * 0.75f,timeToMove * 1.25f);

	}
	
	// Update is called once per frame
	void Update () {





		if (moving) { //moving
			timeToMoveCounter -= Time.deltaTime; //one screen refresh
			myRigidbody.velocity = MoveDirection;
			if (timeToMoveCounter < 0f) { //if counter has finished for timeToMoveCounter
				moving = false;
				//timeBetweenMoveCounter = timeBetweenMove;
				timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
			}

		} else { //not moving
			timeBetweenMoveCounter -= Time.deltaTime; //one screen refresh
			myRigidbody.velocity = Vector2.zero;
			if (timeBetweenMoveCounter < 0f) { //if counter has finished for timeBetweenMove
				moving = true;
				//timeToMoveCounter = timeToMove; // reset counter for timeToMoveCounter
				timeToMoveCounter = Random.Range(timeToMove * 0.75f,timeToMove * 1.25f);
				float RRx = Random.Range(-1f,1f); //Random number between 0-1
				float RRy = Random.Range(-1f,1f);//Random number between 0-1
				MoveDirection = new Vector3(RRx * moveSpeed,RRy * moveSpeed,transform.position.z); //Set direction
				//MoveDirection = new Vector3(RRx * moveSpeed,RRy * moveSpeed,0f);

			}
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		//when colliders meet, do something

		if(other.gameObject.name == "Player"){

			//theCamera gets a new Object to follow.
			theCamera = FindObjectOfType<CameraSystem> ();
			theCamera.followTarget = this.gameObject;
			Destroy (other.gameObject); // Destroy the player
		}

	}
}
