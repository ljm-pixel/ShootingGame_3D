using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : BasePanel<LevelUI>
{
    public Button nextLevelButton;
    public Button quitButton;
    public Button[] buffButton;
    public Text[] buffText;
    public Image[] buffImage;
    public Sprite[] sprites;

    public override void Init()
    {
        nextLevelButton.onClick.AddListener(NextLevel);
        HideMe();
    }

    private void NextLevel()
    {
        GameUI.Instance.StartGame();
        HideMe();
    }
    private void OnEnable()
    {
        OpenMouse();

        if (PropSpawner.Instance == null || WeaponSpawner.Instance == null)
            return;
        int length = PropSpawner.Instance.PropPrefabs.Length + WeaponSpawner.Instance.weaponPrefabs.Count;
        int propLength = PropSpawner.Instance.PropPrefabs.Length;
        for (int i = 0; i < buffButton.Length; i++)
        {
            int index = Random.Range(0, length);
            //int index = Random.Range(0, PropSpawner.Instance.PropPrefabs.Length);
            //print(index);
            //print(PropSpawner.Instance.PropPrefabs.Length);
            //Debug.Log(WeaponSpawner.Instance.weaponPrefabs.Count);

            if(index >= PropSpawner.Instance.PropPrefabs.Length)
            {
                buffText[i].text = WeaponSpawner.Instance.GetWeaponHint(index - propLength);
                buffImage[i].sprite = sprites[index - propLength];
                buffButton[i].onClick.AddListener(() => {
                    WeaponSpawner.Instance.SpawnWeaponPrefabs(index - propLength);
                    NextLevel();
                });
            }
            else
            {
                if(index >= propLength)
                    index = propLength - 1;
                if (index < 0)
                    index = 0;
                buffText[i].text = PropSpawner.Instance.GetBuffHint(index);
                buffImage[i].sprite = sprites[index];
                buffButton[i].onClick.AddListener(() => {
                    PropSpawner.Instance.SelectBuff(index);
                    PropSpawner.Instance.Dic(index);
                    NextLevel();
                });
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
