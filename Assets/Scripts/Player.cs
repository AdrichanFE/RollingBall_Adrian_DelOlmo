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
    [SerializeField] int vida;
    [SerializeField] TMP_Text textoPuntuacion;
    [SerializeField] LayerMask queEsSuelo;
    [SerializeField] AudioClip sonidoNota;
    [SerializeField] AudioManager audioManager;
    int puntuacion;
    Vector3 direccionMove;

    public bool esVistaCenital { get; set; } = false;//Esto lo uso para poder usar esta variable en el detector de la camara cenital

    
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
            x = Input.GetAxisRaw("Horizontal");
            z = Input.GetAxisRaw("Vertical");

        if (!esVistaCenital)
        {
            Saltar();
        }
    
    }
    private void FixedUpdate()//Ciclo de fisicas, es fijo. Se reproduce 0.02 segundos.
    {
        MovimientoNormal();
        
        
    }

    void MovimientoNormal()
    { 
         direccionMove=new Vector3(x,0,z);
         rb.AddForce((direccionMove).normalized * fuerzaMove, ForceMode.Force);
    }


    void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&!esVistaCenital&&DetectarSuelo())
        { 
            rb.AddForce(direccionSalto * fuerzaSalto, ForceMode.Impulse);  
        }
    }
    bool DetectarSuelo()
    {
        bool resultado=Physics.Raycast(transform.position, new Vector3(0, -1, 0), distanciaDetSuelo,queEsSuelo);
        return resultado;
    }
    
    //void Muerte()
    //{
    //    if (vida <= 0)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

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
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("RodilloMortal"))
    //    {
    //        vida -= 10;
    //        Muerte();
    //    }
        
    //}

}
