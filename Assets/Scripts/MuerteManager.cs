using UnityEngine;
using UnityEngine.SceneManagement;

public class MuerteManager : MonoBehaviour
{
    [SerializeField] private GameObject panelPrincipal;

    public void OnVolverMenuPrincipal() {
        SceneManager.LoadScene(3);
    }
}