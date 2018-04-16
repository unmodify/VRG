using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter(Collision theCol){
		if (theCol.gameObject.name.Contains ("Pillar")) {
			Debug.Log ("Right Hand:onCollisionEnter");
		}

	}

	// Update is called once per frame
	void Update () {
		
	}
}
