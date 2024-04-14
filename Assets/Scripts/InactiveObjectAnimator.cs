using UnityEngine;

public class InactiveObjectAnimator : MonoBehaviour
{
    public string animationName; // Name of the animation to play

    public Animator animator; // Reference to the Animator component

    void Start()
    {
    }

    void OnEnable()
    {
        // Check if the Animator component is assigned and the animation name is valid
        if (animator != null && !string.IsNullOrEmpty(animationName))
        {
            // Play the specified animation
            animator.Play(animationName);
            Debug.Log("Animation name: "+ animationName);
        }
    }
}