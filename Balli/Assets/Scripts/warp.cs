using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warp : MonoBehaviour {
	
	public float RotationolSpeed = 5;
//	public ParticleSystem Partic;

	// Use this for initialization
	void Start () {
		//RotationolSpeed = Time.deltaTime + 1;
		//set the sorting layer of the particle system
		//Partic.renderer.sortingLayerName = "foreground";
		//Partic.renderer.sortingOrder = 2;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate (new Vector3 (0f, 0f, 5f) );
		transform.Rotate  (new Vector3 (0f, 0f, RotationolSpeed*Time.deltaTime) );	

	
	}
}
