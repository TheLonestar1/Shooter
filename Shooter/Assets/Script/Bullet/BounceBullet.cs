using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBullet : MonoBehaviour
{

    private Rigidbody2D _rigidbody2d;

    private Vector3 _lastVelocity;
    void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _lastVelocity = _rigidbody2d.velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
        {
            var speed = _lastVelocity.magnitude;
            var direction = Vector2.Reflect(_lastVelocity.normalized, collision.contacts[0].normal);

            _rigidbody2d.velocity = direction * Mathf.Max(speed, 0f);
        }
    }
}
