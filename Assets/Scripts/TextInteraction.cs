using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    public string interactionText = "Default Interaction Text";
    public string notYetText = "Oops, not yet bud!";
    public string firstInRangeText;
    public string otherInRangeText;
    public TextMeshProUGUI displayText;
    public int thisStage;
    private GameManager gm;
    private int overallStage;
    private int overallStagePlusOne;
    public bool disappear;
    private GameObject go;
    // private bool inRange = false;
    public bool showLate = false;
    private int thisStagePlusOne;
    // private bool isKeyToy = false;
    public Sprite firstSprite;
    public Sprite otherSprite;
    private SpriteRenderer spr;
    public Sprite sprite1;
    public Sprite sprite2;
    private int pressedFCount = 0;
    public bool swap = false;
    private GameObject dkt;
    private GameObject[] sceneGOs;
    public Sprite blankSprite;
    public string blankString;
    public bool updateStage = false;
    
    // Post process stuff
    // public KeyCode flashKey = KeyCode.Space;
    // public float flashDuration = 0.1f;
    // public Color flashColor = Color.green;

    private void Awake()
    {
        // Debug.Log("The VERY FIRST value of showLate is: " + showLate);
    }

    private void Start()
    {
        displayText.enabled = false;
        // Debug.Log("Disabled display text.");
        gm = FindObjectOfType<GameManager>();
        go = gameObject;
        // Debug.Log("Call start; the value of showLate is " + showLate + " and the object is named: " + go.name);
        // if (showLate)
        // {
        //     go.SetActive(false);
        // }

        // if (go.name == "SPR_keyDogToy_v1001")
        // {
        //     go.SetActive(false);
        // }
        spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            pressedFCount++;
            // Debug.Log("Pressed F. The value of pressedFCount is: " + pressedFCount);
            
            if ((pressedFCount % 2) == 0)
            {
                // if (swap)
                // {
                //     go.SetActive(false);
                //     Debug.Log("Disabled " + go.name);
                // }
                // else
                // {
                //     go.SetActive(true);
                //     Debug.Log("Enabled " + go.name);
                // }
                spr.sprite = firstSprite;
                // displayText.text = firstText;
            }
            else
            {
                // if (swap)
                // {
                //     go.SetActive(true);
                //     Debug.Log("Enabled " + go.name);
                // }
                // else
                // {
                //     go.SetActive(false);
                //     Debug.Log("Disabled " + go.name);
                // }
                spr.sprite = otherSprite;
                // displayText.text = otherText;
            }
            

            // Debug.Log("Pressed F; the value of game stage is: " + gm.GetStage());
        }

        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //     if ((pressedFCount) % 2 != 0)
        //     {
        //         if (go.name == "SPR_keyDogToy_v1001")
        //         {
        //             go.SetActive(true);
        //         }
        //     }
        // }
    }

    // public void showKeyToy()
    // {
    //     go.SetActive(true);
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        { 
            // displayText.text = "Press 'E' to interact.";
            if ((pressedFCount % 2) == 0)
            {
                displayText.text = firstInRangeText;
            }
            else
            {
                displayText.text = otherInRangeText;
            }
            displayText.enabled = true;
            // inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            displayText.enabled = false;
            // inRange = false;
        }
    }

    public void Interact()
    {
        displayText.text = interactionText;
        overallStage = gm.GetStage();
        // Debug.Log("overall stage before mod is: " + overallStage + " | this stage before mod is: " + thisStage);
        overallStagePlusOne = overallStage + 1;
        thisStagePlusOne = thisStage + 1;
        // Debug.Log("overall stage plus one is: " + overallStagePlusOne);
        // Debug.Log("The player interacted with text; the value of showLate is: " + showLate + 
                  // " and the object is named: " + go.name + 
                  // " | the value of thisStage is: " + thisStage + 
                  // " | the value of this stage plus one is: " + thisStagePlusOne + 
                  // " | and the value of the game stage is: " + overallStage + 
                  // " | the value of the game stage plus one is: " + overallStagePlusOne);

        if (thisStage == overallStagePlusOne)
        {
            // Debug.Log("Made it inside set stage update.");
            displayText.text = interactionText;
            if (updateStage)
            {
                gm.SetStage(thisStage);
            }
            
            if (disappear)
            {
                // Debug.Log("Making " + go.name + "disappear.");
                go.SetActive(false);
            }

            // if (gm.GetStage() == 2)
            // {
            //     dkt = GameObject.FindWithTag("testTag");
            //     dkt.SetActive(true);
            // }


        }
        else
        {
            displayText.text = notYetText;
        }
        
        // Debug.Log("Ended interaction. The value of the game stage is: " + gm.GetStage());

    }

}
