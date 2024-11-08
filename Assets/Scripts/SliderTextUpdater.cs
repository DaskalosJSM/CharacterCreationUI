using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderTextUpdater : MonoBehaviour
{
    // Referencia al componente Slider
    public Slider slider;

    // Referencia al TextMeshPro
    public TextMeshProUGUI textMeshPro;

    // Método que actualiza el texto según el valor del slider
    void Start()
    {
        slider = this.gameObject.GetComponent<Slider>();
        // Asegurarse de que el método se llama cada vez que el valor del slider cambia
        slider.onValueChanged.AddListener(UpdateText);
        
        // Actualizar el texto al valor inicial del slider
        UpdateText(slider.value);
    }

    void UpdateText(float value)
    {
        // Cambiar el texto del TextMeshPro al valor actual del slider como entero
        textMeshPro.text = Mathf.RoundToInt(value).ToString() + "%" ;
    }

    // Destruir el listener cuando el objeto sea destruido para evitar errores
    void OnDestroy()
    {
        slider.onValueChanged.RemoveListener(UpdateText);
    }
}
