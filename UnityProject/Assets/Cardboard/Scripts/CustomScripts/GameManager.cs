using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Variables
	private Vector3 respawnpos;
	private GameObject _player;

	public bool canTeleport;

	// Constructor
	public GameManager (){

	}

	void Start(){
		_player = GameObject.Find ("Player");
		ChangeRespawnPosition ();
	}

	void Update(){
		// Debug: PC only
		if (Input.GetKey (KeyCode.R)) {
			RespawnPlayer();
		}

		ObjectInFrontChecker ();
	}

	// Change player respawn position
	// Checkpoints and game events, for example, call this function
	void ChangeRespawnPosition(){
		respawnpos = _player.transform.position;
		
		Debug.Log (respawnpos);
	}

	// Respawn player upon death
	void RespawnPlayer(){
			_player.transform.position = respawnpos;
	}

	void ObjectInFrontChecker() {
	}


}