using UnityEngine;

// Ensure the component is present on the gameobject the script is attached to
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;

    Animator animator;
    string currentState;
    const string PLAYER_IDLE = "Idle";
    const string PLAYER_WALK_LEFT = "WLeft";
    const string PLAYER_WALK_RIGHT = "WRight";
    const string PLAYER_WALK_UP = "WUp";
    const string PLAYER_WALK_DOWN = "WDown";


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed).normalized;

        if(body.velocity == Vector2.zero)
        {
            ChangeAnimationState(PLAYER_IDLE);
        }
        if(horizontal > 0)
        {
            ChangeAnimationState(PLAYER_WALK_RIGHT);
        }
        if (horizontal < 0)
        {
            ChangeAnimationState(PLAYER_WALK_LEFT);
        }
        if (vertical > 0 && horizontal == 0)
        {
            ChangeAnimationState(PLAYER_WALK_UP);
        }
        if (vertical < 0 && horizontal == 0)
        {
            ChangeAnimationState(PLAYER_WALK_DOWN);
        }
    }

    void ChangeAnimationState(string newState) {

        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;

    }

}
