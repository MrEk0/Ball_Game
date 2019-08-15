using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Settings", menuName ="Settings")]
public class GameSettings : ScriptableObject
{
    [SerializeField] List<float> speedMultiplier;
    [SerializeField] List<float> scoreToBoost;
    [SerializeField] float startSpeed;

    public float GetSpeedMult(int index)
    {
        if (index <= speedMultiplier.Count - 1)
            return speedMultiplier[index];
        return speedMultiplier.Count- 1;
    }

    public float GetScoreToBoost(int index)
    {
        if (index <= scoreToBoost.Count - 1)
            return scoreToBoost[index];
        return scoreToBoost.Count-1;
    }

    public float GetStartSpeed()
    {
        return startSpeed;
    }
}
