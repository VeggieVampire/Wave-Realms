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

	private GameObject touch;
	private GameObject MoveTouch;
	private RectTransform MoveTouch2;
	// Use this for initialization
	void Start () {
	//	Screen.orientation = ScreenOrientation.Portrait;
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		//player = GameObject.FindGameObjectWithTag ("Player");

		//Debug.Log ("Screen Height: " + Screen.height);
		//Debug.Log ("Screen Width: " + Screen.width);

		//Checking for moblie stuff
		Debug.Log ("Device: " + Application.platform);


		/*
		MoveTouch = GameObject.Find ("MoveTouchpad");
		MoveTouch.transform.Translate (new Vector2 (Screen.width/4,100f));
		//Change the Position of the MoveTouch pad
		MoveTouch2 = GameObject.Find ("MoveTouchpad").GetComponent<RectTransform> ();

	*/
		//Change the Position of the MoveTouch pad
		//MoveTouch2.localPosition = new Vector2(2f,5f);

		//Change the size of the MoveTouch pad
		//MoveTouch2.sizeDelta = new Vector2(Screen.width/2,Screen.height/2);

		//This check if it's running Windows and if it is then deletes the touch on screen stuff
		if (Application.platform == RuntimePlatform.WindowsPlayer||Application.platform == RuntimePlatform.WindowsEditor){
			//touch = GameObject.Find ("MoveTouchpad");
			touch = GameObject.Find ("MobileJoystick");

			if (touch.name != "DualTouchControls") {
					//	touch = GameObject.Find ("MoblieSingleStickControl");
					//Debug.Log (touch.transform.parent.gameObject.name);
				//Debug.Log (touch.name);
					Destroy (touch.transform.parent.gameObject);
					Destroy (touch);

				} else {
				touch = GameObject.Find ("MoveTouchpad");
				Debug.Log (touch.name);
				//touch = GameObject.Find ("MobileJoystick");
					Destroy (touch.transform.parent.gameObject);
					Destroy (touch);
				}
			//Destroy (touch);
			//touch.SetActive(false);
			//Debug.Log("DualTouchControls status: " + touch.activeSelf);
			}
	}

	// Update is called once per frame
	void Update() {
		


										
	}
	// Last Update is called once per frame
	void LateUpdate () {

		targetPos = new Vector3 (followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
		transform.position = Vector3.Lerp(
			transform.position,											//Position Currently at //FROM
			targetPos, 													//Position Want to be at //TO
			moveSpeed * Time.deltaTime  );								// At what speed

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
