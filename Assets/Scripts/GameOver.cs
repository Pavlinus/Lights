using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public void OnTryAgainBtnClick() {
		Application.LoadLevel (1);
	}
	
	public void OnMainMenuBtnClick() {
		Application.LoadLevel (0);
	}
}
