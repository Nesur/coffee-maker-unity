using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static CoffeeMachineManager;

public class CoffeeMachineUIHandler : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown waterAmountDropdown;
    [SerializeField]
    private GameObject espressoPrefab;
    
    [SerializeField]
    private GameObject cremaPrefab;
    [SerializeField]
    private GameObject lattePrefab;

    public void WaterAmountChanged()
    {
        CoffeeWaterAmount coffeeWaterAmount = (CoffeeWaterAmount)waterAmountDropdown.value;
        CoffeeMachineManager.INSTANCE.SelectWaterAmount(coffeeWaterAmount);
    }
    

    public void SelectExpresso()
    {
        CoffeeMachineManager.INSTANCE.SelectCoffee(espressoPrefab);
    }

    
    public void SelectCrema()
    {
        CoffeeMachineManager.INSTANCE.SelectCoffee(cremaPrefab);
    }
    
    public void SelectLatte()
    {
        CoffeeMachineManager.INSTANCE.SelectCoffee(lattePrefab);
    }

    public void GoBackToMenu()
    {
        SceneManager.LoadScene("TitleScene");
    }

}
