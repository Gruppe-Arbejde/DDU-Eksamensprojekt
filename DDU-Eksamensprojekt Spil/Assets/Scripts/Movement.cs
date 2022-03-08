using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb; //so that we can interact with the component in unity
    public Animator animator;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        //input handling
        movement.x = Input.GetAxisRaw("Horizontal"); //gives value between -1 and 1 depending on what key is pressed
        movement.y = Input.GetAxisRaw("Vertical"); //gives value between -1 and 1 depending on what key is pressed

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);//checks length of vector which is our speed
    }

    private void FixedUpdate() //as update can have fluctuating frame rate fixed update is used instead as it is always called 50 times a second
    {
        //movement calculation
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); //fixedDeltaTime is to assure a constant movement speed
    }
}
