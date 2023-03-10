using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLogicScript : MonoBehaviour
{
    // Clasa de tip Service pentru logica principala a jocului
    // HatzCount - Numarul de hatzuri stocate
    // MainClickerLogicSubservice - Model pentru un "SubService" de tip MainClickerLogic (explicat in fisierul aferent)
    public ulong HatzCount;
    public MainClickerLogic MainClickerLogicSubservice;
    public GameObject hatzClickParticle;
    public MainBuildingsLogic MainBuildingsLogicSubservice;
    private float timer;

    private void InitializeMainLogicScript()
    {
        // Functie pentru initializarea MainLogicScript. Apeleaza initializarea subserviciului si ar trebui apelata doar o data
        MainClickerLogicSubservice.InitializeClickerLogic();
        timer = 0f;
    }
    void Start()
    {
        // Start va fi apelata o singura data la incarcarea programului
        InitializeMainLogicScript();
        
    }

    void Update()
    {
        // Update este apelata in fiecare frame
        timer += Time.deltaTime;
        if(timer >= 1f)
        {
            timer = 0f;
            HatzCount += MainBuildingsLogicSubservice.tickBuildings();
        }
    }

    public void MainClickerButtonClicked()
    {
        // Functie care va fi apelata la apasarea butonului principal. Adauga hatzuri folosing subserviciul clicker logic
        ulong HatzToAdd = MainClickerLogicSubservice.GetHatzToAdd();
        HatzCount += HatzToAdd;
        Instantiate(hatzClickParticle).GetComponent<HatzParticleLogic>().setHatzCount(MainClickerLogicSubservice.GetHatzOnClick());
    }

    public double GetHatzCount()
    {
        return HatzCount;
    }

    public void SetHatzCount(ulong count)
    {
        HatzCount = count;
    }
}
