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
    // Calcula la altura de cada elemento asumiendo que todos son del mismo tamaño
    float itemHeight = totalItems[0].GetComponent<RectTransform>().rect.height;
    
    // Calcula la posición de desplazamiento en píxeles
    float targetPositionY = index * itemHeight;

    // Establece el límite superior e inferior para evitar ir más allá del contenido
    float maxPositionY = scrollRect.content.rect.height - scrollRect.viewport.rect.height;
    targetPositionY = Mathf.Clamp(targetPositionY, 0, maxPositionY);

    // Usa DOTween para animar el desplazamiento
    DOTween.To(() => scrollRect.content.anchoredPosition,
               pos => scrollRect.content.anchoredPosition = new Vector2(pos.x, -targetPositionY),
               new Vector2(scrollRect.content.anchoredPosition.x, -targetPositionY),
               transitionDuration)
           .SetEase(Ease.OutCubic); // Ajusta la curva de easing si es necesario
}
}
