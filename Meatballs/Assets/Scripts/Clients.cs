using UnityEngine;
using System.Collections;

public class Clients{
    public int difficulty;
    public int[,] preferences;
    public int maxPayment;
    public string clientName;
    public float time;
    public string gender;

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

    private void SetPayment() {
        switch (difficulty) {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
        }
    }

    private void SetName() { }

    private int GetRandom(){
        int rnd = Random.Range(1, 7);
        return rnd;
    }

    public Clients() {
        difficulty = Random.Range(1, 6);
    }

    public void SetClient() {
        SetName();
        SetPayment();
        int ingredient1 = 0;
        int ingredient2 = 0;
        int ingredient3 = 0;

        switch (difficulty) {
            case 1:
                clientName = "Jeff";
                ingredient1 = GetRandom();
                ingredient2 = GetRandom();
                preferences = new int[2,2];

                preferences[0, 0] = ingredient1;
                preferences[1, 0] = SetTasteValue();

                preferences[0, 1] = ingredient2;
                preferences[1, 1] = SetTasteValue();

                Debug.Log("Ingrediente 1 " + preferences[0,0] + " " + preferences[1,0]);
                Debug.Log("Ingrediente 2 " + preferences[0, 1] + " " + preferences[1, 1]);
                break;
            case 2:
                clientName = "John";
                ingredient1 = GetRandom();
                ingredient2 = GetRandom();
                preferences = new int[2, 2];

                preferences[0, 0] = ingredient1;
                preferences[1, 0] = SetTasteValue();

                preferences[0, 1] = ingredient2;
                preferences[1, 1] = SetTasteValue();

                Debug.Log("Ingrediente 1 " + preferences[0, 0] + " " + preferences[1, 0]);
                Debug.Log("Ingrediente 2 " + preferences[0, 1] + " " + preferences[1, 1]);
                break;
            case 3:
                clientName = "Jason";
                ingredient1 = GetRandom();
                ingredient2 = GetRandom();
                ingredient3 = GetRandom();
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
                clientName = "Julio";
                ingredient1 = GetRandom();
                ingredient2 = GetRandom();
                ingredient3 = GetRandom();
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
                clientName = "Jeffry";
                ingredient1 = GetRandom();
                ingredient2 = GetRandom();
                ingredient3 = GetRandom();
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

    private int SetTasteValue() {
        int tasteValue = 0;
        float tastePercent = Random.Range(0f, 1f);
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
        else {
            tasteValue = 4;
        }
        return tasteValue;
    }
}
