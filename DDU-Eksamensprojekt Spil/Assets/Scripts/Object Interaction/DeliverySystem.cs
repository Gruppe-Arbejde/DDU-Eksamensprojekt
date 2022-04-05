using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverySystem : MonoBehaviour
{
    //Variable creation
    bool pickUpAllowed;
    public GameObject popup;
    public MaxInventoryManager inventory;
    public IngredientInteraction interaction;
 
    public TrashCanScript trash;

    public int foodValue;

    public bool saladPresent = false;
    public bool bunPresent = false;
    public bool beefPresent = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && pickUpAllowed)
        {
            switch (interaction.foodID)
            {
                case 15: //salad
                    if (saladPresent == false)
                    {
                        saladPresent = true;
                        inventory.maxInventoryActive = false;
                        foodValue += 15;
                        Debug.Log("Salad inserted in bag");
                        trash.trashCanSingle();
                    }
                    else
                    {
                        Debug.Log("Salad already present");
                    }
                    break;
                case 25: //bun
                    if (bunPresent == false)
                    {
                        bunPresent = true;
                        inventory.maxInventoryActive = false;
                        Debug.Log("Bun inserted in bag");
                        foodValue += 25;
                        trash.trashCanSingle();
                    }
                    else
                    {
                        Debug.Log("Salad already present");
                    }
                    break;
                case 10: //beef
                    if (beefPresent == false)
                    {
                        beefPresent = true;
                        inventory.maxInventoryActive = false;
                        Debug.Log("Beef inserted in bag");
                        foodValue += 10;
                        trash.trashCanSingle();
                    }
                    else
                    {
                        Debug.Log("Salad already present");
                    }
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
}
