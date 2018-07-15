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

    private float fireRate = 0.25f;
    private float nextFire = 0.0f;

    public GameObject shot;

    void Start()
    {
        // Find the player
        player = this.gameObject;

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

    void Update()
    {
        FireControl();
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

    void FireControl()
    {

        // fire the bolt 
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            //GameObject shot = GameObject.FindWithTag("Bolt");

            if (shot != null)
            {
                Instantiate(shot, playerTransform.position, playerTransform.rotation);
                nextFire = Time.time + fireRate;
            }
            else
                Debug.Log("Shot not found");
        }
    }

}
