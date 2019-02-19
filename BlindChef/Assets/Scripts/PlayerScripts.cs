using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour
{
    public float MoveSpeed;

    private Vector2 moveVector;
    private Rigidbody2D rb;
    private GameObject tileMask;

    private Vector2 lastDirection;
    private Essen carry;
    public SpriteRenderer carrySprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tileMask = transform.Find("TileMask").gameObject;
        tileMask.SetActive(true);
        carrySprite.enabled = false;
    }


    void Update()
    {
        HandleMovement();
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position,lastDirection, 2f,LayerMask.NameToLayer("Interactable"));
            if(hit.collider != null)
            {
                InteractObject obj = hit.collider.gameObject.GetComponent<InteractObject>();
                if (obj.CanGetIngredient)
                {
                    if (carry == null)
                    {
                        carry = obj.GetFood();
                    }
                    else
                    {
                        carry.Merge(obj.GetFood());
                    }
                    carrySprite.enabled = true;
                }
                else
                {
                    if (carry != null && obj.IsEmpty)
                    {
                        //TODO Place Item to this position!
                        obj.AddFood(carry);
                        carry = null;
                        carrySprite.enabled = false;
                    }
                }
                
            }

        }
    }

    void HandleMovement()
    {
        float xMove = Input.GetAxis("Horizontal") * MoveSpeed;
        float yMove = Input.GetAxis("Vertical") * MoveSpeed;



        moveVector = new Vector2(xMove, yMove) * Time.deltaTime * 60f;
        lastDirection = moveVector;
        rb.velocity = moveVector;
    }

}
