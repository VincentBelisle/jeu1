using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionBalleProche : MonoBehaviour
{
   // private bool balleDetectee;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter(Collider col)
    {
        print(col.tag);
        if (col.tag == "Balle")
        {
        }

    }
    private void OnTriggerExit(Collider col)
    {
        print(col.tag);
        
        if (col.tag == "Balle")
        {
        }

        print("bye");
    }


}
