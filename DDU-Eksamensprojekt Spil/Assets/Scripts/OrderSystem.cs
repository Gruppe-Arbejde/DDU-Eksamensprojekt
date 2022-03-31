using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSystem : MonoBehaviour
{
    [SerializeField]
    public bool isRecipeActive;
    //public GameObject recipeObject;
    public SpriteRenderer spriteColor;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //change this back after system completion
        //if (isRecipeActive == true) //checks if there is a recipe already displayed
        //{
        //    recipe(Random.Range(0f, 2)); //generates a random number so that the recipes chosen are random
        //    Debug.Log("random generated"); //development help
        //}
    }

    public void recipeGenerationClick()
    {
        if (isRecipeActive == false) //checks if there is a recipe already displayed
        {
            recipe(Random.Range(0, 2)); //generates a random number so that the recipes chosen are random
            Debug.Log("random generated"); //development help
        }
        else
        {
            Debug.Log("Already have active recipe");
        }
    }

    public void recipeActivityClick()
    {
        if (isRecipeActive == true)
        {
            isRecipeActive = false;
        }
        else
        {
            isRecipeActive = true;
        }

    }

    public void recipe(int recipeName) //function that recieves a float called recipeName
    {
        Debug.Log($"{recipeName}"); //development help

        switch (recipeName) //multi selection of recipes depending of random value generated
        {
            case 0:
                spriteColor.color = Color.red;
                break;
            case 1:
                spriteColor.color = Color.blue;
                break;
            case 2:
                spriteColor.color = Color.green;
                break;
            default:
                break;
        }
    }
}
