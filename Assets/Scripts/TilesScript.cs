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
    private Camera _camera;
    private Vector3 selTarget;
    private int _second;

    public object m_LocalPosition { get; }

    void Awake()
    {
        targetPosition = transform.position;
        _correctPosition = targetPosition;
        _sprite = GetComponent<SpriteRenderer>();
        //   moveableObjects.Add(this);
    }

    void FixedUpdate()
    {
        //  Debug.Log($"GameScript shuffled = {_shuffled}");
        //  Debug.Log($"Update = on");
        Debug.Log($"TilesScript TILES on Right place = {InRightPlace}");
        // Debug.Log($"Shufled in TilesMovement =  {_shuffled}");
        selected = TilesMovement.IsSelected;

        Debug.Log($"TilesScript_isSelected = {selected}");
        _shuffled = false;
        InRightPlace = false;
        _shuffled = GameScript.IsShuffled;
        if (_shuffled)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition,
                speed * Time.deltaTime);
            //   Debug.Log($"Shuffle off = {_shuffled}");
        }

        if (_shuffled)
        {
            var redPos6 = GameObject.FindGameObjectWithTag("Red (6)").transform.localPosition.x;
            var redPos1 = GameObject.FindGameObjectWithTag("Red (1)").transform.localPosition.x;
            var redPos2 = GameObject.FindGameObjectWithTag("Red (2)").transform.localPosition.x;
            var redPos3 = GameObject.FindGameObjectWithTag("Red (3)").transform.localPosition.x;
            var redPos4 = GameObject.FindGameObjectWithTag("Red (4)").transform.localPosition.x;
            var redPos5 = GameObject.FindGameObjectWithTag("Red (5)").transform.localPosition.x;

            var yellowPos6 = GameObject.FindGameObjectWithTag("Yellow (6)").transform.localPosition.x;
            var yellowPos1 = GameObject.FindGameObjectWithTag("Yellow (1)").transform.localPosition.x;
            var yellowPos2 = GameObject.FindGameObjectWithTag("Yellow (2)").transform.localPosition.x;
            var yellowPos3 = GameObject.FindGameObjectWithTag("Yellow (3)").transform.localPosition.x;
            var yellowPos4 = GameObject.FindGameObjectWithTag("Yellow (4)").transform.localPosition.x;
            var yellowPos5 = GameObject.FindGameObjectWithTag("Yellow (5)").transform.localPosition.x;

            var bluePos6 = GameObject.FindGameObjectWithTag("Blue (6)").transform.localPosition.x;
            var bluePos1 = GameObject.FindGameObjectWithTag("Blue (1)").transform.localPosition.x;
            var bluePos2 = GameObject.FindGameObjectWithTag("Blue (2)").transform.localPosition.x;
            var bluePos3 = GameObject.FindGameObjectWithTag("Blue (3)").transform.localPosition.x;
            var bluePos4 = GameObject.FindGameObjectWithTag("Blue (4)").transform.localPosition.x;
            var bluePos5 = GameObject.FindGameObjectWithTag("Blue (5)").transform.localPosition.x;
           // Debug.Log($"Red1 pos = {redPos1}");
           //  Debug.Log($"Red2 pos = {redPos2}");
           // Debug.Log($"Red3 pos = {redPos3}");
           // Debug.Log($"Red6 pos = {redPos6}");
            _second = TimerScript.Second;
            if (Math.Abs(redPos6 - redPos1) < 0.1 && Math.Abs(redPos6 - redPos2) < 0.1
                                                   && Math.Abs(redPos6 - redPos3) < 0.1
                                                   && Math.Abs(redPos6 - redPos4) < 0.1
                                                   && Math.Abs(redPos6 - redPos5) < 0.1
                                                   && Math.Abs(yellowPos6 - yellowPos1) < 0.1 &&
                                                   Math.Abs(yellowPos6 - yellowPos2) < 0.1
                                                   && Math.Abs(yellowPos6 - yellowPos3) < 0.1
                                                   && Math.Abs(yellowPos6 - yellowPos4) < 0.1
                                                   && Math.Abs(yellowPos6 - yellowPos5) < 0.1
                                                   && Math.Abs(bluePos6 - bluePos1) < 0.1 &&
                                                   Math.Abs(bluePos6 - bluePos2) < 0.1
                                                   && Math.Abs(bluePos6 - bluePos3) < 0.1
                                                   && Math.Abs(bluePos6 - bluePos4) < 0.1
                                                   && Math.Abs(bluePos6 - bluePos5) < 0.1 && _shuffled && _second >= 3)

            {
                _sprite.color = Color.green;
                InRightPlace = true;
                win = 1;
            }
            else
            {
                InRightPlace = false;
                if (!selected)
                {
                    //_sprite.color = Color.white;
                }
            }
        }
    }
}