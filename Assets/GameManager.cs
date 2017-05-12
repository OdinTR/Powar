using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	
	public GUIText gameovertext;
	public GameObject scorep1;
	public GameObject scorep2;
	public int score1;
	public int score2;
	public bool gameover;
	public bool updatescore;
	public bool p1wins;
	public bool p2wins;

	// Use this for initialization
	void Start () {

		gameovertext.text = "";
		scorep1.GetComponent<UnityEngine.UI.Text> ().text = "";
		scorep2.GetComponent<UnityEngine.UI.Text> ().text = "";
		score1 = 0;
		score2 = 0;
		
	}

	// Update is called once per frame
	void Update () {
		if (updatescore) {
			if (GameObject.FindGameObjectWithTag ("player1") != null) {
				score1 += 1;
				scorep1.GetComponent<UnityEngine.UI.Text> ().text = score1.ToString();
				updatescore = false;
			} else if (GameObject.FindGameObjectWithTag ("player2") != null) {
				score2 += 1;
				scorep2.GetComponent<UnityEngine.UI.Text> ().text = score2.ToString();
				updatescore = false;
			} else if (score1 == 3) {
				p1wins = true;
				gameovertext.text = "Game Over!";
				updatescore = false;
			} else if (score2 == 3) {
				p2wins = true;
				gameovertext.text = "Game Over!";
				updatescore = false;
			}

		}
		
	}
}
