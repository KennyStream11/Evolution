using UnityEngine;

public class Oeuf : MonoBehaviour
{
    [SerializeField] EspeceCreature espece;
    [SerializeField] int tapsEnCours;
    [SerializeField] Incubateur incubateur;

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

    private void Start()
    {
        espece = incubateur.TirerEspece();
        Debug.Log(espece.Nom);
        Debug.Log(TapsPourEclore());
    }
}
