// https://www.youtube.com/watch?v=Mzt1rEEdeOI

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class LeverManager : MonoBehaviour {
	
	// Variables
	private Animator switchAnim;
	public bool stateOn = false;
	public bool allowTurnOff = true; // Allow the lever to be switched off

	public float autoResetTime = 0.0f;

	public DoorManager door;
	public ProducerManager producer;
	public PlatformMover platform;
	public ToggleLightColor TLCColor1;
	public ToggleLightColor TLCColor2;

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

				// Door exists?
				try{
					door.StartCoroutine ("MoveDirection");
				} catch{}

				// Producer exists?
				try{
					producer.StartCoroutine("SpawnObject");
				} catch{}

				// Platform exists?
				try{
					platform.StartCoroutine("TurnOn");
				} catch{}

				// Change nearby light(s)?
				try{TLCColor1.StartCoroutine("switchColor");}catch{}
				try{TLCColor2.StartCoroutine("switchColor");}catch{}


				// Is the lever allowed to auto-reset itself?
				if (!allowTurnOff && autoResetTime > 0.0f)
				{
					Invoke ("Reset", autoResetTime);
				}

			} else {
				if (allowTurnOff) {
					switchAnim.SetTrigger ("TurnOff");
					stateOn = false;

					// Door exists?
					try{
						door.StartCoroutine ("MoveDirection");
					} catch{}
					
					// Producer exists?
					try{
						producer.StartCoroutine("SpawnObject");
					} catch{}

					// Change nearby light(s)?
					try{TLCColor1.StartCoroutine("switchColor");}catch{}
					try{TLCColor2.StartCoroutine("switchColor");}catch{}

				}
			}
		}
	}

	// Give external classes the option to reset the lever
	// This will not trigger any Coroutines of linked objects
	public void Reset(){
		switchAnim.SetTrigger ("TurnOff");
		stateOn = false;

		// Door exists?
		try{
			door.StartCoroutine ("MoveDirection");
		} catch{}
	}
}
