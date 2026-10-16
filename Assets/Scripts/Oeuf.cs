using UnityEngine;

public class Oeuf : MonoBehaviour
{
    [SerializeField] EspeceCreature espece;
    [SerializeField] int tapsEnCours = 0;
    [SerializeField] Incubateur incubateur;
    [SerializeField] Color legendaire;
    [SerializeField] Color rare;
    [SerializeField] Color commune;
    int tapsPourEclore;
    Color couleurDefinie;
    Color CouleurOeuf()
    {
        if (espece.Rarete == Rarete.Commune)
        {
            Debug.Log("L'oeuf est Commun, il sera de couleur Verte");
            return commune;
        }
        else if (espece.Rarete == Rarete.Rare)
        {
            Debug.Log("L'oeuf est Rare, il sera de couleur Bleue");
            return rare;
        }
        else
        {
            Debug.Log("L'oeuf est Légendaire, il sera de couleur Dorée");
            return legendaire;
        }
    }

    int TapsPourEclore()
    {
        if (espece.Rarete == Rarete.Commune)
        {
            Debug.Log("L'oeuf est Commun, il mettra 5 taps à éclore!");
            return 5;
        }
        else if (espece.Rarete == Rarete.Rare)
        {
            Debug.Log("L'oeuf est Rare, il mettra 10 taps à éclore!");
            return 10;
        }
        else
        {
            Debug.Log("L'oeuf est Légendaire, il mettra 15 taps à éclore!");
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
        //Logs console debug
        Debug.Log(couleurDefinie);
        Debug.Log(tapsPourEclore);
        Debug.Log(espece.Rarete);

    }
}
