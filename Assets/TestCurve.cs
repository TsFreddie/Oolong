using System;
using System.Collections;
using System.Collections.Generic;
using TSF.Oolong.UGUI;
using UnityEngine;

public class TestCurve : MonoBehaviour
{
    public void Update()
    {
        var t = Mathf.Repeat(Time.time / 5.0f, 1.0f);
        var x = new CubicBezier(.06f, .82f, .08f, .97f).Evaluate(t);
        transform.position = new Vector3(x * 5, 0, 0);
    }
}
