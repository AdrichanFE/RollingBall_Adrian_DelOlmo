using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorCamara : MonoBehaviour
{
    [SerializeField] GameObject virtualCam1;
    [SerializeField] GameObject virtualCam2;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (virtualCam1.activeSelf)
            {
                virtualCam1.SetActive(false);
                virtualCam2.SetActive(true);
            }
            else
            {
                virtualCam1.SetActive(true);
                virtualCam2.SetActive(false);
            }
            
        }
    }
}
