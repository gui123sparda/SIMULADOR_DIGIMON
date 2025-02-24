using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[System.Serializable]
public class DigimonNode : MonoBehaviour
{
    public string digimonName;
    public Sprite digimonSprite;

    [Header("Evoluções")]
    public EvolutionOption evolutionLeft;
    public EvolutionOption evolutionMiddle;
    public EvolutionOption evolutionRight;

    public DigimonNode(string name, Sprite sprite){
        digimonName = name;
        digimonSprite = sprite;
    }
    





}
