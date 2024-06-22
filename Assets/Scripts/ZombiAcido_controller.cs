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

    public override void Update()
    {
        jugadorEnRangoDisparo = Physics2D.Raycast(ojosZombie.position, transform.right, distanciaDeDisparo, capaJugador);
        jugadorEnRango = Physics2D.Raycast(ojosZombie.position, transform.right, distanciaLinea, capaJugador);
        if (jugadorEnRangoDisparo && jugadorEnRangoDisparo.transform.CompareTag("Player") && Time.time > tiempoActual + tiempoEntreDisparos && !jugadorEnRango)
        {
            tiempoActual = Time.time;
            Invoke(nameof(dispararAcido),tiempoEntreDisparos);
        }
        else if (jugadorEnRango && jugadorEnRango.transform.CompareTag("Player"))
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(jugadorEnRango.transform.position.x, transform.position.y)
                                , velocidadMovimiento * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, puntosMoviento[numeroAleatorio].position, velocidadMovimiento * Time.deltaTime);

            if (Vector2.Distance(transform.position, puntosMoviento[numeroAleatorio].position) < distanciaMinima)
            {
                numeroAleatorio = Random.Range(0, puntosMoviento.Length);
                Girar();
            }
        }

        if (enContactoJugador)
        {
            atacar();
        }
    }

    private void dispararAcido()
    {
        Instantiate(proyectil, ojosZombie.position,ojosZombie.rotation);
    }

    public override void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(ojosZombie.position, ojosZombie.position + transform.right * distanciaDeDisparo);
        base.OnDrawGizmos();
    }
}
