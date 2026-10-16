using UnityEngine;
using TMPro;

public class Bebe : MonoBehaviour
{
    [SerializeField] EspeceCreature espece;
    [SerializeField] TMP_Text textNomBebe;

    public void MettreAJourNomBebe(EspeceCreature nouvelleEspece)
    {
        espece = nouvelleEspece;
        textNomBebe.text = espece.Nom;
    }

    private void Start()
    {
        MettreAJourNomBebe(espece);
    }
}
