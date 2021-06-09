using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_Movement : MonoBehaviour
{

    private CharacterController controller;

    public float speed = 12f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;


        controller.Move( move* speed * Time.deltaTime);
    }
}
