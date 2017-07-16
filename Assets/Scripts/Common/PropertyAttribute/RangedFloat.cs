using System;

[Serializable]
public struct RangedFloat
{
    public float MinValue;
    public float MaxValue;

    public RangedFloat(float minValue, float maxValue)
    {
        MinValue = minValue;
        MaxValue = maxValue;
    }
    
    public float RandomValue 
    {
        get { return UnityEngine.Random.Range( MinValue, MaxValue ); }
    }
    public float Magnitude
    {
        get { return MaxValue - MinValue; }
    }
    public bool Contains(float value)
    {
        return (value >= MinValue) && (value <= MaxValue);
    }
}