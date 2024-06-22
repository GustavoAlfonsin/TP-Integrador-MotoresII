using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ControladorJugador : MonoBehaviour
{
    [Header("vida y Energia")]
    private float vida;
    [SerializeField] private float vidaMaxima;
    private int cantObjetosCurativos = 2;

    [SerializeField] private barra_Vida barraDeVida;
    [SerializeField] private barra_Energia barraDeEnergia;

    private Rigidbody2D rb2D;

    [Header("Movimiento")]
    private float movimientoHorizontal = 0f;
    [SerializeField] private float velocidadDeMovimiento;
    [Range(0,0.3f)][SerializeField] private float suavizadoDeMovimiento;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;

    [Header("Sprint")]
    [SerializeField] private float velocidadMovimientoBase;
    [SerializeField] private float velocidadExtra;
    [SerializeField] private float tiempoSprint;
    private float tiempoActualSprint;
    private float tiempoSiguienteSprint;
    [SerializeField] private float tiempoEntreSprints;
    private bool puedeCorrer = true;
    private bool estaCorriendo = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        tiempoActualSprint = tiempoSprint;
        vida = vidaMaxima;
        barraDeVida.inicializarBarraDeVida(vida);
        barraDeEnergia.inicializarBarraDeEnergia(tiempoSprint);
    }

    // Update is called once per frame
    void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;

        if (Input.GetKeyDown(KeyCode.C) && puedeCorrer) 
        {
            velocidadDeMovimiento = velocidadExtra;
            estaCorriendo = true;
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            velocidadDeMovimiento = velocidadMovimientoBase;
            estaCorriendo = false;
        }

        if (Mathf.Abs(rb2D.velocity.x) >= 0 && estaCorriendo) 
        {
            if (tiempoActualSprint > 0 )
            {
                tiempoActualSprint -= Time.deltaTime;
                barraDeEnergia.cambiarEnergiaActual(tiempoActualSprint);
            }
            else
            {
                velocidadDeMovimiento = velocidadMovimientoBase;
                estaCorriendo = false;
                puedeCorrer = false;
                tiempoSiguienteSprint = Time.time + tiempoEntreSprints;
                barraDeEnergia.cambiarEnergiaActual(0);
            }
        }

        if (!estaCorriendo && tiempoActualSprint <= tiempoSprint && Time.time >= tiempoSiguienteSprint)
        {
            tiempoActualSprint += Time.deltaTime;
            barraDeEnergia.cambiarEnergiaActual(tiempoActualSprint);
            if (tiempoActualSprint >= tiempoSprint)
            {
                barraDeEnergia.cambiarEnergiaActual(tiempoSprint);
                puedeCorrer = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            recurarse();
        }
    }

    private void FixedUpdate()
    {
        Mover(movimientoHorizontal*Time.deltaTime);
    }

    private void Mover(float mover)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);

        if (mover > 0 && !mirandoDerecha) 
        {
            Girar();
        }else if (mover < 0 && mirandoDerecha) 
        {
            Girar();
        }
    }
    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        transform.eulerAngles = new Vector3(0,transform.eulerAngles.y + 180, 0);
    }

    public void tomarDanio(float danio)
    {
        vida -= danio;
        barraDeVida.cambiarVidaActual(vida);
        if (vida <= 0) 
        {
            vida = 0;
            Destroy(this.gameObject);
        }
    }

    private void recurarse()
    {
        if (cantObjetosCurativos > 0 && vida < vidaMaxima)
        {
            Debug.Log($"Tienes {vida} puntos de salud");
            vida += 25;
            if (vida > vidaMaxima)
            {
                vida = vidaMaxima;
            }
            barraDeVida.cambiarVidaActual(vida);
            Debug.Log($"Ahora tienes {vida} puntos de vida");
        }
        else
        {
            Debug.Log("No tienes más objetos curativos");
        }
    }
}
