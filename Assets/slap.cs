using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slap : MonoBehaviour {
	public float hitStrength = 20;
	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter(Collision theCol){
		if (theCol.gameObject.name.Contains ("Pillar")) {
			Debug.Log ("Right Hand:onCollisionEnter");
		}
		foreach (ContactPoint contact in theCol.contacts){
			Debug.DrawRay (contact.point, contact.normal, Color.white);
		}
		Debug.Log ("hand:onCollisionEnter:"+theCol.gameObject.name);

	}

	void OnTriggerEnter(Collider theCol){
		if (theCol.gameObject.name.Contains ("Pillar")) {
			Debug.Log ("Right Hand:onTriggerEnter");
		}
		Vector3 aForce = (theCol.gameObject.transform.position - transform.position).normalized * hitStrength;
		if (theCol.gameObject.GetComponent<Rigidbody> ()) {
			theCol.gameObject.GetComponent<Rigidbody> ().AddForce (aForce);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
