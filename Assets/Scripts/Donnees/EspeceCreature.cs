using UnityEngine;

public enum Rarete
{
    Commune,
    Rare,
    Legendaire
}

[CreateAssetMenu(fileName = "NouvelleEspece", menuName = "Creatures/Espece")]
public class EspeceCreature : ScriptableObject
{
    [SerializeField] string nom;
    public string Nom => nom;

    [SerializeField] Rarete rarete;
    public Rarete Rarete => rarete;
    [SerializeField] Color couleur = Color.white;
    public Color Couleur => couleur;
}