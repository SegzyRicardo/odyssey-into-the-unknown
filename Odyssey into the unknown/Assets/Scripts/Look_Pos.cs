using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look_Pos : MonoBehaviour
{
    public Camera cam;
    public float MaxLenght = 5000;
    public LayerMask Layer;
    public Transform obj;

    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, MaxLenght, Layer))
        {
            Debug.DrawLine(cam.transform.position, hit.point, Color.blue);
            obj.transform.position = hit.point;
        }
            
    }
}
