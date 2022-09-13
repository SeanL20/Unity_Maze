using UnityEngine;
using System.Collections;

public class Enem2 : MonoBehaviour {
	//waypoints
	public Transform[] waypoints;
	public static int current = 0;
	float speed = 2f;

	//time to wait before the enemy start moving
	public float StartTime = 0;
	public LevelManager lvlmgn;
	public static int files1;
	public Transform target;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		StartTime += Time.deltaTime;
		if (StartTime >= 10) {
			if (transform.position != waypoints [current].position) {
				Vector2 p = Vector2.MoveTowards (transform.position, waypoints [current].position, speed * Time.deltaTime);
				GetComponent<Rigidbody2D> ().MovePosition (p);
			}else{
				// Waypoint reached, select next one
				current = (current + 1) % waypoints.Length;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D co) {
		if (co.name == "Player") {
			lvlmgn.RespawnPlayer ();
			transform.position = new Vector2(0, 5);
			target.position = new Vector2 (0, 5);
			current = 0;
			Inventory.RemoveItem(file.havefile);
			Debug.Log(file.havefile);
			if (file.havefile < 5){
				file2.havefile2 = file.havefile;
			}
			file.havefile -= file.havefile;
		}
	}
}
