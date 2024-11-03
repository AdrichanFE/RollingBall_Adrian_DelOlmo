using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanManager : MonoBehaviour
{

    [Header("Options")]
    public Slider volumeMaster;
    public Toggle mute;
    public Toggle fullScreen;
    public AudioMixer mixer;
    private float lastVolume;

    private void Awake()
    {
        volumeMaster.onValueChanged.AddListener(CambiarVolumen);
    }

    private void Start()
    {
        if (Screen.fullScreen)
        {
            fullScreen.isOn = true;
        }
        else
        {
            fullScreen.isOn=false;
        }
    }

    public void ActivarFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }


    public void SetMute()
    {
        
        if (mute.isOn)
        {
            mixer.GetFloat("VolumeMaster", out lastVolume);
            mixer.SetFloat("VolumeMaster", -80);
        }    
        else
            mixer.SetFloat("VolumeMaster", lastVolume);


    }
    public void CambiarVolumen(float v)
    {
        mixer.SetFloat("VolumeMaster", v);
    }

    public void EmpezarPartida()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }
    public void TerminarJuego()
    {
        Application.Quit();
    }


}
