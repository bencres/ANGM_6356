using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;

    private static PlayerController instance;

    
    // Player movement stuff 
    private Rigidbody2D rb_player;
    private BoxCollider2D groundedCheck;
    private Collider2D collidedObject;
    private GameObject obj1;

    private bool isYoung = false;
    
    // Player sprite stuff
    public Sprite[] playerSprites;
    private SpriteRenderer SpriteRenderer;
    private int currentSpriteIndex = 0;


    [SerializeField] private LayerMask jumpableGround;
    private float Speed;
    private float Jump;

    [SerializeField] private Player young;
    [SerializeField] private Player old;
    
    [System.Serializable]
    private struct Player
    {
        public Sprite playerSprite;
        public float Speed;
        public float Jump;
    }
    
    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    private void Start()
    {
        // Find the GameManager in the scene
        gameManager = FindObjectOfType<GameManager>();
        rb_player = GetComponent<Rigidbody2D>();
        groundedCheck = GetComponent<BoxCollider2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        
        PickPlayer();
    }

    private void Update()
    {
        // Check for the "f" key press
        float tempSpeed = Speed;
        float tempJump = Jump;
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("pressed f");
            isYoung = !isYoung;
            PickPlayer();
            // Toggle between loading the next and previous levels
            LoadNextOrPreviousLevel();
        }
        float dirX = Input.GetAxisRaw("Horizontal");

        rb_player.velocity = new Vector2(dirX * Speed, rb_player.velocity.y);
    
        if (Input.GetButtonDown("Jump") && IsGrounded() == true)
        {
            rb_player.velocity = new Vector2(rb_player.velocity.x, Jump);
        }
    }

    private void LoadNextOrPreviousLevel()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int targetLevelIndex = CalculateTargetLevelIndex(currentLevelIndex);

        Debug.Log("loaded next level");
        
        Debug.Log("Player current pos: " + transform.position);

        // save the player's current position before loading a new level
        gameManager.SavePlayerPosition(transform.position);

        // load the target level
        SceneManager.LoadScene(targetLevelIndex);

        // place the player at the saved position in the new level
        transform.position = gameManager.savedPlayerPosition;
        Debug.Log("updated player transform");
    }

    private int CalculateTargetLevelIndex(int currentLevelIndex)
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;

        // calculate the target level index based on the current level index
        // and toggle between next and previous levels
        int targetLevelIndex = currentLevelIndex + 1;
        if (targetLevelIndex >= sceneCount)
        {
            targetLevelIndex = 0;
        }

        return targetLevelIndex;
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(groundedCheck.bounds.center, groundedCheck.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void PickPlayer()
    {

        if (isYoung)
        {
            SpriteRenderer.sprite = young.playerSprite;
            Speed = young.Speed;
            Jump = young.Jump;
        }
        else
        {
            SpriteRenderer.sprite = old.playerSprite;
            Speed = old.Speed;
            Jump = old.Jump;
        }
    }
}
