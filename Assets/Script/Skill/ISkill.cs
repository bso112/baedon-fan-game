using UnityEngine;

public interface ISkill
{
    string getName();
    void activate(CharacterStats target);
    void inactivate(CharacterStats target);
}
