using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena.

public class MuerteManager : MonoBehaviour
{
    [SerializeField] private GameObject panelPrincipal; // Referencia al panel de la UI.

    // Método para volver al menú principal.
    public void OnVolverMenuPrincipal() {
        SceneManager.LoadScene(3); // Carga la escena con índice 3 (menú principal).
    }
}