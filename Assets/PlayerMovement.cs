using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	float dXmin,dYmin,dZmin;
	float dXmax,dYmax,dZmax;

	public float playerSpeed = 10;
	public GameObject player = null;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);

		Debug.Log ("Player Rotation Before" + player.transform.rotation);
		Debug.Log ("Camera Rotation Before" + transform.rotation);
		player.transform.rotation = Quaternion.Euler(new Vector3 (player.transform.rotation.x, transform.rotation.y, player.transform.rotation.z));
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
	