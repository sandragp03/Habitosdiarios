using System.IO;
using UnityEngine;

public static class GestorDatos
{
    private static string rutaArchivo = Application.persistentDataPath + "/usuario.json";

    public static void GuardarUsuario(Usuario usuario)
    {
        string json = JsonUtility.ToJson(usuario, true);
        File.WriteAllText(rutaArchivo, json);
        Debug.Log("Datos guardados en: " + rutaArchivo);
    }

    public static Usuario CargarUsuario()
    {
        if (File.Exists(rutaArchivo))
        {
            string json = File.ReadAllText(rutaArchivo);
            return JsonUtility.FromJson<Usuario>(json);
        }
        else
        {
            Debug.LogWarning("No hay archivo de usuario.");
            return null;
        }
    }
}
