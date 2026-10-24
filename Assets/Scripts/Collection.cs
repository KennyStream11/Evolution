using System.Collections.Generic;
using UnityEngine;


public class Collection : MonoBehaviour
{
    List<EspeceCreature> creatureARanger = new List<EspeceCreature>();

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
}

