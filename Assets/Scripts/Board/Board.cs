using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private Tile _gameTilePrefab;

    private Vector2Int _size;
    private Tile[] _tiles;

    public void Init(Vector2Int size)
    {
        _size = size;

        _tiles = new Tile[_size.x * _size.y];
        for(int i = 0, y = 0; y < _size.y; y++)
        {
            for(int x = 0; x < _size.x; x++, i++)
            {
                Tile tile = _tiles[i] = Instantiate(_gameTilePrefab);
                tile.transform.SetParent(transform, false);
            }
        }
    }
}
