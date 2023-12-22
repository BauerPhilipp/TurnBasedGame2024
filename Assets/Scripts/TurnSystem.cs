using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{

    public event EventHandler OnTurnChanged;

    public static TurnSystem Instance {  get; private set; }

    private int turnNumber = 1;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void NextTurn()
    {
        turnNumber++;

        OnTurnChanged?.Invoke(this, EventArgs.Empty);

    }

    public int GetTurnNumber()
    {
        return turnNumber;
    }
}