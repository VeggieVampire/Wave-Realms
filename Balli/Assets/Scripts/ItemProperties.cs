using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProperties : MonoBehaviour {
	public string ItemName;
	// Use this for initialization

	public GameObject NPC;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D (Collision2D col){
		//Debug.Log("Player has collided with " + col.collider.name);
		//Debug.Log(col.gameObject.tag);



		/*
		 //destroy your target you collided with
		Destroy(col.gameObject);
		//destroy yourself
		Destroy(this.gameObject);
		*/
	}
	//void OnTriggerEnter (Collider other){
	void OnTriggerEnter2D(Collider2D col){
		Debug.Log(col.gameObject.tag);
		if (col.gameObject.tag == "Player") {
			Debug.Log (col.gameObject.tag);
			Destroy(this.gameObject);
		}
		if (col.gameObject.tag == "NPC") {
			NPC = col.gameObject;
			Debug.Log (col.gameObject.tag);
			if (ItemName == "leaf") {
				Instantiate (NPC, new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.identity);
				Destroy(this.gameObject);
			}
		}

	}
	void ItemPropertiez() {

	}
}
