using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AImovement : MonoBehaviour {

	public GameObject player;
	public float speed;
	public Vector3 playerorigin;
	public Vector3 AIorigin;
	public float targetdistance;
	public float distance;
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
	public bool attackstate;
	public GameObject cube;
	public Material Frost;
	public Material red;
	public Material blu;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		speed = 0.3f;
		player = GameObject.FindGameObjectWithTag ("player1");
		if (player != null) {
			playerorigin = player.transform.position;
		}
		AIorigin = transform.position;
		distance = 3f;
		dashspeed = 1;
		attackstate = true;
		dashpng.enabled = false;
		dashcooldowntime = 2;
		dashcooldown = true;
		freezepng.enabled = false;
		freezecooldowntime = 10;
		freezecooldown = false;
	}

	void Update(){
		if (player == null) {
			player = GameObject.FindGameObjectWithTag ("player1");
		} else {
			playerorigin = player.transform.position;
			AIorigin = transform.position;
			targetdistance = Vector3.Distance (playerorigin, AIorigin);
		}

		if(AIorigin.x > 6 && freezecooldown == false || AIorigin.x < -6 && freezecooldown == false){
			freeze = true;
			freezecooldown = true;
			freezepng.enabled = true;

		};
		if(AIorigin.z > 4 && freezecooldown == false || AIorigin.z < -8 && freezecooldown == false){
			freeze = true;
			freezecooldown = true;
			freezepng.enabled = true;

		};
		if (freeze) {
			StartCoroutine ("froze");
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (dashcooldown == true && dashcooldowntime > 0) {
			dashcooldowntime -= Time.deltaTime;
			dashpng.fillAmount = (dashcooldowntime / 5f);
		} else {
			dashcooldowntime = 5;
			dashcooldown = false;
			dashpng.enabled = false;
		}

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

		if (player != null) {
			if (targetdistance > distance) {
				if (playerorigin.x - AIorigin.x > 0) {
					rb.AddForce (speed * dashspeed, 0, 0, ForceMode.VelocityChange);
				} else
					rb.AddForce (dashspeed * speed * -1, 0, 0, ForceMode.VelocityChange);
				if (playerorigin.z - AIorigin.z > 0) {
					rb.AddForce (0, 0, speed * dashspeed, ForceMode.VelocityChange);
				} else
					rb.AddForce (0, 0, dashspeed * speed * -1, ForceMode.VelocityChange);
			} else if (targetdistance < distance && dashcooldown == false) {
				dash = true;
				dashcooldown = true;
				dashpng.enabled = true;
								
			} else {
				if (Random.value >= 0.2f) {
					attackstate = true;
				} else
					attackstate = false;
				if (playerorigin.x - AIorigin.x > 0 && attackstate == true) {
					rb.AddForce (speed * dashspeed, 0, 0, ForceMode.VelocityChange);
				} else if (playerorigin.x - AIorigin.x > 0 && attackstate == false) {
					rb.AddForce (-1 * speed * dashspeed, 0, 0, ForceMode.VelocityChange);
				} else if (playerorigin.x - AIorigin.x < 0 && attackstate == true)
					rb.AddForce (dashspeed * speed * -1, 0, 0, ForceMode.VelocityChange);
				  else if (playerorigin.x - AIorigin.x < 0 && attackstate == false) {
					rb.AddForce (dashspeed * speed, 0, 0, ForceMode.VelocityChange);
				}
				if (playerorigin.z - AIorigin.z > 0 && attackstate == true) {
					rb.AddForce (0, 0, speed * dashspeed, ForceMode.VelocityChange);
				} else if (playerorigin.z - AIorigin.z > 0 && attackstate == false) {
					rb.AddForce (0, 0, dashspeed * speed * -1, ForceMode.VelocityChange);
				} else if (playerorigin.z - AIorigin.z < 0 && attackstate == true) {
					rb.AddForce (0, 0, dashspeed * speed * -1, ForceMode.VelocityChange);
				} else if (playerorigin.z - AIorigin.z < 0 && attackstate == false) {
					rb.AddForce (0, 0, dashspeed * speed, ForceMode.VelocityChange);
				}
			}
		}
		
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
