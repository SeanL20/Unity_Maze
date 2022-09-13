using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public LevelManager lvlmgn;
	public float StartTime = 60;
	public Text Timeleft;

	// Use this for initialization
	void Start () {
		Timeleft = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		//counting down
		StartTime -= Time.deltaTime;
		if (StartTime <= 0) {
			if (ScoreManager.score == 5){
				Application.LoadLevel ("WinScreen");
			} else{
				Application.LoadLevel ("LoseScreen");
			}
		}
		Timeleft.text = "Time: " + Mathf.Round (StartTime);
	}
}
