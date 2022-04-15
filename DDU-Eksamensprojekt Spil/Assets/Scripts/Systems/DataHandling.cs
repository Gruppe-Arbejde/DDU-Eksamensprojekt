using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataHandling : MonoBehaviour
{
    public static float totalScore;
    public DeliverySystem deliverySystem;
    public OrderSystem orderSystem;
    public MaxInventoryManager maxInventoryManager;

    //Checklist GameObjects
    public GameObject salad;
    public GameObject bun;
    public GameObject beef;
    public GameObject tomato;
    //ingredient images
    public GameObject saladImage;
    public GameObject bunImage;
    public GameObject beefImage;
    public GameObject tomatoImage;
    //
    public GameObject ingredientImage;
    Color32 grayColor = new Color32(65, 65, 65, 255);
    //public bool maxInventoryActive;


    public void RecipeChecklistImageHandling()
    {
        switch (orderSystem.recipeID)
        {
            case 0:
                salad.SetActive(true);
                bun.SetActive(true);
                beef.SetActive(true);
                tomato.SetActive(false);
                break;
            case 1:
                salad.SetActive(true);
                bun.SetActive(false);
                beef.SetActive(false);
                tomato.SetActive(false);
                break;
            case 2:
                salad.SetActive(false);
                bun.SetActive(false);
                beef.SetActive(true);
                tomato.SetActive(false);
                break;
            case 3:
                salad.SetActive(false);
                bun.SetActive(false);
                beef.SetActive(false);
                tomato.SetActive(true);
                break;
            default:
                break;
        }
    }
    public void RecipeCheckHandling()
    {
        switch (deliverySystem.lastFoodInserted)
        {
            case 10: //beef
                beefImage.GetComponent<Image>().color = Color.white;
                break;
            case 15: //salad
                saladImage.GetComponent<Image>().color = Color.white;
                break;
            case 20: //tomato
                tomatoImage.GetComponent<Image>().color = Color.white;
                break;
            case 25: //bun
                bunImage.GetComponent<Image>().color = Color.white;
                break;
            default:
                break;
        }
    }

    public void RecipeChecklistColorCorrect()
    {
        ingredientImage.GetComponent<Image>().sprite = null;
        maxInventoryManager.maxInventoryActive = false;
        beefImage.GetComponent<Image>().color = grayColor;
        saladImage.GetComponent<Image>().color = grayColor;
        tomatoImage.GetComponent<Image>().color = grayColor;
        bunImage.GetComponent<Image>().color = grayColor;
    }
}
