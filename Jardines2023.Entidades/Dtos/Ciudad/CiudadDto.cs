using System;

namespace Jardines2023.Entidades.Dtos.Ciudad
{
    public class CiudadDto:ICloneable
    {
        public int CiudadId { get; set; }
        public string NombreCiudad { get; set; }
        public string NombrePais { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
