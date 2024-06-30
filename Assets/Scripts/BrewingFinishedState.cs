using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// POLYMORPHISM
public class BrewingFinishedState : ICoffeeMachineState
{
    public void EnterState(CoffeeMachineManager coffeeMachine)
    {
        var coffee= coffeeMachine.selectedCoffee.GetComponentInChildren<Coffee>();
        Debug.Log("Brewing finished: " + coffee.GetName());
        coffeeMachine.ChangeState(new IdleState());
    }

    public void UpdateState(CoffeeMachineManager coffeeMachine)
    {
    }
}
