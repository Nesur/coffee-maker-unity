using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espresso : Coffee
{
    public override void Brew()
    {
       base.Brew();
    }

    public override string GetName()
    {
        return "Espresso";
    }

}