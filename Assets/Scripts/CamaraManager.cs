using UnityEngine;

public class CamaraManager : MonoBehaviour
{
    [Header("Lista de cámaras")]
    public GameObject[] cameras;

    [Header("Índice de la cámara activa")]
    [Range(0, 3)] // Ajusta el rango según el tamaño de tu lista de cámaras
    public int activeCameraIndex = 0;

    private int previousIndex = -1;

    void Start()
    {
        UpdateCameraState();
    }

    void Update()
    {
        // Si el índice cambió en el editor, actualizamos el estado de las cámaras
        if (activeCameraIndex != previousIndex)
        {
            UpdateCameraState();
            previousIndex = activeCameraIndex;
        }
    }

    private void UpdateCameraState()
    {
        // Desactiva todas las cámaras
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].SetActive(i == activeCameraIndex);
        }
    }
}
