using UnityEngine;

public class Pinchos : MonoBehaviour
{
    [SerializeField] private float speed = 2f; // Velocidad de movimiento.
    [SerializeField] private float delay = 2f; // Tiempo entre cambios de dirección.
    [SerializeField] private float moveHeight = 0.5f; // Altura máxima de movimiento.

    private Vector3 startPos; // Posición inicial.
    private Vector3 endPos; // Posición final (arriba).
    private bool movingUp = true; // Controla la dirección del movimiento.

    void Start()
    {
        startPos = transform.position;
        endPos = startPos + new Vector3(0, moveHeight, 0); // Calcula la posición final.
        InvokeRepeating("ToggleMovement", delay, delay); // Cambia dirección cada "delay" segundos.
    }

    void Update()
    {
        // Interpola suavemente entre las posiciones inicial y final.
        transform.position = Vector3.Lerp(transform.position, movingUp ? endPos : startPos, Time.deltaTime * speed);
    }

    void ToggleMovement()
    {
        movingUp = !movingUp; // Cambia la dirección del movimiento.
    }
}