using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [Header("Objeto a seguir")]
    public Transform target;  // El objeto que este seguirá

    [Header("Opciones")]
    public bool followPosition = true;
    public bool followRotation = false;
    public bool followScale = false;

    void Update()
    {
        if (target == null) return;

        // Seguir posición
        if (followPosition)
            transform.position = target.position;

        // Seguir rotación
        if (followRotation)
            transform.rotation = target.rotation;

        // Seguir escala
        if (followScale)
            transform.localScale = target.localScale;
    }
}
