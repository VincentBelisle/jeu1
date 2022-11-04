using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class GestionJeu : MonoBehaviour
{

    public GameObject balle;

    public GameObject[] departTrous;

    public GameObject drapeau;

    private int index = 0;


    private void Awake()
    {
        departTrous = GameObject.FindGameObjectsWithTag("departTrou");
    }



    // Start is called before the first frame update
    void Start()
    {
       
        // Affiche une fenêtre au début du jeu
        EditorUtility.DisplayDialog("Bienvenue", "Bonjour et bienvenue à mon jeu de mini-golf, voici les contrôles du jeu:" +
            "Cliquez sur la balle et chargez votre tir en glissant la souris, il est aussi possible de bouger la caméra de gauche " +
            "à droite lorsque qu'on clique et se déplace avec la souris", "Ok");

        balle.transform.position = departTrous[index].transform.position;

        // Ajout de 1f en Y pour ne pas que la balle apparaisse en dessous du terrain.
        balle.transform.position = new Vector3(balle.transform.position.x, balle.transform.position.y + 1f, balle.transform.position.z);


        GestionTrou.ReussiteTrou += TeleportationNiveau;


    }

    // Update is called once per frame
    void Update()
    {
        if (balle.transform.position.y < -5)
        {
            balle.GetComponent<Rigidbody>().velocity = Vector3.zero;

            ResetBalleDebutNiveau();
        }
    }


    private void ResetBalleDebutNiveau()
    {
        balle.transform.position = departTrous[index].transform.position;
        // Ajout de 0.1 en Y car sinon la balle est trop basse par rapport au terrain.
        balle.transform.position = new Vector3(balle.transform.position.x, balle.transform.position.y + 0.1f, balle.transform.position.z);
    }

   
    private void TeleportationNiveau()
    {
        if (index < departTrous.Length - 1)
        {
           
            index++;
            balle.transform.position = departTrous[index].transform.position;

            balle.transform.position = new Vector3(balle.transform.position.x,balle.transform.position.y + 1f,balle.transform.position.z);

            // Lorsqu'on est au dernier trou, ajouter un drapeau.
           if (index == departTrous.Length - 1)
            {
                AjoutDrapeau();
            }
        }
        else
        {
            //Jeu terminé
            QuitterJeu();
        }

    }
    /// <summary>
    /// Instancie un drapeau au départ du trou,
    /// </summary>
    private void AjoutDrapeau()
    {
        Instantiate(drapeau, departTrous[index].transform);
    }

 
    public void QuitterJeu()
    {
        // Quitte le jeu dans l'éditeur
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
