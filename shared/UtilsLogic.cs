using System;

public class UtilsLogic
{
    public static string AngleToString(float angle)
    {
        int radQuarter = (int)(angle * 4 / Math.PI);
        DirectionRadQuarter angleName = (DirectionRadQuarter)radQuarter;
        return angleName.ToString().ToLower().Replace('_','-');
    }

    public static float DirectionToAngle(DirectionRadQuarter direction)
    {
        return (float) ((int)direction * Math.PI / 4);
    }
}