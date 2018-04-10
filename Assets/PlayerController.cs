using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour{
    public GameObject bulletPrefab;
	public GameObject axePrefab;
    public Transform bulletSpawnRight;
	public Transform bulletSpawnLeft;
	public float playerSpeed;
	public float z = 0;
    bool fire1Flag = false;
    bool fire2Flag = false;
    GameObject camParent = null;
    
    // Use this for initialization
    void Start () {
        Debug.Log("Cams:" + Camera.allCameras.Length);
        // get the head into each player
        camParent = GameObject.Find("Head");
        Debug.Log("CamP:" + camParent+"\tcamera:"+ Camera.allCameras[0]);        
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
        {
            return;
        }
        //var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
        
        z = Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;

        //transform.Rotate(0, x, 0);
        //transform.Translate(0, 0, z);
        // get rotation from the camera in the scene and apply to the player model
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, camParent.transform.GetChild(0).transform.eulerAngles.y/**180.0f*/, transform.rotation.z));
        var aMoveVec = transform.GetComponent<Transform>().forward * z + transform.GetComponent<Transform>().right * x;
        transform.position += aMoveVec;

        // handle shot inputs
        if ((Input.GetKeyDown(KeyCode.Space)))//||Input.GetButton("Fire1")))
        {
            Debug.Log("netID:pFR:" + netId.ToString());
            CmdFireRight();
        }
        if (Input.GetButton("Fire1") && !fire1Flag)
        {
            Debug.Log("netID:pFR:" + netId.ToString());
            //RpcFireAxe(bulletSpawnRight.position, 
            //    bulletSpawnRight.rotation, 
            //    125f * bulletSpawnRight.GetComponent<Transform>().right,
            //    transform.forward * 6 + (transform.forward * Mathf.Max(z, 0) * 30f));
            CmdFireRight();
            fire1Flag = true;
        }
        if (!Input.GetButton("Fire1"))
        {
            fire1Flag = false;
        }

        if ((Input.GetKeyDown(KeyCode.B)))// || Input.GetButton("Fire2")))
		{
            Debug.Log("netID:pFL:" + netId.ToString());
            CmdFireLeft();
		}
        if (Input.GetButton("Fire2") && !fire2Flag)
        {
            Debug.Log("netID:pFL:" + netId.ToString());
            CmdFireLeft();
            fire2Flag = true;
        }
        
        if (!Input.GetButton("Fire2"))
        {
            fire2Flag = false;
        }
       // Debug.Log("myBs:" + Input.GetButton("Fire1") + "," + Input.GetButton("Fire2"));
    }

    private void LateUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        // update camparent to be at players position
        camParent.GetComponent<Transform>().position = transform.position + transform.up * 0.541f;// - player.transform.forward * 3.0f;   // set our position behind player
        //	
    }

    //[ClientRpc]
    //void RpcFireAxe(Vector3 thePos, Quaternion theOri, Vector3 theVel, Vector3 theAVel)
    //{
    //    Debug.Log("RpcFireAxe:FR:" + netId.ToString()+":"+theVel+":"+theAVel);
    //    // Create the Bullet from the Bullet Prefab
    //    var bullet = (GameObject)Instantiate(
    //        axePrefab,
    //        thePos,
    //        theOri);
    //    bullet.GetComponent<Rigidbody>().angularVelocity = theAVel;
    //    bullet.GetComponent<Rigidbody>().velocity = theVel;
    //    //}
    //    // Add velocity to the bullet
    //    NetworkServer.Spawn(bullet);
    //    // Destroy the bullet after 2 seconds
    //    Destroy(bullet, 3.0f);
    //}

    [Command]
    void CmdFireRight()
    {
        Debug.Log("netID:FR:"+netId.ToString());
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            axePrefab,
            bulletSpawnRight.position,
            bulletSpawnRight.rotation);
        //if (isLocalPlayer)
        //{
            bullet.GetComponent<Rigidbody>().angularVelocity = 125f * bulletSpawnRight.GetComponent<Transform>().right;
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6 + (transform.forward * Mathf.Max(z, 0) * 30f);
        //}
        // Add velocity to the bullet
        NetworkServer.Spawn(bullet);
        // Destroy the bullet after 2 seconds
        Destroy(bullet, 3.0f);
    }

	[Command]
	void CmdFireLeft()
	{
        Debug.Log("netID:FL:" + netId.ToString());
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
			bulletPrefab,
			bulletSpawnLeft.position,
			bulletSpawnLeft.rotation);
        //if (isLocalPlayer)
        //{
            bullet.GetComponent<Rigidbody>().angularVelocity = 125f * bulletSpawnLeft.GetComponent<Transform>().right;
            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6 + GetComponent<Transform>().up * 3f + (transform.forward * Mathf.Max(z, 0) * 30f);
        //}		
		NetworkServer.Spawn(bullet);
		// Destroy the bullet after 2 seconds
		Destroy(bullet, 3.0f);
	}

    public override void OnStartLocalPlayer()
    {
       transform.GetComponent<MeshRenderer>().material.color = Color.blue; // change sphere
    }

    
}
