using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Applaying force to RigidBody to moves object along the -Z Axis 
/// Destroying object if pass the Z boundary 
/// </summary>
public class MovingDown : MonoBehaviour
{
    public float speed; // speed of game object moving in a negative globaal z axies  

    private float zDestroy = -18; // game objects will be destroied if equal or less than this point 
    private Rigidbody ObjectRb; 

    // Start is called before the first frame update
    void Start()
    {
        ObjectRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        // Apply constant force along the -z axis 
        ObjectRb.AddForce(Vector3.back * speed, ForceMode.Impulse);
        
        // Destroy game object if pass the z boundary
        if(transform.position.z <= zDestroy)
        {
            Destroy(gameObject);
        }
    }
}
