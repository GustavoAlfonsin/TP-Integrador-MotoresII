using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombaAcida_Controller : MonoBehaviour
{
    public float velocidadX;
    public float velocidadY;
    public float danio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(velocidadX, velocidadY));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ControladorJugador controlador))
        {
            controlador.tomarDanio(danio);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Paredes"))
        {
            Destroy(this.gameObject);
        }
    }
}
