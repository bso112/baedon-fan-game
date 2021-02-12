using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Node
{
	public NodeState nodeState { get; protected set; }

	public abstract NodeState Evaluate();
}

public enum NodeState
{
	RUNNING, SUCCESS, FAILURE,
}