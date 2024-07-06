using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombi_zonaPeligro : MonoBehaviour
{
    [SerializeField] private GameObject zombie_que_mira;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            zombie_que_mira.GetComponent<Zombi_Controller>().siguiendoJugador = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            zombie_que_mira.GetComponent<Zombi_Controller>().siguiendoJugador = false;
        }
    }
}
