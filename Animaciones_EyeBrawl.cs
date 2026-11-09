using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animaciones_EyeBrawl : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update

    private Vector3 posicionAnterior;
    void Start()
    {
    animator = GetComponent<Animator>();
    posicionAnterior = transform.position;
    }
    

    // Update is called once per frame
    void Update()
    {
        //walk cycle
        Walking();
        //ataques
         if (Input.GetMouseButtonDown(0))
        animator.SetTrigger("A1");

        if (Input.GetMouseButtonDown(1))
            animator.SetTrigger("A2");

        if (Input.GetMouseButtonDown(2))
            animator.SetTrigger("A3");
            
        
    }

    void Walking()
    {
        bool presionandoWASD =
            Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D);
        if (presionandoWASD)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }

    void Ataque()
    {
     if (Input.GetMouseButtonDown(0))
        {animator.SetBool("A1", true);
        animator.SetBool("A2", false);
        animator.SetBool("A3", false);
        StartCoroutine(DesactivarDespuesDeTiempo(0.5f));
        animator.SetBool("A1", false);}

        if (Input.GetMouseButtonDown(1))
        {animator.SetBool("A1",false);
        animator.SetBool("A2", true);
        animator.SetBool("A3", false);
        StartCoroutine(DesactivarDespuesDeTiempo(2f));
        animator.SetBool("A2", false);}

        if (Input.GetMouseButtonDown(2))
        {animator.SetBool("A1",false);
        animator.SetBool("A2", false);
        animator.SetBool("A3", true);
        StartCoroutine(DesactivarDespuesDeTiempo(0.3f));
        animator.SetBool("A3", false);}   
    }
    IEnumerator DesactivarDespuesDeTiempo(float tiempo)
        {
        yield return new WaitForSeconds(tiempo);
        }
}
