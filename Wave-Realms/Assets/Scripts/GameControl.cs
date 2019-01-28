using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using System;

/// <summary>
/// PLayer Move scrript
/// </summary>
public class GameControl : MonoBehaviour {

	// Use this for initialization

	public int playerSpeed = 10;
	public int playerJumpPower = 1250;
	private float moveX;
	private float moveY;
	public bool isGounded;
	public float distanceToBottemOfPlayer = 0.9f;


	void Start () {
		//Debug.Log("Point!");

	}

	// Update is called once per frame
	void Update () {

		PlayerMove ();
		PlayerRaycast ();
		/*
		float zHorizontal = Input.GetAxis ("Horizontal");
		int hor = Mathf.RoundToInt (zHorizontal);
			   if (hor == 1) {
			
		} else if (hor == -1) {
			
		} else if (hor == 0) {
			Debug.Log ("NOt moving stopped");
		}
		*/
	}
	void PhysiscZ(){
		
		GetComponentInParent<Rigidbody2D>().velocity = new Vector2 (moveX*playerSpeed, GetComponentInParent<Rigidbody2D>().velocity.y);
		GetComponentInParent<Rigidbody2D>().velocity = new Vector2 (moveY*playerSpeed, GetComponentInParent<Rigidbody2D>().velocity.x);
	}
	void PlayerMove (){
		//Animations
		//PLayer direction

		//Left and Right
		if(moveX < 0.0f ){
			GetComponent<SpriteRenderer> ().flipX = true;
			Debug.Log ("Moving left");
			PhysiscZ();
		}
		else if (moveX > 0.0f){
			GetComponent<SpriteRenderer> ().flipX = false;
			Debug.Log ("Moving right");
		}
		//Up and Down
		if(moveY < 0.0f ){
			GetComponent<SpriteRenderer> ().flipX = true;
			Debug.Log ("Moving Up");
		}
		else if (moveY > 0.0f){
			GetComponent<SpriteRenderer> ().flipX = false;
			Debug.Log ("Moving Down");
		}
		//PHYSICS

		//GetComponentInParent<Rigidbody2D>().velocity = new Vector2 (moveX*playerSpeed, GetComponentInParent<Rigidbody2D>().velocity.y);
		//GetComponentInParent<Rigidbody2D>().velocity = new Vector2 (moveY*playerSpeed, GetComponentInParent<Rigidbody2D>().velocity.x);
		//Controls
		moveX = Input.GetAxis ("Horizontal");
		moveY = Input.GetAxis ("Vertical");

		//if (Input.GetButtonDown ("BButton") && isGounded == true) {
	//		Jump();
	//	}
		//float yy = this.gameObject.GetComponent<Rigidbody2D>().velocity.y;

		//this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed,yy);

		/*
		//Checking all Button inputs not axises
		if (Input.anyKey){
			foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
			{
				if (Input.GetKeyDown(kcode))
					Debug.Log("KeyCode down: " + kcode);
			}
		}

		float AxisStuffH = Input.GetAxisRaw ("Horizontal") * Time.deltaTime;
		float AxisStuffV = Input.GetAxis("Vertical") * Time.deltaTime  * 10000;

		Debug.Log ("Horizontal: " + AxisStuffH);
		Debug.Log ("Vertical: " + AxisStuffV);
		*/
	}




	void Jump(){
		//JUMPING CODE
		isGounded = false;
		GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
		//Debug.Log ("JUMPING!!!");

	}


	void OnCollisionEnter2D (Collision2D col){
		//Debug.Log("Player has collided with " + col.collider.name);
		//Debug.Log(col.gameObject.tag);

		//if (col.gameObject.tag == "ground") {
		//		isGounded = true;
		//Debug.Log(col.collider.name + "Is gounded");
		//	}
	}
	void PlayerRaycast () {
		//UP
		//invisable ray cast under player to detect if something is under the chr.
		RaycastHit2D rayDown = Physics2D.Raycast (transform.position, Vector2.down);
		RaycastHit2D rayUp = Physics2D.Raycast (transform.position, Vector2.up);

		if (rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottemOfPlayer && rayDown.collider.tag == "enemy") {  
			//Debug.Log ("hit enemy");
			GetComponent<Rigidbody2D>().AddForce (Vector2.up * 1000);
			rayDown.collider.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 200);
			rayDown.collider.gameObject.GetComponent<Rigidbody2D> ().freezeRotation = false;
			rayDown.collider.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 7;
			rayDown.collider.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			//rayDown.collider.gameObject.GetComponent<EnemyMove> ().enabled = false;
			//Destroy (hit.collider.gameObject);
		}
		//checks if gounded
		if (rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottemOfPlayer && rayDown.collider.tag != "enemy") {  
			isGounded = true;
			//Debug.Log ("hit ground");
		}
		//checks if hit up
		if (rayUp != null && rayUp.collider != null && rayUp.distance < distanceToBottemOfPlayer && rayUp.collider.tag == "breakable") { 
			//Debug.Log ("hit breakable box");
			//Destroy (rayUp.collider.gameObject);

			for (int y = 0; y < 4; y++) 
			{
				for (int x = 0; x < 4; x++) 
				{
					//creates object
					float boxPostionX = rayUp.collider.gameObject.transform.position.x;
					float boxPostionY = rayUp.collider.gameObject.transform.position.y;
					GameObject box = Instantiate(rayUp.collider.gameObject, new Vector3(boxPostionX , boxPostionY, 0), Quaternion.identity);
					box.transform.localScale = new Vector3 (0.2f, 0.2f, 0);
					box.gameObject.AddComponent<Rigidbody2D>();

					int RRnumber = Random.Range (1, 4);
					int foceNumber = Random.Range (1,600);
					Debug.Log (RRnumber);
					if (RRnumber == 1) {
						box.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * foceNumber);
					}
					if (RRnumber == 2) {
						box.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.left * foceNumber);
					}

					if (RRnumber == 3) {
						box.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * foceNumber);
					}

					if (RRnumber == 4) {
						box.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.down * foceNumber);
					}

					int gravityRnumber = Random.Range (1, 15);
					box.gameObject.GetComponent<Rigidbody2D> ().gravityScale = gravityRnumber;
					box.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					box.gameObject.GetComponent<Rigidbody2D> ().freezeRotation = false;
					/**
					box.gameObject.AddComponent<Rigidbody2D>();
					box.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 200);


					//
					//box.gameObject.GetComponent<EnemyMove> ().enabled = false;
					Debug.Log(box.transform.position.y);
					//cube.AddComponent<Rigidbody>();
					//cube.transform.position = new Vector2(x, y);
					**/

				}
			}
			Destroy (rayUp.collider.gameObject);


		}

	}  

}
//print(Input.mousePosition);
//print (Input.GetMouseButtonDown);
//new int value = 
//	float Vertical = Input.GetAxis ("Vertical");
//if (Vertical > 1)
//	Debug.Log("Up");

//	float Horizontal = Input.GetAxis ("Horizontal");

//if (Horizontal > 0)

//	Debug.Log("Right");

//if (Horizontal < 0 )
//	Debug.Log("left");

//if (Horizontal == 0 )
//	Debug.Log("zero");




/*

		Debug.Log("Button X: " + Input.GetAxis ("XButton") );
		Debug.Log("Button A: " + Input.GetAxis ("AButton") );
		Debug.Log("Button B: " + Input.GetAxis ("BButton") );
		Debug.Log("Button y: " + Input.GetAxis ("YButton") );
		Debug.Log("Button Left: " + Input.GetAxis ("LeftButton") );
		Debug.Log("Button Right: " + Input.GetAxis ("RightButton") );
		Debug.Log("Button Select: " + Input.GetAxis ("SelectButton") );
		Debug.Log("Button start: " + Input.GetAxis ("StartButton") );
*/