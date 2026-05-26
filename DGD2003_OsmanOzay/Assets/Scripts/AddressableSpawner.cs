using UnityEngine;
using UnityEngine.AddressableAssets;

public class AddressableSpawner : MonoBehaviour
{
    public string effectAddress = "VictoryEffect";

    public void SpawnEffect()
    {
        Addressables.InstantiateAsync(effectAddress, transform.position, Quaternion.identity);
    }
}