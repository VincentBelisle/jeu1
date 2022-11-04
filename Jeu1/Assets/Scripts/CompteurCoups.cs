using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[RequireComponent(typeof(TextMeshProUGUI))]

public class CompteurCoups : MonoBehaviour
{
    private int nombreCoups;
    private TextMeshProUGUI etiquette;


    void Start()
    {
        nombreCoups = 0;
        etiquette = GetComponent<TextMeshProUGUI>();

        // Lorsque la balle est tiré, augmente le nombre de coups
        DragTir.OnTir += IncrementerCoup;

        GestionTrou.ReussiteTrou += MiseAZeroNbCoups;

    }

    private void MiseAZeroNbCoups()
    {
        nombreCoups = 0;
        AfficherNombre(nombreCoups);
    }
   
    private void AfficherNombre(int nombre)
    {
        etiquette.text = $"{nombre}";
    }

    private void IncrementerCoup()
    {
        nombreCoups++;
        AfficherNombre(nombreCoups);
    }
}
