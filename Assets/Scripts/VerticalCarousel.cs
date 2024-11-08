using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class VerticalCarousel : MonoBehaviour
{
    public ScrollRect scrollRect; // Referencia al ScrollRect del carrusel
    public float transitionDuration = 0.5f; // Duración de la animación
    public int currentIndex = 0; // Índice del elemento actual
    public GameObject[] totalItems; // Total de elementos en el carrusel

    private void Start()
    {
        UpdateCarousel(); // Asegurarse de que el índice actual esté actualizado al inicio
    }

  

    [ContextMenu("Move To Next")] // Permite llamar a este método desde el menú contextual en el Inspector
    public void MoveToNext()
    {
        Debug.Log("Se activó el cambio de carrusel al siguiente elemento.");
        if (currentIndex < totalItems.Length - 1)
        {
            currentIndex++;
            UpdateCarousel();
        }
    }

    [ContextMenu("Move To Previous")] // Permite llamar a este método desde el menú contextual en el Inspector
    public void MoveToPrevious()
    {
        Debug.Log("Se activó el cambio de carrusel al elemento anterior.");
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateCarousel();
        }
    }

    // Método para actualizar el carrusel según el índice actual
    private void UpdateCarousel()
    {
        // Validar que el índice esté dentro del rango
        currentIndex = Mathf.Clamp(currentIndex, 0, totalItems.Length - 1);
        ScrollToIndex(currentIndex);
    }

    // Método para desplazarse al índice especificado
    public void ScrollToIndex(int index)
    {
        // Calcula la posición normalizada en el eje vertical
        float normalizedPosition = 1 - (float)index / (totalItems.Length - 1);
        Debug.Log("Posición normalizada: " + normalizedPosition);

        // Usa DOTween para animar el valor de verticalNormalizedPosition
        DOTween.To(() => scrollRect.verticalNormalizedPosition,
                   x => scrollRect.verticalNormalizedPosition = x,
                   normalizedPosition,
                   transitionDuration)
               .SetEase(Ease.OutCubic); // Cambia la curva de easing según la suavidad que desees
    }
}
