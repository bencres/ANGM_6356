using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private GameManager gm;

    private static PlayerController instance;

    
    // Player movement stuff 
    private Rigidbody2D rb_player;
    private BoxCollider2D groundedCheck;
    private Collider2D collidedObject;
    private GameObject obj1;

    private bool isYoung = false;


    
    // Player sprite stuff
    // public Sprite[] playerSprites;
    // public Sprite[] pss1;
    // public Sprite[] pss2;
    // public Sprite[] pss3;
    private SpriteRenderer SpriteRenderer;
    // private int currentSpriteIndex = 0;
    


    [SerializeField] private LayerMask jumpableGround;
    private float Speed;
    private float Jump;

    [SerializeField] private Player young;
    [SerializeField] private Player old;
    [SerializeField] private Player young1;
    [SerializeField] private Player old1;    
    [SerializeField] private Player young2;
    [SerializeField] private Player old2;    
    [SerializeField] private Player young3;
    [SerializeField] private Player old3;    
    [SerializeField] private Player young4;
    [SerializeField] private Player old4;
    
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
        gm = FindObjectOfType<GameManager>();
        rb_player = GetComponent<Rigidbody2D>();
        groundedCheck = GetComponent<BoxCollider2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        
        NewPickPlayer();
    }

    private void Update()
    {
        // Check for the "f" key press
        float tempSpeed = Speed;
        float tempJump = Jump;
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Debug.Log("pressed f");
            isYoung = !isYoung;
            NewPickPlayer();
            // Toggle between loading the next and previous levels
            // LoadNextOrPreviousLevel();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            NewPickPlayer();
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

        // Debug.Log("loaded next level");
        
        // Debug.Log("Player current pos: " + transform.position);

        // save the player's current position before loading a new level
        gm.SavePlayerPosition(transform.position);

        // load the target level
        SceneManager.LoadScene(targetLevelIndex);

        // place the player at the saved position in the new level
        transform.position = gm.savedPlayerPosition;
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

    public void NewPickPlayer()
    {
        if (isYoung)
        {
            switch (gm.GetStage())
            {
                case 0:
                    SpriteRenderer.sprite = young.playerSprite;
                    Speed = young.Speed;
                    Jump = young.Jump;
                    break;
                case 1:
                    SpriteRenderer.sprite = young1.playerSprite;
                    Speed = young.Speed;
                    Jump = young.Jump;
                    break;
                case 2:
                    SpriteRenderer.sprite = young2.playerSprite;
                    Speed = young.Speed;
                    Jump = young.Jump;
                    break;
                case 3:
                    SpriteRenderer.sprite = young3.playerSprite;
                    Speed = young.Speed;
                    Jump = young.Jump;
                    break;
                case 4:
                    SpriteRenderer.sprite = young4.playerSprite;
                    Speed = young.Speed;
                    Jump = young.Jump;
                    break;
            }
        }
        else
        {
            switch (gm.GetStage())
            {
                case 0:
                    SpriteRenderer.sprite = old.playerSprite;
                    Speed = old.Speed;
                    Jump = old.Jump;
                    break;                
                case 1:
                    SpriteRenderer.sprite = old1.playerSprite;
                    Speed = old.Speed;
                    Jump = old.Jump;
                    break;
                case 2:
                    SpriteRenderer.sprite = old2.playerSprite;
                    Speed = old.Speed;
                    Jump = old.Jump;
                    break;
                case 3:
                    SpriteRenderer.sprite = old3.playerSprite;
                    Speed = old.Speed;
                    Jump = old.Jump;
                    break;
                case 4:
                    SpriteRenderer.sprite = old4.playerSprite;
                    Speed = old.Speed;
                    Jump = old.Jump;
                    break;
            }
        }

    }
}
