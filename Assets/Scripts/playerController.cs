using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody playerRB;//rigidbodyimize isim verdik
    public float jumpForce;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtparticle;
    public AudioClip jumpSound;
    public AudioClip crashsound;
    private AudioSource audio;
    public float gravitymodifier;
    private bool isOnGround = true;//1)double jump � engellemek i�in bool yaratt�k ve true dedik
    public bool gameover;
   
    
    
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();//componente ula�d�k
        Physics.gravity *= gravitymodifier; //1) *= �u demek--physics.gravity=physics.gravity*gravitymodifier--yani bunu kolay yazamak istedik bu sembolle.2)physic deki gravitye eri�dik ve ona kendimiz rakam vericez.
        playerAnim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }



   
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space)&&isOnGround&&!gameover)//2)e�er space e basarsan ve isonground true ise a�a��daki z�plama olur.
        {
            playerRB.AddForce(Vector3.up *jumpForce,ForceMode.Impulse);//forcemod olay� vermek istedi�imiz forc u daha etkili etmek i�in.�e�itleri  var biz �mpulse kulland�k.
            isOnGround = false;//3)bir kez z�plad�m� false a  d�n�cek ve havada ikinciyi edemicek.
            playerAnim.SetTrigger("Jump_trig");
            dirtparticle.Stop();
            audio.PlayOneShot(jumpSound, 1);
        }
        
    }

    private void OnCollisionEnter(Collision collision)//4)yere d�nd���nde tekrarr z�plama truye d�ns�n diye dedikki collidera de�ersen yine true ol.
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtparticle.Play();
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameover = true;
            Debug.Log("GAME OVER!");
            playerAnim.SetBool("Death_b", true);//death layer�ndan bak�p bu ve a�a��daki �artlar� sa�lad���nda �al��d���n� g�r�yoruz bu sebeple settbool ve set�nteger yazd�k.
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtparticle.Stop();
            audio.PlayOneShot(crashsound, 1);

        }
            
        
    }
}
