using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public static int amount = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (amount < 0) {
			amount = 0;
		} else if (amount > 5) {
			amount = 5;
		}
	}

	//adding the file into inventory when player cross the file
	public static void AddItem(int count){
		amount += count;
		ScoreManager.AddScore (count);
		Debug.Log (amount);
	}

	//remove file when enemy hit player
	public static void RemoveItem(int count){
		amount -= count;
		ScoreManager.RemovScore (count);
		Debug.Log (amount);
	}
}