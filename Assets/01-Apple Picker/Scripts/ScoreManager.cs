using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    public int highScore = 0;

    protected override void Awake()
    {
        base.Awake();
    }
}
