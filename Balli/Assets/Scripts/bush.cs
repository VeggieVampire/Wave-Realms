using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bush : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CheckAnimator ();
	}

	void CheckAnimator(){
		float CurrentAnimationLength = GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).length;
		float CurrentAnimationTime = GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime;
		
		//CheckAnimator = GetComponent<Animator> ();
		//GetComponent<Animator> ().GetCurrentAnimatorSateInfo ("Buse", true);
		//GetComponent<Animator> ().SetBool ("IsRunningRight", true);
		//if (this.CheckAnimator.GetCurrentAnimatorSateInfo (0).IsName ("Bush_fire")) {

		if (Input.GetKeyDown(KeyCode.Space))
		{
			//Debug.Log("Space key was pressed.");
			GetComponent<Animator> ().SetBool ("IsOnFire", true);
		}

		if (Input.GetKeyDown(KeyCode.G))
		{
			//Debug.Log("G key was pressed.");
			GetComponent<Animator> ().SetBool ("IsSliced", true);
		}


		if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Bush_fire") == true) {
			//Debug.Log ("Bush_fire " + GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Bush_fire"));
			//Debug.Log (CurrentAnimationLength);
			//Debug.Log (CurrentAnimationTime);
			if (CurrentAnimationTime >= CurrentAnimationLength) {
				//Debug.Log ("Bush_fire has finished");
				GetComponent<Animator> ().SetBool ("IsOnFire", false);
				Destroy (gameObject);

			}
		}

		//Debug.Log("Bush_0 " + GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Bush_0"));
		//Debug.Log("Bush_idle " + GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Bush_idle"));
		//Debug.Log("Bush_fire " + GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Bush_fire"));
		//Debug.Log("Bush_fire " + GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Bush_fire"));
		//Debug.Log("Bush_fire " + GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).length);
		//Debug.Log("Bush_fire " + GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime);
		//Debug.Log("Bush_slice " + GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Bush_fire"));
		

	}
		
}
