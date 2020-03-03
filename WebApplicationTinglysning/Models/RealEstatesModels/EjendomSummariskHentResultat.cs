using System.Xml.Serialization;
using System.Collections.Generic;

namespace WebApplicationTinglysning.Models
{
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
		[XmlElement(ElementName = "DistrictSubdivisionIdentifier", Namespace = "http://rep.oio.dk/ebxml/xml/schemas/dkcc/2005/03/15/")]
		public string DistrictSubdivisionIdentifier { get; set; }
	}

	[XmlRoot(ElementName = "Ejerlejlighed", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class Ejerlejlighed
	{
		[XmlElement(ElementName = "Ejerlejlighedsnummer", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string Ejerlejlighedsnummer { get; set; }
	}

	[XmlRoot(ElementName = "EjendomType", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class EjendomType
	{
		[XmlElement(ElementName = "Ejerlejlighed", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public Ejerlejlighed Ejerlejlighed { get; set; }
	}

	[XmlRoot(ElementName = "Matrikel", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class Matrikel
	{
		[XmlElement(ElementName = "CadastralDistrictName", Namespace = "http://rep.oio.dk/kms.dk/xml/schemas/2005/03/11/")]
		public string CadastralDistrictName { get; set; }
		[XmlElement(ElementName = "CadastralDistrictIdentifier", Namespace = "http://rep.oio.dk/kms.dk/xml/schemas/2005/03/11/")]
		public string CadastralDistrictIdentifier { get; set; }
		[XmlElement(ElementName = "Matrikelnummer", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string Matrikelnummer { get; set; }
	}

	// Added
	[XmlRoot(ElementName = "Umatrikuleretareal", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class Umatrikuleretareal
	{
		[XmlElement(ElementName = "UmatrikuleretType", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string UmatrikuleretType { get; set; }
		[XmlElement(ElementName = "UmatrikuleretIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string UmatrikuleretIdentifikator { get; set; }
		[XmlElement(ElementName = "JurisdictionCode", Namespace = "http://rep.oio.dk/ois.dk/xml/schemas/2006/04/25/")]
		public string JurisdictionCode { get; set; }
		[XmlElement(ElementName = "UmatrikuleretarealBeskrivelse", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string UmatrikuleretarealBeskrivelse { get; set; }
	}

	[XmlRoot(ElementName = "EjendomIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class EjendomIdentifikator
	{
		[XmlElement(ElementName = "BestemtFastEjendomNummer", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string BestemtFastEjendomNummer { get; set; }
		[XmlElement(ElementName = "EjendomType", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public EjendomType EjendomType { get; set; }
		[XmlElement(ElementName = "Matrikel", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public List<Matrikel> Matrikel { get; set; }

		// Added
		[XmlElement(ElementName = "Umatrikuleretareal", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public Umatrikuleretareal Umatrikuleretareal { get; set; }
	}

	[XmlRoot(ElementName = "MatrikelStruktur", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/snapshot/1/")]
	public class MatrikelStruktur
	{
		[XmlElement(ElementName = "Matrikel", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public Matrikel Matrikel { get; set; }
		[XmlElement(ElementName = "SpecificParcelAreaMeasure", Namespace = "http://rep.oio.dk/svur.dk/xml/schemas/2006/04/25/")]
		public string SpecificParcelAreaMeasure { get; set; }
		[XmlElement(ElementName = "LandParcelRegistrationDate", Namespace = "http://rep.oio.dk/matr.dk/xml/schemas/2006/04/25/")]
		public string LandParcelRegistrationDate { get; set; }
		[XmlElement(ElementName = "RoadAreaMeasure", Namespace = "http://rep.oio.dk/matr.dk/xml/schemas/2006/04/25/")]
		public string RoadAreaMeasure { get; set; }
		[XmlElement(ElementName = "JurisdictionCode", Namespace = "http://rep.oio.dk/ois.dk/xml/schemas/2006/04/25/")]
		public string JurisdictionCode { get; set; }
	}

	[XmlRoot(ElementName = "MatrikelStrukturSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/snapshot/1/")]
	public class MatrikelStrukturSamling
	{
		[XmlElement(ElementName = "MatrikelStruktur", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/snapshot/1/")]
		public MatrikelStruktur MatrikelStruktur { get; set; }
	}

	[XmlRoot(ElementName = "RealPropertyStructure", Namespace = "http://rep.oio.dk/bbr.dk/xml/schemas/2005/12/15/")]
	public class RealPropertyStructure
	{
		[XmlElement(ElementName = "MunicipalityCode", Namespace = "http://rep.oio.dk/cpr.dk/xml/schemas/core/2005/03/18/")]
		public string MunicipalityCode { get; set; }
		[XmlElement(ElementName = "MunicipalRealPropertyIdentifier", Namespace = "http://rep.oio.dk/bbr.dk/xml/schemas/2005/03/11/")]
		public string MunicipalRealPropertyIdentifier { get; set; }
	}

	[XmlRoot(ElementName = "EjendomVurderingStruktur", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/snapshot/1/")]
	public class EjendomVurderingStruktur
	{
		[XmlElement(ElementName = "RealPropertyStructure", Namespace = "http://rep.oio.dk/bbr.dk/xml/schemas/2005/12/15/")]
		public RealPropertyStructure RealPropertyStructure { get; set; }
		[XmlElement(ElementName = "DelvistBeroertESREjendomIndikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/snapshot/1/")]
		public string DelvistBeroertESREjendomIndikator { get; set; }
		[XmlElement(ElementName = "EjendomVaerdi", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/snapshot/1/")]
		public string EjendomVaerdi { get; set; }
		[XmlElement(ElementName = "ParcelLandValueAssessmentCalculationAmount", Namespace = "http://rep.oio.dk/svur.dk/xml/schemas/2006/04/25/")]
		public string ParcelLandValueAssessmentCalculationAmount { get; set; }
		[XmlElement(ElementName = "AssessmentChangedDate", Namespace = "http://rep.oio.dk/svur.dk/xml/schemas/2006/04/25/")]
		public string AssessmentChangedDate { get; set; }
	}

	[XmlRoot(ElementName = "EjendomVurderingSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/snapshot/1/")]
	public class EjendomVurderingSamling
	{
		[XmlElement(ElementName = "EjendomVurderingStruktur", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/snapshot/1/")]
		public EjendomVurderingStruktur EjendomVurderingStruktur { get; set; }
	}

	[XmlRoot(ElementName = "Fordelingtal", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class Fordelingtal
	{
		[XmlElement(ElementName = "Taeller", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string Taeller { get; set; }
		[XmlElement(ElementName = "Naevner", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string Naevner { get; set; }
	}

	[XmlRoot(ElementName = "EjendomIndskannetAktSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
	public class EjendomIndskannetAktSamling
	{
		[XmlElement(ElementName = "DokumentFilnavnTekst", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public string DokumentFilnavnTekst { get; set; }
	}

	// Added
	[XmlRoot(ElementName = "Tekst", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class Tekst
	{
		[XmlElement(ElementName = "TekstGruppe", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public TekstGruppe TekstGruppe { get; set; }
	}

	// Added
	[XmlRoot(ElementName = "EjendomNoteringTekst", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
	public class EjendomNoteringTekst
	{
		[XmlElement(ElementName = "Tekst", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public Tekst Tekst { get; set; }
		[XmlElement(ElementName = "Dato", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string Dato { get; set; }
	}

	// Added
	[XmlRoot(ElementName = "EjendomNoteringTekstSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
	public class EjendomNoteringTekstSamling
	{
		[XmlElement(ElementName = "EjendomNoteringTekst", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public EjendomNoteringTekst EjendomNoteringTekst { get; set; }
	}

	[XmlRoot(ElementName = "EjendomStamoplysninger", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
	public class EjendomStamoplysninger
	{
		[XmlElement(ElementName = "AdresseStruktur", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/snapshot/1/")]
		public AdresseStruktur AdresseStruktur { get; set; }
		[XmlElement(ElementName = "EjendomIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public EjendomIdentifikator EjendomIdentifikator { get; set; }
		[XmlElement(ElementName = "MatrikelStrukturSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/snapshot/1/")]
		public MatrikelStrukturSamling MatrikelStrukturSamling { get; set; }
		[XmlElement(ElementName = "EjendomVurderingSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/snapshot/1/")]
		public EjendomVurderingSamling EjendomVurderingSamling { get; set; }
		[XmlElement(ElementName = "Fordelingtal", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public Fordelingtal Fordelingtal { get; set; }
		[XmlElement(ElementName = "EjendomIndskannetAktSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public EjendomIndskannetAktSamling EjendomIndskannetAktSamling { get; set; }
		// Added
		[XmlElement(ElementName = "EjendomNoteringTekstSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public EjendomNoteringTekstSamling EjendomNoteringTekstSamling { get; set; }
		[XmlElement(ElementName = "TillaegstekstSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public TillaegstekstSamling TillaegstekstSamling { get; set; }
	}

	[XmlRoot(ElementName = "DokumentRevisionIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class DokumentRevisionIdentifikator
	{
		[XmlElement(ElementName = "DokumentIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string DokumentIdentifikator { get; set; }
		[XmlElement(ElementName = "RevisionNummer", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string RevisionNummer { get; set; }
	}

	[XmlRoot(ElementName = "EjendomIdentifikatorSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class EjendomIdentifikatorSamling
	{
		[XmlElement(ElementName = "EjendomIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public List<EjendomIdentifikator> EjendomIdentifikator { get; set; }
	}

	[XmlRoot(ElementName = "OgsaaLystPaaSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
	public class OgsaaLystPaaSamling
	{
		[XmlElement(ElementName = "OgsaaLystPaaAntal", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public string OgsaaLystPaaAntal { get; set; }
		[XmlElement(ElementName = "EjendomIdentifikatorSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public EjendomIdentifikatorSamling EjendomIdentifikatorSamling { get; set; }
	}

	[XmlRoot(ElementName = "DokumentAlias", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
	public class DokumentAlias
	{
		[XmlElement(ElementName = "DokumentAliasIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public string DokumentAliasIdentifikator { get; set; }
		[XmlElement(ElementName = "AktHistoriskIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public string AktHistoriskIdentifikator { get; set; }
	}

	[XmlRoot(ElementName = "PersonSimpelIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class PersonSimpelIdentifikator
	{
		[XmlElement(ElementName = "PersonName", Namespace = "http://rep.oio.dk/itst.dk/xml/schemas/2006/01/17/")]
		public string PersonName { get; set; }
		[XmlElement(ElementName = "BirthDate", Namespace = "http://rep.oio.dk/ebxml/xml/schemas/dkcc/2005/03/15/")]
		public string BirthDate { get; set; }
	}

	[XmlRoot(ElementName = "AndelIdeel", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class AndelIdeel
	{
		[XmlElement(ElementName = "Taeller", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string Taeller { get; set; }
		[XmlElement(ElementName = "Naevner", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string Naevner { get; set; }
	}

	[XmlRoot(ElementName = "Adkomsthaver", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
	public class Adkomsthaver
	{
		[XmlElement(ElementName = "LegalUnitName", Namespace = "http://rep.oio.dk/cvr.dk/xml/schemas/2005/03/22/")]
		public string LegalUnitName { get; set; }
		[XmlElement(ElementName = "CVRnumberIdentifier", Namespace = "http://rep.oio.dk/cvr.dk/xml/schemas/2005/03/22/")]
		public string CVRnumberIdentifier { get; set; }
		[XmlElement(ElementName = "AddressSpecific", Namespace = "http://rep.oio.dk/xkom.dk/xml/schemas/2006/01/06/")]
		public AddressSpecific AddressSpecific { get; set; }
		[XmlElement(ElementName = "AndelIdeel", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public AndelIdeel AndelIdeel { get; set; }
		[XmlElement(ElementName = "PersonSimpelIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public PersonSimpelIdentifikator PersonSimpelIdentifikator { get; set; }
	}

	[XmlRoot(ElementName = "AdkomsthaverSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
	public class AdkomsthaverSamling
	{
		[XmlElement(ElementName = "Adkomsthaver", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public Adkomsthaver Adkomsthaver { get; set; }
	}

	[XmlRoot(ElementName = "SkoedeKoebesum", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class SkoedeKoebesum
	{
		[XmlElement(ElementName = "KontantKoebesum", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string KontantKoebesum { get; set; }
		[XmlElement(ElementName = "ArvGaveBeloeb", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string ArvGaveBeloeb { get; set; }
		[XmlElement(ElementName = "OvertagneRestancer", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string OvertagneRestancer { get; set; }
		[XmlElement(ElementName = "AfloesningsbareServitutter", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string AfloesningsbareServitutter { get; set; }
		[XmlElement(ElementName = "AnlaegsBidrag", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string AnlaegsBidrag { get; set; }
		[XmlElement(ElementName = "IAltKoebesum", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string IAltKoebesum { get; set; }
	}

	[XmlRoot(ElementName = "AdkomstSummarisk", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
	public class AdkomstSummarisk
	{
		[XmlElement(ElementName = "DokumentRevisionIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public DokumentRevisionIdentifikator DokumentRevisionIdentifikator { get; set; }
		[XmlElement(ElementName = "TinglysningsDato", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string TinglysningsDato { get; set; }
		[XmlElement(ElementName = "OgsaaLystPaaSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public OgsaaLystPaaSamling OgsaaLystPaaSamling { get; set; }
		[XmlElement(ElementName = "DokumentAlias", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public DokumentAlias DokumentAlias { get; set; }
		[XmlElement(ElementName = "AdkomstType", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public string AdkomstType { get; set; }
		[XmlElement(ElementName = "DokumentOverfoertIndikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public string DokumentOverfoertIndikator { get; set; }
		[XmlElement(ElementName = "AdkomsthaverSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public AdkomsthaverSamling AdkomsthaverSamling { get; set; }
		[XmlElement(ElementName = "ValutaKode", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string ValutaKode { get; set; }
		[XmlElement(ElementName = "SkoedeOvertagelsesDato", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string SkoedeOvertagelsesDato { get; set; }
		[XmlElement(ElementName = "SkoedeKoebesum", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public SkoedeKoebesum SkoedeKoebesum { get; set; }
		[XmlElement(ElementName = "TinglysningAfgiftBetalt", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public string TinglysningAfgiftBetalt { get; set; }
	}

	[XmlRoot(ElementName = "AdkomstSummariskSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
	public class AdkomstSummariskSamling
	{
		[XmlElement(ElementName = "AdkomstSummarisk", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public AdkomstSummarisk AdkomstSummarisk { get; set; }
	}

	[XmlRoot(ElementName = "Pantrettighed", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class Pantrettighed
	{
		[XmlElement(ElementName = "RettighedIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string RettighedIdentifikator { get; set; }
		[XmlElement(ElementName = "PrioritetNummer", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string PrioritetNummer { get; set; }
	}

	[XmlRoot(ElementName = "VirksomhedSimpelIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class VirksomhedSimpelIdentifikator
	{
		[XmlElement(ElementName = "LegalUnitName", Namespace = "http://rep.oio.dk/cvr.dk/xml/schemas/2005/03/22/")]
		public string LegalUnitName { get; set; }
		[XmlElement(ElementName = "CVRnumberIdentifier", Namespace = "http://rep.oio.dk/cvr.dk/xml/schemas/2005/03/22/")]
		public string CVRnumberIdentifier { get; set; }
	}

	[XmlRoot(ElementName = "RolleInformation", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class RolleInformation
	{
		[XmlElement(ElementName = "VirksomhedSimpelIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public VirksomhedSimpelIdentifikator VirksomhedSimpelIdentifikator { get; set; }
		[XmlElement(ElementName = "AddressSpecific", Namespace = "http://rep.oio.dk/xkom.dk/xml/schemas/2006/01/06/")]
		public AddressSpecific AddressSpecific { get; set; }
		[XmlElement(ElementName = "PersonSimpelIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public PersonSimpelIdentifikator PersonSimpelIdentifikator { get; set; }
	}

	[XmlRoot(ElementName = "KreditorInformationSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
	public class KreditorInformationSamling
	{
		[XmlElement(ElementName = "RolleInformation", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public RolleInformation RolleInformation { get; set; }
	}

	[XmlRoot(ElementName = "DebitorInformationSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
	public class DebitorInformationSamling
	{
		[XmlElement(ElementName = "RolleInformation", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public RolleInformation RolleInformation { get; set; }
	}

	[XmlRoot(ElementName = "HaeftelseRenteFast", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class HaeftelseRenteFast
	{
		[XmlElement(ElementName = "HaeftelseRentePaalydendeSats", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string HaeftelseRentePaalydendeSats { get; set; }
		[XmlElement(ElementName = "HaeftelseRenteSatsForeloebigIndikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string HaeftelseRenteSatsForeloebigIndikator { get; set; }
	}

	[XmlRoot(ElementName = "HaeftelseRente", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class HaeftelseRente
	{
		[XmlElement(ElementName = "HaeftelseRenteFast", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public HaeftelseRenteFast HaeftelseRenteFast { get; set; }
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

	[XmlRoot(ElementName = "Servitutrettighed", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class Servitutrettighed
	{
		[XmlElement(ElementName = "RettighedIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string RettighedIdentifikator { get; set; }
		[XmlElement(ElementName = "PrioritetNummer", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string PrioritetNummer { get; set; }
	}

	[XmlRoot(ElementName = "ServitutInformation", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class ServitutInformation
	{
		[XmlElement(ElementName = "ServitutKanTinglysesUdenEjersTiltraedelseIndikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string ServitutKanTinglysesUdenEjersTiltraedelseIndikator { get; set; }
		[XmlElement(ElementName = "ServitutKanTinglysesMedPrioritetForudForGaeldOgServitutterIndikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string ServitutKanTinglysesMedPrioritetForudForGaeldOgServitutterIndikator { get; set; }
		[XmlElement(ElementName = "ServitutHarBetydningForEjendommensVaerdiIndikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string ServitutHarBetydningForEjendommensVaerdiIndikator { get; set; }
		[XmlElement(ElementName = "ServitutAfsnitAnvendelse", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public ServitutAfsnitAnvendelse ServitutAfsnitAnvendelse { get; set; }
		[XmlElement(ElementName = "ServitutAfsnitBebyggelse", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public ServitutAfsnitBebyggelse ServitutAfsnitBebyggelse { get; set; }
		[XmlElement(ElementName = "ServitutAfsnitAndet", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public ServitutAfsnitAndet ServitutAfsnitAndet { get; set; }
		[XmlElement(ElementName = "ServitutAfsnitEjendomsforhold", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public ServitutAfsnitEjendomsforhold ServitutAfsnitEjendomsforhold { get; set; }
		[XmlElement(ElementName = "ServitutAfsnitFaerdsel", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public ServitutAfsnitFaerdsel ServitutAfsnitFaerdsel { get; set; }
		[XmlElement(ElementName = "ServitutAfsnitTekniskeAnlaeg", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public ServitutAfsnitTekniskeAnlaeg ServitutAfsnitTekniskeAnlaeg { get; set; }
	}

	[XmlRoot(ElementName = "ServitutSummarisk", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
	public class ServitutSummarisk
	{
		[XmlElement(ElementName = "DokumentRevisionIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public DokumentRevisionIdentifikator DokumentRevisionIdentifikator { get; set; }
		[XmlElement(ElementName = "TinglysningsDato", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string TinglysningsDato { get; set; }
		[XmlElement(ElementName = "Servitutrettighed", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public Servitutrettighed Servitutrettighed { get; set; }
		[XmlElement(ElementName = "DokumentAlias", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public DokumentAlias DokumentAlias { get; set; }
		[XmlElement(ElementName = "ServitutType", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string ServitutType { get; set; }
		[XmlElement(ElementName = "ServitutInformation", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public ServitutInformation ServitutInformation { get; set; }
		[XmlElement(ElementName = "DokumentOverfoertIndikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public string DokumentOverfoertIndikator { get; set; }
		[XmlElement(ElementName = "TillaegstekstSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public TillaegstekstSamling TillaegstekstSamling { get; set; }
		[XmlElement(ElementName = "DokumentInformationOverfoert", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public DokumentInformationOverfoert DokumentInformationOverfoert { get; set; }
		[XmlElement(ElementName = "OgsaaLystPaaSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public OgsaaLystPaaSamling OgsaaLystPaaSamling { get; set; }
	}

	[XmlRoot(ElementName = "ServitutIndholdAnvendelse", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class ServitutIndholdAnvendelse
	{
		[XmlElement(ElementName = "ServitutIndholdAnvendelseKode", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string ServitutIndholdAnvendelseKode { get; set; }
	}

	[XmlRoot(ElementName = "ServitutAfsnitAnvendelse", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class ServitutAfsnitAnvendelse
	{
		[XmlElement(ElementName = "ServitutIndholdAnvendelse", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public ServitutIndholdAnvendelse ServitutIndholdAnvendelse { get; set; }
	}

	[XmlRoot(ElementName = "ServitutIndholdBebyggelse", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class ServitutIndholdBebyggelse
	{
		[XmlElement(ElementName = "ServitutIndholdBebyggelseKode", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string ServitutIndholdBebyggelseKode { get; set; }
	}

	[XmlRoot(ElementName = "ServitutAfsnitBebyggelse", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class ServitutAfsnitBebyggelse
	{
		[XmlElement(ElementName = "ServitutIndholdBebyggelse", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public ServitutIndholdBebyggelse ServitutIndholdBebyggelse { get; set; }
	}

	[XmlRoot(ElementName = "ServitutIndholdAndet", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class ServitutIndholdAndet
	{
		[XmlElement(ElementName = "ServitutIndholdAndetKode", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string ServitutIndholdAndetKode { get; set; }
	}

	[XmlRoot(ElementName = "ServitutAfsnitAndet", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class ServitutAfsnitAndet
	{
		[XmlElement(ElementName = "ServitutIndholdAndet", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public ServitutIndholdAndet ServitutIndholdAndet { get; set; }
	}

	[XmlRoot(ElementName = "ServitutIndholdEjendomsforhold", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class ServitutIndholdEjendomsforhold
	{
		[XmlElement(ElementName = "ServitutIndholdEjendomsforholdKode", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string ServitutIndholdEjendomsforholdKode { get; set; }
	}

	[XmlRoot(ElementName = "ServitutAfsnitEjendomsforhold", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class ServitutAfsnitEjendomsforhold
	{
		[XmlElement(ElementName = "ServitutIndholdEjendomsforhold", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public ServitutIndholdEjendomsforhold ServitutIndholdEjendomsforhold { get; set; }
	}

	[XmlRoot(ElementName = "ServitutIndholdFaerdsel", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class ServitutIndholdFaerdsel
	{
		[XmlElement(ElementName = "ServitutIndholdFaerdselKode", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string ServitutIndholdFaerdselKode { get; set; }
	}

	[XmlRoot(ElementName = "ServitutAfsnitFaerdsel", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class ServitutAfsnitFaerdsel
	{
		[XmlElement(ElementName = "ServitutIndholdFaerdsel", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public ServitutIndholdFaerdsel ServitutIndholdFaerdsel { get; set; }
	}

	[XmlRoot(ElementName = "ServitutIndholdTekniskeAnlaeg", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class ServitutIndholdTekniskeAnlaeg
	{
		[XmlElement(ElementName = "ServitutIndholdTekniskeAnlaegKode", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string ServitutIndholdTekniskeAnlaegKode { get; set; }
	}

	[XmlRoot(ElementName = "ServitutAfsnitTekniskeAnlaeg", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class ServitutAfsnitTekniskeAnlaeg
	{
		[XmlElement(ElementName = "ServitutIndholdTekniskeAnlaeg", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public ServitutIndholdTekniskeAnlaeg ServitutIndholdTekniskeAnlaeg { get; set; }
	}

	[XmlRoot(ElementName = "ServitutSummariskSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
	public class ServitutSummariskSamling
	{
		[XmlElement(ElementName = "ServitutSummarisk", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public List<ServitutSummarisk> ServitutSummarisk { get; set; }
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
		[XmlElement(ElementName = "HaeftelseType", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public string HaeftelseType { get; set; }
		[XmlElement(ElementName = "DokumentOverfoertIndikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public string DokumentOverfoertIndikator { get; set; }
		[XmlElement(ElementName = "KreditorInformationSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public KreditorInformationSamling KreditorInformationSamling { get; set; }
		[XmlElement(ElementName = "DebitorInformationSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public DebitorInformationSamling DebitorInformationSamling { get; set; }
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
		[XmlElement(ElementName = "TinglysningAfgiftOverfoerselIndikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public string TinglysningAfgiftOverfoerselIndikator { get; set; }
		[XmlElement(ElementName = "KonverteretDigitalPantebrevIndikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public string KonverteretDigitalPantebrevIndikator { get; set; }
		[XmlElement(ElementName = "RespektSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public RespektSamling RespektSamling { get; set; }
		[XmlElement(ElementName = "OgsaaLystPaaSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public OgsaaLystPaaSamling OgsaaLystPaaSamling { get; set; }
		[XmlElement(ElementName = "HaeftelsePantebrevFormularLovpligtigKode", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string HaeftelsePantebrevFormularLovpligtigKode { get; set; }
		[XmlElement(ElementName = "HaeftelseRente", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public HaeftelseRente HaeftelseRente { get; set; }
		[XmlElement(ElementName = "HaeftelseLaantypeKode", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string HaeftelseLaantypeKode { get; set; }
		[XmlElement(ElementName = "TinglysningAfgiftBetalt", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public string TinglysningAfgiftBetalt { get; set; }
	}

	[XmlRoot(ElementName = "Respekt", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class Respekt
	{
		[XmlElement(ElementName = "RettighedIdentifikator", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public string RettighedIdentifikator { get; set; }
	}

	[XmlRoot(ElementName = "RespektSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
	public class RespektSamling
	{
		[XmlElement(ElementName = "Respekt", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/model/1/")]
		public List<Respekt> Respekt { get; set; }
	}

	[XmlRoot(ElementName = "HaeftelseSummariskSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
	public class HaeftelseSummariskSamling
	{
		[XmlElement(ElementName = "HaeftelseSummarisk", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public List<HaeftelseSummarisk> HaeftelseSummarisk { get; set; }
	}

	[XmlRoot(ElementName = "EjendomSummarisk", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
	public class EjendomSummarisk
	{
		[XmlElement(ElementName = "EjendomStamoplysninger", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public EjendomStamoplysninger EjendomStamoplysninger { get; set; }
		[XmlElement(ElementName = "AdkomstSummariskSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public AdkomstSummariskSamling AdkomstSummariskSamling { get; set; }
		[XmlElement(ElementName = "HaeftelseSummariskSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public HaeftelseSummariskSamling HaeftelseSummariskSamling { get; set; }
		[XmlElement(ElementName = "ServitutSummariskSamling", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public ServitutSummariskSamling ServitutSummariskSamling { get; set; }
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

	[XmlRoot(ElementName = "EjendomSummariskHentResultat", Namespace = "http://rep.oio.dk/tinglysning.dk/service/message/elektroniskakt/1/")]
	public class EjendomSummariskHentResultat
	{
		[XmlElement(ElementName = "EjendomSummarisk", Namespace = "http://rep.oio.dk/tinglysning.dk/schema/elektroniskakt/1/")]
		public EjendomSummarisk EjendomSummarisk { get; set; }
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
		[XmlAttribute(AttributeName = "ns12", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Ns12 { get; set; }
		[XmlAttribute(AttributeName = "ns13", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Ns13 { get; set; }
		[XmlAttribute(AttributeName = "ns14", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Ns14 { get; set; }
		[XmlAttribute(AttributeName = "ns15", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Ns15 { get; set; }
		[XmlAttribute(AttributeName = "xd", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Xd { get; set; }
	}

}
