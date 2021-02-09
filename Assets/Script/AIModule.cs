using UnityEngine;

public enum AI_MODULE_TYPE { SHIPDONKKUM, END }

public interface AIModule
{
    void idle();
    void chase(GameObject target);
    void fight(GameObject target);

}


