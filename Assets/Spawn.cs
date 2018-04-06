using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Spawn : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        if (isLocalPlayer)
        {
            transform.GetChild(2).position = new Vector3(Random.value * 10f - 5f, Random.value * 5f, Random.value * 10f - 5f);
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void OnStartLocalPlayer()
    {
        transform.GetChild(2).GetComponent<MeshRenderer>().material.color = Color.blue;
        transform.GetChild(1).GetComponent<MeshRenderer>().material.color = Color.blue;

    }
}
