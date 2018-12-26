using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProperties : MonoBehaviour {
	public string ItemName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D (Collision2D col){
		//Debug.Log("Player has collided with " + col.collider.name);
		Debug.Log(col.gameObject.tag);
	if(col.gameObject.tag == "Player"){
			Debug.Log(col.gameObject.tag);
		}
	if(col.gameObject.tag == "NPC"){
			Debug.Log(col.gameObject.tag);
		}
	}
	void ItemPropertiez() {

	}
}
