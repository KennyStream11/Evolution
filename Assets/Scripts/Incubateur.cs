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

                candidates.Add(e);

            }

        }
        if (candidates.Count == 0)
        {
            Debug.LogError("Attention la liste est vide! Rareté fautive : " + rareteTiree + ".");
            return especes[Random.Range(0, especes.Count)];
        }
        int tirage = Random.Range(0, candidates.Count);
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

        for (int i = 0; i < 100; i++)
        {
            EspeceCreature e = TirerEspece();

            if (e.Rarete == Rarete.Legendaire)
            {
                legendaires++;
            }
            else if (e.Rarete == Rarete.Rare)
            {
                rares++;
            }
            else
            {
                communes++;
            }
        }

        Debug.Log("Le tirage a compté : " + communes + " communes/" + rares + " rares/" + legendaires + " legendaires");
    }
}