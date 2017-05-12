using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

	public float speed;
	public Rigidbody rb;
	public float dashspeed;
	public bool dash;
	public bool freeze;
	public float dashcooldowntime;
	public bool dashcooldown;
	public bool freezecooldown;
	public float freezecooldowntime;
	public GameObject cube;
	public Material white;
	public Material black;

	// Use this for initialization
	void Start () {
		speed = 12;
		dashspeed = 1;
		dashcooldowntime = 5;
		dashcooldown = false;
		rb = GetComponent<Rigidbody> ();


	}

	// Update is called once per frame
	void Update () {
		if (dashcooldown == true && dashcooldowntime > 0) {
			dashcooldowntime -= Time.deltaTime;
			Debug.Log (dashcooldowntime);
		} else {
			dashcooldowntime = 5;
			dashcooldown = false;
		}

		if(Input.GetKey(KeyCode.Space) && dashcooldown == false){
			dash = true;
			dashcooldown = true;
		};

		if (dash) {
			dashspeed = 20;
			dash = false;
		} else
			dashspeed = 1;

		if (freezecooldown == true && freezecooldowntime > 0) {
			freezecooldowntime -= Time.deltaTime;
			Debug.Log (freezecooldowntime);
		} else {
			freezecooldowntime = 10;
			freezecooldown = false;
		}

		if(Input.GetKey(KeyCode.F) && freezecooldown == false){
			freeze = true;
			freezecooldown = true;
		};
		if (freeze) {
			StartCoroutine ("froze");
		}

	}

	void FixedUpdate(){

		if(Input.GetKey(KeyCode.W)){
			rb.AddForce (0, 0, speed * dashspeed);
		};

		if(Input.GetKey(KeyCode.S)){
			rb.AddForce (0, 0, -1 * speed * dashspeed);
		};

		if(Input.GetKey(KeyCode.A)){
			rb.AddForce (-1*speed * dashspeed, 0, 0);
		};

		if(Input.GetKey(KeyCode.D)){
			rb.AddForce (speed * dashspeed, 0, 0);
		};
	}

	IEnumerator froze(){
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		rb.isKinematic = true;
		cube.GetComponent<Renderer> ().material = white;
		yield return new WaitForSeconds (2);
		rb.isKinematic = false;
		freeze = false;
		cube.GetComponent<Renderer> ().material = black;
	}
}
