using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    [SerializeField]
    float _walkSpeed = 5;

    [SerializeField]
    float _maxSpeed = 50;

    [SerializeField]
    float _jumpForceAmount = 100;

    [SerializeField]
    Transform _groundPoint;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement functionality
        Move();
       //Jump fucntionality
       Jump();
    }

    void Move()
    {
        float xDirection = Input.GetAxisRaw("Horizontal");

        Debug.Log(xDirection);

        if(xDirection > 0)
        {
            _rigidbody.AddForce(Vector2.right * _walkSpeed * Time.deltaTime);
        }
        else if (xDirection < 0)
        {
            _rigidbody.AddForce(Vector2.left * _walkSpeed * Time.deltaTime);
        }


        _rigidbody.velocity = Vector2.ClampMagnitude(_rigidbody.velocity, _maxSpeed);
    }


    void Jump()
    {
        RaycastHit2D hit = Physics2D.CircleCast(_groundPoint.position, .1f, Vector2.down, .1f,LayerMask.GetMask("Ground"));

        //Check the input 
        float _isJumping = Input.GetAxisRaw("Jump");

        if(hit && _isJumping == 1)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForceAmount);
        }
    }
}
