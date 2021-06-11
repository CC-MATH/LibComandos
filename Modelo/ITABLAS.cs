using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Libreria
{
    public interface ITABLAS
    {
        DataSet dsGrid();

        DataTable dtDDL();

      
    }
}
