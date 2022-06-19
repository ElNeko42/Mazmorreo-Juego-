using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuDestruir : MonoBehaviour
{
    // Start is called before the first frame update
    gameController controlador;
    void Start()
    {
        controlador = FindObjectOfType<gameController>();
        controlador.Resetear();
        GameObject player = GameObject.FindGameObjectWithTag("GameControler");
        if (player)
            Destroy(player);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
