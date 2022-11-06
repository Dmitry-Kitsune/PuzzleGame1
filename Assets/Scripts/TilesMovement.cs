using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class TilesMovement : MonoBehaviour
{
    private static List<TilesMovement> _movebleObjects = new List<TilesMovement>();
    public float speed = 15f;
    private Vector3 _target;
    private bool _selected;
    private Camera _camera;
    private Vector3 _selTarget;
    private Rigidbody2D _body;
    private bool _shuffled;
    private SpriteRenderer _sprite;
    public static bool IsSelected;

    void Start()
    {   
        _camera = Camera.main;
      //_sprite = GetComponent<SpriteRenderer>();
        //gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        //isMoving = false;
        _target = transform.position;
        _body = GetComponent<Rigidbody2D>();
        _movebleObjects.Add(this);
    }
    public void FixedUpdate()
    {
       // Debug.Log("Fixed");
            _shuffled = GameScript.IsShuffled;
            IsSelected = _selected;
       // Debug.Log($"Shufled in TilesMovement =  {_shuffled}");
        if (Input.GetMouseButtonDown(1) && _selected)
        {
            _target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _target.z = transform.position.z;
            TilesScript thisTile = transform.GetComponent<TilesScript>();
            thisTile.targetPosition =  _target;
            Debug.Log($"Shufled in TilesMovement =  {_shuffled}");
            if (_shuffled)
            {
                Debug.Log($"Shuffled in ");
                transform.position = Vector3.MoveTowards(transform.position, _target,
                    speed * Time.deltaTime);
            }
        }
    }
    private void OnMouseDown()
    {
        Debug.Log("OnMouseDownis on");
        if (Input.GetMouseButtonDown(0))
        {
            _selected = true;
            Debug.Log($"OnMouseDown() selected = {_selected}"); 
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;

            foreach (TilesMovement obj in _movebleObjects)
            {
                Debug.Log($"obj{obj}");
                if (obj != this)
                {
                    obj._selected = false;
                    obj.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                  //  _sprite.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
        }
    }
}