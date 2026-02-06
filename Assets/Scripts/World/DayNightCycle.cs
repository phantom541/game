using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light sun;
    public float dayLengthInMinutes = 5f;

    private float timeOfDay;

    void Update()
    {
        timeOfDay += Time.deltaTime / (dayLengthInMinutes * 60f);
        timeOfDay %= 1;

        float sunAngle = timeOfDay * 360f - 90f;
        sun.transform.rotation = Quaternion.Euler(sunAngle, 170f, 0f);
    }

    public bool IsNight()
    {
        return timeOfDay < 0.25f || timeOfDay > 0.75f;
    }
}
