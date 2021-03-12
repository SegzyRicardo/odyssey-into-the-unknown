using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane_Rotation : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        Vector3 relativePos = target.position - transform.position;

        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }


    /*public List<Transform> transforms;
    List<Quaternion> rotations = new List<Quaternion>();
    Quaternion avg;
    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < (transforms.Count-2); i++)
        {
            Vector3 p1 = transforms[i].transform.position;
            Vector3 p2 = transforms[i + 1].transform.position;
            Vector3 p3 = transforms[i + 2].transform.position;
            Vector3 vec1 = p1 - p3;
            Vector3 vec2 = p2 - p3;
            Vector3 normalVec = Vector3.Cross(vec1, vec2);

            Quaternion planeNormal = Quaternion.LookRotation(normalVec);
            rotations.Add(planeNormal);
            //Debug.Log(planeNormal);
            if (i != 0)
            {
                Quaternion avg = Quaternion.Lerp(rotations[i-1], rotations[i], (1/i+1));
            }
        }
        for(int i = 0; i < (rotations.Count-2); i++)
        {
            Quaternion avg = Quaternion.Lerp(rotations[i - 1], rotations[i], (1 / (i + 2)));
            Debug.Log(avg);
        }
        transform.rotation = rotations[0];
    }*/
}
