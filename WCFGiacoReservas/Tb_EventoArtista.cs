//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFGiacoReservas
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tb_EventoArtista
    {
        public int evento_id { get; set; }
        public int artista_id { get; set; }
        public int duracion_show { get; set; }
    
        public virtual Tb_Artista Tb_Artista { get; set; }
        public virtual Tb_Evento Tb_Evento { get; set; }
    }
}
