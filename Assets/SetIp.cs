using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetIp : NetworkBehaviour {
    public string serverIp = "192.168.0.3";
	// Use this for initialization
	void Start () {
        GetComponent<NetworkManager>().networkAddress = serverIp;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
