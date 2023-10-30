using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    public virtual void Interact()
    {
        // This is a placeholder method that can be overridden in derived classes.
        Debug.Log("Interacting with " + gameObject.name);
    }
}
