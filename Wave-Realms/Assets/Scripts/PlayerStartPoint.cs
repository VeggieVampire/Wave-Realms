using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {


	//tells player and cameraSystem to start at
	private PlayerController thePlayer;
	private CameraSystem theCamera;

	public Vector2 startDirection;

	// Use this for initialization
	void Start () {
		//Finds the Player
		thePlayer = FindObjectOfType<PlayerController> ();

		//X0,Y0 = down
		//X0,Y1 = up
		//X1,Y0 = left
		//X1,Y1 = right
		thePlayer.lastMove = startDirection;

		//Moves the Player
		thePlayer.transform.position = transform.position;

		//Finds the Camera
		theCamera = FindObjectOfType<CameraSystem> ();
		//Moves only X and Y. Keeps local Z 
		theCamera.transform.position = new Vector3 (transform.position.x, transform.position.y, theCamera.transform.position.z);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
