using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Coffee : MonoBehaviour
{
    protected float waterAmount;
    // ENCAPSULATION
    public bool isBrewed { get; private set; }  = false;
    public bool isBrewing { get; set; }  = false;
    // INHERITANCE
    public virtual void Brew()
    {
        float waterLimit = waterAmount - 0.2f;
        if (isBrewing && transform.localScale.y < waterLimit)
        {
            transform.localScale += new Vector3(0f, Time.deltaTime / 3, 0f);
        }
        else if(transform.localScale.y >= waterLimit)
        {
            isBrewed = true;
        }

    }
    // ABSTRACTION
    public abstract string GetName();

    public void SetWaterAmount(float waterAmount)
    {
        this.waterAmount = waterAmount;
    }

    void Update()
    {
        Brew();    
    }
}

