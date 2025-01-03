using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rodillo : MonoBehaviour
{
    float timer;
    [SerializeField] float velocidad;
    [SerializeField] Vector3 direccion;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime);
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            direccion *= -1;
            timer = 0;
        }

    }
}
