using Tarea;

List<tarea> tareasPendientes = new List<tarea>(); 
List<tarea> tareasRealizadas = new List<tarea>();

int n = new Random().Next(1,5); 

Console.Write($"\n►►Se cargaran {n} tareas◄◄");
crearTarea(n, tareasPendientes);

Console.Write("\n\nEstas son las tareas cargadas: ");
mostrarListaDeTareas(tareasPendientes); 

Console.Write("\n\n►►Control de tareas◄◄");
Console.ReadKey();

moverTarea(tareasPendientes, tareasRealizadas);

Console.Write("\n\n►►Buscar una tarea pendiente◄◄");

int respuesta;

do{

    tarea tareaBuscada = new tarea();
     tareaBuscada = buscarTareaPorDescripcion(tareasPendientes);

    if (string.IsNullOrEmpty(tareaBuscada.Descripcion)){
        Console.Write("\nNo se encontro ninguna tarea con la descipcion ingresada");
    }
    else{
        Console.Write("\nSe encontro una coincidencia");
        Console.ReadKey();
        tareaBuscada.mostrarTarea();
    }

    Console.Write("\n\nDesea realizar otra busqueda?\n1-SI\n2-NO\n>> ");

    while(!int.TryParse(Console.ReadLine(), out respuesta) || respuesta < 1 || respuesta > 2){
        Console.Write("\nDebe ingresar una opción valida\n>> ");
    }

}while(respuesta != 2);

sumaDeHorasTrabajadas(tareasRealizadas);

/****Funciones****/

void crearTarea (int numtareas, List<tarea> T) {

    for(int i = 0; i < numtareas; i++){

        tarea nuevaTarea = new tarea();
                
        Console.Write($"\n\n----Tarea N° {i+1}----");

        nuevaTarea.Tareaid = i+1;
        
        Console.Write("\nIngrese una descripción de la tarea: ");

        while(string.IsNullOrEmpty(nuevaTarea.Descripcion = Console.ReadLine())){

            Console.Write("\nError, ingrese una descripción valida:");

        }

        nuevaTarea.Duracion = new Random().Next(10,101);

        T.Add(nuevaTarea);

    }
}

void mostrarListaDeTareas(List<tarea> T){

    if( T == null){
        Console.Write("\nLa lista no contiene tareas");
    }
    else{

        foreach(var t in T){
            t.mostrarTarea();
        }
    }
}

void moverTarea(List<tarea> origen, List<tarea> destino){

    char respuesta;
    foreach(var t in origen){

        t.mostrarTarea();
        Console.Write("\nRealizo esta tarea?\n[S] Si\n[N] No\n>> ");

        respuesta = Console.ReadKey().KeyChar;
        Console.ReadKey();

        while(char.ToLower(respuesta) != 's' && char.ToLower(respuesta) != 'n'){

            Console.Write("\nDebe ingresar una opción valida\n>> ");
            respuesta = Console.ReadKey().KeyChar;
            Console.ReadKey();
            
        }

        if(char.ToLower(respuesta) == 's'){

            destino.Add(t);

        }

    }

    foreach(var remover in destino){ 
        origen.Remove(remover);
    }
    
}

tarea buscarTareaPorDescripcion (List<tarea> T){

    string? tex;
    tarea encontrado = new tarea();

    Console.Write("\nIngrese la descripcion de la tarea que desea buscar: ");

    while(string.IsNullOrEmpty(tex = Console.ReadLine())){
        Console.Write("\nError, ingrese una descripcion: ");
    }

    foreach(var t in T){

        if(tex == t.Descripcion){
            encontrado = t;
        }
    }
    
    return encontrado;

}

void sumaDeHorasTrabajadas (List<tarea> T){

    int horas = 0;

    foreach (var t in T){

        horas += t.Duracion;

    }

    var archivo = new StreamWriter("HrsTrabajadas.txt");
    archivo.WriteLine($"El empleado trabajo un total de {horas} hs");
    archivo.Close();

}