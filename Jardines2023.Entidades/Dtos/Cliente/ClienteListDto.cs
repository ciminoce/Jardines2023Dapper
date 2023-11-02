﻿using System;

namespace Jardines2023.Entidades.Dtos.Cliente
{
    public class ClienteListDto : ICloneable
    {
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string NombrePais { get; set; }
        public string NombreCiudad { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
