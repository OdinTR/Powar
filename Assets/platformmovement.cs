using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformmovement : MonoBehaviour {

	public float y0;
	public float amplitude;
	public float speed;

	// Use this for initialization
	void Start () {
		y0 = transform.position.y;
		speed = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 oldp = transform.position;
		oldp.y = y0 + amplitude * Mathf.Sin (speed * Time.time);
		transform.position = oldp;

	}
}
