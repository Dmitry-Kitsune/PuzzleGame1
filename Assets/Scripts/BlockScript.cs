using UnityEngine;
using UnityEngine.UIElements;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
public class BlockScript : MonoBehaviour
{
    private Position _possition;
    private SpriteRenderer _sprite;
    private Position _correctPosition;
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _possition = this._correctPosition;
    }

    void Update()
    {
        if (_possition == _correctPosition) ;
        {
            _sprite.color = Color.white;
        }
    }
}