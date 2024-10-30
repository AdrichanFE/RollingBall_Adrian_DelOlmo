using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDeObstaculos : MonoBehaviour
{

    [SerializeField] GameObject[] obstaculosSpawn;
    [SerializeField] private float timer;
    

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2)
        {
            int randomIndex=Random.Range(0,obstaculosSpawn.Length);
            Instantiate(obstaculosSpawn[randomIndex], new Vector3(Random.Range(-7,-10), Random.Range(154,160),Random.Range(1190,1200)), Quaternion.identity);
            //Quaternion.identity sirve para instanciar objetos sin rotacion especifica, algunos ejemplos serian:
            // transform.position=Quaternion.identity; esto aplica una rotacion de "ninguna", dejando al objeto alineado con sus ejes originales.
            //transform.position *=Quaternion.identity; esto multiplica la actual rotacion por la identidad, lo que tiene el efecto de "resetear" la rotacion.
            timer = 0;
        }
    }
}
