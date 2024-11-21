using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Transform playerCamera;
    float xRotation = 0f;

    public float mouseSens;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    
    [SerializeField] AudioSource jumpSound;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Jump();
        }

        rb.velocity = new Vector3(horizontalInput * moveSpeed, rb.velocity.y, verticalInput * moveSpeed);

        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;

        transform.Rotate(Vector3.up * mouseX);

        

    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpSound.Play();
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
    
}
