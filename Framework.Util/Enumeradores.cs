using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Util
{
    public enum ValidationTypes
    {
        /// <summary>
        /// Positive Decimal Number
        /// </summary>
        PositiveDecimal,
        /// <summary>
        /// Number
        /// </summary>
        Numeric,
        /// <summary>
        /// Decimal Number (+ or -)
        /// </summary>
        Decimal,
        /// <summary>
        /// Dates(DD/MM/YYYY)
        /// </summary>
        DatesDDMMYYYY,
        /// <summary>
        /// Dates(DD/MM/YY)
        /// </summary>
        DatesDDMMYY,
        /// <summary>
        /// Dates(DD MMM YYYY)
        /// </summary>
        DatesDD_MMM_YYYY,
        Email,
        IPAddress,
        URL,
        /// <summary>
        /// Ex.: 00000-000
        /// </summary>
        CEP,
        CNPJ,
        CPF,
        StringNullEspacoEmBranco
    }
}
