using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HorizontalObstacleMove : MonoBehaviour
{
    
    void Start()
    {
        ActiveObstacle();
    }
    void ActiveObstacle()
    {
        transform.DOLocalMoveX(5f, 2f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        
    }
}
