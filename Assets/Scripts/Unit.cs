using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	public LevelManager lvlmgn;
	public Transform target, target2;
	float Speed = 2;
	Vector3[] path;
	int targetIndex;
	public Vector3 targetOldPosition;
	public static int files;
	
	// Use this for initialization
	void Start () {
		PathRequestManager.RequestPath (transform.position, target.position, OnPathFound);
	}
	
	void Update(){
		PathRequestManager.RequestPath (transform.position, target.position, OnPathFound);
		files = file.havefile;
	}
	
	public void OnPathFound(Vector3[] newPath, bool pathSuccessful){
		if (pathSuccessful) {
			path = newPath;
			StopCoroutine("FollowPath");
			StartCoroutine("FollowPath");
		}
	}

	IEnumerator FollowPath(){
		Vector3 currentWaypoint = path [0];
		
		while (true) {
			if(transform.position == currentWaypoint){
				targetIndex++;
				if (targetIndex >= path.Length){
					targetIndex = 0;
					path = new Vector3[0];
					yield break;
				}
				currentWaypoint = path[targetIndex];
			}
			transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, Speed * Time.deltaTime);
			yield return null;
		}
	}
	
	// Update is called once per frame
	public void OnDrawGizmos () {
		if (path != null) {
			for (int i = targetIndex; i < path.Length; i++){
				Gizmos.color = Color.black;
				Gizmos.DrawCube(path[i], Vector3.one);
				if (i == targetIndex){
					Gizmos.DrawLine(transform.position, path[i]);
				}else{
					Gizmos.DrawLine(path[i-1], path[i]);
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D co) {
		if (co.name == "Player") {
			lvlmgn.RespawnPlayer ();
			transform.position = new Vector2(0, 5);
			target2.position = new Vector2 (0, 5);
			Enem2.current = 0;
			Inventory.RemoveItem(files);
			if (files < 5){
				file2.havefile2 = files;
			}
			file.havefile -= file.havefile;
		}
	}
}
