using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// POLYMORPHISM
public class BrewingState : ICoffeeMachineState
{
    private Coffee coffee;
    private GameObject coffeeStreamParticleSystem;

    public void EnterState(CoffeeMachineManager coffeeMachineManager)
    {
        coffee = coffeeMachineManager.selectedCoffee.GetComponentInChildren<Coffee>();
        coffeeStreamParticleSystem = Object.Instantiate(coffeeMachineManager.brewingStreamParticleSystem, coffeeMachineManager.brewingStreamSpot.transform.position, coffeeMachineManager.brewingStreamParticleSystem.transform.rotation);
        coffeeMachineManager.StartCoroutine(StartBrewing());
    }

    public void UpdateState(CoffeeMachineManager coffeeMachineManager)
    {
        if(coffee.isBrewed) 
        {
            BrewingFinishedState brewingFinishedState = new BrewingFinishedState();
            Object.Destroy(coffeeStreamParticleSystem);
            coffeeMachineManager.ChangeState(brewingFinishedState);
        }
    }
    /// <summary>
    /// Delay is used because cup was filling with coffee without stream touching glass
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartBrewing()
    {
        yield return new WaitForSeconds(2);
        coffee.isBrewing = true;
    }
}
