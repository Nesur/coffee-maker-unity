using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreBrewingState : ICoffeeMachineState
{
    private bool isPreparing = false;
    public void EnterState(CoffeeMachineManager coffeeMachineManager)
    {
        coffeeMachineManager.SetBusy();
        coffeeMachineManager.GrindBeans();
    }

    public void UpdateState(CoffeeMachineManager coffeeMachineManager)
    {
        if (!isPreparing)
        {
            isPreparing = true;
            coffeeMachineManager.StartCoroutine(PrepareToBrew(coffeeMachineManager));
        }
    }

    private IEnumerator PrepareToBrew(CoffeeMachineManager coffeeMachineManager) { 
        yield return new WaitForSeconds(6f);
        coffeeMachineManager.ChangeState(new BrewingState());
    }
}
