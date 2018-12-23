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


	// Use this for initialization
	void Start () {

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
		float sw = 40;
		//Debug.Log ("Screen Height: " + Screen.width / 30);
		float sh = 18;

		for (int y = 0; y < sh - 5; y++)
		{
			for (int x = 0; x < sw - 11; x++) {
				float swidth = (x * sw) / 49;
				float sheight = (y * sh) /22 ;
				int RRnumber = Random.Range (1, 5);
				if (RRnumber == 1) {
					Instantiate (grass_0, new Vector3 (swidth, sheight, 0), Quaternion.identity);
				}
				if (RRnumber == 2) {
					Instantiate (grass_1, new Vector3 (swidth, sheight, 0), Quaternion.identity);
				}
				if (RRnumber == 3) {
					Instantiate (grass_2, new Vector3 (swidth, sheight, 0), Quaternion.identity);
				}
				if (RRnumber == 4) {
					Instantiate (grass_3, new Vector3 (swidth, sheight, 0), Quaternion.identity);
				}
				if (RRnumber == 5) {
					Instantiate (grass_4, new Vector3 (swidth, sheight, 0), Quaternion.identity);
				}
				//float sw = Screen.width/100;

				//Debug.Log (swidth);


			}
			
		}


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
	
	// Update is called once per frame
	void Update () {
		//float boxPostionX = rayUp.collider.gameObject.transform.position.x;
		//float boxPostionY = rayUp.collider.gameObject.transform.position.y;

	}




}
