using System;
using UnityEngine;
using UnityEngine.UI;

public class GrabController : MonoBehaviour
{
    #region Variables
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;
    public Sprite cut;
    public bool grabToggle = false;

    #endregion

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);

        if (grabCheck.collider != null && grabCheck.collider.tag == "Box")
        {
            if (Input.GetKey(KeyCode.F))
                if (!grabToggle)
                    grabToggle = true;
                else
                    grabToggle = false;

            OnChangeValue();
        }
    }

    public void OnChangeValue()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);
        if (grabToggle)
        {
            grabCheck.collider.gameObject.transform.parent = boxHolder;
            grabCheck.collider.gameObject.transform.position = boxHolder.position;
            grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            print("Box Grabbed = True"); // Debugging
        }
        if (!grabToggle)
        {
            grabCheck.collider.gameObject.transform.parent = null;
            grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            print("Box Grabbed = False"); // Debugging
        }
        if (grabCheck.collider != null && grabCheck.collider.tag == "Box")
        {
            if (Input.GetKey(KeyCode.E))
            {
                grabCheck.collider.gameObject.GetComponent<SpriteRenderer>().sprite = cut;
                print("Box Cut = True"); // Debugging
            }
        }
    }

}