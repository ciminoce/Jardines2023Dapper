﻿using Jardines2023.Entidades.Entidades;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jardines2023.Windows.Helpers
{
    public static class FormHelper
    {

        public static int CalcularPaginas(int registros, int registrosPorPagina)
        {
            if (registros < registrosPorPagina)
            {
                return 1;
            }
            else if (registros % registrosPorPagina == 0)
            {
                return registros / registrosPorPagina;
            }
            else
            {
                return registros / registrosPorPagina + 1;
            }
        }

    }
}
