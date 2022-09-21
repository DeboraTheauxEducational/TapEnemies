using UnityEngine;
using UnityEngine.UI;
using Code;

public class EnemyView : RecyclableObject
{
    [SerializeField] private Image enemyHealthBarFill;
    [SerializeField] private Animator enemyAnimator;

    private EnemyPresenter presenter;

    private void Awake()
    {
        presenter = new EnemyPresenter();
    }

    internal override void Init()
    {
        presenter.OnActivateEnemy();
    }

    internal override void Release()
    {
        presenter.OnReleaseEnemy();
    }
}