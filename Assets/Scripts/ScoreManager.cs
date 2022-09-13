using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	//score
	public static int score;
	
	Text text;
	
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (score < 0) {
			score = 0;
		}
		text.text = score + " of 5 file";
	}
	
	public static void AddScore(int addtoscore){
		score += addtoscore;
	}

	public static void RemovScore(int Score){
		score -= Score;
	}
}
