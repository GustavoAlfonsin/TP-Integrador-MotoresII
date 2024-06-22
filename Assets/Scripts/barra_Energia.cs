using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barra_Energia : MonoBehaviour
{
    private Slider slider_energia;
    // Start is called before the first frame update
    void Start()
    {
        slider_energia = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiarEnergiaMaxima(float energiaMaxima)
    {
        slider_energia.maxValue = energiaMaxima;
    }

    public void cambiarEnergiaActual(float cantidad)
    {
        slider_energia.value = cantidad;
    }

    public void inicializarBarraDeEnergia(float cantidadEnergia)
    {
        CambiarEnergiaMaxima(cantidadEnergia);
        cambiarEnergiaActual(cantidadEnergia);
    }
}
