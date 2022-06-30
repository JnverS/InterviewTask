using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Sprite))]
public class Slot : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] public int value;
    private Image image;
    private static readonly System.Random Random = new System.Random();

    private void Start()
    {
        image = GetComponent<Image>();
        value = Random.Next(sprites.Length);
        RefreshSprite();
    }

    public void RefreshSprite()
    {
        if (value >= sprites.Length)
        {
            Debug.LogError($"Slot: trying to getting index {value} but length is {sprites.Length} ");
            return;
        }

        image.sprite = sprites[value];
    }
}