using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// POLYMORPHISM
public class IdleState : ICoffeeMachineState
{
    public void EnterState(CoffeeMachineManager coffeeMachineManager)
    {
        coffeeMachineManager.SetReady();
    }

    public void UpdateState(CoffeeMachineManager coffeeMachineManager)
    {
        if (coffeeMachineManager.selectedCoffee != null)
        {
            PreBrewingState preBrewingState = new PreBrewingState();
            coffeeMachineManager.ChangeState(preBrewingState);
        }
    }
}
