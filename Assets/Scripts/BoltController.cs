using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltController : MonoBehaviour {

    private float speed = 20.0f;
    private GameObject bolt;
    private Rigidbody boltRigidbody;
    private Transform boltTransform;

	// Use this for initialization
	void Start () {
        bolt = this.gameObject;
        boltRigidbody = bolt.GetComponent<Rigidbody>();
        boltTransform = bolt.GetComponent<Transform>();

        boltRigidbody.velocity = transform.forward * speed;
	}
	
    void Update ()
    {
        if (boltTransform.position.z > 20.0f)
            GameObject.Destroy(bolt);
    }
	
}
