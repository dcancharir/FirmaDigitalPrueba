using iTextSharp.text.pdf;
using iTextSharp.text.pdf.security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmarPfd.Clases
{
    public class Firmante
    {
        private readonly Certificado certificado;

        public Firmante(Certificado certificado)
        {
            this.certificado = certificado;
        }

        public void Firmar(string rutaDocumentoSinFirma, string rutaDocumentoFirmado)
        {
            using (var reader = new PdfReader(rutaDocumentoSinFirma))
            using (var writer = new FileStream(rutaDocumentoFirmado, FileMode.Create, FileAccess.Write))
            using (var stamper = PdfStamper.CreateSignature(reader, writer, '\0', null, true))
            {
                var signature = stamper.SignatureAppearance;
                signature.CertificationLevel = PdfSignatureAppearance.CERTIFIED_NO_CHANGES_ALLOWED;
                signature.Reason = "Firma del Boletas GDT";
                signature.ReasonCaption = "Tipo de firma: ";
                signature.Location = "Tacna - Peru";
                var signatureKey = new PrivateKeySignature(certificado.Key, DigestAlgorithms.SHA256);
                var signatureChain = certificado.Chain;
                var standard = CryptoStandard.CADES;

                MakeSignature.SignDetached(signature, signatureKey, signatureChain, null, null, null, 0, standard);
            }
        }
    }
}
