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
        Debug.Log("col:" + theCollision.gameObject.name);
        gameObject.transform.SetParent(theCollision.gameObject.transform);
        GetComponent<Rigidbody>().isKinematic = true;
        if (GetComponent<CapsuleCollider>() != null)
        {
            GetComponent<CapsuleCollider>().enabled = false;
        }

        //Destroy(gameObject);
		gameObject.transform.SetParent (theCollision.gameObject.transform);
		GetComponent<Rigidbody>().isKinematic = true;
		if (GetComponent<CapsuleCollider> () != null) {
			GetComponent<CapsuleCollider> ().enabled = false;
		}
		//Vector3 childPos = transform.position - theCollision.transform.position;

    }

// Use this for initialization
void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
