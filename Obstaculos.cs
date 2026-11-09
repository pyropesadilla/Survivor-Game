using UnityEngine;

public class Obstaculos : MonoBehaviour
{
   [Header("Configuración del movimiento")]
    public float distance = 2f;        // Distancia que baja en el eje Y
    public float speed = 2f;           // Velocidad con la que baja

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool shouldMoveDown = false;
    private bool isMoving = false;

    void Start()
    {
        // Guardamos la posición inicial
        initialPosition = transform.position;
        // Calculamos la posición hacia la que bajará
        targetPosition = initialPosition - new Vector3(0, distance, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Si el objeto que colisiona tiene el tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            shouldMoveDown = true;
            isMoving = true;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            if (shouldMoveDown)
            {
                // Mover hacia abajo
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

                // Si ya llegó al destino, detener el movimiento
                if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
                {
                    isMoving = false;
                }
            }
        }
    }
}