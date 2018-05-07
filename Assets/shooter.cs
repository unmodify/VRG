using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float z = 0;
    public float playerSpeed;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKeyDown(KeyCode.B)))// || Input.GetButton("Fire2")))
        {
            var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);
            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody>().velocity = -bullet.transform.forward * z;
            Destroy(bullet, 3.0f);
        }
        
    }
}
