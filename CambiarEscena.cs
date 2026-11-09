using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    [Header("Configuración")]
    public string sceneName = "Game"; // Nombre de la escena a la que cambiará
    public float delay = 6f;                      // Tiempo de espera en segundos

    void Start()
    {
        // Llama a la función para cambiar de escena después del retraso indicado
        Invoke(nameof(ChangeScene), delay);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
