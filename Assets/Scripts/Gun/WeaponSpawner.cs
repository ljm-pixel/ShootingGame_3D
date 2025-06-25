using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public List<GameObject> weaponPrefabs;
    public List<GameObject> weapons;
    public Transform weaponPos;
    private int gunNum = 0;

    private static WeaponSpawner instance;
    public static WeaponSpawner Instance => instance;
    void Awake()
    {
        instance = this;
        weapons = new List<GameObject>();
        //print(weapons.Count);
        SpawnWeaponPrefabs(0);
        //print(weapons.Count);
        SpawnWeaponPrefabs(0);
        //print(weapons.Count);
    }

    public void SpawnWeaponPrefabs(int index)
    {
        if (weaponPrefabs.Count == 0)
            return;
        GameObject weaponObj = ObjectPool.Instance.GetObject(weaponPrefabs[index]);
        weaponObj.transform.SetParent(weaponPos, false);
        weapons.Add(weaponObj);
        weaponPrefabs.RemoveAt(index);
        weaponObj.SetActive(false);
    }
    public string GetWeaponHint(int index)
    {
        return weaponPrefabs[index].GetComponent<Gun>().HintText();
    }

    // Start is called before the first frame update
    void Start()
    {
        //weapons = new List<GameObject>();
        //SpawnWeaponPrefabs(0);
        //SpawnWeaponPrefabs(1);
    }

    // Update is called once per frame
    void Update()
    {
        SwitchGun();
    }

    void SwitchGun()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            weapons[gunNum].SetActive(false);
            if (++gunNum > weapons.Count - 1)
            {
                gunNum = 0;
            }
            weapons[gunNum].SetActive(true);
        }
    }
}
