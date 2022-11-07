using System.Collections.Generic;
using UnityEngine;

public class TilesMovement : MonoBehaviour
{
    private static List<TilesMovement> _moveableObjects = new List<TilesMovement>();

    public float speed = 10f;
    private Vector3 _target;
    private bool _selected;
    private Camera _camera;
    private Vector3 _selTarget;
    private Rigidbody2D _body;
    private bool _shuffled;
    private SpriteRenderer _sprite;

    void Start()
    {
        _camera = Camera.main;
        _target = transform.position;
        _body = GetComponent<Rigidbody2D>();
        _moveableObjects.Add(this);
    }

    
    public void FixedUpdate()
    {
        _shuffled = GameScript.IsShuffled;
        if (Input.GetMouseButtonDown(1) && _selected)
        {
            _target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _target.z = transform.position.z;
            TilesScript thisTile = transform.GetComponent<TilesScript>();
            thisTile.targetPosition = _target;
            if (_shuffled)
            {
                transform.position = Vector3.MoveTowards(transform.position, _target,
                    speed * Time.deltaTime);
            }
        }
    }

    public static void DestroyList()
    {
        _moveableObjects = new List<TilesMovement>();
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _selected = true;
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            foreach (TilesMovement obj in _moveableObjects)
            {
                if (obj != this)
                {
                    if (obj == null)
                    {
                        Debug.Log("TilesMovement - Object is NULL");
                        Debug.Log($"Object = {obj}");
                        Debug.Log($"Object of Gameobj = {obj.gameObject}");
                        return;
                    }

                    obj._selected = false;
                    obj.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
        }
    }
}