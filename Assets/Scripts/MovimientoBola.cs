using TMPro; // Para usar TextMeshPro.
using UnityEngine;
using UnityEngine.SceneManagement; // Para cambiar de escena.

public class MovimientoBola : MonoBehaviour
{
    public AudioSource sonidoVida; // Sonido al recoger vida.
    public AudioSource sonidoDanio; // Sonido al recibir daño.
    public AudioSource sonidoColeccionable; // Sonido al recoger coleccionable.

    public TextMeshProUGUI coleccionablesText; // Texto para mostrar coleccionables.
    public TextMeshProUGUI vidasText; // Texto para mostrar vidas.

    private Rigidbody rb; // Componente Rigidbody para física.
    [SerializeField] private float movementForce; // Fuerza de movimiento.
    [SerializeField] private float jumpForce; // Fuerza de salto.
    private float hInput, vInput; // Entradas de movimiento.
    private bool enSuelo = true; // Verifica si está en el suelo.
    private bool dobleSaltoDisponible = true; // Permite doble salto.
    private int vidas; // Contador de vidas.
    private int coleccionables; // Contador de coleccionables.

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coleccionables = 0;
        vidas = 3;
        setTextoColeccionables(); // Actualiza texto de coleccionables.
        setTextoVidas(); // Actualiza texto de vidas.
    }

    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space)) // Salta al presionar espacio.
        {
            Saltar();
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(hInput, 0, vInput).normalized * movementForce, ForceMode.Force); // Aplica fuerza de movimiento.
    }

    void Saltar()
    {
        if (enSuelo) // Salto normal.
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            enSuelo = false;
        }
        else if (dobleSaltoDisponible) // Doble salto.
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            dobleSaltoDisponible = false;
        }
    }

    void setTextoColeccionables()
    {
        coleccionablesText.text = "Coleccionables: " + coleccionables.ToString(); // Actualiza texto.
    }

    void setTextoVidas()
    {
        vidasText.text = "Vidas: " + vidas.ToString(); // Actualiza texto.
    }

    private void FinDelJuego()
    {
        coleccionables = 0;
        vidas = 3;
        SceneManager.LoadScene(4); // Carga escena de fin de juego.
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo")) // Restablece salto en suelo.
        {
            enSuelo = true;
            dobleSaltoDisponible = true;
        }
        else if (collision.gameObject.CompareTag("Plataforma")) // Restablece salto en plataforma.
        {
            enSuelo = true;
        }
        else if (collision.gameObject.CompareTag("SueloSinSalto")) // Desactiva salto.
        {
            enSuelo = false;
            dobleSaltoDisponible = false;
        }

        if (collision.gameObject.CompareTag("Pinchos")) // Daño por pinchos.
        {
            transform.position = new Vector3(0, 0.5f, 0); // Resetea posición.
            vidas--;
            setTextoVidas();
            sonidoDanio.Play();

            if (vidas <= 0) // Fin del juego si no hay vidas.
            {
                FinDelJuego();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plataforma")) // Desactiva salto al salir de plataforma.
        {
            enSuelo = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable")) // Recoge coleccionable.
        {
            other.gameObject.SetActive(false);
            coleccionables++;
            setTextoColeccionables();
            sonidoColeccionable.Play();

            if (coleccionables >= 7) // Fin del juego al recoger 7.
            {
                FinDelJuego();
            }
        }

        if (other.gameObject.CompareTag("Vida")) // Recoge vida.
        {
            other.gameObject.SetActive(false);
            vidas++;
            setTextoVidas();
            sonidoVida.Play();
        }

        if (other.gameObject.CompareTag("EnemigoIA")) // Daño por enemigo.
        {
            transform.position = new Vector3(0, 0.5f, 5.5f); // Resetea posición.
            vidas--;
            setTextoVidas();
            sonidoDanio.Play();

            if (vidas <= 0) // Fin del juego si no hay vidas.
            {
                FinDelJuego();
            }
        }

        if (other.gameObject.CompareTag("Lava")) // Daño por lava.
        {
            transform.position = new Vector3(0, 0.5f, -20); // Resetea posición.
            rb.linearVelocity = Vector3.zero; // Detiene movimiento.
            rb.angularVelocity = Vector3.zero; // Detiene rotación.
            vidas--;
            setTextoVidas();
            sonidoDanio.Play();

            if (vidas <= 0) // Fin del juego si no hay vidas.
            {
                FinDelJuego();
            }
        }
    }
}