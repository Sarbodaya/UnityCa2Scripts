﻿using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    public float radius = 3f;
    public Transform interactionTransform;
    bool isFocus = false;

    Transform player;
    bool hasInteracted = false;

    public virtual void Interact()
    {
    	//This method should be overwritten
    	Debug.Log("Interacting with"+transform.name);

    }

    void Updat()
    {
    	if(isFocus && !hasInteracted)
    	{
    		float distance = Vector3.Distance(player.position,interactionTransform.position);
    		if(distance <= radius)
    		{
    			Interact();
    			hasInteracted = true;
    		}
    	}
    }

    public void OnFocused(Transform playerTransform)
    {
    	isFocus = true;
    	player = playerTransform;
    	hasInteracted = false;
    }

    public void OnDeFocused()
    {
    	isFocus = false;
    	player = null;
    	hasInteracted = false;
    } 

    void OnDrawGizmosSelected()
    {
    	if(interactionTransform == null)
    	{
    		interactionTransform = transform;
    	}
    	Gizmos.color = Color.yellow;
    	Gizmos.DrawWireSphere(interactionTransform.position,radius);
    }
}
