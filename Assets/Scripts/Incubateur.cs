using System.Collections.Generic;
using UnityEngine;

public class Incubateur : MonoBehaviour
{
    [SerializeField] List<EspeceCreature> especes;
    [SerializeField] float chanceLegendaire = 5f;
    [SerializeField] float chanceRare = 25f;


    // Tire une espèce au hasard, selon les raretés
    public EspeceCreature TirerEspece()
    {

        Rarete rareteTiree = TirerRarete();
        List<EspeceCreature> candidates = new List<EspeceCreature>();
        foreach (EspeceCreature e in especes)
        {
            if (e.Rarete == rareteTiree)
            {
                Debug.Log("La rareté tirée est : " + rareteTiree);
                candidates.Add(e);
            }
        }

        Debug.Log("Tirage de l'index de la créature");

        int tirage = Random.Range(0, candidates.Count);
        Debug.Log("La créature choisie est " + candidates[tirage].Nom);
        return candidates[tirage];
    }

    // Tire une rareté : légendaire, rare ou commune
    Rarete TirerRarete()
    {
        float tirage = Random.Range(0f, 100f);

        if (tirage <= chanceLegendaire)
        {
            return Rarete.Legendaire;
        }
        else if (tirage <= chanceRare + chanceLegendaire)
        {
            return Rarete.Rare;

        }
        else
        {
            return Rarete.Commune;

        }
    }
    void Start()
    {
        int communes = 0;
        int rares = 0;
        int legendaires = 0;

        for (int i = 0; i < 10; i++)
        {
            EspeceCreature e = TirerEspece();

            // ✍️ if / else if / else : augmenter le compteur qui correspond à la rareté de e
            if (e.Rarete == Rarete.Legendaire)
            {
                legendaires++;
            }
            else if(e.Rarete == Rarete.Rare)
            {
                rares++;
            }
            else
            {
                communes++;
            }
        }

        // ✍️ un Debug.Log qui affiche les 3 compteurs
        Debug.Log("Le tirage a compté : " + communes + " communes/" + rares + " rares/" + legendaires + " legendaires");
    }
}