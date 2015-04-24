using UnityEngine;
using System.Collections;

public class HubManager : MonoBehaviour {

	// Variables
	private bool isMainMenuAvailable;
	private PartyManager pm;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Main menu functionalities
	// Buttons call these functionalities

	public void StartGame() {
		Application.LoadLevel ("Level1");
	}

	public void StopGame() {
		Application.Quit();
	}

	public void ChooseLevel1() {Application.LoadLevel ("Level1");}
	public void ChooseLevel2() {Application.LoadLevel ("Level2");}
	public void ChooseLevel3() {Application.LoadLevel ("Level3");}
	public void ChooseLevel4() {Application.LoadLevel ("LevelBonus");}
	
}
