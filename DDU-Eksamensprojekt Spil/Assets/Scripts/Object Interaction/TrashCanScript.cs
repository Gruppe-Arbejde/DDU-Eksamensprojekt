using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashCanScript : MonoBehaviour
{
    bool pickUpAllowed;
    public GameObject ingredientImage;
    public AudioManager audioManager; 
    public GameObject popup;
    public IngredientInteraction interaction;
    public MaxInventoryManager maxInventoryManager;
    Color32 noColor = new Color32(149, 111, 77, 255);

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && pickUpAllowed)
        {
            ingredientImage.GetComponent<Image>().sprite = null;
            maxInventoryManager.maxInventoryActive = false;
            ingredientImage.GetComponent<Image>().color = noColor;
            audioManager.Play("player pickup");
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

    public void trashCanSingle()
    {
        ingredientImage.GetComponent<Image>().sprite = null;
        ingredientImage.GetComponent<Image>().color = noColor;
        maxInventoryManager.maxInventoryActive = false;
    }
}
