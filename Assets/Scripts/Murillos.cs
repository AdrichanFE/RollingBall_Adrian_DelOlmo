using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murillos : MonoBehaviour
{

    [SerializeField] private Rigidbody[] rbs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            for (int i = 0; i < rbs.Length; i++)
            {
                rbs[i].useGravity = true;
            }

        }
    }
}
