using UnityEngine;

public class CajaVida : MonoBehaviour
{
    private GeneracionCajaVida generador;
    private Vida vidaManager;

    void Start()
    {
        generador = FindAnyObjectByType<GeneracionCajaVida>();
        vidaManager = FindAnyObjectByType<Vida>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Jugador")) return;

        vidaManager.AñadirVida();
        generador.CajaRecogida();
        Destroy(gameObject);
    }
}
