using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class LeverByLook : MonoBehaviour {
	
	private CardboardHead head;
	private LeverManager lm;
	
	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
		lm = GetComponentInParent<LeverManager> ();
	}
	
	void Update() {
		
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		GetComponent<Renderer>().material.color = isLookedAt ? Color.green : Color.red;
		
		if ((Cardboard.SDK.CardboardTriggered && isLookedAt)) 
		{
			//Debug.Log (GetComponent<Collider>());
			lm.StartCoroutine("FlipState");
			
		}
	}
	
}