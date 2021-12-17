using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveleft : MonoBehaviour

{
    //bu script dosyasýný bacgroundada veriyoruz çünü sanki bacgrounda ilerliyor gibi ilüzyon yaratmak için.yani hem background hemde obstaaclere veriyoruz.ama bacg ground ve abstaclýn speedini deðiþ yoksa ayný hýz olur ve hiçbiþi anlayamassýn unutma.
    public float barrelSpeed;
    public float leftBound = -15;
    private playerController PlayerControllerScript;//player controller scriptine referans veriyoruz.
    
    void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<playerController>();//bu script playera etki ediyor.ONu dedik
    }

    
    void Update()
    {
        if(PlayerControllerScript.gameover==false)//game over olmadýðýnda bacground ilerlicek böylece.
        {
            transform.Translate(Vector3.left * Time.deltaTime * barrelSpeed);
        }
        if(transform.position.x<leftBound && gameObject.CompareTag("Obstacle"))//eðer ground un  x'i leftbondan küçük olursa ve bu obstacle ise obstacel i yok et. 
        {
            Destroy(gameObject);
        }

        
    }
}
