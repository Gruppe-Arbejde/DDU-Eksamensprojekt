using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public GameObject ingredientList;
    public GameObject recipePicture;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //change this back after system completion
        if (isRecipeActive == false) //checks if there is a recipe already displayed
        {
            recipe(Random.Range(0, 4)); //generates a random number so that the recipes chosen are random
            Debug.Log("random generated"); //development help
            isRecipeActive = true;
        }
        else
        {
            if (bagInventory.foodValue == recipeValue)
            {
                Debug.Log("food made");
                //foodText.SetActive(true);

                foodMadePopUp();
                isRecipeActive = false;
                bagInventory.saladPresent = false;
                bagInventory.bunPresent = false;
                bagInventory.beefPresent = false;
                bagInventory.tomatoPresent = false;
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
                //RecipeImage.color = Color.red;
                //recipeCheck(50);
                recipeValue = 50;
                ingredientList.GetComponent<TMPro.TextMeshProUGUI>().text = "Salad\nBun\nBeef";
                //spriteColor.color = Color.red;
                recipePicture.transform.GetChild(1).gameObject.SetActive(true);
                recipePicture.transform.GetChild(2).gameObject.SetActive(false);
                recipePicture.transform.GetChild(3).gameObject.SetActive(false);
                recipePicture.transform.GetChild(4).gameObject.SetActive(false);
                break;
            case 1: //single salad
                //RecipeImage.color = Color.green;
                //recipeCheck(15);
                recipeValue = 15;
                ingredientList.GetComponent<TMPro.TextMeshProUGUI>().text = "Salad";
                //spriteColor.color = Color.blue;
                recipePicture.transform.GetChild(1).gameObject.SetActive(false);
                recipePicture.transform.GetChild(2).gameObject.SetActive(true);
                recipePicture.transform.GetChild(3).gameObject.SetActive(false);
                recipePicture.transform.GetChild(4).gameObject.SetActive(false);
                break;
            case 2: //single beef
                //RecipeImage.color = Color.blue;
                //recipeCheck(10)
                recipeValue = 10;
                ingredientList.GetComponent<TMPro.TextMeshProUGUI>().text = "Beef";
                //spriteColor.color = Color.green;
                recipePicture.transform.GetChild(1).gameObject.SetActive(false);
                recipePicture.transform.GetChild(2).gameObject.SetActive(false);
                recipePicture.transform.GetChild(3).gameObject.SetActive(true);
                recipePicture.transform.GetChild(4).gameObject.SetActive(false);
                break;
            case 3: //Tomato
                //RecipeImage.color = Color.blue;
                //recipeCheck(10)
                recipeValue = 20;
                ingredientList.GetComponent<TMPro.TextMeshProUGUI>().text = "Tomato";
                //spriteColor.color = Color.green;
                recipePicture.transform.GetChild(1).gameObject.SetActive(false);
                recipePicture.transform.GetChild(2).gameObject.SetActive(false);
                recipePicture.transform.GetChild(3).gameObject.SetActive(false);
                recipePicture.transform.GetChild(4).gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void foodMadePopUp() //ingredient creation
    {
        if (foodText.activeInHierarchy == false) //checks if the popup is already active in the game and if not runs the following code
        {
            foodText.SetActive(true); //sets the popup to being active and displayed
            Invoke("foodMadePopUp", 2); //runs the function again after 3 seconds so that the text is only displayed for a certain amount of time
        }
        else if (foodText.activeInHierarchy == true) ////checks if the popup is already active in the game and if it is runs the following code
        {
            foodText.SetActive(false); //sets the popup to being false and therefore not displayed
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
