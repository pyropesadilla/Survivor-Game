using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarPlayer3D : MonoBehaviour
{
    [SerializeField] private Camera camara;
    [SerializeField] private float alturaPlano = 0f; // Altura del plano donde el jugador mira (ej: el suelo)
    
    void Update()
    {
        // Creamos un rayo desde la cámara hacia donde apunta el mouse
        Ray rayo = camara.ScreenPointToRay(Input.mousePosition);
        Plane plano = new Plane(Vector3.up, new Vector3(0, alturaPlano, 0)); // Plano horizontal

        float distancia;

        // Si el rayo intersecta con el plano, calculamos el punto objetivo
        if (plano.Raycast(rayo, out distancia))
        {
            Vector3 puntoObjetivo = rayo.GetPoint(distancia);

            // Calculamos la dirección en el plano XZ
            Vector3 direccion = (puntoObjetivo - transform.position);
            direccion.y = 0; // Evita que el personaje se incline hacia arriba o abajo

            if (direccion.sqrMagnitude > 0.001f) // Evita errores si el vector es muy pequeño
            {
                Quaternion rotacion = Quaternion.LookRotation(direccion);
                transform.rotation = rotacion;
            }
        }
    }
}
