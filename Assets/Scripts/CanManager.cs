using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanManager : MonoBehaviour
{
    public void EmpezarPartida()
    {
        SceneManager.LoadScene(1);
    }
    public void TerminarJuego()
    {
        Application.Quit();
    }


}
