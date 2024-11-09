using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    [SerializeField] List<GameObject> checkPoints;
    [SerializeField] Vector3 vectorPoint;

    Rigidbody rb;
    [SerializeField] float velocidad;
    [SerializeField] Vector3 direccionSalto;
    [SerializeField] float fuerzaSalto,fuerzaMove,distanciaDetSuelo;
    [SerializeField] TMP_Text textoPuntuacion;
    [SerializeField] GameObject menuPausa;
    //[SerializeField] GameObject menuVictoria;
    [SerializeField] LayerMask queEsSuelo;
    [SerializeField] AudioClip sonidoNota;
    //[SerializeField] AudioClip sonidoVictoria;
    [SerializeField] AudioManager audioManager;
    private float x, z;
    private int puntuacion;
    private Vector3 direccionMove;
    private Vector3 playerPosition;

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            menuPausa.SetActive(true);
            MovimientoNormal();
        }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            // Calcular la dirección desde el jugador hasta el checkpoint
            Vector3 DireccionHastaCheckPoint = other.transform.position - transform.position;

            // Vectores Para aparecer un poc mas atras y no buguear los checkpoint
            Vector3 unPocoMasAtras = DireccionHastaCheckPoint.normalized;
            Vector3 paraAtras = new Vector3(0, 0, -2);

            // Calcular la nueva posición del vectorPoint
            vectorPoint = other.transform.position + unPocoMasAtras + paraAtras;
            playerPosition = vectorPoint;
        }


        if (other.gameObject.CompareTag("Coleccionable")) 
        {
            audioManager.ReproducirSonido(sonidoNota);
            puntuacion += 20;
            textoPuntuacion.SetText("Puntuacion: " + puntuacion);

            Destroy(other.gameObject);
        } 

        if (other.gameObject.CompareTag("DetectorCaida"))
        {

            rb= gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //Con esto detenemos temporalmente la fisica del judagor
                rb.velocity = Vector3.zero;

                //Movemos al jugador a la nueva posicion
                rb.MovePosition(vectorPoint);

                //Con esto reactivamos la fisica
                rb.useGravity = true;

                //Se podria programar un pequeño delay para reactivar la fisica del jugador, pero creo que queda bien asi como esta
            }
        }

    }

}
