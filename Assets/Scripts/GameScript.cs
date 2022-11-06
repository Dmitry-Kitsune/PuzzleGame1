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

    //  private SpriteRenderer _sprite;
    public float speed = 10f;
    private Vector3 target;
    private Vector3 selTarget;
    private Rigidbody2D body;
    private float xInput, yInput;
    private int _second;

    [Obsolete("Obsolete")]
    void Start()
    {
        // Physics2D.autoSimulation = false;
        _camera = Camera.main;
        Shuffle();
        // _sprite = GetComponent<SpriteRenderer>();
    }

    [Obsolete("Obsolete")]
    void FixedUpdate()
    {
        _second = TimerScript.Second;
        switch (_second)
        {
            case < 4:
                return;
            case >= 4:
                Debug.Log($"Second = {_second}");
                Physics2D.Simulate(1000);
                Physics2D.simulationMode = SimulationMode2D.FixedUpdate;
                //   Physics2D.autoSimulation = true;
                //  _sprite.color = Color.white;
                break;
            default:
                return;
        }

        //////////////////////////////////////////////////////////
        if (!_isFinished)
        {
            var done = TilesScript.InRightPlace;
            // Debug.Log($"done = {done}");
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

    /// /////////////////////////////////////////////////////////
    [Obsolete("Obsolete")]
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Physics2D.autoSimulation = false;
        Physics2D.simulationMode = SimulationMode2D.Script;
        IsShuffled = false;
    }

    [Obsolete("Obsolete")]
    private void Shuffle()
    {
        Debug.Log($"private SHUFFLE  --  On ");
        for (int i = 0; i <= 18; i++)
        {
            if (tiles[i] == null) continue;
            {
                Debug.Log($"private SHUFFLE  --  i =  {i}");
                var lastPos = tiles[i].targetPosition;
                var randomIndex = Random.Range(0, 14);
                tiles[i].targetPosition = tiles[randomIndex].targetPosition;
                tiles[randomIndex].targetPosition = lastPos;
                (tiles[i], tiles[randomIndex]) = (tiles[randomIndex], tiles[i]);
                Debug.Log($"private SHUFFLE  -Counting-  isShuffled =  {IsShuffled}");
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