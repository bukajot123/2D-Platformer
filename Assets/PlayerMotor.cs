using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    Vector2 direction;
    private bool canJump = true;
    private Rigidbody2D rigidbody2D;
    public float speed = 10;
    public float jumpForce = 10;
    public float maxSpeed = 10;
    public float stoppingForce = 5;
    public float multijump;
    public float max_jumps = 2;
    public float dahForce = 10;
    private float dashTime;
    public float dashDuration = 0.2f;
    private Animator _animator;
    private float initXScale;

   
    private void Start()
    {
        rigidbody2D= GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        initXScale = transform.localScale.x;
    }
    
    private void FixedUpdate()
    {
        MovePLayer();
        HandleMaxSpeed();
        PlayerStopping();
        if(direction.x !=0)
        {
            _animator.SetBool("IsMoving", true);

        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }

        if(direction.x > 0)
        {
            transform.localScale = new Vector3(initXScale, transform.localScale.y, transform.localScale.z);
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(-initXScale, transform.localScale.y, transform.localScale.z);
        }
    }

    private void MovePLayer()
    {
        rigidbody2D.AddForce(new Vector2(direction.x * speed, 0));
    }

    private void HandleMaxSpeed()
    {
        if (dashTime > 0)
        {
            dashTime -= Time.fixedDeltaTime;
            return; 
        }
        if (rigidbody2D.linearVelocityX >= maxSpeed)
        {
            rigidbody2D.linearVelocityX = maxSpeed;
        }
        else if (rigidbody2D.linearVelocityX <= -maxSpeed)
        {
            rigidbody2D.linearVelocityX = -maxSpeed;
        }
    }

    private void PlayerStopping()
    {
        if (direction.x == 0 && rigidbody2D.linearVelocityX != 0)
        {
            rigidbody2D.AddForce(new Vector2(-rigidbody2D.linearVelocityX * stoppingForce, 0));
        }
    }

    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }

    private void OnJump()
    {
        if (canJump)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            if(multijump > 0)
            {
                multijump--;
            }
            else if(multijump == 0)
            {
                canJump = false;
            }
            
         
            
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
       canJump = true;
        multijump = max_jumps;
    }

    private void OnDash()
    {
        float dashDirection;

        if (direction.x != 0)
        {
            
            dashDirection = direction.x;
        }
        else
        {
            
            dashDirection = 2f;
        }

        rigidbody2D.AddForce(new Vector2(dashDirection * dahForce, 0), ForceMode2D.Impulse);
        dashTime = dashDuration;

        Debug.Log("Dash w kierunku: " + dashDirection);
    }


}

