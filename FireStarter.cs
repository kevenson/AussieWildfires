using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStarter : MonoBehaviour
{
    /// <summary>
    /// Starts wildfire based on timer
    /// </summary>

    public float timeDelayToStartFires = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartYourFires");
    }
    private IEnumerator StartYourFires()
    {
        yield return new WaitForSeconds(timeDelayToStartFires);
        FireController.fireStarter = true;
    }


    // Update is called once per frame
    void Update()
    {
        //if(startFires)
        //{
        //    FireController.fireStarter = true;
        //}
    }
}
