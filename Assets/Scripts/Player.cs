using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
 

    // Declare variables.
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    private Vector3 direction;
    private const float gravity = -28.4f;
    private const float strength = 8.0f;
    private const float degrees = 20;
    

    // Search for player component.
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Call AnimateSprite every .15 seconds.
    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    // Reset player position when starting game.
    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
    
    public void Update()
    {
        // Player jumps when spacebar, up arrow key, left mouse click input is received.
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up*strength;
            transform.rotation = Quaternion.Euler(Vector3.forward * degrees);
        }

        // Update player position.
       if (direction.y < 10.0f)
       {
            direction.y += gravity * Time.deltaTime;
            transform.rotation = Quaternion.Euler(Vector3.forward * (4*direction.y));
       }
        transform.position += direction * Time.deltaTime;
    }

    // Cycle through sprite array to show sprite changes as player moves.
    private void AnimateSprite()
    {
        spriteIndex++;

        if(spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    // Handle collision with objects.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else if(other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}
