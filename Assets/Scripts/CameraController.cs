using UnityEngine;

public class CameraController : MonoBehaviour
{
   //Room camera
    //[SerializeField] private float speed;
    //private float currentPosX;
    //private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;

    [SerializeField] private float verticalSmoothness = 5f;

    [SerializeField] private float horizontalSmoothness = 3f; 
    private float lookAhead;

 private void Update()
    {
        // Movimiento en X (adelanta la cámara en la dirección en la que se mueve el jugador)
        lookAhead = Mathf.Lerp(lookAhead, aheadDistance * Mathf.Sign(player.localScale.x), Time.deltaTime * horizontalSmoothness);

        // Movimiento en Y (suave, pero sin bloquear la bajada)
        float targetY = Mathf.Lerp(transform.position.y, player.position.y, Time.deltaTime * verticalSmoothness);


        // Posición final de la cámara
        Vector3 targetPosition = new Vector3(player.position.x + lookAhead, targetY, transform.position.z);
        transform.position = targetPosition;
    }
}