using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    
    public int openSide;
    //1 necesitamos una puerta abajo; 2 arriba;3 derecha;4 izq

    private RoomTemplates templates;
    private int rand;
    private bool spawner = false;
    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    void Spawn()
    {
        //compruebo si ha creado una sala
        if (spawner==false)
        {
            if (openSide == 1)
            {
                //se crea puerta abajo
                rand = Random.Range(0, templates.botoomRoms.Length);
                Instantiate(templates.botoomRoms[rand], transform.position, templates.botoomRoms[rand].transform.rotation);
            }
            else if (openSide == 2)
            {
                //se crea puerta arriba
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openSide == 3)
            {
                //se crea puerta derecha
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                
            }
            else if (openSide == 4)
            {
                //se crea puerta izquierda
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);

            }
            // si se crea pasa ser true
            spawner = true;
        }
       
    }

    //en caso de que se creara otra sala en el mismo punto se destruye
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            /* if (other.GetComponent<RoomSpawner>().spawner==false && spawner==false)
             {
                 Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                 Destroy(gameObject);
             }
             spawner = true;*/
            Destroy(gameObject);
        }
    }
}
