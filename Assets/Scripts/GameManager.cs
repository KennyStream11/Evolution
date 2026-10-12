using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text texteAdn;
    [SerializeField] TMP_Text texteProduction;


    //Setup valeurs mitochondries
    //Premier générateur Mitochondrie
    //Cout de départ 10 ADN
    //Production : 1 ADN
    //Multiplicateur de cout : 15%
    [SerializeField] TMP_Text texteBoutonMitochondrie;
    [SerializeField] Button boutonMitochondrie;
    int nbMitochondrie = 0;
    [SerializeField] float coutMitochondrie = 10f;
    [SerializeField] float productionMitochondrie = 1f;
    [SerializeField] float multiplicateurCout = 1.15f;

    //Setup valeurs Ribosome
    //Deuxième générateur Ribosome
    //Cout de départ 100 ADN
    //Production : 8 ADN
    //Multiplicateur de cout : 15%
    [SerializeField] TMP_Text texteBoutonRibosome;
    [SerializeField] Button boutonRibosome;
    int nbRibosome = 0;
    [SerializeField] float coutRibosome = 100f;
    [SerializeField] float productionRibosome = 8f;




    float adn = 0;
    float adnParClic = 1;
    [SerializeField] float adnParSeconde = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Setup du bouton d'achat
        MettreAJourAffichageMitochondrie();
        MettreAJourAffichageRibosome();

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
        if(adn >= coutMitochondrie)
        {
            boutonMitochondrie.interactable = true;
        }
        else
        {
            boutonMitochondrie.interactable = false;
        }
        if (adn >= coutRibosome)
        {
            boutonRibosome.interactable = true;
        }
        else
        {
            boutonRibosome.interactable = false;
        }

    }
    public void AcheterMitochondrie()
    {
        //Si le joueur a au moins autant d’ADN que le coût de la mitochondrie:
        if (adn >= coutMitochondrie)
        {
            //retirer le coût de son ADN,
            adn -= coutMitochondrie;

            //ajouter 1 au nombre de mitochondries,
            nbMitochondrie++;

            //augmenter la production par seconde de la production d’une mitochondrie,
            adnParSeconde += productionMitochondrie;

            //multiplier le coût par le multiplicateur,
            coutMitochondrie *= multiplicateurCout;

            //mettre à jour l’affichage.
            MettreAJourAffichageMitochondrie();
            Debug.Log("Mitochondrie achetée avec succès !");
        }
        else
        {
            Debug.Log("Pas assez d'adn (coût : " + coutMitochondrie + ")");
        }
    }
    public void AcheterRibosome()
    {
        //Si le joueur a au moins autant d’ADN que le coût de la Ribosome:
        if (adn >= coutRibosome)
        {
            //retirer le coût de son ADN,
            adn -= coutRibosome;

            //ajouter 1 au nombre de Ribosome,
            nbRibosome++;

            //augmenter la production par seconde de la production d’une Ribosome,
            adnParSeconde += productionRibosome;

            //multiplier le coût par le multiplicateur,
            coutRibosome *= multiplicateurCout;

            //mettre à jour l’affichage.
            MettreAJourAffichageRibosome();
            Debug.Log("Ribosome achetée avec succès !");
        }
        else
        {
            Debug.Log("Pas assez d'adn (coût : " + coutRibosome + ")");
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
    void MettreAJourAffichageMitochondrie()
    {
        texteProduction.text = "+ " + adnParSeconde + "/s";
        texteBoutonMitochondrie.text = "Mitochondrie (x" + nbMitochondrie + ")\nCoût : " + Mathf.CeilToInt(coutMitochondrie) + " ADN";
        
    }
    void MettreAJourAffichageRibosome()
    {
        texteBoutonRibosome.text = "Ribosome (x" + nbRibosome + ")\nCoût : " + Mathf.CeilToInt(coutRibosome) + " ADN";

    }
}
