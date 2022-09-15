using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BulletCollustion : MonoBehaviour
{
    public static UnityEvent<string> OnKillSide = new UnityEvent<string>();
    public static UnityEvent OnReloadGame = new UnityEvent();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null && (collision.collider.tag == "Player" && collision.collider.tag != tag) ||
          (collision.collider.tag == "Enemy" && collision.collider.tag != tag))
        {

            OnKillSide.Invoke(tag);
            OnReloadGame.Invoke();
        }
    }
}
