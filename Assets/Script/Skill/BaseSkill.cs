using UnityEngine;
using UnityEditor;
using System;


public abstract class BaseSkill : ISkill
{
    public abstract void activate(CharacterStats target);
    public abstract string getName();
    public abstract void inactivate(CharacterStats target);
}
