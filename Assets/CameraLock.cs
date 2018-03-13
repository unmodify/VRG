using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraLock : NetworkBehaviour {

	Camera playerCamera;

	public Vector3 offset  = new Vector3(0.17f, 2.36f, 3.94f);

	void Start(){
		playerCamera = transform.GetChild (4).GetComponent<Camera> ();
	}

	void Update(){
		playerCamera.transform.position = transform.position + offset;
		playerCamera.transform.rotation = Quaternion.Euler(22.08f, transform.rotation.y * -1, 0f);
//		offset = new Vector3(0.17f, 2.36f, 394f);
//		GetComponent<Transform>().position = GetComponentInParent<Transform>().position + offset;

		Debug.Log (transform.rotation.y);
	}

//	void Start(){
//	
//
//	}
//
//
//	// Update is called once per frame
//	void Update () {
//
//		GetComponent<Transform>().position = GetComponentInParent<Transform> ().forward * -10f;
//		GetComponent<Transform> ().position += GetComponentInParent<Transform> ().position;
//		Debug.Log ("Test");
//
//
//
//
//		if (isLocalPlayer)
//		{
//			
//			Debug.Log ("Test Inside");
////			transform.position = Vector3.zero;
//		}
//
////		lookAt += Target.transform.position;
////		base.Update ();
////		gameObject.transform.position += lookAt;
//
//	
//	}
}
