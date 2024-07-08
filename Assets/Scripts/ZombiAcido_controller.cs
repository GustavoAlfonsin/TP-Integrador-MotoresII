using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class ZombiAcido_controller : Zombi_Controller
{
    [Header("Zombi Acido")]
    public GameObject proyectil;
    [SerializeField] GameObject disparador;
    [SerializeField] private float distanciaDeDisparo;
    private float tiempoEntreDisparos = 10f;
    private float tiempoActual = -5f;
    // Start is called before the first frame update
    public override void Update()
    {
        tiempoActual += Time.deltaTime;
        if (siguiendoJugador && tiempoActual > tiempoEntreDisparos)
        {
            tiempoActual = 0;
            StartCoroutine(dispararAcido());
        }
        else 
        {
            base.Update();
        }
    }
    
    IEnumerator dispararAcido()
    {
        float velocidadNormar = speed;
        speed = 0;
        Instantiate(proyectil, disparador.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);
        speed = velocidadNormar;
    }
}
