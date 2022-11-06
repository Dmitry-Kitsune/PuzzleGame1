using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class TilesMovement : MonoBehaviour
{
    public static List<TilesMovement> movebleObjects = new List<TilesMovement>();
    public float speed = 15f;
    private Vector3 target;
    private bool selected;
    private Camera _camera;
    private Vector3 selTarget;
    private Rigidbody2D body;
    private bool _shuffled;
    private SpriteRenderer _sprite;

    void Start()
    {   
        _camera = Camera.main;
        _sprite = GetComponent<SpriteRenderer>();
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        //isMoving = false;
        target = transform.position;
        movebleObjects.Add(this);
        body = GetComponent<Rigidbody2D>();
    }
    public void FixedUpdate()
    {
       // Debug.Log("Fixed");
            _shuffled = GameScript.IsShuffled; 
       // Debug.Log($"Shufled in TilesMovement =  {_shuffled}");
        if (Input.GetMouseButtonDown(1) && selected)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            TilesScript thisTile = transform.GetComponent<TilesScript>();
            thisTile.targetPosition =  target;
            Debug.Log($"Shufled in TilesMovement =  {_shuffled}");
            if (_shuffled)
            {
                Debug.Log($"Shuffled in ");
                transform.position = Vector3.MoveTowards(transform.position, target,
                    speed * Time.deltaTime);
            }
        }
    }
    private void OnMouseDown()
    {
        Debug.Log("OnMouseDownis on");
        if (Input.GetMouseButtonDown(0))
        {
            selected = true;
            Debug.Log($"OnMouseDown() selected = {selected}"); 
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;

            foreach (TilesMovement obj in movebleObjects)
            {
                Debug.Log($"obj{obj}");
                if (obj != this)
                {
                    obj.selected = false;
                    obj.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                  //  _sprite.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
        }
    }
}