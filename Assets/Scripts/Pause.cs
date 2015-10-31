using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	UIManager uiManager;

	void Start() {
		uiManager = GameObject.FindGameObjectWithTag ("UIManager")
			.GetComponent<UIManager> ();
	}

	public void OnClickResumeBtn() {
		uiManager.ClosePauseMenu ();
	}

	public void OnClickRestartBtn() {
		Application.LoadLevel (1);
	}

	public void OnClickMainMenuBtn() {
		Application.LoadLevel (0);
	}
}
