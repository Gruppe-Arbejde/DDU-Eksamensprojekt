using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    //public string cameraName;
    public Camera Main; // THis is PLAYER CAMERA
    public Camera Secondary; // THIS IS THE CAMERA WE CHANGE TOO OR DISABLE.
    //public GameObject SpawnPoint;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Secondary.enabled = false;
            Main.enabled = true;
            Debug.Log("TELEPORT");
        }
    }
}
