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
    private float lookAhead;
    [SerializeField] private float minYLimit = -5f; // Límite mínimo para la cámara

private void Update()
{
    float targetY = Mathf.Max(player.position.y, minYLimit); // Evita que la cámara baje más allá de minYLimit
    Vector3 targetPosition = new Vector3(player.position.x + lookAhead, targetY, transform.position.z);
    transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * cameraSpeed);
}

    //public void MoveToNewRoom(Transform _newRoom)
    //{
   //     currentPosX = _newRoom.position.x+7.2f;
    //}
}