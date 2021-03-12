using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Center : MonoBehaviour
{
    public CharacterController controller;
    public Transform player;
    public Transform cam;
    public float turnSmooth = 0.3f;
    float turnVeloc;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        transform.position = player.transform.position;

        if (direction.magnitude > 0f)
        {
            float targetAngle = cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVeloc, turnSmooth);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }
}
