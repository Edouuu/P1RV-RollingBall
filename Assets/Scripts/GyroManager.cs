using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroManager : MonoBehaviour
{
    // Permet de creer une instance de GyroManager s'il n'en existe pas
    // Ou de recuperer une instance qui existerait deja
    #region Instance
    private static GyroManager instance;
    public static GyroManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GyroManager>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned GyroManager", typeof(GyroManager)).GetComponent<GyroManager>();
                }
            }

            return instance;
        }
        set
        {
            instance = value;
        }
    }
    #endregion

    // 	Add a header above some fields in the Inspector.
    [Header("Logic")]
    private Gyroscope gyro;
    private Quaternion rotation;
    private bool gyroActive;

    // Permet de verifier si le telephone possede un gyroscope
    public void EnableGyro() 
    {
        // Deja activé
        if (gyroActive)
        {
            return;
        }

        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            gyroActive = gyro.enabled;
        }
        else
        {
            Debug.Log("Gyro is not supported on this device");
        }
    }

    // On ne recupere les informations de rotation que si le tel possede un gyroscope
    private void Update()
    {
        if (gyroActive)
        {
            rotation = gyro.attitude;
        }
    }

    // Fonction public pour acceder à rotation (Update est en private)
    public Quaternion GetGyroRotation()
    { 
        return rotation;
    }
}
