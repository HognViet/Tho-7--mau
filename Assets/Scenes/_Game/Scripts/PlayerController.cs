using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moverment_Speed = 3.5f;
    private Vector3 moverment = Vector3.zero;
    private Vector3 flipRight = new Vector3(1, 1, 1);
    private Vector3 flipLeft = new Vector3(-1, 1, 1);

    [SerializeField] private Camera playerCamera;
    private Vector3 cameraOffset = new Vector3(0, 0, -10);

    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Moverment();
        Flip();
    }
    void Moverment()
    {
        // di chuyen can thiep toa do
        //
        //if (Input.GetKey(KeyCode.A))
        //{
        //    moverment.x = -moverment_Speed;
        //}
        //if(Input.GetKey(KeyCode.D))
        //{
        //    moverment.x = moverment_Speed;
        //}
        //this.transform.Translate(moverment * Time.deltaTime);
        // di chuyen camera
        playerCamera.transform.position = this.transform.position + cameraOffset;
        // di chuyen can thiep physics
        if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocity = new Vector2(moverment_Speed, 0);
            moverment.x = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocity = new Vector2(-moverment_Speed, 0);
            moverment.x = -1;
        }
        else rb.linearVelocity = new Vector2(0, 0);
    }
    void Flip()
    {
        
        if(moverment.x > 0)
        {
            this.transform.localScale = flipRight;
        }
        else if(moverment.x < 0)
        {
            this.transform.localScale = flipLeft;
        }
    }
    
}
