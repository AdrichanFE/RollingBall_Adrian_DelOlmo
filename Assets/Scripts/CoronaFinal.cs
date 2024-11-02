using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoronaFinal : MonoBehaviour
{
    [SerializeField] float velocidad,velocidadRotacion;
    [SerializeField] Vector3 direccionRotacion;
    [SerializeField] Vector3 direccion;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(direccionRotacion * velocidadRotacion * Time.deltaTime, Space.World);

        transform.Translate(direccion * velocidad * Time.deltaTime, Space.World);
        timer += Time.deltaTime;
        if (timer >= 3f)
        {
            direccion *= -1;
            timer = 0;
        }
    }
}