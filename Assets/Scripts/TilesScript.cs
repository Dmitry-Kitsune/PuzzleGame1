using UnityEngine;
using UnityEngine.Tilemaps;

public class TilesScript : MonoBehaviour
{
    public Vector3 targetPosition;
    private Vector3 _correctPosition;
    private SpriteRenderer _sprite;
    public int number;
    public int emptySpaceIndex;
    public bool inRightPlace;

    void Awake()
    {
        targetPosition = transform.position;
        _correctPosition = targetPosition;
        _sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.05f);
        if (targetPosition == _correctPosition)
        {
            _sprite.color = Color.green;
            inRightPlace = true;
        }
        else
        {
            _sprite.color = Color.white;
            inRightPlace = false;
        }
    }
}