using UnityEngine;
using UnityEngine.UI;


public class ChangeText : MonoBehaviour
{
    [SerializeField]
    private Text _answerText;

    [SerializeField]
    private Board _board;

    private void Start()
    {
        _board.OnChangeAnswer += Change;
    }

    private void OnDisable()
    {
        _board.OnChangeAnswer -= Change;
    }
    private void OnEnable()
    {
        _board.OnChangeAnswer += Change;
    }

    public void Change(string text)
    {
        _answerText.text = "Find " + text;
    }
}
