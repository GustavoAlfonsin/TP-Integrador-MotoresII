using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barra_Vida : MonoBehaviour
{
    private Slider sliderVida;
    // Start is called before the first frame update
    void Start()
    {
      sliderVida = GetComponent<Slider>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiarVidaMaxima(float vidaMaxima)
    {
        sliderVida.maxValue = vidaMaxima;
    }

    public void cambiarVidaActual(float cantidad)
    {
        sliderVida.value = cantidad;
    }

    public void inicializarBarraDeVida(float cantidadVida)
    {
        CambiarVidaMaxima(cantidadVida);
        cambiarVidaActual(cantidadVida);
    }
}
