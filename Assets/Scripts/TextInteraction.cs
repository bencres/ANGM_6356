using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextInteraction : Interactable
{
    // Start is called before the first frame update
    public string interactionText = "Default Interaction Text";
    public TextMeshProUGUI displayText;

    private void Start()
    {
        displayText.enabled = false;
        Debug.Log("Disabled display text.");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            displayText.text = "Press 'E' to interact.";
            displayText.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            displayText.enabled = false;
        }
    }

    public void Interact()
    {
        // Implement the specific interaction behavior here.
        // For example, display the dog's "bark bark" text.
        Debug.Log("text interacted");
        displayText.text = interactionText;
    }

}
