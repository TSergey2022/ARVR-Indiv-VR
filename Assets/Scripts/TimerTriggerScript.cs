using System.Collections;
using UnityEngine;

public class TimerTriggerScript : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(Toggle(other.gameObject));
    }

    private static IEnumerator Toggle(GameObject triggerZone)
    {
        TimerScript.Instance.Toggle();
        triggerZone.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        triggerZone.SetActive(true);
    }
}
