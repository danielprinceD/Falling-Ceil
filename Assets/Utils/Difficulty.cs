
using UnityEngine;

public static class Difficulty
{
    static float reachDifficultyLevelIn = 60f;

    public static float getDifficultyPercentage()
    {
        return Mathf.Clamp01(Time.time / reachDifficultyLevelIn);
    }

}