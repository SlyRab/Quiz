using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TileData
{
    [SerializeField]
    private string _identifier;

    [SerializeField]
    private Sprite _sprite;

    public string Identifier => _identifier;
    public Sprite Sprite => _sprite;
}

[CreateAssetMenu(fileName ="New TuleBundleData", menuName = "Tile Bundle Data", order = 10)]
public class TileBundleData : ScriptableObject
{
    [SerializeField]
    private TileData[] _tileData;

    public TileData[] TileData => _tileData;
}