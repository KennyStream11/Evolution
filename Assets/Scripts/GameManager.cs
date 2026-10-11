using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text texteAdn;
    [SerializeField] TMP_Text texteProduction;
    [SerializeField] TMP_Text texteBoutonMitochondrie;
    [SerializeField] Button boutonMitochondrie;

    //Setup valeurs mitochondries
    int nbMitochondrie = 0;
    [SerializeField] float coutMitochondrie = 10f;
    [SerializeField] float productionMitochondrie = 1f;
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

        if(adn >= coutMitochondrie)
        {
            boutonMitochondrie.interactable = true;
        }
        else
        {
            boutonMitochondrie.interactable = false;
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
            MettreAJourAffichage();
            Debug.Log("Mitochondrie achetée avec succès !");
        }
        else
        {
            Debug.Log("Pas assez d'adn (coût : " + coutMitochondrie + ")");
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
        texteProduction.text = "+ " + adnParSeconde + "/s";
        texteBoutonMitochondrie.text = "Mitochondrie (x" + nbMitochondrie + ")\nCoût : " + Mathf.CeilToInt(coutMitochondrie) + " ADN";
        
    }
}
