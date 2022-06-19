using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    gameController controlador;
    public Camera FpsCamera;
    public float horizontalspeed;
    public float verticalspeed;
    float h;
    float v;
    private void Start()
    {
        controlador = FindObjectOfType<gameController>();
        Cursor.visible = false;
    }
    void Update()
    {
        if (controlador.pararMovimiento == false)
        {

            h = horizontalspeed * Input.GetAxis("Mouse X");
            v = horizontalspeed * Input.GetAxis("Mouse Y");
            transform.Rotate(0, h, 0);
            FpsCamera.transform.Rotate(-v, 0, 0);
        }
        else
        {
            Cursor.visible = true;
        }


    }
}
