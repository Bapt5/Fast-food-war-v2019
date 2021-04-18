﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			
			if (PlayerPrefs.GetInt ("Tutorial") == 0) {
					PlayerPrefs.SetInt ("TS", 4);
			}

			PlayerPrefs.SetInt("Health", PlayerPrefs.GetInt("Health")+1);
		}
		Destroy (gameObject);
	}
}
