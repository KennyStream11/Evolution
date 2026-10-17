using UnityEngine;
using TMPro;

public class Bebe : MonoBehaviour
{
    [SerializeField] EspeceCreature espece;
    [SerializeField] TMP_Text texteNomBebe;

    public void MettreAJourNomBebe(EspeceCreature nouvelleEspece)
    {
        espece = nouvelleEspece;
        texteNomBebe.text = espece.Nom;
    }
}
