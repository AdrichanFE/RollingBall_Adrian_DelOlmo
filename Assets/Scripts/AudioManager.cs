using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioSource sfx;
    [SerializeField] AudioSource sfx2;
  

    public void ReproducirSonido(AudioClip musicalNote)
    {
        //Ejecuta el clip introducido por parametro de entrada
        sfx.PlayOneShot(musicalNote);
    }

    public void ReproducirSonidoVictoria(AudioClip sonidoVictoria)
    {
        sfx2.PlayOneShot(sonidoVictoria);
    }
 
}
