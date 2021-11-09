using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private Image _contentImage;

    private string _name;
    public string Name { get { return _name; } }

    private int _id;
    public int Id { get { return _id; } }

    public delegate void ChoiseAnswer(int id);
    public event ChoiseAnswer OnChoiseAnswer;
    public void SetTileData(int id, TileData tileData)
    {
        _contentImage.sprite = tileData.Sprite;
        _name = tileData.Identifier;

        _id = id;
    }

    public void ClickAnswer()
    {
        OnChoiseAnswer?.Invoke(_id);
    }
}
