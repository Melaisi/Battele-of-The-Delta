using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float verticalInput { get { return Input.GetAxis("Vertical"); } }
    float horizontalInput { get { return Input.GetAxis("Horizontal"); } }

    public float velocity;
    public float speed = 10;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        velocity = speed * verticalInput;
        //Debug.Log(velocity);
        rb.AddRelativeForce(Vector3.forward * speed * verticalInput);
        rb.AddRelativeTorque(Vector3.up * speed * horizontalInput);
    }

    
}
