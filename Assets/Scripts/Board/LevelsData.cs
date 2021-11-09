using System;
using UnityEngine;

[Serializable]
public class LevelData
{
    [SerializeField]
    private Vector2Int _boardSize;

    [SerializeField]
    private TileBundleData _levelTileBundle;

    public Vector2Int BoardSize => _boardSize;
    public TileBundleData LevelTileBundle => _levelTileBundle;
}
