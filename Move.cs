using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public float rotationSpeed = 10f;
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); 
        float moveZ = Input.GetAxis("Vertical");   

        Vector3 move = new Vector3(moveX,0.0f,moveZ);
        if (move.magnitude > 0.01f)
        {
            // Movimiento
            transform.position += move.normalized * moveSpeed * Time.deltaTime;
        }
    }
}
