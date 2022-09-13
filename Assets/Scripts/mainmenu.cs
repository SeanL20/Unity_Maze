using UnityEngine;
using System.Collections;

public class mainmenu : MonoBehaviour {

	public void Newgame(){
		Application.LoadLevel ("maze");
	}
		
	public void quitgame(){
		Application.Quit ();
	}
}
