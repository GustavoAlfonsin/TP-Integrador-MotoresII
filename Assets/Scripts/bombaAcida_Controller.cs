using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombaAcida_Controller : MonoBehaviour
{
    public float velocidadX;
    public float velocidadY;
    public float danio;
    public bool left;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,5);
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player.transform.position.x < transform.position.x)
        {
            left = true;
        }
        else
        {
            left = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (left)
        {
            transform.Translate(Vector2.left * velocidadX * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * velocidadX * Time.deltaTime);
        }
       // this.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(velocidadX, velocidadY));
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
