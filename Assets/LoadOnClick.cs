﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {

	public void LoadLevel(int level){
		SceneManager.LoadScene (level);
	}

	public void Quit(){
		Application.Quit ();
	}
}
