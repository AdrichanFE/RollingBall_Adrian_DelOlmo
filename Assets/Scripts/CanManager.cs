using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CanManager : MonoBehaviour
{

    [Header("Options")]
    public Slider volumeMaster;
    public Toggle mute;
    public Toggle fullScreen;
    public AudioMixer mixer;
    private float lastVolume;
    public TMP_Dropdown resolucionesDrop;
    Resolution[] resoluciones;

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
        RevisarResoluciones();
    }

    public void ActivarFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    public void RevisarResoluciones()
    {
        resoluciones = Screen.resolutions;
        resolucionesDrop.ClearOptions();
        List<string> opciones = new List<string>();
        int resolucionActual = 0;

        for (int i = 0; i < resoluciones.Length; i++)
        {
            string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
            opciones.Add(opcion);

            if(Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height)
            {
                resolucionActual = i;
            }
        }
        resolucionesDrop.AddOptions(opciones);
        resolucionesDrop.value = resolucionActual;
        resolucionesDrop.RefreshShownValue();

        resolucionesDrop.value = PlayerPrefs.GetInt("numeroResolucion", 0);
    }

    public void CambiarResolucion(int indiceResolucion)
    {
        PlayerPrefs.SetInt("numeroResolucion", resolucionesDrop.value);


        Resolution resolucion = resoluciones[indiceResolucion];
        Screen.SetResolution(resolucion.width,resolucion.height,Screen.fullScreen);
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
