using System;

[Serializable]
public class FloatStat : Stat<float>
{
    public FloatStat(float max) 
        : base(max)
    {

    }
}