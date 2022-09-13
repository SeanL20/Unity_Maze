using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class file : MonoBehaviour {

	public static int havefile = 0;
	//position of the player
	public Transform target;
	//file and adding it to scores
	public int addtoscore = 1;

	void Start () {
		target = GameObject.Find("Player").transform;
	}

	void OnTriggerEnter2D(Collider2D co){
		if (co.name == "Player") {
			Destroy (gameObject);
			file2.n ++;
			Inventory.AddItem(1);
			havefile += 1;
		}
	}
}