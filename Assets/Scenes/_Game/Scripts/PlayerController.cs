using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moverment_Speed = 3.5f;
    private Vector3 moverment = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Moverment();
    }
    void Moverment()
    {
        // di chuyen 
        if(Input.GetKey(KeyCode.A))
        {
            moverment.x = -moverment_Speed;
        }
        if(Input.GetKey(KeyCode.D))
        {
            moverment.x = moverment_Speed;
        }
        this.transform.Translate(moverment * Time.deltaTime);
    }
}
