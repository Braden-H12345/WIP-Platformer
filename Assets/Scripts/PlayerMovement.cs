using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float _horizontal;
    private float _vertical;
    private bool _isFacingRight = true;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRender;


    public float _speedScaling = 8f;

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
        _vertical = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            _horizontal = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _horizontal = 1f;
        }
         if (Input.GetKey(KeyCode.W))
        {
            _vertical = 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _vertical = -1f;
        }



        Flip();

    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_horizontal * _speedScaling, _vertical * _speedScaling);
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
