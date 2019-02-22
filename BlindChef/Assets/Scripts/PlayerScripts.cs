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

    public Quest quest;
    public ParticleSystem footsteps;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tileMask = transform.Find("TileMask").gameObject;
        tileMask.SetActive(true);
        carrySprite.enabled = false;
        quest = null;
    }


    void Update()
    {
        HandleMovement();
        HandleInteraction();
    }

    private void HandleInteraction()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, lastDirection, 2f, 1 << LayerMask.NameToLayer("Interactable"));
            //Debug.DrawLine(transform.position, (Vector2)transform.position + lastDirection);
            if (hit.collider != null)
            {
                InteractObject obj = hit.collider.gameObject.GetComponent<InteractObject>();
                if (obj.CanGetIngredient)
                {
                    CollectIngredients(obj);
                }
                else
                {
                    PutFoodDown(obj);
                }

            }

        }
    }

    private void PutFoodDown(InteractObject obj)
    {
        if (carry != null && obj.IsEmpty)
        {
            //TODO Place Item to this position!
            obj.AddFood(carry);
            carry = null;
            carrySprite.enabled = false;
        }
    }

    private void CollectIngredients(InteractObject obj)
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

    void HandleMovement()
    {
        float xMove = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        float yMove = Input.GetAxisRaw("Vertical") * MoveSpeed;

        

        moveVector = new Vector2(xMove, yMove) * Time.deltaTime * 60f;
        if(moveVector != Vector2.zero) {
            lastDirection = moveVector;
            carrySprite.gameObject.transform.position = (Vector2)transform.position + moveVector.normalized;
            if (footsteps.isStopped)
            {
                footsteps.Play();
            }
        }
        else
        {
            footsteps.Stop();
           
        }
        rb.velocity = moveVector;
    }

    public Essen GetEssen()
    {
        return carry;
    }
}
