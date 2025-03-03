using UnityEngine;
using UnityEngine.AI; // Necesario para usar NavMeshAgent.

public class MovimientoEnemigo : MonoBehaviour
{
    public Transform jugador; // Referencia al transform del jugador.
    private NavMeshAgent nav; // Componente para navegación.

    void Start()
    {
        nav = GetComponent<NavMeshAgent>(); // Obtiene el componente NavMeshAgent.
    }

    void Update()
    {
        // Si el jugador existe y su posición en Z es mayor que 2, el enemigo lo persigue.
        if (jugador != null && jugador.position.z > 2)
        {
            nav.SetDestination(jugador.position); // Establece el destino del enemigo.
        }
    }
}