using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dust : MonoBehaviour {

	public float DustSizeReducation;
	public float DustSizeDestroy=1;
	public float DestroyTime;
	public float RotationolSpeed;
	// Use this for initialization
	void Start () {
		//KillTime = KillTime * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {

		DestroyTime = DestroyTime - 1;
		//Debug.Log ("DTIME: " + DestroyTime);
		transform.localScale -= new Vector3 (DustSizeReducation, DustSizeReducation, 0f);
		transform.Rotate  (new Vector3 (0f, 0f, RotationolSpeed*Time.deltaTime) );	
		//transform.gameObject.AddComponent<Rigidbody2D>();
		//transform.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0;

		//GameObject box = Instantiate(rayUp.collider.gameObject, new Vector3(boxPostionX , boxPostionY, 0), Quaternion.identity);
		//box.transform.localScale = new Vector3 (0.2f, 0.2f, 0);
		//box.gameObject.AddComponent<Rigidbody2D>();
		//GetComponent<Rigidbody2D>().AddForce (Vector2.up * 1000);
		//rayDown.collider.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 200);
		if (DestroyTime <= 0 || transform.localScale.x <= DustSizeDestroy) {
			Destroy(gameObject);

		}

		//Debug.Log ("Scale: " + transform.localScale.x);



	}
}
