using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject panelPrincipal;
    public void OnLevelOneButtonClicked() {
        SceneManager.LoadScene(1);
    }

    public void OnTwoOneButtonClicked() {
        SceneManager.LoadScene(2);
    }

    public void OnVolverMenuPrincipal() {
        SceneManager.LoadScene(3);
    }
}