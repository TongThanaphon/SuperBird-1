using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource scoreSound;
    public AudioSource deadSound;
    public AudioSource bg;
    public void Play(string name){
        if(name == "score"){
            scoreSound.Play();
        }
        if(name == "dead"){
            deadSound.Play();
        }
    }

    public void Stop(string name){
        if(name == "bg"){
            bg.Stop();
        }
    }
}
