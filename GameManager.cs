using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using AuraAPI;

public class GameManager : MonoBehaviour
{
    public GameObject auraVolume;
    public float skyBoxFogStart;
    public float skyBoxFogEnd;
    //public Material skyboxMat;
    //public Material skyboxMat_onFire;


    // Start is called before the first frame update
    void Start()
    {
        auraVolume.SetActive(false);
    }
    void ProgressScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (FireController.lightingShift == true)
        {
            // if we're shifting lighting, trigger Aura volume on
            auraVolume.SetActive(true);
            //RenderSettings.skybox = skyboxMat_onFire;//(Material)Resources.Load("skyboxMat_onFire");
            //DynamicGI.UpdateEnvironment();
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (OVRInput.Get(OVRInput.Button.One))
        {
            ProgressScene();
        }
    }
}
