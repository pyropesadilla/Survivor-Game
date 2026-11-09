using UnityEngine;
using System.Collections;

public class AtaqueSimple : MonoBehaviour
{
    // Referencia al objeto que queremos activar
    [SerializeField] private GameObject AtaqueBase;
    [SerializeField] private GameObject AtaqueArea;
    [SerializeField] private GameObject AtaqueLargo;

   

    void Start()
    {
        // Asegurarse de que el objeto comience desactivado
        if (AtaqueBase != null) AtaqueBase.SetActive(false);
        if (AtaqueArea != null) AtaqueArea.SetActive(false);
        if (AtaqueLargo != null) AtaqueLargo.SetActive(false);
        
    }

    void Update()
    {
        
        
        if (Input.GetMouseButtonDown(0))
        {

            if (AtaqueBase != null)
            {
                // Activar el objeto
                AtaqueBase.SetActive(true);
                AtaqueArea.SetActive(false);
                AtaqueLargo.SetActive(false);
                //Debug.Log("Objeto activado con clic izquierdo.");
                //animator.SetBool("A1", true);
                StartCoroutine(DesactivarDespuesDeTiempo(AtaqueBase, 0.5f));
            }
            else
            {
                //Debug.LogWarning("No se ha asignado un objeto en el inspector.");
            }
        }

        if (Input.GetMouseButtonDown(1))
        {

            if (AtaqueBase != null)
            {
                // Activar el objeto
                AtaqueBase.SetActive(false);
                AtaqueArea.SetActive(true);
                AtaqueLargo.SetActive(false);
                //Debug.Log("Objeto activado con clic izquierdo.");
                //animator.SetBool("A2", true);
                StartCoroutine(DesactivarDespuesDeTiempo(AtaqueArea, 2f));
            }
            else
            {
                //Debug.LogWarning("No se ha asignado un objeto en el inspector.");
            }
        }

        if (Input.GetMouseButtonDown(2))
        {

            if (AtaqueBase != null)
            {
                // Activar el objeto
                AtaqueBase.SetActive(false);
                AtaqueArea.SetActive(false);
                AtaqueLargo.SetActive(true);
                //Debug.Log("Objeto activado con clic izquierdo.");
                //animator.SetBool("A3", true);
                StartCoroutine(DesactivarDespuesDeTiempo(AtaqueLargo, 1f));
            }
            else
            {
                //Debug.LogWarning("No se ha asignado un objeto en el inspector.");
            }
        }
        //animator.SetBool("A1", false);
        //animator.SetBool("A2", false);
        //animator.SetBool("A3", false);
    }

    IEnumerator DesactivarDespuesDeTiempo(GameObject objeto, float tiempo)
        {
            yield return new WaitForSeconds(tiempo);
            DesactivarObjeto(objeto);
        }

    void DesactivarObjeto(GameObject objetoADesactivar)
    {
        if (objetoADesactivar != null)
        {
            objetoADesactivar.SetActive(false);
            //Debug.Log($"{objetoADesactivar.name} desactivado automáticamente después de 1 segundo.");
        }
        else
        {
            //Debug.LogWarning("No se ha especificado ningún objeto para desactivar.");
        }
    }
}
