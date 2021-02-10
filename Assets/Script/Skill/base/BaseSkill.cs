using UnityEngine;
using UnityEditor;
using System;


public abstract class BaseSkill : ISkill
{
    private readonly float cooldown = 8F;
    public float currentCooldown { get; private set; } = float.MaxValue;

    public abstract string getName();

    public void activate(CharacterStats target)
    {
        if (cooldown > currentCooldown)
            return;

        onActivate(target);

        currentCooldown = 0;
    }


    public void Inactivate(CharacterStats target)
    {

        onInactivate(target);

        currentCooldown = 0;
    }

    public void update()
    {
        updateCurrentCooldown();

        onUpdate();

    }


    protected abstract void onActivate(CharacterStats target);
    protected abstract void onInactivate(CharacterStats target);

    protected void onUpdate() { }

    protected void updateCurrentCooldown() { currentCooldown += Time.deltaTime; }

 
}
