using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderSystem : MonoBehaviour
{
    [SerializeField]
    public bool isRecipeActive;
    public DeliverySystem deliverySystem;
    public DeathTimer deathTimer;
    public ScoreSystem scoreSystem;
    public DataHandling dataHandling;
    public AudioManager audioManager;

    public int recipeValue;
    public int recipeID;

    public Sprite hamBurger;
    public Sprite salad;
    public Sprite beef;
    public Sprite tomato;
    
    //public GameObject ingredientList;
    public GameObject FoodPicture;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //change this back after system completion
        if (isRecipeActive == false) //checks if there is a recipe already displayed
        {
            recipe(Random.Range(0, 7)); //generates a random number so that the recipes chosen are random
            Debug.Log("random generated"); //development help
            isRecipeActive = true;
        }
        else
        {
            if (deliverySystem.foodValue == recipeValue)
            {
                Debug.Log("food made");
                //foodMadePopUp();
                audioManager.Play("clock");
                isRecipeActive = false;
                deliverySystem.saladPresent = false;
                deliverySystem.bunPresent = false;
                deliverySystem.beefPresent = false;
                deliverySystem.tomatoPresent = false;
                deliverySystem.foodValue = 0;
                deathTimer.time += 20; //sets the start value of timer after completing order alternatively += could be used to make it more dynamic
                scoreSystem.ScoreIncrease();
                dataHandling.RecipeChecklistColorCorrect();
            }
            else if (deliverySystem.foodValue > recipeValue)
            {
                deliverySystem.saladPresent = false;
                deliverySystem.bunPresent = false;
                deliverySystem.beefPresent = false;
                deliverySystem.tomatoPresent = false;
                deliverySystem.foodValue = 0;
                dataHandling.RecipeChecklistColorCorrect();
            }
        }
        dataHandling.RecipeChecklistImageHandling();
    }

    //public void recipeActivityClick()
    //{
    //    if (isRecipeActive == true)
    //    {
    //        isRecipeActive = false;
    //    }
    //    else
    //    {
    //        isRecipeActive = true;
    //    }

    //}

    public void recipe(int recipeName) //function that recieves a float called recipeName
    {
        Debug.Log($"{recipeName}"); //development help

        switch (recipeName) //multi selection of recipes depending of random value generated
        {
            case 0: //burger (salad, bun, beef)
                recipeValue = 95;
                FoodPicture.GetComponent<Image>().sprite = hamBurger;
                recipeID = 0;
                break;
            case 1: //single salad
                recipeValue = 30;
                FoodPicture.GetComponent<Image>().sprite = salad;
                recipeID = 1;
                break;
            case 2: //single beef
                recipeValue = 40;
                FoodPicture.GetComponent<Image>().sprite = beef;
                recipeID = 2;
                break;
            case 3: //Tomato
                recipeValue = 35;
                FoodPicture.GetComponent<Image>().sprite = tomato;
                recipeID = 3;
                break;
            case 4: //Tomato, salad, bun, beef
                recipeValue = 130;
                FoodPicture.GetComponent<Image>().sprite = hamBurger;
                recipeID = 4;
                break;
            case 5: //Tomato, salad, bun
                recipeValue = 90;
                FoodPicture.GetComponent<Image>().sprite = hamBurger;
                recipeID = 5;
                break;
            case 6: //Beef, bun tomato
                recipeValue = 100;
                //ingredientList.GetComponent<TMPro.TextMeshProUGUI>().text = "Tomato";
                FoodPicture.GetComponent<Image>().sprite = hamBurger;
                recipeID = 6;
                break;
            default:
                break;
        }
    }

    //public void foodMadePopUp() //ingredient creation
    //{
    //    if (foodText.activeInHierarchy == false) //checks if the popup is already active in the game and if not runs the following code
    //    {
    //        foodText.SetActive(true); //sets the popup to being active and displayed
    //        Invoke("foodMadePopUp", 2); //runs the function again after 3 seconds so that the text is only displayed for a certain amount of time
    //    }
    //    else if (foodText.activeInHierarchy == true) ////checks if the popup is already active in the game and if it is runs the following code
    //    {
    //        foodText.SetActive(false); //sets the popup to being false and therefore not displayed
    //    }
    //}
}
