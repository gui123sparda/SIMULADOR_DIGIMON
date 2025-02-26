using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DigimonController : MonoBehaviour
{
    public EvolutionTree evolutionTree;
    public string digimonName;
    public Sprite digimonImage;
    public SpriteRenderer spriteRenderer;
    public int treino = 0;
    public int felicidade =50;
    public int fome = 50;

    public TextMeshProUGUI nomeTextMesh;
    public TextMeshProUGUI treinoTextMesh;
    public TextMeshProUGUI felicidadeTextMesh;
    public TextMeshProUGUI fomeTextMesh;

    void Awake(){
        digimonName = evolutionTree.rootNode.digimonName;
        digimonImage = evolutionTree.rootNode.digimonSprite;
        spriteRenderer.sprite = digimonImage;
    }
    void Start()
    {
        digimonName = evolutionTree.rootNode.digimonName;
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
        spriteRenderer.sprite = digimonImage;
        nomeTextMesh.text = digimonName;
        treinoTextMesh.text = treino.ToString();
        felicidadeTextMesh.text = felicidade.ToString();
        fomeTextMesh.text = fome.ToString();
        
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
