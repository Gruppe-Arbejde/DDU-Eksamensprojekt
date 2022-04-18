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
    public DataHandling dataHandling;
    public TrashCanScript trash;
    public AudioManager audioManager;

    public int foodValue;
    public int lastFoodInserted;

    public bool saladPresent = false;
    public bool bunPresent = false;
    public bool beefPresent = false;
    public bool tomatoPresent = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && pickUpAllowed)
        {
            switch (interaction.foodID)
            {
                case 30: //salad
                    if (saladPresent == false)
                    {
                        saladPresent = true;
                        inventory.maxInventoryActive = false;
                        foodValue += 30;
                        Debug.Log("Salad inserted in bag");
                        trash.trashCanSingle();
                        lastFoodInserted = 30;
                        dataHandling.RecipeCheckHandling();
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
                        lastFoodInserted = 25;
                        dataHandling.RecipeCheckHandling();
                    }
                    else
                    {
                        Debug.Log("Salad already present");
                    }
                    break;
                case 40: //beef
                    if (beefPresent == false)
                    {
                        beefPresent = true;
                        inventory.maxInventoryActive = false;
                        Debug.Log("Beef inserted in bag");
                        foodValue += 40;
                        trash.trashCanSingle();
                        lastFoodInserted = 40;
                        dataHandling.RecipeCheckHandling();
                    }
                    else
                    {
                        Debug.Log("Salad already present");
                    }
                    break;
                case 35: //tomato
                    if (tomatoPresent == false)
                    {
                        tomatoPresent = true;
                        inventory.maxInventoryActive = false;
                        Debug.Log("Tomato inserted in bag");
                        foodValue += 35;
                        trash.trashCanSingle();
                        lastFoodInserted = 35;
                        dataHandling.RecipeCheckHandling();
                    }
                    else
                    {
                        Debug.Log("Tomato already present");
                    }
                    break;
                default:
                    break;
            }
            audioManager.Play("player pickup");
        }
        if (Input.GetKeyDown(KeyCode.E) && pickUpAllowed)
        {

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
