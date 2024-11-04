using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.CinemachineImpulseManager.ImpulseEvent;

public class BarrasRotatorias : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float fuerzaImpulso;
    [SerializeField] Vector3 direccionRotacion;
    // Start is called before the first frame update
    void Start()
    {
       rb=GetComponent<Rigidbody>();
        rb.AddTorque((direccionRotacion).normalized * fuerzaImpulso, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
       
       

    }
}
