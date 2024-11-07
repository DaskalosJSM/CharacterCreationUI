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
        // Inicialización si es necesario
    }

    [ContextMenu("Move To Next")] // Permite llamar a este método desde el menú contextual en el Inspector
    public void MoveToNext()
    {
        Debug.Log("Se activo el cambio de carrusel");
        if (currentIndex < totalItems.Length - 1)
        {
            currentIndex++;
            ScrollToIndex(currentIndex);
        }
    }

    [ContextMenu("Move To Previous")] // Permite llamar a este método desde el menú contextual en el Inspector
    public void MoveToPrevious()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            ScrollToIndex(currentIndex);
        }
    }
private void ScrollToIndex(int index)
{
    // Calcula la posición normalizada en el eje vertical
    float normalizedPosition = 1 - (float)index / (totalItems.Length - 1);
    
    Debug.Log("Normalized Position: " + normalizedPosition);

    // Usa DOTween para animar el valor de verticalNormalizedPosition
    DOTween.To(() => scrollRect.verticalNormalizedPosition,
               x => scrollRect.verticalNormalizedPosition = x,
               normalizedPosition,
               transitionDuration)
           .SetEase(Ease.OutCubic); // Cambia la curva de easing según la suavidad que desees
}
}
