// https://www.youtube.com/watch?v=Mzt1rEEdeOI

using UnityEngine;
using System.Collections;

public class CanvasManager : MonoBehaviour {

	// Variables
	private Typer typer;
	//private Animator menuAnim;
	private bool menuOn = false;
	public bool autoRun = false;

	// Use this for initialization
	void Awake () {
		typer = GetComponentInChildren<Typer> ();
		//menuAnim = GetComponent<Animator> ();
	}

	// Start function without player input.
	void Start()
	{
		if (autoRun == true) {
			try{
				typer.StartCoroutine ("TypeIn");
			}catch{}
			menuOn = true;
		}
	}

	// Calls FadeIn or FadeOut from Animation depending on boolean
	public void BeginMenu()
	{
		if (!menuOn) {
			//menuAnim.SetTrigger("FadeIn");
			try{
				typer.StartCoroutine ("TypeIn");
			}catch{}
			menuOn = true;

		} 
		/*else {
			//menuAnim.SetTrigger("FadeOut");
			typer.StartCoroutine("TypeOff");
			menuOn = false;
		}*/
	}
}
