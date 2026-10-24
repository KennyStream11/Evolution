using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Bebe : MonoBehaviour
{

    // ========== IDENTITE ==========
    [SerializeField] EspeceCreature espece;
    [SerializeField] TMP_Text texteNomBebe;
    public void MettreAJourNomBebe(EspeceCreature nouvelleEspece)
    {
        espece = nouvelleEspece;
        texteNomBebe.text = espece.Nom;
        ptsCroissanceRequis = PointsRequisSelonRarete(nouvelleEspece);
        MettreAJourCroissance();
    }




    // ========== COEUR ET SOIN ==========
    [SerializeField] List<Generateur> generateurs;
    [SerializeField] TMP_Text texteCoeur;
    [SerializeField] TMP_Text texteProduction;

    [SerializeField] float multiplicateurCout = 1.15f;

    float coeur = 0;
    float coeurParClic = 1;
    [SerializeField] float coeurParSeconde = 0f;

    public void Acheter(int index)
    {
        Generateur g = generateurs[index];

        //Si le joueur a au moins autant de coeurs que le coût du générateur:
        if (coeur >= g.cout)
        {
            //retirer le coût de ses coeurs,
            coeur -= g.cout;

            //ajouter 1 au nombre du générateur,
            g.nombre++;

            //augmenter la production par seconde de la production du générateur,
            coeurParSeconde += g.production;

            //multiplier le coût par le multiplicateur,
            g.cout *= multiplicateurCout;

            //mettre à jour l’affichage.
            MettreAJourAffichage();
            Debug.Log(g.nom + " achetée avec succès !");

        }
        else
        {
            Debug.Log("Pas assez de Coeurs pour " + g.nom + " (coût : " + g.cout + ")");
        }
    }

    float Cliquer(float coeurCible, float clicCoeur)
    {
        return coeurCible + clicCoeur;
    }

    public void Taper()
    {
        coeur = Cliquer(coeur, coeurParClic);
    }
    

    // ========== CROISSANCE ==========
    int ptsCroissance = 0;
    [SerializeField] int ptsCroissanceRequis;
    [SerializeField] float coutCroissance = 50f;
    [SerializeField] float multiplicateurCoutCroissance = 1.20f;
    [SerializeField] TMP_Text texteCroissance;
    public int PointsRequisSelonRarete(EspeceCreature g)
    {
        if(g.Rarete == Rarete.Commune)
        {
            return 10;
        }
        else if(g.Rarete == Rarete.Rare)
        {
            return 15;
        }
        else
        {
            return 20;
        }
    }
    public void AcheterCroissance()
    {

        //Si le joueur a au moins autant de coeurs que le coût du générateur:
        if (coeur >= coutCroissance)
        {
            //retirer le coût de ses coeurs,
            coeur -= coutCroissance;

            //ajouter 1 au nombre du générateur,
            ptsCroissance++;

            //multiplier le coût par le multiplicateur,
            coutCroissance *= multiplicateurCoutCroissance;

            //mettre à jour l’affichage.
            texteCroissance.text = ptsCroissance + "/" + ptsCroissanceRequis + " Croissance";
            Debug.Log("Point de croissance acheté avec succès !");

        }
        else
        {
            Debug.Log("Pas assez de Coeurs pour acheter ce point de croissance (coût : " + coutCroissance + ")");
        }
    }


    // ========== START ==========
    void Start()
    {
        // Setup du bouton d'achat
        MettreAJourAffichage();

    }


    // ========== UPDATE ==========
    void Update()
    {

        // Calcul des gains par secondes
        float coeurCetteImage = coeurParSeconde * Time.deltaTime;
        // Ajoute les coeurs produits par l'image aux coeurs totaux
        coeur += coeurCetteImage;
        // Affichage du compteur
        texteCoeur.text = "Coeurs : " + Mathf.FloorToInt(coeur);

        //Griser le bouton si les coeurs sont insuffisants pour Generateur
        foreach (Generateur g in generateurs)
        {
            if (coeur >= g.cout)
            {
                g.bouton.interactable = true;
            }
            else
            {
                g.bouton.interactable = false;
            }
        }

    }

    void MettreAJourCroissance()
    {
        texteCroissance.text = ptsCroissance + "/" + ptsCroissanceRequis + "Croissance";
    }
    void MettreAJourAffichage()
    {
        // 1. le texte de production : la production TOTALE (coeurParSeconde), une seule fois
        texteProduction.text = "+ " + coeurParSeconde + "/s";
        texteCroissance.text = ptsCroissance + "/" + ptsCroissanceRequis + " Croissance";
        foreach (Generateur g in generateurs)
        {
            // 2. le texte du bouton de g : nom de g + " (x" + nombre de g + ")\nCoût : " + coût de g arrondi vers le haut + " Coeurs"
            g.textBouton.text = g.nom + " (x" + g.nombre + ")\nCoût : " + Mathf.CeilToInt(g.cout) + " Coeurs";
        }

    }

}


