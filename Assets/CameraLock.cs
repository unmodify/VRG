using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraLock : NetworkBehaviour {

	Camera playerCamera;
    public const int tag =  14;
	public float offset  = 10f;
    float xTilt = 22f;

	void Start(){
        //playerCamera = transform.GetChild (4).GetComponent<Camera> ();
        //playerCamera = GameObject.Find("Main Camera").GetComponent<Camera>(); // didn't work, got null
        //playerCamera = Camera.main; // failed, maybe deleted one already
        playerCamera = Camera.allCameras[0];
        if (!playerCamera)
        {
            Debug.Log("Start:no camera found");
        }
        else
        {
            Debug.Log("Start:camera found");
        }
        Debug.Log("Found Cameras?:" + Camera.allCameras.Length);


    }

	void Update(){
        if (isLocalPlayer)
        {
            playerCamera.transform.position = transform.position + transform.forward * -offset;
            playerCamera.transform.position += new Vector3(0, 4, 0);
            Vector3 playerRotation = transform.rotation.ToEulerAngles();
            playerCamera.transform.rotation = Quaternion.EulerAngles((playerRotation.x + xTilt) / 360f * 2f * Mathf.PI, playerRotation.y, playerRotation.z);
            //		offset = new Vector3(0.17f, 2.36f, 394f);
            //		GetComponent<Transform>().position = GetComponentInParent<Transform>().position + offset;

            Debug.Log(playerCamera.transform.rotation);
        }
	}
}
