// https://www.youtube.com/watch?v=Mzt1rEEdeOI

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class LeverManagerOLD : MonoBehaviour {
	
	// Variables
	private Animator switchAnim;
	public bool stateOn = false;
	public bool allowTurnOff = true; // Allow the lever to be switched off
	public DoorManager door;
	private LeverAreaDetection lad;

	// Use this for initialization
	void Awake () {
		switchAnim = GetComponent<Animator> ();
		lad = GetComponentInChildren<LeverAreaDetection> ();
	}
	
	// Either turn lever on or off
	public void FlipState()
	{
		if (lad.isInArea) {

			if (!stateOn) {
				switchAnim.SetTrigger ("TurnOn");
				//typer.StartCoroutine("TypeIn");
				stateOn = true;
				door.StartCoroutine ("MoveDirection");
			} else {
				if (allowTurnOff) {
					switchAnim.SetTrigger ("TurnOff");
					stateOn = false;
					door.StartCoroutine ("MoveDirection");
				}
			}
		}
	}
}
