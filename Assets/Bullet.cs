﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    
    void OnCollisionEnter(Collision theCollision)
    {
        var hit = theCollision.gameObject;
        var health = hit.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(10);
        }
        //Destroy(gameObject);
    }

// Use this for initialization
void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
