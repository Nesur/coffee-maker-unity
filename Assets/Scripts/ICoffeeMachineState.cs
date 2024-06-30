using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ABSTRACTION
public interface ICoffeeMachineState
{
    void EnterState(CoffeeMachineManager coffeeMachine);
    void UpdateState(CoffeeMachineManager coffeeMachine);
}
