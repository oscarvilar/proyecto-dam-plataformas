using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SistemaGuardado
{
    static string ruta = Application.persistentDataPath + "/player.datos";

    public static void guardar(GameMaster gm)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        

        FileStream stream = new FileStream(ruta, FileMode.Create);
        Debug.Log("ruta: " + ruta);
        Datos dato = new Datos(gm);
        formatter.Serialize(stream, dato);
        stream.Close();
        Debug.Log("guardado");
    }

    public static Datos cargar()
    {
        if (File.Exists(ruta))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(ruta, FileMode.Open);

            Datos dato = formatter.Deserialize(stream) as Datos;
            stream.Close();

            return dato;
        }
        else
        {
            Debug.LogError("fichero no encontrado en" + ruta);
            return null;
        }
    }
}
