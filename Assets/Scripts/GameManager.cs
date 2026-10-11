using UnityEngine;

public class GameManager : MonoBehaviour
{
    float adn = 0;
    float adnParClic = 1;

    float adnParSeconde = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        adn = Cliquer(adn, adnParClic);
 
    }

    // Update is called once per frame
    void Update()
    {
        float adnCetteImage = adnParSeconde * Time.deltaTime;
        adn += adnCetteImage;
        Debug.Log("Tu as actuellement " + adn + " ADN.");
    }
    float Cliquer(float adnCible, float clicAdn)
    {
        return adnCible + clicAdn;
    }
}
