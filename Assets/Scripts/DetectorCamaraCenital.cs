using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorCamaraCenital : MonoBehaviour
{

    [SerializeField] GameObject virtualCam1;
    [SerializeField] GameObject virtualCamCenital;
    public Player player;


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if (virtualCam1.activeSelf)
            {
                player.esVistaCenital = true;
                virtualCam1.SetActive(false);
                virtualCamCenital.SetActive(true);
            }
            else
            {
                player.esVistaCenital = false;
                virtualCam1.SetActive(true);
                virtualCamCenital.SetActive(false);
            }

        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
           



    //    }
    //}

}
