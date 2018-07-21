using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour {

    public float speed = 0.03f;
    private Vector2 offset;
	
	void Update () {
        offset = new Vector2(0, Time.time * speed);
        this.GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
