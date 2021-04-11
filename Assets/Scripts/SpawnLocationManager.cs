using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocationManager : MonoBehaviour
{
    public bool isOccupied;
    private void Start()
    {
        isOccupied = false;
        GetComponent<MeshRenderer>().material.color = Color.green;
    }
    private void OnTriggerEnter(Collider other)
    {
        isOccupied = true;
        Debug.Log("Enemy spawned ");
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    private void OnTriggerExit(Collider other)
    {
        isOccupied = false;
        Debug.Log("Enemy left from here");

        GetComponent<MeshRenderer>().material.color = Color.green;
    }
    private void OnTriggerStay(Collider other)
    {
        isOccupied = true;
        GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
