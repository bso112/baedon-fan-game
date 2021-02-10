using System;
using UnityEngine;

[Serializable]
public class FloatStat : Stat<float>
{
    public FloatStat(float max, float current) 
        : base(max, current)
    {

    }

    public static FloatStat operator -(FloatStat stat, float amount)
    {
        return new FloatStat(stat.max, Mathf.Clamp(stat.current ,0, stat.max));
    }
}