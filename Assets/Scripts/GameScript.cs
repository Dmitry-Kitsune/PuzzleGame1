using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    [SerializeField] private Transform emptySpace1 = null;
    [SerializeField] private Transform emptySpace2 = null;
    [SerializeField] private Transform emptySpace3 = null;
    [SerializeField] private Transform emptySpace4 = null;
    [SerializeField] private TilesScript[] tiles;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private TextMeshProUGUI winPanelTiMeshPro;

    public TilesScript tilesScript;
    //  [SerializeField] private BlockScript[] block;
    private Camera _camera;
    private bool _isFinished;
    private int _emptySpaceIndex;
    

    void Start()
    {
        _camera = Camera.main; 
        Shuffle();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                // Debug.Log(hit.transform.name);
                if (Vector2.Distance(emptySpace1.position, hit.transform.position) <= 6.01)
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

                if (Vector2.Distance(emptySpace2.position, hit.transform.position) <= 6.01)
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

                if (Vector2.Distance(emptySpace3.position, hit.transform.position) <= 6.01)
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

                if (Vector2.Distance(emptySpace4.position, hit.transform.position) <= 6.01)
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
            }
        }

        if (!_isFinished)
        {
            int correctTiles = 0;
            foreach (var a in tiles)
            {
                if (a != null)
                {
                    if (a.inRightPlace)
                        correctTiles++;
                }

                if (correctTiles == tiles.Length - 4)
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
    }

    private void Shuffle()
    {
        for (int i = 0; i <= 24; i++)
        {
            if (tiles[i] != null)
            {
                var lastPos = tiles[i].targetPosition;
                int randomIndex = Random.Range(0, 21);
                tiles[i].targetPosition = tiles[randomIndex].targetPosition;
                tiles[randomIndex].targetPosition = lastPos;
                var tile = tiles[i];
                tiles[i] = tiles[randomIndex];
                tiles[randomIndex] = tile;
            }
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