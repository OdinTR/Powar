using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour {

	public float speed;
	public Rigidbody rb;
	public float dashspeed;
	public bool dash;
	public bool freeze;
	public Image dashpng;
	public Image freezepng;
	public float dashcooldowntime;
	public bool dashcooldown;
	public bool freezecooldown;
	public float freezecooldowntime;
	public GameObject cube;
	public Material Frost;
	public Material red;
	public Material blu;

	// Use this for initialization
	void Start () {
		speed = 0.3f;
		dashspeed = 1;
		dashpng.enabled = false;
		dashcooldowntime = 5;
		dashcooldown = false;
		freezepng.enabled = false;
		freezecooldowntime = 10;
		freezecooldown = false;
		rb = GetComponent<Rigidbody> ();



	}

	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.F) && freezecooldown == false){
			freeze = true;
			freezecooldown = true;
			freezepng.enabled = true;
			
		};
		if (freeze) {
			StartCoroutine ("froze");
		}

	}

	void FixedUpdate(){
		
		if (dashcooldown == true && dashcooldowntime > 0) {
			dashcooldowntime -= Time.deltaTime;
			dashpng.fillAmount = (dashcooldowntime / 5f);
		} else {
			dashcooldowntime = 5;
			dashcooldown = false;
			dashpng.enabled = false;
		}

		if(Input.GetKey(KeyCode.Space) && dashcooldown == false){
			dash = true;
			dashcooldown = true;
			dashpng.enabled = true;
		};

		if (dash) {
			dashspeed = 40;
			dash = false;
		} else
			dashspeed = 1;

		if (freezecooldown == true && freezecooldowntime > 0) {
			freezecooldowntime -= Time.deltaTime;
			freezepng.fillAmount = (freezecooldowntime / 10f);
		} else {
			freezecooldowntime = 10;
			freezecooldown = false;
			freezepng.enabled = false;
		}

		if(Input.GetKey(KeyCode.W)){
			rb.AddForce (0, 0, speed * dashspeed,ForceMode.VelocityChange);
		};

		if(Input.GetKey(KeyCode.S)){
			rb.AddForce (0, 0, -1 * speed * dashspeed,ForceMode.VelocityChange);
		};

		if(Input.GetKey(KeyCode.A)){
			rb.AddForce (-1*speed * dashspeed, 0, 0,ForceMode.VelocityChange);
		};

		if(Input.GetKey(KeyCode.D)){
			rb.AddForce (speed * dashspeed, 0, 0,ForceMode.VelocityChange);
		};
	}

	IEnumerator froze(){
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		rb.isKinematic = true;
		cube.GetComponent<Renderer> ().material = Frost;
		yield return new WaitForSeconds (2);
		rb.isKinematic = false;
		freeze = false;
		if (cube.tag == "player1") {
			cube.GetComponent<Renderer> ().material = red;
		} else if (cube.tag == "player2") {
			cube.GetComponent<Renderer> ().material = blu;
		}
	}
}
