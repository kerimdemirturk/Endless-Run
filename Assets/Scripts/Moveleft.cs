using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveleft : MonoBehaviour

{
    //bu script dosyas�n� bacgroundada veriyoruz ��n� sanki bacgrounda ilerliyor gibi il�zyon yaratmak i�in.yani hem background hemde obstaaclere veriyoruz.ama bacg ground ve abstacl�n speedini de�i� yoksa ayn� h�z olur ve hi�bi�i anlayamass�n unutma.
    public float barrelSpeed;
    public float leftBound = -15;
    private playerController PlayerControllerScript;//player controller scriptine referans veriyoruz.
    
    void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<playerController>();//bu script playera etki ediyor.ONu dedik
    }

    
    void Update()
    {
        if(PlayerControllerScript.gameover==false)//game over olmad���nda bacground ilerlicek b�ylece.
        {
            transform.Translate(Vector3.left * Time.deltaTime * barrelSpeed);
        }
        if(transform.position.x<leftBound && gameObject.CompareTag("Obstacle"))//e�er ground un  x'i leftbondan k���k olursa ve bu obstacle ise obstacel i yok et. 
        {
            Destroy(gameObject);
        }

        
    }
}
