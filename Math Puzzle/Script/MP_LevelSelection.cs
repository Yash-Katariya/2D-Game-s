using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MP_LevelSelection : MonoBehaviour
{
    public GameObject ButtonPrefab;
    public Transform ButtonTfrom;

    public void OnEnable()
    {
        int AllChild = ButtonTfrom.childCount;
        for (int i = 0; i < AllChild; i++)
        {
            Destroy(ButtonTfrom.GetChild(i).gameObject);
        }

        int lastLevel = PlayerPrefs.GetInt("lastLevel", 0);   // Get karay Vu

        for (int i = 0; i < 28; i++)
        {
            GameObject G = Instantiate(ButtonPrefab, ButtonTfrom);
            TMP_Text Text = G.GetComponentInChildren<TMP_Text>();
            Button B = G.GetComponent<Button>();
            Image _tick = G.transform.GetChild(1).GetComponent<Image>();
            Image _lock = G.transform.GetChild(2).GetComponent<Image>();

            string state = PlayerPrefs.GetString("" + i, "lock");
            print(i + " -> " + state);

            if (state == "clear")
            {
                _tick.gameObject.SetActive(true);
                Text.text = (i + 1).ToString();
            }
            else if (state == "skip" || lastLevel == i)
            {
                Text.text = (i + 1).ToString();
            }
            else
            {
                _lock.gameObject.SetActive(true);
                B.interactable = false;
            }

            int finalI = i;
            B.onClick.AddListener(() =>
            {
                LevelManage.Instance.moveToPlaying(finalI);
            });
        }
    }
}
/*
    clear
    skip
    lock
 */