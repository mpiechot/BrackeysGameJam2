using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour
{
    public float MoveSpeed;
    public int score { get; set; }

    private Vector2 moveVector;
    private Rigidbody2D rb;
    private GameObject tileMask;

    private Vector2 lastDirection;
    private Essen carry;
    private bool particleActive;
    private float particleActiveTime;
    public SpriteRenderer carrySprite;
    public BouncePulse carryBounce;

    public Quest quest;
    public ParticleSystem footsteps;
    public Transform CharacterSprite;
    private float walkTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tileMask = transform.Find("TileMask").gameObject;
        tileMask.SetActive(true);
        carrySprite.color = new Color(1, 1, 1, 0.1f);
        particleActive = false;
        particleActiveTime = 0;
        quest = null;
    }

    void Update()
    {
        HandleMovement();
        HandleInteraction();
        HandleParticle();
    }

    private void HandleInteraction()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, lastDirection, 2f, 1 << LayerMask.NameToLayer("Interactable"));
            if (hit.collider != null)
            {
                InteractObject obj = hit.collider.gameObject.GetComponent<InteractObject>();
                if (obj.CanGetIngredient)
                {
                    if (carry == null || carry.ZutatenListe.Count < 5)
                    {
                        CollectIngredients(obj);
                        particleActiveTime = 0.1f;
                    }
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
            obj.AddFood(carry);
            carry = null;
            carrySprite.color = new Color(1, 1, 1, 0.1f);
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
        carrySprite.color = new Color(1, 1, 1, Mathf.Clamp01(0.2f * carry.ZutatenListe.Count));
        carryBounce.StartAnimating();
    }

    void HandleMovement()
    {
        float xMove = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        float yMove = Input.GetAxisRaw("Vertical") * MoveSpeed;

        moveVector = new Vector2(xMove, yMove) * Time.deltaTime * 60f;
        if(moveVector != Vector2.zero)
        {
            lastDirection = moveVector;
            carrySprite.transform.position = transform.position + (Vector3)moveVector.normalized + Vector3.back * 0.3f;
            particleActive = true;
            CharacterSprite.localRotation = Quaternion.FromToRotation(Vector2.up, moveVector.normalized);
            walkTimer += moveVector.magnitude;
            CharacterSprite.localScale = new Vector3(walkTimer < 100 ? -0.26482f : 0.26482f, 0.26482f, 0.26482f);
            if (walkTimer > 200)
                walkTimer = 0;
        }
        else
        {
            particleActive = false;
        }
        rb.velocity = moveVector;
    }

    public Essen GetEssen()
    {
        return carry;
    }


    void HandleParticle()
    {
        if ((particleActive || particleActiveTime > 0) && !footsteps.loop)
        {
            footsteps.Play();
            footsteps.loop = true;
        }
        else if(!(particleActive || particleActiveTime > 0))
            footsteps.loop = false;
        particleActiveTime -= Time.deltaTime;
    }
}
