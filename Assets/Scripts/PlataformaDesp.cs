using UnityEngine;
using System.Collections;

public class PlataformaDesp : MonoBehaviour
{
    private Renderer rend;
    private Color originalColor;
    private float originalAlpha;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
        originalAlpha = originalColor.a; // Guarda el alpha original (243 en 0-255, que es ≈0.95 en Unity)

        StartCoroutine(AlphaCycle());
    }

    IEnumerator AlphaCycle()
    {
        while (true)
        {
            // Desaparece la plataforma (Alpha = 0)
            SetAlpha(0);
            yield return new WaitForSeconds(2f);

            // Reaparece la plataforma (Alpha = 243/255 ≈ 0.95)
            SetAlpha(0.95f);
            yield return new WaitForSeconds(2f);
        }
    }

    void SetAlpha(float alpha)
    {
        Color newColor = originalColor;
        newColor.a = alpha;
        rend.material.color = newColor;
    }
}
