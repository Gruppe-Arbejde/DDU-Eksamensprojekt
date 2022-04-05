using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour
{
    public Transform destination;


    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.position = destination.position;
        if (other.tag == "Player")
        {
            var startPosition = other.transform.position;
            other.transform.position = destination.position;
            Camera.main.transform.position = new Vector3(0, -15, -10);
            print("TELEPORT");
        }
    }
}
