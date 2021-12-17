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
    private bool isOnGround = true;//1)double jump ý engellemek için bool yarattýk ve true dedik
    public bool gameover;
   
    
    
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();//componente ulaþdýk
        Physics.gravity *= gravitymodifier; //1) *= þu demek--physics.gravity=physics.gravity*gravitymodifier--yani bunu kolay yazamak istedik bu sembolle.2)physic deki gravitye eriþdik ve ona kendimiz rakam vericez.
        playerAnim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }



   
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space)&&isOnGround&&!gameover)//2)eðer space e basarsan ve isonground true ise aþaðýdaki zýplama olur.
        {
            playerRB.AddForce(Vector3.up *jumpForce,ForceMode.Impulse);//forcemod olayý vermek istediðimiz forc u daha etkili etmek için.çeþitleri  var biz ýmpulse kullandýk.
            isOnGround = false;//3)bir kez zýpladýmý false a  dönücek ve havada ikinciyi edemicek.
            playerAnim.SetTrigger("Jump_trig");
            dirtparticle.Stop();
            audio.PlayOneShot(jumpSound, 1);
        }
        
    }

    private void OnCollisionEnter(Collision collision)//4)yere döndüðünde tekrarr zýplama truye dönsün diye dedikki collidera deðersen yine true ol.
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
            playerAnim.SetBool("Death_b", true);//death layerýndan bakýp bu ve aþaðýdaki þartlarý saðladýðýnda çalýþdýðýný görüyoruz bu sebeple settbool ve setýnteger yazdýk.
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtparticle.Stop();
            audio.PlayOneShot(crashsound, 1);

        }
            
        
    }
}
