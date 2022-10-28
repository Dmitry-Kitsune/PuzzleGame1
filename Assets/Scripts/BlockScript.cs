using UnityEngine;
using UnityEngine.UIElements;

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