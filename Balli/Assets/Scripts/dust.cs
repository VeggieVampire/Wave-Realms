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

		if (DestroyTime <= 0 || transform.localScale.x <= DustSizeDestroy) {
			Destroy(gameObject);

		}

		//Debug.Log ("Scale: " + transform.localScale.x);



	}
}
