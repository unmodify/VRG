using System.Collections;
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
		GetComponent<Rigidbody>().isKinematic = true;
		GetComponent<Collider> ().enabled = false;
		Vector3 childPos = transform.position - theCollision.transform.position;
		transform.SetParent (theCollision.transform);
    }

// Use this for initialization
void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
