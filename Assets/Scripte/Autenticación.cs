using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Autenticación : MonoBehaviour
{
//Login
    public TMP_InputField campoEmail;
    public TMP_InputField campoContraseña;
    public GameObject mensajeError;
    public GameObject panelHabitos;     // Nuevo panel que se activa tras login
    public GameObject panelLogin;       // Panel de fondo (login) que se ocultará

    //Registro
    public GameObject panelRegistro;
    public TMP_InputField campoRegistroNombre;
    public TMP_InputField campoRegistroApellido;
    public TMP_InputField campoRegistroEmail;
    public TMP_InputField campoRegistroContraseña;


     public void IniciarSesion()
    {
        string emailGuardado = PlayerPrefs.GetString("email", "");
        string passGuardado = PlayerPrefs.GetString("password", "");

        if (campoEmail.text == emailGuardado && campoContraseña.text == passGuardado)
        {
            Debug.Log("Inicio de sesión correcto");
            mensajeError.SetActive(false);
            panelHabitos.SetActive(true);
            panelLogin.SetActive(false);
        }
        else
        {
            mensajeError.SetActive(true);
        }
    }
//Confirmar nuevo registro
    public void ConfirmarRegistro()
    {
        PlayerPrefs.SetString("nombre", campoRegistroNombre.text);
        PlayerPrefs.SetString("apellido", campoRegistroApellido.text);
        PlayerPrefs.SetString("email", campoRegistroEmail.text);
        PlayerPrefs.SetString("password", campoRegistroContraseña.text);
        PlayerPrefs.Save();

        Debug.Log("Registro exitoso");
        panelRegistro.SetActive(false);
        panelLogin.SetActive(true);
    }

    // Navegación entre paneles
    public void IrARegistro()
    {
        panelLogin.SetActive(false);
        panelRegistro.SetActive(true);
    }

    public void VolverAlLogin()
    {
        panelRegistro.SetActive(false);
        panelLogin.SetActive(true);
    }
}