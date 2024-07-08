using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    public Text gameOverTxt;
    public Image imagen;
    public Text info_municion;
    [SerializeField] private Sprite imagen_pistola;
    [SerializeField] private Sprite imagen_escopeta;
    [SerializeField] private Sprite imagen_fusil;
    [SerializeField] private GameObject jugador;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        gameOverTxt.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverTxt.text = "Game Over";
            gameOverTxt.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.N) && gameOver)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
        mostrarArmaActual();
    }

    private void mostrarArmaActual()
    {
        Tipos_Armas armaActual = jugador.GetComponent<ControladorArmasJugador>().armaActual.Tipo;
        int municionActual = jugador.GetComponent<ControladorArmasJugador>().armaActual.MunicionActual;
        int municionTotal = jugador.GetComponent<ControladorArmasJugador>().armaActual.MunicionMaxima;
        switch (armaActual)
        {
            case Tipos_Armas.Pistola:
                imagen.sprite = imagen_pistola;
                break;
            case Tipos_Armas.Escopeta:
                imagen.sprite= imagen_escopeta;
                break;
            case Tipos_Armas.Fusil:
                imagen.sprite = imagen_fusil;
                break;
            default:
                break;
        }

        info_municion.text = $"{municionActual} / {municionTotal}";
    }
}
