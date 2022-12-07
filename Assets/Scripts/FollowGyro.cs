using UnityEngine;

public class FollowGyro : MonoBehaviour
{
    // **tentative pour gérer la vitesse de rotation, pas reussie
    //public float vitesseRotation;

    // Assigner une rotation de base permet de positionner comme il faut le terrain au lancement du jeu
    [Header("Tweaks")]
    [SerializeField] private Quaternion baseRotation = new Quaternion(0, 0, 1, 0);

    private Quaternion quaterIni;
    private float temps;
    public float angleMax = 30.0f;

    private void Start()
    {
        GyroManager.Instance.EnableGyro();
        temps = 0;
    }

    public Quaternion Calibrage()
    {
        return quaterIni;
    }

    private void Update()
    {
        // Calibrage du téléphone, pas très propre mais ça fonctionne pour l'instant
        if (temps < 3)

        {
            print("Calibrating...");
        }
        while (temps < 3)
        {
            temps += Time.deltaTime;
            quaterIni.x = -GyroManager.Instance.GetGyroRotation().x;
            quaterIni.y = -GyroManager.Instance.GetGyroRotation().z;
            quaterIni.z = -GyroManager.Instance.GetGyroRotation().y;
            quaterIni.w = GyroManager.Instance.GetGyroRotation().w;
            print(quaterIni);
        }

        // On reattribue les rotations pour qu'elles correspondent au bon angle avec le telephone à plat
        Quaternion quater;
        quater.x = -GyroManager.Instance.GetGyroRotation().x;
        quater.y = -GyroManager.Instance.GetGyroRotation().z;
        quater.z = -GyroManager.Instance.GetGyroRotation().y;
        quater.w = GyroManager.Instance.GetGyroRotation().w;

        //quater.eulerAngles = quater.eulerAngles - quaterIni.eulerAngles;
        //print("quater");
        //print(quater);


        Vector3 nouv = new Vector3(quater.eulerAngles.x, 0.0f, quater.eulerAngles.z);
        //print(nouv);
        if (quater.eulerAngles.x > angleMax && quater.eulerAngles.x <= 180.0f)
        {
            nouv.x = angleMax;
        }
        if (quater.eulerAngles.x < 360.0f - angleMax && quater.eulerAngles.x >= 180.0f)
        {
            nouv.x = 360.0f - angleMax;
        }
        if (quater.eulerAngles.z > angleMax && quater.eulerAngles.z <= 180.0f)
        {
            nouv.z = angleMax;
        }
        if (quater.eulerAngles.z < 360.0f - angleMax && quater.eulerAngles.z >= 180.0f)
        {
            nouv.z = 360.0f - angleMax;
        }




        //quater.eulerAngles = quater.eulerAngles * vitesseRotation;



        transform.localRotation = Quaternion.Euler(nouv);
    }
}
