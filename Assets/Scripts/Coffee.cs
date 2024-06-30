using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Coffee : MonoBehaviour
{
    protected float waterAmount;
    public bool isBrewed { get; private set; }  = false;
    public bool isBrewing { get; set; }  = false;
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

