using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Player collision occuer ");
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("collision occuer with enemy !");
            GameManager.Instance.decreaseHealth();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Health")
        {
            Debug.Log("collision occuer with Health !");
            GameManager.Instance.increaseHealth();
            Destroy(collision.gameObject);
        }
    }
}
