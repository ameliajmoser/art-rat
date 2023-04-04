using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManController : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component on the man's body
    public Transform hairTransform; // Reference to the Transform (position) component of the man's hair

    private void Update()
    {
        // Get input from the player's controllers -- 
        // "HairPull" axis should be mapped to a controller movement that player uses to pull
        // on the hair, ie. moving their hands forwards and backwards
        // Can use Unity's Input Manager to create this Axis and map it to a controller movement.
        // Not sure how this works with VR controllers atm
        float hairPull = Input.GetAxis("HairPull"); 

        // Map hair pull to arm movement on the man's body RANDOMLY
        if (hairPull > 0.0f)
        {
            float direction = Random.Range(-1.0f, 1.0f);
            float speed = Random.Range(0.5f, 1.5f);
            animator.SetFloat("Horizontal", direction);
            animator.SetFloat("Vertical", speed);
        }
        else
        {
            animator.SetFloat("Horizontal", 0.0f);
            animator.SetFloat("Vertical", 0.0f);
        }
    }

    private void LateUpdate()
    {
        // Rotate the hair so that it matches player's view, otherwise they might not see it/could obstruct view
        Vector3 playerPosition = Camera.main.transform.position;
        Vector3 hairPosition = hairTransform.position;
        Vector3 lookAt = new Vector3(playerPosition.x, hairPosition.y, playerPosition.z);
        hairTransform.LookAt(lookAt);
    }
}
