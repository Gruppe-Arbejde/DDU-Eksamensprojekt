using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public bool inFreezer = false;

    public Transform kitchenTarget;
    public Transform freezerTarget;
    public float smoothing;

    public InsanityScript insanity;
    public GameObject insanityScript;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (inFreezer == false)
            {
                Vector3 freezerPosition = new Vector3(freezerTarget.position.x, freezerTarget.position.y, transform.position.z);
                Camera.main.transform.position = Vector3.Lerp(transform.position, freezerPosition, smoothing*Time.deltaTime);
                inFreezer = true;
                print("TELEPORT TO FREEZER");
                insanityScript.SetActive(true);
                insanity.insanityStart();
            }
            else if (inFreezer == true)
            {
                Vector3 kitchenPosition = new Vector3(kitchenTarget.position.x, kitchenTarget.position.y, transform.position.z);
                Camera.main.transform.position = Vector3.Lerp(transform.position, kitchenPosition, smoothing*Time.deltaTime);
                inFreezer = false;
                print("TELEPORT TO KITCHEN");

            }
        }
    }
}
