using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class myNetId : NetworkBehaviour {
    public string id;
    public NetworkIdentity idComponent = null;
	// Use this for initialization
	void Start () {
        idComponent = GetComponent<NetworkIdentity>();
	}
	
	// Update is called once per frame
	void Update () {
        id = idComponent.netId.ToString();
    }
}
