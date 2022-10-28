using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameScript : MonoBehaviour
{
    [SerializeField] private Transform emptySpace1 = null;
    [SerializeField] private Transform emptySpace2 = null;
    [SerializeField] private Transform emptySpace3 = null;
    [SerializeField] private Transform emptySpace4 = null;
    [SerializeField] private TilesScript[] tiles;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private TextMeshProUGUI winPanelTiMeshPro;
    [SerializeField] private TilesScript[] headTiles;
    public TilesScript tilesScript;
    [SerializeField] private BlockScript[] block;
    private Camera _camera;
    private bool _isFinished;

    private int _emptySpaceIndex;
    //public bool move { get; }

    void Start()
    {
        _camera = Camera.main;
        Shuffle();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var gameObjs = GameObject.FindGameObjectsWithTag(tag);
            Console.WriteLine($"gameObjs{gameObjs}");
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                // Debug.Log(hit.transform.name);

                if (Vector2.Distance(emptySpace1.position, hit.transform.position) <= 6.01)
                {
                    if (gameObjs != GameObject.FindGameObjectsWithTag("Block"))
                    {
                        Vector2 lastEmptySpacePosition = emptySpace1.position;
                        TilesScript thisTile = hit.transform.GetComponent<TilesScript>();
                        emptySpace1.position = thisTile.targetPosition;
                        thisTile.targetPosition = lastEmptySpacePosition;
                        int tileIndex = FindIndex(thisTile);
                        this._emptySpaceIndex = 6;
                        //this.emptySpaceIndex = 21;
                        _emptySpaceIndex = tileIndex;
                        tiles[_emptySpaceIndex] = tiles[tileIndex];
                        tiles[tileIndex] = null;
                    }

                    return;
                }

                if (Vector2.Distance(emptySpace2.position, hit.transform.position) <= 6.01)
                {
                    if (gameObjs != GameObject.FindGameObjectsWithTag("Block"))
                    {
                        Vector2 lastEmptySpacePosition = emptySpace2.position;
                        TilesScript thisTile = hit.transform.GetComponent<TilesScript>();
                        emptySpace2.position = thisTile.targetPosition;
                        thisTile.targetPosition = lastEmptySpacePosition;
                        int tileIndex = FindIndex(thisTile);
                        this._emptySpaceIndex = 8;
                        //this.emptySpaceIndex = 22;
                        _emptySpaceIndex = tileIndex;
                        tiles[_emptySpaceIndex] = tiles[tileIndex];
                        tiles[tileIndex] = null;
                    }

                    return;
                }

                if (Vector2.Distance(emptySpace3.position, hit.transform.position) <= 6.01)
                {
                    if (gameObjs != GameObject.FindGameObjectsWithTag("Block"))
                    {
                        Vector2 lastEmptySpacePosition = emptySpace3.position;
                        TilesScript thisTile = hit.transform.GetComponent<TilesScript>();
                        emptySpace3.position = thisTile.targetPosition;
                        thisTile.targetPosition = lastEmptySpacePosition;
                        int tileIndex = FindIndex(thisTile);
                        this._emptySpaceIndex = 16;
                        //this.emptySpaceIndex = 23;
                        _emptySpaceIndex = tileIndex;
                        tiles[_emptySpaceIndex] = tiles[tileIndex];
                        tiles[tileIndex] = null;
                    }

                    return;
                }

                if (Vector2.Distance(emptySpace4.position, hit.transform.position) <= 6.01)
                {
                    if (gameObjs != GameObject.FindGameObjectsWithTag("Block"))
                    {
                        Vector2 lastEmptySpacePosition = emptySpace4.position;
                        TilesScript thisTile = hit.transform.GetComponent<TilesScript>();
                        emptySpace4.position = thisTile.targetPosition;
                        thisTile.targetPosition = lastEmptySpacePosition;
                        int tileIndex = FindIndex(thisTile);
                        this._emptySpaceIndex = 18;
                        //this.emptySpaceIndex = 24;
                        _emptySpaceIndex = tileIndex;
                        tiles[_emptySpaceIndex] = tiles[tileIndex];
                        tiles[tileIndex] = null;
                    }

                    return;
                }
            }
        }

        if (!_isFinished)
        {
            var done = TilesScript.InRightPlace;
            Console.WriteLine(done);
            var correctTiles = 0;
            foreach (var a in tiles)
            {
                if (done == false)
                {
                    if (TilesScript.InRightPlace)
                        correctTiles++;
                }

                if (done)

                {
                    _isFinished = true;
                    Debug.Log("You WON!");
                    winPanel.SetActive(true);
                    var b = GetComponent<TimerScript>();
                    b.StopTimer();
                    winPanelTiMeshPro.text = $"{b.minutes:0#}:{b.seconds:0#}";
                }

                // if (correctTiles == tiles.Length - 4)
                // {
                //     _isFinished = true;
                //     Debug.Log("You WON!");
                //     winPanel.SetActive(true);
                //     var b = GetComponent<TimerScript>();
                //     b.StopTimer();
                //     winPanelTiMeshPro.text = $"{b.minutes:0#}:{b.seconds:0#}";
                // }
                else
                {
                    _isFinished = false;
                }
            }
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Shuffle()
    {
        for (var i = 0; i <= 18; i++)
        {
            if (tiles[i] == null) continue;
            var lastPos = tiles[i].targetPosition;
            var randomIndex = Random.Range(0, 14);
            tiles[i].targetPosition = tiles[randomIndex].targetPosition;
            tiles[randomIndex].targetPosition = lastPos;
            (tiles[i], tiles[randomIndex]) = (tiles[randomIndex], tiles[i]);
        }

        for (int e = 0; e <= 3; e++)
        {
            if (headTiles[e] == null) continue;
            var lastPos = headTiles[e].targetPosition;
            var randomIndex = Random.Range(0, 2);
            headTiles[e].targetPosition = headTiles[randomIndex].targetPosition;
            headTiles[randomIndex].targetPosition = lastPos;
            (headTiles[e], headTiles[randomIndex]) = (headTiles[randomIndex], headTiles[e]);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    private int FindIndex(TilesScript ts)
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i] != null)
            {
                if (tiles[i] == ts)
                {
                    return i;
                }
            }
        }

        return this._emptySpaceIndex;
    }
}