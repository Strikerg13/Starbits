using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {

    public float tumble;
    public float speed;

    void Start()
    {
        this.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;

        this.GetComponent<Rigidbody>().velocity = this.GetComponent<Transform>().forward * speed * (-1);
    }

    void OnTriggerEnter(Collider col)
    {
        Destroy(col.gameObject);
        Destroy(this.gameObject);
    }

}