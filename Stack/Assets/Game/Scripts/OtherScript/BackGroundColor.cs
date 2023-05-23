using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class BackGroundColor : MonoBehaviour
{
    [SerializeField] private Image bg;
    [SerializeField] private Color[] colors;
    [SerializeField] private float colorChangeSpeed;
    [SerializeField] private float time;
    private float currentTime;
    private int colorIndex;

    private void Update()
    {
        ColorChange();
        ColorChangeTime();
    }
    private void ColorChange()
    {
        bg.color = Color.Lerp(bg.color, colors[colorIndex],colorChangeSpeed * Time.deltaTime);
    }

    private void ColorChangeTime()
    {
        if(currentTime < 0)
        {
            colorIndex++;
            CheckColorIndex();
            currentTime = time;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }

    private void CheckColorIndex()
    {
        if(colorIndex >= colors.Length)
        {
            colorIndex = 0;
        }
    }
    private void OnDestroy()
    {
        bg.color = colors[colorIndex];
    }
}
