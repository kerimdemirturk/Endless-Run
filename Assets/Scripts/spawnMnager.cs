using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMnager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(15, 0, 0);
    public float lateTime = 2;
    public float repeatRate = 2;
    private playerController Playercontollerscript;//playerscript e referance verdik

    void Start()
    {
        Playercontollerscript = GameObject.Find("Player").GetComponent<playerController>();//spawn edilmesini yine player daki gameovera baðlýcaz
        InvokeRepeating("spawnManager", lateTime, repeatRate);
    }

    
    void Update()
    {
        
    }
    void spawnManager()
    {
        if(Playercontollerscript.gameover==false)//game over olmadýðýmýzda spawn edilebilcek sadece.
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
        
    }
}
