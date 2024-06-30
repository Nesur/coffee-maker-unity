using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Latte : Coffee
{
    // INHERITANCE
    public override void Brew()
    {
        base.Brew();
    }

    // POLYMORPHISM
    public override string GetName()
    {
        return "Latte";
    }
}
