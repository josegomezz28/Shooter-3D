using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class GeneracionEnemigos : MonoBehaviour
{
    [Header("Puntos de inicio de los enemigos")]

    public Transform parentObjectEnemigos;
    public Transform[] puntosInicio;
    public GameObject enemigo;

    [Header("Ajustes de dificultad")]

    public TimerEnemigo timerEnemigo;
    public float refrescoEnemigos = 1.0f;
    public float velocidadEnemigo = 3.5f;
    public float dificultadEnemigo = 0;


   
    void Start()
    {
        timerEnemigo = FindAnyObjectByType<TimerEnemigo>();
        StartCoroutine("DificultadCreacionEnemigo");
    }


    void Update()
    {
        dificultadEnemigo = timerEnemigo.getTimerEnemigo();

        if (dificultadEnemigo > 0 && dificultadEnemigo < 30)
        {
            refrescoEnemigos = 2.0f;
            velocidadEnemigo = 3.5f;
        }
        if (dificultadEnemigo >= 30 && dificultadEnemigo < 60)
        {
            refrescoEnemigos = 1.0f;
            velocidadEnemigo = 4.0f;
        }
        if (dificultadEnemigo >= 60)
        {
            refrescoEnemigos = 0.5f;
            velocidadEnemigo = 4.5f;
        }

    }

    IEnumerator DificultadCreacionEnemigo()
    {
        yield return new WaitForSeconds(refrescoEnemigos);   
        CreaEnemigo();
        StartCoroutine("DificultadCreacionEnemigo");
    }

    void CreaEnemigo()
    {
        int aleatorioPuntosInicio = Random.Range(0, 3);
        GameObject nuevaEnemigo;
        nuevaEnemigo = Instantiate(enemigo, puntosInicio[aleatorioPuntosInicio].position,
            puntosInicio[aleatorioPuntosInicio].rotation, parentObjectEnemigos);

        NavMeshAgent agent = nuevaEnemigo.GetComponent<NavMeshAgent>();
        agent.speed = velocidadEnemigo;
    }
    
    public void DestruirTodosLosEnemigos()
    {
        if(parentObjectEnemigos != null)
        {
            foreach (Transform enemigo in parentObjectEnemigos)
            {
                Destroy(enemigo.gameObject);
            }
        }
    }
    
    
}
