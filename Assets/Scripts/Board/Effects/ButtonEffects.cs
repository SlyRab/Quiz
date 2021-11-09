using DG.Tweening;
using UnityEngine;

public class ButtonEffects : MonoBehaviour
{
    public void StartupAnimation()
    {
        transform.localScale = new Vector2(0,0);
        Tween scaleTween = transform.DOScale(1f, 1)
            .SetEase(Ease.OutBounce);
    }

    public void WorngAnimation()
    {
        Tween scaleTween = transform.DOLocalMoveX(30, 3f)
            .SetEase(Ease.InBounce);
    }
}
