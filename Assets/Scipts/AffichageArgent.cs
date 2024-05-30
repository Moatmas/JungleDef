using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AffichageArgent : MonoBehaviour
{
    public TextMeshProUGUI DescriptionArgent;
    
    void Start()
    {
        DescriptionArgent.text = (PlayerStats.Money.ToString() + " $") ;
    }

    void Update()
    {
        DescriptionArgent.text = (PlayerStats.Money.ToString() + " $") ;
    }
}
