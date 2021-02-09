using UnityEngine;

public interface Skill
{
    string getName();
    void activate(CharacterStats target);
    void inactivate(CharacterStats target);
}
