using UnityEngine;
using UnityEngine.UIElements;

public class BlockScript : MonoBehaviour
{
    private Position _position;
    private SpriteRenderer _sprite;
    private Position _correctPosition;

    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _position = this._correctPosition;
    }

    void Update()
    {
        if (_position == _correctPosition) ;
        {
            _sprite.color = Color.white;
        }
    }
}