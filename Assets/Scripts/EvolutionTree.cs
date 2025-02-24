using System.Collections.Generic;
using UnityEngine;

public class EvolutionTree : MonoBehaviour
{
   
    public DigimonNode rootNode;
    public DigimonNode currentNode;

    void Awake()
    {
        currentNode = rootNode;

        Debug.Log($"Digimon Inicial: {currentNode.digimonName}");
    }

    public DigimonNode TryEvolve(int treino, int felicidade, int fome){
        EvolutionOption[] options = { currentNode.evolutionLeft, currentNode.evolutionMiddle, currentNode.evolutionRight };

        foreach (var option in options)
        {
            
            if (option != null && option.nextEvolution != null &&
                treino >= option.minTreino && felicidade >= option.minFelicidade && fome <= option.maxFome)
            {
                Debug.Log($"Evoluiu para: {option.nextEvolution.digimonName}");
                return option.nextEvolution;
            }
        }
        Debug.Log("Nenhuma evolução ocorreu.");
        return currentNode;
    }
}