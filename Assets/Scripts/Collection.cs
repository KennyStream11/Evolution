using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Collection : MonoBehaviour
{
    List<EspeceCreature> creatureARanger = new List<EspeceCreature>();
    [SerializeField] GameObject panneauCollection;

    public void AddCollection(EspeceCreature e)
    {
        Debug.Log("Tentative d'ajout de créature à la collection.");
        creatureARanger.Add(e);
        Debug.Log(e.Nom + " ajouté");
        Debug.Log("La collection contient " + creatureARanger.Count + " créatures.");

        int iterationCreature = 0;

        foreach (EspeceCreature f in creatureARanger)
        {
            if (f == e)
            {
                iterationCreature++;
            }
        }
        Debug.Log("La collection contient " + iterationCreature + " " + e.Nom );
    }

    public void Ouvrir()
    {
        panneauCollection.gameObject.SetActive(true);
    }
    public void Fermer()
    {
        panneauCollection.gameObject.SetActive(false);
    }
}

