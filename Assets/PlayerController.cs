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
    // Use this for initialization
    void Start () {
       // GetComponent<Rigidbody>().freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
        {
        //    return;
        }
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        z = Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;

        //transform.Rotate(0, x, 0);
        //transform.Translate(0, 0, z);
        transform.position += GetComponent<Transform>().forward* z;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFireRight();
        }
		if (Input.GetKeyDown(KeyCode.B))
		{
			CmdFireLeft();
		}
    }

    [Command]
    void CmdFireRight()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawnRight.position,
            bulletSpawnRight.rotation);
        bullet.GetComponent<Rigidbody>().angularVelocity = 125f*bulletSpawnRight.GetComponent<Transform>().right;

        // Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6+ GetComponent<Transform>().up*3f + (transform.forward * Mathf.Max(z, 0) * 30f);
        NetworkServer.Spawn(bullet);
        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }

	[Command]
	void CmdFireLeft()
	{
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate(
			bulletPrefab,
			bulletSpawnLeft.position,
			bulletSpawnLeft.rotation);
		bullet.GetComponent<Rigidbody>().angularVelocity = 125f*bulletSpawnLeft.GetComponent<Transform>().right;

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6+ GetComponent<Transform>().up*3f + (transform.forward * Mathf.Max(z, 0) * 30f);
		NetworkServer.Spawn(bullet);
		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);
	}

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
		Camera.allCameras [0].GetComponent<PlayerMovement> ().player = gameObject;
    }

    
}
