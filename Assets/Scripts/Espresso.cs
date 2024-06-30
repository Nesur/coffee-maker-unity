using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espresso : Coffee
{
    // INHERITANCE
    public override void Brew()
    {
       base.Brew();
    }

    // POLYMORPHISM
    public override string GetName()
    {
        return "Espresso";
    }

}
