using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalCambApi.Aplication.Adapter
{
    public class ResponseModel<T> where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        public ResponseModel()
        {
            IsValid = true;
        }

        /// <summary>
        /// Indicador de generacion (1 = Correcto, 0 = Error)
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Entidad de Auditoria
        /// </summary>
        public AuditResponse auditResponse { get; set; }

        /// <summary>
        /// Entidad
        /// </summary>
        public T Entity { get; set; }

        /// <summary>
        /// List - Entity
        /// </summary>
        public IEnumerable<T> EntityList { get; set; }
    }
}
