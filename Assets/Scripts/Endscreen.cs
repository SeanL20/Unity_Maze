using UnityEngine;
using System.Collections;

public class Endscreen : MonoBehaviour {

	public void mainmenu(){
		Application.LoadLevel("Main Menu");
	}

	public void retry(){
		Application.LoadLevel ("maze");
	}
	
	public void quit(){
		Application.Quit ();
	}
}
