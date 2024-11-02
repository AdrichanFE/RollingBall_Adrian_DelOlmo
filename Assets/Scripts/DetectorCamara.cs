using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorCamara : MonoBehaviour
{
    [SerializeField] GameObject CamaraEncendido;
    [SerializeField] GameObject CamaraApagado;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (CamaraEncendido.activeSelf)
            {
                CamaraEncendido.SetActive(false);
                CamaraApagado.SetActive(true);
                Debug.Log("Detectado");
            }
            else
            {
                CamaraEncendido.SetActive(true);
                CamaraApagado.SetActive(false);
            }
            
        }
    }
}
