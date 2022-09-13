using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float speed = 0.4f;
	public Vector2 dest = Vector2.zero;
	
	// Use this for initialization
	void Start () {
		dest = transform.position;
	}
	
	void FixedUpdate () {
		//move closer to destination
		Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
		GetComponent<Rigidbody2D> ().MovePosition (p);
		
		//Input for movement
		if ((Vector2)transform.position == dest) {
			if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up)){
				dest = (Vector2)transform.position + Vector2.up;
			}
			if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right)){
				dest = (Vector2)transform.position + Vector2.right;
			}
			if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up)){
				dest = (Vector2)transform.position - Vector2.up;
			}
			if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right)){
				dest = (Vector2)transform.position - Vector2.right;
			}
		}
		
		//animation
		Vector2 dir = dest - (Vector2)transform.position;
		GetComponent<Animator> ().SetFloat ("DirX", dir.x);
		GetComponent<Animator> ().SetFloat ("DirY", dir.y);


	}
	
	bool valid(Vector2 dir) {
		//making the avatar look at the direction it's going
		Vector2 pos = transform.position;
		RaycastHit2D Hit = Physics2D.Linecast (pos + dir, pos);
		return (Hit.collider == GetComponent<Collider2D>());
	}

}