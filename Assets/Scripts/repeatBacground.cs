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
        repeatWide = GetComponent<BoxCollider>().size.x / 2;//kolayca yarý yolda yenilenmeseini hesaplamak istediðimiz için box collider ekledi bacgrounda-
    }                                                       //sonrasýndada box collidera ulaþdýk ve onun x axisindeki size'ýnýn  yarýsýný aldýk sonrasýdada offset olarak if'e ekledik.

    
    void Update()
    {
        if(transform.position.x<startPos.x-repeatWide)
        {
            transform.position = startPos;
        }
            
    }
}
