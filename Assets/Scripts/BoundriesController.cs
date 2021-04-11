using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundriesController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Health")
        {
            Destroy(collision.gameObject);
        }
    }
}
