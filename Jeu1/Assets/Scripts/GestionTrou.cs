using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionTrou : MonoBehaviour

{
    private AudioSource sonTrouReussi;

    public float tempsAttente = 2f;

    private bool balleSortie;

  
    public static event Action ReussiteTrou;


    void Start()
    {
        balleSortie = false;
        sonTrouReussi = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider col)
    {
       
        if(col.tag == "Balle")
        {
            balleSortie = false;
            StartCoroutine(DelaiAttente());
        }

    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Balle")
        {
            balleSortie = true;
        }
    }
    private IEnumerator DelaiAttente()
    {
        yield return new WaitForSecondsRealtime(tempsAttente);

        // Si la balle n'est pas sortie après deux secondes
        if (balleSortie == false)
        {
            TrouReussi();

            StopAllCoroutines();
        }
    }

    private void TrouReussi()
    {
        sonTrouReussi.Play();

        ReussiteTrou?.Invoke();
    }
}

