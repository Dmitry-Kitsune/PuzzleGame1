using System;
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
    void Awake()
    {
        targetPosition = transform.position;
        _correctPosition = targetPosition;
        _sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.05f);
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


        if (Math.Abs(redPos6 - redPos1) < 0.01 & Math.Abs(redPos6 - redPos2) < 0.01
                                               & Math.Abs(redPos6 - redPos3) < 0.01
                                               & Math.Abs(redPos6 - redPos4) < 0.01
                                               & Math.Abs(redPos6 - redPos5) < 0.01 
            & Math.Abs(yellowPos6 - yellowPos1) < 0.01 &
                                               Math.Abs(yellowPos6 - yellowPos2) < 0.01
                                               & Math.Abs(yellowPos6 - yellowPos3) < 0.01
                                               & Math.Abs(yellowPos6 - yellowPos4) < 0.01
                                               & Math.Abs(yellowPos6 - yellowPos5) < 0.01 
            & Math.Abs(bluePos6 - bluePos1) < 0.01 &
                                               Math.Abs(bluePos6 - bluePos2) < 0.01
                                               & Math.Abs(bluePos6 - bluePos3) < 0.01
                                               & Math.Abs(bluePos6 - bluePos4) < 0.01
                                               & Math.Abs(bluePos6 - bluePos5) < 0.01)
        {
            _sprite.color = Color.green;
            InRightPlace = true;
            win = 1;
        }
        /*if (targetPosition == _correctPosition)
        {
            _sprite.color = Color.green;
            inRightPlace = true;
        }*/
        else
        {
            _sprite.color = Color.white;
            InRightPlace = false;
        }
    }
}