using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigonuevo : MonoBehaviour
{
	public float rangoDeAlerta;
	public Transform target;
	public float moveSpeed = 3f;
	public float vida = 3;
	private float rotationSpeed = 6;
	public Transform myTransform;
	gameController controlador;




	void Awake()
	{
		myTransform = transform;
	}


	void Start()
	{
		target = GameObject.FindWithTag("Player").transform; //target the player
		controlador = FindObjectOfType<gameController>();

	}


	 void Update()
	{
		//Calcular distancia
		 float distancia;
		distancia = Vector3.Distance(target.transform.position, transform.position);

		//Si la distancia es menor a 4
		if (distancia < rangoDeAlerta)
		{
			//Voltear
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
			Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
			//Caminar
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
			//Lineas de debug que aparecen en la ventana Scene
			Debug.DrawLine(target.transform.position, transform.position, Color.red, Time.deltaTime, false);
		}
		if (vida <= 0)
		{
			Destroy(gameObject, 0.5f);
			gameObject.transform.Rotate(new Vector3(0, 20 * Time.deltaTime, 5 * Time.deltaTime));
			Debug.Log("me quedan " + vida + " vidas");
			controlador.Puntos();
		}
	}
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("bala"))
		{
			vida--;
			Destroy(collision.gameObject);
		}

	}
}
