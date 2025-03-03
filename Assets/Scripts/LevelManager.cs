using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para manejar escenas.

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject panelPrincipal; // Referencia al panel de la UI.

    // Carga la escena con índice 1 (Nivel 1).
    public void OnLevelOneButtonClicked() {
        SceneManager.LoadScene(1);
    }

    // Carga la escena con índice 2 (Nivel 2).
    public void OnTwoOneButtonClicked() {
        SceneManager.LoadScene(2);
    }

    // Carga la escena con índice 3 (Menú principal).
    public void OnVolverMenuPrincipal() {
        SceneManager.LoadScene(3);
    }
}