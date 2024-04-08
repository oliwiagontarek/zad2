using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capybara_movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private bool isGrounded = false;
    private float moveSpeed = 5f;
    private float upForce = 500f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * upForce);
            isGrounded = false;
        }


        float velocityX = Input.GetAxis("Horizontal") * moveSpeed;

        rb.velocity = new Vector2(velocityX, rb.velocity.y);

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Danger"))
        {
            Destroy(this.gameObject);
            Debug.Log("niezbadane s¹ wyroki bo¿e");
        }

        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log(10); 
        }
    }
}