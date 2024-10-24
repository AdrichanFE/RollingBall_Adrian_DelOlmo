using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [SerializeField] GameObject virtualCamNormal;
    [SerializeField] GameObject virtualCam2;
    [SerializeField] GameObject virtualCam3;
    [SerializeField] GameObject virtualCamCenital;
    public Player player;


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if (virtualCamNormal.activeSelf)
            {
                player.esVistaCenital = true;
                virtualCamNormal.SetActive(false);
                virtualCamCenital.SetActive(true);
            }
            else
            {
                player.esVistaCenital = false;
                virtualCamNormal.SetActive(true);
                virtualCamCenital.SetActive(false);
            }

        }
        
    }
    


   

}
