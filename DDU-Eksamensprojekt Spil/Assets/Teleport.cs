using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    bool inFreezer = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (inFreezer == false)
            {
                Camera.main.transform.position = new Vector3(0, -15, -10);
                inFreezer = true;
                print("TELEPORT TO FREEZER");
            }
            else if (inFreezer == true)
            {
                Camera.main.transform.position = new Vector3(0, 0, -10);
                inFreezer = false;
                print("TELEPORT TO KITCHEN");
            }
        }
    }
}
