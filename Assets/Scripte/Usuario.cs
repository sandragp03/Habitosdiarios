using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class Habito
{
    public string nombre;
    public bool completado;
}

[Serializable]
public class Usuario
{
    public string nombre;
    public string apellido;
    public string email;
    public string contraseña;
    public List<Habito> habitos = new List<Habito>();
}
