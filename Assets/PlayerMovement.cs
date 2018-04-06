using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour {
	float dXmin,dYmin,dZmin;
	float dXmax,dYmax,dZmax;

	public float playerSpeed = 10;
	public GameObject player = null;
    public bool areWeLocalPlayer = false;

	// Use this for initialization
	void Start () {

	}

	void Update(){
        Debug.Log("PM:up:" + areWeLocalPlayer);
		if (!areWeLocalPlayer)
		{
			return;
		}
		player.transform.rotation = Quaternion.Euler(new Vector3(player.transform.rotation.x, transform.GetChild(0).eulerAngles.y/**180.0f*/, player.transform.rotation.z));
	//	transform.rotation = new Vector3 (transform.rotation.x, transform.rotation.y * 180.0f, transform.rotation.z);
	}

	
	// Update is called once per frame
	void LateUpdate () {
        Debug.Log("PM:LU:" + areWeLocalPlayer);
        //transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);
        if (!areWeLocalPlayer)
		{
			return;
		}
		Debug.Log ("Player Rotation Before" + player.transform.rotation);
		Debug.Log ("Camera Rotation Before" + transform.rotation);
        //player.transform.rotation = Quaternion.Euler(new Vector3 (player.transform.rotation.x, transform.rotation.y/(2.0f*Mathf.PI)*360.0f, player.transform.rotation.z));
     
        transform.GetChild(0).position = player.transform.position+player.transform.up*0.541f;// - player.transform.forward * 3.0f;   // set our position behind player
		Debug.Log ("Player Rotation After" + player.transform.rotation);
		Debug.Log ("Camera Rotation After" + transform.rotation);




//		float aX = Input.acceleration.x;
//		float aY = Input.acceleration.y;
//		float aZ = Input.acceleration.z;
//		if (dXmax<aX){
//			dXmax = aX;
//		}
//		if (dYmax<aY){
//			dYmax = aY;
//		}
//		if (dZmax<aZ){
//			dZmax = aZ;
//		}
//		// mins
//		if (dXmin>aX){
//			dXmin = aX;
//		}
//		if (dYmin>aY){
//			dYmin = aY;
//		}
//		if (dZmin>aZ){
//			dZmin = aZ;
//		}
//	//	Debug.Log("DebugAccel0:"+aX+ "," +aY +","+ aZ);
//		// show min max and delta
//	//	Debug.Log("DebugAccelA:"+dXmin + "," +dYmin +","+ dZmin);
//	//	Debug.Log("DebugAccelB:"+dXmax + "," +dYmax +","+ dZmax);
//	//	Debug.Log("DebugAccelC:"+(dXmax-dXmin) + "," +(dYmax-dYmin)+","+ (dZmax-dZmin));
//		// reduce to 0 over time
//		dXmin *= 0.9f;
//		dYmin *= 0.9f;
//		dZmin *= 0.9f;
//		dXmax *= 0.9f;
//		dYmax *= 0.9f;
//		dZmax *= 0.9f;
//
//
//		float tempMag = Input.acceleration.magnitude;
//		Debug.Log("DebugAccelAD:==================== ");
//		//Debug.Log("DebugAccelAD: "+tempMag);
//		Matrix4x4 m = Matrix4x4.Rotate(transform.rotation);
//		Vector4 v = m.GetColumn(2);
//		//Debug.Log("DebugAccelAD2:" + v+"\t(p):"+GetComponentInParent<Transform>().position+"\tm:"+tempMag);
//		//Debug.Log("DebugAccelAD2:" + v+"\t(p):"+player.transform.position+"\tm:"+tempMag);
//
//		if (tempMag >= 2) {
//		//	if (player != null) {
//			//Debug.Log("DebugAccelAD: Player is not null " + player);
//			player.transform.position = player.transform.position+ new Vector3(v.x,v.y,v.z);
//		//	}
//
//			Debug.Log("DebugAccelAD2: FIRED!!!!");
//		}
//		if (Input.GetKeyDown(KeyCode.Space)){
//			//player.transform.position = player.transform.position+ new Vector3(1,0,0);
//			player.transform.position = player.transform.position+ new Vector3(v.x,v.y,v.z);
//			Debug.Log("DebugAccelAD2: FIRED2!!!!");
		//}
			
	}
}
	