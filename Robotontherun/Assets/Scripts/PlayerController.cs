// Taken from Unity 2d tutorial: https://unity3d.com/learn/tutorials/topics/2d-game-creation/horizontal-movement?playlist=17093
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlayerController : Physics
{
    // Floats
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    // References
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Stats
    public int currentHealth;
    public int maxHealth = 100;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        // Start the game with max health.
        currentHealth = maxHealth;
    }

    // Allows the player to 'die'.
    void Die()
    {
        // If you die restart the game.
        Application.LoadLevel(Application.loadedLevel);
    }

    void Update()
    {
        ComputeVelocity();

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");


        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;

        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        bool flipSprite = false;

        if (spriteRenderer.flipX == false && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)))
        {
            flipSprite = true;
        }
        else if (spriteRenderer.flipX == true && (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)))
        {
            flipSprite = true;
        }

        // Flips sprite if needed
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetFloat("Speed", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
}
