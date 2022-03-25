using UnityEngine;

public class GrabController : MonoBehaviour
{
    #region Variables
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;
    public Sprite cut;
    #endregion

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);

        if (grabCheck.collider != null && grabCheck.collider.tag == "Box")
        {
            if (!Input.GetKey(KeyCode.F))
            {
                grabCheck.collider.gameObject.transform.parent = null;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                print("Box Grabbed = False"); // Debugging
            }
            else
            {
                grabCheck.collider.gameObject.transform.parent = boxHolder;
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                print("Box Grabbed = True"); // Debugging
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
}
