﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class WorkingState : IBehaviourState
{
    private ITask assignedTask;
    private Dweller dweller;
    private ResourceManager rm;

    public WorkingState(Dweller dweller, ITask assignedTask)
    {
        dweller.SetCurrentTask(assignedTask);
        assignedTask.SetTaskAssigned(true);
        this.assignedTask = assignedTask;
        this.dweller = dweller;
        assignedTask.BeginTask(dweller);
        this.rm = GameObject.Find("GameManager").GetComponent<ResourceManager>();
    }

    public void OnEnter()
    {

    }

    public IAction NextAction()
    {
        IAction action = assignedTask.GetCriteria();

        if (action != null)
        {
            return action;
        }
        
        if (!assignedTask.CheckCriteria())
        {
            return null;
        }
        return assignedTask.Progress();
        
    }
    public void OnExit()
    {
    }
}
