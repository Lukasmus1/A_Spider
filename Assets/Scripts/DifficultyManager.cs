using System;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField] private float timeToIncreaseDifficulty = 1f;
    private float _timeSinceLastIncrease;

    public static float TimeMultiplier { get; private set; }
    public static DifficultyClass DefaultDifficultyModifier { get; set; }

    private void Start()
    {
        TimeMultiplier = DefaultDifficultyModifier.Value;
    }

    private void Update()
    {
        _timeSinceLastIncrease += Time.deltaTime;
        if (_timeSinceLastIncrease >= timeToIncreaseDifficulty)
        {
            _timeSinceLastIncrease = 0;
            TimeMultiplier++;
            UiScript.RaiseNotification("Difficulty increased!");
        }
    }
}
