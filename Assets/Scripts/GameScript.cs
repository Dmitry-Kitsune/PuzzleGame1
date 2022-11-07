using System;
using TMPro;
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
    private bool selected;
    public static bool IsShuffled;
    public float speed = 15f;
    private Vector3 target;
    private Vector3 selTarget;
    private Rigidbody2D body;
    private float xInput, yInput;
    private int _second;
    void Start()
    {
        Physics2D.simulationMode = SimulationMode2D.Script; 
        _camera = Camera.main;
        Shuffle();
    }

    void FixedUpdate()
    {
        _second = TimerScript.Second;
        switch (_second)
        {
            case < 4:
                return;
            case >= 4:
                Physics2D.Simulate(_second);
                Physics2D.simulationMode = SimulationMode2D.FixedUpdate;
                break;
            default:
                return;
        }
        if (!_isFinished)
        {
            var done = TilesScript.InRightPlace;
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
        TilesMovement.DestroyList();
        Physics2D.simulationMode = SimulationMode2D.Script;
        IsShuffled = false;
    }

    private void Shuffle()
    {
        for (int i = 0; i <= 18; i++)
        {
            if (tiles[i] == null) continue;
            {
                var lastPos = tiles[i].targetPosition;
                var randomIndex = Random.Range(0, 14);
                tiles[i].targetPosition = tiles[randomIndex].targetPosition;
                tiles[randomIndex].targetPosition = lastPos;
                (tiles[i], tiles[randomIndex]) = (tiles[randomIndex], tiles[i]);
            }
            if (i == 14)
            {
                Debug.Log($"private SHUFFLE  --  inside if [i] =  {i}");
                IsShuffled = true;
                Debug.Log($"private SHUFFLE  --  isShuffled =  {IsShuffled}");
            }
        }

        for (int e = 0; e <= 2; e++)
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
    
}