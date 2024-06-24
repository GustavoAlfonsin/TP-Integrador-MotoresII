using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barra_Vida : MonoBehaviour
{
    [SerializeField]private Slider slider_Vida;
    // Start is called before the first frame update
    void Start()
    {
      slider_Vida = this.GetComponent<Slider>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiarVidaMaxima(float vidaMaxima)
    {
        slider_Vida.maxValue = vidaMaxima;
    }

    public void cambiarVidaActual(float cantidad)
    {
        slider_Vida.value = cantidad;
    }

    public void inicializarBarraDeVida(float cantidadVida)
    {
        CambiarVidaMaxima(cantidadVida);
        cambiarVidaActual(cantidadVida);
    }
}
