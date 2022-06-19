using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class enemigoDisparo : MonoBehaviour
{
	public float rangoDeAlerta;
	public Transform target;
	public float moveSpeed = 3f;
	public float vida;
	private float rotationSpeed = 6;
	public Transform myTransform;
	public GameObject bullet;
	public Transform spawnPoint;
	public float shotForce = 1500;
	public float shotRate = 1f;
	public float shotRateTime = 0;
	gameController controlador;
	SoundManager soundManager;

	void Awake()
	{
		myTransform = transform;
	}


	void Start()
	{
		target = GameObject.FindWithTag("Player").transform; //target the player
		controlador = FindObjectOfType<gameController>();
		soundManager = FindObjectOfType<SoundManager>();


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
			Vector3 posJugador = new Vector3(target.position.x, transform.position.y, target.position.z);
			transform.LookAt(posJugador);
			//Caminar
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
			//Lineas de debug que aparecen en la ventana Scene
			Debug.DrawLine(target.transform.position, transform.position, Color.red, Time.deltaTime, false);
			if (Time.time > shotRateTime)
			{
				soundManager.SeleccionAudio(2, 0.3f);
				GameObject newBullet;
				newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
				newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);
				shotRateTime = Time.time + shotRate;
				Destroy(newBullet, 2);
			}
		}
		if (vida <= 0)
		{	
			controlador.Puntos();
			Destroy(gameObject, 0.5f);
			gameObject.transform.Rotate(new Vector3(0, 20 * Time.deltaTime, 5 * Time.deltaTime));
			Debug.Log("me quedan " + vida + " vidas");
			StartCoroutine(pasarNivel(2f));

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
	IEnumerator pasarNivel(float tiempo)
	{
		SceneManager.LoadScene("JuegoPrincipal");
		yield return new WaitForSeconds(tiempo);
		


	}
}
