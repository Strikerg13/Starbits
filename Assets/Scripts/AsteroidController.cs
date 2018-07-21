using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {

    private float tumble = 5.0f;
    private float speed = 4.0f;

    void Start()
    {
        this.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
        this.GetComponent<Rigidbody>().velocity = this.GetComponent<Transform>().forward * speed * (-1);
    }

    void OnTriggerEnter(Collider col)
    {
        // ignore the boundary
        if (col.tag == "Boundary")
            return;
        
        Destroy(col.gameObject);
        Destroy(this.gameObject);
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag != "Boundary")
            return;

        Destroy(this.gameObject);
    }

}