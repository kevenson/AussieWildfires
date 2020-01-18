using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStarter : MonoBehaviour
{
    public bool startFires = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startFires)
        {
            FireController.fireStarter = true;
        }
    }
}
