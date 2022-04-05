using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderSystem : MonoBehaviour
{
    [SerializeField]
    public bool isRecipeActive;
    //public GameObject recipeObject;
    //public SpriteRenderer spriteColor;
    public Image RecipeImage;
    public DeliverySystem bagInventory;
    //public int foodValue;
    public int recipeValue;
    public GameObject foodText;


    // Update is called once per frame
    void Update()
    {
        //change this back after system completion
        if (isRecipeActive == false) //checks if there is a recipe already displayed
        {
            recipe(Random.Range(0, 3)); //generates a random number so that the recipes chosen are random
            Debug.Log("random generated"); //development help
            isRecipeActive = true;
        }
        else
        {
            if (bagInventory.foodValue == recipeValue)
            {
                Debug.Log("food made");
                foodText.SetActive(true);
                isRecipeActive = false;
                bagInventory.saladPresent = false;
                bagInventory.bunPresent = false;
                bagInventory.beefPresent = false;
                bagInventory.foodValue = 0;
            }
        }
    }

    //public void recipeGenerationClick()
    //{
    //    if (isRecipeActive == false) //checks if there is a recipe already displayed
    //    {
    //        recipe(Random.Range(0, 3)); //generates a random number so that the recipes chosen are random
    //        Debug.Log("random generated"); //development help
    //    }
    //    else
    //    {
    //        Debug.Log("Already have active recipe");
    //    }
    //}

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
            case 0: //burger
                RecipeImage.color = Color.red;
                //recipeCheck(50);
                recipeValue = 50;
                //spriteColor.color = Color.red;
                break;
            case 1: //single salad
                RecipeImage.color = Color.green;
                //recipeCheck(15);
                recipeValue = 15;
                //spriteColor.color = Color.blue;
                break;
            case 2: //single beef
                RecipeImage.color = Color.blue;
                //recipeCheck(10)
                recipeValue = 10;
                //spriteColor.color = Color.green;
                break;
            default:
                break;
        }
    }

    //public void recipeCheck(int recipeValue)
    //{
    //    if (bagInventory.foodValue == recipeValue);
    //    {
    //        Debug.Log("food made");
    //        foodText.SetActive(true);
    //        isRecipeActive = false;
    //        bagInventory.saladPresent = false;
    //        bagInventory.bunPresent = false;
    //        bagInventory.beefPresent = false;
    //    }
    //}
}
