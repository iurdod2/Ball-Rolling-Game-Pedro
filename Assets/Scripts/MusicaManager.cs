using UnityEngine;

public class MusicaManager : MonoBehaviour
{
    private static MusicaManager instancia; // Singleton para evitar duplicados

    private void Awake()
    {
        // Si no hay ninguna instancia de MusicaManager, esta será la principal
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject); // Evita que se destruya al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Si ya existe una instancia, destruye esta para evitar duplicados
        }
    }
}
