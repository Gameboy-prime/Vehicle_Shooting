using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    #region Singleton
    public static CarManager instance;
    private void Awake()
    {
        instance=this;
    }

    public GameObject car;
    #endregion
}
