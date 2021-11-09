using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Board : MonoBehaviour
{
    public UnityEvent OnGoodAnswer;

    public delegate void ChangeAnswerDelegate(string answer);
    public event ChangeAnswerDelegate OnChangeAnswer;

    public Tile Answer { get; }

    [SerializeField]
    private Tile _gameTilePrefab;

    [SerializeField]
    private GridLayoutGroup _gridLayoutGroup;

    private TileData[] _tileDatas;
    private Tile[] _tiles;
    private Vector2Int _size;

    private Tile _answer;
    private List<string> _selectedBeforeTiles = new List<string>();

    public void Init(Vector2Int size, TileBundleData tileBundleData)
    {
        _size = size;
        _selectedBeforeTiles = new List<string>();

        _tileDatas = new TileData[tileBundleData.TileData.Length];
        tileBundleData.TileData.CopyTo(_tileDatas, 0);

        if (_tiles != null)
        {
            Clear();
        }

        _gridLayoutGroup.constraintCount = size.x;

        var randomData = GetRandomTileData(_tileDatas, size.x * size.y);

        _tiles = new Tile[size.x * size.y];

        for (int i = 0; i < randomData.Length; i++)
        {
            Tile tile = _tiles[i] = Instantiate(_gameTilePrefab);
            tile.transform.SetParent(transform);
            tile.SetTileData(i, randomData[i]);
            tile.OnChoiseAnswer += CheckAnswer;
        }
        ChangeAnswer();
    }

    public TileData[] GetRandomTileData(TileData[] tileData, int size)
    {
        System.Random _random = new System.Random();
        TileData[] randomTiles = new TileData[size];
        for (int k = 0, i = tileData.Length - 1; k < size; i--, k++)
        {
            int j = _random.Next(0, i + 1);
            var temp = tileData[j];
            tileData[j] = tileData[i];
            tileData[i] = temp;

            randomTiles[k] = tileData[i];
        }
        return randomTiles;
    }

    public void CheckAnswer(int id)
    {
        if (_answer.Id == id)
        {
            OnGoodAnswer?.Invoke();
        }
    }

    private void Clear()
    {
        for (int i = 0; i < _tiles.Length; i++)
        {
            _tiles[i].gameObject.SetActive(false);
            Destroy(_tiles[i].gameObject);
        }
        _selectedBeforeTiles = null;
        _tiles = null;
    }

    private void ChangeAnswer()
    {
        _answer = _tiles[Random.Range(0, _tiles.Length)];

        OnChangeAnswer?.Invoke(_answer.Name);
    }
}
