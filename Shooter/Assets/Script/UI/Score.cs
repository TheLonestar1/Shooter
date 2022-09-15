using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public  class Score : MonoBehaviour
{
    
     public TMP_Text _text;

     int _scorePlayer = 0;

     int _scoreEnemy = 0;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        BulletCollustion.OnKillSide.AddListener(AddScore);
    }

    void AddScore(string side)
    {
        if (side == "Player") _scorePlayer++;
        if (side == "Enemy") _scoreEnemy++;

        _text.text = $"Score: {_scorePlayer} - {_scoreEnemy}";
    }
}
