using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Datos{

    public string nivel;

        public Datos(GameMaster gm)
        {
            nivel = gm.nivel;
        }
}
