﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Startgame()
    {
        Application.LoadLevel("SampleScene");
    }
    public void OnClickExit()
    {
        Startgame();
    }
}
