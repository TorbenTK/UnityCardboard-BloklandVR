using UnityEngine;
using System.Collections;

public class PlatformObjectHolder : MonoBehaviour {

	private GazeInputModule gim;

	void OnTriggerEnter(Collider col){
		//col.transform.parent = gameObject.transform;
		if (col.tag == "Player") {
			col.transform.parent = gameObject.transform;

			// Fix to avoid cursor from scaling wrongly
			gim = GameObject.Find ("EventSystem").GetComponent<GazeInputModule>();
			gim.cursor.transform.localScale += new Vector3(0, 0, 0);

		} else if (col.tag == "ProducerObject") {
			col.transform.parent = gameObject.transform;
		}
	}

	void OnTriggerExit(Collider col){
		if (col.tag == "Player") {
			// Fix to avoid cursor from scaling wrongly
			gim = GameObject.Find ("EventSystem").GetComponent<GazeInputModule>();
			gim.cursor.transform.localScale += new Vector3(0, 0, 0);
		}

		col.transform.parent = null;
	}
}