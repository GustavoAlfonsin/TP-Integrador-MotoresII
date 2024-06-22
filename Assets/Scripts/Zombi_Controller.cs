using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombi_Controller : MonoBehaviour
{
    private float vida = 15;
    private Rigidbody2D rb2D;

    [Header("Detector Del Jugador")]
    public Transform ojosZombie;
    public float distanciaLinea;
    public LayerMask capaJugador;
    public RaycastHit2D jugadorEnRango;
    private bool enContactoJugador;

    [Header("Movimiento")]
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Transform[] puntosMoviento;
    [SerializeField] private float distanciaMinima;
    private int numeroAleatorio;
    private SpriteRenderer sprite;

    private float tiempoEntreAtaques = 2;
    private float tiempo;

    [SerializeField] private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        numeroAleatorio = Random.Range(0, puntosMoviento.Length);
        rb2D = GetComponent<Rigidbody2D>();
        sprite = rb2D.GetComponent<SpriteRenderer>();
        Girar();
    }

    // Update is called once per frame
    void Update()
    {
        jugadorEnRango = Physics2D.Raycast(ojosZombie.position, transform.right, distanciaLinea, capaJugador);
        if (jugadorEnRango && jugadorEnRango.transform.CompareTag("Player"))
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

    private void Girar()
    {
        if (transform.position.x < puntosMoviento[numeroAleatorio].position.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
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

    private void atacar()
    {
        tiempo += Time.deltaTime;
        if (tiempo >= tiempoEntreAtaques)
        {
            jugadorEnRango.rigidbody.GetComponent<ControladorJugador>().tomarDanio(20);
            Debug.Log("El zombi ataco al jugador");
            tiempo = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enContactoJugador = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enContactoJugador = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(ojosZombie.position,ojosZombie.position + transform.right * distanciaLinea);
    }

}
