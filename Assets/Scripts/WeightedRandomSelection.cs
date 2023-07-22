using UnityEngine;
using System.Collections.Generic;

public class WeightedRandomSelection : MonoBehaviour
{
    [System.Serializable]
    public class WeightedElement
    {
        public GameObject gameObject; // Puedes reemplazar GameObject con el tipo de objeto que necesites
        public float baseWeight;
        public float maxWeight;
    }

    public List<WeightedElement> weightedList;
    public float roundWeightAugment=0.04f;

    public GameObject GetRandomWeightedElement()
    {
        // Calcula el peso total de todos los elementos en la lista
        float totalWeight = 0f;
        foreach (WeightedElement element in weightedList)
        {
            float adjustedWeight = element.baseWeight + (element.baseWeight * WaveSpawner.roundIndex * roundWeightAugment);
            totalWeight += Mathf.Min(adjustedWeight, element.maxWeight);
        }

        // Genera un número aleatorio entre 0 y el peso total
        float randomValue = Random.Range(0f, totalWeight);

        // Recorre la lista para encontrar el elemento correspondiente al valor aleatorio
        float weightSum = 0f;
        foreach (WeightedElement element in weightedList)
        {
            float adjustedWeight = element.baseWeight + (element.baseWeight * WaveSpawner.roundIndex * roundWeightAugment); 
            float weightedMax = Mathf.Min(adjustedWeight, element.maxWeight); 
            weightSum += weightedMax;
            if (randomValue <= weightSum)
            {
                return element.gameObject;
            }
        }

        // Si algo salió mal, devuelve null
        return null;
    }
}
