using UnityEngine;
using System.Collections;

public class DetectorManager : MonoBehaviour {

	// Variables
	// DestroyObjectUponEnter
	// ResetLever
	// ResetDoor
	public bool DestroyObjectUponEnter;
	public LeverManager _lever;
	public DoorManager _door;

	public ToggleLightColor TLCColor1;
	public ToggleLightColor TLCColor2;
	public ToggleLightColor TLCColor3;

	public ProducerManager _producer;

	void OnTriggerEnter(Collider col){

		// Destroy object?
		if (DestroyObjectUponEnter) {
			Destroy (col.gameObject);
		}

		// Reset lever?
		try{
			_lever.StartCoroutine("Reset");
		}
		catch{}

		// Open/close door?
		try{
			_door.StartCoroutine("MoveDirection");
		}
		catch{}

		// Change nearby light(s)?
		try{TLCColor1.StartCoroutine("switchColor");}catch{}
		try{TLCColor2.StartCoroutine("switchColor");}catch{}
		try{TLCColor3.StartCoroutine("switchColor");}catch{}

		// Stop production of Producer?
		try {_producer.stopProduction = true;} catch {}
		
	}

	void OnTriggerExit(){
		// Change nearby light(s)?
		try{TLCColor1.StartCoroutine("switchColor");}catch{}
		try{TLCColor2.StartCoroutine("switchColor");}catch{}
		try{TLCColor3.StartCoroutine("switchColor");}catch{}
	}
}
