using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;


    public GameObject upgradedTurret;
    public int upgradeCost;

    public Bullet bullet;
    public int GetSellAmount()
    {
        return cost / 2;
    }

}
