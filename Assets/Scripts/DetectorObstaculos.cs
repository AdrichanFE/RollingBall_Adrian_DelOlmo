using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorObstaculos : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstaculo"))
        {
            Destroy(other.gameObject);
        }

        
    }
}
