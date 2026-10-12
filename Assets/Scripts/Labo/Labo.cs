using System.Collections.Generic;
using UnityEngine;

public class Labo : MonoBehaviour
{
    List<Creature> creatures = new List<Creature>();

    //nom, vie, force, vitesse, resistance


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        creatures.Add(new Creature("Requin Puissant", 100, 25, 25, 5));
        creatures.Add(new Creature("Poisson Globe", 900, 15, 10, 10));
        creatures.Add(new Creature("", -500, -15, -10, -10));
        //Combat(creatures[0], creatures[1]);
        // Après le combat
        creatures[0].Soigner(30);
        creatures[0].Soigner(1000);
        creatures[1].Soigner(30);

        foreach (Creature c in creatures)
        {
            c.SePresenter();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Combat(Creature a, Creature b)
    {
        Debug.Log("---------------");
        Debug.Log("UN COMBAT ECLATE");
        Debug.Log("---------------");
        Creature rapide;
        Creature lent;

        if (a.Vitesse >= b.Vitesse)
        {
            rapide = a;
            lent = b;
        }
        else
        {
            rapide = b;
            lent = a;
        }

        Debug.Log(rapide.Nom + " est plus rapide, il frappera en premier.");
        while (rapide.EstVivante && lent.EstVivante)
        {
            rapide.Attaquer(lent);
            if (lent.EstVivante)
            {
                lent.Attaquer(rapide);
            }
        }

        if (!a.EstVivante)
        {
            Debug.Log(a.Nom + " s'est fait terrasser par " + b.Nom);
        }
        else
        {
            Debug.Log(b.Nom + " s'est fait terrasser par " + a.Nom);
        }

    }
}



