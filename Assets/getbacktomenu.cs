using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getbacktomenu : MonoBehaviour {

	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			Time.timeScale = 1;
			UnityEngine.SceneManagement.SceneManager.LoadScene (0);
		}
		
	}
}
