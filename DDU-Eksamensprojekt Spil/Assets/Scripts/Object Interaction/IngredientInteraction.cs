using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngredientInteraction : MonoBehaviour
{
    //Variable creation
    public GameObject boxUI;
    public GameObject popup;
    public GameObject maxInventoryPopUp;
    public MaxInventoryManager inventory;

    public bool maxInventoryActive;
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
            boxUI.transform.GetChild(0).gameObject.SetActive(true); //sets first child object[0] of Box to active
            inventory.maxInventoryActive = true; //the player has picked up an ingredient an the inventory is therefore true
            foodID = 15;
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
            boxUI.transform.GetChild(1).gameObject.SetActive(true); //sets first child object[1] of Box to active
            inventory.maxInventoryActive = true; //the player has picked up an ingredient an the inventory is therefore true
            foodID = 25;
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
            boxUI.transform.GetChild(2).gameObject.SetActive(true); //sets first child object[2] of Box to active
            inventory.maxInventoryActive = true; //the player has picked up an ingredient an the inventory is therefore true
            foodID = 10;
        }
        else
        {
            Debug.Log("Inventory is full"); //debug
            maxInvPopUp(); //runs the maxInvPopUp function
        }
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
}
