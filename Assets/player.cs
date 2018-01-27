using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	public Animator anim;

	private float inputH;

	private float inputV;

	private bool run;


	public float speed;

	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator> ();
		run = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.J)) {
			anim.Play ("Melee_Stab", -1, 0f);
		}
		if (Input.GetKeyDown (KeyCode.G)) {
			anim.Play ("GrenadeThrow", -1, 0f);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			anim.Play ("Standing_Jump", -1, 0f);
		}

		if (Input.GetKey (KeyCode.LeftShift)) {
			run = true;
			speed = 666f;
		} 
		else {
			run = false;
			speed = 100f;
		}
		inputH = Input.GetAxis ("Horizontal");
		inputV = Input.GetAxis ("Vertical");

		anim.SetFloat ("inputH", inputH);
		anim.SetFloat ("inputV", inputV);
		anim.SetBool ("run", run);
	}
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}
}
