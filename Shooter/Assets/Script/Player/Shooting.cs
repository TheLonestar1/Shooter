using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Shooting : MonoBehaviour
{
    [SerializeField]
    private float _speedBullet;
    [SerializeField]
    private GameObject _bulletPrefab;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(_bulletPrefab);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * _speedBullet,ForceMode2D.Impulse);
        }
    }

}
