﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MoveAction : IAction
{
    private bool completed;
    private bool startAction;
    private Vector3 targetPosition;
    private IAstarAI ai;

    public MoveAction(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
        this.startAction = true;
        this.completed = false;
    }

    public bool Completed()
    {
        return completed;
    }

    public void Update(Dweller dweller)
    {
        ai = dweller.GetComponent<IAstarAI>();
        ai.isStopped = false;
        if (startAction)
        {
           dweller.GetComponent<Animator>().SetTrigger("Walk");
           ai.destination = targetPosition;
           ai.SearchPath();
           startAction = false;
        }

        if (!ai.pathPending && (ai.reachedEndOfPath || !ai.hasPath))
        {
            dweller.GetComponent<Animator>().SetTrigger("Idle");
            completed = true;
        }
    }
}
