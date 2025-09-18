using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 4.5f;
    [SerializeField] private float jumpForce = 5f;


    private Vector2 movementInput;
    [SerializeField] private bool isJump = false;
    [SerializeField] private bool isGround = false;

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
        if (rb.linearVelocityY > 0.01f)
        {
            rb.gravityScale = 1.25f;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocityX = movementInput.x * movementSpeed;

        if (isJump && isGround)
        {
            rb.linearVelocityY = jumpForce;
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
        if ((collision.gameObject.CompareTag("Ground")))
        {
            isGround = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Cham vo quai");
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Spike"))
        {
            Debug.Log("Cham vo dau gai");
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Ban da win");

        }
    }
        private void OnCollisionExit2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Ground")))
        {
            isGround = false;
        }
    } 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Debug.Log("Cham vo coin");
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Ban da win");

        }
    }
}


