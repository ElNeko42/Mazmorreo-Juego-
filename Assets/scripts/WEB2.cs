using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WEB2 : MonoBehaviour
{
    gameController controlador;
    string URL = "http://www.fben.colexio-karbo.com/20-21/juegoMazmorra/insertarPuntos.php";
    public string nombre;
    public int punto;

    private void Start()
    {
        controlador = FindObjectOfType<gameController>();
        
    }
    public void ReadText(string s) {
        nombre = s;
        Debug.Log("el nombre es " + nombre);
    }
    public void Add()
    {
        punto = controlador.score;
        WWWForm form = new WWWForm();
        form.AddField("nombre",nombre);
        form.AddField("puntos",punto);
        WWW www = new WWW(URL, form);
    }

}
