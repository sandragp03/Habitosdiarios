using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Autenticación : MonoBehaviour
{

    // Paneles
    public GameObject panelLogin;
    public GameObject panelRegistro;
    public GameObject panelHabitos;
///  Login
    public TMP_InputField campoEmail;
    public TMP_InputField campoContraseña;
    public GameObject mensajeError;


    //  Registro
    public TMP_InputField campoRegistroNombre;
    public TMP_InputField campoRegistroApellido;
    public TMP_InputField campoRegistroEmail;
    public TMP_InputField campoRegistroContraseña;


     public void IniciarSesion()
    {
         Usuario usuarioGuardado = GestorDatos.CargarUsuario();

        if (usuarioGuardado != null &&
            campoEmail.text == usuarioGuardado.email &&
            campoContraseña.text == usuarioGuardado.contraseña)
        {
            Debug.Log("Login correcto: " + usuarioGuardado.nombre);
            mensajeError.SetActive(false);
            panelLogin.SetActive(false);
            panelHabitos.SetActive(true);
        }
        else
        {
            mensajeError.SetActive(true);
        }
    }
//Confirmar nuevo registro
    public void ConfirmarRegistro()
    {
        Usuario nuevoUsuario = new Usuario();
        nuevoUsuario.nombre = campoRegistroNombre.text;
        nuevoUsuario.apellido = campoRegistroApellido.text;
        nuevoUsuario.email = campoRegistroEmail.text;
        nuevoUsuario.contraseña = campoRegistroContraseña.text;

        // Ejemplo: hábitos por defecto
        nuevoUsuario.habitos.Add(new Habito { nombre = "Beber agua", completado = false });
        nuevoUsuario.habitos.Add(new Habito { nombre = "Leer 10 minutos", completado = false });

        GestorDatos.GuardarUsuario(nuevoUsuario);

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