using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public AudioSource RadioFile;

    void Awake()
    {
        RadioFile.time = Random.Range(0f, RadioFile.clip.length);
        RadioFile.Play();        
    }
}
