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

        if(grabCheck.collider != null && grabCheck.collider.tag == "Box")
        {
            if (!Input.GetKey(KeyCode.G))
            {
                grabCheck.collider.gameObject.transform.parent = null;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }
            else
            {
                grabCheck.collider.gameObject.transform.parent = boxHolder;
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
        }

        if (grabCheck.collider.tag == "Box" && Input.GetKey(KeyCode.J))
        {
            grabCheck.collider.gameObject.GetComponent<SpriteRenderer>().sprite = cut;
        }
    }
}
