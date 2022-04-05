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
    public int saladID;
    public int bunID;
    public int beefID;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && pickUpAllowed)
        {
            switch (generatorID) //assign this variable in unity editor not in script
            {
                case 1:
                    SaladShelfClick();
                    break;
                case 2:
                    BunShelfClick();
                    break;
                case 3:
                    BeefShelfClick();
                    break;
                default:
                    break;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            popup.SetActive(true);
            pickUpAllowed = true;
            Debug.Log("trigger enter");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            popup.SetActive(false);
            pickUpAllowed = false;
            Debug.Log("trigger exit");
        }
    }


    public void SaladShelfClick()
    {
        Debug.Log("shelf clicked");
        if (inventory.maxInventoryActive == false)
        {
            Debug.Log("you acquired salad");
            boxUI.transform.GetChild(0).gameObject.SetActive(true); //sets first child object[0] of Box to active
            inventory.maxInventoryActive = true;
        }
        else
        {
            Debug.Log("inventory is full");
            maxInvPopUp();
        }
    }
    public void BunShelfClick()
    {
        Debug.Log("shelf clicked");
        if (inventory.maxInventoryActive == false)
        {
            Debug.Log("you acquired buns");
            boxUI.transform.GetChild(1).gameObject.SetActive(true); //sets first child object[1] of Box to active
            inventory.maxInventoryActive = true;
        }
        else
        {
            Debug.Log("inventory is full");
            maxInvPopUp();
        }
    }
    public void BeefShelfClick()
    {
        Debug.Log("shelf clicked");
        if (inventory.maxInventoryActive == false)
        {
            Debug.Log("you acquired beef");
            boxUI.transform.GetChild(2).gameObject.SetActive(true); //sets first child object[2] of Box to active
            inventory.maxInventoryActive = true;
        }
        else
        {
            Debug.Log("Inventory is full");
            maxInvPopUp();
        }
    }

    public void maxInvPopUp()
    {
        if (maxInventoryPopUp.activeInHierarchy == false)
        {
            maxInventoryPopUp.SetActive(true);
            Invoke("maxInvPopUp", 5);
        }
        else if (maxInventoryPopUp.activeInHierarchy == true)
        {
            maxInventoryPopUp.SetActive(false);
        }
    }
}
