using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuroRompible : MonoBehaviour
{
    [SerializeField] float tiempoBala;
    private float timer = 0f;
    private bool iniciarCuenta = false;
    [SerializeField] private Rigidbody[] rbs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (iniciarCuenta)
        {
            timer += 1 * Time.unscaledDeltaTime;//Con este contador no le afecta el tiempo bala
            if (timer >= 2f)
            {
                Time.timeScale = 1f;
                for (int i = 0; i < rbs.Length; i++)
                {
                    rbs[i].useGravity = true;
                }
                
                
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Time.timeScale = tiempoBala;
            iniciarCuenta=true;
           
        }

        

        
    }
}
