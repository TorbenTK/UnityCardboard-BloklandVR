using UnityEngine;
using System.Collections;

public class HazardAreaManager : MonoBehaviour {

	// Variables
	private GameManager gm;
	private GameObject _player;

	// Use this for initialization
	void Start () {
		_player = GameObject.Find ("Player");
		gm = GameObject.Find ("StaticGameData").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider col) {
		if (col.tag == _player.tag)
		{
			gm.StartCoroutine("RespawnPlayer");
		}
	}
}
