using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionables : MonoBehaviour
{
    float timer;
    [SerializeField] float velocidad,velocidadRotacion;
    [SerializeField] Vector3 direccionRotacion;
    [SerializeField] Vector3 direccion;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(direccionRotacion * velocidadRotacion * Time.deltaTime,Space.World);
        
        transform.Translate(direccion * velocidad * Time.deltaTime,Space.World);
        timer += Time.deltaTime;
        if (timer >= 0.9f)
        {
            direccion *= -1;
            timer = 0;
        }
    }
}
