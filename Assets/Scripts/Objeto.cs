using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tipo_objeto
{
    municion_pistola,
    municion_escopeta,
    municion_fusil,
    objeto_curacion
}
public class Objeto : MonoBehaviour
{
    [SerializeField] Tipo_objeto tipo;
    [SerializeField] int cant;
    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(tipo == Tipo_objeto.objeto_curacion)
            {
                collision.GetComponent<ControladorJugador>().tomarObjetoCurativo();
            }
            else
            {
                collision.GetComponent<ControladorArmasJugador>().recogerMunicion(tipo, cant);
            }
            Destroy(gameObject);
        }
    }
}
