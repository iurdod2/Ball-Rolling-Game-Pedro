using UnityEngine; 

public class Coleccionable : MonoBehaviour 
{
    // El método Start se llama una vez al inicio, justo antes del primer frame.
    void Start()
    {
    }

    // El método Update se llama una vez por frame, es decir, continuamente durante la ejecución del juego.
    void Update()
    {
        // Hace que el objeto rote continuamente.
        // transform.Rotate() aplica una rotación al objeto al que está adjunto este script.
        // new Vector3(15, 30, 40) define los grados de rotación en los ejes X, Y y Z respectivamente.
        // Time.deltaTime asegura que la rotación sea suave y consistente, independientemente del framerate.
        transform.Rotate(new Vector3(15, 30, 40) * Time.deltaTime);
    }
}