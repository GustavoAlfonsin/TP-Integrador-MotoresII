using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Doors_Controller : MonoBehaviour
{
    [SerializeField] private GameObject destinos;
    [SerializeField] public GameObject camara;
    [SerializeField] private GameObject jugador;
    [SerializeField] private bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void transportarJugador()
    {
        if (isOpen)
        {
            camara.SetActive(false);
            jugador.transform.position = destinos.transform.position;
            destinos.GetComponent<Doors_Controller>().camara.SetActive(true);
        }
        else
        {
            Debug.Log("La puerta esta cerrada");
        }
    }
}
