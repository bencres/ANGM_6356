using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    public float interactionRange = 2f; // The maximum distance for interactions.
    public KeyCode interactKey = KeyCode.E; // The key to trigger interactions.

    private void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            Debug.Log("pressed " + interactKey);
            TryInteract();
        }
    }

    private void TryInteract()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactionRange);
        
        foreach (Collider2D collider in colliders)
        {
            TextInteraction interactable = collider.GetComponent<TextInteraction>();

            if (interactable != null)
            {
                // Call the interact method on the interactable object.
                Debug.Log("calling interactable method");
                interactable.Interact();
            }
        }
    }
}
