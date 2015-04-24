using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class TeleportByLook : MonoBehaviour {
	
	private CardboardHead head;
	private Vector3 pos;
	private GameObject _player;

	public bool teleportBelow = false;
	public bool isCheckpoint = false;

	private GameManager gm;

	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
		pos = transform.localPosition;
		gm = GameObject.Find ("StaticGameData").GetComponent<GameManager>();
	}
	
	void Update() {

		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		if (isCheckpoint) {
			GetComponent<Renderer> ().material.color = isLookedAt ? Color.blue : Color.red;
		} else {
			GetComponent<Renderer> ().material.color = isLookedAt ? Color.green : Color.red;
		}

		/*
		if ((Cardboard.SDK.CardboardTriggered)) {

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
			if(Physics.Raycast(ray, out hit, Mathf.Infinity))
			{
				if(hit.collider.tag == "Platform")
				{
					Debug.Log("Platform"); 
				}
			}
		}*/

		if ((Cardboard.SDK.CardboardTriggered && isLookedAt)) 
		{

			//Debug.Log (GetComponent<Collider>());
			// Teleport player
			_player = GameObject.Find ("Player");
			_player.transform.position = new Vector3(pos.x, pos.y+(teleportBelow ? -1 : 1), pos.z);

			if (isCheckpoint)
			{
				gm.StartCoroutine("ChangeRespawnPosition");
			}
		}
	}
	
}