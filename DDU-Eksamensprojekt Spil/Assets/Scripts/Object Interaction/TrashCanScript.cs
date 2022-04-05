using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanScript : MonoBehaviour
{
    bool pickUpAllowed;

    public GameObject popup;
    public GameObject ingredientInteraction;

    public void TrashCanClick()
    {

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
