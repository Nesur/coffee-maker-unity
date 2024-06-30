using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Latte : Coffee
{
    public override void Brew()
    {
        base.Brew();
    }

    public override string GetName()
    {
        return "Latte";
    }
}
