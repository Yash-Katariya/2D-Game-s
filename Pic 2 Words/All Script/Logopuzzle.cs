using UnityEngine;
using UnityEngine.UI;

public class Logopuzzle : MonoBehaviour
{
    public GameObject ButtonPrefab;
    public LevelManager levelManager;
    public Transform LogoParent;

    public void OnEnable()
    {
        int allchild = LogoParent.childCount;
        for (int i = 0; i < allchild; i++)
        {
            Destroy(LogoParent.GetChild(i).gameObject);
        }

        Sprite[] Levelimage = levelManager.LevelImage;

        for (int i = 0; i < Levelimage.Length; i++)
        {
            GameObject clone = Instantiate(ButtonPrefab, transform);
            Image image = clone.transform.GetChild(0).GetComponent<Image>();
            Image Tickimage = clone.transform.GetChild(1).GetComponent<Image>();

            print($"{i} -> {PlayerPrefs.GetInt("" + i)}");

            bool LevelCompleted = PlayerPrefs.GetInt("" + i) == 1;

            Tickimage.gameObject.SetActive(LevelCompleted);

            image.sprite = Levelimage[i];
            Button b = clone.GetComponent<Button>();
            int Finalanswer = i;
            b.onClick.AddListener(() =>
            {
                LevelManager.Instance.CurrentLevel = Finalanswer;
                LevelManager.Instance.Backtoplay();
            });
        }
    }
}