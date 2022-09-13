using UnityEngine;
using System.Collections;

public class file2 : MonoBehaviour {

	public GameObject[] files;
	public static int havefile2, n , fil;
	//position of the player
	public Transform target;

	void Start () {
		target = GameObject.Find ("Player").transform;
	}

	void OnTriggerEnter2D(Collider2D co){
		if (co.name == "Player") {
			Destroy(gameObject);
			Debug.Log (havefile2);
			if(n == 5){
				Inventory.AddItem(5);
				file.havefile = 5;
			}else{
				Inventory.AddItem(havefile2);
				file.havefile += havefile2;
			}
		}
	}
}
