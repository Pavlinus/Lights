using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	void Start () {
		Time.timeScale = 1f;
	}

	void Update () {
	
	}

	public void PlayButtonPressed() {
		Application.LoadLevel (1);
	}

	public void QuitButtonPressed() {
		Application.Quit ();
	}
}
