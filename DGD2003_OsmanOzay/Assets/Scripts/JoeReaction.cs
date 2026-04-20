using UnityEngine;

public class JoeReaction : MonoBehaviour
{
    public void ShrinkInFear()
    {
        Debug.Log("Sauron saw Joe! Joe is shrinking!");
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}