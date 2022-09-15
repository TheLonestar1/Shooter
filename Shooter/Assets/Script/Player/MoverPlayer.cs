using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MoverPlayer : MonoBehaviour
{
    [SerializeField]
    private int _speedPlayer;

    [SerializeField]
    private int _speed;

    private Rigidbody2D _rigidbody2D;

    private Vector2 _movmentPosition;

    public static UnityEvent<string> OnAction = new UnityEvent<string>();

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

        if (_movmentPosition != null)
        {
            _rigidbody2D.velocity = transform.up * _movmentPosition.y * _speedPlayer * 100 * Time.fixedDeltaTime;
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
                StartCoroutine(SendAction(Mathf.Sign(_movmentPosition.y) < 0 ? "Player move back" : "Player move forward"));
            _rigidbody2D.angularVelocity = -_movmentPosition.x * _speed * 100 * Time.fixedDeltaTime;
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
                StartCoroutine(SendAction(Mathf.Sign(_movmentPosition.x) < 0 ? "Player move rigth" : "Player move left"));
        }
    }
    
    

    IEnumerator SendAction(string action)
    {
        yield return new WaitForSeconds(.5f);
        OnAction.Invoke(action);
    }
    private void InputMovement()
    {
        float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");

        _movmentPosition = new Vector2(mx, my);

    }
}
