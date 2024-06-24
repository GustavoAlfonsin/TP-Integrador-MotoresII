using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaccion_jugador : MonoBehaviour
{
    public Text mensaje;
    private bool puedeInteractuar = false;
    private GameObject objeto;
    public GameObject[] camaras;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && puedeInteractuar)
        {
            //desactivarCamaras();
            objeto.GetComponent<Doors_Controller>().transportarJugador();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Puerta"))
        {
            puedeInteractuar = true;
            objeto = collision.gameObject;
            mensaje.text = "Presione [ i ] para ingresar";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Puerta"))
        {
            puedeInteractuar = false;
            objeto = null;
            mensaje.text = "";
        }
    }

    private void desactivarCamaras()
    {
        foreach (GameObject camara in camaras)
        {
            camara.SetActive(false);
        }
    }
}
