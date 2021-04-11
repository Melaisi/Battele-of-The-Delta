

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Expermintal player controller
/// </summary>
public class ExpPlayerCTR : MonoBehaviour
{
    Rigidbody playerRb;

    public float playerSpeed;
    public enum movementType { addforce, velocity };
    public bool fixedupdate = false;

    float horizontalInput = 0;
    float verticalInput = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

    }

    private void FixedUpdate()
    {
        
            playerRb.AddTorque(Vector3.up * playerSpeed * horizontalInput);
            playerRb.AddForce(transform.forward * playerSpeed * verticalInput);
        
    }

    void inputControl()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            //playerRb.AddForce(Vector3.right * playerSpeed * horizontalInput);
            // Applay torque to rotate object's Yaw axis
            //playerRb.AddTorque(Vector3.up * playerSpeed * horizontalInput);

            //playerRb.AddForce(Vector3.forward * playerSpeed * verticalInput);
            // Applay force to the local forward direction 
            //playerRb.AddForce(transform.forward * playerSpeed * verticalInput);
        }
    
}
