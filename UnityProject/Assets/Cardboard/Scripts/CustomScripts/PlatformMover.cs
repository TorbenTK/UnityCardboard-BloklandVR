// https://www.youtube.com/watch?v=AfwmRYQRsbg
// Modified version of the link above

using UnityEngine;
using System.Collections;

public class PlatformMover : MonoBehaviour {

	// Variables

	public Transform movingPlatform;
	public Transform pos1;
	public Transform pos2;
	public Vector3 newPos;
	private int currentState = 1;
	public float smooth;
	public float resetTime;
	public bool turnedOn = true;

	public Color _color;
	
	private Vector3 newPosition;

	public float startCooldown;


	// Use this for initialization
	void Start () {
		if (startCooldown != 0.0f) {
			StartCoroutine("StartAfterTime");
		}
		else if (turnedOn) {
			ChangeTarget ();
		}
	}

	void Awake () {
		GetComponent<Renderer> ().material.color = _color;
	}

	// Update is called per frame.
	// We apply force, that is why we grab FixedUpdate()
	void FixedUpdate (){
		if (turnedOn) {
			movingPlatform.position = Vector3.Lerp (movingPlatform.position, newPos, smooth * Time.deltaTime);
		}
	}

	void ChangeTarget(){
		if (currentState == 1) {
			currentState = 2;
			newPos = pos2.position;
		} else if (currentState == 2) {
			currentState = 1;
			newPos = pos1.position;
		}
		Invoke ("ChangeTarget", resetTime);
	}

	void TurnOn(){
		turnedOn = true;
		ChangeTarget ();
	}

	void StartAfterTime(){
		Invoke ("TurnOn", startCooldown);
	}
}
