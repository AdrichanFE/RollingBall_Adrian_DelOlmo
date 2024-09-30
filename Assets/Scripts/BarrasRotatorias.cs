using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrasRotatorias : MonoBehaviour
{
    float timer;
    [SerializeField] float velocidad;
    [SerializeField] Vector3 direccionRotacion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(direccionRotacion * velocidad * Time.deltaTime);//,Space.World);
        //if (timer >= 2.5)
        //{
        //    direccionRotacion*=;
        //    timer = 0;
        //}
    }
}
