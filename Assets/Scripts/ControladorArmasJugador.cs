using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorArmasJugador : MonoBehaviour
{
    private List<Arma> ArmasJugador;
    private int indexArma;
    public Arma armaActual;

    private void Awake()
    {
        ArmasJugador = new List<Arma>();
        Arma pistola = new Arma(Tipos_Armas.Pistola, 5);
        ArmasJugador.Add(pistola);
        Arma escopeta = new Arma(Tipos_Armas.Escopeta, 9);
        ArmasJugador.Add(escopeta);
        Arma fusil = new Arma(Tipos_Armas.Fusil, 6.5f);
        ArmasJugador.Add(fusil);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CambiarArma();
    }

    private void CambiarArma()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (indexArma <= 0)
            {
                indexArma = ArmasJugador.Count-1;
            }
            else
            {
                indexArma -= 1;
            }
            armaActual = ArmasJugador[indexArma];
            Debug.Log($"Estas usando {armaActual.Tipo}");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (indexArma >= ArmasJugador.Count-1)
            {
                indexArma = 0;
            }
            else
            {
                indexArma += 1;
            }
            armaActual = ArmasJugador[indexArma];
            Debug.Log($"Estas usando {armaActual.Tipo}");
        }
    }
}
