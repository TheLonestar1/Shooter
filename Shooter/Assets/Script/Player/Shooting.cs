using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Shooting : MonoBehaviour
{
    public static UnityEvent<string> OnAction = new UnityEvent<string>();

    [SerializeField]
    protected float _speedBullet;
    [SerializeField]
    protected GameObject _bulletPrefab;
    [SerializeField]
    protected int maxReflectionCount = 5;
    [SerializeField]
    protected float maxStepDistance = 200f;
    [SerializeField]
    protected LayerMask _layerMask;
    protected bool _isFire;
    protected void Start()
    {
        _isFire = true;
    }
    private void Update()
    {
        DrawReflectionPattern(transform.position + transform.up * 0.5f, transform.up, maxReflectionCount);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (_isFire)
            {
                _isFire = false;
                StartCoroutine(Shoot());
            }
        }
    }
    protected IEnumerator Shoot()
    {
        
        var bullet = Instantiate(_bulletPrefab);
        bullet.tag = tag;
        bullet.transform.SetPositionAndRotation(transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * _speedBullet, ForceMode2D.Impulse);
        OnAction.Invoke($"{tag} Shoot");
        yield return new WaitForSeconds(1f);
        _isFire = true;
    }
    private void DrawReflectionPattern(Vector3 position, Vector3 direction, int reflectionsRemaining)
    {
        if (reflectionsRemaining == 0)
        {
            return;
        }


        RaycastHit2D hit = Physics2D.Raycast(position, direction, maxStepDistance,_layerMask);
        if (hit.collider != null)
        {
            direction = Vector3.Reflect(direction, hit.normal);
            position = hit.point;
        }
        else
        {
            position += direction * maxStepDistance;
        }


        DrawReflectionPattern(position, direction, reflectionsRemaining - 1);


    }
}
