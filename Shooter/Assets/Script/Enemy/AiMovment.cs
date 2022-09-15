using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
public class AiMovment : MonoBehaviour
{
    public static UnityEvent<string> OnAction = new UnityEvent<string>();

    [SerializeField]
    private float _maxDistanceWalk;
    [SerializeField]
    private float _maxAngleRotation;
    [SerializeField]
    private float _speedMove;
    [SerializeField]
    private float _speedRotation;
    [SerializeField]
    private float _rangeView;

    float _distanceWalk = 0;
    float _angleRotation = 0;
    Rigidbody2D _rigidbody2D;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(Movment());

    }

    // Update is called once per frame
    IEnumerator Movment()
    {
        while(true){
            Collider2D target = Physics2D.OverlapCircleAll(transform.position, _rangeView).Where(x => x.tag == "Player").FirstOrDefault();
            if (_distanceWalk == 0)
                _distanceWalk = UnityEngine.Random.Range(-_maxDistanceWalk / 2, _maxDistanceWalk / 2);
            if (_angleRotation == 0 && target == null)
                _angleRotation = UnityEngine.Random.Range(-_maxAngleRotation / 2, _maxAngleRotation / 2);
            if (target != null) {
                Vector3 current = transform.up;
                Vector3 to = target.transform.position - transform.position;
                _angleRotation = Vector3.SignedAngle(current, to, transform.forward);
            }

            MoveAndRotate(_distanceWalk, _angleRotation);


            yield return new WaitForSeconds(1f);
        }
    }
    void MoveAndRotate(float distanceWalk, float koefRotate)
    {
        
        for (int i = 0; i < Math.Abs(koefRotate); i++)
            _rigidbody2D.angularVelocity = Math.Sign(koefRotate) * _speedRotation * 100 * Time.fixedDeltaTime;
        _angleRotation = 0;
        OnAction.Invoke(Math.Sign(koefRotate) < 0 ? "Enemy move left" : "Enemy move right");
        var koeef = Math.Sign(distanceWalk);
        _rigidbody2D.velocity = transform.up * koeef * _speedMove * 10 * Time.fixedDeltaTime;
        _distanceWalk -= koeef;
        OnAction.Invoke(koeef < 0 ? "Enemy move back" : "Enemy move forward");
    }
}
