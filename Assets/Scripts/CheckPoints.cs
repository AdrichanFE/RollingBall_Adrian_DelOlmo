using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{

   public List<Vector3> positions = new List<Vector3>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            positions.Add(transform.position);
            Debug.Log("Si lo ha detectado");
        }
    }


}
