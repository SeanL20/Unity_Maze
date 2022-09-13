using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public GameObject currentCheckPoint, obj;
	private Movement player;
	private Unit enem;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Movement> ();
	}

	//respawning player
	public void RespawnPlayer(){
		if (file.havefile > 0) {
			spawn();
			Debug.Log("spawned");
		}
		Debug.Log ("Player Respawn");
		player.dest = new Vector2 (0f, -5f);
		player.transform.position = currentCheckPoint.transform.position;
	}

	public void spawn(){
		Instantiate (obj, player.transform.position, Quaternion.identity);
	}
}