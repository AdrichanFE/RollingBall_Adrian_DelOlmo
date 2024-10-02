using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float velocidad;
    CharacterController controller;
    //[SerializeField] Vector3 direccion;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x=Input.GetAxisRaw("Horizontal");
        float z=Input.GetAxisRaw("Vertical");
        
        Vector3 movimiento=new Vector3(x,0,z).normalized*velocidad*Time.deltaTime;
        controller.Move(movimiento);

    }
   
    
}
