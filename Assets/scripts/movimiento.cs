using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    gameController controlador;
    SoundManager soundManager;
    public float vida;
    public bool espera = false;
    //Declaro la variable de tipo RigidBody que luego asociaremos a nuestro Jugador
    private Rigidbody rb;
    public GameObject arma;


    //Declaro la variable pública velocidad para poder modificarla desde la Inspector window
    [Range(1, 10)]
    public float velocidad = 5;

    void Start()
    {

        //Capturo el rigidbody del jugador al iniciar el juego
        rb = GetComponent<Rigidbody>();
        controlador = FindObjectOfType<gameController>();
        soundManager = FindObjectOfType<SoundManager>();


    }

    void FixedUpdate()
    {

        //Capturo el movimiento en horizontal y vertical de nuestro teclado
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");

        //Genero el vector de movimiento asociado, teniendo en cuenta la velocidad
        
        if (controlador.pararMovimiento == false)
        {Vector3 movimiento = transform.forward * movimientoV + transform.right * movimientoH;
            
            //si es true el jugador va para atras
            if (espera == true)
            {
                StartCoroutine(Danho(0.5f));

                rb.MovePosition(transform.position + (transform.forward * -1 + transform.right * -1) * 4 * Time.deltaTime);

            }
            else
            {
                rb.MovePosition(transform.position + movimiento * velocidad * Time.deltaTime);
            }
        }
        if (vida <= 0)
        {//te moriste wey
            Destroy(arma);
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemigo")|| collision.gameObject.CompareTag("bala"))
        {
            soundManager.SeleccionAudio(0, 0.3f);
            vida--;
            Debug.Log("me esta tocado el enemigo");
            espera = true;

        }


    }
    //corrutina para ell danho
    IEnumerator Danho(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        espera = false;


    }
}
