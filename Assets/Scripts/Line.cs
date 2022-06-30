using System.Collections;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private GameObject startPoint;
    [SerializeField] private GameObject endPoint;
    [SerializeField] public Slot[] slots;
    [SerializeField] private GameObject slotPrefab;
    private Vector3[] defaultPositions;
    private bool isPlay;
    private float speed;

    public float Speed
    {
        set => speed = value;
    }

    private void Start()
    {
        defaultPositions = new Vector3[slots.Length];
        for (int i = 0; i < slots.Length; i++)
        {
            defaultPositions[i] = slots[i].transform.position;
        }
    }

    private bool IsNeedToDestroy(GameObject slot)
    {
        return slot.transform.position.x > endPoint.transform.position.x;
    }

    private void DestroySlot(GameObject slot)
    {
        for (var i = slots.Length - 1; i >= 1; i--)
        {
            slots[i] = slots[i - 1];
        }

        Destroy(slot);
    }

    private void SpawnSlot(Vector3 position)
    {
        var slot = Instantiate(slotPrefab, transform);
        slot.transform.position = position;
        var slotScript = slot.GetComponent<Slot>();
        slots[0] = slotScript;
        StartCoroutine(SpinSlots(slot));
    }

    public void Spin()
    {
        isPlay = true;
        for (int i = 0; i < slots.Length; i++)
        {
            StartCoroutine(SpinSlots(slots[i].gameObject));
        }
    }

    public void Stop()
    {
        isPlay = false;
    }


    private IEnumerator SpinSlots(GameObject slotGameObject)
    {
        while (isPlay)
        {
            slotGameObject.transform.position += new Vector3(speed, 0f, 0f);
            if (IsNeedToDestroy(slotGameObject))
            {
                DestroySlot(slotGameObject);
                SpawnSlot(startPoint.transform.position);
                yield break;
            }

            yield return null;
        }
    }

    public void FixPosition()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].transform.position = defaultPositions[i];
        }
    }
}