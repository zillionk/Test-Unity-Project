using UnityEngine;
using System.Collections;

public class knight_controller_1 : MonoBehaviour {
	Rigidbody2D r_body;
	Animator anim;
	public float jump_force;
	public float move_force;
	public Transform spawn;

	// Use this for initialization
	void Start () {
		r_body = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		transform.position = spawn.position;
	}
	
	// Update is called once per frame
	void Update () {
		//get space bar for jump
		if(Input.GetButtonDown("Jump")) {
			//add jump force 
			r_body.AddForce(new Vector2(0,jump_force));
			//play jump animation
		}
		if(transform.position.y < -20){
			//respawn
			transform.position = spawn.position;
		}
	}

	void FixedUpdate () {
		//get left/right and a/d to movement
		float h = Input.GetAxis("Horizontal");
		float speed = 10;
		//add force horizontally
		r_body.AddForce (new Vector2(move_force * h,0));
		anim.SetFloat ("Speed", Mathf.Abs (h));
	}
}
