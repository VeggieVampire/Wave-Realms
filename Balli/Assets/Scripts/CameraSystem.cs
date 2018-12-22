using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {

	public GameObject followTarget;
	private Vector3 targetPos;
	public float moveSpeed;

	public float xMin;
	public float xMax;
	public float yMin;
	public float yMax;


	// Use this for initialization
	void Start () {
	//	Screen.orientation = ScreenOrientation.Portrait;
		//player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
		

		targetPos = new Vector3 (followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
		transform.position = Vector3.Lerp(
			transform.position,											//Position Currently at //FROM
			targetPos, 													//Position Want to be at //TO
			moveSpeed * Time.deltaTime  );								// At what speed
										
	}
	// Last Update is called once per frame
	void LateUpdate () {
		Clamping();
	}


	void Clamping (){
		float x = Mathf.Clamp (followTarget.transform.position.x, xMin, xMax);
		float y = Mathf.Clamp (followTarget.transform.position.y, yMin, yMax);
		gameObject.transform.position = new Vector3 (x, y, gameObject.transform.position.z);
	}
}
