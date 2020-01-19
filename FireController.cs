using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    /// <summary>
    /// Controller for fire, which should:
    /// - move fire straight from start line to finish (river), updating y val as it moves along terrain
    /// - tigger FireClimbers at base of trees when it hits them, which start burning at base of trunk
    ///     and then climb the tree, triggering the destruction of leaves
    /// - change the terrain texture as it passes over
    /// </summary>
    /// 

    public GameObject fireWall;
    public float yOffset = 5.5f;
    public float fireYHeight = 0f;
    public static bool fireStarter = false;
    public static bool lightingShift = false;
    private bool movable = true;
    public float fireSpeed = 2f;
    public float randomSpeedMult = 0.9f;
    // Start is called before the first frame update
    void Start()
    {
        fireStarter = false;
        lightingShift = false;
        movable = true;
        fireYHeight = fireWall.transform.position.y;
        randomSpeedMult = Random.Range(0.85f, 1.25f);
    }

    // Update is called once per frame
    void Update()
    {
        // when x val of fireWall reaches 80, trigger lighting shift
        if (fireStarter && movable)
        {
            fireWall.transform.Translate(Vector3.forward * Time.deltaTime * fireSpeed * randomSpeedMult);

            RaycastHit hit;
            Physics.Raycast(fireWall.transform.position, Vector3.down, out hit);
            if (hit.point.y != fireYHeight)
            {
                fireYHeight = hit.point.y + yOffset;
                var newPos = new Vector3(fireWall.transform.position.x, fireYHeight, fireWall.transform.position.z);
                fireWall.transform.position = newPos;
            }

            // check x val of firewall
            if(fireWall.transform.position.x >= 80)
            {
                lightingShift = true;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("fire just hit " + other.gameObject);
        if (fireStarter)
        {
            if (other.tag == "tree")
            {
                other.gameObject.GetComponentInChildren<ParticleSystem>().Play();
            }
            else if(other.tag == "animal")
            {
                other.gameObject.GetComponentInChildren<ParticleSystem>().Play();
                other.gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
            }
            else if(other.tag == "river")
            {
                // if we hit river, stop
                movable = false;
                gameObject.SetActive(false);
            }
        }
    }
}
