using System;
using UnityEngine;

[Serializable]
public class Stat<T> 
{
    public T max;
    [HideInInspector]
    public T current;

    public Stat(T max, T current)
    {
        this.max = max;
        this.current = current;
    }




}
