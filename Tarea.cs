namespace Tarea {

    public class tarea {

        private int tareaid;
        private string? descripcion;
        private int duracion; // 10 - 100

        public int Tareaid { get => tareaid; set => tareaid = value; }
        public string? Descripcion { get => descripcion; set => descripcion = value; }
        public int Duracion { get => duracion; set => duracion = value; }

        public void mostrarTarea (){

            Console.Write($"\n\nTarea: {tareaid}");
            Console.Write($"\nDescipción: '{descripcion}'");
            Console.Write($"\nDuración: {duracion}");
        }
    }

}

