using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilesScript : MonoBehaviour
{
    public Vector3 targetPosition;
    private Vector3 _correctPosition;
    private SpriteRenderer _sprite;
    public int number;
    public int emptySpaceIndex;
    public static bool InRightPlace;
    public int win = 0;
    private bool selected;
    private Rigidbody2D body;
    public float speed = 15f;
    private bool _shuffled;
    public Vector3 target;

    public static List<TilesScript> moveableObjects = new List<TilesScript>();
    private Camera _camera;
    private Vector3 selTarget;

    
    void Awake()
    {
        targetPosition = transform.position;
        _correctPosition = targetPosition;
        _sprite = GetComponent<SpriteRenderer>();
     //   moveableObjects.Add(this);
        _sprite.color = Color.white;
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        _camera = Camera.main;
        _sprite = GetComponent<SpriteRenderer>();
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        //isMoving = false;
        target = transform.position;
        moveableObjects.Add(this);
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //  Debug.Log($"GameScript shuffled = {_shuffled}");
        //  Debug.Log($"Update = on");
        
        _shuffled = false; 
        InRightPlace = false;
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
        _shuffled = GameScript.IsShuffled;
        if (_shuffled)
        {
           transform.position =  Vector3.MoveTowards(transform.position, targetPosition, 
               speed * Time.deltaTime); 
        //   Debug.Log($"Shuffle off = {_shuffled}");
        }

        if (_shuffled)
        {
            var redPos6 = GameObject.FindGameObjectWithTag("Red (6)").transform.position.x;
            var redPos1 = GameObject.FindGameObjectWithTag("Red (1)").transform.position.x;
            var redPos2 = GameObject.FindGameObjectWithTag("Red (2)").transform.position.x;
            var redPos3 = GameObject.FindGameObjectWithTag("Red (3)").transform.position.x;
            var redPos4 = GameObject.FindGameObjectWithTag("Red (4)").transform.position.x;
            var redPos5 = GameObject.FindGameObjectWithTag("Red (5)").transform.position.x;

            var yellowPos6 = GameObject.FindGameObjectWithTag("Yellow (6)").transform.position.x;
            var yellowPos1 = GameObject.FindGameObjectWithTag("Yellow (1)").transform.position.x;
            var yellowPos2 = GameObject.FindGameObjectWithTag("Yellow (2)").transform.position.x;
            var yellowPos3 = GameObject.FindGameObjectWithTag("Yellow (3)").transform.position.x;
            var yellowPos4 = GameObject.FindGameObjectWithTag("Yellow (4)").transform.position.x;
            var yellowPos5 = GameObject.FindGameObjectWithTag("Yellow (5)").transform.position.x;

            var bluePos6 = GameObject.FindGameObjectWithTag("Blue (6)").transform.position.x;
            var bluePos1 = GameObject.FindGameObjectWithTag("Blue (1)").transform.position.x;
            var bluePos2 = GameObject.FindGameObjectWithTag("Blue (2)").transform.position.x;
            var bluePos3 = GameObject.FindGameObjectWithTag("Blue (3)").transform.position.x;
            var bluePos4 = GameObject.FindGameObjectWithTag("Blue (4)").transform.position.x;
            var bluePos5 = GameObject.FindGameObjectWithTag("Blue (5)").transform.position.x;


            if (Math.Abs(redPos6 - redPos1) < 0.05 && Math.Abs(redPos6 - redPos2) < 0.05
                                                   && Math.Abs(redPos6 - redPos3) < 0.05
                                                   && Math.Abs(redPos6 - redPos4) < 0.05
                                                   && Math.Abs(redPos6 - redPos5) < 0.05
                                                   && Math.Abs(yellowPos6 - yellowPos1) < 0.05 &&
                                                   Math.Abs(yellowPos6 - yellowPos2) < 0.05
                                                   && Math.Abs(yellowPos6 - yellowPos3) < 0.05
                                                   && Math.Abs(yellowPos6 - yellowPos4) < 0.05
                                                   && Math.Abs(yellowPos6 - yellowPos5) < 0.05
                                                   && Math.Abs(bluePos6 - bluePos1) < 0.05 &&
                                                   Math.Abs(bluePos6 - bluePos2) < 0.05
                                                   && Math.Abs(bluePos6 - bluePos3) < 0.05
                                                   && Math.Abs(bluePos6 - bluePos4) < 0.05
                                                   && Math.Abs(bluePos6 - bluePos5) < 0.05)
            {
                _sprite.color = Color.green;
                InRightPlace = true;
                win = 1;
            }
            else
            {
                InRightPlace = false;
            }
        }
    }

    // private void MovebleObjects(moveableObjects)
    // {
    // static List<TilesScript> moveableObjects = new List<TilesScript>(); 
    // }
    private void OnMouseDown()
    {
        Debug.Log("OnMouseDownis on");
        if (Input.GetMouseButtonDown(0))
        {
            selected = true;
            Debug.Log($"OnMouseDown() selected = {selected}"); 
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;

            foreach (TilesScript obj in moveableObjects)
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
