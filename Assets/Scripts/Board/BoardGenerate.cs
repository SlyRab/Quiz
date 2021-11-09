using UnityEngine;
using UnityEngine.Events;

public class BoardGenerate : MonoBehaviour
{
    public UnityEvent OnEndGame;

    [SerializeField]
    private Board _grid;

    [SerializeField]
    private LevelData[] _levels;

    private int _currentLevel = 0;


    private void Start()
    {
        SelectLevel(_currentLevel);
    }

    public void NextLevel()
    {
        if (_currentLevel + 1 < _levels.Length)
        {
            _currentLevel++;
            SelectLevel(_currentLevel);
        }
        else
        {
            OnEndGame?.Invoke();
            _currentLevel = 0;

        }
    }

    public void SelectLevel(int i)
    {
        _grid.Init(_levels[i].BoardSize, _levels[i].LevelTileBundle);
    }
}
