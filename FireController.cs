using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
    private bool movable = true;
    public float fireSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        fireStarter = false;
        movable = true;
        fireYHeight = fireWall.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (fireStarter && movable)
        {
            fireWall.transform.Translate(Vector3.forward * Time.deltaTime * fireSpeed);

            RaycastHit hit;
            Physics.Raycast(fireWall.transform.position, Vector3.down, out hit);
            if (hit.point.y != fireYHeight)
            {
                fireYHeight = hit.point.y + yOffset;
                var newPos = new Vector3(fireWall.transform.position.x, fireYHeight, fireWall.transform.position.z);
                fireWall.transform.position = newPos;
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
            else if(other.tag == "river")
            {
                // if we hit river, stop
                movable = false;
            }
        }
    }
}
