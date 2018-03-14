using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraLock : NetworkBehaviour {

	Camera playerCamera;
    public int tag =  13;
	public float offset  = 10f;
    float xTilt = 22f;

	void Start(){
		playerCamera = transform.GetChild (4).GetComponent<Camera> ();

	}

	void Update(){
		playerCamera.transform.position = transform.position + transform.forward * -offset;
        playerCamera.transform.position += new Vector3(0, 4, 0);
        Vector3 playerRotation = transform.rotation.ToEulerAngles();
		playerCamera.transform.rotation = Quaternion.EulerAngles((playerRotation.x+xTilt)/360f*2f*Mathf.PI, playerRotation.y , playerRotation.z );
//		offset = new Vector3(0.17f, 2.36f, 394f);
//		GetComponent<Transform>().position = GetComponentInParent<Transform>().position + offset;

		Debug.Log (playerCamera.transform.rotation);
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
