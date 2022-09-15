using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class ActionList : MonoBehaviour
{
    List<GameObject> _Action;
    [SerializeField]
    GameObject _gameObject;

    [SerializeField]
    float offset;
    private void Start()
    {
        _Action = new List<GameObject>();
        AiMovment.OnAction.AddListener(AddRecord);
        MoverPlayer.OnAction.AddListener(AddRecord);
        Shooting.OnAction.AddListener(AddRecord);
    }

    public  void AddRecord(string action)
    {
        var newAction = Instantiate(_gameObject,transform);
        newAction.GetComponent<TMP_Text>().text = action;
        
        UpdateRecords(newAction);
    }

    private  void UpdateRecords(GameObject action)
    {
        
        _Action.Add(action);
        
        if(_Action.Count >= 8)
        {
            Destroy(_Action.First());
            _Action.RemoveAt(0);
        }
        _Action.ToList().ForEach(action => action.transform.position += new Vector3(0, -offset, 0));
    }




}
