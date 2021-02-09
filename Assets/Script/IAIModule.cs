using UnityEngine;

public enum AI_MODULE_TYPE { SHIPDONKKUM, END }

public interface IAIModule
{
    void idle();
    void chase(CharacterStats target);
    void fight(CharacterStats target);
    void update();

}


