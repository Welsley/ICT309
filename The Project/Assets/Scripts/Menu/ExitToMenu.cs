﻿using UnityEngine;
using System.Collections;

public class ExitToMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Screen.lockCursor = false;
			Application.LoadLevel(0);
		}
	}
}
