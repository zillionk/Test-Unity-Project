using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public GameObject currentCheckpoint;
	private playerController player;
	public GameObject[] blocks;
	private bool flyingUp;

	// Use this for initialization
	void Start () {
		blocks = new GameObject[25];
		player = FindObjectOfType<playerController>();
		blocks =  GameObject.FindGameObjectsWithTag("Block");
		//Debug.Log (blocks[0]);
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<Rigidbody2D> ().velocity.y > 0) {
			flyingUp = true;
		} else if (player.GetComponent<Rigidbody2D> ().velocity.y <= 0) {
			flyingUp = false;
		}
	}
	void FixedUpdate () {
		foreach (GameObject block in blocks) {
			if(block.GetComponent<Collider2D>() != null) {
				block.GetComponent<Collider2D>().isTrigger = flyingUp;
			}
		}
	}

	public void respawnPlayer () {
		Debug.Log ("played respawn.");
		player.transform.position = currentCheckpoint.transform.position;
	}
}
