using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<Generateur> generateurs;
    [SerializeField] TMP_Text texteAdn;
    [SerializeField] TMP_Text texteProduction;

    [SerializeField] float multiplicateurCout = 1.15f;



    float adn = 0;
    float adnParClic = 1;
    [SerializeField] float adnParSeconde = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Setup du bouton d'achat
        MettreAJourAffichage();

        

    }


    // Update is called once per frame
    void Update()
    {

        // Calcul des gains par secondes
        float adnCetteImage = adnParSeconde * Time.deltaTime;
        // Ajoute l'adn produit par l'image à l'adn total
        adn += adnCetteImage;
        // Affichage du compteur
        texteAdn.text = "ADN : " + Mathf.FloorToInt(adn);

        //Griser le bouton si l'adn est insuffisant pour Mitochondrie
        foreach (Generateur g in generateurs)
        {
            if (adn >= g.cout)
            {
                g.bouton.interactable = true;
            }
            else
            {
                g.bouton.interactable = false;
            }
        }

    }

    public void Acheter(int index)
    {
        Generateur g = generateurs[index];

        //Si le joueur a au moins autant d’ADN que le coût du générateur:
        if (adn >= g.cout)
        {
            //retirer le coût de son ADN,
            adn -= g.cout;

            //ajouter 1 au nombre du générateur,
            g.nombre++;

            //augmenter la production par seconde de la production du générateur,
            adnParSeconde += g.production;

            //multiplier le coût par le multiplicateur,
            g.cout *= multiplicateurCout;

            //mettre à jour l’affichage.
            MettreAJourAffichage();
            Debug.Log(g.nom + " achetée avec succès !");

        }
        else
        {
            Debug.Log("Pas assez d'ADN pour " + g.nom + " (coût : " + g.cout + ")");
        }
    }

    float Cliquer(float adnCible, float clicAdn)
    {
        return adnCible + clicAdn;
    }

    public void Taper()
    {
        adn = Cliquer(adn, adnParClic);
    }
    void MettreAJourAffichage()
    {
        // 1. le texte de production : la production TOTALE (adnParSeconde), une seule fois
        texteProduction.text = "+ " + adnParSeconde + "/s";
        foreach (Generateur g in generateurs)
        {
            // 2. le texte du bouton de g : nom de g + " (x" + nombre de g + ")\nCoût : " + coût de g arrondi vers le haut + " ADN"
            g.textBouton.text = g.nom + " (x" + g.nombre + ")\nCoût : " + Mathf.CeilToInt(g.cout) + " ADN";
        }

    }
}
