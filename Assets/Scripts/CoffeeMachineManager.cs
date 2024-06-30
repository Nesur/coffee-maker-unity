using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoffeeMachineManager : MonoBehaviour
{

    private static CoffeeMachineManager _INSTANCE;
    public static CoffeeMachineManager INSTANCE { get { return _INSTANCE; } private set { _INSTANCE = value; } }


    [SerializeField] 
    private GameObject smallCupPrefab;
    [SerializeField] 
    private GameObject mediumCupPrefab;
    [SerializeField] 
    private GameObject largeCupPrefab;
    [SerializeField]
    private GameObject m_brewingSpot;
    public GameObject brewingSpot { get { return m_brewingSpot; } }
    [SerializeField]
    private GameObject m_Status;
    [SerializeField]
    private GameObject m_BrewingStreamSpot;
    public GameObject brewingStreamSpot { get { return m_BrewingStreamSpot; } }
    [SerializeField]
    private GameObject m_brewingStreamParticleSystem;
    public GameObject brewingStreamParticleSystem { get { return m_brewingStreamParticleSystem; } }




    private CoffeeWaterAmount m_WaterAmount = CoffeeWaterAmount.SMALL;
    public CoffeeWaterAmount waterAmount { get { return m_WaterAmount; } }
    
    private GameObject m_SelectedCoffee = null;
    public GameObject selectedCoffee { get { return m_SelectedCoffee; } private set { m_SelectedCoffee = value; } }

    private ICoffeeMachineState coffeeMachineState;
    private bool isReady = true;
    private GameObject currentCup;
    private Renderer renderer;
    private AudioSource audioSource;
    void Awake()
    {
        if (_INSTANCE == null)
        {
            _INSTANCE = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(new IdleState());
        renderer = m_Status.GetComponent<Renderer>();
        audioSource = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        coffeeMachineState.UpdateState(this);
        UpdateStatus();
    }

    private void UpdateStatus()
    {
        if (isReady)
        {
            renderer.material.SetColor("_Color", Color.green);
        }
        else
        {
            renderer.material.SetColor("_Color", Color.red);
        }
    }

    public void ChangeState(ICoffeeMachineState coffeeMachineState)
    {
        this.coffeeMachineState = coffeeMachineState;
        this.coffeeMachineState.EnterState(this);
    }



    public void GrindBeans()
    {
        audioSource.Play();
    }

    public enum CoffeeWaterAmount
    {
        SMALL, MEDIUM, LARGE
    }
    public void SetBusy()
    {
        isReady = false;
    }
    public void SetReady()
    {
        isReady = true;
        m_SelectedCoffee = null;
    }

    public void SelectCoffee(GameObject coffeePrefab)
    {
        if (m_SelectedCoffee != null)
        {
            Debug.Log("Brewing in progress");
        }
        else
        {

            if (currentCup != null)
            {
                Destroy(currentCup);
                currentCup = null;
            }
            currentCup = PutCup();
            float waterAmount = GetWaterAmount();
            GameObject coffeeGameObject = Instantiate(coffeePrefab, currentCup.GetComponentInChildren<Transform>());
            var coffee = coffeeGameObject.GetComponentInChildren<Coffee>() as Coffee;
            coffee.SetWaterAmount(waterAmount);
            m_SelectedCoffee = coffeeGameObject;
        }
    }


    private float GetWaterAmount()
    {
        switch (waterAmount)
        {
            case CoffeeWaterAmount.SMALL:
                return 1.0f;
            case CoffeeWaterAmount.MEDIUM:
                return 1.5f;
            case CoffeeWaterAmount.LARGE:
                return 2.0f;
        }
        return 0.0f;
    }

    public void SelectWaterAmount(CoffeeWaterAmount coffeeWaterAmount)
    {
        this.m_WaterAmount = coffeeWaterAmount;
    }

    public GameObject PutCup()
    {
        GameObject cupToSpawn = null;
        switch (m_WaterAmount)
        {
            case CoffeeWaterAmount.SMALL:
                cupToSpawn = smallCupPrefab;
                break;
            case CoffeeWaterAmount.MEDIUM:
                cupToSpawn = mediumCupPrefab;
                break;
            case CoffeeWaterAmount.LARGE:
                cupToSpawn = largeCupPrefab;
                break;

        }
        return Instantiate(cupToSpawn, brewingSpot.transform.position, cupToSpawn.transform.rotation);
    }
}
