using UnityEngine;

public class IntroCameraController : MonoBehaviour
{   
    [SerializeField] private Transform startPoint;  // El punto de inicio de la cámara
    [SerializeField] private Transform endPoint;    // El punto final donde la cámara llegará
    [SerializeField] private float cameraSpeed; // Velocidad de la cámara

    [SerializeField] private Camera mainCamera; // La cámara que debe seguir al IntroCamera

    private bool isMoving = true;

    private void Start()
    {
        // Asegúrate de que el objeto IntroCamera empiece en el startPoint
        transform.position = startPoint.position;
    }

    private void Update()
    {
        // Mover el objeto IntroCamera entre el punto de inicio y el punto final
        if (isMoving)
        {
            // Mueve el objeto IntroCamera
            transform.position = Vector3.Lerp(transform.position, endPoint.position, Time.deltaTime * cameraSpeed);

            // Si el objeto alcanza el punto final, detén el movimiento
            if (Vector3.Distance(transform.position, endPoint.position) < 0.1f)
            {
                isMoving = false;
            }
        }

        // Ahora, la cámara sigue el objeto IntroCamera
        if (mainCamera != null)
        {
            // Asegúrate de que la cámara siga al objeto en los ejes X e Y pero mantenga su Z
            mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
        }

        // Detectar cualquier tecla y cargar la siguiente escena
        if (Input.anyKeyDown)
        {
            // Cambiar a la escena principal (por ejemplo, la escena del juego)
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene"); // Asegúrate de tener la escena MainScene en el Build Settings
        }
    }
}
