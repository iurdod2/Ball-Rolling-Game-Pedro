using UnityEngine;
using System.Collections;

public class PlataformaDesp : MonoBehaviour
{
    private Renderer rend; // Componente Renderer para cambiar el color.
    private Color originalColor; // Guarda el color original.
    private float originalAlpha; // Guarda el valor alpha original.

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
        originalAlpha = originalColor.a; // Almacena el alpha original (≈0.95).

        StartCoroutine(AlphaCycle()); // Inicia la corrutina para cambiar el alpha.
    }

    IEnumerator AlphaCycle()
    {
        while (true) // Ciclo infinito.
        {
            // Desaparece la plataforma (alpha = 0).
            SetAlpha(0);
            yield return new WaitForSeconds(2f); // Espera 2 segundos.

            // Reaparece la plataforma (alpha ≈ 0.95) (243/255 ≈ 0.95).
            SetAlpha(0.95f);
            yield return new WaitForSeconds(2f); // Espera 2 segundos.
        }
    }

    void SetAlpha(float alpha)
    {
        Color newColor = originalColor; // Crea un nuevo color basado en el original.
        newColor.a = alpha; // Cambia el valor alpha.
        rend.material.color = newColor; // Aplica el nuevo color al material.
    }
}