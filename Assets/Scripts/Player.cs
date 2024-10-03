using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float velocidad;
    [SerializeField] Vector3 direccionSalto;
    [SerializeField] float fuerzaSalto,fuerzaMove;
    Vector3 direccionMove;
    //CharacterController controller;
    //[SerializeField] Vector3 direccion;
    // Start is called before the first frame update
    void Start()
    {
        //controller = GetComponent<CharacterController>();
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Saltar();
        Movimiento();
        //float x=Input.GetAxisRaw("Horizontal");
        //float z=Input.GetAxisRaw("Vertical");
        
        //Vector3 movimiento=new Vector3(x,0,z).normalized*velocidad*Time.deltaTime;
        //controller.Move(movimiento);

    }

    void Movimiento()
    {
       
         float x=Input.GetAxisRaw("Horizontal");
         float z=Input.GetAxisRaw("Vertical");
         direccionMove=new Vector3(x,0,z);
        rb.AddForce(direccionMove * fuerzaMove, ForceMode.Force);
    }

    void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(direccionSalto*fuerzaSalto, ForceMode.Impulse);
        }
    }
   
    
}
