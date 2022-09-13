using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPlayer : MonoBehaviour
{
    [SerializeField]
    private int _speedPlayer;

    [SerializeField]
    private int _speed;

    private Rigidbody2D _rigidbody2D;

    private Vector2 _movmentPosition;



    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        InputMovement();
    }
    private void FixedUpdate()
    {
        _rigidbody2D.velocity = (transform.up * _movmentPosition.y * _speedPlayer * 100 * Time.fixedDeltaTime);
        _rigidbody2D.angularVelocity = -_movmentPosition.x * _speed * 100 * Time.fixedDeltaTime;
    }


    private void InputMovement()
    {
        float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");

        _movmentPosition = new Vector2(mx, my).normalized;
    }
}
