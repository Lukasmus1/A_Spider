using UnityEngine;

public class Spawner : MonoBehaviour
{
    // ReSharper disable Unity.PerformanceAnalysis
    //This is called very few times, so it's not a performance issue
    public static void SpawnEnemy(float minX, float maxX, float minY, float maxY, GameObject player, GameObject enemyPrefab, GameObject arrowPrefab)
    {
        Vector2 randomPosition = Utilities.Instance.GetRandomVector2(minX, maxX, minY, maxY);
        if (randomPosition.x < player.transform.position.x + 10 && randomPosition.x > player.transform.position.x - 10)
        {
            //If the random position is too close to the player, move it to the right or left
            MoveFromPlayer(ref randomPosition.x);
        }
        
        if (randomPosition.y < player.transform.position.y + 10 && randomPosition.y > player.transform.position.y - 10)
        {
            //If the random position is too close to the player, move it up or down
            MoveFromPlayer(ref randomPosition.y);
        }
        
        randomPosition = CheckDistanceFromMax(randomPosition, minX, maxX, minY, maxY);
        
        GameObject enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        ArrowScript arrowScript = Instantiate(arrowPrefab, player.transform).GetComponent<ArrowScript>();
        arrowScript.SetVariables(enemy);
    }

    private static void MoveFromPlayer(ref float pos)
    {
        if (Random.Range(0, 2) == 0)
        {
            pos += 10;
        }
        else
        {
            pos -= 10;
        }
    }
    
    private static Vector2 CheckDistanceFromMax(Vector2 pos, float minX, float maxX, float minY, float maxY)
    {
        if (pos.x > maxX)
        {
            pos.x = maxX - 2;
        }
        else if (pos.x < minX)
        {
            pos.x = minX + 2;
        }
        
        if (pos.y > maxY)
        {
            pos.y = maxY - 2;
        }
        else if (pos.y < minY)
        {
            pos.y = minY + 2;
        }
        
        return pos;
    }
}
