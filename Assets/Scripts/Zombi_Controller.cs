using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Zombi_Controller : MonoBehaviour
{
    [SerializeField] private float vidaMaxima;
    private float vida;
    private SpriteRenderer SpriteRenderer;
    private Color colorbase;
    private Rigidbody2D rb2D;

    [Header("Detector Del Jugador")]
    internal bool siguiendoJugador;
    [SerializeField] private float minDistance;
    public bool left;

    [Header("Movimiento")]
    [SerializeField] internal float speed;
    [SerializeField] private float waitTime;
    [SerializeField] internal Transform[] puntosMoviento;
    private bool isWaiting;
    private int waypointActual;

    private float tiempoEntreAtaques = 2;
    private float tiempo;
    [SerializeField] private float danioAtaque;

    [SerializeField] private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        vida = vidaMaxima;
        rb2D = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        colorbase = SpriteRenderer.color;
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
                left = true;
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                left = false;
            }
        }
        else
        {
            if (transform.position.x > puntosMoviento[waypointActual].position.x)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                left = true;
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                left = false;
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
        else
        {
            StartCoroutine(mostrarDanio());
        }
    }
    IEnumerator mostrarDanio()
    {
        float damageDuration = 0.1f;
        SpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(damageDuration);
        SpriteRenderer.color = colorbase;
    }
    internal void atacar()
    {
        tiempo += Time.deltaTime;
        if (tiempo >= tiempoEntreAtaques)
        {
            player.GetComponent<ControladorJugador>().tomarDanio(danioAtaque);
            Debug.Log("El zombi ataco al jugador");
            tiempo = 0;
        }
    }

}
