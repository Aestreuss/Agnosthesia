using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void FixedUpdate()
    {
        if (canMove)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            transform.position += new Vector3(horizontal, vertical, 0) * Time.deltaTime * speed;
        }

    }


}
