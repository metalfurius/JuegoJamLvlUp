using UnityEngine;

[System.Serializable]
public class Wave
{
    public GameObject enemy;
    public int baseCount; // Cantidad base de enemigos en la primera oleada
    public float baseRate; // Tasa base de aparición de enemigos en la primera oleada
    public float roundWeightAugment=0.04f;


    public int count
    {
        get
        {
            // Ajusta la cantidad de enemigos en función de la ronda actual (roundIndex)
            // Puedes agregar un factor de aumento multiplicativo para un aumento más significativo
            return Mathf.RoundToInt(baseCount + (WaveSpawner.roundIndex * roundWeightAugment*Random.Range(10,25)));
        }
    }

    public float rate
    {
        get
        {
            // Ajusta la tasa de aparición de enemigos en función de la ronda actual (roundIndex)
            // Puedes agregar un factor de aumento multiplicativo para un aumento más significativo
            return baseRate + (WaveSpawner.roundIndex * roundWeightAugment*Random.Range(1,4));
        }
    }
}
