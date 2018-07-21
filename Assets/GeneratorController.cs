using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour {

    public GameObject asteroid;
    private Rigidbody myRigidbody;
    private Transform myTransform;
    private float nextAsteroid = 0.0f;
    private float genRate = 0.75f;
    private Vector3 offset;

	// Use this for initialization
	void Start () 
    {
        myRigidbody = this.GetComponent<Rigidbody>();
        myTransform = this.GetComponent<Transform>();

        makeAsteroid();
         
	}
	
	// Update is called once per frame
	void Update () 
    {
        makeAsteroid();
	}

    void makeAsteroid()
    {
        // check interval between asteroid generation
        if (Time.time < nextAsteroid)
            return;

        // generate an asteroid
        if (asteroid != null)
        {
            offset = new Vector3(Random.Range(-7, 7) * 1.0f, 0,0);

            Instantiate(asteroid, myTransform.position + offset, myTransform.rotation);
            nextAsteroid = Time.time + genRate;
        }
        else
            Debug.Log("Asteroid not found");
    }
}
