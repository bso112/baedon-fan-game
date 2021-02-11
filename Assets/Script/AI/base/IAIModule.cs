using UnityEngine;

public enum AI_MODULE_TYPE { CHEWEDGUM, END }

public interface IAIModule
{
    void idle();
    void chase(CharacterStats target, CharacterStats self);
    void fight(CharacterStats target, CharacterStats self);

    void update();
}


