using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    float horizontal;
    float vertical;

    public bool canMove = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody> ();
    }

    private void Update()
    {
        if (canMove)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
        }

    }

    private void FixedUpdate()
    {
        if (canMove)
            transform.position += new Vector3(horizontal, vertical, 0) * Time.deltaTime * speed;
    }
}
