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

	public GameObject touch;
	// Use this for initialization
	void Start () {
	//	Screen.orientation = ScreenOrientation.Portrait;
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		//player = GameObject.FindGameObjectWithTag ("Player");

		//Checking for moblie
		Debug.Log ("Device: " + Application.platform);

		//Debug.Log (GameObject.Find("DualTouchControls").name);

		//This check if it's running Windows and if it is then deletes the touch on screen stuff
		if (Application.platform == RuntimePlatform.WindowsPlayer||Application.platform == RuntimePlatform.WindowsEditor){
			touch = GameObject.Find ("DualTouchControls");
			Destroy (touch);
			}
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
		float x = transform.position.x;
		float y = transform.position.y;

		if (transform.position.x <= xMin || transform.position.x >= xMax){
			x = Mathf.Clamp (followTarget.transform.position.x, xMin, xMax);
		} 
		if (transform.position.y <= yMin || transform.position.y >= yMax) {
			y = Mathf.Clamp (followTarget.transform.position.y, yMin, yMax);
		}
		//float y = Mathf.Clamp (followTarget.transform.position.y, yMin, yMax);
		gameObject.transform.position = new Vector3 (x, y, gameObject.transform.position.z);
	}
}
