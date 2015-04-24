using UnityEngine;
using System.Collections;

public class CannonManager : MonoBehaviour {

	// Variables
	private Animator animator;
	public float resetTime;


	// Use this for initialization
	void Start () {
		FireCannon ();
	}

	void Awake () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void FireCannon() {
		animator.SetTrigger ("isFired");

		//Invoke ("CannonballSpawner");
		Invoke ("ResetCannon", 0.5f);
		Invoke ("FireCannon", resetTime);
	}
	/*
	void CannonballSpawner() {
		animator.ResetTrigger ("isFired");
	}*/

	void ResetCannon() {
		animator.ResetTrigger ("isFired");
	}
}
