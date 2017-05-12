using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour {

	public GameObject gamemanager;
	public GameObject cubeprefab;
	public GameObject cube2prefab;
	public GameObject player1;
	public GameObject player2;
	public bool p2dead;
	public bool p1dead;
	public
	void Update(){
		if (!gamemanager.GetComponent<GameManager> ().gameover && player1 == null && p1dead == true) {
			p1dead = false;
			Invoke ("Spawnp1", 2f);
		}
		if (!gamemanager.GetComponent<GameManager> ().gameover && player2 == null && p2dead == true) {
			p2dead = false;
			Invoke ("Spawnp2", 2f);
		}
		
	}


	void OnCollisionEnter(Collision collision){
		Destroy (collision.gameObject);
		if (collision.gameObject == player1) {
			p1dead = true;
		} else if (collision.gameObject == player2) {
			p2dead = true;
		}
		gamemanager.GetComponent<GameManager> ().updatescore = true;
	}

	void Spawnp1(){
		player1 = Instantiate (cubeprefab, new Vector3 (0.19f, 2.25f, -0.151f), Quaternion.identity, GameObject.Find ("Platform").transform);
		player1.transform.position = new Vector3 (0.19f, 2.25f, -0.151f);
	}

	void Spawnp2(){
		player2 = Instantiate (cube2prefab, new Vector3 (-0.19f, 2.25f, -0.151f), Quaternion.identity, GameObject.Find ("Platform").transform);
		player2.transform.position = new Vector3 (-1f, 2.25f, -0.151f);
	}
}
