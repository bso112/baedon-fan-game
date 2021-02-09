
using UnityEngine;

public class ManaShield : Skill
{
    public string getName()
    {
        return "ManaShield";
    }

    public void activate(CharacterStats target)
    {
        target.ManaBarrierActivate();
    }


    public void inactivate(CharacterStats target)
    {
        target.ManaBarrierInactivate();
    }
}
