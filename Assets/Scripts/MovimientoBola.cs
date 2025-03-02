using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; // Importante para cambiar de escena

public class MovimientoBola : MonoBehaviour
{
    public AudioSource sonidoVida;
    public AudioSource sonidoDanio;
    public AudioSource sonidoColeccionable;

    public TextMeshProUGUI coleccionablesText;
    public TextMeshProUGUI vidasText;

    private Rigidbody rb;
    [SerializeField] private float movementForce;
    [SerializeField] private float jumpForce;
    private float hInput, vInput;
    private bool enSuelo = true;
    private bool dobleSaltoDisponible = true;
    private int vidas;
    private int coleccionables;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coleccionables = 0;
        vidas = 3;
        setTextoColeccionables();
        setTextoVidas();
    }

    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Saltar();
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(hInput, 0, vInput).normalized * movementForce, ForceMode.Force);
    }

    void Saltar()
    {
        if (enSuelo)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            enSuelo = false;
        }
        else if (dobleSaltoDisponible)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            dobleSaltoDisponible = false;
        }
    }

    void setTextoColeccionables()
    {
        coleccionablesText.text = "Coleccionables: " + coleccionables.ToString();
    }

    void setTextoVidas()
    {
        vidasText.text = "Vidas: " + vidas.ToString();
    }

    private void FinDelJuego()
    {
        coleccionables = 0;
        vidas = 3;
        SceneManager.LoadScene(4); // Cambia "Menu" por el nombre de la escena donde está el Panel de Fin de Juego
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
            dobleSaltoDisponible = true;
        }
        else if (collision.gameObject.CompareTag("Plataforma"))
        {
            enSuelo = true;
        }
        else if (collision.gameObject.CompareTag("SueloSinSalto"))
        {
            enSuelo = false;
            dobleSaltoDisponible = false;
        }

        if (collision.gameObject.CompareTag("Pinchos"))
        {
            transform.position = new Vector3(0, 0.5f, 0);
            vidas--;
            setTextoVidas();
            sonidoDanio.Play();

            if (vidas <= 0)
            {
                FinDelJuego(); // Cambia de escena cuando el jugador pierde todas sus vidas
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            enSuelo = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            other.gameObject.SetActive(false);
            coleccionables++;
            setTextoColeccionables();
            sonidoColeccionable.Play();

            if (coleccionables >= 7)
            {
                FinDelJuego(); // Cambia de escena cuando el jugador recoge 7 coleccionables
            }
        }

        if (other.gameObject.CompareTag("Vida"))
        {
            other.gameObject.SetActive(false);
            vidas++;
            setTextoVidas();
            sonidoVida.Play();
            
        }

        if (other.gameObject.CompareTag("EnemigoIA"))
        {
            transform.position = new Vector3(0, 0.5f, 5.5f);
            vidas--;
            setTextoVidas();
            sonidoDanio.Play();

            if (vidas <= 0)
            {
                FinDelJuego(); // Cambia de escena cuando el jugador pierde todas sus vidas
            }
        }

        if (other.gameObject.CompareTag("Lava"))
        {
            transform.position = new Vector3(0, 0.5f, -20);
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            vidas--;
            setTextoVidas();
            sonidoDanio.Play();

            if (vidas <= 0)
            {
                FinDelJuego(); // Cambia de escena cuando el jugador pierde todas sus vidas
            }
        }
    }
}
