﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public interface ITask
{

    void AssignDweller();
    Seeker ReleaseDweller();

}