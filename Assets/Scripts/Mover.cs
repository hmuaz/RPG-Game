using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform target;
    Camera cam;
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            MoveToCursor();
        }


    }

    void MoveToCursor()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        bool hashit = Physics.Raycast(ray, out hit);
        Debug.Log(hashit);
        if (hashit)
        {
            GetComponent<NavMeshAgent>().destination = hit.point;
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        }

    }
}
