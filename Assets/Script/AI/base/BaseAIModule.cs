using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(CharacterStats))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public abstract class BaseAIModule : MonoBehaviour
{
    [SerializeField]
    protected CharacterStats target;
    //여기 범위까지는 근접공격을 우선시
    [SerializeField]
    protected float closeAttackRange = 0F;

    
    protected Dictionary<string, BaseSkill> skills = new Dictionary<string, BaseSkill>();
    protected NavMeshAgent navAgent;
    protected Animator animator;
    protected Node topNode;
    protected CharacterStats self;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, closeAttackRange);
    }

    protected void Start()
    {
        self = GetComponent<CharacterStats>();
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    protected void update()
    {
        foreach (var skill in skills)
        {
            skill.Value.update();
        }

        topNode.Evaluate();
    }


    protected abstract void constructBehaviourTree();


    protected void addSkill(BaseSkill skill)
    {
        skills.Add(skill.getName(), skill);
    }

  
}
