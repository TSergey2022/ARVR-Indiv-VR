using System.Collections.Generic;
using UnityEngine;

public class ObjectShufflerScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToShuffle; // Список объектов для перемешивания

    private List<Vector3> originalPositions = new (); // Сохраняем изначальные позиции

    private void Start()
    {
        // Сохраняем изначальные позиции объектов
        foreach (var obj in objectsToShuffle)
        {
            originalPositions.Add(obj.transform.position);
        }

        // Перемешиваем позиции
        ShufflePositions();

        // Случайно поворачиваем объекты
        RandomizeRotations();
        
        foreach (var obj in objectsToShuffle)
        {
            obj.SetActive(true);
        }
    }

    private void ShufflePositions()
    {
        // Перемешиваем список изначальных позиций
        var shuffledPositions = new List<Vector3>(originalPositions);
        var n = shuffledPositions.Count;
        while (n > 1)
        {
            n--;
            var k = Random.Range(0, n + 1);
            (shuffledPositions[k], shuffledPositions[n]) = (shuffledPositions[n], shuffledPositions[k]);
        }

        // Применяем перемешанные позиции к объектам
        for (var i = 0; i < objectsToShuffle.Count; i++)
        {
            objectsToShuffle[i].transform.position = shuffledPositions[i];
        }
    }

    private void RandomizeRotations()
    {
        // Возможные углы поворота по оси Y
        int[] possibleYRotations = { -90, 0, 90, 180 };

        foreach (var obj in objectsToShuffle)
        {
            // Выбираем случайный угол из массива
            var randomYRotation = possibleYRotations[Random.Range(0, possibleYRotations.Length)];

            // Применяем поворот
            obj.transform.rotation = Quaternion.Euler(0, randomYRotation, 0);
        }
    }
}
