using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	
	public GameObject gameovertext;
	public GameObject playerwinstext;
	public GameObject optionstext;
	public GameObject gameoverpanel;
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

		gameoverpanel.SetActive (false);
		scorep1.GetComponent<UnityEngine.UI.Text> ().text = "";
		scorep2.GetComponent<UnityEngine.UI.Text> ().text = "";
		score1 = 0;
		score2 = 0;
		Time.timeScale = 1;
		
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
			}

		}

		if (score1 == 3) {
			p1wins = true;
			gameover = true;
			updatescore = false;
		} else if (score2 == 3) {
			p2wins = true;
			gameover = true;
			updatescore = false;
		}


		if (gameover) {
			Time.timeScale = 0;
			gameoverpanel.SetActive (true);
			gameovertext.GetComponent<UnityEngine.UI.Text> ().text = "Game Over!";
			if (p1wins == true) {
				playerwinstext.GetComponent<UnityEngine.UI.Text> ().text = "Player1 Wins!";
				gameoverpanel.GetComponent<CanvasRenderer> ().SetColor(new Color32 (255, 0, 0,150));
			} else if (p2wins == true) {
				playerwinstext.GetComponent<UnityEngine.UI.Text> ().text = "Player2 Wins!";
				gameoverpanel.GetComponent<CanvasRenderer> ().SetColor(new Color32 (0, 0, 255,150));
			}
			optionstext.GetComponent<UnityEngine.UI.Text> ().text = "Press 'ESC' to get back to menu or 'R' for a Restart!";


			if (Input.GetKey (KeyCode.Escape)) {
				UnityEngine.SceneManagement.SceneManager.LoadScene (0);
			} else if (Input.GetKey (KeyCode.R)) {
				UnityEngine.SceneManagement.SceneManager.LoadScene (1);
			}
		}
		
	}
}
