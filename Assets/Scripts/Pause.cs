using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pause : MonoBehaviour {
	//the game object of the pause menu
	public GameObject pauseui;

	private bool paused = false;
	
	void Start () {
	//check if game is paused
		pauseui.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Pause")) {
			paused = !paused;
		}
		if (paused) {
			pauseui.SetActive (true);
			Time.timeScale = 0;
		}
		if (!paused) {
			pauseui.SetActive (false);
			Time.timeScale = 1;
		}
	}

	//function for when the restart button is pressed
	public void Resume(){
		paused = false;
	}

	//function for when the restart button is pressed
	public void Restart(){
		Application.LoadLevel (Application.loadedLevel);
		ScoreManager.score = 0;
	}

	public void mainmenu(){
		Application.LoadLevel("Main Menu");
	}

	public void quit(){
		Application.Quit ();
	}
}
