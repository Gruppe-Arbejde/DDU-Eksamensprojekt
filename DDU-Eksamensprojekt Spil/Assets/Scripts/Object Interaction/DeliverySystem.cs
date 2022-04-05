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
    public OrderSystem orderSystem;

    public bool saladPresent;
    public bool bunPresent;
    public bool beefPresent;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && pickUpAllowed)
        {
            switch (interaction.foodID)
            {
                case 15: //salad
                    saladPresent = true;
                    inventory.maxInventoryActive = false;
                    orderSystem.foodValue += 15;

                    Debug.Log("Salad inserted in bag");
                    break;
                case 25: //bun
                    bunPresent = true;
                    inventory.maxInventoryActive = false;
                    Debug.Log("Bun inserted in bag");
                    orderSystem.foodValue += 25;
                    break;
                case 10: //beef
                    beefPresent = true;
                    inventory.maxInventoryActive = false;
                    Debug.Log("Beef inserted in bag");
                    orderSystem.foodValue += 10;
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
