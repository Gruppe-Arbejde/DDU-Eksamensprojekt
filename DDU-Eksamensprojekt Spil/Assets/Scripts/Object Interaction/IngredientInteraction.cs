using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngredientInteraction : MonoBehaviour
{
    //Variable creation
    public GameObject ingredientInventory;
    public GameObject popup;
    public GameObject maxInventoryPopUp;
    public MaxInventoryManager inventory;
    public IngredientInteraction interaction;
    public TrashCanScript trash;

    //sprites
    public Sprite bun;
    public Sprite salad;
    public Sprite beef;
    public Sprite tomato;
    public Sprite choppedSalad;
    public Sprite choppedTomato;
    public Sprite choppedBeef;

    //process interaction
    public Animation tomatoCutting;
    public Animation saladCutting;
    public Animation beefCutting;

    //Bools
    public bool maxInventoryActive;
    public bool beefCut;
    public bool tomatoCut;
    public bool saladCut;
    public bool cuttingBoardFull;
    public bool cookerFull;
    bool pickUpAllowed;

    public int generatorID;
    public int foodID;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && pickUpAllowed) //checks if e key is pressed while the bool pickUpAllowed is true
        {
            switch (generatorID) //assign this variable in unity editor not in script
            {
                case 1:
                    SaladShelfClick(); //runs SaladShelfClick function
                    break;
                case 2:
                    BunShelfClick(); //runs BunShelfClick function
                    break;
                case 3:
                    BeefShelfClick(); //runs BeefShelfClick function
                    break;
                case 4:
                    TomatoShelfClick(); //runs TomatoShelfClick function
                    break;
                case 5:
                    CookerClick(); //runs CookerClick function
                    break;
                case 6:
                    CuttingBoardClick(); //runs CuttingBoardClick function
                    break;
                default:
                    break;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) //function that triggers when two colliders are touching
    {
        if (collision.gameObject.name.Equals("Player")) //checks if the name of the object who hold the collider is "Player"
        {
            popup.SetActive(true); //sets the popup gameobject to active
            popup.GetComponent<TMPro.TextMeshProUGUI>().text = "E to interact with object";
            pickUpAllowed = true; //sets the bool pickUpAllowed to true so that you can fulfill one of the conditions in the update loop
            Debug.Log("trigger enter"); //debug
        }

    }

    private void OnTriggerExit2D(Collider2D collision) //function that triggers when two colliders leave eachother
    {
        if (collision.gameObject.name.Equals("Player")) //checks if the name of the object who held the collider is "Player"
        {
            popup.SetActive(false); //sets the popup gameobject to false
            pickUpAllowed = false; //sets the bool pickUpAllowed to true so that you can fulfill one of the conditions in the update loop
            Debug.Log("trigger exit"); //debug
        }
    }


    public void SaladShelfClick() //ingredient creation
    {
        Debug.Log("shelf clicked"); //debug
        if (inventory.maxInventoryActive == false) //checks if the player already holds an ingredient
        {
            Debug.Log("you acquired salad"); //debug
            ingredientInventory.GetComponent<Image>().sprite = salad;
            ingredientInventory.GetComponent<Image>().color = Color.white;
            inventory.maxInventoryActive = true; //the player has picked up an ingredient an the inventory is therefore true
            interaction.foodID = 15;
        }
        else
        {
            Debug.Log("inventory is full"); //debug
            maxInvPopUp(); //runs the maxInvPopUp function
        }
    }
    public void BunShelfClick() //ingredient creation
    {
        Debug.Log("shelf clicked"); //debug
        if (inventory.maxInventoryActive == false)
        {
            Debug.Log("you acquired buns"); //debug
            ingredientInventory.GetComponent<Image>().sprite = bun;
            ingredientInventory.GetComponent<Image>().color = Color.white;
            inventory.maxInventoryActive = true; //the player has picked up an ingredient an the inventory is therefore true
            interaction.foodID = 25;
        }
        else
        {
            Debug.Log("inventory is full"); //debug
            maxInvPopUp(); //runs the maxInvPopUp function
        }
    }
    public void BeefShelfClick() //ingredient creation
    {
        Debug.Log("shelf clicked"); //debug
        if (inventory.maxInventoryActive == false)
        {
            Debug.Log("you acquired beef"); //debug
            ingredientInventory.GetComponent<Image>().sprite = beef;
            ingredientInventory.GetComponent<Image>().color = Color.white;
            inventory.maxInventoryActive = true; //the player has picked up an ingredient an the inventory is therefore true
            interaction.foodID = 10;
        }
        else
        {
            Debug.Log("Inventory is full"); //debug
            maxInvPopUp(); //runs the maxInvPopUp function
        }
    }

    public void TomatoShelfClick() //ingredient creation
    {
        Debug.Log("shelf clicked"); //debug
        if (inventory.maxInventoryActive == false) //checks if the player already holds an ingredient
        {
            Debug.Log("you acquired tomato"); //debug
            ingredientInventory.GetComponent<Image>().sprite = tomato;
            ingredientInventory.GetComponent<Image>().color = Color.white;
            inventory.maxInventoryActive = true; //the player has picked up an ingredient an the inventory is therefore true
            interaction.foodID = 20;
        }
        else
        {
            Debug.Log("inventory is full"); //debug
            maxInvPopUp(); //runs the maxInvPopUp function
        }
    }

    public void CookerClick()
    {
        if (beefCut == false && cookerFull == false && interaction.foodID == 10)
        {
            Debug.Log("you begin to cook beef"); //debug
            trash.trashCanSingle();
            cookerFull = true;
            Invoke("ProcessBeef", 3);
        }
        else if (beefCut == true && inventory.maxInventoryActive == false)
        {
            cookerFull = false;
            beefCut = false;
            Debug.Log("Acquired cooked beef");
            ingredientInventory.GetComponent<Image>().sprite = choppedBeef;
            ingredientInventory.GetComponent<Image>().color = Color.white;
            inventory.maxInventoryActive = true; //the player has picked up an ingredient an the inventory is therefore true
            interaction.foodID = 40;
        }

    }

    public void CuttingBoardClick()
    {
        Debug.Log("shelf clicked"); //debug
        switch (interaction.foodID)
        {
            case 15:
                if (saladCut == false && cuttingBoardFull == false)
                {
                    Debug.Log("you begin to cut salad"); //debug
                    trash.trashCanSingle();
                    cuttingBoardFull = true;
                    Invoke("ProcessSalad", 3);
                }
                else if (saladCut == true && inventory.maxInventoryActive == false)
                {
                    cuttingBoardFull = false;
                    saladCut = false;
                    Debug.Log("Acquired chopped salad");
                    ingredientInventory.GetComponent<Image>().sprite = choppedSalad;
                    ingredientInventory.GetComponent<Image>().color = Color.white;
                    inventory.maxInventoryActive = true; //the player has picked up an ingredient an the inventory is therefore true
                    interaction.foodID = 30;
                }
                break;
            case 20:
                if (tomatoCut == false && cuttingBoardFull == false)
                {
                    Debug.Log("you begin to cut tomatoes"); //debug
                    trash.trashCanSingle();
                    cuttingBoardFull = true;
                    Invoke("ProcessTomato", 3);
                }
                else if (tomatoCut == true && inventory.maxInventoryActive == false)
                {
                    cuttingBoardFull = false;
                    tomatoCut = false;
                    Debug.Log("Acquired chopped tomato");
                    ingredientInventory.GetComponent<Image>().sprite = choppedTomato;
                    ingredientInventory.GetComponent<Image>().color = Color.white;
                    inventory.maxInventoryActive = true; //the player has picked up an ingredient an the inventory is therefore true
                    interaction.foodID = 35;
                }
                break;
            default:
                break;
        }
        //if (interaction.foodID == 10)
        //{
        //    Debug.Log("you begin cut vegetables"); //debug
        //}
        //else
        //{
        //    Debug.Log("inventory is full"); //debug
        //    maxInvPopUp(); //runs the maxInvPopUp function
        //}
    }

    public void maxInvPopUp() //ingredient creation
    {
        if (maxInventoryPopUp.activeInHierarchy == false) //checks if the popup is already active in the game and if not runs the following code
        {
            maxInventoryPopUp.SetActive(true); //sets the popup to being active and displayed
            Invoke("maxInvPopUp", 3); //runs the function again after 3 seconds so that the text is only displayed for a certain amount of time
        }
        else if (maxInventoryPopUp.activeInHierarchy == true) ////checks if the popup is already active in the game and if it is runs the following code
        {
            maxInventoryPopUp.SetActive(false); //sets the popup to being false and therefore not displayed
        }
    }
    public void ProcessBeef()
    {
        beefCut = true;
        Debug.Log("Beef cooked");
    }
    public void ProcessSalad()
    {
        saladCut = true;
        Debug.Log("salad chopped");
    }
    public void ProcessTomato()
    {
        tomatoCut = true;
        Debug.Log("tomato chopped");
    }
}
