using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
	
	public LevelManager levelMgn;
	
	//finding levelmanager for player to respawn
	void Start() {
		levelMgn = FindObjectOfType<LevelManager> ();
	}
	
	
	// Update is called once per frame
	void Update () {
		
	}
	
}