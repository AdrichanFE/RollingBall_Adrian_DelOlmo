using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float velocidad,x,z;
    [SerializeField] Vector3 direccionSalto;
    [SerializeField] float fuerzaSalto,fuerzaMove,distanciaDetSuelo;
    [SerializeField] int vida=100;
    [SerializeField] TMP_Text textoPuntuacion;
    [SerializeField] LayerMask queEsSuelo;
    [SerializeField] AudioClip sonidoNota;
    [SerializeField] AudioManager audioManager;
    int puntuacion;
    
    
    Vector3 direccionMove;

    //CharacterController controller;
    //[SerializeField] Vector3 direccion;
    // Start is called before the first frame update
    void Start()
    {
        //controller = GetComponent<CharacterController>();
        rb=GetComponent<Rigidbody>();
        vida = 100;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        Saltar();
        
        //float x=Input.GetAxisRaw("Horizontal");
        //float z=Input.GetAxisRaw("Vertical");
        
        //Vector3 movimiento=new Vector3(x,0,z).normalized*velocidad*Time.deltaTime;
        //controller.Move(movimiento);

    }
    private void FixedUpdate()//Ciclo de fisicas, es fijo. Se reproduce 0.02 segundos.
    {
        Movimiento();
    }

    void Movimiento()
    { 
         direccionMove=new Vector3(x,0,z);
         rb.AddForce((direccionMove).normalized * fuerzaMove, ForceMode.Force);
    }

    void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (DetectarSuelo() == true)
            {
                rb.AddForce(direccionSalto * fuerzaSalto, ForceMode.Impulse);
            }
            
        }
    }
    bool DetectarSuelo()
    {
        bool resultado=Physics.Raycast(transform.position, new Vector3(0, -1, 0), distanciaDetSuelo,queEsSuelo);
        return resultado;
    }
    
    void Muerte()
    {
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Coleccionable")) 
        {
            audioManager.ReproducirSonido(sonidoNota);
            puntuacion += 20;
            textoPuntuacion.SetText("Puntuacion: " + puntuacion);

            Destroy(other.gameObject);
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RodilloMortal"))
        {
            vida -= 10;
            Muerte();
        }
        
    }

}
