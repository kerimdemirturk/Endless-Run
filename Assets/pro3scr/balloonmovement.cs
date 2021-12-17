using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonmovement : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public float verticalInput;


    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            verticalInput = Input.GetAxisRaw("Vertical");
            transform.Translate(Vector3.up * verticalInput * speed);
        }
    }
}
