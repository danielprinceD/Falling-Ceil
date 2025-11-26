
using UnityEngine;

public static class Difficulty
{
    static float reachDifficultyLevelIn = 60f;

    public static float getDifficultyPercentage()
    {
        return Mathf.Clamp01(Time.time / reachDifficultyLevelIn);
    }

    public static float getLerpValue(float fromLevel , float toLevel , float fromTime , float toTime )
    {
        return fromLevel + ((toLevel - fromLevel)/ (toTime - fromTime)) * (Time.time - fromTime) ;
    }

}