using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform wallCheck;
    [SerializeField] Transform wallCheck2;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask wallLayer;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * moveSpeed, rb.velocity.y, verticalInput * moveSpeed);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Jump();
        }

        /*
         wallrun attempt
         if (Input.GetButton("left") && Input.GetButton("right") && Input.GetButton("up") && isWallrun())
        {
            rb.velocity = new Vector3(horizontalInput * moveSpeed, -0.1f, verticalInput * moveSpeed);
        }

        if (Input.GetButton("left") && Input.GetButton("right") && Input.GetButton("up") && isWallrun2())
        {
            rb.velocity = new Vector3(horizontalInput * moveSpeed, -0.01f, verticalInput * moveSpeed);
        }
        */
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyHead"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

    bool isGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, groundLayer);
    }
    
    bool isWallrun()
    {
        return Physics.CheckSphere(wallCheck.position, 0.5f, wallLayer);
    }

    bool isWallrun2()
    {
        return Physics.CheckSphere(wallCheck2.position, 0.5f, wallLayer);
    }
}
