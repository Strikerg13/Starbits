using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;
}

public class PlayerController : MonoBehaviour {

    private float moveHorizontal;
    private float moveVertical;
    private float moveSpeed = 10f;
    private float tilt = 3.0f;
    public GameObject player;
    private Rigidbody playerRigidbody;
    private Transform playerTransform;
    public Boundary boundary;

    void Start()
    {
        // Find the player
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null) // get the player's components
        {
            playerRigidbody = player.GetComponent<Rigidbody>();
            playerTransform = player.GetComponent<Transform>();
        }

    }

    void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        // Make player move
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        playerRigidbody.velocity = new Vector3(moveHorizontal, 0.0f, moveVertical) * moveSpeed;

        // Restrict player to the visible window
        playerTransform.position = new Vector3
            (
                Mathf.Clamp(playerTransform.position.x, boundary.xMin, boundary.xMax), 
                0.0f, 
                Mathf.Clamp(playerTransform.position.z, boundary.zMin, boundary.zMax)
            );

        // Tilt the player when moving side to side
        playerTransform.rotation = Quaternion.Euler(0.0f, 0.0f, playerRigidbody.velocity.x * -tilt);
    }

}
