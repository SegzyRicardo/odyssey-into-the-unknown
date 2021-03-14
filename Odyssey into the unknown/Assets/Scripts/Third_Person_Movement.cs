using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third_Person_Movement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float speed = 6.0f;
    public float turnSmooth = 0.2f;
    public float jumpHeight = 20f;
    public Transform waist;
    public LayerMask Layer;
    public Transform lookPosition;
    public Transform[] Legs = new Transform[2];
    

    private float turnVeloc;
    private Vector3 playerVelocity;
    private bool groundedPlayer = true;
    private float gravityValue = -9.81f;

    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;


        RaycastHit hit;
        Vector3 RayStart = new Vector3(waist.transform.position.x, waist.transform.position.y-4.8f, waist.transform.position.z);
        if (Physics.Raycast(RayStart, Vector3.down, out hit, 0.3f, Layer))
        {
            Debug.DrawLine(RayStart, hit.point, Color.magenta);
            if (hit.collider)
            {
                groundedPlayer = true;
            }
        }
        else
        {
            groundedPlayer = false;
        }

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
        }

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -1.0f * gravityValue);
        }

        if (direction.magnitude > 0f || Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            Vector3 a = Legs[0].position;
            Vector3 b = Legs[1].position;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Mathf.Atan2(lookPosition.position.x, lookPosition.position.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVeloc, turnSmooth);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            if(direction.magnitude > 0f)
            {
                Vector3 moveDirec = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDirec.normalized * speed * Time.deltaTime);
            }
            if (playerVelocity.y == 0)
            {
                Legs[0].position = a;
                Legs[1].position = b;
            }
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
