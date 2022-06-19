using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincial : MonoBehaviour
{
    public GameObject controlles;
    public GameObject mPrinci;
    public bool control = false;
   public void Jugar()
    {
        SceneManager.LoadScene("JuegoPrincipal");
    }
    public void Menu()
    {
        SceneManager.LoadScene("menuPrincipal");
        control = true;
    }

   public  void Salir()
    {
        mPrinci.SetActive(false);
        controlles.SetActive(true);
    }

}
