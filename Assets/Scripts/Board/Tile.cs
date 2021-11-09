using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private Image _contentImage;

    public UnityEvent OnTileDone;

    private string _name;
    public string Name { get { return _name; } }

    private int _id;
    public int Id { get { return _id; } }

    public delegate void ChoiseAnswer(int id);
    public event ChoiseAnswer OnChoiseAnswer;
    public void SetTileData(int id, TileData tileData)
    {
        Delay();
        _contentImage.sprite = tileData.Sprite;
        _name = tileData.Identifier;
        _id = id;
        OnTileDone.Invoke();
    }

    public void ClickAnswer()
    {
        OnChoiseAnswer?.Invoke(_id);
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.3f); 
    }
}
