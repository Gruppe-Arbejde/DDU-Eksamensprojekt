using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x =  Input.GetAxisRaw("Horizontal"); //gives value between -1 and 1 depending on what key is pressed
        movement.y = Input.GetAxisRaw("Vertical"); //gives value between -1 and 1 depending on what key is pressed
    }

    void FixedUpdate() //as update can have fluctuating frame rate fixed update is used instead as it is always called 50 times a second
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); //fixedDeltaTime is to assure a constant movement speed
    }
}
