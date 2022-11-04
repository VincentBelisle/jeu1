using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SuivreBalle : MonoBehaviour
{

    private float RotationX = 0f;
    
    private float vitesseRotation = 5f;

    public Rigidbody balle;

    [SerializeField] LineRenderer ligne;


    void Update()
    {

        // Attache la caméra à la balle
        transform.position = balle.position;



      
        if (Input.GetMouseButton(0))
        {

            float ancienneRotation = RotationX;

            RotationX += Input.GetAxis("Mouse X") * vitesseRotation;

            // Applique la rotation en X sur la caméra
            transform.rotation = Quaternion.Euler(0f, RotationX, 0f);


            if (RotationX != ancienneRotation)
            {
                balle.constraints = RigidbodyConstraints.FreezeRotation;

                balle.transform.rotation = Quaternion.Euler(0f, RotationX, 0f);


            }
        }
    }
     

    public void ModifierVitesseRotation(float vitesse)

    {

        vitesseRotation = vitesse;

    }


}



    