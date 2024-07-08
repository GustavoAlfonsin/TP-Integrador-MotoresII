using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    public Text gameOverTxt;
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
    }
}
