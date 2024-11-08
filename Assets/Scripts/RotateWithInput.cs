using UnityEngine;

public class RotateWithInput : MonoBehaviour
{
    // Velocidad base de rotación ajustable desde el Inspector
    public float rotationSpeed = 100f;

    // Dirección de rotación controlada por teclado o botones (-1 izquierda, 1 derecha, 0 sin rotación)
    private float rotationDirection = 0f;

    // Booleano para controlar si la rotación es automática
    public bool isAutoRotating = false;

    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");


        // Control de rotación

        if (horizontalInput != 0)
        {
            RotateWithKeyboardInput();
        }
        if (isAutoRotating)
        {
            RotateAutomatically();
        }
        

        RotateObject();

        // Aplicar la rotación en el eje Y del GameObject
    }

    // Método para iniciar la rotación hacia la izquierda (para botón)
    public void StartRotationLeft()
    {
        isAutoRotating = false;  // Desactivar rotación automática al usar botón
        rotationDirection = -1f;
    }

    // Método para iniciar la rotación hacia la derecha (para botón)
    public void StartRotationRight()
    {
        isAutoRotating = false;  // Desactivar rotación automática al usar botón
        rotationDirection = 1f;
    }

    // Método para detener la rotación (para botón)
    public void StopRotation()
    {
        rotationDirection = 0f;
    }

    // Método para habilitar o deshabilitar la rotación automática (vinculado a un Toggle)
    public void SetAutoRotation(bool value)
    {
        isAutoRotating = value;

        // Al desactivar la rotación automática, detenemos cualquier rotación
        if (!isAutoRotating)
        {
            rotationDirection = 0f;
        }
    }

    // Método que controla la rotación con las teclas izquierda/derecha o A/D
    private void RotateWithKeyboardInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0)
        {
            // Desactivar rotación automática al detectar input del teclado
            isAutoRotating = false;

            // Establecemos la dirección y hacemos que sea 5 veces más rápida
            rotationDirection = horizontalInput * 5f;
        }
    }

    // Método que aplica la rotación en el eje Y del GameObject
    private void RotateObject()
    {
        // Velocidad final depende de si es rotación manual (5x) o automática (1x)
        float currentRotationSpeed = isAutoRotating ? rotationSpeed : rotationSpeed * 5f;

        float rotationAmount = -rotationDirection * currentRotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotationAmount, 0);
    }

    // Método para rotación automática hacia la derecha
    private void RotateAutomatically()
    {
        rotationDirection = 1f;
    }
}
