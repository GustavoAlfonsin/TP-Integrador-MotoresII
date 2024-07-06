using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Zombi_Controller : MonoBehaviour
{
    private float vida = 15;
    private Rigidbody2D rb2D;

    [Header("Detector Del Jugador")]
    internal bool siguiendoJugador;
    [SerializeField] private float minDistance;

    [Header("Movimiento")]
    [SerializeField] private float speed;
    [SerializeField] private float waitTime;
    [SerializeField] internal Transform[] puntosMoviento;
    [SerializeField] private float areaDeDeteccion;
    private bool isWaiting;
    private int waypointActual;

    private float tiempoEntreAtaques = 2;
    private float tiempo;

    [SerializeField] private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Flip();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (siguiendoJugador)
        {
            if (Mathf.Abs(transform.position.x - player.position.x) > minDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                Flip();
            }
            else
            {
                atacar();
            }
            
        }else if (transform.position != puntosMoviento[waypointActual].position)
        {
            Flip();
            siguiendoJugador = false;
            transform.position = Vector2.MoveTowards(transform.position, puntosMoviento[waypointActual].position,
                                                      speed * Time.deltaTime);
        }
        else if(!isWaiting)
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait() 
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        waypointActual++;
        if (waypointActual == puntosMoviento.Length) 
        {
            waypointActual = 0;
        }
        isWaiting = false;
        Flip();
    }
    private void Flip()
    {
        if (siguiendoJugador)
        {
            if (transform.position.x > player.position.x)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
        else
        {
            if (transform.position.x > puntosMoviento[waypointActual].position.x)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
        
    }

    public void recibirDanio(float danio)
    {
        vida -= danio;
        if (vida <= 0) 
        {
            vida = 0;
            Destroy(this.gameObject);
            Debug.Log("El zombi ha sido eliminado");
        }
    }

    internal void atacar()
    {
        tiempo += Time.deltaTime;
        if (tiempo >= tiempoEntreAtaques)
        {
            Debug.Log("El zombi ataco al jugador");
            tiempo = 0;
        }
    }

}
