using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public Interactable focus;
	public LayerMask movementMask;

	Camera cam;

	PlayerMotor  motor;
    // Start is called before the first frame update
    void Start()
    {
    	cam = Camera.main;
    	motor = GetComponent<PlayerMotor>();
        
    }

    // Update is called once per frame
    void Update()
    {
    	if(Input.GetMouseButtonDown(0))
    	{
    		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
    		RaycastHit hit;

    		if(Physics.Raycast(ray,out hit,100,movementMask))
    		{
    			
    			// move our player whatever we hit
    			motor.MoveToPoint(hit.point);
                RemoveFocus();


    			// Stop focusing any object
    		}
    	}

        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit,100))
            {
                
                // move our player whatever we hit
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null)
                {
                    SetFocus(interactable);


                }
                // Stop focusing any object
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if(newFocus!= focus)
        {
            if(focus!=null)
            {
                focus.OnDeFocused();
            }
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }

        focus = newFocus;
        newFocus.OnFocused(transform);
    }
    void RemoveFocus()
    {
        if(focus!=null)
        {
            focus.OnDeFocused();
        }
        
        focus = null;
        motor.StopFollowingTarget();
    }
}
