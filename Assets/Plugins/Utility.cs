﻿using UnityEngine;
using System.Collections;


public static class Utility
{
    public static void Flip(this SpriteRenderer _SpriteRenderer)
    {
        _SpriteRenderer.flipX = !_SpriteRenderer.flipX;
    }

    public static Vector3 GetUnitVector(GameObject Source, GameObject Target)
    {
        var TargetParent = Target.transform.parent;
        Target.transform.parent = Source.transform;
        var UnitVector = Target.transform.localPosition.normalized;
        Target.transform.parent = TargetParent;

        return UnitVector;
    }
}