using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class DragTir : MonoBehaviour
{


    private Vector3 positionSourisPressDown;
    private Vector3 positionSourisPressUp;

    private bool balleNeBougePlus;

    [SerializeField] LineRenderer ligne;


    public float multiplicateurForce = 3;

    public static event Action OnTir;


    private Rigidbody rb;


    private void Awake()

    {
        ligne.enabled = false;

        rb = GetComponent<Rigidbody>();
        
    }


    private void Update()
    {
        ligne.SetPosition(0, rb.transform.position);
        ligne.SetPosition(1, rb.transform.position  + rb.transform.forward * 1f);


        balleNeBougePlus = BalleNeBougePlus();

    }


    private void OnMouseDown()
    {

        if (balleNeBougePlus)
        {
            ligne.enabled = true;
            positionSourisPressDown = Input.mousePosition;
        }

    }

    private void OnMouseUp()
    {
        if (ligne.enabled == true)
        {

            rb.constraints = RigidbodyConstraints.None;

            positionSourisPressUp = Input.mousePosition;

            Tirer(positionSourisPressDown.y - positionSourisPressUp.y);

            ligne.enabled = false;
        }
        
    }



    private void Tirer(float force)
    {

        if (balleNeBougePlus)
        {
            rb.AddForce(transform.forward * force, ForceMode.Impulse);
            OnTir?.Invoke();
        }
        
      
    }

    private bool BalleNeBougePlus()
    {

        return rb.velocity == Vector3.zero;


    }
}
    



