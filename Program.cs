﻿Console.WriteLine("Ingrese una ruta:"); 
string? ruta = Console.ReadLine(); 

if (Path.IsPathRooted(ruta) && Directory.Exists(ruta)) // Verifica si la ruta ingresada es válida y existe 
{
    string[] archivos = Directory.GetFiles(ruta); // Obtiene una lista de archivos de la ruta 

    Console.WriteLine("Listado de archivos:"); 
    foreach (string archivo in archivos)
    {
        Console.WriteLine(archivo); 
    }

    StreamWriter index = new StreamWriter("index.csv"); // Crea un archivo llamado 'index.csv' y lo asocia con un objeto StreamWriter llamado 'index'
    
        for (int i = 0; i < archivos.Length; i++) 
        {
            string[] campos = archivos[i].Split(@"\").Last().Split("."); // Divide el nombre de archivo en partes 
            index.WriteLine($"{i + 1}, {campos[0]}, {campos[1]}"); 
        }
        index.Close();
}
else
{
    Console.WriteLine("La ruta ingresada no es válida o no existe");
}