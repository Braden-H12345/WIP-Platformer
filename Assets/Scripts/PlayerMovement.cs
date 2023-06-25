using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float _horizontal;
    private bool _isFacingRight = true;
    private Rigidbody2D _rb;
    private bool _allowJump = false;
    private SpriteRenderer _spriteRender;


    public float _speedScaling = 8f;
    public float _jumpScaling = 16f;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundCheckLayer;
    [SerializeField] private Transform _cameraTransform;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRender = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _horizontal = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            _horizontal = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _horizontal = 1f;
        }


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _allowJump = true;
        }

        Flip();

    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_horizontal * _speedScaling, _rb.velocity.y);

        if(_allowJump)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpScaling);
            _allowJump=false;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundCheckLayer);
    }

    private void Flip()
    {
        if (_rb.velocity.x > 0)
        {
            _spriteRender.flipX = false;
        }
        else if(_rb.velocity.x == 0)
        {
            //does nothing to keep the direction whatever it was before!
        }
        else
        {
            _spriteRender.flipX = true;
        }
    }
}
