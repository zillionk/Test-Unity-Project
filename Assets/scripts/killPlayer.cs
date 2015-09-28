﻿using UnityEngine;
using System.Collections;

public class killPlayer : MonoBehaviour {
	public LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D (Collider2D other) {
		if (other.name == "knight") {
			levelManager.respawnPlayer();
		}
	}
}
