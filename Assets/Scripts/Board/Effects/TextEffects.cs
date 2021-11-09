using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform), typeof(Text))]
public class TextEffects : MonoBehaviour
{
    private RectTransform _rectTransform;
    private Text _text;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _text = GetComponent<Text>();
    }
    public void FadeIn()
    {
        _rectTransform.anchoredPosition = new Vector2(-700, 0);
        _text.color = new Color(0,0,0,0.3f);
        _rectTransform.DOAnchorPos(new Vector2(0, 0), 1f);
        _text.DOFade(1, 2f);
    }
    private void OnEnable()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

}
