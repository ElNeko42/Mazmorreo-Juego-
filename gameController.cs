using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class gameController : MonoBehaviour
{
    movimiento personaje;
    float partida;
    public GameObject marcador;
    public GameObject GameOver;
    public bool pararMovimiento = false;



    public TextMeshProUGUI puntosTexto;
    public TextMeshProUGUI puntosTextoFinal;
    public TextMeshProUGUI vida;
    public static int puntos;
    public int score;
    MenuPrincial menu;

    // Start is called before the first frame update
    void Start()
    {
        menu = FindObjectOfType<MenuPrincial>();
        personaje = FindObjectOfType<movimiento>();
        partida = personaje.vida;
        pararMovimiento = false;
    }

    // Update is called once per frame
    void Update()
    {
        //muestro la vida y la puntuacion del jugador
        vida.text = "VIDAS: " + personaje.vida;
        puntosTexto.text = "PUNTOS: " + puntos;
        puntosTextoFinal.text = "PUNTOS: " + puntos;
        partida = personaje.vida;
        score = puntos;
       // Debug.Log(partida);
        if (partida <= 0)
        {
            //muestro el panel de fin de partida
            marcador.SetActive(false);
            GameOver.SetActive(true);
            pararMovimiento = true;
            
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

    }
    //metodo que amenta la puntuacion cada ves que se muere un enemigo
    public void Puntos()
    {
        puntos++;
        Debug.Log("tienes " + puntos);
    }
    internal void Resetear()
    {
        puntos = 0;
    }
  
}
