using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour {
	public Transform smoke;
	public float DustSizeReducation;
	public float DustSizeDestroy=1;
	public float DestroyTime;

	public float BounceLow;
	public float BounceHigh;
	public float PosX = -0.03f;
	public float PosY = 0.12f;
	public float RotationolSpeed;
	public float MovementSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CreateFire();
	}
	void CreateFire(){

		float Bounce = Random.Range (BounceLow, BounceHigh);
		Transform smokeee = Instantiate (smoke, new Vector3 (this.gameObject.transform.position.x + Bounce + PosX, this.gameObject.transform.position.y + Bounce + PosY, 0f), Quaternion.identity);
		smokeee.gameObject.AddComponent<Rigidbody2D> ();
		//smokeee.transform.localScale -= new Vector3 (DustSizeReducation, DustSizeReducation, 0f);
		smokeee.transform.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0;
		smokeee.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * MovementSpeed);
		/*smokeee.transform.Rotate  (new Vector3 (0f, 0f, RotationolSpeed*Time.deltaTime) );
		if (DestroyTime <= 0 || transform.localScale.x <= DustSizeDestroy) {
			Destroy(smokeee.gameObject);

		}
		*/
	}
}
