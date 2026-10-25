using System.Collections.Generic;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.UI;


public class Collection : MonoBehaviour
{
    List<EspeceCreature> especeObtenues = new List<EspeceCreature>();
    [SerializeField] GameObject panneauCollection;
    [SerializeField] Incubateur incubateur;
    [SerializeField] List<CaseCollection> caseCollection;

    public void AddCollection(EspeceCreature e)
    {
        Debug.Log("Tentative d'ajout de créature à la collection.");
        especeObtenues.Add(e);
        Debug.Log(e.Nom + " ajouté");
        Debug.Log("La collection contient " + especeObtenues.Count + " créatures.");

        int iterationCreature = 0;

        foreach (EspeceCreature f in especeObtenues)
        {
            if (f == e)
            {
                iterationCreature++;
            }
        }
        Debug.Log("La collection contient " + iterationCreature + " " + e.Nom);
        Sauvegarder();
        Debug.Log("Partie Sauvegardé");
    }

    public void Ouvrir()
    {
        AfficherCollection();
        panneauCollection.gameObject.SetActive(true);
    }
    public void Fermer()
    {
        panneauCollection.gameObject.SetActive(false);
    }

    public int NombreDe(EspeceCreature recherchee)
    {
        int count = 0;

        foreach (EspeceCreature e in especeObtenues)
        {
            if (e == recherchee)
            {
                count++;
            }
        }
        return count;
    }
    void AfficherCollection()
    {
        //pour i de 0 jusqu'au nombre d'espèces:
        for (int i = 0; i < incubateur.Especes.Count; i++)
        {
            EspeceCreature especeActuelle = incubateur.Especes[i];
            CaseCollection caseActuelle = caseCollection[i];
            int nombre = NombreDe(especeActuelle);
            if (nombre > 0)
            {
                caseActuelle.silhouette.color = especeActuelle.Couleur;
                caseActuelle.caseName.text = especeActuelle.Nom;
                caseActuelle.caseCount.text = "" + nombre;
            }
            else
            {
                caseActuelle.silhouette.color = Color.black;
                caseActuelle.caseName.text = "???";
                caseActuelle.caseCount.text = "";

            }
        }
    }

    //    1. Sauvegarder() : pour chaque espèce de incubateur.Especes, range NombreDe(cette espèce) sous l’étiquette "Collection_" + son nom.Puis PlayerPrefs.Save().
    //💡 C’est la même boucle que AfficherCollection, avec une ligne de PlayerPrefs à la place de l’affichage.

    public void Sauvegarder()
    {
        foreach(EspeceCreature e in incubateur.Especes)
        {
            PlayerPrefs.SetInt("Collection_" + e.BaseID, NombreDe(e));
        }
        PlayerPrefs.Save();
    }
    void Charger()
    {
        foreach (EspeceCreature e in incubateur.Especes)
        {
            int loadNombre = PlayerPrefs.GetInt("Collection_" + e.BaseID, 0);

            for (int i = 0; i < loadNombre; i++)
            {
                especeObtenues.Add(e);
            }
        }
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("OeufEnCours"))
        {
            ;
        }
        else
        {
        }
            Debug.Log("Partie chargée");
        Charger();
    }
}

