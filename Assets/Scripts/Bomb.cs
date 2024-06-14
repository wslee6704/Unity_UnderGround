using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    GameObject Player;
	// Use this for initialization
	void Start () {
        Player = GameObject.Find("player_ui");
	}
	
	// Update is called once per frame
	void Update () {
		if(Player.gameObject.transform.position.y - this.gameObject.transform.position.y <= 10)
        {

        }
	}
}
