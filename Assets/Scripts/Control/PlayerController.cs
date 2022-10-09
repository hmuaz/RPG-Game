using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera cam;
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
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
            GetComponent<Mover>().MoveTo(hit.point);
        }

    }
}
