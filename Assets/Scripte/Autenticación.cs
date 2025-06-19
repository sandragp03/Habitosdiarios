using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Autenticación : MonoBehaviour
{
    public TMP_InputField campoEmail;
    public TMP_InputField campoContraseña;
    public GameObject mensajeError;

     public void IniciarSesion()
    {
        string emailGuardado = PlayerPrefs.GetString("email", "");
        string passGuardado = PlayerPrefs.GetString("password", "");

        if (campoEmail.text == emailGuardado && campoContraseña.text == passGuardado)
        {
            Debug.Log("Inicio de sesión correcto");
            mensajeError.SetActive(false);
        }
        else
        {
            mensajeError.SetActive(true);
        }
    }

    public void Registrarse()
    {
        PlayerPrefs.SetString("email", campoEmail.text);
        PlayerPrefs.SetString("password", campoContraseña.text);
        PlayerPrefs.Save();

        Debug.Log("Registro completado");
        mensajeError.SetActive(false);
        // Aquí también puedes redirigir a pantalla principal
    }
}