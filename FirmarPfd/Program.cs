using FirmarPfd.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmarPfd
{
    class Program
    {
        static void Main(string[] args)
        {
            var certificado = new Certificado(@"F:\demos\VidalTI.pfx", "VidalTI*");
            var firmante = new Firmante(certificado);
            firmante.Firmar(@"F:\demos\documento.pdf", @"F:\demos\documento-firmado.pdf");
            //var certificado = new Certificado(@"F:\demos\VidalTI.pfx", "VidalTI*");
            //var notario = new Notario(certificado);
            //var documentoValido = notario.CertificarDocumento(@"F:\demos\documento-firmado.pdf");

            //if (documentoValido)
            //    Console.WriteLine("Documento firmado por el sistema y no ha sufrido modificaciones");
            //else
            //    Console.WriteLine("El documento no se pudo validar");

            Console.ReadLine();
        }
    }
}
