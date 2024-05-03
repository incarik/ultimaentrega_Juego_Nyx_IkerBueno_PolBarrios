using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandera : MonoBehaviour
{
    AudioSource source;
    public AudioClip lvl1Music;
    public AudioClip victory;

    // Start is called before the first frame update
   
     void Awake()
    {
        source = GetComponent<AudioSource>();
    }
     void Start()
    {
        source.clip = lvl1Music;
        source.Play();
  

    }
    void OnTriggerEnter2D(Collider2D collider)
    {   
        source.clip = victory;
        source.Play();

    }
    
}
