using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    float _speed = 5;

    Rigidbody2D _rigidbody;

    [SerializeField]
    Transform _groundPoint;

    [SerializeField]
    Transform _headPoint;
    bool _isThereObstacleFrontOfMe = false;

    [SerializeField]
    LayerMask _collidingLayers;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void FixedUpdate()
    {
        _isThereObstacleFrontOfMe = Physics2D.Linecast(_groundPoint.position, _headPoint.position, _collidingLayers);

        if( _isThereObstacleFrontOfMe )
        {
            ChangeDirection();
        }

        Move();
    }
    void Move()
    {
        _rigidbody.AddForce(Vector3.right * transform.localScale.x * _speed);
    }

    void ChangeDirection()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
    }
}
