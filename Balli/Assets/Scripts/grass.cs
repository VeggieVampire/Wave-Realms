using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grass : MonoBehaviour {
	public Transform grass_0;
	public Transform grass_1;
	public Transform grass_2;
	public Transform grass_3;
	public Transform grass_4;
	/*

	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;
	public Sprite sprite4;
	public Sprite sprite5;
	*/
	//private SpriteRenderer spriteRenderer;
	private GameObject myGrass;
	// Use this for initialization
	void Start () {



		//OldScript ();
	//	NewScript ();

	}
	
	// Update is called once per frame
	void Update () {
		//float boxPostionX = rayUp.collider.gameObject.transform.position.x;
		//float boxPostionY = rayUp.collider.gameObject.transform.position.y;
	}


	void OldScript(){
	
		float sw = 40;
		//Debug.Log ("Screen Height: " + Screen.width / 30);
		float sh = 18;

		for (int y = 0; y < sh - 5; y++) {
			for (int x = 0; x < sw - 11; x++) {
				float swidth = (x * sw) / 49;
				float sheight = (y * sh) / 22;
				SpawnGrass (swidth, sheight);
				//float sw = Screen.width/100;

				//Debug.Log (swidth);


			}
		}

		/*
		spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
		if (spriteRenderer.sprite == null){ // if the sprite on spriteRenderer is null then
			spriteRenderer.sprite = sprite1; // set the sprite to sprite1
			}
			*/
		//Debug.Log ("Screen Width: " + Screen.width + Screen.height);
		//Debug.Log ("Screen Height: " + Screen.height);
		//Debug.Log ("Screen Width: " + Screen.width / 100);
		//Debug.Log ("x " + gameObject.transform.position.x);
		//Debug.Log ("y " + gameObject.transform.position.y);
		//float startX gameObject.transform.position.x;
		//float startY gameObject.transform.position.y;
		//float sw = Screen.width / 30;





		/*
			 * //for (int y = 0; y < 4; y++) 
		{
			//for (int x = 0; x < 4; x++) 
			{
				//creates object
				float boxPostionX = gameObject.transform.position.x;
				float boxPostionY = gameObject.transform.position.y;
				Instantiate(prefab,new Vector3(boxPostionX + x , boxPostionY + y, 0), Quaternion.identity);
				//GameObject box = Instantiate(gameObject original, new Vector3(boxPostionX , boxPostionY, 0), Quaternion.identity);
				//box.transform.localScale = new Vector3 (0.2f, 0.2f, 0);
			}
		}
		*/

	}
	void SpawnGrass(float XX, float YY){
		int RRnumber = Random.Range (1, 5);
		if (RRnumber == 1) {
			Instantiate (grass_0, new Vector3 (XX, YY, 0), Quaternion.identity);
		}
		if (RRnumber == 2) {
			Instantiate (grass_1, new Vector3 (XX, YY, 0), Quaternion.identity);
		}
		if (RRnumber == 3) {
			Instantiate (grass_2, new Vector3 (XX, YY, 0), Quaternion.identity);
		}
		if (RRnumber == 4) {
			Instantiate (grass_3, new Vector3 (XX, YY, 0), Quaternion.identity);
		}
		if (RRnumber == 5) {
			Instantiate (grass_4, new Vector3 (XX, YY, 0), Quaternion.identity);
		}

	}

	void NewScript(){
		//Debug.Log ("Screen Height: " + Screen.height);
		//Debug.Log ("Screen Width: " + Screen.width);
;
		Instantiate (grass_0, new Vector3 (0,0, 0), Quaternion.identity);
		myGrass = GameObject.Find ("grass_0(Clone)");
		float TileWidth = myGrass.GetComponent<SpriteRenderer> ().bounds.size.x;
		float TileHeight = myGrass.GetComponent<SpriteRenderer> ().bounds.size.y;

	//	Debug.Log ("Tile Width: " + TileWidth + " Height: " + TileHeight);
		Destroy (myGrass);
		//SpawnGrass (5f, 1f); /test grass

	//	float y = TileHeight;
	//	float x = TileWidth;

		float sw = Screen.width / 16 ;
		float sh = Screen.height / 10;
		//Debug.Log ("Screen Height: " + Screen.width / 30);
		//float sh = 100f;

		for (int y = 0; y < sh; y++) {
			for (int x = 0; x < sw; x++) {
				float swidth = (x * TileWidth);
				float sheight = (y * TileHeight);
				SpawnGrass (swidth, sheight);
			}
		}
		/* while(Screen.height > y ){
			//SpawnGrass (x, y);
			y = y + TileHeight;
			for (int xz = 0; xz < 10; xz++) {
				x = x + TileWidth;
				SpawnGrass (x, y);
			}
		}
		*/
	}
}
