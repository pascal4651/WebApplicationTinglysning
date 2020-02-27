using System.Xml.Serialization;

namespace WebApplicationTinglysning.Models
{

	[XmlRoot(ElementName = "BilIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class BilIdentifikator
	{
		[XmlElement(ElementName = "Stelnummer", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string Stelnummer { get; set; }
	}

	[XmlRoot(ElementName = "BilMaerke", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class BilMaerke
	{
		[XmlElement(ElementName = "BilFabrikatTekst", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string BilFabrikatTekst { get; set; }
		[XmlElement(ElementName = "BilModelTekst", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string BilModelTekst { get; set; }
		[XmlElement(ElementName = "BilVariantTekst", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string BilVariantTekst { get; set; }
	}

	[XmlRoot(ElementName = "BilStruktur", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class BilStruktur
	{
		[XmlElement(ElementName = "BilMaerke", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public BilMaerke BilMaerke { get; set; }
		[XmlElement(ElementName = "RegistreringsnummerTekst", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string RegistreringsnummerTekst { get; set; }
		[XmlElement(ElementName = "FoersteRegistreringsAar", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string FoersteRegistreringsAar { get; set; }
	}

	[XmlRoot(ElementName = "BilStamoplysninger", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
	public class BilStamoplysninger
	{
		[XmlElement(ElementName = "BilIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public BilIdentifikator BilIdentifikator { get; set; }
		[XmlElement(ElementName = "BilStruktur", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public BilStruktur BilStruktur { get; set; }
	}

	[XmlRoot(ElementName = "BilSummarisk", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
	public class BilSummarisk
	{
		[XmlElement(ElementName = "BilStamoplysninger", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public BilStamoplysninger BilStamoplysninger { get; set; }
		[XmlElement(ElementName = "ModelId", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string ModelId { get; set; }
	}

	/*
	[XmlRoot(ElementName = "CanonicalizationMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
	public class CanonicalizationMethod
	{
		[XmlAttribute(AttributeName = "Algorithm")]
		public string Algorithm { get; set; }
	}

	[XmlRoot(ElementName = "SignatureMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
	public class SignatureMethod
	{
		[XmlAttribute(AttributeName = "Algorithm")]
		public string Algorithm { get; set; }
	}

	[XmlRoot(ElementName = "DigestMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
	public class DigestMethod
	{
		[XmlAttribute(AttributeName = "Algorithm")]
		public string Algorithm { get; set; }
	}

	[XmlRoot(ElementName = "Reference", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
	public class Reference
	{
		[XmlElement(ElementName = "DigestMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
		public DigestMethod DigestMethod { get; set; }
		[XmlElement(ElementName = "DigestValue", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
		public string DigestValue { get; set; }
	}

	[XmlRoot(ElementName = "SignedInfo", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
	public class SignedInfo
	{
		[XmlElement(ElementName = "CanonicalizationMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
		public CanonicalizationMethod CanonicalizationMethod { get; set; }
		[XmlElement(ElementName = "SignatureMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
		public SignatureMethod SignatureMethod { get; set; }
		[XmlElement(ElementName = "Reference", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
		public Reference Reference { get; set; }
	}

	[XmlRoot(ElementName = "Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
	public class Signature
	{
		[XmlElement(ElementName = "SignedInfo", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
		public SignedInfo SignedInfo { get; set; }
		[XmlElement(ElementName = "SignatureValue", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
		public string SignatureValue { get; set; }
	}*/

	[XmlRoot(ElementName = "BilSummariskHentResultat", Namespace = "http://rep.oio.dk/tinglysning.dk/service/message/elektroniskakt/1/")]
	public class BilSummariskHentResultat
	{
		[XmlElement(ElementName = "BilSummarisk", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public BilSummarisk BilSummarisk { get; set; }
		[XmlElement(ElementName = "UdskriftDatoTid", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public string UdskriftDatoTid { get; set; }
		[XmlElement(ElementName = "AnmeldelseModtagetIndikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public string AnmeldelseModtagetIndikator { get; set; }
		[XmlElement(ElementName = "Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
		public Signature Signature { get; set; }
		[XmlAttribute(AttributeName = "xmlns")]
		public string Xmlns { get; set; }
		[XmlAttribute(AttributeName = "ns", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Ns { get; set; }
		[XmlAttribute(AttributeName = "ns1", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Ns1 { get; set; }
		[XmlAttribute(AttributeName = "xd", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Xd { get; set; }
	}

}
