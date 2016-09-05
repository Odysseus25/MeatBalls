using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Clients{
    public int difficulty;
    public int[,] preferences;
    public int maxPayment;
    public string clientName;
    public float time;      //time in seconds 
    public char gender;

    private string[] maleNames = { "Verde", "Boga", "Macho", "Tulio" };
    private string[] femaleNames = { "Pao", "Nana", "Mary"};

    /* Ingredients code
     * Salt = 1
     * Pepper = 2
     * Onion = 3
     * Sweet Pepper = 4
     * Cilantro = 5
     * 
     * Los clientes tienen grados de dificultad desde 1 hasta 5 estrellas. 
     * 1 estrella = piden 2 ingredientes que solo salen de 1 spawner que se mueve.
     * 2 estrellas = piden 2 ingredientes que salen de 2 spawners.
     * 3 estrellas = piden tres ingredientes que salen de 3 spawners.
     * 4 estrellas = piden tres ingredientes que salen de 3 spawners y salen ingredientes malos.
     * 5 estrellas = igual que el 4 pero mas velocidad. 
     */


    public Clients()
    {
        System.Random rnd = new System.Random();
        difficulty = rnd.Next(1, 6);
    }

    void SetPayment() {
        switch (difficulty) {
            case 1:
                maxPayment = 10;
                break;
            case 2:
                maxPayment = 20;
                break;
            case 3:
                maxPayment = 30;
                break;
            case 4:
                maxPayment = 40;
                break;
            case 5:
                maxPayment = 50;
                break;
        }
    }

    void SetName() {
        if (this.gender == 'm')
        {
            this.clientName = maleNames[UnityEngine.Random.Range(0, 4)];
        }
        else {
            this.clientName = femaleNames[UnityEngine.Random.Range(0, 3)];
        }
    }

    void SetGender()
    {
        float rnd = UnityEngine.Random.Range(0f, 1f);
        if (rnd >= 0f && rnd <= 0.49f)
        {
            gender = 'm';
        }
        else
        {
            gender = 'f';
        }
    }

    void SetTime() {
        switch(difficulty) {
            case 1:
                time = 90f;
                break;
            case 2:
                time = 75f;
                break;
            case 3:
                time = 60f;
                break;
            case 4:
                time = 45f;
                break;
            case 5:
                time = 30f;
                break;
        }
    }

    int GetRandom(){
        int rnd = UnityEngine.Random.Range(1, 6);
        return rnd;
    }

    int SetTasteValue()
    {
        int tasteValue = 0;
        float tastePercent = UnityEngine.Random.Range(0f, 1f);
        if (tastePercent >= 0 && tastePercent <= 0.24f)
        {
            tasteValue = 1;
        }
        else if (tastePercent >= 0.25f && tastePercent <= 0.5f)
        {
            tasteValue = 2;
        }
        else if (tastePercent >= 0.51f && tastePercent <= 0.74f)
        {
            tasteValue = 3;
        }
        else
        {
            tasteValue = 4;
        }
        return tasteValue;
    }

    public void SetClient() {
        SetGender();
        SetName();
        SetTime();
        SetPayment();

        int ingredient1 = 0;
        int ingredient2 = 0;
        int ingredient3 = 0;

        switch (difficulty) {
            case 1:
                ingredient1 = GetRandom();
                ingredient2 = GetRandom();
                while (ingredient2 == ingredient1) {
                    ingredient2 = GetRandom();
                }
                preferences = new int[2,2];

                preferences[0, 0] = ingredient1;
                preferences[1, 0] = SetTasteValue();

                preferences[0, 1] = ingredient2;
                preferences[1, 1] = SetTasteValue();

                Debug.Log("Ingrediente 1 " + preferences[0,0] + " " + preferences[1,0]);
                Debug.Log("Ingrediente 2 " + preferences[0, 1] + " " + preferences[1, 1]);
                break;
            case 2:
                ingredient1 = GetRandom();
                ingredient2 = GetRandom();
                while (ingredient2 == ingredient1)
                {
                    ingredient2 = GetRandom();
                }
                preferences = new int[2, 2];

                preferences[0, 0] = ingredient1;
                preferences[1, 0] = SetTasteValue();

                preferences[0, 1] = ingredient2;
                preferences[1, 1] = SetTasteValue();

                Debug.Log("Ingrediente 1 " + preferences[0, 0] + " " + preferences[1, 0]);
                Debug.Log("Ingrediente 2 " + preferences[0, 1] + " " + preferences[1, 1]);
                break;
            case 3:
                ingredient1 = GetRandom();
                ingredient2 = GetRandom();
                while (ingredient2 == ingredient1)
                {
                    ingredient2 = GetRandom();
                }
                ingredient3 = GetRandom();
                while (ingredient3 == ingredient1 || ingredient3 == ingredient2)
                {
                    ingredient3 = GetRandom();
                }
                preferences = new int[2, 3];

                preferences[0, 0] = ingredient1;
                preferences[1, 0] = SetTasteValue();

                preferences[0, 1] = ingredient2;
                preferences[1, 1] = SetTasteValue();

                preferences[0, 2] = ingredient3;
                preferences[1, 2] = SetTasteValue();

                Debug.Log("Ingrediente 1 " + preferences[0, 0] + " " + preferences[1, 0]);
                Debug.Log("Ingrediente 2 " + preferences[0, 1] + " " + preferences[1, 1]);
                Debug.Log("Ingrediente 3 " + preferences[0, 2] + " " + preferences[1, 2]);
                break;
            case 4:
                ingredient1 = GetRandom();
                ingredient2 = GetRandom();
                while (ingredient2 == ingredient1)
                {
                    ingredient2 = GetRandom();
                }
                ingredient3 = GetRandom();
                while (ingredient3 == ingredient1 || ingredient3 == ingredient2)
                {
                    ingredient3 = GetRandom();
                }
                preferences = new int[2, 3];

                preferences[0, 0] = ingredient1;
                preferences[1, 0] = SetTasteValue();

                preferences[0, 1] = ingredient2;
                preferences[1, 1] = SetTasteValue();

                preferences[0, 2] = ingredient3;
                preferences[1, 2] = SetTasteValue();

                //agregar ingredientes malos
                Debug.Log("Ingrediente 1 " + preferences[0, 0] + " " + preferences[1, 0]);
                Debug.Log("Ingrediente 2 " + preferences[0, 1] + " " + preferences[1, 1]);
                Debug.Log("Ingrediente 3 " + preferences[0, 2] + " " + preferences[1, 2]);
                break;
            case 5:
                ingredient1 = GetRandom();
                ingredient2 = GetRandom();
                while (ingredient2 == ingredient1)
                {
                    ingredient2 = GetRandom();
                }
                ingredient3 = GetRandom();
                while (ingredient3 == ingredient1 || ingredient3 == ingredient2)
                {
                    ingredient3 = GetRandom();
                }
                preferences = new int[2, 3];

                preferences[0, 0] = ingredient1;
                preferences[1, 0] = SetTasteValue();

                preferences[0, 1] = ingredient2;
                preferences[1, 1] = SetTasteValue();

                preferences[0, 2] = ingredient3;
                preferences[1, 2] = SetTasteValue();

                //agregar ingredientes malos
                Debug.Log("Ingrediente 1 " + preferences[0, 0] + " " + preferences[1, 0]);
                Debug.Log("Ingrediente 2 " + preferences[0, 1] + " " + preferences[1, 1]);
                Debug.Log("Ingrediente 3 " + preferences[0, 2] + " " + preferences[1, 2]);
                break;
        }
    }
}
