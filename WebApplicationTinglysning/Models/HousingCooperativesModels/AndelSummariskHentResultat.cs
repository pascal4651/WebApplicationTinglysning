﻿using System.Xml.Serialization;
using System.Collections.Generic;

namespace WebApplicationTinglysning.Models.HousingCooperativesModels
{
	[XmlRoot(ElementName = "AndelIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class AndelIdentifikator
	{
		[XmlElement(ElementName = "MunicipalityCode", Namespace = "http://rep.oio.dk/cpr.dk/xml/schemas/core/2005/03/18/")]
		public string MunicipalityCode { get; set; }
		[XmlElement(ElementName = "StreetCode", Namespace = "http://rep.oio.dk/cpr.dk/xml/schemas/core/2005/03/18/")]
		public string StreetCode { get; set; }
		[XmlElement(ElementName = "StreetBuildingIdentifier", Namespace = "http://rep.oio.dk/ebxml/xml/schemas/dkcc/2003/02/13/")]
		public string StreetBuildingIdentifier { get; set; }
		[XmlElement(ElementName = "FloorIdentifier", Namespace = "http://rep.oio.dk/ebxml/xml/schemas/dkcc/2003/02/13/")]
		public string FloorIdentifier { get; set; }
		[XmlElement(ElementName = "SideDoerTekst", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string SideDoerTekst { get; set; }
	}

	[XmlRoot(ElementName = "AddressAccess", Namespace = "http://rep.oio.dk/xkom.dk/xml/schemas/2005/03/15/")]
	public class AddressAccess
	{
		[XmlElement(ElementName = "MunicipalityCode", Namespace = "http://rep.oio.dk/cpr.dk/xml/schemas/core/2005/03/18/")]
		public string MunicipalityCode { get; set; }
		[XmlElement(ElementName = "StreetCode", Namespace = "http://rep.oio.dk/cpr.dk/xml/schemas/core/2005/03/18/")]
		public string StreetCode { get; set; }
		[XmlElement(ElementName = "StreetBuildingIdentifier", Namespace = "http://rep.oio.dk/ebxml/xml/schemas/dkcc/2003/02/13/")]
		public string StreetBuildingIdentifier { get; set; }
	}

	[XmlRoot(ElementName = "AddressSpecific", Namespace = "http://rep.oio.dk/xkom.dk/xml/schemas/2006/01/06/")]
	public class AddressSpecific
	{
		[XmlElement(ElementName = "AddressAccess", Namespace = "http://rep.oio.dk/xkom.dk/xml/schemas/2005/03/15/")]
		public AddressAccess AddressAccess { get; set; }
		[XmlElement(ElementName = "FloorIdentifier", Namespace = "http://rep.oio.dk/ebxml/xml/schemas/dkcc/2003/02/13/")]
		public string FloorIdentifier { get; set; }
		[XmlElement(ElementName = "SuiteIdentifier", Namespace = "http://rep.oio.dk/ebxml/xml/schemas/dkcc/2003/02/13/")]
		public string SuiteIdentifier { get; set; }
	}

	[XmlRoot(ElementName = "AdresseStruktur", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/snapshot/1/")]
	public class AdresseStruktur
	{
		[XmlElement(ElementName = "AddressSpecific", Namespace = "http://rep.oio.dk/xkom.dk/xml/schemas/2006/01/06/")]
		public AddressSpecific AddressSpecific { get; set; }
		[XmlElement(ElementName = "StreetName", Namespace = "http://rep.oio.dk/ebxml/xml/schemas/dkcc/2005/03/15/")]
		public string StreetName { get; set; }
		[XmlElement(ElementName = "PostCodeIdentifier", Namespace = "http://rep.oio.dk/ebxml/xml/schemas/dkcc/2005/03/15/")]
		public string PostCodeIdentifier { get; set; }
		[XmlElement(ElementName = "DistrictName", Namespace = "http://rep.oio.dk/ebxml/xml/schemas/dkcc/2005/03/15/")]
		public string DistrictName { get; set; }
	}

	[XmlRoot(ElementName = "AndelStamoplysninger", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
	public class AndelStamoplysninger
	{
		[XmlElement(ElementName = "AndelIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public AndelIdentifikator AndelIdentifikator { get; set; }
		[XmlElement(ElementName = "AdresseStruktur", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/snapshot/1/")]
		public AdresseStruktur AdresseStruktur { get; set; }
	}

	[XmlRoot(ElementName = "DokumentRevisionIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class DokumentRevisionIdentifikator
	{
		[XmlElement(ElementName = "DokumentIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string DokumentIdentifikator { get; set; }
		[XmlElement(ElementName = "RevisionNummer", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string RevisionNummer { get; set; }
	}

	[XmlRoot(ElementName = "Pantrettighed", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class Pantrettighed
	{
		[XmlElement(ElementName = "RettighedIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string RettighedIdentifikator { get; set; }
		[XmlElement(ElementName = "PrioritetNummer", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string PrioritetNummer { get; set; }
	}

	[XmlRoot(ElementName = "DokumentAlias", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
	public class DokumentAlias
	{
		[XmlElement(ElementName = "AktHistoriskIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public string AktHistoriskIdentifikator { get; set; }
		[XmlElement(ElementName = "DokumentAliasIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public string DokumentAliasIdentifikator { get; set; }
	}

	[XmlRoot(ElementName = "PersonSimpelIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class PersonSimpelIdentifikator
	{
		[XmlElement(ElementName = "PersonName", Namespace = "http://rep.oio.dk/itst.dk/xml/schemas/2006/01/17/")]
		public string PersonName { get; set; }
		[XmlElement(ElementName = "BirthDate", Namespace = "http://rep.oio.dk/ebxml/xml/schemas/dkcc/2005/03/15/")]
		public string BirthDate { get; set; }
	}

	[XmlRoot(ElementName = "RolleInformation", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class RolleInformation
	{
		[XmlElement(ElementName = "PersonSimpelIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public PersonSimpelIdentifikator PersonSimpelIdentifikator { get; set; }
		[XmlElement(ElementName = "VirksomhedSimpelIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public VirksomhedSimpelIdentifikator VirksomhedSimpelIdentifikator { get; set; }
		[XmlElement(ElementName = "AddressSpecific", Namespace = "http://rep.oio.dk/xkom.dk/xml/schemas/2006/01/06/")]
		public AddressSpecific AddressSpecific { get; set; }
	}

	[XmlRoot(ElementName = "KreditorInformationSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
	public class KreditorInformationSamling
	{
		[XmlElement(ElementName = "RolleInformation", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public List<RolleInformation> RolleInformation { get; set; }
	}

	[XmlRoot(ElementName = "DebitorInformationSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
	public class DebitorInformationSamling
	{
		[XmlElement(ElementName = "RolleInformation", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public List<RolleInformation> RolleInformation { get; set; }
	}

	[XmlRoot(ElementName = "VirksomhedSimpelIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class VirksomhedSimpelIdentifikator
	{
		[XmlElement(ElementName = "LegalUnitName", Namespace = "http://rep.oio.dk/cvr.dk/xml/schemas/2005/03/22/")]
		public string LegalUnitName { get; set; }
		[XmlElement(ElementName = "CVRnumberIdentifier", Namespace = "http://rep.oio.dk/cvr.dk/xml/schemas/2005/03/22/")]
		public string CVRnumberIdentifier { get; set; }
	}

	[XmlRoot(ElementName = "MeddelelseshaverInformationSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
	public class MeddelelseshaverInformationSamling
	{
		[XmlElement(ElementName = "RolleInformation", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public RolleInformation RolleInformation { get; set; }
	}

	[XmlRoot(ElementName = "SecondaryPostalLabel", Namespace = "http://rep.oio.dk/cpr.dk/xml/schemas/core/2005/10/31/")]
	public class SecondaryPostalLabel
	{
		[XmlElement(ElementName = "PostalAddressFirstLineText", Namespace = "http://rep.oio.dk/ebxml/xml/schemas/dkcc/2005/05/19/")]
		public string PostalAddressFirstLineText { get; set; }
		[XmlElement(ElementName = "PostalAddressSecondLineText", Namespace = "http://rep.oio.dk/ebxml/xml/schemas/dkcc/2005/05/19/")]
		public string PostalAddressSecondLineText { get; set; }
		[XmlElement(ElementName = "PostalAddressThirdLineText", Namespace = "http://rep.oio.dk/ebxml/xml/schemas/dkcc/2005/05/19/")]
		public string PostalAddressThirdLineText { get; set; }
	}

	[XmlRoot(ElementName = "FuldmagtHaverInformation", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class FuldmagtHaverInformation
	{
		[XmlElement(ElementName = "VirksomhedSimpelIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public VirksomhedSimpelIdentifikator VirksomhedSimpelIdentifikator { get; set; }
		[XmlElement(ElementName = "SecondaryPostalLabel", Namespace = "http://rep.oio.dk/cpr.dk/xml/schemas/core/2005/10/31/")]
		public SecondaryPostalLabel SecondaryPostalLabel { get; set; }
	}

	[XmlRoot(ElementName = "ImplicitFuldmagt", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class ImplicitFuldmagt
	{
		[XmlElement(ElementName = "FuldmagtHaverInformation", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public FuldmagtHaverInformation FuldmagtHaverInformation { get; set; }
		[XmlElement(ElementName = "FuldmagtOmfangIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string FuldmagtOmfangIdentifikator { get; set; }
	}

	[XmlRoot(ElementName = "ImplicitFuldmagtSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class ImplicitFuldmagtSamling
	{
		[XmlElement(ElementName = "ImplicitFuldmagt", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public ImplicitFuldmagt ImplicitFuldmagt { get; set; }
	}

	[XmlRoot(ElementName = "UnderpantBeloeb", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class UnderpantBeloeb
	{
		[XmlElement(ElementName = "BeloebVaerdi", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string BeloebVaerdi { get; set; }
		[XmlElement(ElementName = "ValutaKode", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string ValutaKode { get; set; }
	}

	[XmlRoot(ElementName = "UnderpanthaverInformationSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class UnderpanthaverInformationSamling
	{
		[XmlElement(ElementName = "RolleInformation", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public RolleInformation RolleInformation { get; set; }
	}

	[XmlRoot(ElementName = "Underpantrettighed", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class Underpantrettighed
	{
		[XmlElement(ElementName = "DokumentRevisionIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public DokumentRevisionIdentifikator DokumentRevisionIdentifikator { get; set; }
		[XmlElement(ElementName = "DokumentAlias", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public DokumentAlias DokumentAlias { get; set; }
		[XmlElement(ElementName = "RettighedIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string RettighedIdentifikator { get; set; }
		[XmlElement(ElementName = "UnderpantBeloeb", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public UnderpantBeloeb UnderpantBeloeb { get; set; }
		[XmlElement(ElementName = "PrioritetNummer", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string PrioritetNummer { get; set; }
		[XmlElement(ElementName = "UnderpanthaverInformationSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public UnderpanthaverInformationSamling UnderpanthaverInformationSamling { get; set; }
	}

	[XmlRoot(ElementName = "UnderpantrettighedSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class UnderpantrettighedSamling
	{
		[XmlElement(ElementName = "Underpantrettighed", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public Underpantrettighed Underpantrettighed { get; set; }
	}

	[XmlRoot(ElementName = "BeloebValuta", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class BeloebValuta
	{
		[XmlElement(ElementName = "BeloebVaerdi", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string BeloebVaerdi { get; set; }
		[XmlElement(ElementName = "ValutaKode", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string ValutaKode { get; set; }
	}

	[XmlRoot(ElementName = "HaeftelseBeloeb", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class HaeftelseBeloeb
	{
		[XmlElement(ElementName = "BeloebValuta", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public BeloebValuta BeloebValuta { get; set; }
	}

	[XmlRoot(ElementName = "TekstGruppe", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class TekstGruppe
	{
		[XmlElement(ElementName = "Overskrift", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string Overskrift { get; set; }
		[XmlElement(ElementName = "Afsnit", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public List<string> Afsnit { get; set; }
	}

	[XmlRoot(ElementName = "TekstAngivelse", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class TekstAngivelse
	{
		[XmlElement(ElementName = "TekstGruppe", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public TekstGruppe TekstGruppe { get; set; }
	}

	[XmlRoot(ElementName = "TillaegstekstSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
	public class TillaegstekstSamling
	{
		[XmlElement(ElementName = "TekstAngivelse", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public TekstAngivelse TekstAngivelse { get; set; }
	}

	[XmlRoot(ElementName = "DokumentInformationOverfoert", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
	public class DokumentInformationOverfoert
	{
		[XmlElement(ElementName = "DokumentTypeBeskrivelse", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public string DokumentTypeBeskrivelse { get; set; }
		[XmlElement(ElementName = "DokumentNummer", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public string DokumentNummer { get; set; }
		[XmlElement(ElementName = "DokumentFilnavnTekst", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public string DokumentFilnavnTekst { get; set; }
	}

	[XmlRoot(ElementName = "HaeftelseSummarisk", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
	public class HaeftelseSummarisk
	{
		[XmlElement(ElementName = "DokumentRevisionIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public DokumentRevisionIdentifikator DokumentRevisionIdentifikator { get; set; }
		[XmlElement(ElementName = "TinglysningsDato", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string TinglysningsDato { get; set; }
		[XmlElement(ElementName = "SenestPaategnetDato", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string SenestPaategnetDato { get; set; }
		[XmlElement(ElementName = "Pantrettighed", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public Pantrettighed Pantrettighed { get; set; }
		[XmlElement(ElementName = "DokumentAlias", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public DokumentAlias DokumentAlias { get; set; }
		[XmlElement(ElementName = "AndelHaeftelseTypeTekst", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public string AndelHaeftelseTypeTekst { get; set; }
		[XmlElement(ElementName = "DokumentOverfoertIndikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public string DokumentOverfoertIndikator { get; set; }
		[XmlElement(ElementName = "KreditorInformationSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public KreditorInformationSamling KreditorInformationSamling { get; set; }
		[XmlElement(ElementName = "DebitorInformationSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public DebitorInformationSamling DebitorInformationSamling { get; set; }
		[XmlElement(ElementName = "MeddelelseshaverInformationSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public MeddelelseshaverInformationSamling MeddelelseshaverInformationSamling { get; set; }
		[XmlElement(ElementName = "ImplicitFuldmagtSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public ImplicitFuldmagtSamling ImplicitFuldmagtSamling { get; set; }
		[XmlElement(ElementName = "UnderpantrettighedSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public UnderpantrettighedSamling UnderpantrettighedSamling { get; set; }
		[XmlElement(ElementName = "HaeftelseBeloeb", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public HaeftelseBeloeb HaeftelseBeloeb { get; set; }
		[XmlElement(ElementName = "HaeftelseRenteOverfoert", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public string HaeftelseRenteOverfoert { get; set; }
		[XmlElement(ElementName = "TillaegstekstSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public TillaegstekstSamling TillaegstekstSamling { get; set; }
		[XmlElement(ElementName = "DokumentInformationOverfoert", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public DokumentInformationOverfoert DokumentInformationOverfoert { get; set; }
		[XmlElement(ElementName = "TinglysningAfgiftBetalt", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public string TinglysningAfgiftBetalt { get; set; }
		[XmlElement(ElementName = "TinglysningAfgiftOverfoerselIndikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public string TinglysningAfgiftOverfoerselIndikator { get; set; }
		[XmlElement(ElementName = "KonverteretDigitalPantebrevIndikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public string KonverteretDigitalPantebrevIndikator { get; set; }
	}

	[XmlRoot(ElementName = "HaeftelseSummariskSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
	public class HaeftelseSummariskSamling
	{
		[XmlElement(ElementName = "HaeftelseSummarisk", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public HaeftelseSummarisk HaeftelseSummarisk { get; set; }
	}

	[XmlRoot(ElementName = "AndelSummarisk", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
	public class AndelSummarisk
	{
		[XmlElement(ElementName = "AndelStamoplysninger", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public AndelStamoplysninger AndelStamoplysninger { get; set; }
		[XmlElement(ElementName = "HaeftelseSummariskSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public HaeftelseSummariskSamling HaeftelseSummariskSamling { get; set; }
		[XmlElement(ElementName = "ModelId", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string ModelId { get; set; }
	}

	[XmlRoot(ElementName = "ForespoergselsIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class ForespoergselsIdentifikator
	{
		[XmlElement(ElementName = "Id", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string Id { get; set; }
	}

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
	}

	[XmlRoot(ElementName = "AndelSummariskHentResultat", Namespace = "http://rep.oio.dk/tinglysning.dk/service/message/elektroniskakt/1/")]
	public class AndelSummariskHentResultat
	{
		[XmlElement(ElementName = "AndelSummarisk", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public AndelSummarisk AndelSummarisk { get; set; }
		[XmlElement(ElementName = "ForespoergselsIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public ForespoergselsIdentifikator ForespoergselsIdentifikator { get; set; }
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
		[XmlAttribute(AttributeName = "ns2", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Ns2 { get; set; }
		[XmlAttribute(AttributeName = "ns3", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Ns3 { get; set; }
		[XmlAttribute(AttributeName = "ns4", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Ns4 { get; set; }
		[XmlAttribute(AttributeName = "ns5", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Ns5 { get; set; }
		[XmlAttribute(AttributeName = "ns6", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Ns6 { get; set; }
		[XmlAttribute(AttributeName = "ns7", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Ns7 { get; set; }
		[XmlAttribute(AttributeName = "ns8", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Ns8 { get; set; }
		[XmlAttribute(AttributeName = "ns9", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Ns9 { get; set; }
		[XmlAttribute(AttributeName = "ns10", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Ns10 { get; set; }
		[XmlAttribute(AttributeName = "ns11", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Ns11 { get; set; }
		[XmlAttribute(AttributeName = "xd", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Xd { get; set; }
	}

}
