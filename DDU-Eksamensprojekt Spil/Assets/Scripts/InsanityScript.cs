using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class InsanityScript : MonoBehaviour
{
    //variable creation
    Light2D insanityLight;
    private float outerRadius;


    // Start is called before the first frame update
    void Start()
    {
        insanityLight = GetComponent<Light2D>(); //gets light component from gameObject
        outerRadius = insanityLight.pointLightOuterRadius; //sets outerRadious variable to the light objects current outer radius
        Invoke("moreInsane", 1); //invoke the specified function after a second
    }
  
    // Update is called once per frame
    void Update()
    {
        if (insanityLight.pointLightOuterRadius <= 1) //if the light gets too dim then execute the following code
        {
            SceneManager.LoadScene(0); //the player is killed and sent back to the main menu
        }
    }

    void moreInsane() //insanity function
    {
        insanityLight.pointLightOuterRadius += -1; //slowly subtract a value from the lights outerRadius
        Invoke("moreInsane", 1); //invoke the function again after 1 second
    }
}