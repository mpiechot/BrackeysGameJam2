using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour
{

    public float MoveSpeed;

    private Vector2 moveVector;
    private Rigidbody2D rb;
    private GameObject tileMask;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tileMask = transform.Find("TileMask").gameObject;
        tileMask.SetActive(true);
    }


    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        float xMove = Input.GetAxis("Horizontal") * MoveSpeed;
        float yMove = Input.GetAxis("Vertical") * MoveSpeed;



        moveVector = new Vector2(xMove, yMove) * Time.deltaTime * 60f;
        rb.velocity = moveVector;
    }

}
