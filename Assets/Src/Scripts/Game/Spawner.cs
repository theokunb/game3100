using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const int AllSpace = 100;
    private const int PlayerSpawn = 5;
    private const int StartFreeSpace = 30;
    private const int EndFreeSpace = 10;

    public void CreateEnemyPacks(Pack[] packs, Rectangle platform)
    {
        float startPoint = platform.Lenght * StartFreeSpace / AllSpace;
        float endPoint = platform.Lenght * (AllSpace - EndFreeSpace) / AllSpace;
        var spaceBetweenPacks = (endPoint - startPoint) / packs.Length;

        for (int i = 0; i < packs.Length; i++)
        {
            packs[i].Create(startPoint + spaceBetweenPacks * i, platform.Width);
        }
    }

    public void PutToStartPosition(Player player, Rectangle platform)
    {
        var position = new Vector3(platform.Width / 2, 1, platform.Lenght * PlayerSpawn / AllSpace);
        player.transform.position = position;
    }
}
