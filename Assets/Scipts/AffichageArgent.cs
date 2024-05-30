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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DescriptionArgent != null){
            DescriptionArgent.text = PlayerStats.Money.ToString() + " €";
        }
    }
}
