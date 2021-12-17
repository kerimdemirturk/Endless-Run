using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatBacground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWide;
    void Start()
    {
        startPos = transform.position;
        repeatWide = GetComponent<BoxCollider>().size.x / 2;//kolayca yar� yolda yenilenmeseini hesaplamak istedi�imiz i�in box collider ekledi bacgrounda-
    }                                                       //sonras�ndada box collidera ula�d�k ve onun x axisindeki size'�n�n  yar�s�n� ald�k sonras�dada offset olarak if'e ekledik.

    
    void Update()
    {
        if(transform.position.x<startPos.x-repeatWide)
        {
            transform.position = startPos;
        }
            
    }
}
