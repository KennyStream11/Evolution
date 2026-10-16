using UnityEngine;
using UnityEngine.UI;

public class Oeuf : MonoBehaviour
{
    [SerializeField] EspeceCreature espece;
    [SerializeField] Incubateur incubateur;
    [SerializeField] Image imageOeuf;
    [SerializeField] GestionPhases gestionPhases;
    [SerializeField] Bebe bebe;


    //Init EGG TAPS
    [SerializeField] int tapsEnCours = 0;
    int tapsPourEclore;

    //Init EGG COLORS
    [SerializeField] Color legendaire;
    [SerializeField] Color rare;
    [SerializeField] Color commune;
    Color couleurDefinie;

    Color CouleurOeuf()
    {
        if (espece.Rarete == Rarete.Commune)
        {
            return commune;
        }
        else if (espece.Rarete == Rarete.Rare)
        {
            return rare;
        }
        else
        {
            return legendaire;
        }
    }

    int TapsPourEclore()
    {
        if (espece.Rarete == Rarete.Commune)
        {
            return 5;
        }
        else if (espece.Rarete == Rarete.Rare)
        {
            return 10;
        }
        else
        {
            return 15;
        }
    }

    public void TaperOeuf()
    {
        if (tapsEnCours < tapsPourEclore)
        {
            tapsEnCours++;
            Debug.Log(tapsEnCours);
            if (tapsEnCours == tapsPourEclore)
            {
                Debug.Log("Oeuf éclot");
                bebe.MettreAJourNomBebe(espece);
                gestionPhases.ChangerPhase(GestionPhases.Phase.Bebe);
            }
        }
    }


    private void Start()
    {
        //Initialisation et pioche de l'espece et de ses paramètres
        espece = incubateur.TirerEspece();
        //Utilisation des données piochées
        tapsPourEclore = TapsPourEclore();
        couleurDefinie = CouleurOeuf();

        imageOeuf.color = couleurDefinie;
        //Logs console debug
        Debug.Log("Votre oeuf a été choisi : " + espece.Nom + "! Créature " + espece.Rarete + "! Tapotez " + tapsPourEclore + " fois pour le faire éclore !");

    }
}
