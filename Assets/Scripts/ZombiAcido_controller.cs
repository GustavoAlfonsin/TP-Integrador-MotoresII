using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiAcido_controller : Zombi_Controller
{
    [Header("Zombi Acido")]
    public GameObject proyectil;
    [SerializeField] private float distanciaDeDisparo;
    private float tiempoEntreDisparos = 3f;
    private float tiempoActual = -3f;
    public RaycastHit2D jugadorEnRangoDisparo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void dispararAcido()
    {
       // Instantiate(proyectil, ojosZombie.position,ojosZombie.rotation);
    }

}
