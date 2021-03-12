using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray_Down : MonoBehaviour
{
    public Transform RayStart;

    public LayerMask Layer;

    public float MaxLenght = 10.0f;

    [Header("Test Parameters")]

    public Transform HitMark;
    /*void Start()
    {

    }*/

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(RayStart.transform.position, Vector3.down, out hit, MaxLenght, Layer))
        {
            Debug.DrawLine(RayStart.transform.position, hit.point, Color.green);
            HitMark.transform.position = hit.point;
        }
    }
}

