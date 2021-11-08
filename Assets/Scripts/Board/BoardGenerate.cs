using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerate : MonoBehaviour
{
    [SerializeField]
    private Vector2Int _gridSize;

    [SerializeField]
    private Board _grid;


    private void Start()
    {
        _grid.Init(_gridSize);
    }
}
