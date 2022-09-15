using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNewRound : MonoBehaviour
{
    Vector3 _enemyPosition;
    Vector3 _playerPosition;
    private void Awake()
    {
        _enemyPosition = GameObject.Find("Enemy").transform.position;
        _playerPosition = GameObject.Find("Player").transform.position;

        BulletCollustion.OnReloadGame.AddListener(reloadScene);
       
    }


    public void reloadScene()
    {
        List<BulletCollustion> bullets = new List<BulletCollustion>( FindObjectsOfType<BulletCollustion>());
        bullets.ForEach(bullet => Destroy(bullet.gameObject));
        GameObject.Find("Player").transform.position = _playerPosition;
        GameObject.Find("Enemy").transform.position = _enemyPosition;
    }

}
