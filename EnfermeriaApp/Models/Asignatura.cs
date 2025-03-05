namespace EnfermeriaApp.Models
{
    public class Asignatura
    {
        public string CodAsignatura { get; set; }
        public string AsignaturaNombre { get; set; }
        public decimal ECTS { get; set; }
        public int? Horas { get; set; }
        public string Programa { get; set; }
    }
}
