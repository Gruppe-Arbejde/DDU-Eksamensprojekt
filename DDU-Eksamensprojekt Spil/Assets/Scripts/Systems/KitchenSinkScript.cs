using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class KitchenSinkScript : MonoBehaviour
{
    bool pickUpAllowed;
    public GameObject popup;
    public GameObject insanityLight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && pickUpAllowed) //checks if e key is pressed while the bool pickUpAllowed is true
        {
            insanityLight.GetComponent<Light2D>().pointLightOuterRadius = 2;
            //insanityLight.pointLightOuterRadius = 2;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) //function that triggers when two colliders are touching
    {
        if (collision.gameObject.name.Equals("Player")) //checks if the name of the object who hold the collider is "Player"
        {
            popup.SetActive(true); //sets the popup gameobject to active
            pickUpAllowed = true; //sets the bool pickUpAllowed to true so that you can fulfill one of the conditions in the update loop
            Debug.Log("trigger enter"); //debug
        }

    }

    private void OnTriggerExit2D(Collider2D collision) //function that triggers when two colliders leave eachother
    {
        if (collision.gameObject.name.Equals("Player")) //checks if the name of the object who held the collider is "Player"
        {
            popup.SetActive(false); //sets the popup gameobject to false
            //popup.GetComponent<TMPro.TextMeshProUGUI>().text = "E to wash hands clean from blood and clear insanity";
            pickUpAllowed = false; //sets the bool pickUpAllowed to true so that you can fulfill one of the conditions in the update loop
            Debug.Log("trigger exit"); //debug
        }
    }
}
