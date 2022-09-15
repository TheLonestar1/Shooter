using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExitZone : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Border"))
        {
            Destroy(gameObject);
        }
    }
}
