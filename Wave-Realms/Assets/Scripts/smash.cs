using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smash : MonoBehaviour {
	float dustRR = 1f;
	public Transform dust;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float dustSpeed = 500f;

		Transform LeftDust = Instantiate (dust, new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.identity);
		LeftDust.gameObject.AddComponent<Rigidbody2D>();
		LeftDust.transform.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0;
		//LeftDust.gameObject.GetComponent<Rigidbody2D>().AddForce (this.gameObject.transform.position.x + dustRR,this.gameObject.transform.position.y + dustRR  * dustSpeed);
		//Quaternion target = Quaternion.Euler(0f, dustRR, 0f);


		LeftDust.gameObject.GetComponent<Rigidbody2D>().AddForce (Vector2.up * dustSpeed);
		LeftDust.transform.rotation = Quaternion.Euler(Vector3.left);
		dustRR ++;
		if (dustRR >= 360) {
			dustRR = 1;
		}
	}
}
