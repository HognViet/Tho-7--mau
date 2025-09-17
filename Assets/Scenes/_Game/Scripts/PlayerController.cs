using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 4.5f;
    [SerializeField] private float jumpForce = 5f;

    private Vector2 movementInput;
   [SerializeField] private bool isJump = false;
    [SerializeField]private bool isGround = false;

    private Rigidbody2D rb;

    private Vector3 flipRight = new Vector3(1, 1, 1);
    private Vector3 flipLeft = new Vector3(-1, 1, 1);

    private Camera playerCamera;
    [SerializeField] private Vector3 cameraOffset = new Vector3(0, 0, -10);

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCamera = Camera.main;
        rb.freezeRotation = true;
    }

    private void Update()
    {

        movementInput.x = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;
        }

        Flip();

        playerCamera.transform.position = transform.position + cameraOffset;
    }

    private void FixedUpdate()
    {
        rb.linearVelocityX = movementInput.x * movementSpeed;

        if (isJump && isGround)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJump = false;
        }
    }

    private void Flip()
    {
        if (movementInput.x > 0)
            transform.localScale = flipRight;
        else if (movementInput.x < 0)
            transform.localScale = flipLeft;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {       
           isGround = true;       
    }
    private void OnCollisionExit2D(Collision2D collision)
    {       
            isGround = false;
    }
}
