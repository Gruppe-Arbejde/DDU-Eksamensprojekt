using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanScript : MonoBehaviour
{
    bool pickUpAllowed;

    public GameObject popup;
    public IngredientInteraction interaction;
    public MaxInventoryManager inventory;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && pickUpAllowed)
        {
            interaction.boxUI.transform.GetChild(0).gameObject.SetActive(false);
            interaction.boxUI.transform.GetChild(1).gameObject.SetActive(false);
            interaction.boxUI.transform.GetChild(2).gameObject.SetActive(false);
            inventory.maxInventoryActive = false;
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
