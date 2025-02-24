using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;

public class DigimonController : MonoBehaviour
{
    public EvolutionTree evolutionTree;
    public string digimonName;
    public Sprite digimonImage;

    public int treino = 0;
    public int felicidade =50;
    public int fome = 50;

    void Start()
    {
        digimonName = evolutionTree.rootNode.digimonName;
        digimonImage = evolutionTree.rootNode.digimonSprite;
        UpdateUI();
    }

    public void Train()
    {
        treino += 10;
        TryEvolve();
    }

    public void Play()
    {
        felicidade += 10;
        TryEvolve();
    }

    public void Feed()
    {
        fome -= 10;
        TryEvolve();
    }

    void Update()
    {
        digimonName = evolutionTree.currentNode.digimonName;
        if(Input.GetKeyDown(KeyCode.Z)){
            Train();
        }

        if(Input.GetKeyDown(KeyCode.X)){
            Play();
        }

        if(Input.GetKeyDown(KeyCode.C)){

            Feed();
        }
    }
    private void TryEvolve()
    {
        DigimonNode newDigimon = evolutionTree.TryEvolve(treino, felicidade, fome);
        if (newDigimon != evolutionTree.currentNode)
        {
            evolutionTree.currentNode = newDigimon;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        if (digimonImage == null || evolutionTree.currentNode.digimonSprite ==null){
            Debug.Log("Sem Imagem");
        }else
        if(digimonImage != null && evolutionTree.currentNode.digimonSprite !=null){
            digimonImage = evolutionTree.currentNode.digimonSprite;
        }
        Debug.Log($"Digimon Atual: {evolutionTree.currentNode.digimonName} | Treino: {treino}, Felicidade: {felicidade}, Fome: {fome}");
    }
}
