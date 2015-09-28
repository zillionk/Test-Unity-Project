using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	Rigidbody2D r_body;
	public float moveSpeed;
	public float jumpHeight;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;

	private bool grounded;
	private Animator anim;

	// Use this for initialization
	void Start () {
		r_body = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && grounded) {
			r_body.velocity = new Vector2(r_body.velocity.x,jumpHeight);
		}
		if (Input.GetKey (KeyCode.D) ) {
			r_body.velocity = new Vector2(moveSpeed,r_body.velocity.y);

		}
		if (Input.GetKey (KeyCode.A)) {
			r_body.velocity = new Vector2(-moveSpeed,r_body.velocity.y);
		}

		anim.SetFloat ("Speed", Mathf.Abs (r_body.velocity.x));
		anim.SetBool ("Grounded", grounded);
		if (r_body.velocity.x > 0)
			transform.localScale = new Vector3 (1f, 1f, 1f);
		else if (r_body.velocity.x < 0)
			transform.localScale = new Vector3 (-1f, 1f, 1f);

	}
}
