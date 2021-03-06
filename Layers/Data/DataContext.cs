using System;
using System.Data.Entity;
using System.Data;
using System.Data.Common;
using Emash.GeoPat.Data.Models;
namespace Emash.GeoPat.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbConnection connection) : base(connection,false)
        {
        }
        
        public DbSet<BsnCdType> BsnCdTypes { get; set; }
        
        public DbSet<BsnCdFam> BsnCdFams { get; set; }
        
        public DbSet<BsnCdEntp> BsnCdEntps { get; set; }
        
        public DbSet<BsnDsc> BsnDscs { get; set; }
        
        public DbSet<BsnCls> BsnClss { get; set; }
        
        public DbSet<BsnDoc> BsnDocs { get; set; }
        
        public DbSet<BsnCdDoc> BsnCdDocs { get; set; }
        
        public DbSet<BsnElt> BsnElts { get; set; }
        
        public DbSet<BsnSprt> BsnSprts { get; set; }
        
        public DbSet<BsnPrt> BsnPrts { get; set; }
        
        public DbSet<BsnGrp> BsnGrps { get; set; }
        
        public DbSet<BsnInsp> BsnInsps { get; set; }
        
        public DbSet<BsnEltInsp> BsnEltInsps { get; set; }
        
        public DbSet<BsnPhotoEltInsp> BsnPhotoEltInsps { get; set; }
        
        public DbSet<BsnCamp> BsnCamps { get; set; }
        
        public DbSet<BsnCdMeteo> BsnCdMeteos { get; set; }
        
        public DbSet<BsnCdPresta> BsnCdPrestas { get; set; }
        
        public DbSet<BsnTravaux> BsnTravauxs { get; set; }
        
        public DbSet<BsnNatureTrav> BsnNatureTravs { get; set; }
        
        public DbSet<BsnCdPermeable> BsnCdPermeables { get; set; }
        
        public DbSet<BsnSysUser> BsnSysUsers { get; set; }
        
        public DbSet<BsnCdTypePv> BsnCdTypePvs { get; set; }
        
        public DbSet<BsnCdEtude> BsnCdEtudes { get; set; }
        
        public DbSet<BsnBpu> BsnBpus { get; set; }
        
        public DbSet<BsnCdContrainte> BsnCdContraintes { get; set; }
        
        public DbSet<BsnCdTravaux> BsnCdTravauxs { get; set; }
        
        public DbSet<BsnCdExt> BsnCdExts { get; set; }
        
        public DbSet<BsnSeuilQualite> BsnSeuilQualites { get; set; }
        
        public DbSet<BsnSeuilUrgence> BsnSeuilUrgences { get; set; }
        
        public DbSet<BsnPrevision> BsnPrevisions { get; set; }
        
        public DbSet<BsnVst> BsnVsts { get; set; }
        
        public DbSet<BsnSprtVst> BsnSprtVsts { get; set; }
        
        public DbSet<BsnPhotoSprtVst> BsnPhotoSprtVsts { get; set; }
        
        public DbSet<BsnPhotoVst> BsnPhotoVsts { get; set; }
        
        public DbSet<BsnPhotoInsp> BsnPhotoInsps { get; set; }
        
        public DbSet<BsnCdQualite> BsnCdQualites { get; set; }
        
        public DbSet<BsnHistoNote> BsnHistoNotes { get; set; }
        
        public DbSet<BsnCdOrigin> BsnCdOrigins { get; set; }
        
        public DbSet<BsnDictionnaire> BsnDictionnaires { get; set; }
        
        public DbSet<BsnCdEvt> BsnCdEvts { get; set; }
        
        public DbSet<BsnEvt> BsnEvts { get; set; }
        
        public DbSet<BsnImpluvium> BsnImpluviums { get; set; }
        
        public DbSet<BsnGeometrie> BsnGeometries { get; set; }
        
        public DbSet<BsnCdAcces> BsnCdAccess { get; set; }
        
        public DbSet<BsnCdEntete> BsnCdEntetes { get; set; }
        
        public DbSet<BsnCdChapitre> BsnCdChapitres { get; set; }
        
        public DbSet<BsnCdLigne> BsnCdLignes { get; set; }
        
        public DbSet<BsnEntete> BsnEntetes { get; set; }
        
        public DbSet<BsnCdTypeqp> BsnCdTypeqps { get; set; }
        
        public DbSet<BsnCdFameqp> BsnCdFameqps { get; set; }
        
        public DbSet<BsnEquipement> BsnEquipements { get; set; }
        
        public DbSet<BsnContact> BsnContacts { get; set; }
        
        public DbSet<BsnCdUnite> BsnCdUnites { get; set; }
        
        public DbSet<BsnInspecteur> BsnInspecteurs { get; set; }
        
        public DbSet<BsnCdComposant> BsnCdComposants { get; set; }
        
        public DbSet<BsnCdSousType> BsnCdSousTypes { get; set; }
        
        public DbSet<BsnCdFrequence> BsnCdFrequences { get; set; }
        
        public DbSet<BsnCdRole> BsnCdRoles { get; set; }
        
        public DbSet<BsnCdConclusion> BsnCdConclusions { get; set; }
        
        public DbSet<BsnDscTemp> BsnDscTemps { get; set; }
        
        public DbSet<BsnPhotoInspTmp> BsnPhotoInspTmps { get; set; }
        
        public DbSet<BsnPhotoEltInspTmp> BsnPhotoEltInspTmps { get; set; }
        
        public DbSet<BsnEltInspTmp> BsnEltInspTmps { get; set; }
        
        public DbSet<BsnInspTmp> BsnInspTmps { get; set; }
        
        public DbSet<BsnClsDoc> BsnClsDocs { get; set; }
        
        public DbSet<BsnCdConclusionInsp> BsnCdConclusionInsps { get; set; }
        
        public DbSet<BsnDscCamp> BsnDscCamps { get; set; }
        
        public DbSet<BsnCdPrecoSprtVst> BsnCdPrecoSprtVsts { get; set; }
        
        public DbSet<BsnCdRoleDsc> BsnCdRoleDscs { get; set; }
        
        public DbSet<BsnCdConclusionInspTmp> BsnCdConclusionInspTmps { get; set; }
        
        public DbSet<ChsCdCou> ChsCdCous { get; set; }
        
        public DbSet<ChsCdEntp> ChsCdEntps { get; set; }
        
        public DbSet<ChsCdTech> ChsCdTechs { get; set; }
        
        public DbSet<ChsPave> ChsPaves { get; set; }
        
        public DbSet<ChsCdCause> ChsCdCauses { get; set; }
        
        public DbSet<ChsCls> ChsClss { get; set; }
        
        public DbSet<ChsCdDoc> ChsCdDocs { get; set; }
        
        public DbSet<ChsDoc> ChsDocs { get; set; }
        
        public DbSet<ChsMatPave> ChsMatPaves { get; set; }
        
        public DbSet<ChsFabCar> ChsFabCars { get; set; }
        
        public DbSet<ChsMat> ChsMats { get; set; }
        
        public DbSet<ChsParamsis> ChsParamsiss { get; set; }
        
        public DbSet<ChsCdMesure> ChsCdMesures { get; set; }
        
        public DbSet<ChsCdIndic> ChsCdIndics { get; set; }
        
        public DbSet<ChsCdSeuil> ChsCdSeuils { get; set; }
        
        public DbSet<ChsCamp> ChsCamps { get; set; }
        
        public DbSet<ChsClCamp> ChsClCamps { get; set; }
        
        public DbSet<ChsMesure> ChsMesures { get; set; }
        
        public DbSet<ChsAgrege> ChsAgreges { get; set; }
        
        public DbSet<ChsCdFamCar> ChsCdFamCars { get; set; }
        
        public DbSet<ChsSysUser> ChsSysUsers { get; set; }
        
        public DbSet<ChsCdFamTech> ChsCdFamTechs { get; set; }
        
        public DbSet<ChsCdOrig> ChsCdOrigs { get; set; }
        
        public DbSet<ChsCdMat> ChsCdMats { get; set; }
        
        public DbSet<ChsCdAgrege> ChsCdAgreges { get; set; }
        
        public DbSet<ChsPrevision> ChsPrevisions { get; set; }
        
        public DbSet<ChsCdContrainte> ChsCdContraintes { get; set; }
        
        public DbSet<ChsBpu> ChsBpus { get; set; }
        
        public DbSet<ChsCdTravaux> ChsCdTravauxs { get; set; }
        
        public DbSet<ChsPlateforme> ChsPlateformes { get; set; }
        
        public DbSet<ChsCdPortance> ChsCdPortances { get; set; }
        
        public DbSet<ChsCdMpa> ChsCdMpas { get; set; }
        
        public DbSet<ChsCdMo> ChsCdMos { get; set; }
        
        public DbSet<ChsSousCouche> ChsSousCouches { get; set; }
        
        public DbSet<ChsClCarotte> ChsClCarottes { get; set; }
        
        public DbSet<ChsDetailCarotte> ChsDetailCarottes { get; set; }
        
        public DbSet<ChsExploitCarotte> ChsExploitCarottes { get; set; }
        
        public DbSet<ChsFamCar> ChsFamCars { get; set; }
        
        public DbSet<ChsClRoul> ChsClRouls { get; set; }
        
        public DbSet<ChsZh> ChsZhs { get; set; }
        
        public DbSet<ChsDetailCamp> ChsDetailCamps { get; set; }
        
        public DbSet<ChsPaveVoie> ChsPaveVoies { get; set; }
        
        public DbSet<ChsClPaveVoie> ChsClPaveVoies { get; set; }
        
        public DbSet<ChsDictionnaire> ChsDictionnaires { get; set; }
        
        public DbSet<ChsCdEvt> ChsCdEvts { get; set; }
        
        public DbSet<ChsEvt> ChsEvts { get; set; }
        
        public DbSet<ChsCdPosit> ChsCdPosits { get; set; }
        
        public DbSet<ChsNeAdmin> ChsNeAdmins { get; set; }
        
        public DbSet<ChsContact> ChsContacts { get; set; }
        
        public DbSet<ChsClsDoc> ChsClsDocs { get; set; }
        
        public DbSet<DsMat> DsMats { get; set; }
        
        public DbSet<DsPon> DsPons { get; set; }
        
        public DbSet<DsMatParam> DsMatParams { get; set; }
        
        public DbSet<DsPonParam> DsPonParams { get; set; }
        
        public DbSet<DsTree> DsTrees { get; set; }
        
        public DbSet<DsNode> DsNodes { get; set; }
        
        public DbSet<DsNodeParam> DsNodeParams { get; set; }
        
        public DbSet<DsBpuColor> DsBpuColors { get; set; }
        
        public DbSet<DsTreeResultPave> DsTreeResultPaves { get; set; }
        
        public DbSet<DsTreeResultPaveVoie> DsTreeResultPaveVoies { get; set; }
        
        public DbSet<DsTreeResult> DsTreeResults { get; set; }
        
        public DbSet<DsSimDvp> DsSimDvps { get; set; }
        
        public DbSet<DsSimRec> DsSimRecs { get; set; }
        
        public DbSet<DsSimFis> DsSimFiss { get; set; }
        
        public DbSet<DsSimFisClasse> DsSimFisClasses { get; set; }
        
        public DbSet<DsSimRecValues> DsSimRecValuess { get; set; }
        
        public DbSet<DsSimDvpValues> DsSimDvpValuess { get; set; }
        
        public DbSet<DsSimFisValues> DsSimFisValuess { get; set; }
        
        public DbSet<DsSimCalculTrafic> DsSimCalculTrafics { get; set; }
        
        public DbSet<DsSimResult> DsSimResults { get; set; }
        
        public DbSet<DsSimCalculFis> DsSimCalculFiss { get; set; }
        
        public DbSet<DsSimEntretien> DsSimEntretiens { get; set; }
        
        public DbSet<DsSimEtude> DsSimEtudes { get; set; }
        
        public DbSet<DsSimCalcul> DsSimCalculs { get; set; }
        
        public DbSet<DsTraficColor> DsTraficColors { get; set; }
        
        public DbSet<DsAgrege> DsAgreges { get; set; }
        
        public DbSet<EqpCdTypeSv> EqpCdTypeSvs { get; set; }
        
        public DbSet<EqpCdFamSv> EqpCdFamSvs { get; set; }
        
        public DbSet<EqpCls> EqpClss { get; set; }
        
        public DbSet<EqpDoc> EqpDocs { get; set; }
        
        public DbSet<EqpCdDoc> EqpCdDocs { get; set; }
        
        public DbSet<EqpNatureTrav> EqpNatureTravs { get; set; }
        
        public DbSet<EqpSysUser> EqpSysUsers { get; set; }
        
        public DbSet<EqpBpu> EqpBpus { get; set; }
        
        public DbSet<EqpCdTravaux> EqpCdTravauxs { get; set; }
        
        public DbSet<EqpCdStypeSv> EqpCdStypeSvs { get; set; }
        
        public DbSet<EqpDictionnaire> EqpDictionnaires { get; set; }
        
        public DbSet<EqpCdEvt> EqpCdEvts { get; set; }
        
        public DbSet<EqpDscSv> EqpDscSvs { get; set; }
        
        public DbSet<EqpCdFabricant> EqpCdFabricants { get; set; }
        
        public DbSet<EqpCdProtect> EqpCdProtects { get; set; }
        
        public DbSet<EqpCdClasseSv> EqpCdClasseSvs { get; set; }
        
        public DbSet<EqpCdGammeSv> EqpCdGammeSvs { get; set; }
        
        public DbSet<EqpCdSupportSv> EqpCdSupportSvs { get; set; }
        
        public DbSet<EqpCdFondation> EqpCdFondations { get; set; }
        
        public DbSet<EqpDscSh> EqpDscShs { get; set; }
        
        public DbSet<EqpDscEs> EqpDscEss { get; set; }
        
        public DbSet<EqpCdProduitSh> EqpCdProduitShs { get; set; }
        
        public DbSet<EqpCdBarretteSh> EqpCdBarretteShs { get; set; }
        
        public DbSet<EqpCdMarquageSh> EqpCdMarquageShs { get; set; }
        
        public DbSet<EqpCdModSh> EqpCdModShs { get; set; }
        
        public DbSet<EqpCdType> EqpCdTypes { get; set; }
        
        public DbSet<EqpCdRetenue> EqpCdRetenues { get; set; }
        
        public DbSet<EqpCdMateriau> EqpCdMateriaus { get; set; }
        
        public DbSet<EqpCdExtAm> EqpCdExtAms { get; set; }
        
        public DbSet<EqpCdExtAv> EqpCdExtAvs { get; set; }
        
        public DbSet<EqpDscPo> EqpDscPos { get; set; }
        
        public DbSet<EqpCdPortail> EqpCdPortails { get; set; }
        
        public DbSet<EqpDscCl> EqpDscCls { get; set; }
        
        public DbSet<EqpCdCloture> EqpCdClotures { get; set; }
        
        public DbSet<EqpCdMaille> EqpCdMailles { get; set; }
        
        public DbSet<EqpCdFranch> EqpCdFranchs { get; set; }
        
        public DbSet<EqpCdPoteauCl> EqpCdPoteauCls { get; set; }
        
        public DbSet<EqpPanneau> EqpPanneaus { get; set; }
        
        public DbSet<EqpTravaux> EqpTravauxs { get; set; }
        
        public DbSet<EqpPrevision> EqpPrevisions { get; set; }
        
        public DbSet<EqpEvt> EqpEvts { get; set; }
        
        public DbSet<EqpCdEntp> EqpCdEntps { get; set; }
        
        public DbSet<EqpCdPosit> EqpCdPosits { get; set; }
        
        public DbSet<EqpCdMatSv> EqpCdMatSvs { get; set; }
        
        public DbSet<EqpCdContrainte> EqpCdContraintes { get; set; }
        
        public DbSet<EqpCdTypeDv> EqpCdTypeDvs { get; set; }
        
        public DbSet<EqpDscDv> EqpDscDvs { get; set; }
        
        public DbSet<EqpContact> EqpContacts { get; set; }
        
        public DbSet<EqpClsDoc> EqpClsDocs { get; set; }
        
        public DbSet<GmsCdType> GmsCdTypes { get; set; }
        
        public DbSet<GmsCdFam> GmsCdFams { get; set; }
        
        public DbSet<GmsCdEntp> GmsCdEntps { get; set; }
        
        public DbSet<GmsDsc> GmsDscs { get; set; }
        
        public DbSet<GmsCls> GmsClss { get; set; }
        
        public DbSet<GmsDoc> GmsDocs { get; set; }
        
        public DbSet<GmsCdDoc> GmsCdDocs { get; set; }
        
        public DbSet<GmsElt> GmsElts { get; set; }
        
        public DbSet<GmsSprt> GmsSprts { get; set; }
        
        public DbSet<GmsPrt> GmsPrts { get; set; }
        
        public DbSet<GmsGrp> GmsGrps { get; set; }
        
        public DbSet<GmsEltInsp> GmsEltInsps { get; set; }
        
        public DbSet<GmsCdMeteo> GmsCdMeteos { get; set; }
        
        public DbSet<GmsTravaux> GmsTravauxs { get; set; }
        
        public DbSet<GmsNatureTrav> GmsNatureTravs { get; set; }
        
        public DbSet<GmsCdTravaux> GmsCdTravauxs { get; set; }
        
        public DbSet<GmsCdPoutre> GmsCdPoutres { get; set; }
        
        public DbSet<GmsPrevision> GmsPrevisions { get; set; }
        
        public DbSet<GmsCdAncrage> GmsCdAncrages { get; set; }
        
        public DbSet<GmsPanneau> GmsPanneaus { get; set; }
        
        public DbSet<GmsCdPanneau> GmsCdPanneaus { get; set; }
        
        public DbSet<GmsCdAcces> GmsCdAccess { get; set; }
        
        public DbSet<GmsSysUser> GmsSysUsers { get; set; }
        
        public DbSet<GmsBpu> GmsBpus { get; set; }
        
        public DbSet<GmsCdContrainte> GmsCdContraintes { get; set; }
        
        public DbSet<GmsCamp> GmsCamps { get; set; }
        
        public DbSet<GmsCdPresta> GmsCdPrestas { get; set; }
        
        public DbSet<GmsCdTypePv> GmsCdTypePvs { get; set; }
        
        public DbSet<GmsPhotoEltInsp> GmsPhotoEltInsps { get; set; }
        
        public DbSet<GmsInsp> GmsInsps { get; set; }
        
        public DbSet<GmsPhotoInsp> GmsPhotoInsps { get; set; }
        
        public DbSet<GmsCdEtude> GmsCdEtudes { get; set; }
        
        public DbSet<GmsSeuilQualite> GmsSeuilQualites { get; set; }
        
        public DbSet<GmsSeuilUrgence> GmsSeuilUrgences { get; set; }
        
        public DbSet<GmsSprtVst> GmsSprtVsts { get; set; }
        
        public DbSet<GmsPhotoSprtVst> GmsPhotoSprtVsts { get; set; }
        
        public DbSet<GmsPhotoVst> GmsPhotoVsts { get; set; }
        
        public DbSet<GmsCdPosPan> GmsCdPosPans { get; set; }
        
        public DbSet<GmsCdPosMat> GmsCdPosMats { get; set; }
        
        public DbSet<GmsCdQualite> GmsCdQualites { get; set; }
        
        public DbSet<GmsCdProtec> GmsCdProtecs { get; set; }
        
        public DbSet<GmsHistoNote> GmsHistoNotes { get; set; }
        
        public DbSet<GmsCdOrigin> GmsCdOrigins { get; set; }
        
        public DbSet<GmsDictionnaire> GmsDictionnaires { get; set; }
        
        public DbSet<GmsCdEvt> GmsCdEvts { get; set; }
        
        public DbSet<GmsEvt> GmsEvts { get; set; }
        
        public DbSet<GmsCdInterface> GmsCdInterfaces { get; set; }
        
        public DbSet<GmsCdFournisseur> GmsCdFournisseurs { get; set; }
        
        public DbSet<GmsCdPoteau> GmsCdPoteaus { get; set; }
        
        public DbSet<GmsCdEntete> GmsCdEntetes { get; set; }
        
        public DbSet<GmsCdChapitre> GmsCdChapitres { get; set; }
        
        public DbSet<GmsCdLigne> GmsCdLignes { get; set; }
        
        public DbSet<GmsEntete> GmsEntetes { get; set; }
        
        public DbSet<GmsContact> GmsContacts { get; set; }
        
        public DbSet<GmsCdUnite> GmsCdUnites { get; set; }
        
        public DbSet<GmsInspecteur> GmsInspecteurs { get; set; }
        
        public DbSet<GmsCdComposant> GmsCdComposants { get; set; }
        
        public DbSet<GmsVst> GmsVsts { get; set; }
        
        public DbSet<GmsCdConclusion> GmsCdConclusions { get; set; }
        
        public DbSet<GmsDscTemp> GmsDscTemps { get; set; }
        
        public DbSet<GmsEltInspTmp> GmsEltInspTmps { get; set; }
        
        public DbSet<GmsPhotoEltInspTmp> GmsPhotoEltInspTmps { get; set; }
        
        public DbSet<GmsInspTmp> GmsInspTmps { get; set; }
        
        public DbSet<GmsPhotoInspTmp> GmsPhotoInspTmps { get; set; }
        
        public DbSet<GmsClsDoc> GmsClsDocs { get; set; }
        
        public DbSet<GmsDscCamp> GmsDscCamps { get; set; }
        
        public DbSet<GmsCdPrecoSprtVst> GmsCdPrecoSprtVsts { get; set; }
        
        public DbSet<GmsCdConclusionInsp> GmsCdConclusionInsps { get; set; }
        
        public DbSet<GmsCdConclusionInspTmp> GmsCdConclusionInspTmps { get; set; }
        
        public DbSet<GotCdEntp> GotCdEntps { get; set; }
        
        public DbSet<GotDsc> GotDscs { get; set; }
        
        public DbSet<GotCls> GotClss { get; set; }
        
        public DbSet<GotDoc> GotDocs { get; set; }
        
        public DbSet<GotCdDoc> GotCdDocs { get; set; }
        
        public DbSet<GotElt> GotElts { get; set; }
        
        public DbSet<GotPrt> GotPrts { get; set; }
        
        public DbSet<GotGrp> GotGrps { get; set; }
        
        public DbSet<GotEltInsp> GotEltInsps { get; set; }
        
        public DbSet<GotPhotoEltInsp> GotPhotoEltInsps { get; set; }
        
        public DbSet<GotCamp> GotCamps { get; set; }
        
        public DbSet<GotCdMeteo> GotCdMeteos { get; set; }
        
        public DbSet<GotCdPresta> GotCdPrestas { get; set; }
        
        public DbSet<GotTravaux> GotTravauxs { get; set; }
        
        public DbSet<GotNatureTrav> GotNatureTravs { get; set; }
        
        public DbSet<GotCdTravaux> GotCdTravauxs { get; set; }
        
        public DbSet<GotCdFam> GotCdFams { get; set; }
        
        public DbSet<GotCdPente> GotCdPentes { get; set; }
        
        public DbSet<GotCdProtect> GotCdProtects { get; set; }
        
        public DbSet<GotCdGeo> GotCdGeos { get; set; }
        
        public DbSet<GotCdMateriau> GotCdMateriaus { get; set; }
        
        public DbSet<GotCdHydrique> GotCdHydriques { get; set; }
        
        public DbSet<GotCdTraitement> GotCdTraitements { get; set; }
        
        public DbSet<GotSprt> GotSprts { get; set; }
        
        public DbSet<GotSysUser> GotSysUsers { get; set; }
        
        public DbSet<GotCdTypePv> GotCdTypePvs { get; set; }
        
        public DbSet<GotInsp> GotInsps { get; set; }
        
        public DbSet<GotCdCouche> GotCdCouches { get; set; }
        
        public DbSet<GotCdCompactage> GotCdCompactages { get; set; }
        
        public DbSet<GotCdEtude> GotCdEtudes { get; set; }
        
        public DbSet<GotSeuilQualite> GotSeuilQualites { get; set; }
        
        public DbSet<GotSeuilUrgence> GotSeuilUrgences { get; set; }
        
        public DbSet<GotVst> GotVsts { get; set; }
        
        public DbSet<GotPhotoSprtVst> GotPhotoSprtVsts { get; set; }
        
        public DbSet<GotBpu> GotBpus { get; set; }
        
        public DbSet<GotPrevision> GotPrevisions { get; set; }
        
        public DbSet<GotCdContrainte> GotCdContraintes { get; set; }
        
        public DbSet<GotPhotoInsp> GotPhotoInsps { get; set; }
        
        public DbSet<GotPhotoVst> GotPhotoVsts { get; set; }
        
        public DbSet<GotCdQualite> GotCdQualites { get; set; }
        
        public DbSet<GotHistoNote> GotHistoNotes { get; set; }
        
        public DbSet<GotCdOrigin> GotCdOrigins { get; set; }
        
        public DbSet<GotCdRisque> GotCdRisques { get; set; }
        
        public DbSet<GotDictionnaire> GotDictionnaires { get; set; }
        
        public DbSet<GotCdType> GotCdTypes { get; set; }
        
        public DbSet<GotCdEvt> GotCdEvts { get; set; }
        
        public DbSet<GotEvt> GotEvts { get; set; }
        
        public DbSet<GotCdLigne> GotCdLignes { get; set; }
        
        public DbSet<GotCdChapitre> GotCdChapitres { get; set; }
        
        public DbSet<GotSprtVst> GotSprtVsts { get; set; }
        
        public DbSet<GotCdEntete> GotCdEntetes { get; set; }
        
        public DbSet<GotEntete> GotEntetes { get; set; }
        
        public DbSet<GotContact> GotContacts { get; set; }
        
        public DbSet<GotCdComposant> GotCdComposants { get; set; }
        
        public DbSet<GotInspecteur> GotInspecteurs { get; set; }
        
        public DbSet<GotCdUnite> GotCdUnites { get; set; }
        
        public DbSet<GotCdConclusion> GotCdConclusions { get; set; }
        
        public DbSet<GotDscTemp> GotDscTemps { get; set; }
        
        public DbSet<GotEltInspTmp> GotEltInspTmps { get; set; }
        
        public DbSet<GotPhotoEltInspTmp> GotPhotoEltInspTmps { get; set; }
        
        public DbSet<GotInspTmp> GotInspTmps { get; set; }
        
        public DbSet<GotPhotoInspTmp> GotPhotoInspTmps { get; set; }
        
        public DbSet<GotClsDoc> GotClsDocs { get; set; }
        
        public DbSet<GotCouche> GotCouches { get; set; }
        
        public DbSet<GotDscCamp> GotDscCamps { get; set; }
        
        public DbSet<GotCdPrecoSprtVst> GotCdPrecoSprtVsts { get; set; }
        
        public DbSet<GotCdConclusionInsp> GotCdConclusionInsps { get; set; }
        
        public DbSet<GotCdConclusionInspTmp> GotCdConclusionInspTmps { get; set; }
        
        public DbSet<InfLiaison> InfLiaisons { get; set; }
        
        public DbSet<InfCdLiaison> InfCdLiaisons { get; set; }
        
        public DbSet<InfChaussee> InfChaussees { get; set; }
        
        public DbSet<InfPtSing> InfPtSings { get; set; }
        
        public DbSet<InfCdPtSing> InfCdPtSings { get; set; }
        
        public DbSet<InfCls> InfClss { get; set; }
        
        public DbSet<InfCdDoc> InfCdDocs { get; set; }
        
        public DbSet<InfDoc> InfDocs { get; set; }
        
        public DbSet<InfCdDec> InfCdDecs { get; set; }
        
        public DbSet<InfFamDec> InfFamDecs { get; set; }
        
        public DbSet<InfTrDec> InfTrDecs { get; set; }
        
        public DbSet<InfTpc> InfTpcs { get; set; }
        
        public DbSet<InfCdTpc> InfCdTpcs { get; set; }
        
        public DbSet<InfDictionnaire> InfDictionnaires { get; set; }
        
        public DbSet<InfRepere> InfReperes { get; set; }
        
        public DbSet<InfPrevSge> InfPrevSges { get; set; }
        
        public DbSet<InfPk> InfPks { get; set; }
        
        public DbSet<InfPrOld> InfPrOlds { get; set; }
        
        public DbSet<InfSysUser> InfSysUsers { get; set; }
        
        public DbSet<InfSensible> InfSensibles { get; set; }
        
        public DbSet<InfCdSensible> InfCdSensibles { get; set; }
        
        public DbSet<InfClim> InfClims { get; set; }
        
        public DbSet<InfCdClim> InfCdClims { get; set; }
        
        public DbSet<InfAmenagement> InfAmenagements { get; set; }
        
        public DbSet<InfCdAmenag> InfCdAmenags { get; set; }
        
        public DbSet<InfAccident> InfAccidents { get; set; }
        
        public DbSet<InfDscOa> InfDscOas { get; set; }
        
        public DbSet<InfCorrespondance> InfCorrespondances { get; set; }
        
        public DbSet<InfCdPosit> InfCdPosits { get; set; }
        
        public DbSet<InfSecurite> InfSecurites { get; set; }
        
        public DbSet<InfEclairage> InfEclairages { get; set; }
        
        public DbSet<InfCdSecur> InfCdSecurs { get; set; }
        
        public DbSet<InfCdEclair> InfCdEclairs { get; set; }
        
        public DbSet<InfOccupation> InfOccupations { get; set; }
        
        public DbSet<InfCdOccup> InfCdOccups { get; set; }
        
        public DbSet<InfCdOccupant> InfCdOccupants { get; set; }
        
        public DbSet<InfTalus> InfTaluss { get; set; }
        
        public DbSet<InfCdTalus> InfCdTaluss { get; set; }
        
        public DbSet<InfWgs> InfWgss { get; set; }
        
        public DbSet<InfCdVoie> InfCdVoies { get; set; }
        
        public DbSet<InfPaveVoie> InfPaveVoies { get; set; }
        
        public DbSet<InfClVoie> InfClVoies { get; set; }
        
        public DbSet<InfTrafic> InfTrafics { get; set; }
        
        public DbSet<InfSectionTrafic> InfSectionTrafics { get; set; }
        
        public DbSet<InfCdClassTraf> InfCdClassTrafs { get; set; }
        
        public DbSet<InfRepartitionTrafic> InfRepartitionTrafics { get; set; }
        
        public DbSet<InfGare> InfGares { get; set; }
        
        public DbSet<InfCdGare> InfCdGares { get; set; }
        
        public DbSet<InfAire> InfAires { get; set; }
        
        public DbSet<InfCdAire> InfCdAires { get; set; }
        
        public DbSet<InfCdPrestataire> InfCdPrestataires { get; set; }
        
        public DbSet<InfPrestataire> InfPrestataires { get; set; }
        
        public DbSet<InfCdService> InfCdServices { get; set; }
        
        public DbSet<InfCdBif> InfCdBifs { get; set; }
        
        public DbSet<InfBifurcation> InfBifurcations { get; set; }
        
        public DbSet<InfBretelle> InfBretelles { get; set; }
        
        public DbSet<InfCdPlace> InfCdPlaces { get; set; }
        
        public DbSet<InfCdEvt> InfCdEvts { get; set; }
        
        public DbSet<InfEvt> InfEvts { get; set; }
        
        public DbSet<InfContact> InfContacts { get; set; }
        
        public DbSet<InfClsDoc> InfClsDocs { get; set; }
        
        public DbSet<InfAirePrestataire> InfAirePrestataires { get; set; }
        
        public DbSet<InfAireService> InfAireServices { get; set; }
        
        public DbSet<InfAirePlace> InfAirePlaces { get; set; }
        
        public DbSet<OaCdFam> OaCdFams { get; set; }
        
        public DbSet<OaCdType> OaCdTypes { get; set; }
        
        public DbSet<OaCdEntp> OaCdEntps { get; set; }
        
        public DbSet<OaDsc> OaDscs { get; set; }
        
        public DbSet<OaCdCharge> OaCdCharges { get; set; }
        
        public DbSet<OaCdFond> OaCdFonds { get; set; }
        
        public DbSet<OaCdFamAppui> OaCdFamAppuis { get; set; }
        
        public DbSet<OaCdAppui> OaCdAppuis { get; set; }
        
        public DbSet<OaCdAppAppui> OaCdAppAppuis { get; set; }
        
        public DbSet<OaCdChape> OaCdChapes { get; set; }
        
        public DbSet<OaTablier> OaTabliers { get; set; }
        
        public DbSet<OaCdDpr> OaCdDprs { get; set; }
        
        public DbSet<OaEquipement> OaEquipements { get; set; }
        
        public DbSet<OaCdGc> OaCdGcs { get; set; }
        
        public DbSet<OaJoint> OaJoints { get; set; }
        
        public DbSet<OaCdJoint> OaCdJoints { get; set; }
        
        public DbSet<OaCdTablier> OaCdTabliers { get; set; }
        
        public DbSet<OaCdMat> OaCdMats { get; set; }
        
        public DbSet<OaCls> OaClss { get; set; }
        
        public DbSet<OaDoc> OaDocs { get; set; }
        
        public DbSet<OaCdDoc> OaCdDocs { get; set; }
        
        public DbSet<OaSysUser> OaSysUsers { get; set; }
        
        public DbSet<OaCdBe> OaCdBes { get; set; }
        
        public DbSet<OaCdGest> OaCdGests { get; set; }
        
        public DbSet<OaElt> OaElts { get; set; }
        
        public DbSet<OaSprt> OaSprts { get; set; }
        
        public DbSet<OaPrt> OaPrts { get; set; }
        
        public DbSet<OaGrp> OaGrps { get; set; }
        
        public DbSet<OaInsp> OaInsps { get; set; }
        
        public DbSet<OaEltInsp> OaEltInsps { get; set; }
        
        public DbSet<OaPhotoEltInsp> OaPhotoEltInsps { get; set; }
        
        public DbSet<OaCamp> OaCamps { get; set; }
        
        public DbSet<OaCdMeteo> OaCdMeteos { get; set; }
        
        public DbSet<OaCdPresta> OaCdPrestas { get; set; }
        
        public DbSet<OaTravaux> OaTravauxs { get; set; }
        
        public DbSet<OaNatureTrav> OaNatureTravs { get; set; }
        
        public DbSet<OaCdIqoa> OaCdIqoas { get; set; }
        
        public DbSet<OaCdMo> OaCdMos { get; set; }
        
        public DbSet<OaBpu> OaBpus { get; set; }
        
        public DbSet<OaCdTravaux> OaCdTravauxs { get; set; }
        
        public DbSet<OaCdTech> OaCdTechs { get; set; }
        
        public DbSet<OaCdOrigin> OaCdOrigins { get; set; }
        
        public DbSet<OaHistoNote> OaHistoNotes { get; set; }
        
        public DbSet<OaCdEvt> OaCdEvts { get; set; }
        
        public DbSet<OaEvt> OaEvts { get; set; }
        
        public DbSet<OaPrevision> OaPrevisions { get; set; }
        
        public DbSet<OaCdContrainte> OaCdContraintes { get; set; }
        
        public DbSet<OaSeuilUrgence> OaSeuilUrgences { get; set; }
        
        public DbSet<OaDictionnaire> OaDictionnaires { get; set; }
        
        public DbSet<OaPhotoInsp> OaPhotoInsps { get; set; }
        
        public DbSet<OaCdEtude> OaCdEtudes { get; set; }
        
        public DbSet<OaCdTypePv> OaCdTypePvs { get; set; }
        
        public DbSet<OaCdQualite> OaCdQualites { get; set; }
        
        public DbSet<OaPhotoVst> OaPhotoVsts { get; set; }
        
        public DbSet<OaSprtVst> OaSprtVsts { get; set; }
        
        public DbSet<OaPhotoSprtVst> OaPhotoSprtVsts { get; set; }
        
        public DbSet<OaVst> OaVsts { get; set; }
        
        public DbSet<OaCdHierarchie> OaCdHierarchies { get; set; }
        
        public DbSet<OaCdEntete> OaCdEntetes { get; set; }
        
        public DbSet<OaCdChapitre> OaCdChapitres { get; set; }
        
        public DbSet<OaCdLigne> OaCdLignes { get; set; }
        
        public DbSet<OaEntete> OaEntetes { get; set; }
        
        public DbSet<OaContact> OaContacts { get; set; }
        
        public DbSet<OaInspecteur> OaInspecteurs { get; set; }
        
        public DbSet<OaCdUnite> OaCdUnites { get; set; }
        
        public DbSet<OaCdComposant> OaCdComposants { get; set; }
        
        public DbSet<OaCdConclusion> OaCdConclusions { get; set; }
        
        public DbSet<OaDscTemp> OaDscTemps { get; set; }
        
        public DbSet<OaInspTmp> OaInspTmps { get; set; }
        
        public DbSet<OaEltInspTmp> OaEltInspTmps { get; set; }
        
        public DbSet<OaPhotoInspTmp> OaPhotoInspTmps { get; set; }
        
        public DbSet<OaPhotoEltInspTmp> OaPhotoEltInspTmps { get; set; }
        
        public DbSet<OaCdOccupant> OaCdOccupants { get; set; }
        
        public DbSet<OaOccupation> OaOccupations { get; set; }
        
        public DbSet<OaCdOccup> OaCdOccups { get; set; }
        
        public DbSet<OaArchive3> OaArchive3s { get; set; }
        
        public DbSet<OaClsDoc> OaClsDocs { get; set; }
        
        public DbSet<OaAppuis> OaAppuiss { get; set; }
        
        public DbSet<OaDscCamp> OaDscCamps { get; set; }
        
        public DbSet<OaCdPrecoSprtVst> OaCdPrecoSprtVsts { get; set; }
        
        public DbSet<OaCdConclusionInsp> OaCdConclusionInsps { get; set; }
        
        public DbSet<OaCdConclusionInspTmp> OaCdConclusionInspTmps { get; set; }
        
        public DbSet<OaDscArchive3> OaDscArchive3s { get; set; }
        
        public DbSet<OhCdType> OhCdTypes { get; set; }
        
        public DbSet<OhCdFam> OhCdFams { get; set; }
        
        public DbSet<OhCdEntp> OhCdEntps { get; set; }
        
        public DbSet<OhDsc> OhDscs { get; set; }
        
        public DbSet<OhCls> OhClss { get; set; }
        
        public DbSet<OhDoc> OhDocs { get; set; }
        
        public DbSet<OhCdDoc> OhCdDocs { get; set; }
        
        public DbSet<OhElt> OhElts { get; set; }
        
        public DbSet<OhSprt> OhSprts { get; set; }
        
        public DbSet<OhPrt> OhPrts { get; set; }
        
        public DbSet<OhGrp> OhGrps { get; set; }
        
        public DbSet<OhInsp> OhInsps { get; set; }
        
        public DbSet<OhEltInsp> OhEltInsps { get; set; }
        
        public DbSet<OhPhotoEltInsp> OhPhotoEltInsps { get; set; }
        
        public DbSet<OhCamp> OhCamps { get; set; }
        
        public DbSet<OhCdMeteo> OhCdMeteos { get; set; }
        
        public DbSet<OhCdPresta> OhCdPrestas { get; set; }
        
        public DbSet<OhTravaux> OhTravauxs { get; set; }
        
        public DbSet<OhNatureTrav> OhNatureTravs { get; set; }
        
        public DbSet<OhCdMat> OhCdMats { get; set; }
        
        public DbSet<OhCdExt> OhCdExts { get; set; }
        
        public DbSet<OhCdEau> OhCdEaus { get; set; }
        
        public DbSet<OhCdOuv> OhCdOuvs { get; set; }
        
        public DbSet<OhCdEcoul> OhCdEcouls { get; set; }
        
        public DbSet<OhCdProAv> OhCdProAvs { get; set; }
        
        public DbSet<OhSysUser> OhSysUsers { get; set; }
        
        public DbSet<OhCdProAm> OhCdProAms { get; set; }
        
        public DbSet<OhCdTypePv> OhCdTypePvs { get; set; }
        
        public DbSet<OhCdEtude> OhCdEtudes { get; set; }
        
        public DbSet<OhBpu> OhBpus { get; set; }
        
        public DbSet<OhCdContrainte> OhCdContraintes { get; set; }
        
        public DbSet<OhCdTravaux> OhCdTravauxs { get; set; }
        
        public DbSet<OhCdSousType> OhCdSousTypes { get; set; }
        
        public DbSet<OhSeuilQualite> OhSeuilQualites { get; set; }
        
        public DbSet<OhSeuilUrgence> OhSeuilUrgences { get; set; }
        
        public DbSet<OhPrevision> OhPrevisions { get; set; }
        
        public DbSet<OhVst> OhVsts { get; set; }
        
        public DbSet<OhSprtVst> OhSprtVsts { get; set; }
        
        public DbSet<OhPhotoSprtVst> OhPhotoSprtVsts { get; set; }
        
        public DbSet<OhPhotoVst> OhPhotoVsts { get; set; }
        
        public DbSet<OhPhotoInsp> OhPhotoInsps { get; set; }
        
        public DbSet<OhCdQualite> OhCdQualites { get; set; }
        
        public DbSet<OhCdNomEau> OhCdNomEaus { get; set; }
        
        public DbSet<OhHistoNote> OhHistoNotes { get; set; }
        
        public DbSet<OhCdOrigin> OhCdOrigins { get; set; }
        
        public DbSet<OhDictionnaire> OhDictionnaires { get; set; }
        
        public DbSet<OhCdEvt> OhCdEvts { get; set; }
        
        public DbSet<OhEvt> OhEvts { get; set; }
        
        public DbSet<OhCdTeteAm> OhCdTeteAms { get; set; }
        
        public DbSet<OhCdTeteAv> OhCdTeteAvs { get; set; }
        
        public DbSet<OhCdEntete> OhCdEntetes { get; set; }
        
        public DbSet<OhCdChapitre> OhCdChapitres { get; set; }
        
        public DbSet<OhCdLigne> OhCdLignes { get; set; }
        
        public DbSet<OhEntete> OhEntetes { get; set; }
        
        public DbSet<OhContact> OhContacts { get; set; }
        
        public DbSet<OhCdComposant> OhCdComposants { get; set; }
        
        public DbSet<OhInspecteur> OhInspecteurs { get; set; }
        
        public DbSet<OhCdUnite> OhCdUnites { get; set; }
        
        public DbSet<OhCdMo> OhCdMos { get; set; }
        
        public DbSet<OhCdConclusion> OhCdConclusions { get; set; }
        
        public DbSet<OhDscTemp> OhDscTemps { get; set; }
        
        public DbSet<OhInspTmp> OhInspTmps { get; set; }
        
        public DbSet<OhEltInspTmp> OhEltInspTmps { get; set; }
        
        public DbSet<OhPhotoEltInspTmp> OhPhotoEltInspTmps { get; set; }
        
        public DbSet<OhPhotoInspTmp> OhPhotoInspTmps { get; set; }
        
        public DbSet<OhClsDoc> OhClsDocs { get; set; }
        
        public DbSet<OhCdConclusionInsp> OhCdConclusionInsps { get; set; }
        
        public DbSet<OhDscCamp> OhDscCamps { get; set; }
        
        public DbSet<OhCdPrecoSprtVst> OhCdPrecoSprtVsts { get; set; }
        
        public DbSet<OhCdConclusionInspTmp> OhCdConclusionInspTmps { get; set; }
        
        public DbSet<PrfBmUser> PrfBmUsers { get; set; }
        
        public DbSet<PrfBmSchema> PrfBmSchemas { get; set; }
        
        public DbSet<PrfBmTable> PrfBmTables { get; set; }
        
        public DbSet<PrfBmProfil> PrfBmProfils { get; set; }
        
        public DbSet<PrfSysLang> PrfSysLangs { get; set; }
        
        public DbSet<PrfBmParam> PrfBmParams { get; set; }
        
        public DbSet<PrfBmProfilTable> PrfBmProfilTables { get; set; }
        
        public DbSet<PrfBmUserProfil> PrfBmUserProfils { get; set; }
        
        public DbSet<MapinfoTbGroupe> MapinfoTbGroupes { get; set; }
        
        public DbSet<MapinfoTbTemplate> MapinfoTbTemplates { get; set; }
        
        public DbSet<MapinfoTbTemplateCfg> MapinfoTbTemplateCfgs { get; set; }
        
        public DbSet<MapinfoTbGroupeCfg> MapinfoTbGroupeCfgs { get; set; }
        
        public DbSet<MapinfoTbMap> MapinfoTbMaps { get; set; }
        
        public DbSet<MapinfoCdMotsReserve> MapinfoCdMotsReserves { get; set; }
        
        public DbSet<MapinfoTbMapCfg> MapinfoTbMapCfgs { get; set; }
        
        public DbSet<MapinfoSysUser> MapinfoSysUsers { get; set; }
        
        public DbSet<MapinfoTbMapGeoStyle> MapinfoTbMapGeoStyles { get; set; }
        
        public DbSet<MapinfoTbModele> MapinfoTbModeles { get; set; }
        
        public DbSet<MapinfoTbModeleCfg> MapinfoTbModeleCfgs { get; set; }
        
        public DbSet<MapinfoTbAnaThema> MapinfoTbAnaThemas { get; set; }
        
        public DbSet<MapinfoSiModel> MapinfoSiModels { get; set; }
        
        public DbSet<MapinfoSiZone> MapinfoSiZones { get; set; }
        
        public DbSet<MapinfoSiStyleValeur> MapinfoSiStyleValeurs { get; set; }
        
        public DbSet<MapinfoTbMapMetier> MapinfoTbMapMetiers { get; set; }
        
        public DbSet<MapinfoTbMapMetierCfg> MapinfoTbMapMetierCfgs { get; set; }
        
        public DbSet<MapinfoTbMapMetierColumns> MapinfoTbMapMetierColumnss { get; set; }
        
        public DbSet<MapinfoSiModelPredef> MapinfoSiModelPredefs { get; set; }
        
        public DbSet<MapinfoSiPrp> MapinfoSiPrps { get; set; }
        
        public DbSet<WebNode> WebNodes { get; set; }
        
        public DbSet<WebCdNode> WebCdNodes { get; set; }
        
        public DbSet<WebNodeParam> WebNodeParams { get; set; }
        
        public DbSet<WebSysUser> WebSysUsers { get; set; }
        
        public DbSet<WebStyle> WebStyles { get; set; }
        
        public DbSet<WebStyleRule> WebStyleRules { get; set; }
        
        public DbSet<WebModele> WebModeles { get; set; }
        
        public DbSet<WebCdModele> WebCdModeles { get; set; }
        
        public DbSet<WebModeleWebNode> WebModeleWebNodes { get; set; }
        
        public DbSet<WebNodeWebStyle> WebNodeWebStyles { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BsnCdType>().ToTable("CD_TYPE_BSN","BSN");
            modelBuilder.Entity<BsnCdType>().HasKey(item => new {item.Type });
            modelBuilder.Entity<BsnCdType>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<BsnCdType>().Property(item => item.Type).HasMaxLength(60);
            modelBuilder.Entity<BsnCdType>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<BsnCdFam>().ToTable("CD_FAM_BSN","BSN");
            modelBuilder.Entity<BsnCdFam>().HasKey(item => new {item.Famille });
            modelBuilder.Entity<BsnCdFam>().Property(item => item.Famille).IsRequired();
            modelBuilder.Entity<BsnCdFam>().Property(item => item.Famille).HasMaxLength(60);
            modelBuilder.Entity<BsnCdFam>().Property(item => item.Famille).HasColumnName("FAMILLE");
            modelBuilder.Entity<BsnCdFam>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<BsnCdFam>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<BsnCdEntp>().ToTable("CD_ENTP_BSN","BSN");
            modelBuilder.Entity<BsnCdEntp>().HasKey(item => new {item.Entreprise });
            modelBuilder.Entity<BsnCdEntp>().Property(item => item.Entreprise).IsRequired();
            modelBuilder.Entity<BsnCdEntp>().Property(item => item.Entreprise).HasMaxLength(60);
            modelBuilder.Entity<BsnCdEntp>().Property(item => item.Entreprise).HasColumnName("ENTREPRISE");
            modelBuilder.Entity<BsnDsc>().ToTable("DSC_BSN","BSN");
            modelBuilder.Entity<BsnDsc>().HasKey(item => new {item.NumBsn });
            modelBuilder.Entity<BsnDsc>().Property(item => item.NumBsn).IsRequired();
            modelBuilder.Entity<BsnDsc>().Property(item => item.NumBsn).HasMaxLength(20);
            modelBuilder.Entity<BsnDsc>().Property(item => item.NumBsn).HasColumnName("NUM_BSN");
            modelBuilder.Entity<BsnDsc>().Property(item => item.CdAccesBsnVacces).HasMaxLength(60);
            modelBuilder.Entity<BsnDsc>().Property(item => item.CdAccesBsnVacces).HasColumnName("CD_ACCES_BSN__VACCES");
            modelBuilder.Entity<BsnDsc>().Property(item => item.CdPermeableBsnType).HasMaxLength(60);
            modelBuilder.Entity<BsnDsc>().Property(item => item.CdPermeableBsnType).HasColumnName("CD_PERMEABLE_BSN__TYPE");
            modelBuilder.Entity<BsnDsc>().Property(item => item.CdEntpBsnEntreprise).HasMaxLength(60);
            modelBuilder.Entity<BsnDsc>().Property(item => item.CdEntpBsnEntreprise).HasColumnName("CD_ENTP_BSN__ENTREPRISE");
            modelBuilder.Entity<BsnDsc>().Property(item => item.CdTypeBsnType).IsRequired();
            modelBuilder.Entity<BsnDsc>().Property(item => item.CdTypeBsnType).HasMaxLength(60);
            modelBuilder.Entity<BsnDsc>().Property(item => item.CdTypeBsnType).HasColumnName("CD_TYPE_BSN__TYPE");
            modelBuilder.Entity<BsnDsc>().Property(item => item.CdSousTypeBsnNatSensib).HasMaxLength(60);
            modelBuilder.Entity<BsnDsc>().Property(item => item.CdSousTypeBsnNatSensib).HasColumnName("CD_SOUS_TYPE_BSN__NAT_SENSIB");
            modelBuilder.Entity<BsnDsc>().Property(item => item.CdFrequenceBsnFreq).HasMaxLength(25);
            modelBuilder.Entity<BsnDsc>().Property(item => item.CdFrequenceBsnFreq).HasColumnName("CD_FREQUENCE_BSN__FREQ");
            modelBuilder.Entity<BsnDsc>().Property(item => item.CdQualiteBsnQualite).HasMaxLength(25);
            modelBuilder.Entity<BsnDsc>().Property(item => item.CdQualiteBsnQualite).HasColumnName("CD_QUALITE_BSN__QUALITE");
            modelBuilder.Entity<BsnDsc>().Property(item => item.CdExtBsnType).HasMaxLength(60);
            modelBuilder.Entity<BsnDsc>().Property(item => item.CdExtBsnType).HasColumnName("CD_EXT_BSN__TYPE");
            modelBuilder.Entity<BsnDsc>().Property(item => item.CdFamBsnFamille).IsRequired();
            modelBuilder.Entity<BsnDsc>().Property(item => item.CdFamBsnFamille).HasMaxLength(60);
            modelBuilder.Entity<BsnDsc>().Property(item => item.CdFamBsnFamille).HasColumnName("CD_FAM_BSN__FAMILLE");
            modelBuilder.Entity<BsnDsc>().Property(item => item.NumExploit).HasMaxLength(30);
            modelBuilder.Entity<BsnDsc>().Property(item => item.NumExploit).HasColumnName("NUM_EXPLOIT");
            modelBuilder.Entity<BsnDsc>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<BsnDsc>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<BsnDsc>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<BsnDsc>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<BsnDsc>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<BsnDsc>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<BsnDsc>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<BsnDsc>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<BsnDsc>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<BsnDsc>().Property(item => item.VolUtil).HasColumnName("VOL_UTIL");
            modelBuilder.Entity<BsnDsc>().Property(item => item.VolMor).HasColumnName("VOL_MOR");
            modelBuilder.Entity<BsnDsc>().Property(item => item.VolPoll).HasColumnName("VOL_POLL");
            modelBuilder.Entity<BsnDsc>().Property(item => item.VolIncen).HasColumnName("VOL_INCEN");
            modelBuilder.Entity<BsnDsc>().Property(item => item.DureePluie).HasColumnName("DUREE_PLUIE");
            modelBuilder.Entity<BsnDsc>().Property(item => item.FauneFlore).HasMaxLength(60);
            modelBuilder.Entity<BsnDsc>().Property(item => item.FauneFlore).HasColumnName("FAUNE_FLORE");
            modelBuilder.Entity<BsnDsc>().Property(item => item.SurfVersant).HasColumnName("SURF_VERSANT");
            modelBuilder.Entity<BsnDsc>().Property(item => item.DebitMax).HasColumnName("DEBIT_MAX");
            modelBuilder.Entity<BsnDsc>().Property(item => item.TpsConcent).HasColumnName("TPS_CONCENT");
            modelBuilder.Entity<BsnDsc>().Property(item => item.Vehicule).HasMaxLength(255);
            modelBuilder.Entity<BsnDsc>().Property(item => item.Vehicule).HasColumnName("VEHICULE");
            modelBuilder.Entity<BsnDsc>().Property(item => item.Pieton).HasMaxLength(255);
            modelBuilder.Entity<BsnDsc>().Property(item => item.Pieton).HasColumnName("PIETON");
            modelBuilder.Entity<BsnDsc>().Property(item => item.Note1).HasColumnName("NOTE1");
            modelBuilder.Entity<BsnDsc>().Property(item => item.Note2).HasColumnName("NOTE2");
            modelBuilder.Entity<BsnDsc>().Property(item => item.Note3).HasColumnName("NOTE3");
            modelBuilder.Entity<BsnDsc>().Property(item => item.Note4).HasColumnName("NOTE4");
            modelBuilder.Entity<BsnDsc>().Property(item => item.Urgence).HasMaxLength(5);
            modelBuilder.Entity<BsnDsc>().Property(item => item.Urgence).HasColumnName("URGENCE");
            modelBuilder.Entity<BsnDsc>().Property(item => item.DescInva).HasMaxLength(1000);
            modelBuilder.Entity<BsnDsc>().Property(item => item.DescInva).HasColumnName("DESC_INVA");
            modelBuilder.Entity<BsnDsc>().Property(item => item.Securite).HasColumnName("SECURITE");
            modelBuilder.Entity<BsnDsc>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<BsnDsc>().Property(item => item.ProsurvAnnee).HasColumnName("PROSURV_ANNEE");
            modelBuilder.Entity<BsnDsc>().Property(item => item.DernInsp).HasColumnName("DERN_INSP");
            modelBuilder.Entity<BsnDsc>().Property(item => item.DernVst).HasColumnName("DERN_VST");
            modelBuilder.Entity<BsnDsc>().Property(item => item.NoteVst).HasMaxLength(5);
            modelBuilder.Entity<BsnDsc>().Property(item => item.NoteVst).HasColumnName("NOTE_VST");
            modelBuilder.Entity<BsnDsc>().Property(item => item.Archive).HasMaxLength(255);
            modelBuilder.Entity<BsnDsc>().Property(item => item.Archive).HasColumnName("ARCHIVE");
            modelBuilder.Entity<BsnDsc>().Property(item => item.OuvAval).HasMaxLength(200);
            modelBuilder.Entity<BsnDsc>().Property(item => item.OuvAval).HasColumnName("OUV_AVAL");
            modelBuilder.Entity<BsnDsc>().Property(item => item.LoiEau).HasColumnName("LOI_EAU");
            modelBuilder.Entity<BsnDsc>().Property(item => item.EauxCollect).HasMaxLength(200);
            modelBuilder.Entity<BsnDsc>().Property(item => item.EauxCollect).HasColumnName("EAUX_COLLECT");
            modelBuilder.Entity<BsnDsc>().Property(item => item.Commentaire).HasMaxLength(1000);
            modelBuilder.Entity<BsnDsc>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<BsnDsc>().Property(item => item.X1).HasColumnName("X1");
            modelBuilder.Entity<BsnDsc>().Property(item => item.Y1).HasColumnName("Y1");
            modelBuilder.Entity<BsnDsc>().Property(item => item.Z1).HasColumnName("Z1");
            modelBuilder.Entity<BsnDsc>().Property(item => item.DateReleve).HasColumnName("DATE_RELEVE");
            modelBuilder.Entity<BsnDsc>().Property(item => item.Terrain).HasColumnName("TERRAIN");
            modelBuilder.Entity<BsnCls>().ToTable("CLS_BSN","BSN");
            modelBuilder.Entity<BsnCls>().HasKey(item => new {item.Id });
            modelBuilder.Entity<BsnCls>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<BsnCls>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<BsnCls>().Property(item => item.TableName).IsRequired();
            modelBuilder.Entity<BsnCls>().Property(item => item.TableName).HasMaxLength(30);
            modelBuilder.Entity<BsnCls>().Property(item => item.TableName).HasColumnName("TABLE_NAME");
            modelBuilder.Entity<BsnCls>().Property(item => item.KeyValue).IsRequired();
            modelBuilder.Entity<BsnCls>().Property(item => item.KeyValue).HasMaxLength(500);
            modelBuilder.Entity<BsnCls>().Property(item => item.KeyValue).HasColumnName("KEY_VALUE");
            modelBuilder.Entity<BsnDoc>().ToTable("DOC_BSN","BSN");
            modelBuilder.Entity<BsnDoc>().HasKey(item => new {item.Id });
            modelBuilder.Entity<BsnDoc>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<BsnDoc>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<BsnDoc>().Property(item => item.CdDocBsnCode).IsRequired();
            modelBuilder.Entity<BsnDoc>().Property(item => item.CdDocBsnCode).HasMaxLength(15);
            modelBuilder.Entity<BsnDoc>().Property(item => item.CdDocBsnCode).HasColumnName("CD_DOC_BSN__CODE");
            modelBuilder.Entity<BsnDoc>().Property(item => item.Libelle).HasMaxLength(100);
            modelBuilder.Entity<BsnDoc>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<BsnDoc>().Property(item => item.Ref).IsRequired();
            modelBuilder.Entity<BsnDoc>().Property(item => item.Ref).HasMaxLength(50);
            modelBuilder.Entity<BsnDoc>().Property(item => item.Ref).HasColumnName("REF");
            modelBuilder.Entity<BsnCdDoc>().ToTable("CD_DOC_BSN","BSN");
            modelBuilder.Entity<BsnCdDoc>().HasKey(item => new {item.Code });
            modelBuilder.Entity<BsnCdDoc>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<BsnCdDoc>().Property(item => item.Code).HasMaxLength(15);
            modelBuilder.Entity<BsnCdDoc>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<BsnCdDoc>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<BsnCdDoc>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<BsnCdDoc>().Property(item => item.Path).HasMaxLength(255);
            modelBuilder.Entity<BsnCdDoc>().Property(item => item.Path).HasColumnName("PATH");
            modelBuilder.Entity<BsnElt>().ToTable("ELT_BSN","BSN");
            modelBuilder.Entity<BsnElt>().HasKey(item => new {item.GrpBsnIdGrp,item.PrtBsnIdPrt,item.SprtBsnIdSprt,item.IdElem });
            modelBuilder.Entity<BsnElt>().Property(item => item.GrpBsnIdGrp).IsRequired();
            modelBuilder.Entity<BsnElt>().Property(item => item.GrpBsnIdGrp).HasColumnName("GRP_BSN__ID_GRP");
            modelBuilder.Entity<BsnElt>().Property(item => item.PrtBsnIdPrt).IsRequired();
            modelBuilder.Entity<BsnElt>().Property(item => item.PrtBsnIdPrt).HasColumnName("PRT_BSN__ID_PRT");
            modelBuilder.Entity<BsnElt>().Property(item => item.SprtBsnIdSprt).IsRequired();
            modelBuilder.Entity<BsnElt>().Property(item => item.SprtBsnIdSprt).HasColumnName("SPRT_BSN__ID_SPRT");
            modelBuilder.Entity<BsnElt>().Property(item => item.IdElem).IsRequired();
            modelBuilder.Entity<BsnElt>().Property(item => item.IdElem).HasColumnName("ID_ELEM");
            modelBuilder.Entity<BsnElt>().Property(item => item.Libe).IsRequired();
            modelBuilder.Entity<BsnElt>().Property(item => item.Libe).HasMaxLength(500);
            modelBuilder.Entity<BsnElt>().Property(item => item.Libe).HasColumnName("LIBE");
            modelBuilder.Entity<BsnElt>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<BsnElt>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<BsnElt>().Property(item => item.Aide).HasMaxLength(500);
            modelBuilder.Entity<BsnElt>().Property(item => item.Aide).HasColumnName("AIDE");
            modelBuilder.Entity<BsnElt>().Property(item => item.Indice1).HasMaxLength(500);
            modelBuilder.Entity<BsnElt>().Property(item => item.Indice1).HasColumnName("INDICE1");
            modelBuilder.Entity<BsnElt>().Property(item => item.Indice2).HasMaxLength(500);
            modelBuilder.Entity<BsnElt>().Property(item => item.Indice2).HasColumnName("INDICE2");
            modelBuilder.Entity<BsnElt>().Property(item => item.Indice3).HasMaxLength(500);
            modelBuilder.Entity<BsnElt>().Property(item => item.Indice3).HasColumnName("INDICE3");
            modelBuilder.Entity<BsnSprt>().ToTable("SPRT_BSN","BSN");
            modelBuilder.Entity<BsnSprt>().HasKey(item => new {item.GrpBsnIdGrp,item.PrtBsnIdPrt,item.IdSprt });
            modelBuilder.Entity<BsnSprt>().Property(item => item.GrpBsnIdGrp).IsRequired();
            modelBuilder.Entity<BsnSprt>().Property(item => item.GrpBsnIdGrp).HasColumnName("GRP_BSN__ID_GRP");
            modelBuilder.Entity<BsnSprt>().Property(item => item.PrtBsnIdPrt).IsRequired();
            modelBuilder.Entity<BsnSprt>().Property(item => item.PrtBsnIdPrt).HasColumnName("PRT_BSN__ID_PRT");
            modelBuilder.Entity<BsnSprt>().Property(item => item.IdSprt).IsRequired();
            modelBuilder.Entity<BsnSprt>().Property(item => item.IdSprt).HasColumnName("ID_SPRT");
            modelBuilder.Entity<BsnSprt>().Property(item => item.Libs).IsRequired();
            modelBuilder.Entity<BsnSprt>().Property(item => item.Libs).HasMaxLength(500);
            modelBuilder.Entity<BsnSprt>().Property(item => item.Libs).HasColumnName("LIBS");
            modelBuilder.Entity<BsnSprt>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<BsnSprt>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<BsnPrt>().ToTable("PRT_BSN","BSN");
            modelBuilder.Entity<BsnPrt>().HasKey(item => new {item.GrpBsnIdGrp,item.IdPrt });
            modelBuilder.Entity<BsnPrt>().Property(item => item.GrpBsnIdGrp).IsRequired();
            modelBuilder.Entity<BsnPrt>().Property(item => item.GrpBsnIdGrp).HasColumnName("GRP_BSN__ID_GRP");
            modelBuilder.Entity<BsnPrt>().Property(item => item.IdPrt).IsRequired();
            modelBuilder.Entity<BsnPrt>().Property(item => item.IdPrt).HasColumnName("ID_PRT");
            modelBuilder.Entity<BsnPrt>().Property(item => item.Libp).IsRequired();
            modelBuilder.Entity<BsnPrt>().Property(item => item.Libp).HasMaxLength(500);
            modelBuilder.Entity<BsnPrt>().Property(item => item.Libp).HasColumnName("LIBP");
            modelBuilder.Entity<BsnPrt>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<BsnPrt>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<BsnGrp>().ToTable("GRP_BSN","BSN");
            modelBuilder.Entity<BsnGrp>().HasKey(item => new {item.IdGrp });
            modelBuilder.Entity<BsnGrp>().Property(item => item.IdGrp).IsRequired();
            modelBuilder.Entity<BsnGrp>().Property(item => item.IdGrp).HasColumnName("ID_GRP");
            modelBuilder.Entity<BsnGrp>().Property(item => item.Libg).IsRequired();
            modelBuilder.Entity<BsnGrp>().Property(item => item.Libg).HasMaxLength(500);
            modelBuilder.Entity<BsnGrp>().Property(item => item.Libg).HasColumnName("LIBG");
            modelBuilder.Entity<BsnGrp>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<BsnGrp>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<BsnInsp>().ToTable("INSP_BSN","BSN");
            modelBuilder.Entity<BsnInsp>().HasKey(item => new {item.CampBsnIdCamp,item.DscBsnNumBsn });
            modelBuilder.Entity<BsnInsp>().Property(item => item.CampBsnIdCamp).IsRequired();
            modelBuilder.Entity<BsnInsp>().Property(item => item.CampBsnIdCamp).HasMaxLength(100);
            modelBuilder.Entity<BsnInsp>().Property(item => item.CampBsnIdCamp).HasColumnName("CAMP_BSN__ID_CAMP");
            modelBuilder.Entity<BsnInsp>().Property(item => item.DscBsnNumBsn).IsRequired();
            modelBuilder.Entity<BsnInsp>().Property(item => item.DscBsnNumBsn).HasMaxLength(20);
            modelBuilder.Entity<BsnInsp>().Property(item => item.DscBsnNumBsn).HasColumnName("DSC_BSN__NUM_BSN");
            modelBuilder.Entity<BsnInsp>().Property(item => item.CdMeteoBsnMeteo).HasMaxLength(60);
            modelBuilder.Entity<BsnInsp>().Property(item => item.CdMeteoBsnMeteo).HasColumnName("CD_METEO_BSN__METEO");
            modelBuilder.Entity<BsnInsp>().Property(item => item.InspecteurBsnNom).HasMaxLength(60);
            modelBuilder.Entity<BsnInsp>().Property(item => item.InspecteurBsnNom).HasColumnName("INSPECTEUR_BSN__NOM");
            modelBuilder.Entity<BsnInsp>().Property(item => item.CdEtudeBsnEtude).HasMaxLength(65);
            modelBuilder.Entity<BsnInsp>().Property(item => item.CdEtudeBsnEtude).HasColumnName("CD_ETUDE_BSN__ETUDE");
            modelBuilder.Entity<BsnInsp>().Property(item => item.Etat).IsRequired();
            modelBuilder.Entity<BsnInsp>().Property(item => item.Etat).HasMaxLength(25);
            modelBuilder.Entity<BsnInsp>().Property(item => item.Etat).HasColumnName("ETAT");
            modelBuilder.Entity<BsnInsp>().Property(item => item.Datev).HasColumnName("DATEV");
            modelBuilder.Entity<BsnInsp>().Property(item => item.Temperature).HasColumnName("TEMPERATURE");
            modelBuilder.Entity<BsnInsp>().Property(item => item.Moyen).HasMaxLength(500);
            modelBuilder.Entity<BsnInsp>().Property(item => item.Moyen).HasColumnName("MOYEN");
            modelBuilder.Entity<BsnInsp>().Property(item => item.Conditions).HasMaxLength(500);
            modelBuilder.Entity<BsnInsp>().Property(item => item.Conditions).HasColumnName("CONDITIONS");
            modelBuilder.Entity<BsnInsp>().Property(item => item.DateValid).HasColumnName("DATE_VALID");
            modelBuilder.Entity<BsnInsp>().Property(item => item.NomValid).HasMaxLength(250);
            modelBuilder.Entity<BsnInsp>().Property(item => item.NomValid).HasColumnName("NOM_VALID");
            modelBuilder.Entity<BsnInsp>().Property(item => item.DescInva).HasMaxLength(1000);
            modelBuilder.Entity<BsnInsp>().Property(item => item.DescInva).HasColumnName("DESC_INVA");
            modelBuilder.Entity<BsnInsp>().Property(item => item.Securite).HasMaxLength(1000);
            modelBuilder.Entity<BsnInsp>().Property(item => item.Securite).HasColumnName("SECURITE");
            modelBuilder.Entity<BsnInsp>().Property(item => item.Prioritaire).HasMaxLength(1000);
            modelBuilder.Entity<BsnInsp>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<BsnInsp>().Property(item => item.Note1).HasColumnName("NOTE1");
            modelBuilder.Entity<BsnInsp>().Property(item => item.Note2).HasColumnName("NOTE2");
            modelBuilder.Entity<BsnInsp>().Property(item => item.Note3).HasColumnName("NOTE3");
            modelBuilder.Entity<BsnInsp>().Property(item => item.Note4).HasColumnName("NOTE4");
            modelBuilder.Entity<BsnInsp>().Property(item => item.Urgence).HasMaxLength(5);
            modelBuilder.Entity<BsnInsp>().Property(item => item.Urgence).HasColumnName("URGENCE");
            modelBuilder.Entity<BsnInsp>().Property(item => item.Qualite).HasMaxLength(25);
            modelBuilder.Entity<BsnInsp>().Property(item => item.Qualite).HasColumnName("QUALITE");
            modelBuilder.Entity<BsnEltInsp>().ToTable("ELT_INSP_BSN","BSN");
            modelBuilder.Entity<BsnEltInsp>().HasKey(item => new {item.GrpBsnIdGrp,item.PrtBsnIdPrt,item.SprtBsnIdSprt,item.EltBsnIdElem,item.CampBsnIdCamp,item.DscBsnNumBsn });
            modelBuilder.Entity<BsnEltInsp>().Property(item => item.GrpBsnIdGrp).IsRequired();
            modelBuilder.Entity<BsnEltInsp>().Property(item => item.GrpBsnIdGrp).HasColumnName("GRP_BSN__ID_GRP");
            modelBuilder.Entity<BsnEltInsp>().Property(item => item.PrtBsnIdPrt).IsRequired();
            modelBuilder.Entity<BsnEltInsp>().Property(item => item.PrtBsnIdPrt).HasColumnName("PRT_BSN__ID_PRT");
            modelBuilder.Entity<BsnEltInsp>().Property(item => item.SprtBsnIdSprt).IsRequired();
            modelBuilder.Entity<BsnEltInsp>().Property(item => item.SprtBsnIdSprt).HasColumnName("SPRT_BSN__ID_SPRT");
            modelBuilder.Entity<BsnEltInsp>().Property(item => item.EltBsnIdElem).IsRequired();
            modelBuilder.Entity<BsnEltInsp>().Property(item => item.EltBsnIdElem).HasColumnName("ELT_BSN__ID_ELEM");
            modelBuilder.Entity<BsnEltInsp>().Property(item => item.CampBsnIdCamp).IsRequired();
            modelBuilder.Entity<BsnEltInsp>().Property(item => item.CampBsnIdCamp).HasMaxLength(100);
            modelBuilder.Entity<BsnEltInsp>().Property(item => item.CampBsnIdCamp).HasColumnName("CAMP_BSN__ID_CAMP");
            modelBuilder.Entity<BsnEltInsp>().Property(item => item.DscBsnNumBsn).IsRequired();
            modelBuilder.Entity<BsnEltInsp>().Property(item => item.DscBsnNumBsn).HasMaxLength(20);
            modelBuilder.Entity<BsnEltInsp>().Property(item => item.DscBsnNumBsn).HasColumnName("DSC_BSN__NUM_BSN");
            modelBuilder.Entity<BsnEltInsp>().Property(item => item.Indice).IsRequired();
            modelBuilder.Entity<BsnEltInsp>().Property(item => item.Indice).HasColumnName("INDICE");
            modelBuilder.Entity<BsnEltInsp>().Property(item => item.Obs).HasMaxLength(255);
            modelBuilder.Entity<BsnEltInsp>().Property(item => item.Obs).HasColumnName("OBS");
            modelBuilder.Entity<BsnPhotoEltInsp>().ToTable("PHOTO_ELT_INSP_BSN","BSN");
            modelBuilder.Entity<BsnPhotoEltInsp>().HasKey(item => new {item.GrpBsnIdGrp,item.PrtBsnIdPrt,item.SprtBsnIdSprt,item.CampBsnIdCamp,item.EltBsnIdElem,item.DscBsnNumBsn,item.Id });
            modelBuilder.Entity<BsnPhotoEltInsp>().Property(item => item.GrpBsnIdGrp).IsRequired();
            modelBuilder.Entity<BsnPhotoEltInsp>().Property(item => item.GrpBsnIdGrp).HasColumnName("GRP_BSN__ID_GRP");
            modelBuilder.Entity<BsnPhotoEltInsp>().Property(item => item.PrtBsnIdPrt).IsRequired();
            modelBuilder.Entity<BsnPhotoEltInsp>().Property(item => item.PrtBsnIdPrt).HasColumnName("PRT_BSN__ID_PRT");
            modelBuilder.Entity<BsnPhotoEltInsp>().Property(item => item.SprtBsnIdSprt).IsRequired();
            modelBuilder.Entity<BsnPhotoEltInsp>().Property(item => item.SprtBsnIdSprt).HasColumnName("SPRT_BSN__ID_SPRT");
            modelBuilder.Entity<BsnPhotoEltInsp>().Property(item => item.CampBsnIdCamp).IsRequired();
            modelBuilder.Entity<BsnPhotoEltInsp>().Property(item => item.CampBsnIdCamp).HasMaxLength(100);
            modelBuilder.Entity<BsnPhotoEltInsp>().Property(item => item.CampBsnIdCamp).HasColumnName("CAMP_BSN__ID_CAMP");
            modelBuilder.Entity<BsnPhotoEltInsp>().Property(item => item.EltBsnIdElem).IsRequired();
            modelBuilder.Entity<BsnPhotoEltInsp>().Property(item => item.EltBsnIdElem).HasColumnName("ELT_BSN__ID_ELEM");
            modelBuilder.Entity<BsnPhotoEltInsp>().Property(item => item.DscBsnNumBsn).IsRequired();
            modelBuilder.Entity<BsnPhotoEltInsp>().Property(item => item.DscBsnNumBsn).HasMaxLength(20);
            modelBuilder.Entity<BsnPhotoEltInsp>().Property(item => item.DscBsnNumBsn).HasColumnName("DSC_BSN__NUM_BSN");
            modelBuilder.Entity<BsnPhotoEltInsp>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<BsnPhotoEltInsp>().Property(item => item.Id).HasMaxLength(50);
            modelBuilder.Entity<BsnPhotoEltInsp>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<BsnPhotoEltInsp>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<BsnPhotoEltInsp>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<BsnCamp>().ToTable("CAMP_BSN","BSN");
            modelBuilder.Entity<BsnCamp>().HasKey(item => new {item.IdCamp });
            modelBuilder.Entity<BsnCamp>().Property(item => item.IdCamp).IsRequired();
            modelBuilder.Entity<BsnCamp>().Property(item => item.IdCamp).HasMaxLength(100);
            modelBuilder.Entity<BsnCamp>().Property(item => item.IdCamp).HasColumnName("ID_CAMP");
            modelBuilder.Entity<BsnCamp>().Property(item => item.CdPrestaBsnPrestataire).IsRequired();
            modelBuilder.Entity<BsnCamp>().Property(item => item.CdPrestaBsnPrestataire).HasMaxLength(50);
            modelBuilder.Entity<BsnCamp>().Property(item => item.CdPrestaBsnPrestataire).HasColumnName("CD_PRESTA_BSN__PRESTATAIRE");
            modelBuilder.Entity<BsnCamp>().Property(item => item.CdTypePvBsnCode).IsRequired();
            modelBuilder.Entity<BsnCamp>().Property(item => item.CdTypePvBsnCode).HasMaxLength(15);
            modelBuilder.Entity<BsnCamp>().Property(item => item.CdTypePvBsnCode).HasColumnName("CD_TYPE_PV_BSN__CODE");
            modelBuilder.Entity<BsnCamp>().Property(item => item.Annee).IsRequired();
            modelBuilder.Entity<BsnCamp>().Property(item => item.Annee).HasColumnName("ANNEE");
            modelBuilder.Entity<BsnCamp>().Property(item => item.Dater).IsRequired();
            modelBuilder.Entity<BsnCamp>().Property(item => item.Dater).HasColumnName("DATER");
            modelBuilder.Entity<BsnCamp>().Property(item => item.Dateg).HasColumnName("DATEG");
            modelBuilder.Entity<BsnCamp>().Property(item => item.Userg).HasMaxLength(255);
            modelBuilder.Entity<BsnCamp>().Property(item => item.Userg).HasColumnName("USERG");
            modelBuilder.Entity<BsnCamp>().Property(item => item.Observ).HasMaxLength(255);
            modelBuilder.Entity<BsnCamp>().Property(item => item.Observ).HasColumnName("OBSERV");
            modelBuilder.Entity<BsnCdMeteo>().ToTable("CD_METEO_BSN","BSN");
            modelBuilder.Entity<BsnCdMeteo>().HasKey(item => new {item.Meteo });
            modelBuilder.Entity<BsnCdMeteo>().Property(item => item.Meteo).IsRequired();
            modelBuilder.Entity<BsnCdMeteo>().Property(item => item.Meteo).HasMaxLength(60);
            modelBuilder.Entity<BsnCdMeteo>().Property(item => item.Meteo).HasColumnName("METEO");
            modelBuilder.Entity<BsnCdPresta>().ToTable("CD_PRESTA_BSN","BSN");
            modelBuilder.Entity<BsnCdPresta>().HasKey(item => new {item.Prestataire });
            modelBuilder.Entity<BsnCdPresta>().Property(item => item.Prestataire).IsRequired();
            modelBuilder.Entity<BsnCdPresta>().Property(item => item.Prestataire).HasMaxLength(50);
            modelBuilder.Entity<BsnCdPresta>().Property(item => item.Prestataire).HasColumnName("PRESTATAIRE");
            modelBuilder.Entity<BsnTravaux>().ToTable("TRAVAUX_BSN","BSN");
            modelBuilder.Entity<BsnTravaux>().HasKey(item => new {item.DscBsnNumBsn,item.CdTravauxBsnCode,item.NatureTravBsnNature,item.DateRcp });
            modelBuilder.Entity<BsnTravaux>().Property(item => item.DscBsnNumBsn).IsRequired();
            modelBuilder.Entity<BsnTravaux>().Property(item => item.DscBsnNumBsn).HasMaxLength(20);
            modelBuilder.Entity<BsnTravaux>().Property(item => item.DscBsnNumBsn).HasColumnName("DSC_BSN__NUM_BSN");
            modelBuilder.Entity<BsnTravaux>().Property(item => item.CdTravauxBsnCode).IsRequired();
            modelBuilder.Entity<BsnTravaux>().Property(item => item.CdTravauxBsnCode).HasMaxLength(60);
            modelBuilder.Entity<BsnTravaux>().Property(item => item.CdTravauxBsnCode).HasColumnName("CD_TRAVAUX_BSN__CODE");
            modelBuilder.Entity<BsnTravaux>().Property(item => item.NatureTravBsnNature).IsRequired();
            modelBuilder.Entity<BsnTravaux>().Property(item => item.NatureTravBsnNature).HasMaxLength(100);
            modelBuilder.Entity<BsnTravaux>().Property(item => item.NatureTravBsnNature).HasColumnName("NATURE_TRAV_BSN__NATURE");
            modelBuilder.Entity<BsnTravaux>().Property(item => item.DateRcp).IsRequired();
            modelBuilder.Entity<BsnTravaux>().Property(item => item.DateRcp).HasColumnName("DATE_RCP");
            modelBuilder.Entity<BsnTravaux>().Property(item => item.CdEntpBsnEntreprise).IsRequired();
            modelBuilder.Entity<BsnTravaux>().Property(item => item.CdEntpBsnEntreprise).HasMaxLength(60);
            modelBuilder.Entity<BsnTravaux>().Property(item => item.CdEntpBsnEntreprise).HasColumnName("CD_ENTP_BSN__ENTREPRISE");
            modelBuilder.Entity<BsnTravaux>().Property(item => item.DateFinGar).HasColumnName("DATE_FIN_GAR");
            modelBuilder.Entity<BsnTravaux>().Property(item => item.Cout).HasColumnName("COUT");
            modelBuilder.Entity<BsnTravaux>().Property(item => item.Marche).HasMaxLength(25);
            modelBuilder.Entity<BsnTravaux>().Property(item => item.Marche).HasColumnName("MARCHE");
            modelBuilder.Entity<BsnTravaux>().Property(item => item.Commentaire).HasMaxLength(500);
            modelBuilder.Entity<BsnTravaux>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<BsnNatureTrav>().ToTable("NATURE_TRAV_BSN","BSN");
            modelBuilder.Entity<BsnNatureTrav>().HasKey(item => new {item.CdTravauxBsnCode,item.Nature });
            modelBuilder.Entity<BsnNatureTrav>().Property(item => item.CdTravauxBsnCode).IsRequired();
            modelBuilder.Entity<BsnNatureTrav>().Property(item => item.CdTravauxBsnCode).HasMaxLength(60);
            modelBuilder.Entity<BsnNatureTrav>().Property(item => item.CdTravauxBsnCode).HasColumnName("CD_TRAVAUX_BSN__CODE");
            modelBuilder.Entity<BsnNatureTrav>().Property(item => item.Nature).IsRequired();
            modelBuilder.Entity<BsnNatureTrav>().Property(item => item.Nature).HasMaxLength(100);
            modelBuilder.Entity<BsnNatureTrav>().Property(item => item.Nature).HasColumnName("NATURE");
            modelBuilder.Entity<BsnCdPermeable>().ToTable("CD_PERMEABLE_BSN","BSN");
            modelBuilder.Entity<BsnCdPermeable>().HasKey(item => new {item.Type });
            modelBuilder.Entity<BsnCdPermeable>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<BsnCdPermeable>().Property(item => item.Type).HasMaxLength(60);
            modelBuilder.Entity<BsnCdPermeable>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<BsnSysUser>().ToTable("SYS_USER_BSN","BSN");
            modelBuilder.Entity<BsnSysUser>().HasKey(item => new {item.CodeDbs,item.CodeTable,item.CodeColonne,item.NomUser,item.CodePrp });
            modelBuilder.Entity<BsnSysUser>().Property(item => item.CodeDbs).IsRequired();
            modelBuilder.Entity<BsnSysUser>().Property(item => item.CodeDbs).HasMaxLength(50);
            modelBuilder.Entity<BsnSysUser>().Property(item => item.CodeDbs).HasColumnName("CODE_DBS");
            modelBuilder.Entity<BsnSysUser>().Property(item => item.CodeTable).IsRequired();
            modelBuilder.Entity<BsnSysUser>().Property(item => item.CodeTable).HasMaxLength(100);
            modelBuilder.Entity<BsnSysUser>().Property(item => item.CodeTable).HasColumnName("CODE_TABLE");
            modelBuilder.Entity<BsnSysUser>().Property(item => item.CodeColonne).IsRequired();
            modelBuilder.Entity<BsnSysUser>().Property(item => item.CodeColonne).HasMaxLength(100);
            modelBuilder.Entity<BsnSysUser>().Property(item => item.CodeColonne).HasColumnName("CODE_COLONNE");
            modelBuilder.Entity<BsnSysUser>().Property(item => item.NomUser).IsRequired();
            modelBuilder.Entity<BsnSysUser>().Property(item => item.NomUser).HasMaxLength(150);
            modelBuilder.Entity<BsnSysUser>().Property(item => item.NomUser).HasColumnName("NOM_USER");
            modelBuilder.Entity<BsnSysUser>().Property(item => item.CodePrp).IsRequired();
            modelBuilder.Entity<BsnSysUser>().Property(item => item.CodePrp).HasMaxLength(255);
            modelBuilder.Entity<BsnSysUser>().Property(item => item.CodePrp).HasColumnName("CODE_PRP");
            modelBuilder.Entity<BsnSysUser>().Property(item => item.ValPrp).IsRequired();
            modelBuilder.Entity<BsnSysUser>().Property(item => item.ValPrp).HasMaxLength(500);
            modelBuilder.Entity<BsnSysUser>().Property(item => item.ValPrp).HasColumnName("VAL_PRP");
            modelBuilder.Entity<BsnCdTypePv>().ToTable("CD_TYPE_PV_BSN","BSN");
            modelBuilder.Entity<BsnCdTypePv>().HasKey(item => new {item.Code });
            modelBuilder.Entity<BsnCdTypePv>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<BsnCdTypePv>().Property(item => item.Code).HasMaxLength(15);
            modelBuilder.Entity<BsnCdTypePv>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<BsnCdTypePv>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<BsnCdTypePv>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<BsnCdTypePv>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<BsnCdTypePv>().Property(item => item.Cycle).HasColumnName("CYCLE");
            modelBuilder.Entity<BsnCdTypePv>().Property(item => item.Cout).HasColumnName("COUT");
            modelBuilder.Entity<BsnCdEtude>().ToTable("CD_ETUDE_BSN","BSN");
            modelBuilder.Entity<BsnCdEtude>().HasKey(item => new {item.Etude });
            modelBuilder.Entity<BsnCdEtude>().Property(item => item.Etude).IsRequired();
            modelBuilder.Entity<BsnCdEtude>().Property(item => item.Etude).HasMaxLength(65);
            modelBuilder.Entity<BsnCdEtude>().Property(item => item.Etude).HasColumnName("ETUDE");
            modelBuilder.Entity<BsnBpu>().ToTable("BPU_BSN","BSN");
            modelBuilder.Entity<BsnBpu>().HasKey(item => new {item.IdBpu });
            modelBuilder.Entity<BsnBpu>().Property(item => item.IdBpu).IsRequired();
            modelBuilder.Entity<BsnBpu>().Property(item => item.IdBpu).HasColumnName("ID_BPU");
            modelBuilder.Entity<BsnBpu>().Property(item => item.CdTravauxBsnCode).IsRequired();
            modelBuilder.Entity<BsnBpu>().Property(item => item.CdTravauxBsnCode).HasMaxLength(60);
            modelBuilder.Entity<BsnBpu>().Property(item => item.CdTravauxBsnCode).HasColumnName("CD_TRAVAUX_BSN__CODE");
            modelBuilder.Entity<BsnBpu>().Property(item => item.CdUniteBsnUnite).HasMaxLength(12);
            modelBuilder.Entity<BsnBpu>().Property(item => item.CdUniteBsnUnite).HasColumnName("CD_UNITE_BSN__UNITE");
            modelBuilder.Entity<BsnBpu>().Property(item => item.Techn).IsRequired();
            modelBuilder.Entity<BsnBpu>().Property(item => item.Techn).HasMaxLength(255);
            modelBuilder.Entity<BsnBpu>().Property(item => item.Techn).HasColumnName("TECHN");
            modelBuilder.Entity<BsnBpu>().Property(item => item.Prix).HasColumnName("PRIX");
            modelBuilder.Entity<BsnBpu>().Property(item => item.DateMaj).HasColumnName("DATE_MAJ");
            modelBuilder.Entity<BsnBpu>().Property(item => item.Freq).HasColumnName("FREQ");
            modelBuilder.Entity<BsnBpu>().Property(item => item.PrecoVst).HasColumnName("PRECO_VST");
            modelBuilder.Entity<BsnBpu>().Property(item => item.RealisVst).HasColumnName("REALIS_VST");
            modelBuilder.Entity<BsnCdContrainte>().ToTable("CD_CONTRAINTE_BSN","BSN");
            modelBuilder.Entity<BsnCdContrainte>().HasKey(item => new {item.Type });
            modelBuilder.Entity<BsnCdContrainte>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<BsnCdContrainte>().Property(item => item.Type).HasMaxLength(100);
            modelBuilder.Entity<BsnCdContrainte>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<BsnCdTravaux>().ToTable("CD_TRAVAUX_BSN","BSN");
            modelBuilder.Entity<BsnCdTravaux>().HasKey(item => new {item.Code });
            modelBuilder.Entity<BsnCdTravaux>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<BsnCdTravaux>().Property(item => item.Code).HasMaxLength(60);
            modelBuilder.Entity<BsnCdTravaux>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<BsnCdExt>().ToTable("CD_EXT_BSN","BSN");
            modelBuilder.Entity<BsnCdExt>().HasKey(item => new {item.Type });
            modelBuilder.Entity<BsnCdExt>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<BsnCdExt>().Property(item => item.Type).HasMaxLength(60);
            modelBuilder.Entity<BsnCdExt>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<BsnCdExt>().Property(item => item.IsBsn).IsRequired();
            modelBuilder.Entity<BsnCdExt>().Property(item => item.IsBsn).HasColumnName("IS_BSN");
            modelBuilder.Entity<BsnCdExt>().Property(item => item.IsOh).IsRequired();
            modelBuilder.Entity<BsnCdExt>().Property(item => item.IsOh).HasColumnName("IS_OH");
            modelBuilder.Entity<BsnSeuilQualite>().ToTable("SEUIL_QUALITE_BSN","BSN");
            modelBuilder.Entity<BsnSeuilQualite>().HasKey(item => new {item.CdQualiteBsnQualite,item.IndiceUrgence });
            modelBuilder.Entity<BsnSeuilQualite>().Property(item => item.CdQualiteBsnQualite).IsRequired();
            modelBuilder.Entity<BsnSeuilQualite>().Property(item => item.CdQualiteBsnQualite).HasMaxLength(25);
            modelBuilder.Entity<BsnSeuilQualite>().Property(item => item.CdQualiteBsnQualite).HasColumnName("CD_QUALITE_BSN__QUALITE");
            modelBuilder.Entity<BsnSeuilQualite>().Property(item => item.IndiceUrgence).IsRequired();
            modelBuilder.Entity<BsnSeuilQualite>().Property(item => item.IndiceUrgence).HasMaxLength(5);
            modelBuilder.Entity<BsnSeuilQualite>().Property(item => item.IndiceUrgence).HasColumnName("INDICE_URGENCE");
            modelBuilder.Entity<BsnSeuilUrgence>().ToTable("SEUIL_URGENCE_BSN","BSN");
            modelBuilder.Entity<BsnSeuilUrgence>().HasKey(item => new {item.Ordre });
            modelBuilder.Entity<BsnSeuilUrgence>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<BsnSeuilUrgence>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<BsnSeuilUrgence>().Property(item => item.NbrNote).HasColumnName("NBR_NOTE");
            modelBuilder.Entity<BsnSeuilUrgence>().Property(item => item.ValNote).HasColumnName("VAL_NOTE");
            modelBuilder.Entity<BsnSeuilUrgence>().Property(item => item.Indice).HasColumnName("INDICE");
            modelBuilder.Entity<BsnPrevision>().ToTable("PREVISION_BSN","BSN");
            modelBuilder.Entity<BsnPrevision>().HasKey(item => new {item.DscBsnNumBsn,item.BpuBsnIdBpu,item.DateDebut });
            modelBuilder.Entity<BsnPrevision>().Property(item => item.DscBsnNumBsn).IsRequired();
            modelBuilder.Entity<BsnPrevision>().Property(item => item.DscBsnNumBsn).HasMaxLength(20);
            modelBuilder.Entity<BsnPrevision>().Property(item => item.DscBsnNumBsn).HasColumnName("DSC_BSN__NUM_BSN");
            modelBuilder.Entity<BsnPrevision>().Property(item => item.BpuBsnIdBpu).IsRequired();
            modelBuilder.Entity<BsnPrevision>().Property(item => item.BpuBsnIdBpu).HasColumnName("BPU_BSN__ID_BPU");
            modelBuilder.Entity<BsnPrevision>().Property(item => item.DateDebut).IsRequired();
            modelBuilder.Entity<BsnPrevision>().Property(item => item.DateDebut).HasColumnName("DATE_DEBUT");
            modelBuilder.Entity<BsnPrevision>().Property(item => item.CdContrainteBsnType).HasMaxLength(100);
            modelBuilder.Entity<BsnPrevision>().Property(item => item.CdContrainteBsnType).HasColumnName("CD_CONTRAINTE_BSN__TYPE");
            modelBuilder.Entity<BsnPrevision>().Property(item => item.DateFin).HasColumnName("DATE_FIN");
            modelBuilder.Entity<BsnPrevision>().Property(item => item.Montant).HasColumnName("MONTANT");
            modelBuilder.Entity<BsnPrevision>().Property(item => item.DateDemPub).HasColumnName("DATE_DEM_PUB");
            modelBuilder.Entity<BsnPrevision>().Property(item => item.Commentaire).HasMaxLength(255);
            modelBuilder.Entity<BsnPrevision>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<BsnPrevision>().Property(item => item.Realise).HasColumnName("REALISE");
            modelBuilder.Entity<BsnVst>().ToTable("VST_BSN","BSN");
            modelBuilder.Entity<BsnVst>().HasKey(item => new {item.CampBsnIdCamp,item.DscBsnNumBsn });
            modelBuilder.Entity<BsnVst>().Property(item => item.CampBsnIdCamp).IsRequired();
            modelBuilder.Entity<BsnVst>().Property(item => item.CampBsnIdCamp).HasMaxLength(100);
            modelBuilder.Entity<BsnVst>().Property(item => item.CampBsnIdCamp).HasColumnName("CAMP_BSN__ID_CAMP");
            modelBuilder.Entity<BsnVst>().Property(item => item.DscBsnNumBsn).IsRequired();
            modelBuilder.Entity<BsnVst>().Property(item => item.DscBsnNumBsn).HasMaxLength(20);
            modelBuilder.Entity<BsnVst>().Property(item => item.DscBsnNumBsn).HasColumnName("DSC_BSN__NUM_BSN");
            modelBuilder.Entity<BsnVst>().Property(item => item.InspecteurBsnNom).HasMaxLength(60);
            modelBuilder.Entity<BsnVst>().Property(item => item.InspecteurBsnNom).HasColumnName("INSPECTEUR_BSN__NOM");
            modelBuilder.Entity<BsnVst>().Property(item => item.Etat).IsRequired();
            modelBuilder.Entity<BsnVst>().Property(item => item.Etat).HasMaxLength(25);
            modelBuilder.Entity<BsnVst>().Property(item => item.Etat).HasColumnName("ETAT");
            modelBuilder.Entity<BsnVst>().Property(item => item.Datev).HasColumnName("DATEV");
            modelBuilder.Entity<BsnVst>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<BsnVst>().Property(item => item.Observ).HasMaxLength(500);
            modelBuilder.Entity<BsnVst>().Property(item => item.Observ).HasColumnName("OBSERV");
            modelBuilder.Entity<BsnVst>().Property(item => item.NoteVst).HasMaxLength(5);
            modelBuilder.Entity<BsnVst>().Property(item => item.NoteVst).HasColumnName("NOTE_VST");
            modelBuilder.Entity<BsnSprtVst>().ToTable("SPRT_VST_BSN","BSN");
            modelBuilder.Entity<BsnSprtVst>().HasKey(item => new {item.CampBsnIdCamp,item.DscBsnNumBsn,item.CdChapitreBsnIdChap,item.CdLigneBsnIdLigne });
            modelBuilder.Entity<BsnSprtVst>().Property(item => item.CampBsnIdCamp).IsRequired();
            modelBuilder.Entity<BsnSprtVst>().Property(item => item.CampBsnIdCamp).HasMaxLength(100);
            modelBuilder.Entity<BsnSprtVst>().Property(item => item.CampBsnIdCamp).HasColumnName("CAMP_BSN__ID_CAMP");
            modelBuilder.Entity<BsnSprtVst>().Property(item => item.DscBsnNumBsn).IsRequired();
            modelBuilder.Entity<BsnSprtVst>().Property(item => item.DscBsnNumBsn).HasMaxLength(20);
            modelBuilder.Entity<BsnSprtVst>().Property(item => item.DscBsnNumBsn).HasColumnName("DSC_BSN__NUM_BSN");
            modelBuilder.Entity<BsnSprtVst>().Property(item => item.CdChapitreBsnIdChap).IsRequired();
            modelBuilder.Entity<BsnSprtVst>().Property(item => item.CdChapitreBsnIdChap).HasColumnName("CD_CHAPITRE_BSN__ID_CHAP");
            modelBuilder.Entity<BsnSprtVst>().Property(item => item.CdLigneBsnIdLigne).IsRequired();
            modelBuilder.Entity<BsnSprtVst>().Property(item => item.CdLigneBsnIdLigne).HasColumnName("CD_LIGNE_BSN__ID_LIGNE");
            modelBuilder.Entity<BsnSprtVst>().Property(item => item.Indice).IsRequired();
            modelBuilder.Entity<BsnSprtVst>().Property(item => item.Indice).HasColumnName("INDICE");
            modelBuilder.Entity<BsnSprtVst>().Property(item => item.Obs).HasMaxLength(255);
            modelBuilder.Entity<BsnSprtVst>().Property(item => item.Obs).HasColumnName("OBS");
            modelBuilder.Entity<BsnPhotoSprtVst>().ToTable("PHOTO_SPRT_VST_BSN","BSN");
            modelBuilder.Entity<BsnPhotoSprtVst>().HasKey(item => new {item.CampBsnIdCamp,item.DscBsnNumBsn,item.CdChapitreBsnIdChap,item.CdLigneBsnIdLigne,item.Id });
            modelBuilder.Entity<BsnPhotoSprtVst>().Property(item => item.CampBsnIdCamp).IsRequired();
            modelBuilder.Entity<BsnPhotoSprtVst>().Property(item => item.CampBsnIdCamp).HasMaxLength(100);
            modelBuilder.Entity<BsnPhotoSprtVst>().Property(item => item.CampBsnIdCamp).HasColumnName("CAMP_BSN__ID_CAMP");
            modelBuilder.Entity<BsnPhotoSprtVst>().Property(item => item.DscBsnNumBsn).IsRequired();
            modelBuilder.Entity<BsnPhotoSprtVst>().Property(item => item.DscBsnNumBsn).HasMaxLength(20);
            modelBuilder.Entity<BsnPhotoSprtVst>().Property(item => item.DscBsnNumBsn).HasColumnName("DSC_BSN__NUM_BSN");
            modelBuilder.Entity<BsnPhotoSprtVst>().Property(item => item.CdChapitreBsnIdChap).IsRequired();
            modelBuilder.Entity<BsnPhotoSprtVst>().Property(item => item.CdChapitreBsnIdChap).HasColumnName("CD_CHAPITRE_BSN__ID_CHAP");
            modelBuilder.Entity<BsnPhotoSprtVst>().Property(item => item.CdLigneBsnIdLigne).IsRequired();
            modelBuilder.Entity<BsnPhotoSprtVst>().Property(item => item.CdLigneBsnIdLigne).HasColumnName("CD_LIGNE_BSN__ID_LIGNE");
            modelBuilder.Entity<BsnPhotoSprtVst>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<BsnPhotoSprtVst>().Property(item => item.Id).HasMaxLength(50);
            modelBuilder.Entity<BsnPhotoSprtVst>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<BsnPhotoSprtVst>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<BsnPhotoSprtVst>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<BsnPhotoVst>().ToTable("PHOTO_VST_BSN","BSN");
            modelBuilder.Entity<BsnPhotoVst>().HasKey(item => new {item.Id });
            modelBuilder.Entity<BsnPhotoVst>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<BsnPhotoVst>().Property(item => item.Id).HasMaxLength(30);
            modelBuilder.Entity<BsnPhotoVst>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<BsnPhotoVst>().Property(item => item.CampBsnIdCamp).IsRequired();
            modelBuilder.Entity<BsnPhotoVst>().Property(item => item.CampBsnIdCamp).HasMaxLength(100);
            modelBuilder.Entity<BsnPhotoVst>().Property(item => item.CampBsnIdCamp).HasColumnName("CAMP_BSN__ID_CAMP");
            modelBuilder.Entity<BsnPhotoVst>().Property(item => item.DscBsnNumBsn).IsRequired();
            modelBuilder.Entity<BsnPhotoVst>().Property(item => item.DscBsnNumBsn).HasMaxLength(20);
            modelBuilder.Entity<BsnPhotoVst>().Property(item => item.DscBsnNumBsn).HasColumnName("DSC_BSN__NUM_BSN");
            modelBuilder.Entity<BsnPhotoVst>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<BsnPhotoVst>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<BsnPhotoInsp>().ToTable("PHOTO_INSP_BSN","BSN");
            modelBuilder.Entity<BsnPhotoInsp>().HasKey(item => new {item.Id });
            modelBuilder.Entity<BsnPhotoInsp>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<BsnPhotoInsp>().Property(item => item.Id).HasMaxLength(30);
            modelBuilder.Entity<BsnPhotoInsp>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<BsnPhotoInsp>().Property(item => item.CampBsnIdCamp).IsRequired();
            modelBuilder.Entity<BsnPhotoInsp>().Property(item => item.CampBsnIdCamp).HasMaxLength(100);
            modelBuilder.Entity<BsnPhotoInsp>().Property(item => item.CampBsnIdCamp).HasColumnName("CAMP_BSN__ID_CAMP");
            modelBuilder.Entity<BsnPhotoInsp>().Property(item => item.DscBsnNumBsn).IsRequired();
            modelBuilder.Entity<BsnPhotoInsp>().Property(item => item.DscBsnNumBsn).HasMaxLength(20);
            modelBuilder.Entity<BsnPhotoInsp>().Property(item => item.DscBsnNumBsn).HasColumnName("DSC_BSN__NUM_BSN");
            modelBuilder.Entity<BsnPhotoInsp>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<BsnPhotoInsp>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<BsnCdQualite>().ToTable("CD_QUALITE_BSN","BSN");
            modelBuilder.Entity<BsnCdQualite>().HasKey(item => new {item.Qualite });
            modelBuilder.Entity<BsnCdQualite>().Property(item => item.Qualite).IsRequired();
            modelBuilder.Entity<BsnCdQualite>().Property(item => item.Qualite).HasMaxLength(25);
            modelBuilder.Entity<BsnCdQualite>().Property(item => item.Qualite).HasColumnName("QUALITE");
            modelBuilder.Entity<BsnHistoNote>().ToTable("HISTO_NOTE_BSN","BSN");
            modelBuilder.Entity<BsnHistoNote>().HasKey(item => new {item.DscBsnNumBsn,item.DateNote });
            modelBuilder.Entity<BsnHistoNote>().Property(item => item.DscBsnNumBsn).IsRequired();
            modelBuilder.Entity<BsnHistoNote>().Property(item => item.DscBsnNumBsn).HasMaxLength(20);
            modelBuilder.Entity<BsnHistoNote>().Property(item => item.DscBsnNumBsn).HasColumnName("DSC_BSN__NUM_BSN");
            modelBuilder.Entity<BsnHistoNote>().Property(item => item.DateNote).IsRequired();
            modelBuilder.Entity<BsnHistoNote>().Property(item => item.DateNote).HasColumnName("DATE_NOTE");
            modelBuilder.Entity<BsnHistoNote>().Property(item => item.CdOriginBsnOrigine).IsRequired();
            modelBuilder.Entity<BsnHistoNote>().Property(item => item.CdOriginBsnOrigine).HasMaxLength(20);
            modelBuilder.Entity<BsnHistoNote>().Property(item => item.CdOriginBsnOrigine).HasColumnName("CD_ORIGIN_BSN__ORIGINE");
            modelBuilder.Entity<BsnHistoNote>().Property(item => item.Note1).HasColumnName("NOTE1");
            modelBuilder.Entity<BsnHistoNote>().Property(item => item.Note2).HasColumnName("NOTE2");
            modelBuilder.Entity<BsnHistoNote>().Property(item => item.Note3).HasColumnName("NOTE3");
            modelBuilder.Entity<BsnHistoNote>().Property(item => item.Note4).HasColumnName("NOTE4");
            modelBuilder.Entity<BsnHistoNote>().Property(item => item.Urgence).HasMaxLength(5);
            modelBuilder.Entity<BsnHistoNote>().Property(item => item.Urgence).HasColumnName("URGENCE");
            modelBuilder.Entity<BsnHistoNote>().Property(item => item.Securite).HasColumnName("SECURITE");
            modelBuilder.Entity<BsnHistoNote>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<BsnCdOrigin>().ToTable("CD_ORIGIN_BSN","BSN");
            modelBuilder.Entity<BsnCdOrigin>().HasKey(item => new {item.Origine });
            modelBuilder.Entity<BsnCdOrigin>().Property(item => item.Origine).IsRequired();
            modelBuilder.Entity<BsnCdOrigin>().Property(item => item.Origine).HasMaxLength(20);
            modelBuilder.Entity<BsnCdOrigin>().Property(item => item.Origine).HasColumnName("ORIGINE");
            modelBuilder.Entity<BsnDictionnaire>().ToTable("DICTIONNAIRE_BSN","BSN");
            modelBuilder.Entity<BsnDictionnaire>().HasKey(item => new {item.Nom });
            modelBuilder.Entity<BsnDictionnaire>().Property(item => item.Nom).IsRequired();
            modelBuilder.Entity<BsnDictionnaire>().Property(item => item.Nom).HasMaxLength(100);
            modelBuilder.Entity<BsnDictionnaire>().Property(item => item.Nom).HasColumnName("NOM");
            modelBuilder.Entity<BsnDictionnaire>().Property(item => item.Description).HasMaxLength(255);
            modelBuilder.Entity<BsnDictionnaire>().Property(item => item.Description).HasColumnName("DESCRIPTION");
            modelBuilder.Entity<BsnDictionnaire>().Property(item => item.Definition).HasMaxLength(500);
            modelBuilder.Entity<BsnDictionnaire>().Property(item => item.Definition).HasColumnName("DEFINITION");
            modelBuilder.Entity<BsnDictionnaire>().Property(item => item.Motscles).HasMaxLength(255);
            modelBuilder.Entity<BsnDictionnaire>().Property(item => item.Motscles).HasColumnName("MOTSCLES");
            modelBuilder.Entity<BsnCdEvt>().ToTable("CD_EVT_BSN","BSN");
            modelBuilder.Entity<BsnCdEvt>().HasKey(item => new {item.Type });
            modelBuilder.Entity<BsnCdEvt>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<BsnCdEvt>().Property(item => item.Type).HasMaxLength(25);
            modelBuilder.Entity<BsnCdEvt>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<BsnCdEvt>().Property(item => item.Impact).HasColumnName("IMPACT");
            modelBuilder.Entity<BsnEvt>().ToTable("EVT_BSN","BSN");
            modelBuilder.Entity<BsnEvt>().HasKey(item => new {item.CdEvtBsnType,item.DscBsnNumBsn,item.DateRel });
            modelBuilder.Entity<BsnEvt>().Property(item => item.CdEvtBsnType).IsRequired();
            modelBuilder.Entity<BsnEvt>().Property(item => item.CdEvtBsnType).HasMaxLength(25);
            modelBuilder.Entity<BsnEvt>().Property(item => item.CdEvtBsnType).HasColumnName("CD_EVT_BSN__TYPE");
            modelBuilder.Entity<BsnEvt>().Property(item => item.DscBsnNumBsn).IsRequired();
            modelBuilder.Entity<BsnEvt>().Property(item => item.DscBsnNumBsn).HasMaxLength(20);
            modelBuilder.Entity<BsnEvt>().Property(item => item.DscBsnNumBsn).HasColumnName("DSC_BSN__NUM_BSN");
            modelBuilder.Entity<BsnEvt>().Property(item => item.DateRel).IsRequired();
            modelBuilder.Entity<BsnEvt>().Property(item => item.DateRel).HasColumnName("DATE_REL");
            modelBuilder.Entity<BsnEvt>().Property(item => item.DateTrt).HasColumnName("DATE_TRT");
            modelBuilder.Entity<BsnEvt>().Property(item => item.Obsv).HasMaxLength(255);
            modelBuilder.Entity<BsnEvt>().Property(item => item.Obsv).HasColumnName("OBSV");
            modelBuilder.Entity<BsnImpluvium>().ToTable("IMPLUVIUM_BSN","BSN");
            modelBuilder.Entity<BsnImpluvium>().HasKey(item => new {item.DscBsnNumBsn,item.Liaison,item.Sens,item.AbsDeb });
            modelBuilder.Entity<BsnImpluvium>().Property(item => item.DscBsnNumBsn).IsRequired();
            modelBuilder.Entity<BsnImpluvium>().Property(item => item.DscBsnNumBsn).HasMaxLength(20);
            modelBuilder.Entity<BsnImpluvium>().Property(item => item.DscBsnNumBsn).HasColumnName("DSC_BSN__NUM_BSN");
            modelBuilder.Entity<BsnImpluvium>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<BsnImpluvium>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<BsnImpluvium>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<BsnImpluvium>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<BsnImpluvium>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<BsnImpluvium>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<BsnImpluvium>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<BsnImpluvium>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<BsnImpluvium>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<BsnImpluvium>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<BsnImpluvium>().Property(item => item.Surface).HasColumnName("SURFACE");
            modelBuilder.Entity<BsnImpluvium>().Property(item => item.Commentaire).HasMaxLength(500);
            modelBuilder.Entity<BsnImpluvium>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<BsnGeometrie>().ToTable("GEOMETRIE_BSN","BSN");
            modelBuilder.Entity<BsnGeometrie>().HasKey(item => new {item.DscBsnNumBsn });
            modelBuilder.Entity<BsnGeometrie>().Property(item => item.DscBsnNumBsn).IsRequired();
            modelBuilder.Entity<BsnGeometrie>().Property(item => item.DscBsnNumBsn).HasMaxLength(20);
            modelBuilder.Entity<BsnGeometrie>().Property(item => item.DscBsnNumBsn).HasColumnName("DSC_BSN__NUM_BSN");
            modelBuilder.Entity<BsnGeometrie>().Property(item => item.Surf).HasColumnName("SURF");
            modelBuilder.Entity<BsnGeometrie>().Property(item => item.Prof).HasColumnName("PROF");
            modelBuilder.Entity<BsnGeometrie>().Property(item => item.Pente).HasColumnName("PENTE");
            modelBuilder.Entity<BsnGeometrie>().Property(item => item.Perimetre).HasColumnName("PERIMETRE");
            modelBuilder.Entity<BsnCdAcces>().ToTable("CD_ACCES_BSN","BSN");
            modelBuilder.Entity<BsnCdAcces>().HasKey(item => new {item.Vacces });
            modelBuilder.Entity<BsnCdAcces>().Property(item => item.Vacces).IsRequired();
            modelBuilder.Entity<BsnCdAcces>().Property(item => item.Vacces).HasMaxLength(60);
            modelBuilder.Entity<BsnCdAcces>().Property(item => item.Vacces).HasColumnName("VACCES");
            modelBuilder.Entity<BsnCdEntete>().ToTable("CD_ENTETE_BSN","BSN");
            modelBuilder.Entity<BsnCdEntete>().HasKey(item => new {item.IdEntete });
            modelBuilder.Entity<BsnCdEntete>().Property(item => item.IdEntete).IsRequired();
            modelBuilder.Entity<BsnCdEntete>().Property(item => item.IdEntete).HasColumnName("ID_ENTETE");
            modelBuilder.Entity<BsnCdEntete>().Property(item => item.CdComposantBsnTypeComp).IsRequired();
            modelBuilder.Entity<BsnCdEntete>().Property(item => item.CdComposantBsnTypeComp).HasMaxLength(6);
            modelBuilder.Entity<BsnCdEntete>().Property(item => item.CdComposantBsnTypeComp).HasColumnName("CD_COMPOSANT_BSN__TYPE_COMP");
            modelBuilder.Entity<BsnCdEntete>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<BsnCdEntete>().Property(item => item.Libelle).HasMaxLength(500);
            modelBuilder.Entity<BsnCdEntete>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<BsnCdEntete>().Property(item => item.OrdreEnt).IsRequired();
            modelBuilder.Entity<BsnCdEntete>().Property(item => item.OrdreEnt).HasColumnName("ORDRE_ENT");
            modelBuilder.Entity<BsnCdEntete>().Property(item => item.Guide).HasMaxLength(500);
            modelBuilder.Entity<BsnCdEntete>().Property(item => item.Guide).HasColumnName("GUIDE");
            modelBuilder.Entity<BsnCdChapitre>().ToTable("CD_CHAPITRE_BSN","BSN");
            modelBuilder.Entity<BsnCdChapitre>().HasKey(item => new {item.IdChap });
            modelBuilder.Entity<BsnCdChapitre>().Property(item => item.IdChap).IsRequired();
            modelBuilder.Entity<BsnCdChapitre>().Property(item => item.IdChap).HasColumnName("ID_CHAP");
            modelBuilder.Entity<BsnCdChapitre>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<BsnCdChapitre>().Property(item => item.Libelle).HasMaxLength(500);
            modelBuilder.Entity<BsnCdChapitre>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<BsnCdChapitre>().Property(item => item.OrdreChap).IsRequired();
            modelBuilder.Entity<BsnCdChapitre>().Property(item => item.OrdreChap).HasColumnName("ORDRE_CHAP");
            modelBuilder.Entity<BsnCdChapitre>().Property(item => item.Ponderation).HasColumnName("PONDERATION");
            modelBuilder.Entity<BsnCdLigne>().ToTable("CD_LIGNE_BSN","BSN");
            modelBuilder.Entity<BsnCdLigne>().HasKey(item => new {item.CdChapitreBsnIdChap,item.IdLigne });
            modelBuilder.Entity<BsnCdLigne>().Property(item => item.CdChapitreBsnIdChap).IsRequired();
            modelBuilder.Entity<BsnCdLigne>().Property(item => item.CdChapitreBsnIdChap).HasColumnName("CD_CHAPITRE_BSN__ID_CHAP");
            modelBuilder.Entity<BsnCdLigne>().Property(item => item.IdLigne).IsRequired();
            modelBuilder.Entity<BsnCdLigne>().Property(item => item.IdLigne).HasColumnName("ID_LIGNE");
            modelBuilder.Entity<BsnCdLigne>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<BsnCdLigne>().Property(item => item.Libelle).HasMaxLength(500);
            modelBuilder.Entity<BsnCdLigne>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<BsnCdLigne>().Property(item => item.OrdreLigne).IsRequired();
            modelBuilder.Entity<BsnCdLigne>().Property(item => item.OrdreLigne).HasColumnName("ORDRE_LIGNE");
            modelBuilder.Entity<BsnEntete>().ToTable("ENTETE_BSN","BSN");
            modelBuilder.Entity<BsnEntete>().HasKey(item => new {item.CampBsnIdCamp,item.DscBsnNumBsn,item.CdEnteteBsnIdEntete });
            modelBuilder.Entity<BsnEntete>().Property(item => item.CampBsnIdCamp).IsRequired();
            modelBuilder.Entity<BsnEntete>().Property(item => item.CampBsnIdCamp).HasMaxLength(100);
            modelBuilder.Entity<BsnEntete>().Property(item => item.CampBsnIdCamp).HasColumnName("CAMP_BSN__ID_CAMP");
            modelBuilder.Entity<BsnEntete>().Property(item => item.DscBsnNumBsn).IsRequired();
            modelBuilder.Entity<BsnEntete>().Property(item => item.DscBsnNumBsn).HasMaxLength(20);
            modelBuilder.Entity<BsnEntete>().Property(item => item.DscBsnNumBsn).HasColumnName("DSC_BSN__NUM_BSN");
            modelBuilder.Entity<BsnEntete>().Property(item => item.CdEnteteBsnIdEntete).IsRequired();
            modelBuilder.Entity<BsnEntete>().Property(item => item.CdEnteteBsnIdEntete).HasColumnName("CD_ENTETE_BSN__ID_ENTETE");
            modelBuilder.Entity<BsnEntete>().Property(item => item.Valeur).HasMaxLength(250);
            modelBuilder.Entity<BsnEntete>().Property(item => item.Valeur).HasColumnName("VALEUR");
            modelBuilder.Entity<BsnCdTypeqp>().ToTable("CD_TYPEQP_BSN","BSN");
            modelBuilder.Entity<BsnCdTypeqp>().HasKey(item => new {item.CdFameqpBsnFam,item.Type });
            modelBuilder.Entity<BsnCdTypeqp>().Property(item => item.CdFameqpBsnFam).IsRequired();
            modelBuilder.Entity<BsnCdTypeqp>().Property(item => item.CdFameqpBsnFam).HasMaxLength(25);
            modelBuilder.Entity<BsnCdTypeqp>().Property(item => item.CdFameqpBsnFam).HasColumnName("CD_FAMEQP_BSN__FAM");
            modelBuilder.Entity<BsnCdTypeqp>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<BsnCdTypeqp>().Property(item => item.Type).HasMaxLength(60);
            modelBuilder.Entity<BsnCdTypeqp>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<BsnCdTypeqp>().Property(item => item.Garantie).HasColumnName("GARANTIE");
            modelBuilder.Entity<BsnCdTypeqp>().Property(item => item.Dvt).HasColumnName("DVT");
            modelBuilder.Entity<BsnCdFameqp>().ToTable("CD_FAMEQP_BSN","BSN");
            modelBuilder.Entity<BsnCdFameqp>().HasKey(item => new {item.Fam });
            modelBuilder.Entity<BsnCdFameqp>().Property(item => item.Fam).IsRequired();
            modelBuilder.Entity<BsnCdFameqp>().Property(item => item.Fam).HasMaxLength(25);
            modelBuilder.Entity<BsnCdFameqp>().Property(item => item.Fam).HasColumnName("FAM");
            modelBuilder.Entity<BsnEquipement>().ToTable("EQUIPEMENT_BSN","BSN");
            modelBuilder.Entity<BsnEquipement>().HasKey(item => new {item.CdFameqpBsnFam,item.CdTypeqpBsnType,item.DscBsnNumBsn,item.Position });
            modelBuilder.Entity<BsnEquipement>().Property(item => item.CdFameqpBsnFam).IsRequired();
            modelBuilder.Entity<BsnEquipement>().Property(item => item.CdFameqpBsnFam).HasMaxLength(25);
            modelBuilder.Entity<BsnEquipement>().Property(item => item.CdFameqpBsnFam).HasColumnName("CD_FAMEQP_BSN__FAM");
            modelBuilder.Entity<BsnEquipement>().Property(item => item.CdTypeqpBsnType).IsRequired();
            modelBuilder.Entity<BsnEquipement>().Property(item => item.CdTypeqpBsnType).HasMaxLength(60);
            modelBuilder.Entity<BsnEquipement>().Property(item => item.CdTypeqpBsnType).HasColumnName("CD_TYPEQP_BSN__TYPE");
            modelBuilder.Entity<BsnEquipement>().Property(item => item.DscBsnNumBsn).IsRequired();
            modelBuilder.Entity<BsnEquipement>().Property(item => item.DscBsnNumBsn).HasMaxLength(20);
            modelBuilder.Entity<BsnEquipement>().Property(item => item.DscBsnNumBsn).HasColumnName("DSC_BSN__NUM_BSN");
            modelBuilder.Entity<BsnEquipement>().Property(item => item.Position).IsRequired();
            modelBuilder.Entity<BsnEquipement>().Property(item => item.Position).HasMaxLength(60);
            modelBuilder.Entity<BsnEquipement>().Property(item => item.Position).HasColumnName("POSITION");
            modelBuilder.Entity<BsnEquipement>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<BsnEquipement>().Property(item => item.Commentaire).HasMaxLength(500);
            modelBuilder.Entity<BsnEquipement>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<BsnContact>().ToTable("CONTACT_BSN","BSN");
            modelBuilder.Entity<BsnContact>().HasKey(item => new {item.DocBsnId });
            modelBuilder.Entity<BsnContact>().Property(item => item.DocBsnId).IsRequired();
            modelBuilder.Entity<BsnContact>().Property(item => item.DocBsnId).HasColumnName("DOC_BSN__ID");
            modelBuilder.Entity<BsnContact>().Property(item => item.Givenname).HasMaxLength(60);
            modelBuilder.Entity<BsnContact>().Property(item => item.Givenname).HasColumnName("GIVENNAME");
            modelBuilder.Entity<BsnContact>().Property(item => item.Sn).HasMaxLength(60);
            modelBuilder.Entity<BsnContact>().Property(item => item.Sn).HasColumnName("SN");
            modelBuilder.Entity<BsnContact>().Property(item => item.Cn).HasMaxLength(125);
            modelBuilder.Entity<BsnContact>().Property(item => item.Cn).HasColumnName("CN");
            modelBuilder.Entity<BsnContact>().Property(item => item.O).HasMaxLength(60);
            modelBuilder.Entity<BsnContact>().Property(item => item.O).HasColumnName("O");
            modelBuilder.Entity<BsnContact>().Property(item => item.Mail).HasMaxLength(60);
            modelBuilder.Entity<BsnContact>().Property(item => item.Mail).HasColumnName("MAIL");
            modelBuilder.Entity<BsnContact>().Property(item => item.Telephonenumber).HasMaxLength(20);
            modelBuilder.Entity<BsnContact>().Property(item => item.Telephonenumber).HasColumnName("TELEPHONENUMBER");
            modelBuilder.Entity<BsnContact>().Property(item => item.Mobile).HasMaxLength(20);
            modelBuilder.Entity<BsnContact>().Property(item => item.Mobile).HasColumnName("MOBILE");
            modelBuilder.Entity<BsnContact>().Property(item => item.Facsimiletelephonenumber).HasMaxLength(20);
            modelBuilder.Entity<BsnContact>().Property(item => item.Facsimiletelephonenumber).HasColumnName("FACSIMILETELEPHONENUMBER");
            modelBuilder.Entity<BsnContact>().Property(item => item.Street).HasMaxLength(60);
            modelBuilder.Entity<BsnContact>().Property(item => item.Street).HasColumnName("STREET");
            modelBuilder.Entity<BsnContact>().Property(item => item.Mozillaworkstreet2).HasMaxLength(60);
            modelBuilder.Entity<BsnContact>().Property(item => item.Mozillaworkstreet2).HasColumnName("MOZILLAWORKSTREET2");
            modelBuilder.Entity<BsnContact>().Property(item => item.L).HasMaxLength(60);
            modelBuilder.Entity<BsnContact>().Property(item => item.L).HasColumnName("L");
            modelBuilder.Entity<BsnContact>().Property(item => item.Postalcode).HasMaxLength(12);
            modelBuilder.Entity<BsnContact>().Property(item => item.Postalcode).HasColumnName("POSTALCODE");
            modelBuilder.Entity<BsnContact>().Property(item => item.Modifytimestamp).HasColumnName("MODIFYTIMESTAMP");
            modelBuilder.Entity<BsnCdUnite>().ToTable("CD_UNITE_BSN","BSN");
            modelBuilder.Entity<BsnCdUnite>().HasKey(item => new {item.Unite });
            modelBuilder.Entity<BsnCdUnite>().Property(item => item.Unite).IsRequired();
            modelBuilder.Entity<BsnCdUnite>().Property(item => item.Unite).HasMaxLength(12);
            modelBuilder.Entity<BsnCdUnite>().Property(item => item.Unite).HasColumnName("UNITE");
            modelBuilder.Entity<BsnInspecteur>().ToTable("INSPECTEUR_BSN","BSN");
            modelBuilder.Entity<BsnInspecteur>().HasKey(item => new {item.Nom });
            modelBuilder.Entity<BsnInspecteur>().Property(item => item.Nom).IsRequired();
            modelBuilder.Entity<BsnInspecteur>().Property(item => item.Nom).HasMaxLength(60);
            modelBuilder.Entity<BsnInspecteur>().Property(item => item.Nom).HasColumnName("NOM");
            modelBuilder.Entity<BsnInspecteur>().Property(item => item.CdPrestaBsnPrestataire).IsRequired();
            modelBuilder.Entity<BsnInspecteur>().Property(item => item.CdPrestaBsnPrestataire).HasMaxLength(50);
            modelBuilder.Entity<BsnInspecteur>().Property(item => item.CdPrestaBsnPrestataire).HasColumnName("CD_PRESTA_BSN__PRESTATAIRE");
            modelBuilder.Entity<BsnInspecteur>().Property(item => item.Fonc).HasMaxLength(60);
            modelBuilder.Entity<BsnInspecteur>().Property(item => item.Fonc).HasColumnName("FONC");
            modelBuilder.Entity<BsnCdComposant>().ToTable("CD_COMPOSANT_BSN","BSN");
            modelBuilder.Entity<BsnCdComposant>().HasKey(item => new {item.TypeComp });
            modelBuilder.Entity<BsnCdComposant>().Property(item => item.TypeComp).IsRequired();
            modelBuilder.Entity<BsnCdComposant>().Property(item => item.TypeComp).HasMaxLength(6);
            modelBuilder.Entity<BsnCdComposant>().Property(item => item.TypeComp).HasColumnName("TYPE_COMP");
            modelBuilder.Entity<BsnCdComposant>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<BsnCdComposant>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<BsnCdSousType>().ToTable("CD_SOUS_TYPE_BSN","BSN");
            modelBuilder.Entity<BsnCdSousType>().HasKey(item => new {item.NatSensib });
            modelBuilder.Entity<BsnCdSousType>().Property(item => item.NatSensib).IsRequired();
            modelBuilder.Entity<BsnCdSousType>().Property(item => item.NatSensib).HasMaxLength(60);
            modelBuilder.Entity<BsnCdSousType>().Property(item => item.NatSensib).HasColumnName("NAT_SENSIB");
            modelBuilder.Entity<BsnCdFrequence>().ToTable("CD_FREQUENCE_BSN","BSN");
            modelBuilder.Entity<BsnCdFrequence>().HasKey(item => new {item.Freq });
            modelBuilder.Entity<BsnCdFrequence>().Property(item => item.Freq).IsRequired();
            modelBuilder.Entity<BsnCdFrequence>().Property(item => item.Freq).HasMaxLength(25);
            modelBuilder.Entity<BsnCdFrequence>().Property(item => item.Freq).HasColumnName("FREQ");
            modelBuilder.Entity<BsnCdRole>().ToTable("CD_ROLE_BSN","BSN");
            modelBuilder.Entity<BsnCdRole>().HasKey(item => new {item.Role });
            modelBuilder.Entity<BsnCdRole>().Property(item => item.Role).IsRequired();
            modelBuilder.Entity<BsnCdRole>().Property(item => item.Role).HasMaxLength(25);
            modelBuilder.Entity<BsnCdRole>().Property(item => item.Role).HasColumnName("ROLE");
            modelBuilder.Entity<BsnCdConclusion>().ToTable("CD_CONCLUSION_BSN","BSN");
            modelBuilder.Entity<BsnCdConclusion>().HasKey(item => new {item.IdConc });
            modelBuilder.Entity<BsnCdConclusion>().Property(item => item.IdConc).IsRequired();
            modelBuilder.Entity<BsnCdConclusion>().Property(item => item.IdConc).HasColumnName("ID_CONC");
            modelBuilder.Entity<BsnCdConclusion>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<BsnCdConclusion>().Property(item => item.Libelle).HasMaxLength(500);
            modelBuilder.Entity<BsnCdConclusion>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<BsnCdConclusion>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<BsnCdConclusion>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<BsnDscTemp>().ToTable("DSC_TEMP_BSN","BSN");
            modelBuilder.Entity<BsnDscTemp>().HasKey(item => new {item.CampBsnIdCamp,item.NumBsn });
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.CampBsnIdCamp).IsRequired();
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.CampBsnIdCamp).HasMaxLength(100);
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.CampBsnIdCamp).HasColumnName("CAMP_BSN__ID_CAMP");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.NumBsn).IsRequired();
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.NumBsn).HasMaxLength(20);
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.NumBsn).HasColumnName("NUM_BSN");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.DscBsnNumBsn).HasMaxLength(20);
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.DscBsnNumBsn).HasColumnName("DSC_BSN__NUM_BSN");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.CdPermeableBsnType).HasMaxLength(60);
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.CdPermeableBsnType).HasColumnName("CD_PERMEABLE_BSN__TYPE");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.CdSousTypeBsnNatSensib).HasMaxLength(60);
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.CdSousTypeBsnNatSensib).HasColumnName("CD_SOUS_TYPE_BSN__NAT_SENSIB");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.CdExtBsnType).HasMaxLength(60);
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.CdExtBsnType).HasColumnName("CD_EXT_BSN__TYPE");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.CdTypeBsnType).IsRequired();
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.CdTypeBsnType).HasMaxLength(60);
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.CdTypeBsnType).HasColumnName("CD_TYPE_BSN__TYPE");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.CdAccesBsnVacces).HasMaxLength(60);
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.CdAccesBsnVacces).HasColumnName("CD_ACCES_BSN__VACCES");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.CdFamBsnFamille).IsRequired();
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.CdFamBsnFamille).HasMaxLength(60);
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.CdFamBsnFamille).HasColumnName("CD_FAM_BSN__FAMILLE");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.CdFrequenceBsnFreq).HasMaxLength(25);
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.CdFrequenceBsnFreq).HasColumnName("CD_FREQUENCE_BSN__FREQ");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.CdEntpBsnEntreprise).HasMaxLength(60);
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.CdEntpBsnEntreprise).HasColumnName("CD_ENTP_BSN__ENTREPRISE");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.NumExploit).HasMaxLength(30);
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.NumExploit).HasColumnName("NUM_EXPLOIT");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.VolUtil).HasColumnName("VOL_UTIL");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.VolMor).HasColumnName("VOL_MOR");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.VolPoll).HasColumnName("VOL_POLL");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.VolIncen).HasColumnName("VOL_INCEN");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.DureePluie).HasColumnName("DUREE_PLUIE");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.FauneFlore).HasMaxLength(60);
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.FauneFlore).HasColumnName("FAUNE_FLORE");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.SurfVersant).HasColumnName("SURF_VERSANT");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.DebitMax).HasColumnName("DEBIT_MAX");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.TpsConcent).HasColumnName("TPS_CONCENT");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.Vehicule).HasMaxLength(255);
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.Vehicule).HasColumnName("VEHICULE");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.Pieton).HasMaxLength(255);
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.Pieton).HasColumnName("PIETON");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.Note1).HasColumnName("NOTE1");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.Note2).HasColumnName("NOTE2");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.Note3).HasColumnName("NOTE3");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.Note4).HasColumnName("NOTE4");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.Urgence).HasMaxLength(5);
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.Urgence).HasColumnName("URGENCE");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.DescInva).HasMaxLength(1000);
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.DescInva).HasColumnName("DESC_INVA");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.Securite).HasColumnName("SECURITE");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.ProsurvAnnee).HasColumnName("PROSURV_ANNEE");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.DernInsp).HasColumnName("DERN_INSP");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.DernVst).HasColumnName("DERN_VST");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.NoteVst).HasMaxLength(5);
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.NoteVst).HasColumnName("NOTE_VST");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.Archive).HasMaxLength(255);
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.Archive).HasColumnName("ARCHIVE");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.OuvAval).HasMaxLength(200);
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.OuvAval).HasColumnName("OUV_AVAL");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.LoiEau).HasColumnName("LOI_EAU");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.EauxCollect).HasMaxLength(200);
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.EauxCollect).HasColumnName("EAUX_COLLECT");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.Commentaire).HasMaxLength(1000);
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.X1).HasColumnName("X1");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.Y1).HasColumnName("Y1");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.Z1).HasColumnName("Z1");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.DateReleve).HasColumnName("DATE_RELEVE");
            modelBuilder.Entity<BsnDscTemp>().Property(item => item.Terrain).HasColumnName("TERRAIN");
            modelBuilder.Entity<BsnPhotoInspTmp>().ToTable("PHOTO_INSP_TMP_BSN","BSN");
            modelBuilder.Entity<BsnPhotoInspTmp>().HasKey(item => new {item.Id });
            modelBuilder.Entity<BsnPhotoInspTmp>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<BsnPhotoInspTmp>().Property(item => item.Id).HasMaxLength(30);
            modelBuilder.Entity<BsnPhotoInspTmp>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<BsnPhotoInspTmp>().Property(item => item.CampBsnIdCamp).IsRequired();
            modelBuilder.Entity<BsnPhotoInspTmp>().Property(item => item.CampBsnIdCamp).HasMaxLength(100);
            modelBuilder.Entity<BsnPhotoInspTmp>().Property(item => item.CampBsnIdCamp).HasColumnName("CAMP_BSN__ID_CAMP");
            modelBuilder.Entity<BsnPhotoInspTmp>().Property(item => item.DscTempBsnNumBsn).IsRequired();
            modelBuilder.Entity<BsnPhotoInspTmp>().Property(item => item.DscTempBsnNumBsn).HasMaxLength(20);
            modelBuilder.Entity<BsnPhotoInspTmp>().Property(item => item.DscTempBsnNumBsn).HasColumnName("DSC_TEMP_BSN__NUM_BSN");
            modelBuilder.Entity<BsnPhotoInspTmp>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<BsnPhotoInspTmp>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<BsnPhotoEltInspTmp>().ToTable("PHOTO_ELT_INSP_TMP_BSN","BSN");
            modelBuilder.Entity<BsnPhotoEltInspTmp>().HasKey(item => new {item.GrpBsnIdGrp,item.PrtBsnIdPrt,item.SprtBsnIdSprt,item.CampBsnIdCamp,item.DscTempBsnNumBsn,item.EltBsnIdElem,item.Id });
            modelBuilder.Entity<BsnPhotoEltInspTmp>().Property(item => item.GrpBsnIdGrp).IsRequired();
            modelBuilder.Entity<BsnPhotoEltInspTmp>().Property(item => item.GrpBsnIdGrp).HasColumnName("GRP_BSN__ID_GRP");
            modelBuilder.Entity<BsnPhotoEltInspTmp>().Property(item => item.PrtBsnIdPrt).IsRequired();
            modelBuilder.Entity<BsnPhotoEltInspTmp>().Property(item => item.PrtBsnIdPrt).HasColumnName("PRT_BSN__ID_PRT");
            modelBuilder.Entity<BsnPhotoEltInspTmp>().Property(item => item.SprtBsnIdSprt).IsRequired();
            modelBuilder.Entity<BsnPhotoEltInspTmp>().Property(item => item.SprtBsnIdSprt).HasColumnName("SPRT_BSN__ID_SPRT");
            modelBuilder.Entity<BsnPhotoEltInspTmp>().Property(item => item.CampBsnIdCamp).IsRequired();
            modelBuilder.Entity<BsnPhotoEltInspTmp>().Property(item => item.CampBsnIdCamp).HasMaxLength(100);
            modelBuilder.Entity<BsnPhotoEltInspTmp>().Property(item => item.CampBsnIdCamp).HasColumnName("CAMP_BSN__ID_CAMP");
            modelBuilder.Entity<BsnPhotoEltInspTmp>().Property(item => item.DscTempBsnNumBsn).IsRequired();
            modelBuilder.Entity<BsnPhotoEltInspTmp>().Property(item => item.DscTempBsnNumBsn).HasMaxLength(20);
            modelBuilder.Entity<BsnPhotoEltInspTmp>().Property(item => item.DscTempBsnNumBsn).HasColumnName("DSC_TEMP_BSN__NUM_BSN");
            modelBuilder.Entity<BsnPhotoEltInspTmp>().Property(item => item.EltBsnIdElem).IsRequired();
            modelBuilder.Entity<BsnPhotoEltInspTmp>().Property(item => item.EltBsnIdElem).HasColumnName("ELT_BSN__ID_ELEM");
            modelBuilder.Entity<BsnPhotoEltInspTmp>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<BsnPhotoEltInspTmp>().Property(item => item.Id).HasMaxLength(50);
            modelBuilder.Entity<BsnPhotoEltInspTmp>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<BsnPhotoEltInspTmp>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<BsnPhotoEltInspTmp>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<BsnEltInspTmp>().ToTable("ELT_INSP_TMP_BSN","BSN");
            modelBuilder.Entity<BsnEltInspTmp>().HasKey(item => new {item.CampBsnIdCamp,item.DscTempBsnNumBsn,item.GrpBsnIdGrp,item.PrtBsnIdPrt,item.SprtBsnIdSprt,item.EltBsnIdElem });
            modelBuilder.Entity<BsnEltInspTmp>().Property(item => item.CampBsnIdCamp).IsRequired();
            modelBuilder.Entity<BsnEltInspTmp>().Property(item => item.CampBsnIdCamp).HasMaxLength(100);
            modelBuilder.Entity<BsnEltInspTmp>().Property(item => item.CampBsnIdCamp).HasColumnName("CAMP_BSN__ID_CAMP");
            modelBuilder.Entity<BsnEltInspTmp>().Property(item => item.DscTempBsnNumBsn).IsRequired();
            modelBuilder.Entity<BsnEltInspTmp>().Property(item => item.DscTempBsnNumBsn).HasMaxLength(20);
            modelBuilder.Entity<BsnEltInspTmp>().Property(item => item.DscTempBsnNumBsn).HasColumnName("DSC_TEMP_BSN__NUM_BSN");
            modelBuilder.Entity<BsnEltInspTmp>().Property(item => item.GrpBsnIdGrp).IsRequired();
            modelBuilder.Entity<BsnEltInspTmp>().Property(item => item.GrpBsnIdGrp).HasColumnName("GRP_BSN__ID_GRP");
            modelBuilder.Entity<BsnEltInspTmp>().Property(item => item.PrtBsnIdPrt).IsRequired();
            modelBuilder.Entity<BsnEltInspTmp>().Property(item => item.PrtBsnIdPrt).HasColumnName("PRT_BSN__ID_PRT");
            modelBuilder.Entity<BsnEltInspTmp>().Property(item => item.SprtBsnIdSprt).IsRequired();
            modelBuilder.Entity<BsnEltInspTmp>().Property(item => item.SprtBsnIdSprt).HasColumnName("SPRT_BSN__ID_SPRT");
            modelBuilder.Entity<BsnEltInspTmp>().Property(item => item.EltBsnIdElem).IsRequired();
            modelBuilder.Entity<BsnEltInspTmp>().Property(item => item.EltBsnIdElem).HasColumnName("ELT_BSN__ID_ELEM");
            modelBuilder.Entity<BsnEltInspTmp>().Property(item => item.Indice).IsRequired();
            modelBuilder.Entity<BsnEltInspTmp>().Property(item => item.Indice).HasColumnName("INDICE");
            modelBuilder.Entity<BsnEltInspTmp>().Property(item => item.Obs).HasMaxLength(255);
            modelBuilder.Entity<BsnEltInspTmp>().Property(item => item.Obs).HasColumnName("OBS");
            modelBuilder.Entity<BsnInspTmp>().ToTable("INSP_TMP_BSN","BSN");
            modelBuilder.Entity<BsnInspTmp>().HasKey(item => new {item.CampBsnIdCamp,item.DscTempBsnNumBsn });
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.CampBsnIdCamp).IsRequired();
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.CampBsnIdCamp).HasMaxLength(100);
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.CampBsnIdCamp).HasColumnName("CAMP_BSN__ID_CAMP");
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.DscTempBsnNumBsn).IsRequired();
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.DscTempBsnNumBsn).HasMaxLength(20);
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.DscTempBsnNumBsn).HasColumnName("DSC_TEMP_BSN__NUM_BSN");
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.InspecteurBsnNom).HasMaxLength(60);
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.InspecteurBsnNom).HasColumnName("INSPECTEUR_BSN__NOM");
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.CdMeteoBsnMeteo).HasMaxLength(60);
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.CdMeteoBsnMeteo).HasColumnName("CD_METEO_BSN__METEO");
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.CdEtudeBsnEtude).HasMaxLength(65);
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.CdEtudeBsnEtude).HasColumnName("CD_ETUDE_BSN__ETUDE");
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.Etat).IsRequired();
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.Etat).HasMaxLength(25);
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.Etat).HasColumnName("ETAT");
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.Datev).HasColumnName("DATEV");
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.Temperature).HasColumnName("TEMPERATURE");
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.Moyen).HasMaxLength(500);
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.Moyen).HasColumnName("MOYEN");
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.Conditions).HasMaxLength(500);
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.Conditions).HasColumnName("CONDITIONS");
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.DateValid).HasColumnName("DATE_VALID");
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.NomValid).HasMaxLength(250);
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.NomValid).HasColumnName("NOM_VALID");
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.DescInva).HasMaxLength(1000);
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.DescInva).HasColumnName("DESC_INVA");
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.Securite).HasMaxLength(1000);
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.Securite).HasColumnName("SECURITE");
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.Prioritaire).HasMaxLength(1000);
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.Note1).HasColumnName("NOTE1");
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.Note2).HasColumnName("NOTE2");
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.Note3).HasColumnName("NOTE3");
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.Note4).HasColumnName("NOTE4");
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.Urgence).HasMaxLength(5);
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.Urgence).HasColumnName("URGENCE");
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.Qualite).HasMaxLength(25);
            modelBuilder.Entity<BsnInspTmp>().Property(item => item.Qualite).HasColumnName("QUALITE");
            modelBuilder.Entity<BsnClsDoc>().ToTable("CLS_DOC_BSN","BSN");
            modelBuilder.Entity<BsnClsDoc>().HasKey(item => new {item.ClsBsnId,item.DocBsnId });
            modelBuilder.Entity<BsnClsDoc>().Property(item => item.ClsBsnId).IsRequired();
            modelBuilder.Entity<BsnClsDoc>().Property(item => item.ClsBsnId).HasColumnName("CLS_BSN__ID");
            modelBuilder.Entity<BsnClsDoc>().Property(item => item.DocBsnId).IsRequired();
            modelBuilder.Entity<BsnClsDoc>().Property(item => item.DocBsnId).HasColumnName("DOC_BSN__ID");
            modelBuilder.Entity<BsnClsDoc>().Property(item => item.Defaut).HasColumnName("DEFAUT");
            modelBuilder.Entity<BsnClsDoc>().Property(item => item.Dossier).HasMaxLength(15);
            modelBuilder.Entity<BsnClsDoc>().Property(item => item.Dossier).HasColumnName("DOSSIER");
            modelBuilder.Entity<BsnCdConclusionInsp>().ToTable("CD_CONCLUSION__INSP_BSN","BSN");
            modelBuilder.Entity<BsnCdConclusionInsp>().HasKey(item => new {item.CampBsnIdCamp,item.DscBsnNumBsn,item.CdConclusionBsnIdConc });
            modelBuilder.Entity<BsnCdConclusionInsp>().Property(item => item.CampBsnIdCamp).IsRequired();
            modelBuilder.Entity<BsnCdConclusionInsp>().Property(item => item.CampBsnIdCamp).HasMaxLength(100);
            modelBuilder.Entity<BsnCdConclusionInsp>().Property(item => item.CampBsnIdCamp).HasColumnName("CAMP_BSN__ID_CAMP");
            modelBuilder.Entity<BsnCdConclusionInsp>().Property(item => item.DscBsnNumBsn).IsRequired();
            modelBuilder.Entity<BsnCdConclusionInsp>().Property(item => item.DscBsnNumBsn).HasMaxLength(20);
            modelBuilder.Entity<BsnCdConclusionInsp>().Property(item => item.DscBsnNumBsn).HasColumnName("DSC_BSN__NUM_BSN");
            modelBuilder.Entity<BsnCdConclusionInsp>().Property(item => item.CdConclusionBsnIdConc).IsRequired();
            modelBuilder.Entity<BsnCdConclusionInsp>().Property(item => item.CdConclusionBsnIdConc).HasColumnName("CD_CONCLUSION_BSN__ID_CONC");
            modelBuilder.Entity<BsnCdConclusionInsp>().Property(item => item.Contenu).HasMaxLength(1000);
            modelBuilder.Entity<BsnCdConclusionInsp>().Property(item => item.Contenu).HasColumnName("CONTENU");
            modelBuilder.Entity<BsnDscCamp>().ToTable("DSC_CAMP_BSN","BSN");
            modelBuilder.Entity<BsnDscCamp>().HasKey(item => new {item.DscBsnNumBsn,item.CampBsnIdCamp });
            modelBuilder.Entity<BsnDscCamp>().Property(item => item.DscBsnNumBsn).IsRequired();
            modelBuilder.Entity<BsnDscCamp>().Property(item => item.DscBsnNumBsn).HasMaxLength(20);
            modelBuilder.Entity<BsnDscCamp>().Property(item => item.DscBsnNumBsn).HasColumnName("DSC_BSN__NUM_BSN");
            modelBuilder.Entity<BsnDscCamp>().Property(item => item.CampBsnIdCamp).IsRequired();
            modelBuilder.Entity<BsnDscCamp>().Property(item => item.CampBsnIdCamp).HasMaxLength(100);
            modelBuilder.Entity<BsnDscCamp>().Property(item => item.CampBsnIdCamp).HasColumnName("CAMP_BSN__ID_CAMP");
            modelBuilder.Entity<BsnDscCamp>().Property(item => item.Realiser).HasColumnName("REALISER");
            modelBuilder.Entity<BsnCdPrecoSprtVst>().ToTable("CD_PRECO__SPRT_VST_BSN","BSN");
            modelBuilder.Entity<BsnCdPrecoSprtVst>().HasKey(item => new {item.CampBsnIdCamp,item.DscBsnNumBsn,item.CdChapitreBsnIdChap,item.CdLigneBsnIdLigne,item.BpuBsnIdBpu });
            modelBuilder.Entity<BsnCdPrecoSprtVst>().Property(item => item.CampBsnIdCamp).IsRequired();
            modelBuilder.Entity<BsnCdPrecoSprtVst>().Property(item => item.CampBsnIdCamp).HasMaxLength(100);
            modelBuilder.Entity<BsnCdPrecoSprtVst>().Property(item => item.CampBsnIdCamp).HasColumnName("CAMP_BSN__ID_CAMP");
            modelBuilder.Entity<BsnCdPrecoSprtVst>().Property(item => item.DscBsnNumBsn).IsRequired();
            modelBuilder.Entity<BsnCdPrecoSprtVst>().Property(item => item.DscBsnNumBsn).HasMaxLength(20);
            modelBuilder.Entity<BsnCdPrecoSprtVst>().Property(item => item.DscBsnNumBsn).HasColumnName("DSC_BSN__NUM_BSN");
            modelBuilder.Entity<BsnCdPrecoSprtVst>().Property(item => item.CdChapitreBsnIdChap).IsRequired();
            modelBuilder.Entity<BsnCdPrecoSprtVst>().Property(item => item.CdChapitreBsnIdChap).HasColumnName("CD_CHAPITRE_BSN__ID_CHAP");
            modelBuilder.Entity<BsnCdPrecoSprtVst>().Property(item => item.CdLigneBsnIdLigne).IsRequired();
            modelBuilder.Entity<BsnCdPrecoSprtVst>().Property(item => item.CdLigneBsnIdLigne).HasColumnName("CD_LIGNE_BSN__ID_LIGNE");
            modelBuilder.Entity<BsnCdPrecoSprtVst>().Property(item => item.BpuBsnIdBpu).IsRequired();
            modelBuilder.Entity<BsnCdPrecoSprtVst>().Property(item => item.BpuBsnIdBpu).HasColumnName("BPU_BSN__ID_BPU");
            modelBuilder.Entity<BsnCdPrecoSprtVst>().Property(item => item.Realise).HasColumnName("REALISE");
            modelBuilder.Entity<BsnCdRoleDsc>().ToTable("CD_ROLE__DSC_BSN","BSN");
            modelBuilder.Entity<BsnCdRoleDsc>().HasKey(item => new {item.DscBsnNumBsn,item.CdRoleBsnRole });
            modelBuilder.Entity<BsnCdRoleDsc>().Property(item => item.DscBsnNumBsn).IsRequired();
            modelBuilder.Entity<BsnCdRoleDsc>().Property(item => item.DscBsnNumBsn).HasMaxLength(20);
            modelBuilder.Entity<BsnCdRoleDsc>().Property(item => item.DscBsnNumBsn).HasColumnName("DSC_BSN__NUM_BSN");
            modelBuilder.Entity<BsnCdRoleDsc>().Property(item => item.CdRoleBsnRole).IsRequired();
            modelBuilder.Entity<BsnCdRoleDsc>().Property(item => item.CdRoleBsnRole).HasMaxLength(25);
            modelBuilder.Entity<BsnCdRoleDsc>().Property(item => item.CdRoleBsnRole).HasColumnName("CD_ROLE_BSN__ROLE");
            modelBuilder.Entity<BsnCdConclusionInspTmp>().ToTable("CD_CONCLUSION__INSP_TMP_BSN","BSN");
            modelBuilder.Entity<BsnCdConclusionInspTmp>().HasKey(item => new {item.CampBsnIdCamp,item.DscTempBsnNumBsn,item.CdConclusionBsnIdConc });
            modelBuilder.Entity<BsnCdConclusionInspTmp>().Property(item => item.CampBsnIdCamp).IsRequired();
            modelBuilder.Entity<BsnCdConclusionInspTmp>().Property(item => item.CampBsnIdCamp).HasMaxLength(100);
            modelBuilder.Entity<BsnCdConclusionInspTmp>().Property(item => item.CampBsnIdCamp).HasColumnName("CAMP_BSN__ID_CAMP");
            modelBuilder.Entity<BsnCdConclusionInspTmp>().Property(item => item.DscTempBsnNumBsn).IsRequired();
            modelBuilder.Entity<BsnCdConclusionInspTmp>().Property(item => item.DscTempBsnNumBsn).HasMaxLength(20);
            modelBuilder.Entity<BsnCdConclusionInspTmp>().Property(item => item.DscTempBsnNumBsn).HasColumnName("DSC_TEMP_BSN__NUM_BSN");
            modelBuilder.Entity<BsnCdConclusionInspTmp>().Property(item => item.CdConclusionBsnIdConc).IsRequired();
            modelBuilder.Entity<BsnCdConclusionInspTmp>().Property(item => item.CdConclusionBsnIdConc).HasColumnName("CD_CONCLUSION_BSN__ID_CONC");
            modelBuilder.Entity<BsnCdConclusionInspTmp>().Property(item => item.Contenu).HasMaxLength(1000);
            modelBuilder.Entity<BsnCdConclusionInspTmp>().Property(item => item.Contenu).HasColumnName("CONTENU");
            modelBuilder.Entity<ChsCdCou>().ToTable("CD_COU_CHS","CHS");
            modelBuilder.Entity<ChsCdCou>().HasKey(item => new {item.Couche });
            modelBuilder.Entity<ChsCdCou>().Property(item => item.Couche).IsRequired();
            modelBuilder.Entity<ChsCdCou>().Property(item => item.Couche).HasMaxLength(14);
            modelBuilder.Entity<ChsCdCou>().Property(item => item.Couche).HasColumnName("COUCHE");
            modelBuilder.Entity<ChsCdCou>().Property(item => item.Posit).IsRequired();
            modelBuilder.Entity<ChsCdCou>().Property(item => item.Posit).HasColumnName("POSIT");
            modelBuilder.Entity<ChsCdCou>().Property(item => item.Couleur).HasMaxLength(16);
            modelBuilder.Entity<ChsCdCou>().Property(item => item.Couleur).HasColumnName("COULEUR");
            modelBuilder.Entity<ChsCdEntp>().ToTable("CD_ENTP_CHS","CHS");
            modelBuilder.Entity<ChsCdEntp>().HasKey(item => new {item.Entreprise });
            modelBuilder.Entity<ChsCdEntp>().Property(item => item.Entreprise).IsRequired();
            modelBuilder.Entity<ChsCdEntp>().Property(item => item.Entreprise).HasMaxLength(60);
            modelBuilder.Entity<ChsCdEntp>().Property(item => item.Entreprise).HasColumnName("ENTREPRISE");
            modelBuilder.Entity<ChsCdTech>().ToTable("CD_TECH_CHS","CHS");
            modelBuilder.Entity<ChsCdTech>().HasKey(item => new {item.CdFamTechChsCode,item.Technique });
            modelBuilder.Entity<ChsCdTech>().Property(item => item.CdFamTechChsCode).IsRequired();
            modelBuilder.Entity<ChsCdTech>().Property(item => item.CdFamTechChsCode).HasMaxLength(15);
            modelBuilder.Entity<ChsCdTech>().Property(item => item.CdFamTechChsCode).HasColumnName("CD_FAM_TECH_CHS__CODE");
            modelBuilder.Entity<ChsCdTech>().Property(item => item.Technique).IsRequired();
            modelBuilder.Entity<ChsCdTech>().Property(item => item.Technique).HasMaxLength(12);
            modelBuilder.Entity<ChsCdTech>().Property(item => item.Technique).HasColumnName("TECHNIQUE");
            modelBuilder.Entity<ChsCdTech>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<ChsCdTech>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<ChsCdTech>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<ChsCdTech>().Property(item => item.Garantie).HasColumnName("GARANTIE");
            modelBuilder.Entity<ChsCdTech>().Property(item => item.Dvt).HasColumnName("DVT");
            modelBuilder.Entity<ChsPave>().ToTable("PAVE_CHS","CHS");
            modelBuilder.Entity<ChsPave>().HasKey(item => new {item.CdCouChsCouche,item.DateMs,item.Liaison,item.Sens,item.AbsDeb,item.AbsFin });
            modelBuilder.Entity<ChsPave>().Property(item => item.CdCouChsCouche).IsRequired();
            modelBuilder.Entity<ChsPave>().Property(item => item.CdCouChsCouche).HasMaxLength(14);
            modelBuilder.Entity<ChsPave>().Property(item => item.CdCouChsCouche).HasColumnName("CD_COU_CHS__COUCHE");
            modelBuilder.Entity<ChsPave>().Property(item => item.DateMs).IsRequired();
            modelBuilder.Entity<ChsPave>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<ChsPave>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<ChsPave>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<ChsPave>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<ChsPave>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<ChsPave>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<ChsPave>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<ChsPave>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<ChsPave>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<ChsPave>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<ChsPave>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<ChsPave>().Property(item => item.CdEntpChsEntreprise).HasMaxLength(60);
            modelBuilder.Entity<ChsPave>().Property(item => item.CdEntpChsEntreprise).HasColumnName("CD_ENTP_CHS__ENTREPRISE");
            modelBuilder.Entity<ChsPave>().Property(item => item.CdCauseChsCause).HasMaxLength(60);
            modelBuilder.Entity<ChsPave>().Property(item => item.CdCauseChsCause).HasColumnName("CD_CAUSE_CHS__CAUSE");
            modelBuilder.Entity<ChsPave>().Property(item => item.CdMoChsMo).HasMaxLength(25);
            modelBuilder.Entity<ChsPave>().Property(item => item.CdMoChsMo).HasColumnName("CD_MO_CHS__MO");
            modelBuilder.Entity<ChsPave>().Property(item => item.CdFamTechChsCode).IsRequired();
            modelBuilder.Entity<ChsPave>().Property(item => item.CdFamTechChsCode).HasMaxLength(15);
            modelBuilder.Entity<ChsPave>().Property(item => item.CdFamTechChsCode).HasColumnName("CD_FAM_TECH_CHS__CODE");
            modelBuilder.Entity<ChsPave>().Property(item => item.CdTechChsTechnique).IsRequired();
            modelBuilder.Entity<ChsPave>().Property(item => item.CdTechChsTechnique).HasMaxLength(12);
            modelBuilder.Entity<ChsPave>().Property(item => item.CdTechChsTechnique).HasColumnName("CD_TECH_CHS__TECHNIQUE");
            modelBuilder.Entity<ChsPave>().Property(item => item.CdTravauxChsCode).IsRequired();
            modelBuilder.Entity<ChsPave>().Property(item => item.CdTravauxChsCode).HasMaxLength(60);
            modelBuilder.Entity<ChsPave>().Property(item => item.CdTravauxChsCode).HasColumnName("CD_TRAVAUX_CHS__CODE");
            modelBuilder.Entity<ChsPave>().Property(item => item.Largeur).HasColumnName("LARGEUR");
            modelBuilder.Entity<ChsPave>().Property(item => item.Epais).IsRequired();
            modelBuilder.Entity<ChsPave>().Property(item => item.Epais).HasColumnName("EPAIS");
            modelBuilder.Entity<ChsPave>().Property(item => item.Granulo).HasMaxLength(6);
            modelBuilder.Entity<ChsPave>().Property(item => item.Granulo).HasColumnName("GRANULO");
            modelBuilder.Entity<ChsPave>().Property(item => item.DureeVie).HasColumnName("DUREE_VIE");
            modelBuilder.Entity<ChsPave>().Property(item => item.Archive).HasMaxLength(255);
            modelBuilder.Entity<ChsPave>().Property(item => item.Archive).HasColumnName("ARCHIVE");
            modelBuilder.Entity<ChsPave>().Property(item => item.Marche).HasMaxLength(25);
            modelBuilder.Entity<ChsPave>().Property(item => item.Marche).HasColumnName("MARCHE");
            modelBuilder.Entity<ChsPave>().Property(item => item.Commentaire).HasMaxLength(255);
            modelBuilder.Entity<ChsPave>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<ChsPave>().Property(item => item.Montant).HasColumnName("MONTANT");
            modelBuilder.Entity<ChsCdCause>().ToTable("CD_CAUSE_CHS","CHS");
            modelBuilder.Entity<ChsCdCause>().HasKey(item => new {item.Cause });
            modelBuilder.Entity<ChsCdCause>().Property(item => item.Cause).IsRequired();
            modelBuilder.Entity<ChsCdCause>().Property(item => item.Cause).HasMaxLength(60);
            modelBuilder.Entity<ChsCdCause>().Property(item => item.Cause).HasColumnName("CAUSE");
            modelBuilder.Entity<ChsCls>().ToTable("CLS_CHS","CHS");
            modelBuilder.Entity<ChsCls>().HasKey(item => new {item.Id });
            modelBuilder.Entity<ChsCls>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<ChsCls>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<ChsCls>().Property(item => item.TableName).HasMaxLength(30);
            modelBuilder.Entity<ChsCls>().Property(item => item.TableName).HasColumnName("TABLE_NAME");
            modelBuilder.Entity<ChsCls>().Property(item => item.KeyValue).HasMaxLength(100);
            modelBuilder.Entity<ChsCls>().Property(item => item.KeyValue).HasColumnName("KEY_VALUE");
            modelBuilder.Entity<ChsCdDoc>().ToTable("CD_DOC_CHS","CHS");
            modelBuilder.Entity<ChsCdDoc>().HasKey(item => new {item.Code });
            modelBuilder.Entity<ChsCdDoc>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<ChsCdDoc>().Property(item => item.Code).HasMaxLength(15);
            modelBuilder.Entity<ChsCdDoc>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<ChsCdDoc>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<ChsCdDoc>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<ChsCdDoc>().Property(item => item.Path).HasMaxLength(255);
            modelBuilder.Entity<ChsCdDoc>().Property(item => item.Path).HasColumnName("PATH");
            modelBuilder.Entity<ChsDoc>().ToTable("DOC_CHS","CHS");
            modelBuilder.Entity<ChsDoc>().HasKey(item => new {item.Id });
            modelBuilder.Entity<ChsDoc>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<ChsDoc>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<ChsDoc>().Property(item => item.CdDocChsCode).IsRequired();
            modelBuilder.Entity<ChsDoc>().Property(item => item.CdDocChsCode).HasMaxLength(15);
            modelBuilder.Entity<ChsDoc>().Property(item => item.CdDocChsCode).HasColumnName("CD_DOC_CHS__CODE");
            modelBuilder.Entity<ChsDoc>().Property(item => item.Libelle).HasMaxLength(100);
            modelBuilder.Entity<ChsDoc>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<ChsDoc>().Property(item => item.Ref).HasMaxLength(50);
            modelBuilder.Entity<ChsDoc>().Property(item => item.Ref).HasColumnName("REF");
            modelBuilder.Entity<ChsMatPave>().ToTable("MAT_PAVE_CHS","CHS");
            modelBuilder.Entity<ChsMatPave>().HasKey(item => new {item.CdCouChsCouche,item.PaveChsDateMs,item.PaveChsLiaison,item.PaveChsSens,item.PaveChsAbsDeb,item.PaveChsAbsFin,item.Num });
            modelBuilder.Entity<ChsMatPave>().Property(item => item.CdCouChsCouche).IsRequired();
            modelBuilder.Entity<ChsMatPave>().Property(item => item.CdCouChsCouche).HasMaxLength(14);
            modelBuilder.Entity<ChsMatPave>().Property(item => item.CdCouChsCouche).HasColumnName("CD_COU_CHS__COUCHE");
            modelBuilder.Entity<ChsMatPave>().Property(item => item.PaveChsDateMs).IsRequired();
            modelBuilder.Entity<ChsMatPave>().Property(item => item.PaveChsDateMs).HasColumnName("PAVE_CHS__DATE_MS");
            modelBuilder.Entity<ChsMatPave>().Property(item => item.PaveChsLiaison).IsRequired();
            modelBuilder.Entity<ChsMatPave>().Property(item => item.PaveChsLiaison).HasMaxLength(15);
            modelBuilder.Entity<ChsMatPave>().Property(item => item.PaveChsLiaison).HasColumnName("PAVE_CHS__LIAISON");
            modelBuilder.Entity<ChsMatPave>().Property(item => item.PaveChsSens).IsRequired();
            modelBuilder.Entity<ChsMatPave>().Property(item => item.PaveChsSens).HasMaxLength(6);
            modelBuilder.Entity<ChsMatPave>().Property(item => item.PaveChsSens).HasColumnName("PAVE_CHS__SENS");
            modelBuilder.Entity<ChsMatPave>().Property(item => item.PaveChsAbsDeb).IsRequired();
            modelBuilder.Entity<ChsMatPave>().Property(item => item.PaveChsAbsDeb).HasColumnName("PAVE_CHS__ABS_DEB");
            modelBuilder.Entity<ChsMatPave>().Property(item => item.PaveChsAbsFin).IsRequired();
            modelBuilder.Entity<ChsMatPave>().Property(item => item.PaveChsAbsFin).HasColumnName("PAVE_CHS__ABS_FIN");
            modelBuilder.Entity<ChsMatPave>().Property(item => item.Num).IsRequired();
            modelBuilder.Entity<ChsMatPave>().Property(item => item.Num).HasColumnName("NUM");
            modelBuilder.Entity<ChsMatPave>().Property(item => item.CdMatChsCode).IsRequired();
            modelBuilder.Entity<ChsMatPave>().Property(item => item.CdMatChsCode).HasMaxLength(12);
            modelBuilder.Entity<ChsMatPave>().Property(item => item.CdMatChsCode).HasColumnName("CD_MAT_CHS__CODE");
            modelBuilder.Entity<ChsMatPave>().Property(item => item.CdOrigChsCode).IsRequired();
            modelBuilder.Entity<ChsMatPave>().Property(item => item.CdOrigChsCode).HasMaxLength(20);
            modelBuilder.Entity<ChsMatPave>().Property(item => item.CdOrigChsCode).HasColumnName("CD_ORIG_CHS__CODE");
            modelBuilder.Entity<ChsMatPave>().Property(item => item.FabCarChsNom).IsRequired();
            modelBuilder.Entity<ChsMatPave>().Property(item => item.FabCarChsNom).HasMaxLength(60);
            modelBuilder.Entity<ChsMatPave>().Property(item => item.FabCarChsNom).HasColumnName("FAB_CAR_CHS__NOM");
            modelBuilder.Entity<ChsMatPave>().Property(item => item.MatChsMat).IsRequired();
            modelBuilder.Entity<ChsMatPave>().Property(item => item.MatChsMat).HasMaxLength(60);
            modelBuilder.Entity<ChsMatPave>().Property(item => item.MatChsMat).HasColumnName("MAT_CHS__MAT");
            modelBuilder.Entity<ChsMatPave>().Property(item => item.Classe).HasMaxLength(8);
            modelBuilder.Entity<ChsMatPave>().Property(item => item.Classe).HasColumnName("CLASSE");
            modelBuilder.Entity<ChsMatPave>().Property(item => item.Dosage).HasMaxLength(50);
            modelBuilder.Entity<ChsMatPave>().Property(item => item.Dosage).HasColumnName("DOSAGE");
            modelBuilder.Entity<ChsMatPave>().Property(item => item.Observ).HasMaxLength(255);
            modelBuilder.Entity<ChsMatPave>().Property(item => item.Observ).HasColumnName("OBSERV");
            modelBuilder.Entity<ChsFabCar>().ToTable("FAB_CAR_CHS","CHS");
            modelBuilder.Entity<ChsFabCar>().HasKey(item => new {item.CdMatChsCode,item.CdOrigChsCode,item.Nom });
            modelBuilder.Entity<ChsFabCar>().Property(item => item.CdMatChsCode).IsRequired();
            modelBuilder.Entity<ChsFabCar>().Property(item => item.CdMatChsCode).HasMaxLength(12);
            modelBuilder.Entity<ChsFabCar>().Property(item => item.CdMatChsCode).HasColumnName("CD_MAT_CHS__CODE");
            modelBuilder.Entity<ChsFabCar>().Property(item => item.CdOrigChsCode).IsRequired();
            modelBuilder.Entity<ChsFabCar>().Property(item => item.CdOrigChsCode).HasMaxLength(20);
            modelBuilder.Entity<ChsFabCar>().Property(item => item.CdOrigChsCode).HasColumnName("CD_ORIG_CHS__CODE");
            modelBuilder.Entity<ChsFabCar>().Property(item => item.Nom).IsRequired();
            modelBuilder.Entity<ChsFabCar>().Property(item => item.Nom).HasMaxLength(60);
            modelBuilder.Entity<ChsFabCar>().Property(item => item.Nom).HasColumnName("NOM");
            modelBuilder.Entity<ChsMat>().ToTable("MAT_CHS","CHS");
            modelBuilder.Entity<ChsMat>().HasKey(item => new {item.Mat });
            modelBuilder.Entity<ChsMat>().Property(item => item.Mat).IsRequired();
            modelBuilder.Entity<ChsMat>().Property(item => item.Mat).HasMaxLength(60);
            modelBuilder.Entity<ChsMat>().Property(item => item.Mat).HasColumnName("MAT");
            modelBuilder.Entity<ChsMat>().Property(item => item.CdMatChsCode).IsRequired();
            modelBuilder.Entity<ChsMat>().Property(item => item.CdMatChsCode).HasMaxLength(12);
            modelBuilder.Entity<ChsMat>().Property(item => item.CdMatChsCode).HasColumnName("CD_MAT_CHS__CODE");
            modelBuilder.Entity<ChsParamsis>().ToTable("PARAMSIS","CHS");
            modelBuilder.Entity<ChsParamsis>().HasKey(item => new {item.Entree,item.Parametre,item.Type });
            modelBuilder.Entity<ChsParamsis>().Property(item => item.Entree).IsRequired();
            modelBuilder.Entity<ChsParamsis>().Property(item => item.Entree).HasMaxLength(50);
            modelBuilder.Entity<ChsParamsis>().Property(item => item.Entree).HasColumnName("ENTREE");
            modelBuilder.Entity<ChsParamsis>().Property(item => item.Parametre).IsRequired();
            modelBuilder.Entity<ChsParamsis>().Property(item => item.Parametre).HasMaxLength(50);
            modelBuilder.Entity<ChsParamsis>().Property(item => item.Parametre).HasColumnName("PARAMETRE");
            modelBuilder.Entity<ChsParamsis>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<ChsParamsis>().Property(item => item.Type).HasMaxLength(50);
            modelBuilder.Entity<ChsParamsis>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<ChsParamsis>().Property(item => item.Valeur).HasMaxLength(50);
            modelBuilder.Entity<ChsParamsis>().Property(item => item.Valeur).HasColumnName("VALEUR");
            modelBuilder.Entity<ChsCdMesure>().ToTable("CD_MESURE_CHS","CHS");
            modelBuilder.Entity<ChsCdMesure>().HasKey(item => new {item.Agr });
            modelBuilder.Entity<ChsCdMesure>().Property(item => item.Agr).IsRequired();
            modelBuilder.Entity<ChsCdMesure>().Property(item => item.Agr).HasMaxLength(12);
            modelBuilder.Entity<ChsCdMesure>().Property(item => item.Agr).HasColumnName("AGR");
            modelBuilder.Entity<ChsCdMesure>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<ChsCdMesure>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<ChsCdMesure>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<ChsCdMesure>().Property(item => item.Cycle).IsRequired();
            modelBuilder.Entity<ChsCdMesure>().Property(item => item.Cycle).HasColumnName("CYCLE");
            modelBuilder.Entity<ChsCdMesure>().Property(item => item.Prix).HasColumnName("PRIX");
            modelBuilder.Entity<ChsCdIndic>().ToTable("CD_INDIC_CHS","CHS");
            modelBuilder.Entity<ChsCdIndic>().HasKey(item => new {item.CdMesureChsAgr,item.Indic });
            modelBuilder.Entity<ChsCdIndic>().Property(item => item.CdMesureChsAgr).IsRequired();
            modelBuilder.Entity<ChsCdIndic>().Property(item => item.CdMesureChsAgr).HasMaxLength(12);
            modelBuilder.Entity<ChsCdIndic>().Property(item => item.CdMesureChsAgr).HasColumnName("CD_MESURE_CHS__AGR");
            modelBuilder.Entity<ChsCdIndic>().Property(item => item.Indic).IsRequired();
            modelBuilder.Entity<ChsCdIndic>().Property(item => item.Indic).HasMaxLength(12);
            modelBuilder.Entity<ChsCdIndic>().Property(item => item.Indic).HasColumnName("INDIC");
            modelBuilder.Entity<ChsCdIndic>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<ChsCdIndic>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<ChsCdIndic>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<ChsCdIndic>().Property(item => item.Unite).HasMaxLength(8);
            modelBuilder.Entity<ChsCdIndic>().Property(item => item.Unite).HasColumnName("UNITE");
            modelBuilder.Entity<ChsCdIndic>().Property(item => item.Vmin).HasColumnName("VMIN");
            modelBuilder.Entity<ChsCdIndic>().Property(item => item.Vmax).HasColumnName("VMAX");
            modelBuilder.Entity<ChsCdIndic>().Property(item => item.Invalide).HasColumnName("INVALIDE");
            modelBuilder.Entity<ChsCdIndic>().Property(item => item.Formats).HasMaxLength(12);
            modelBuilder.Entity<ChsCdIndic>().Property(item => item.Formats).HasColumnName("FORMATS");
            modelBuilder.Entity<ChsCdSeuil>().ToTable("CD_SEUIL_CHS","CHS");
            modelBuilder.Entity<ChsCdSeuil>().HasKey(item => new {item.CdMesureChsAgr,item.CdIndicChsIndic });
            modelBuilder.Entity<ChsCdSeuil>().Property(item => item.CdMesureChsAgr).IsRequired();
            modelBuilder.Entity<ChsCdSeuil>().Property(item => item.CdMesureChsAgr).HasMaxLength(12);
            modelBuilder.Entity<ChsCdSeuil>().Property(item => item.CdMesureChsAgr).HasColumnName("CD_MESURE_CHS__AGR");
            modelBuilder.Entity<ChsCdSeuil>().Property(item => item.CdIndicChsIndic).IsRequired();
            modelBuilder.Entity<ChsCdSeuil>().Property(item => item.CdIndicChsIndic).HasMaxLength(12);
            modelBuilder.Entity<ChsCdSeuil>().Property(item => item.CdIndicChsIndic).HasColumnName("CD_INDIC_CHS__INDIC");
            modelBuilder.Entity<ChsCdSeuil>().Property(item => item.Seuil1).IsRequired();
            modelBuilder.Entity<ChsCdSeuil>().Property(item => item.Seuil1).HasColumnName("SEUIL1");
            modelBuilder.Entity<ChsCdSeuil>().Property(item => item.Seuil2).HasColumnName("SEUIL2");
            modelBuilder.Entity<ChsCdSeuil>().Property(item => item.Seuil3).HasColumnName("SEUIL3");
            modelBuilder.Entity<ChsCdSeuil>().Property(item => item.Seuil4).HasColumnName("SEUIL4");
            modelBuilder.Entity<ChsCdSeuil>().Property(item => item.Interp).IsRequired();
            modelBuilder.Entity<ChsCdSeuil>().Property(item => item.Interp).HasMaxLength(1);
            modelBuilder.Entity<ChsCdSeuil>().Property(item => item.Interp).HasColumnName("INTERP");
            modelBuilder.Entity<ChsCdSeuil>().Property(item => item.Valabs).IsRequired();
            modelBuilder.Entity<ChsCdSeuil>().Property(item => item.Valabs).HasColumnName("VALABS");
            modelBuilder.Entity<ChsCdSeuil>().Property(item => item.Zone).HasColumnName("ZONE");
            modelBuilder.Entity<ChsCdSeuil>().Property(item => item.UAlpha).HasColumnName("U_ALPHA");
            modelBuilder.Entity<ChsCdSeuil>().Property(item => item.CaractEcart).HasColumnName("CARACT_ECART");
            modelBuilder.Entity<ChsCamp>().ToTable("CAMP_CHS","CHS");
            modelBuilder.Entity<ChsCamp>().HasKey(item => new {item.CdMesureChsAgr,item.Section,item.Annee,item.Liaison,item.Sens,item.Voie });
            modelBuilder.Entity<ChsCamp>().Property(item => item.CdMesureChsAgr).IsRequired();
            modelBuilder.Entity<ChsCamp>().Property(item => item.CdMesureChsAgr).HasMaxLength(12);
            modelBuilder.Entity<ChsCamp>().Property(item => item.CdMesureChsAgr).HasColumnName("CD_MESURE_CHS__AGR");
            modelBuilder.Entity<ChsCamp>().Property(item => item.Section).IsRequired();
            modelBuilder.Entity<ChsCamp>().Property(item => item.Section).HasMaxLength(15);
            modelBuilder.Entity<ChsCamp>().Property(item => item.Section).HasColumnName("SECTION");
            modelBuilder.Entity<ChsCamp>().Property(item => item.Annee).IsRequired();
            modelBuilder.Entity<ChsCamp>().Property(item => item.Annee).HasColumnName("ANNEE");
            modelBuilder.Entity<ChsCamp>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<ChsCamp>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<ChsCamp>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<ChsCamp>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<ChsCamp>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<ChsCamp>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<ChsCamp>().Property(item => item.Voie).IsRequired();
            modelBuilder.Entity<ChsCamp>().Property(item => item.Voie).HasMaxLength(6);
            modelBuilder.Entity<ChsCamp>().Property(item => item.Voie).HasColumnName("VOIE");
            modelBuilder.Entity<ChsCamp>().Property(item => item.Dateg).HasColumnName("DATEG");
            modelBuilder.Entity<ChsCamp>().Property(item => item.Datec).IsRequired();
            modelBuilder.Entity<ChsCamp>().Property(item => item.Datec).HasColumnName("DATEC");
            modelBuilder.Entity<ChsCamp>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<ChsCamp>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<ChsCamp>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<ChsCamp>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<ChsCamp>().Property(item => item.DateLoad).HasColumnName("DATE_LOAD");
            modelBuilder.Entity<ChsCamp>().Property(item => item.DateMes).HasColumnName("DATE_MES");
            modelBuilder.Entity<ChsCamp>().Property(item => item.Pas).HasColumnName("PAS");
            modelBuilder.Entity<ChsCamp>().Property(item => item.Observ).HasMaxLength(255);
            modelBuilder.Entity<ChsCamp>().Property(item => item.Observ).HasColumnName("OBSERV");
            modelBuilder.Entity<ChsClCamp>().ToTable("CL_CAMP_CHS","CHS");
            modelBuilder.Entity<ChsClCamp>().HasKey(item => new {item.CdCdMesureChsAgr,item.CdMesureChsAgr,item.CdIndicChsIndic,item.CampChsSection,item.CampChsAnnee,item.CampChsLiaison,item.CampChsSens,item.CampChsVoie,item.AnneeCalc,item.AbsDeb,item.AbsFin,item.Voie });
            modelBuilder.Entity<ChsClCamp>().Property(item => item.CdCdMesureChsAgr).IsRequired();
            modelBuilder.Entity<ChsClCamp>().Property(item => item.CdCdMesureChsAgr).HasMaxLength(12);
            modelBuilder.Entity<ChsClCamp>().Property(item => item.CdCdMesureChsAgr).HasColumnName("CD__CD_MESURE_CHS__AGR");
            modelBuilder.Entity<ChsClCamp>().Property(item => item.CdMesureChsAgr).IsRequired();
            modelBuilder.Entity<ChsClCamp>().Property(item => item.CdMesureChsAgr).HasMaxLength(12);
            modelBuilder.Entity<ChsClCamp>().Property(item => item.CdMesureChsAgr).HasColumnName("CD_MESURE_CHS__AGR");
            modelBuilder.Entity<ChsClCamp>().Property(item => item.CdIndicChsIndic).IsRequired();
            modelBuilder.Entity<ChsClCamp>().Property(item => item.CdIndicChsIndic).HasMaxLength(12);
            modelBuilder.Entity<ChsClCamp>().Property(item => item.CdIndicChsIndic).HasColumnName("CD_INDIC_CHS__INDIC");
            modelBuilder.Entity<ChsClCamp>().Property(item => item.CampChsSection).IsRequired();
            modelBuilder.Entity<ChsClCamp>().Property(item => item.CampChsSection).HasMaxLength(15);
            modelBuilder.Entity<ChsClCamp>().Property(item => item.CampChsSection).HasColumnName("CAMP_CHS__SECTION");
            modelBuilder.Entity<ChsClCamp>().Property(item => item.CampChsAnnee).IsRequired();
            modelBuilder.Entity<ChsClCamp>().Property(item => item.CampChsAnnee).HasColumnName("CAMP_CHS__ANNEE");
            modelBuilder.Entity<ChsClCamp>().Property(item => item.CampChsLiaison).IsRequired();
            modelBuilder.Entity<ChsClCamp>().Property(item => item.CampChsLiaison).HasMaxLength(15);
            modelBuilder.Entity<ChsClCamp>().Property(item => item.CampChsLiaison).HasColumnName("CAMP_CHS__LIAISON");
            modelBuilder.Entity<ChsClCamp>().Property(item => item.CampChsSens).IsRequired();
            modelBuilder.Entity<ChsClCamp>().Property(item => item.CampChsSens).HasMaxLength(6);
            modelBuilder.Entity<ChsClCamp>().Property(item => item.CampChsSens).HasColumnName("CAMP_CHS__SENS");
            modelBuilder.Entity<ChsClCamp>().Property(item => item.CampChsVoie).IsRequired();
            modelBuilder.Entity<ChsClCamp>().Property(item => item.CampChsVoie).HasMaxLength(6);
            modelBuilder.Entity<ChsClCamp>().Property(item => item.CampChsVoie).HasColumnName("CAMP_CHS__VOIE");
            modelBuilder.Entity<ChsClCamp>().Property(item => item.AnneeCalc).IsRequired();
            modelBuilder.Entity<ChsClCamp>().Property(item => item.AnneeCalc).HasColumnName("ANNEE_CALC");
            modelBuilder.Entity<ChsClCamp>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<ChsClCamp>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<ChsClCamp>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<ChsClCamp>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<ChsClCamp>().Property(item => item.Voie).IsRequired();
            modelBuilder.Entity<ChsClCamp>().Property(item => item.Voie).HasMaxLength(6);
            modelBuilder.Entity<ChsClCamp>().Property(item => item.Voie).HasColumnName("VOIE");
            modelBuilder.Entity<ChsMesure>().ToTable("MESURE_CHS","CHS");
            modelBuilder.Entity<ChsMesure>().HasKey(item => new {item.CdCdMesureChsAgr,item.CdMesureChsAgr,item.CdIndicChsIndic,item.CampChsSection,item.CampChsAnnee,item.CampChsLiaison,item.CampChsSens,item.CampChsVoie,item.Voie,item.AbsDeb });
            modelBuilder.Entity<ChsMesure>().Property(item => item.CdCdMesureChsAgr).IsRequired();
            modelBuilder.Entity<ChsMesure>().Property(item => item.CdCdMesureChsAgr).HasMaxLength(12);
            modelBuilder.Entity<ChsMesure>().Property(item => item.CdCdMesureChsAgr).HasColumnName("CD__CD_MESURE_CHS__AGR");
            modelBuilder.Entity<ChsMesure>().Property(item => item.CdMesureChsAgr).IsRequired();
            modelBuilder.Entity<ChsMesure>().Property(item => item.CdMesureChsAgr).HasMaxLength(12);
            modelBuilder.Entity<ChsMesure>().Property(item => item.CdMesureChsAgr).HasColumnName("CD_MESURE_CHS__AGR");
            modelBuilder.Entity<ChsMesure>().Property(item => item.CdIndicChsIndic).IsRequired();
            modelBuilder.Entity<ChsMesure>().Property(item => item.CdIndicChsIndic).HasMaxLength(12);
            modelBuilder.Entity<ChsMesure>().Property(item => item.CdIndicChsIndic).HasColumnName("CD_INDIC_CHS__INDIC");
            modelBuilder.Entity<ChsMesure>().Property(item => item.CampChsSection).IsRequired();
            modelBuilder.Entity<ChsMesure>().Property(item => item.CampChsSection).HasMaxLength(15);
            modelBuilder.Entity<ChsMesure>().Property(item => item.CampChsSection).HasColumnName("CAMP_CHS__SECTION");
            modelBuilder.Entity<ChsMesure>().Property(item => item.CampChsAnnee).IsRequired();
            modelBuilder.Entity<ChsMesure>().Property(item => item.CampChsAnnee).HasColumnName("CAMP_CHS__ANNEE");
            modelBuilder.Entity<ChsMesure>().Property(item => item.CampChsLiaison).IsRequired();
            modelBuilder.Entity<ChsMesure>().Property(item => item.CampChsLiaison).HasMaxLength(15);
            modelBuilder.Entity<ChsMesure>().Property(item => item.CampChsLiaison).HasColumnName("CAMP_CHS__LIAISON");
            modelBuilder.Entity<ChsMesure>().Property(item => item.CampChsSens).IsRequired();
            modelBuilder.Entity<ChsMesure>().Property(item => item.CampChsSens).HasMaxLength(6);
            modelBuilder.Entity<ChsMesure>().Property(item => item.CampChsSens).HasColumnName("CAMP_CHS__SENS");
            modelBuilder.Entity<ChsMesure>().Property(item => item.CampChsVoie).IsRequired();
            modelBuilder.Entity<ChsMesure>().Property(item => item.CampChsVoie).HasMaxLength(6);
            modelBuilder.Entity<ChsMesure>().Property(item => item.CampChsVoie).HasColumnName("CAMP_CHS__VOIE");
            modelBuilder.Entity<ChsMesure>().Property(item => item.Voie).IsRequired();
            modelBuilder.Entity<ChsMesure>().Property(item => item.Voie).HasMaxLength(6);
            modelBuilder.Entity<ChsMesure>().Property(item => item.Voie).HasColumnName("VOIE");
            modelBuilder.Entity<ChsMesure>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<ChsMesure>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<ChsMesure>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<ChsMesure>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<ChsMesure>().Property(item => item.Valeur).HasColumnName("VALEUR");
            modelBuilder.Entity<ChsAgrege>().ToTable("AGREGE_CHS","CHS");
            modelBuilder.Entity<ChsAgrege>().HasKey(item => new {item.CdCdMesureChsAgr,item.CdMesureChsAgr,item.CdIndicChsIndic,item.CampChsSection,item.CampChsAnnee,item.CampChsLiaison,item.CampChsSens,item.CampChsVoie,item.Voie,item.AbsDeb,item.AbsFin });
            modelBuilder.Entity<ChsAgrege>().Property(item => item.CdCdMesureChsAgr).IsRequired();
            modelBuilder.Entity<ChsAgrege>().Property(item => item.CdCdMesureChsAgr).HasMaxLength(12);
            modelBuilder.Entity<ChsAgrege>().Property(item => item.CdCdMesureChsAgr).HasColumnName("CD__CD_MESURE_CHS__AGR");
            modelBuilder.Entity<ChsAgrege>().Property(item => item.CdMesureChsAgr).IsRequired();
            modelBuilder.Entity<ChsAgrege>().Property(item => item.CdMesureChsAgr).HasMaxLength(12);
            modelBuilder.Entity<ChsAgrege>().Property(item => item.CdMesureChsAgr).HasColumnName("CD_MESURE_CHS__AGR");
            modelBuilder.Entity<ChsAgrege>().Property(item => item.CdIndicChsIndic).IsRequired();
            modelBuilder.Entity<ChsAgrege>().Property(item => item.CdIndicChsIndic).HasMaxLength(12);
            modelBuilder.Entity<ChsAgrege>().Property(item => item.CdIndicChsIndic).HasColumnName("CD_INDIC_CHS__INDIC");
            modelBuilder.Entity<ChsAgrege>().Property(item => item.CampChsSection).IsRequired();
            modelBuilder.Entity<ChsAgrege>().Property(item => item.CampChsSection).HasMaxLength(15);
            modelBuilder.Entity<ChsAgrege>().Property(item => item.CampChsSection).HasColumnName("CAMP_CHS__SECTION");
            modelBuilder.Entity<ChsAgrege>().Property(item => item.CampChsAnnee).IsRequired();
            modelBuilder.Entity<ChsAgrege>().Property(item => item.CampChsAnnee).HasColumnName("CAMP_CHS__ANNEE");
            modelBuilder.Entity<ChsAgrege>().Property(item => item.CampChsLiaison).IsRequired();
            modelBuilder.Entity<ChsAgrege>().Property(item => item.CampChsLiaison).HasMaxLength(15);
            modelBuilder.Entity<ChsAgrege>().Property(item => item.CampChsLiaison).HasColumnName("CAMP_CHS__LIAISON");
            modelBuilder.Entity<ChsAgrege>().Property(item => item.CampChsSens).IsRequired();
            modelBuilder.Entity<ChsAgrege>().Property(item => item.CampChsSens).HasMaxLength(6);
            modelBuilder.Entity<ChsAgrege>().Property(item => item.CampChsSens).HasColumnName("CAMP_CHS__SENS");
            modelBuilder.Entity<ChsAgrege>().Property(item => item.CampChsVoie).IsRequired();
            modelBuilder.Entity<ChsAgrege>().Property(item => item.CampChsVoie).HasMaxLength(6);
            modelBuilder.Entity<ChsAgrege>().Property(item => item.CampChsVoie).HasColumnName("CAMP_CHS__VOIE");
            modelBuilder.Entity<ChsAgrege>().Property(item => item.Voie).IsRequired();
            modelBuilder.Entity<ChsAgrege>().Property(item => item.Voie).HasMaxLength(6);
            modelBuilder.Entity<ChsAgrege>().Property(item => item.Voie).HasColumnName("VOIE");
            modelBuilder.Entity<ChsAgrege>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<ChsAgrege>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<ChsAgrege>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<ChsAgrege>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<ChsAgrege>().Property(item => item.CdAgregeChsValeur).IsRequired();
            modelBuilder.Entity<ChsAgrege>().Property(item => item.CdAgregeChsValeur).HasColumnName("CD_AGREGE_CHS__VALEUR");
            modelBuilder.Entity<ChsAgrege>().Property(item => item.Moyenne).HasColumnName("MOYENNE");
            modelBuilder.Entity<ChsCdFamCar>().ToTable("CD_FAM_CAR_CHS","CHS");
            modelBuilder.Entity<ChsCdFamCar>().HasKey(item => new {item.Famille });
            modelBuilder.Entity<ChsCdFamCar>().Property(item => item.Famille).IsRequired();
            modelBuilder.Entity<ChsCdFamCar>().Property(item => item.Famille).HasMaxLength(12);
            modelBuilder.Entity<ChsCdFamCar>().Property(item => item.Famille).HasColumnName("FAMILLE");
            modelBuilder.Entity<ChsCdFamCar>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<ChsCdFamCar>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<ChsCdFamCar>().Property(item => item.Cam).IsRequired();
            modelBuilder.Entity<ChsCdFamCar>().Property(item => item.Cam).HasColumnName("CAM");
            modelBuilder.Entity<ChsSysUser>().ToTable("SYS_USER_CHS","CHS");
            modelBuilder.Entity<ChsSysUser>().HasKey(item => new {item.CodeDbs,item.CodeTable,item.CodeColonne,item.NomUser,item.CodePrp });
            modelBuilder.Entity<ChsSysUser>().Property(item => item.CodeDbs).IsRequired();
            modelBuilder.Entity<ChsSysUser>().Property(item => item.CodeDbs).HasMaxLength(50);
            modelBuilder.Entity<ChsSysUser>().Property(item => item.CodeDbs).HasColumnName("CODE_DBS");
            modelBuilder.Entity<ChsSysUser>().Property(item => item.CodeTable).IsRequired();
            modelBuilder.Entity<ChsSysUser>().Property(item => item.CodeTable).HasMaxLength(100);
            modelBuilder.Entity<ChsSysUser>().Property(item => item.CodeTable).HasColumnName("CODE_TABLE");
            modelBuilder.Entity<ChsSysUser>().Property(item => item.CodeColonne).IsRequired();
            modelBuilder.Entity<ChsSysUser>().Property(item => item.CodeColonne).HasMaxLength(100);
            modelBuilder.Entity<ChsSysUser>().Property(item => item.CodeColonne).HasColumnName("CODE_COLONNE");
            modelBuilder.Entity<ChsSysUser>().Property(item => item.NomUser).IsRequired();
            modelBuilder.Entity<ChsSysUser>().Property(item => item.NomUser).HasMaxLength(150);
            modelBuilder.Entity<ChsSysUser>().Property(item => item.NomUser).HasColumnName("NOM_USER");
            modelBuilder.Entity<ChsSysUser>().Property(item => item.CodePrp).IsRequired();
            modelBuilder.Entity<ChsSysUser>().Property(item => item.CodePrp).HasMaxLength(255);
            modelBuilder.Entity<ChsSysUser>().Property(item => item.CodePrp).HasColumnName("CODE_PRP");
            modelBuilder.Entity<ChsSysUser>().Property(item => item.ValPrp).IsRequired();
            modelBuilder.Entity<ChsSysUser>().Property(item => item.ValPrp).HasMaxLength(500);
            modelBuilder.Entity<ChsSysUser>().Property(item => item.ValPrp).HasColumnName("VAL_PRP");
            modelBuilder.Entity<ChsCdFamTech>().ToTable("CD_FAM_TECH_CHS","CHS");
            modelBuilder.Entity<ChsCdFamTech>().HasKey(item => new {item.Code });
            modelBuilder.Entity<ChsCdFamTech>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<ChsCdFamTech>().Property(item => item.Code).HasMaxLength(15);
            modelBuilder.Entity<ChsCdFamTech>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<ChsCdOrig>().ToTable("CD_ORIG_CHS","CHS");
            modelBuilder.Entity<ChsCdOrig>().HasKey(item => new {item.CdMatChsCode,item.Code });
            modelBuilder.Entity<ChsCdOrig>().Property(item => item.CdMatChsCode).IsRequired();
            modelBuilder.Entity<ChsCdOrig>().Property(item => item.CdMatChsCode).HasMaxLength(12);
            modelBuilder.Entity<ChsCdOrig>().Property(item => item.CdMatChsCode).HasColumnName("CD_MAT_CHS__CODE");
            modelBuilder.Entity<ChsCdOrig>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<ChsCdOrig>().Property(item => item.Code).HasMaxLength(20);
            modelBuilder.Entity<ChsCdOrig>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<ChsCdMat>().ToTable("CD_MAT_CHS","CHS");
            modelBuilder.Entity<ChsCdMat>().HasKey(item => new {item.Code });
            modelBuilder.Entity<ChsCdMat>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<ChsCdMat>().Property(item => item.Code).HasMaxLength(12);
            modelBuilder.Entity<ChsCdMat>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<ChsCdAgrege>().ToTable("CD_AGREGE_CHS","CHS");
            modelBuilder.Entity<ChsCdAgrege>().HasKey(item => new {item.Valeur });
            modelBuilder.Entity<ChsCdAgrege>().Property(item => item.Valeur).IsRequired();
            modelBuilder.Entity<ChsCdAgrege>().Property(item => item.Valeur).HasColumnName("VALEUR");
            modelBuilder.Entity<ChsCdAgrege>().Property(item => item.Libelle).HasMaxLength(50);
            modelBuilder.Entity<ChsCdAgrege>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<ChsCdAgrege>().Property(item => item.Couleur).HasMaxLength(15);
            modelBuilder.Entity<ChsCdAgrege>().Property(item => item.Couleur).HasColumnName("COULEUR");
            modelBuilder.Entity<ChsPrevision>().ToTable("PREVISION_CHS","CHS");
            modelBuilder.Entity<ChsPrevision>().HasKey(item => new {item.BpuChsCode,item.Annee,item.Liaison,item.Sens,item.Voie,item.AbsDeb });
            modelBuilder.Entity<ChsPrevision>().Property(item => item.BpuChsCode).IsRequired();
            modelBuilder.Entity<ChsPrevision>().Property(item => item.BpuChsCode).HasMaxLength(25);
            modelBuilder.Entity<ChsPrevision>().Property(item => item.BpuChsCode).HasColumnName("BPU_CHS__CODE");
            modelBuilder.Entity<ChsPrevision>().Property(item => item.Annee).IsRequired();
            modelBuilder.Entity<ChsPrevision>().Property(item => item.Annee).HasColumnName("ANNEE");
            modelBuilder.Entity<ChsPrevision>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<ChsPrevision>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<ChsPrevision>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<ChsPrevision>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<ChsPrevision>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<ChsPrevision>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<ChsPrevision>().Property(item => item.Voie).IsRequired();
            modelBuilder.Entity<ChsPrevision>().Property(item => item.Voie).HasMaxLength(6);
            modelBuilder.Entity<ChsPrevision>().Property(item => item.Voie).HasColumnName("VOIE");
            modelBuilder.Entity<ChsPrevision>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<ChsPrevision>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<ChsPrevision>().Property(item => item.CdContrainteChsType).HasMaxLength(100);
            modelBuilder.Entity<ChsPrevision>().Property(item => item.CdContrainteChsType).HasColumnName("CD_CONTRAINTE_CHS__TYPE");
            modelBuilder.Entity<ChsPrevision>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<ChsPrevision>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<ChsPrevision>().Property(item => item.Montant).HasColumnName("MONTANT");
            modelBuilder.Entity<ChsPrevision>().Property(item => item.DateDebut).HasColumnName("DATE_DEBUT");
            modelBuilder.Entity<ChsPrevision>().Property(item => item.DateFin).HasColumnName("DATE_FIN");
            modelBuilder.Entity<ChsPrevision>().Property(item => item.DateDemPub).HasColumnName("DATE_DEM_PUB");
            modelBuilder.Entity<ChsPrevision>().Property(item => item.Realise).HasColumnName("REALISE");
            modelBuilder.Entity<ChsPrevision>().Property(item => item.Commentaire).HasMaxLength(255);
            modelBuilder.Entity<ChsPrevision>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<ChsCdContrainte>().ToTable("CD_CONTRAINTE_CHS","CHS");
            modelBuilder.Entity<ChsCdContrainte>().HasKey(item => new {item.Type });
            modelBuilder.Entity<ChsCdContrainte>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<ChsCdContrainte>().Property(item => item.Type).HasMaxLength(100);
            modelBuilder.Entity<ChsCdContrainte>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<ChsBpu>().ToTable("BPU_CHS","CHS");
            modelBuilder.Entity<ChsBpu>().HasKey(item => new {item.Code });
            modelBuilder.Entity<ChsBpu>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<ChsBpu>().Property(item => item.Code).HasMaxLength(25);
            modelBuilder.Entity<ChsBpu>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<ChsBpu>().Property(item => item.CdTravauxChsCode).IsRequired();
            modelBuilder.Entity<ChsBpu>().Property(item => item.CdTravauxChsCode).HasMaxLength(60);
            modelBuilder.Entity<ChsBpu>().Property(item => item.CdTravauxChsCode).HasColumnName("CD_TRAVAUX_CHS__CODE");
            modelBuilder.Entity<ChsBpu>().Property(item => item.Libelle).HasMaxLength(250);
            modelBuilder.Entity<ChsBpu>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<ChsBpu>().Property(item => item.Prix).HasColumnName("PRIX");
            modelBuilder.Entity<ChsBpu>().Property(item => item.DateMaj).HasColumnName("DATE_MAJ");
            modelBuilder.Entity<ChsCdTravaux>().ToTable("CD_TRAVAUX_CHS","CHS");
            modelBuilder.Entity<ChsCdTravaux>().HasKey(item => new {item.Code });
            modelBuilder.Entity<ChsCdTravaux>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<ChsCdTravaux>().Property(item => item.Code).HasMaxLength(60);
            modelBuilder.Entity<ChsCdTravaux>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<ChsPlateforme>().ToTable("PLATEFORME_CHS","CHS");
            modelBuilder.Entity<ChsPlateforme>().HasKey(item => new {item.Liaison,item.Sens,item.AbsDeb });
            modelBuilder.Entity<ChsPlateforme>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<ChsPlateforme>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<ChsPlateforme>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<ChsPlateforme>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<ChsPlateforme>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<ChsPlateforme>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<ChsPlateforme>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<ChsPlateforme>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<ChsPlateforme>().Property(item => item.CdMpaChsValeur).IsRequired();
            modelBuilder.Entity<ChsPlateforme>().Property(item => item.CdMpaChsValeur).HasColumnName("CD_MPA_CHS__VALEUR");
            modelBuilder.Entity<ChsPlateforme>().Property(item => item.CdPortanceChsClasse).IsRequired();
            modelBuilder.Entity<ChsPlateforme>().Property(item => item.CdPortanceChsClasse).HasMaxLength(6);
            modelBuilder.Entity<ChsPlateforme>().Property(item => item.CdPortanceChsClasse).HasColumnName("CD_PORTANCE_CHS__CLASSE");
            modelBuilder.Entity<ChsPlateforme>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<ChsPlateforme>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<ChsCdPortance>().ToTable("CD_PORTANCE_CHS","CHS");
            modelBuilder.Entity<ChsCdPortance>().HasKey(item => new {item.Classe });
            modelBuilder.Entity<ChsCdPortance>().Property(item => item.Classe).IsRequired();
            modelBuilder.Entity<ChsCdPortance>().Property(item => item.Classe).HasMaxLength(6);
            modelBuilder.Entity<ChsCdPortance>().Property(item => item.Classe).HasColumnName("CLASSE");
            modelBuilder.Entity<ChsCdMpa>().ToTable("CD_MPA_CHS","CHS");
            modelBuilder.Entity<ChsCdMpa>().HasKey(item => new {item.Valeur });
            modelBuilder.Entity<ChsCdMpa>().Property(item => item.Valeur).IsRequired();
            modelBuilder.Entity<ChsCdMpa>().Property(item => item.Valeur).HasColumnName("VALEUR");
            modelBuilder.Entity<ChsCdMo>().ToTable("CD_MO_CHS","CHS");
            modelBuilder.Entity<ChsCdMo>().HasKey(item => new {item.Mo });
            modelBuilder.Entity<ChsCdMo>().Property(item => item.Mo).IsRequired();
            modelBuilder.Entity<ChsCdMo>().Property(item => item.Mo).HasMaxLength(25);
            modelBuilder.Entity<ChsCdMo>().Property(item => item.Mo).HasColumnName("MO");
            modelBuilder.Entity<ChsSousCouche>().ToTable("SOUS_COUCHE_CHS","CHS");
            modelBuilder.Entity<ChsSousCouche>().HasKey(item => new {item.CdCouChsCouche,item.PaveChsDateMs,item.PaveChsLiaison,item.PaveChsSens,item.PaveChsAbsDeb,item.PaveChsAbsFin,item.Numordre });
            modelBuilder.Entity<ChsSousCouche>().Property(item => item.CdCouChsCouche).IsRequired();
            modelBuilder.Entity<ChsSousCouche>().Property(item => item.CdCouChsCouche).HasMaxLength(14);
            modelBuilder.Entity<ChsSousCouche>().Property(item => item.CdCouChsCouche).HasColumnName("CD_COU_CHS__COUCHE");
            modelBuilder.Entity<ChsSousCouche>().Property(item => item.PaveChsDateMs).IsRequired();
            modelBuilder.Entity<ChsSousCouche>().Property(item => item.PaveChsDateMs).HasColumnName("PAVE_CHS__DATE_MS");
            modelBuilder.Entity<ChsSousCouche>().Property(item => item.PaveChsLiaison).IsRequired();
            modelBuilder.Entity<ChsSousCouche>().Property(item => item.PaveChsLiaison).HasMaxLength(15);
            modelBuilder.Entity<ChsSousCouche>().Property(item => item.PaveChsLiaison).HasColumnName("PAVE_CHS__LIAISON");
            modelBuilder.Entity<ChsSousCouche>().Property(item => item.PaveChsSens).IsRequired();
            modelBuilder.Entity<ChsSousCouche>().Property(item => item.PaveChsSens).HasMaxLength(6);
            modelBuilder.Entity<ChsSousCouche>().Property(item => item.PaveChsSens).HasColumnName("PAVE_CHS__SENS");
            modelBuilder.Entity<ChsSousCouche>().Property(item => item.PaveChsAbsDeb).IsRequired();
            modelBuilder.Entity<ChsSousCouche>().Property(item => item.PaveChsAbsDeb).HasColumnName("PAVE_CHS__ABS_DEB");
            modelBuilder.Entity<ChsSousCouche>().Property(item => item.PaveChsAbsFin).IsRequired();
            modelBuilder.Entity<ChsSousCouche>().Property(item => item.PaveChsAbsFin).HasColumnName("PAVE_CHS__ABS_FIN");
            modelBuilder.Entity<ChsSousCouche>().Property(item => item.Numordre).IsRequired();
            modelBuilder.Entity<ChsSousCouche>().Property(item => item.Numordre).HasColumnName("NUMORDRE");
            modelBuilder.Entity<ChsSousCouche>().Property(item => item.CdFamTechChsCode).IsRequired();
            modelBuilder.Entity<ChsSousCouche>().Property(item => item.CdFamTechChsCode).HasMaxLength(15);
            modelBuilder.Entity<ChsSousCouche>().Property(item => item.CdFamTechChsCode).HasColumnName("CD_FAM_TECH_CHS__CODE");
            modelBuilder.Entity<ChsSousCouche>().Property(item => item.CdTechChsTechnique).IsRequired();
            modelBuilder.Entity<ChsSousCouche>().Property(item => item.CdTechChsTechnique).HasMaxLength(12);
            modelBuilder.Entity<ChsSousCouche>().Property(item => item.CdTechChsTechnique).HasColumnName("CD_TECH_CHS__TECHNIQUE");
            modelBuilder.Entity<ChsSousCouche>().Property(item => item.Epais).IsRequired();
            modelBuilder.Entity<ChsSousCouche>().Property(item => item.Epais).HasColumnName("EPAIS");
            modelBuilder.Entity<ChsSousCouche>().Property(item => item.Dosage).HasMaxLength(5);
            modelBuilder.Entity<ChsSousCouche>().Property(item => item.Dosage).HasColumnName("DOSAGE");
            modelBuilder.Entity<ChsClCarotte>().ToTable("CL_CAROTTE_CHS","CHS");
            modelBuilder.Entity<ChsClCarotte>().HasKey(item => new {item.Liaison,item.Sens,item.Voie,item.AbsDeb });
            modelBuilder.Entity<ChsClCarotte>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<ChsClCarotte>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<ChsClCarotte>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<ChsClCarotte>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<ChsClCarotte>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<ChsClCarotte>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<ChsClCarotte>().Property(item => item.Voie).IsRequired();
            modelBuilder.Entity<ChsClCarotte>().Property(item => item.Voie).HasMaxLength(6);
            modelBuilder.Entity<ChsClCarotte>().Property(item => item.Voie).HasColumnName("VOIE");
            modelBuilder.Entity<ChsClCarotte>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<ChsClCarotte>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<ChsClCarotte>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<ChsClCarotte>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<ChsDetailCarotte>().ToTable("DETAIL_CAROTTE_CHS","CHS");
            modelBuilder.Entity<ChsDetailCarotte>().HasKey(item => new {item.ClCarotteChsLiaison,item.ClCarotteChsSens,item.ClCarotteChsVoie,item.ClCarotteChsAbsDeb,item.DateMs,item.Posit,item.Numordre });
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.ClCarotteChsLiaison).IsRequired();
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.ClCarotteChsLiaison).HasMaxLength(15);
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.ClCarotteChsLiaison).HasColumnName("CL_CAROTTE_CHS__LIAISON");
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.ClCarotteChsSens).IsRequired();
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.ClCarotteChsSens).HasMaxLength(6);
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.ClCarotteChsSens).HasColumnName("CL_CAROTTE_CHS__SENS");
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.ClCarotteChsVoie).IsRequired();
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.ClCarotteChsVoie).HasMaxLength(6);
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.ClCarotteChsVoie).HasColumnName("CL_CAROTTE_CHS__VOIE");
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.ClCarotteChsAbsDeb).IsRequired();
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.ClCarotteChsAbsDeb).HasColumnName("CL_CAROTTE_CHS__ABS_DEB");
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.DateMs).IsRequired();
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.Posit).IsRequired();
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.Posit).HasColumnName("POSIT");
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.Numordre).IsRequired();
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.Numordre).HasColumnName("NUMORDRE");
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.Couche).IsRequired();
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.Couche).HasMaxLength(12);
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.Couche).HasColumnName("COUCHE");
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.Technique).HasMaxLength(12);
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.Technique).HasColumnName("TECHNIQUE");
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.Epais).HasColumnName("EPAIS");
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.Granulo).HasMaxLength(6);
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.Granulo).HasColumnName("GRANULO");
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.TypeSc).HasMaxLength(25);
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.TypeSc).HasColumnName("TYPE_SC");
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.EpaisSc).HasColumnName("EPAIS_SC");
            modelBuilder.Entity<ChsDetailCarotte>().Property(item => item.DureeServ).HasColumnName("DUREE_SERV");
            modelBuilder.Entity<ChsExploitCarotte>().ToTable("EXPLOIT_CAROTTE_CHS","CHS");
            modelBuilder.Entity<ChsExploitCarotte>().HasKey(item => new {item.ClCarotteChsLiaison,item.ClCarotteChsSens,item.ClCarotteChsVoie,item.ClCarotteChsAbsDeb,item.DateMs,item.Posit,item.Numordre });
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.ClCarotteChsLiaison).IsRequired();
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.ClCarotteChsLiaison).HasMaxLength(15);
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.ClCarotteChsLiaison).HasColumnName("CL_CAROTTE_CHS__LIAISON");
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.ClCarotteChsSens).IsRequired();
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.ClCarotteChsSens).HasMaxLength(6);
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.ClCarotteChsSens).HasColumnName("CL_CAROTTE_CHS__SENS");
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.ClCarotteChsVoie).IsRequired();
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.ClCarotteChsVoie).HasMaxLength(6);
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.ClCarotteChsVoie).HasColumnName("CL_CAROTTE_CHS__VOIE");
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.ClCarotteChsAbsDeb).IsRequired();
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.ClCarotteChsAbsDeb).HasColumnName("CL_CAROTTE_CHS__ABS_DEB");
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.DateMs).IsRequired();
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.Posit).IsRequired();
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.Posit).HasColumnName("POSIT");
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.Numordre).IsRequired();
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.Numordre).HasColumnName("NUMORDRE");
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.Couche).IsRequired();
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.Couche).HasMaxLength(12);
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.Couche).HasColumnName("COUCHE");
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.Technique).HasMaxLength(12);
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.Technique).HasColumnName("TECHNIQUE");
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.Epais).HasColumnName("EPAIS");
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.Granulo).HasMaxLength(6);
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.Granulo).HasColumnName("GRANULO");
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.TypeSc).HasMaxLength(25);
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.TypeSc).HasColumnName("TYPE_SC");
            modelBuilder.Entity<ChsExploitCarotte>().Property(item => item.EpaisSc).HasColumnName("EPAIS_SC");
            modelBuilder.Entity<ChsFamCar>().ToTable("FAM_CAR_CHS","CHS");
            modelBuilder.Entity<ChsFamCar>().HasKey(item => new {item.CdFamCarChsFamille,item.Liaison,item.Sens,item.AbsDeb,item.AbsFin });
            modelBuilder.Entity<ChsFamCar>().Property(item => item.CdFamCarChsFamille).IsRequired();
            modelBuilder.Entity<ChsFamCar>().Property(item => item.CdFamCarChsFamille).HasMaxLength(12);
            modelBuilder.Entity<ChsFamCar>().Property(item => item.CdFamCarChsFamille).HasColumnName("CD_FAM_CAR_CHS__FAMILLE");
            modelBuilder.Entity<ChsFamCar>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<ChsFamCar>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<ChsFamCar>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<ChsFamCar>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<ChsFamCar>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<ChsFamCar>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<ChsFamCar>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<ChsFamCar>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<ChsFamCar>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<ChsFamCar>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<ChsFamCar>().Property(item => item.Progressive).HasColumnName("PROGRESSIVE");
            modelBuilder.Entity<ChsFamCar>().Property(item => item.Commentaire).HasMaxLength(255);
            modelBuilder.Entity<ChsFamCar>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<ChsClRoul>().ToTable("CL_ROUL_CHS","CHS");
            modelBuilder.Entity<ChsClRoul>().HasKey(item => new {item.ClCarotteChsLiaison,item.ClCarotteChsSens,item.ClCarotteChsVoie,item.ClCarotteChsAbsDeb,item.DateMs });
            modelBuilder.Entity<ChsClRoul>().Property(item => item.ClCarotteChsLiaison).IsRequired();
            modelBuilder.Entity<ChsClRoul>().Property(item => item.ClCarotteChsLiaison).HasMaxLength(15);
            modelBuilder.Entity<ChsClRoul>().Property(item => item.ClCarotteChsLiaison).HasColumnName("CL_CAROTTE_CHS__LIAISON");
            modelBuilder.Entity<ChsClRoul>().Property(item => item.ClCarotteChsSens).IsRequired();
            modelBuilder.Entity<ChsClRoul>().Property(item => item.ClCarotteChsSens).HasMaxLength(6);
            modelBuilder.Entity<ChsClRoul>().Property(item => item.ClCarotteChsSens).HasColumnName("CL_CAROTTE_CHS__SENS");
            modelBuilder.Entity<ChsClRoul>().Property(item => item.ClCarotteChsVoie).IsRequired();
            modelBuilder.Entity<ChsClRoul>().Property(item => item.ClCarotteChsVoie).HasMaxLength(6);
            modelBuilder.Entity<ChsClRoul>().Property(item => item.ClCarotteChsVoie).HasColumnName("CL_CAROTTE_CHS__VOIE");
            modelBuilder.Entity<ChsClRoul>().Property(item => item.ClCarotteChsAbsDeb).IsRequired();
            modelBuilder.Entity<ChsClRoul>().Property(item => item.ClCarotteChsAbsDeb).HasColumnName("CL_CAROTTE_CHS__ABS_DEB");
            modelBuilder.Entity<ChsClRoul>().Property(item => item.DateMs).IsRequired();
            modelBuilder.Entity<ChsClRoul>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<ChsClRoul>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<ChsClRoul>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<ChsClRoul>().Property(item => item.Technique).HasMaxLength(12);
            modelBuilder.Entity<ChsClRoul>().Property(item => item.Technique).HasColumnName("TECHNIQUE");
            modelBuilder.Entity<ChsClRoul>().Property(item => item.Epais).HasColumnName("EPAIS");
            modelBuilder.Entity<ChsClRoul>().Property(item => item.Granulo).HasMaxLength(6);
            modelBuilder.Entity<ChsClRoul>().Property(item => item.Granulo).HasColumnName("GRANULO");
            modelBuilder.Entity<ChsZh>().ToTable("ZH_CHS","CHS");
            modelBuilder.Entity<ChsZh>().HasKey(item => new {item.CdCdMesureChsAgr,item.CdMesureChsAgr,item.CdIndicChsIndic,item.CampChsSection,item.CampChsAnnee,item.CampChsLiaison,item.CampChsSens,item.CampChsVoie,item.AbsDeb,item.Voie });
            modelBuilder.Entity<ChsZh>().Property(item => item.CdCdMesureChsAgr).IsRequired();
            modelBuilder.Entity<ChsZh>().Property(item => item.CdCdMesureChsAgr).HasMaxLength(12);
            modelBuilder.Entity<ChsZh>().Property(item => item.CdCdMesureChsAgr).HasColumnName("CD__CD_MESURE_CHS__AGR");
            modelBuilder.Entity<ChsZh>().Property(item => item.CdMesureChsAgr).IsRequired();
            modelBuilder.Entity<ChsZh>().Property(item => item.CdMesureChsAgr).HasMaxLength(12);
            modelBuilder.Entity<ChsZh>().Property(item => item.CdMesureChsAgr).HasColumnName("CD_MESURE_CHS__AGR");
            modelBuilder.Entity<ChsZh>().Property(item => item.CdIndicChsIndic).IsRequired();
            modelBuilder.Entity<ChsZh>().Property(item => item.CdIndicChsIndic).HasMaxLength(12);
            modelBuilder.Entity<ChsZh>().Property(item => item.CdIndicChsIndic).HasColumnName("CD_INDIC_CHS__INDIC");
            modelBuilder.Entity<ChsZh>().Property(item => item.CampChsSection).IsRequired();
            modelBuilder.Entity<ChsZh>().Property(item => item.CampChsSection).HasMaxLength(15);
            modelBuilder.Entity<ChsZh>().Property(item => item.CampChsSection).HasColumnName("CAMP_CHS__SECTION");
            modelBuilder.Entity<ChsZh>().Property(item => item.CampChsAnnee).IsRequired();
            modelBuilder.Entity<ChsZh>().Property(item => item.CampChsAnnee).HasColumnName("CAMP_CHS__ANNEE");
            modelBuilder.Entity<ChsZh>().Property(item => item.CampChsLiaison).IsRequired();
            modelBuilder.Entity<ChsZh>().Property(item => item.CampChsLiaison).HasMaxLength(15);
            modelBuilder.Entity<ChsZh>().Property(item => item.CampChsLiaison).HasColumnName("CAMP_CHS__LIAISON");
            modelBuilder.Entity<ChsZh>().Property(item => item.CampChsSens).IsRequired();
            modelBuilder.Entity<ChsZh>().Property(item => item.CampChsSens).HasMaxLength(6);
            modelBuilder.Entity<ChsZh>().Property(item => item.CampChsSens).HasColumnName("CAMP_CHS__SENS");
            modelBuilder.Entity<ChsZh>().Property(item => item.CampChsVoie).IsRequired();
            modelBuilder.Entity<ChsZh>().Property(item => item.CampChsVoie).HasMaxLength(6);
            modelBuilder.Entity<ChsZh>().Property(item => item.CampChsVoie).HasColumnName("CAMP_CHS__VOIE");
            modelBuilder.Entity<ChsZh>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<ChsZh>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<ChsZh>().Property(item => item.Voie).IsRequired();
            modelBuilder.Entity<ChsZh>().Property(item => item.Voie).HasMaxLength(6);
            modelBuilder.Entity<ChsZh>().Property(item => item.Voie).HasColumnName("VOIE");
            modelBuilder.Entity<ChsZh>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<ChsZh>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<ChsZh>().Property(item => item.Valeur).IsRequired();
            modelBuilder.Entity<ChsZh>().Property(item => item.Valeur).HasColumnName("VALEUR");
            modelBuilder.Entity<ChsDetailCamp>().ToTable("DETAIL_CAMP_CHS","CHS");
            modelBuilder.Entity<ChsDetailCamp>().HasKey(item => new {item.CdCdMesureChsAgr,item.CdIndicChsIndic,item.CdMesureChsAgr,item.CampChsSection,item.CampChsAnnee,item.CampChsLiaison,item.CampChsSens,item.CampChsVoie });
            modelBuilder.Entity<ChsDetailCamp>().Property(item => item.CdCdMesureChsAgr).IsRequired();
            modelBuilder.Entity<ChsDetailCamp>().Property(item => item.CdCdMesureChsAgr).HasMaxLength(12);
            modelBuilder.Entity<ChsDetailCamp>().Property(item => item.CdCdMesureChsAgr).HasColumnName("CD__CD_MESURE_CHS__AGR");
            modelBuilder.Entity<ChsDetailCamp>().Property(item => item.CdIndicChsIndic).IsRequired();
            modelBuilder.Entity<ChsDetailCamp>().Property(item => item.CdIndicChsIndic).HasMaxLength(12);
            modelBuilder.Entity<ChsDetailCamp>().Property(item => item.CdIndicChsIndic).HasColumnName("CD_INDIC_CHS__INDIC");
            modelBuilder.Entity<ChsDetailCamp>().Property(item => item.CdMesureChsAgr).IsRequired();
            modelBuilder.Entity<ChsDetailCamp>().Property(item => item.CdMesureChsAgr).HasMaxLength(12);
            modelBuilder.Entity<ChsDetailCamp>().Property(item => item.CdMesureChsAgr).HasColumnName("CD_MESURE_CHS__AGR");
            modelBuilder.Entity<ChsDetailCamp>().Property(item => item.CampChsSection).IsRequired();
            modelBuilder.Entity<ChsDetailCamp>().Property(item => item.CampChsSection).HasMaxLength(15);
            modelBuilder.Entity<ChsDetailCamp>().Property(item => item.CampChsSection).HasColumnName("CAMP_CHS__SECTION");
            modelBuilder.Entity<ChsDetailCamp>().Property(item => item.CampChsAnnee).IsRequired();
            modelBuilder.Entity<ChsDetailCamp>().Property(item => item.CampChsAnnee).HasColumnName("CAMP_CHS__ANNEE");
            modelBuilder.Entity<ChsDetailCamp>().Property(item => item.CampChsLiaison).IsRequired();
            modelBuilder.Entity<ChsDetailCamp>().Property(item => item.CampChsLiaison).HasMaxLength(15);
            modelBuilder.Entity<ChsDetailCamp>().Property(item => item.CampChsLiaison).HasColumnName("CAMP_CHS__LIAISON");
            modelBuilder.Entity<ChsDetailCamp>().Property(item => item.CampChsSens).IsRequired();
            modelBuilder.Entity<ChsDetailCamp>().Property(item => item.CampChsSens).HasMaxLength(6);
            modelBuilder.Entity<ChsDetailCamp>().Property(item => item.CampChsSens).HasColumnName("CAMP_CHS__SENS");
            modelBuilder.Entity<ChsDetailCamp>().Property(item => item.CampChsVoie).IsRequired();
            modelBuilder.Entity<ChsDetailCamp>().Property(item => item.CampChsVoie).HasMaxLength(6);
            modelBuilder.Entity<ChsDetailCamp>().Property(item => item.CampChsVoie).HasColumnName("CAMP_CHS__VOIE");
            modelBuilder.Entity<ChsPaveVoie>().ToTable("PAVE_VOIE_CHS","CHS");
            modelBuilder.Entity<ChsPaveVoie>().HasKey(item => new {item.CdCouChsCouche,item.PaveChsDateMs,item.PaveChsLiaison,item.PaveChsSens,item.PaveChsAbsDeb,item.PaveChsAbsFin,item.Voie,item.Voiedeb,item.Voiefin });
            modelBuilder.Entity<ChsPaveVoie>().Property(item => item.CdCouChsCouche).IsRequired();
            modelBuilder.Entity<ChsPaveVoie>().Property(item => item.CdCouChsCouche).HasMaxLength(14);
            modelBuilder.Entity<ChsPaveVoie>().Property(item => item.CdCouChsCouche).HasColumnName("CD_COU_CHS__COUCHE");
            modelBuilder.Entity<ChsPaveVoie>().Property(item => item.PaveChsDateMs).IsRequired();
            modelBuilder.Entity<ChsPaveVoie>().Property(item => item.PaveChsDateMs).HasColumnName("PAVE_CHS__DATE_MS");
            modelBuilder.Entity<ChsPaveVoie>().Property(item => item.PaveChsLiaison).IsRequired();
            modelBuilder.Entity<ChsPaveVoie>().Property(item => item.PaveChsLiaison).HasMaxLength(15);
            modelBuilder.Entity<ChsPaveVoie>().Property(item => item.PaveChsLiaison).HasColumnName("PAVE_CHS__LIAISON");
            modelBuilder.Entity<ChsPaveVoie>().Property(item => item.PaveChsSens).IsRequired();
            modelBuilder.Entity<ChsPaveVoie>().Property(item => item.PaveChsSens).HasMaxLength(6);
            modelBuilder.Entity<ChsPaveVoie>().Property(item => item.PaveChsSens).HasColumnName("PAVE_CHS__SENS");
            modelBuilder.Entity<ChsPaveVoie>().Property(item => item.PaveChsAbsDeb).IsRequired();
            modelBuilder.Entity<ChsPaveVoie>().Property(item => item.PaveChsAbsDeb).HasColumnName("PAVE_CHS__ABS_DEB");
            modelBuilder.Entity<ChsPaveVoie>().Property(item => item.PaveChsAbsFin).IsRequired();
            modelBuilder.Entity<ChsPaveVoie>().Property(item => item.PaveChsAbsFin).HasColumnName("PAVE_CHS__ABS_FIN");
            modelBuilder.Entity<ChsPaveVoie>().Property(item => item.Voie).IsRequired();
            modelBuilder.Entity<ChsPaveVoie>().Property(item => item.Voie).HasMaxLength(6);
            modelBuilder.Entity<ChsPaveVoie>().Property(item => item.Voie).HasColumnName("VOIE");
            modelBuilder.Entity<ChsPaveVoie>().Property(item => item.Voiedeb).IsRequired();
            modelBuilder.Entity<ChsPaveVoie>().Property(item => item.Voiedeb).HasColumnName("VOIEDEB");
            modelBuilder.Entity<ChsPaveVoie>().Property(item => item.Voiefin).IsRequired();
            modelBuilder.Entity<ChsPaveVoie>().Property(item => item.Voiefin).HasColumnName("VOIEFIN");
            modelBuilder.Entity<ChsClPaveVoie>().ToTable("CL_PAVE_VOIE_CHS","CHS");
            modelBuilder.Entity<ChsClPaveVoie>().HasKey(item => new {item.CdCouChsCouche,item.PaveChsDateMs,item.PaveChsLiaison,item.PaveChsSens,item.PaveChsAbsDeb,item.PaveChsAbsFin,item.PaveVoieChsVoie,item.PaveVoieChsVoiedeb,item.PaveVoieChsVoiefin,item.AbsDeb });
            modelBuilder.Entity<ChsClPaveVoie>().Property(item => item.CdCouChsCouche).IsRequired();
            modelBuilder.Entity<ChsClPaveVoie>().Property(item => item.CdCouChsCouche).HasMaxLength(14);
            modelBuilder.Entity<ChsClPaveVoie>().Property(item => item.CdCouChsCouche).HasColumnName("CD_COU_CHS__COUCHE");
            modelBuilder.Entity<ChsClPaveVoie>().Property(item => item.PaveChsDateMs).IsRequired();
            modelBuilder.Entity<ChsClPaveVoie>().Property(item => item.PaveChsDateMs).HasColumnName("PAVE_CHS__DATE_MS");
            modelBuilder.Entity<ChsClPaveVoie>().Property(item => item.PaveChsLiaison).IsRequired();
            modelBuilder.Entity<ChsClPaveVoie>().Property(item => item.PaveChsLiaison).HasMaxLength(15);
            modelBuilder.Entity<ChsClPaveVoie>().Property(item => item.PaveChsLiaison).HasColumnName("PAVE_CHS__LIAISON");
            modelBuilder.Entity<ChsClPaveVoie>().Property(item => item.PaveChsSens).IsRequired();
            modelBuilder.Entity<ChsClPaveVoie>().Property(item => item.PaveChsSens).HasMaxLength(6);
            modelBuilder.Entity<ChsClPaveVoie>().Property(item => item.PaveChsSens).HasColumnName("PAVE_CHS__SENS");
            modelBuilder.Entity<ChsClPaveVoie>().Property(item => item.PaveChsAbsDeb).IsRequired();
            modelBuilder.Entity<ChsClPaveVoie>().Property(item => item.PaveChsAbsDeb).HasColumnName("PAVE_CHS__ABS_DEB");
            modelBuilder.Entity<ChsClPaveVoie>().Property(item => item.PaveChsAbsFin).IsRequired();
            modelBuilder.Entity<ChsClPaveVoie>().Property(item => item.PaveChsAbsFin).HasColumnName("PAVE_CHS__ABS_FIN");
            modelBuilder.Entity<ChsClPaveVoie>().Property(item => item.PaveVoieChsVoie).IsRequired();
            modelBuilder.Entity<ChsClPaveVoie>().Property(item => item.PaveVoieChsVoie).HasMaxLength(6);
            modelBuilder.Entity<ChsClPaveVoie>().Property(item => item.PaveVoieChsVoie).HasColumnName("PAVE_VOIE_CHS__VOIE");
            modelBuilder.Entity<ChsClPaveVoie>().Property(item => item.PaveVoieChsVoiedeb).IsRequired();
            modelBuilder.Entity<ChsClPaveVoie>().Property(item => item.PaveVoieChsVoiedeb).HasColumnName("PAVE_VOIE_CHS__VOIEDEB");
            modelBuilder.Entity<ChsClPaveVoie>().Property(item => item.PaveVoieChsVoiefin).IsRequired();
            modelBuilder.Entity<ChsClPaveVoie>().Property(item => item.PaveVoieChsVoiefin).HasColumnName("PAVE_VOIE_CHS__VOIEFIN");
            modelBuilder.Entity<ChsClPaveVoie>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<ChsClPaveVoie>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<ChsClPaveVoie>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<ChsClPaveVoie>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<ChsDictionnaire>().ToTable("DICTIONNAIRE_CHS","CHS");
            modelBuilder.Entity<ChsDictionnaire>().HasKey(item => new {item.Nom });
            modelBuilder.Entity<ChsDictionnaire>().Property(item => item.Nom).IsRequired();
            modelBuilder.Entity<ChsDictionnaire>().Property(item => item.Nom).HasMaxLength(100);
            modelBuilder.Entity<ChsDictionnaire>().Property(item => item.Nom).HasColumnName("NOM");
            modelBuilder.Entity<ChsDictionnaire>().Property(item => item.Description).HasMaxLength(255);
            modelBuilder.Entity<ChsDictionnaire>().Property(item => item.Description).HasColumnName("DESCRIPTION");
            modelBuilder.Entity<ChsDictionnaire>().Property(item => item.Definition).HasMaxLength(1000);
            modelBuilder.Entity<ChsDictionnaire>().Property(item => item.Definition).HasColumnName("DEFINITION");
            modelBuilder.Entity<ChsDictionnaire>().Property(item => item.Motscles).HasMaxLength(255);
            modelBuilder.Entity<ChsDictionnaire>().Property(item => item.Motscles).HasColumnName("MOTSCLES");
            modelBuilder.Entity<ChsCdEvt>().ToTable("CD_EVT_CHS","CHS");
            modelBuilder.Entity<ChsCdEvt>().HasKey(item => new {item.Type });
            modelBuilder.Entity<ChsCdEvt>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<ChsCdEvt>().Property(item => item.Type).HasMaxLength(25);
            modelBuilder.Entity<ChsCdEvt>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<ChsCdEvt>().Property(item => item.Impact).HasColumnName("IMPACT");
            modelBuilder.Entity<ChsEvt>().ToTable("EVT_CHS","CHS");
            modelBuilder.Entity<ChsEvt>().HasKey(item => new {item.CdEvtChsType,item.IdEvt });
            modelBuilder.Entity<ChsEvt>().Property(item => item.CdEvtChsType).IsRequired();
            modelBuilder.Entity<ChsEvt>().Property(item => item.CdEvtChsType).HasMaxLength(25);
            modelBuilder.Entity<ChsEvt>().Property(item => item.CdEvtChsType).HasColumnName("CD_EVT_CHS__TYPE");
            modelBuilder.Entity<ChsEvt>().Property(item => item.IdEvt).IsRequired();
            modelBuilder.Entity<ChsEvt>().Property(item => item.IdEvt).HasColumnName("ID_EVT");
            modelBuilder.Entity<ChsEvt>().Property(item => item.CdPositChsPosit).HasMaxLength(60);
            modelBuilder.Entity<ChsEvt>().Property(item => item.CdPositChsPosit).HasColumnName("CD_POSIT_CHS__POSIT");
            modelBuilder.Entity<ChsEvt>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<ChsEvt>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<ChsEvt>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<ChsEvt>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<ChsEvt>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<ChsEvt>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<ChsEvt>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<ChsEvt>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<ChsEvt>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<ChsEvt>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<ChsEvt>().Property(item => item.DateRel).IsRequired();
            modelBuilder.Entity<ChsEvt>().Property(item => item.DateRel).HasColumnName("DATE_REL");
            modelBuilder.Entity<ChsEvt>().Property(item => item.Vsta).HasColumnName("VSTA");
            modelBuilder.Entity<ChsEvt>().Property(item => item.Obsv).HasMaxLength(255);
            modelBuilder.Entity<ChsEvt>().Property(item => item.Obsv).HasColumnName("OBSV");
            modelBuilder.Entity<ChsEvt>().Property(item => item.DateTrt).HasColumnName("DATE_TRT");
            modelBuilder.Entity<ChsCdPosit>().ToTable("CD_POSIT_CHS","CHS");
            modelBuilder.Entity<ChsCdPosit>().HasKey(item => new {item.Posit });
            modelBuilder.Entity<ChsCdPosit>().Property(item => item.Posit).IsRequired();
            modelBuilder.Entity<ChsCdPosit>().Property(item => item.Posit).HasMaxLength(60);
            modelBuilder.Entity<ChsCdPosit>().Property(item => item.Posit).HasColumnName("POSIT");
            modelBuilder.Entity<ChsNeAdmin>().ToTable("NE_ADMIN_CHS","CHS");
            modelBuilder.Entity<ChsNeAdmin>().HasKey(item => new {item.Liaison,item.Sens,item.AbsDeb });
            modelBuilder.Entity<ChsNeAdmin>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<ChsNeAdmin>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<ChsNeAdmin>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<ChsNeAdmin>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<ChsNeAdmin>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<ChsNeAdmin>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<ChsNeAdmin>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<ChsNeAdmin>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<ChsNeAdmin>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<ChsNeAdmin>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<ChsNeAdmin>().Property(item => item.NeAdmiss).HasColumnName("NE_ADMISS");
            modelBuilder.Entity<ChsNeAdmin>().Property(item => item.DateAdmiss).HasColumnName("DATE_ADMISS");
            modelBuilder.Entity<ChsContact>().ToTable("CONTACT_CHS","CHS");
            modelBuilder.Entity<ChsContact>().HasKey(item => new {item.DocChsId });
            modelBuilder.Entity<ChsContact>().Property(item => item.DocChsId).IsRequired();
            modelBuilder.Entity<ChsContact>().Property(item => item.DocChsId).HasColumnName("DOC_CHS__ID");
            modelBuilder.Entity<ChsContact>().Property(item => item.Givenname).HasMaxLength(60);
            modelBuilder.Entity<ChsContact>().Property(item => item.Givenname).HasColumnName("GIVENNAME");
            modelBuilder.Entity<ChsContact>().Property(item => item.Sn).HasMaxLength(60);
            modelBuilder.Entity<ChsContact>().Property(item => item.Sn).HasColumnName("SN");
            modelBuilder.Entity<ChsContact>().Property(item => item.Cn).HasMaxLength(125);
            modelBuilder.Entity<ChsContact>().Property(item => item.Cn).HasColumnName("CN");
            modelBuilder.Entity<ChsContact>().Property(item => item.O).HasMaxLength(60);
            modelBuilder.Entity<ChsContact>().Property(item => item.O).HasColumnName("O");
            modelBuilder.Entity<ChsContact>().Property(item => item.Mail).HasMaxLength(60);
            modelBuilder.Entity<ChsContact>().Property(item => item.Mail).HasColumnName("MAIL");
            modelBuilder.Entity<ChsContact>().Property(item => item.Telephonenumber).HasMaxLength(20);
            modelBuilder.Entity<ChsContact>().Property(item => item.Telephonenumber).HasColumnName("TELEPHONENUMBER");
            modelBuilder.Entity<ChsContact>().Property(item => item.Mobile).HasMaxLength(20);
            modelBuilder.Entity<ChsContact>().Property(item => item.Mobile).HasColumnName("MOBILE");
            modelBuilder.Entity<ChsContact>().Property(item => item.Facsimiletelephonenumber).HasMaxLength(20);
            modelBuilder.Entity<ChsContact>().Property(item => item.Facsimiletelephonenumber).HasColumnName("FACSIMILETELEPHONENUMBER");
            modelBuilder.Entity<ChsContact>().Property(item => item.Street).HasMaxLength(60);
            modelBuilder.Entity<ChsContact>().Property(item => item.Street).HasColumnName("STREET");
            modelBuilder.Entity<ChsContact>().Property(item => item.Mozillaworkstreet2).HasMaxLength(60);
            modelBuilder.Entity<ChsContact>().Property(item => item.Mozillaworkstreet2).HasColumnName("MOZILLAWORKSTREET2");
            modelBuilder.Entity<ChsContact>().Property(item => item.L).HasMaxLength(60);
            modelBuilder.Entity<ChsContact>().Property(item => item.L).HasColumnName("L");
            modelBuilder.Entity<ChsContact>().Property(item => item.Postalcode).HasMaxLength(12);
            modelBuilder.Entity<ChsContact>().Property(item => item.Postalcode).HasColumnName("POSTALCODE");
            modelBuilder.Entity<ChsContact>().Property(item => item.Modifytimestamp).HasColumnName("MODIFYTIMESTAMP");
            modelBuilder.Entity<ChsClsDoc>().ToTable("CLS_DOC_CHS","CHS");
            modelBuilder.Entity<ChsClsDoc>().HasKey(item => new {item.ClsChsId,item.DocChsId });
            modelBuilder.Entity<ChsClsDoc>().Property(item => item.ClsChsId).IsRequired();
            modelBuilder.Entity<ChsClsDoc>().Property(item => item.ClsChsId).HasColumnName("CLS_CHS__ID");
            modelBuilder.Entity<ChsClsDoc>().Property(item => item.DocChsId).IsRequired();
            modelBuilder.Entity<ChsClsDoc>().Property(item => item.DocChsId).HasColumnName("DOC_CHS__ID");
            modelBuilder.Entity<ChsClsDoc>().Property(item => item.Defaut).HasColumnName("DEFAUT");
            modelBuilder.Entity<ChsClsDoc>().Property(item => item.Dossier).HasMaxLength(15);
            modelBuilder.Entity<ChsClsDoc>().Property(item => item.Dossier).HasColumnName("DOSSIER");
            modelBuilder.Entity<DsMat>().ToTable("MAT_DS","DS");
            modelBuilder.Entity<DsMat>().HasKey(item => new {item.Code });
            modelBuilder.Entity<DsMat>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<DsMat>().Property(item => item.Code).HasMaxLength(15);
            modelBuilder.Entity<DsMat>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<DsMat>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<DsMat>().Property(item => item.Libelle).HasMaxLength(200);
            modelBuilder.Entity<DsMat>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<DsMat>().Property(item => item.AgrX).HasMaxLength(15);
            modelBuilder.Entity<DsMat>().Property(item => item.AgrX).HasColumnName("AGR_X");
            modelBuilder.Entity<DsMat>().Property(item => item.IndicX).HasMaxLength(15);
            modelBuilder.Entity<DsMat>().Property(item => item.IndicX).HasColumnName("INDIC_X");
            modelBuilder.Entity<DsMat>().Property(item => item.AgrY).HasMaxLength(15);
            modelBuilder.Entity<DsMat>().Property(item => item.AgrY).HasColumnName("AGR_Y");
            modelBuilder.Entity<DsMat>().Property(item => item.IndicY).HasMaxLength(15);
            modelBuilder.Entity<DsMat>().Property(item => item.IndicY).HasColumnName("INDIC_Y");
            modelBuilder.Entity<DsPon>().ToTable("PON_DS","DS");
            modelBuilder.Entity<DsPon>().HasKey(item => new {item.Code });
            modelBuilder.Entity<DsPon>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<DsPon>().Property(item => item.Code).HasMaxLength(15);
            modelBuilder.Entity<DsPon>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<DsPon>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<DsPon>().Property(item => item.Libelle).HasMaxLength(200);
            modelBuilder.Entity<DsPon>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<DsPon>().Property(item => item.Agr).HasMaxLength(15);
            modelBuilder.Entity<DsPon>().Property(item => item.Agr).HasColumnName("AGR");
            modelBuilder.Entity<DsMatParam>().ToTable("MAT_PARAM_DS","DS");
            modelBuilder.Entity<DsMatParam>().HasKey(item => new {item.MatDsCode,item.X,item.Y });
            modelBuilder.Entity<DsMatParam>().Property(item => item.MatDsCode).IsRequired();
            modelBuilder.Entity<DsMatParam>().Property(item => item.MatDsCode).HasMaxLength(15);
            modelBuilder.Entity<DsMatParam>().Property(item => item.MatDsCode).HasColumnName("MAT_DS__CODE");
            modelBuilder.Entity<DsMatParam>().Property(item => item.X).IsRequired();
            modelBuilder.Entity<DsMatParam>().Property(item => item.X).HasColumnName("X");
            modelBuilder.Entity<DsMatParam>().Property(item => item.Y).IsRequired();
            modelBuilder.Entity<DsMatParam>().Property(item => item.Y).HasColumnName("Y");
            modelBuilder.Entity<DsMatParam>().Property(item => item.Valeur).IsRequired();
            modelBuilder.Entity<DsMatParam>().Property(item => item.Valeur).HasColumnName("VALEUR");
            modelBuilder.Entity<DsPonParam>().ToTable("PON_PARAM_DS","DS");
            modelBuilder.Entity<DsPonParam>().HasKey(item => new {item.PonDsCode,item.Indic });
            modelBuilder.Entity<DsPonParam>().Property(item => item.PonDsCode).IsRequired();
            modelBuilder.Entity<DsPonParam>().Property(item => item.PonDsCode).HasMaxLength(15);
            modelBuilder.Entity<DsPonParam>().Property(item => item.PonDsCode).HasColumnName("PON_DS__CODE");
            modelBuilder.Entity<DsPonParam>().Property(item => item.Indic).IsRequired();
            modelBuilder.Entity<DsPonParam>().Property(item => item.Indic).HasMaxLength(12);
            modelBuilder.Entity<DsPonParam>().Property(item => item.Indic).HasColumnName("INDIC");
            modelBuilder.Entity<DsPonParam>().Property(item => item.Poid).IsRequired();
            modelBuilder.Entity<DsPonParam>().Property(item => item.Poid).HasColumnName("POID");
            modelBuilder.Entity<DsTree>().ToTable("TREE_DS","DS");
            modelBuilder.Entity<DsTree>().HasKey(item => new {item.Id });
            modelBuilder.Entity<DsTree>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<DsTree>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<DsTree>().Property(item => item.Libelle).HasMaxLength(200);
            modelBuilder.Entity<DsTree>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<DsNode>().ToTable("NODE_DS","DS");
            modelBuilder.Entity<DsNode>().HasKey(item => new {item.TreeDsId,item.Id });
            modelBuilder.Entity<DsNode>().Property(item => item.TreeDsId).IsRequired();
            modelBuilder.Entity<DsNode>().Property(item => item.TreeDsId).HasColumnName("TREE_DS__ID");
            modelBuilder.Entity<DsNode>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<DsNode>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<DsNode>().Property(item => item.Libelle).HasMaxLength(200);
            modelBuilder.Entity<DsNode>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<DsNode>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<DsNode>().Property(item => item.Type).HasMaxLength(100);
            modelBuilder.Entity<DsNode>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<DsNode>().Property(item => item.ParentId).IsRequired();
            modelBuilder.Entity<DsNode>().Property(item => item.ParentId).HasColumnName("PARENT_ID");
            modelBuilder.Entity<DsNode>().Property(item => item.Technique).HasMaxLength(100);
            modelBuilder.Entity<DsNode>().Property(item => item.Technique).HasColumnName("TECHNIQUE");
            modelBuilder.Entity<DsNode>().Property(item => item.Structure).HasMaxLength(100);
            modelBuilder.Entity<DsNode>().Property(item => item.Structure).HasColumnName("STRUCTURE");
            modelBuilder.Entity<DsNode>().Property(item => item.NbSi).HasColumnName("NB_SI");
            modelBuilder.Entity<DsNode>().Property(item => item.IsForTrue).IsRequired();
            modelBuilder.Entity<DsNode>().Property(item => item.IsForTrue).HasColumnName("IS_FOR_TRUE");
            modelBuilder.Entity<DsNodeParam>().ToTable("NODE_PARAM_DS","DS");
            modelBuilder.Entity<DsNodeParam>().HasKey(item => new {item.TreeDsId,item.NodeDsId,item.Id });
            modelBuilder.Entity<DsNodeParam>().Property(item => item.TreeDsId).IsRequired();
            modelBuilder.Entity<DsNodeParam>().Property(item => item.TreeDsId).HasColumnName("TREE_DS__ID");
            modelBuilder.Entity<DsNodeParam>().Property(item => item.NodeDsId).IsRequired();
            modelBuilder.Entity<DsNodeParam>().Property(item => item.NodeDsId).HasColumnName("NODE_DS__ID");
            modelBuilder.Entity<DsNodeParam>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<DsNodeParam>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<DsNodeParam>().Property(item => item.Agr).HasMaxLength(20);
            modelBuilder.Entity<DsNodeParam>().Property(item => item.Agr).HasColumnName("AGR");
            modelBuilder.Entity<DsNodeParam>().Property(item => item.Indic).HasMaxLength(20);
            modelBuilder.Entity<DsNodeParam>().Property(item => item.Indic).HasColumnName("INDIC");
            modelBuilder.Entity<DsNodeParam>().Property(item => item.CompareValue).HasColumnName("COMPARE_VALUE");
            modelBuilder.Entity<DsNodeParam>().Property(item => item.CompareOp).HasMaxLength(50);
            modelBuilder.Entity<DsNodeParam>().Property(item => item.CompareOp).HasColumnName("COMPARE_OP");
            modelBuilder.Entity<DsBpuColor>().ToTable("BPU_COLOR_DS","DS");
            modelBuilder.Entity<DsBpuColor>().HasKey(item => new {item.Code });
            modelBuilder.Entity<DsBpuColor>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<DsBpuColor>().Property(item => item.Code).HasMaxLength(30);
            modelBuilder.Entity<DsBpuColor>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<DsBpuColor>().Property(item => item.Color).HasMaxLength(11);
            modelBuilder.Entity<DsBpuColor>().Property(item => item.Color).HasColumnName("COLOR");
            modelBuilder.Entity<DsTreeResultPave>().ToTable("TREE_RESULT_PAVE_DS","DS");
            modelBuilder.Entity<DsTreeResultPave>().HasKey(item => new {item.TreeDsId,item.TreeResultDsId,item.Liaison,item.Sens,item.AbsDeb });
            modelBuilder.Entity<DsTreeResultPave>().Property(item => item.TreeDsId).IsRequired();
            modelBuilder.Entity<DsTreeResultPave>().Property(item => item.TreeDsId).HasColumnName("TREE_DS__ID");
            modelBuilder.Entity<DsTreeResultPave>().Property(item => item.TreeResultDsId).IsRequired();
            modelBuilder.Entity<DsTreeResultPave>().Property(item => item.TreeResultDsId).HasColumnName("TREE_RESULT_DS__ID");
            modelBuilder.Entity<DsTreeResultPave>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<DsTreeResultPave>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<DsTreeResultPave>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<DsTreeResultPave>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<DsTreeResultPave>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<DsTreeResultPave>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<DsTreeResultPave>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<DsTreeResultPave>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<DsTreeResultPave>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<DsTreeResultPave>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<DsTreeResultPave>().Property(item => item.Technique).IsRequired();
            modelBuilder.Entity<DsTreeResultPave>().Property(item => item.Technique).HasMaxLength(25);
            modelBuilder.Entity<DsTreeResultPave>().Property(item => item.Technique).HasColumnName("TECHNIQUE");
            modelBuilder.Entity<DsTreeResultPaveVoie>().ToTable("TREE_RESULT_PAVE_VOIE_DS","DS");
            modelBuilder.Entity<DsTreeResultPaveVoie>().HasKey(item => new {item.TreeDsId,item.TreeResultDsId,item.TreeResultPaveDsLiaison,item.TreeResultPaveDsSens,item.TreeResultPaveDsAbsDeb,item.Voie });
            modelBuilder.Entity<DsTreeResultPaveVoie>().Property(item => item.TreeDsId).IsRequired();
            modelBuilder.Entity<DsTreeResultPaveVoie>().Property(item => item.TreeDsId).HasColumnName("TREE_DS__ID");
            modelBuilder.Entity<DsTreeResultPaveVoie>().Property(item => item.TreeResultDsId).IsRequired();
            modelBuilder.Entity<DsTreeResultPaveVoie>().Property(item => item.TreeResultDsId).HasColumnName("TREE_RESULT_DS__ID");
            modelBuilder.Entity<DsTreeResultPaveVoie>().Property(item => item.TreeResultPaveDsLiaison).IsRequired();
            modelBuilder.Entity<DsTreeResultPaveVoie>().Property(item => item.TreeResultPaveDsLiaison).HasMaxLength(15);
            modelBuilder.Entity<DsTreeResultPaveVoie>().Property(item => item.TreeResultPaveDsLiaison).HasColumnName("TREE_RESULT_PAVE_DS__LIAISON");
            modelBuilder.Entity<DsTreeResultPaveVoie>().Property(item => item.TreeResultPaveDsSens).IsRequired();
            modelBuilder.Entity<DsTreeResultPaveVoie>().Property(item => item.TreeResultPaveDsSens).HasMaxLength(6);
            modelBuilder.Entity<DsTreeResultPaveVoie>().Property(item => item.TreeResultPaveDsSens).HasColumnName("TREE_RESULT_PAVE_DS__SENS");
            modelBuilder.Entity<DsTreeResultPaveVoie>().Property(item => item.TreeResultPaveDsAbsDeb).IsRequired();
            modelBuilder.Entity<DsTreeResultPaveVoie>().Property(item => item.TreeResultPaveDsAbsDeb).HasColumnName("TREE_RESULT_PAVE_DS__ABS_DEB");
            modelBuilder.Entity<DsTreeResultPaveVoie>().Property(item => item.Voie).IsRequired();
            modelBuilder.Entity<DsTreeResultPaveVoie>().Property(item => item.Voie).HasMaxLength(6);
            modelBuilder.Entity<DsTreeResultPaveVoie>().Property(item => item.Voie).HasColumnName("VOIE");
            modelBuilder.Entity<DsTreeResultPaveVoie>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<DsTreeResultPaveVoie>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<DsTreeResultPaveVoie>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<DsTreeResultPaveVoie>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<DsTreeResult>().ToTable("TREE_RESULT_DS","DS");
            modelBuilder.Entity<DsTreeResult>().HasKey(item => new {item.TreeDsId,item.Id });
            modelBuilder.Entity<DsTreeResult>().Property(item => item.TreeDsId).IsRequired();
            modelBuilder.Entity<DsTreeResult>().Property(item => item.TreeDsId).HasColumnName("TREE_DS__ID");
            modelBuilder.Entity<DsTreeResult>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<DsTreeResult>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<DsTreeResult>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<DsTreeResult>().Property(item => item.Libelle).HasMaxLength(100);
            modelBuilder.Entity<DsTreeResult>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<DsSimDvp>().ToTable("SIM_DVP_DS","DS");
            modelBuilder.Entity<DsSimDvp>().HasKey(item => new {item.Id });
            modelBuilder.Entity<DsSimDvp>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<DsSimDvp>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<DsSimDvp>().Property(item => item.SimEtudeDsId).IsRequired();
            modelBuilder.Entity<DsSimDvp>().Property(item => item.SimEtudeDsId).HasColumnName("SIM_ETUDE_DS__ID");
            modelBuilder.Entity<DsSimDvp>().Property(item => item.Libelle).HasMaxLength(100);
            modelBuilder.Entity<DsSimDvp>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<DsSimDvp>().Property(item => item.Couleur).IsRequired();
            modelBuilder.Entity<DsSimDvp>().Property(item => item.Couleur).HasMaxLength(12);
            modelBuilder.Entity<DsSimDvp>().Property(item => item.Couleur).HasColumnName("COULEUR");
            modelBuilder.Entity<DsSimRec>().ToTable("SIM_REC_DS","DS");
            modelBuilder.Entity<DsSimRec>().HasKey(item => new {item.Id });
            modelBuilder.Entity<DsSimRec>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<DsSimRec>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<DsSimRec>().Property(item => item.SimEtudeDsId).IsRequired();
            modelBuilder.Entity<DsSimRec>().Property(item => item.SimEtudeDsId).HasColumnName("SIM_ETUDE_DS__ID");
            modelBuilder.Entity<DsSimRec>().Property(item => item.Libelle).HasMaxLength(100);
            modelBuilder.Entity<DsSimRec>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<DsSimRec>().Property(item => item.Couleur).IsRequired();
            modelBuilder.Entity<DsSimRec>().Property(item => item.Couleur).HasMaxLength(12);
            modelBuilder.Entity<DsSimRec>().Property(item => item.Couleur).HasColumnName("COULEUR");
            modelBuilder.Entity<DsSimRec>().Property(item => item.DurreeService).IsRequired();
            modelBuilder.Entity<DsSimRec>().Property(item => item.DurreeService).HasColumnName("DURREE_SERVICE");
            modelBuilder.Entity<DsSimFis>().ToTable("SIM_FIS_DS","DS");
            modelBuilder.Entity<DsSimFis>().HasKey(item => new {item.Id });
            modelBuilder.Entity<DsSimFis>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<DsSimFis>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<DsSimFis>().Property(item => item.SimEtudeDsId).IsRequired();
            modelBuilder.Entity<DsSimFis>().Property(item => item.SimEtudeDsId).HasColumnName("SIM_ETUDE_DS__ID");
            modelBuilder.Entity<DsSimFis>().Property(item => item.Libelle).HasMaxLength(100);
            modelBuilder.Entity<DsSimFis>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<DsSimFis>().Property(item => item.Couleur).IsRequired();
            modelBuilder.Entity<DsSimFis>().Property(item => item.Couleur).HasMaxLength(12);
            modelBuilder.Entity<DsSimFis>().Property(item => item.Couleur).HasColumnName("COULEUR");
            modelBuilder.Entity<DsSimFisClasse>().ToTable("SIM_FIS_CLASSE_DS","DS");
            modelBuilder.Entity<DsSimFisClasse>().HasKey(item => new {item.SimFisDsId,item.Id });
            modelBuilder.Entity<DsSimFisClasse>().Property(item => item.SimFisDsId).IsRequired();
            modelBuilder.Entity<DsSimFisClasse>().Property(item => item.SimFisDsId).HasColumnName("SIM_FIS_DS__ID");
            modelBuilder.Entity<DsSimFisClasse>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<DsSimFisClasse>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<DsSimFisClasse>().Property(item => item.Couleur).IsRequired();
            modelBuilder.Entity<DsSimFisClasse>().Property(item => item.Couleur).HasMaxLength(12);
            modelBuilder.Entity<DsSimFisClasse>().Property(item => item.Couleur).HasColumnName("COULEUR");
            modelBuilder.Entity<DsSimFisClasse>().Property(item => item.PercentMin).IsRequired();
            modelBuilder.Entity<DsSimFisClasse>().Property(item => item.PercentMin).HasColumnName("PERCENT_MIN");
            modelBuilder.Entity<DsSimFisClasse>().Property(item => item.PercentMax).IsRequired();
            modelBuilder.Entity<DsSimFisClasse>().Property(item => item.PercentMax).HasColumnName("PERCENT_MAX");
            modelBuilder.Entity<DsSimRecValues>().ToTable("SIM_REC_VALUES_DS","DS");
            modelBuilder.Entity<DsSimRecValues>().HasKey(item => new {item.SimRecDsId,item.Annee });
            modelBuilder.Entity<DsSimRecValues>().Property(item => item.SimRecDsId).IsRequired();
            modelBuilder.Entity<DsSimRecValues>().Property(item => item.SimRecDsId).HasColumnName("SIM_REC_DS__ID");
            modelBuilder.Entity<DsSimRecValues>().Property(item => item.Annee).IsRequired();
            modelBuilder.Entity<DsSimRecValues>().Property(item => item.Annee).HasColumnName("ANNEE");
            modelBuilder.Entity<DsSimRecValues>().Property(item => item.Valeur).IsRequired();
            modelBuilder.Entity<DsSimRecValues>().Property(item => item.Valeur).HasColumnName("VALEUR");
            modelBuilder.Entity<DsSimDvpValues>().ToTable("SIM_DVP_VALUES_DS","DS");
            modelBuilder.Entity<DsSimDvpValues>().HasKey(item => new {item.SimDvpDsId,item.Annee });
            modelBuilder.Entity<DsSimDvpValues>().Property(item => item.SimDvpDsId).IsRequired();
            modelBuilder.Entity<DsSimDvpValues>().Property(item => item.SimDvpDsId).HasColumnName("SIM_DVP_DS__ID");
            modelBuilder.Entity<DsSimDvpValues>().Property(item => item.Annee).IsRequired();
            modelBuilder.Entity<DsSimDvpValues>().Property(item => item.Annee).HasColumnName("ANNEE");
            modelBuilder.Entity<DsSimDvpValues>().Property(item => item.Valeur).IsRequired();
            modelBuilder.Entity<DsSimDvpValues>().Property(item => item.Valeur).HasColumnName("VALEUR");
            modelBuilder.Entity<DsSimFisValues>().ToTable("SIM_FIS_VALUES_DS","DS");
            modelBuilder.Entity<DsSimFisValues>().HasKey(item => new {item.SimFisDsId,item.SimFisClasseDsId,item.Annee });
            modelBuilder.Entity<DsSimFisValues>().Property(item => item.SimFisDsId).IsRequired();
            modelBuilder.Entity<DsSimFisValues>().Property(item => item.SimFisDsId).HasColumnName("SIM_FIS_DS__ID");
            modelBuilder.Entity<DsSimFisValues>().Property(item => item.SimFisClasseDsId).IsRequired();
            modelBuilder.Entity<DsSimFisValues>().Property(item => item.SimFisClasseDsId).HasColumnName("SIM_FIS_CLASSE_DS__ID");
            modelBuilder.Entity<DsSimFisValues>().Property(item => item.Annee).IsRequired();
            modelBuilder.Entity<DsSimFisValues>().Property(item => item.Annee).HasColumnName("ANNEE");
            modelBuilder.Entity<DsSimFisValues>().Property(item => item.Valeur).IsRequired();
            modelBuilder.Entity<DsSimFisValues>().Property(item => item.Valeur).HasColumnName("VALEUR");
            modelBuilder.Entity<DsSimCalculTrafic>().ToTable("SIM_CALCUL_TRAFIC_DS","DS");
            modelBuilder.Entity<DsSimCalculTrafic>().HasKey(item => new {item.Id });
            modelBuilder.Entity<DsSimCalculTrafic>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<DsSimCalculTrafic>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<DsSimCalculTrafic>().Property(item => item.SimCalculDsId).IsRequired();
            modelBuilder.Entity<DsSimCalculTrafic>().Property(item => item.SimCalculDsId).HasColumnName("SIM_CALCUL_DS__ID");
            modelBuilder.Entity<DsSimCalculTrafic>().Property(item => item.SimEntretienDsId).HasColumnName("SIM_ENTRETIEN_DS__ID");
            modelBuilder.Entity<DsSimCalculTrafic>().Property(item => item.SimDvpDsId).HasColumnName("SIM_DVP_DS__ID");
            modelBuilder.Entity<DsSimCalculTrafic>().Property(item => item.SimRecDsId).HasColumnName("SIM_REC_DS__ID");
            modelBuilder.Entity<DsSimCalculTrafic>().Property(item => item.Trafic).IsRequired();
            modelBuilder.Entity<DsSimCalculTrafic>().Property(item => item.Trafic).HasMaxLength(10);
            modelBuilder.Entity<DsSimCalculTrafic>().Property(item => item.Trafic).HasColumnName("TRAFIC");
            modelBuilder.Entity<DsSimResult>().ToTable("SIM_RESULT_DS","DS");
            modelBuilder.Entity<DsSimResult>().HasKey(item => new {item.SimCalculTraficDsId,item.SimFisDsId,item.Liaison,item.Sens,item.AbsDeb,item.Annee });
            modelBuilder.Entity<DsSimResult>().Property(item => item.SimCalculTraficDsId).IsRequired();
            modelBuilder.Entity<DsSimResult>().Property(item => item.SimCalculTraficDsId).HasColumnName("SIM_CALCUL_TRAFIC_DS__ID");
            modelBuilder.Entity<DsSimResult>().Property(item => item.SimFisDsId).IsRequired();
            modelBuilder.Entity<DsSimResult>().Property(item => item.SimFisDsId).HasColumnName("SIM_FIS_DS__ID");
            modelBuilder.Entity<DsSimResult>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<DsSimResult>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<DsSimResult>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<DsSimResult>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<DsSimResult>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<DsSimResult>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<DsSimResult>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<DsSimResult>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<DsSimResult>().Property(item => item.Annee).IsRequired();
            modelBuilder.Entity<DsSimResult>().Property(item => item.Annee).HasColumnName("ANNEE");
            modelBuilder.Entity<DsSimResult>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<DsSimResult>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<DsSimResult>().Property(item => item.Dvr).IsRequired();
            modelBuilder.Entity<DsSimResult>().Property(item => item.Dvr).HasColumnName("DVR");
            modelBuilder.Entity<DsSimResult>().Property(item => item.Fis).IsRequired();
            modelBuilder.Entity<DsSimResult>().Property(item => item.Fis).HasColumnName("FIS");
            modelBuilder.Entity<DsSimResult>().Property(item => item.Lineaire).IsRequired();
            modelBuilder.Entity<DsSimResult>().Property(item => item.Lineaire).HasColumnName("LINEAIRE");
            modelBuilder.Entity<DsSimResult>().Property(item => item.Surface).IsRequired();
            modelBuilder.Entity<DsSimResult>().Property(item => item.Surface).HasColumnName("SURFACE");
            modelBuilder.Entity<DsSimResult>().Property(item => item.Epaisseur).IsRequired();
            modelBuilder.Entity<DsSimResult>().Property(item => item.Epaisseur).HasColumnName("EPAISSEUR");
            modelBuilder.Entity<DsSimCalculFis>().ToTable("SIM_CALCUL_FIS_DS","DS");
            modelBuilder.Entity<DsSimCalculFis>().HasKey(item => new {item.SimCalculTraficDsId,item.SimFisDsId });
            modelBuilder.Entity<DsSimCalculFis>().Property(item => item.SimCalculTraficDsId).IsRequired();
            modelBuilder.Entity<DsSimCalculFis>().Property(item => item.SimCalculTraficDsId).HasColumnName("SIM_CALCUL_TRAFIC_DS__ID");
            modelBuilder.Entity<DsSimCalculFis>().Property(item => item.SimFisDsId).IsRequired();
            modelBuilder.Entity<DsSimCalculFis>().Property(item => item.SimFisDsId).HasColumnName("SIM_FIS_DS__ID");
            modelBuilder.Entity<DsSimEntretien>().ToTable("SIM_ENTRETIEN_DS","DS");
            modelBuilder.Entity<DsSimEntretien>().HasKey(item => new {item.Id });
            modelBuilder.Entity<DsSimEntretien>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<DsSimEntretien>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<DsSimEntretien>().Property(item => item.SimEtudeDsId).IsRequired();
            modelBuilder.Entity<DsSimEntretien>().Property(item => item.SimEtudeDsId).HasColumnName("SIM_ETUDE_DS__ID");
            modelBuilder.Entity<DsSimEntretien>().Property(item => item.Age).IsRequired();
            modelBuilder.Entity<DsSimEntretien>().Property(item => item.Age).HasColumnName("AGE");
            modelBuilder.Entity<DsSimEntretien>().Property(item => item.Epaisseur).HasColumnName("EPAISSEUR");
            modelBuilder.Entity<DsSimEntretien>().Property(item => item.Libelle).HasMaxLength(100);
            modelBuilder.Entity<DsSimEntretien>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<DsSimEntretien>().Property(item => item.Couleur).IsRequired();
            modelBuilder.Entity<DsSimEntretien>().Property(item => item.Couleur).HasMaxLength(12);
            modelBuilder.Entity<DsSimEntretien>().Property(item => item.Couleur).HasColumnName("COULEUR");
            modelBuilder.Entity<DsSimEtude>().ToTable("SIM_ETUDE_DS","DS");
            modelBuilder.Entity<DsSimEtude>().HasKey(item => new {item.Id });
            modelBuilder.Entity<DsSimEtude>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<DsSimEtude>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<DsSimEtude>().Property(item => item.Libelle).HasMaxLength(100);
            modelBuilder.Entity<DsSimEtude>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<DsSimEtude>().Property(item => item.AnneeMin).IsRequired();
            modelBuilder.Entity<DsSimEtude>().Property(item => item.AnneeMin).HasColumnName("ANNEE_MIN");
            modelBuilder.Entity<DsSimEtude>().Property(item => item.AnneeMax).IsRequired();
            modelBuilder.Entity<DsSimEtude>().Property(item => item.AnneeMax).HasColumnName("ANNEE_MAX");
            modelBuilder.Entity<DsSimEtude>().Property(item => item.AnneeMinCalcul).IsRequired();
            modelBuilder.Entity<DsSimEtude>().Property(item => item.AnneeMinCalcul).HasColumnName("ANNEE_MIN_CALCUL");
            modelBuilder.Entity<DsSimEtude>().Property(item => item.AnneeMaxCalcul).IsRequired();
            modelBuilder.Entity<DsSimEtude>().Property(item => item.AnneeMaxCalcul).HasColumnName("ANNEE_MAX_CALCUL");
            modelBuilder.Entity<DsSimCalcul>().ToTable("SIM_CALCUL_DS","DS");
            modelBuilder.Entity<DsSimCalcul>().HasKey(item => new {item.Id });
            modelBuilder.Entity<DsSimCalcul>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<DsSimCalcul>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<DsSimCalcul>().Property(item => item.SimEtudeDsId).IsRequired();
            modelBuilder.Entity<DsSimCalcul>().Property(item => item.SimEtudeDsId).HasColumnName("SIM_ETUDE_DS__ID");
            modelBuilder.Entity<DsSimCalcul>().Property(item => item.Libelle).HasMaxLength(100);
            modelBuilder.Entity<DsSimCalcul>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<DsSimCalcul>().Property(item => item.Comment).HasMaxLength(2000);
            modelBuilder.Entity<DsSimCalcul>().Property(item => item.Comment).HasColumnName("COMMENT");
            modelBuilder.Entity<DsTraficColor>().ToTable("TRAFIC_COLOR_DS","DS");
            modelBuilder.Entity<DsTraficColor>().HasKey(item => new {item.Code });
            modelBuilder.Entity<DsTraficColor>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<DsTraficColor>().Property(item => item.Code).HasMaxLength(10);
            modelBuilder.Entity<DsTraficColor>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<DsTraficColor>().Property(item => item.Color).HasMaxLength(11);
            modelBuilder.Entity<DsTraficColor>().Property(item => item.Color).HasColumnName("COLOR");
            modelBuilder.Entity<DsAgrege>().ToTable("AGREGE_DS","DS");
            modelBuilder.Entity<DsAgrege>().HasKey(item => new {item.Code });
            modelBuilder.Entity<DsAgrege>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<DsAgrege>().Property(item => item.Code).HasMaxLength(15);
            modelBuilder.Entity<DsAgrege>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<DsAgrege>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<DsAgrege>().Property(item => item.Libelle).HasMaxLength(200);
            modelBuilder.Entity<DsAgrege>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<DsAgrege>().Property(item => item.SrcAgr).HasMaxLength(15);
            modelBuilder.Entity<DsAgrege>().Property(item => item.SrcAgr).HasColumnName("SRC_AGR");
            modelBuilder.Entity<DsAgrege>().Property(item => item.SrcIndic).HasMaxLength(15);
            modelBuilder.Entity<DsAgrege>().Property(item => item.SrcIndic).HasColumnName("SRC_INDIC");
            modelBuilder.Entity<DsAgrege>().Property(item => item.Seuil1).HasColumnName("SEUIL1");
            modelBuilder.Entity<DsAgrege>().Property(item => item.Seuil2).HasColumnName("SEUIL2");
            modelBuilder.Entity<DsAgrege>().Property(item => item.Seuil3).HasColumnName("SEUIL3");
            modelBuilder.Entity<DsAgrege>().Property(item => item.Seuil4).HasColumnName("SEUIL4");
            modelBuilder.Entity<DsAgrege>().Property(item => item.ValeurSens).HasMaxLength(2);
            modelBuilder.Entity<DsAgrege>().Property(item => item.ValeurSens).HasColumnName("VALEUR_SENS");
            modelBuilder.Entity<DsAgrege>().Property(item => item.ValeurAbs).HasColumnName("VALEUR_ABS");
            modelBuilder.Entity<EqpCdTypeSv>().ToTable("CD_TYPE_SV_EQP","EQP");
            modelBuilder.Entity<EqpCdTypeSv>().HasKey(item => new {item.CdFamSvEqpFamille,item.Type });
            modelBuilder.Entity<EqpCdTypeSv>().Property(item => item.CdFamSvEqpFamille).IsRequired();
            modelBuilder.Entity<EqpCdTypeSv>().Property(item => item.CdFamSvEqpFamille).HasMaxLength(6);
            modelBuilder.Entity<EqpCdTypeSv>().Property(item => item.CdFamSvEqpFamille).HasColumnName("CD_FAM_SV_EQP__FAMILLE");
            modelBuilder.Entity<EqpCdTypeSv>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<EqpCdTypeSv>().Property(item => item.Type).HasMaxLength(12);
            modelBuilder.Entity<EqpCdTypeSv>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<EqpCdTypeSv>().Property(item => item.Libelle).HasMaxLength(500);
            modelBuilder.Entity<EqpCdTypeSv>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<EqpCdFamSv>().ToTable("CD_FAM_SV_EQP","EQP");
            modelBuilder.Entity<EqpCdFamSv>().HasKey(item => new {item.Famille });
            modelBuilder.Entity<EqpCdFamSv>().Property(item => item.Famille).IsRequired();
            modelBuilder.Entity<EqpCdFamSv>().Property(item => item.Famille).HasMaxLength(6);
            modelBuilder.Entity<EqpCdFamSv>().Property(item => item.Famille).HasColumnName("FAMILLE");
            modelBuilder.Entity<EqpCdFamSv>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<EqpCdFamSv>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<EqpCls>().ToTable("CLS_EQP","EQP");
            modelBuilder.Entity<EqpCls>().HasKey(item => new {item.Id });
            modelBuilder.Entity<EqpCls>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<EqpCls>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<EqpCls>().Property(item => item.TableName).IsRequired();
            modelBuilder.Entity<EqpCls>().Property(item => item.TableName).HasMaxLength(30);
            modelBuilder.Entity<EqpCls>().Property(item => item.TableName).HasColumnName("TABLE_NAME");
            modelBuilder.Entity<EqpCls>().Property(item => item.KeyValue).IsRequired();
            modelBuilder.Entity<EqpCls>().Property(item => item.KeyValue).HasMaxLength(1000);
            modelBuilder.Entity<EqpCls>().Property(item => item.KeyValue).HasColumnName("KEY_VALUE");
            modelBuilder.Entity<EqpDoc>().ToTable("DOC_EQP","EQP");
            modelBuilder.Entity<EqpDoc>().HasKey(item => new {item.Id });
            modelBuilder.Entity<EqpDoc>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<EqpDoc>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<EqpDoc>().Property(item => item.CdDocEqpCode).IsRequired();
            modelBuilder.Entity<EqpDoc>().Property(item => item.CdDocEqpCode).HasMaxLength(15);
            modelBuilder.Entity<EqpDoc>().Property(item => item.CdDocEqpCode).HasColumnName("CD_DOC_EQP__CODE");
            modelBuilder.Entity<EqpDoc>().Property(item => item.Libelle).HasMaxLength(100);
            modelBuilder.Entity<EqpDoc>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<EqpDoc>().Property(item => item.Ref).IsRequired();
            modelBuilder.Entity<EqpDoc>().Property(item => item.Ref).HasMaxLength(50);
            modelBuilder.Entity<EqpDoc>().Property(item => item.Ref).HasColumnName("REF");
            modelBuilder.Entity<EqpCdDoc>().ToTable("CD_DOC_EQP","EQP");
            modelBuilder.Entity<EqpCdDoc>().HasKey(item => new {item.Code });
            modelBuilder.Entity<EqpCdDoc>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<EqpCdDoc>().Property(item => item.Code).HasMaxLength(15);
            modelBuilder.Entity<EqpCdDoc>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<EqpCdDoc>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<EqpCdDoc>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<EqpCdDoc>().Property(item => item.Path).HasMaxLength(255);
            modelBuilder.Entity<EqpCdDoc>().Property(item => item.Path).HasColumnName("PATH");
            modelBuilder.Entity<EqpNatureTrav>().ToTable("NATURE_TRAV_EQP","EQP");
            modelBuilder.Entity<EqpNatureTrav>().HasKey(item => new {item.CdTravauxEqpCode,item.Nature });
            modelBuilder.Entity<EqpNatureTrav>().Property(item => item.CdTravauxEqpCode).IsRequired();
            modelBuilder.Entity<EqpNatureTrav>().Property(item => item.CdTravauxEqpCode).HasMaxLength(60);
            modelBuilder.Entity<EqpNatureTrav>().Property(item => item.CdTravauxEqpCode).HasColumnName("CD_TRAVAUX_EQP__CODE");
            modelBuilder.Entity<EqpNatureTrav>().Property(item => item.Nature).IsRequired();
            modelBuilder.Entity<EqpNatureTrav>().Property(item => item.Nature).HasMaxLength(100);
            modelBuilder.Entity<EqpNatureTrav>().Property(item => item.Nature).HasColumnName("NATURE");
            modelBuilder.Entity<EqpSysUser>().ToTable("SYS_USER_EQP","EQP");
            modelBuilder.Entity<EqpSysUser>().HasKey(item => new {item.CodeDbs,item.CodeTable,item.CodeColonne,item.NomUser,item.CodePrp });
            modelBuilder.Entity<EqpSysUser>().Property(item => item.CodeDbs).IsRequired();
            modelBuilder.Entity<EqpSysUser>().Property(item => item.CodeDbs).HasMaxLength(50);
            modelBuilder.Entity<EqpSysUser>().Property(item => item.CodeDbs).HasColumnName("CODE_DBS");
            modelBuilder.Entity<EqpSysUser>().Property(item => item.CodeTable).IsRequired();
            modelBuilder.Entity<EqpSysUser>().Property(item => item.CodeTable).HasMaxLength(100);
            modelBuilder.Entity<EqpSysUser>().Property(item => item.CodeTable).HasColumnName("CODE_TABLE");
            modelBuilder.Entity<EqpSysUser>().Property(item => item.CodeColonne).IsRequired();
            modelBuilder.Entity<EqpSysUser>().Property(item => item.CodeColonne).HasMaxLength(100);
            modelBuilder.Entity<EqpSysUser>().Property(item => item.CodeColonne).HasColumnName("CODE_COLONNE");
            modelBuilder.Entity<EqpSysUser>().Property(item => item.NomUser).IsRequired();
            modelBuilder.Entity<EqpSysUser>().Property(item => item.NomUser).HasMaxLength(150);
            modelBuilder.Entity<EqpSysUser>().Property(item => item.NomUser).HasColumnName("NOM_USER");
            modelBuilder.Entity<EqpSysUser>().Property(item => item.CodePrp).IsRequired();
            modelBuilder.Entity<EqpSysUser>().Property(item => item.CodePrp).HasMaxLength(255);
            modelBuilder.Entity<EqpSysUser>().Property(item => item.CodePrp).HasColumnName("CODE_PRP");
            modelBuilder.Entity<EqpSysUser>().Property(item => item.ValPrp).IsRequired();
            modelBuilder.Entity<EqpSysUser>().Property(item => item.ValPrp).HasMaxLength(500);
            modelBuilder.Entity<EqpSysUser>().Property(item => item.ValPrp).HasColumnName("VAL_PRP");
            modelBuilder.Entity<EqpBpu>().ToTable("BPU_EQP","EQP");
            modelBuilder.Entity<EqpBpu>().HasKey(item => new {item.Techn });
            modelBuilder.Entity<EqpBpu>().Property(item => item.Techn).IsRequired();
            modelBuilder.Entity<EqpBpu>().Property(item => item.Techn).HasMaxLength(250);
            modelBuilder.Entity<EqpBpu>().Property(item => item.Techn).HasColumnName("TECHN");
            modelBuilder.Entity<EqpBpu>().Property(item => item.CdTravauxEqpCode).IsRequired();
            modelBuilder.Entity<EqpBpu>().Property(item => item.CdTravauxEqpCode).HasMaxLength(60);
            modelBuilder.Entity<EqpBpu>().Property(item => item.CdTravauxEqpCode).HasColumnName("CD_TRAVAUX_EQP__CODE");
            modelBuilder.Entity<EqpBpu>().Property(item => item.Prix).IsRequired();
            modelBuilder.Entity<EqpBpu>().Property(item => item.Prix).HasColumnName("PRIX");
            modelBuilder.Entity<EqpBpu>().Property(item => item.DateMaj).HasColumnName("DATE_MAJ");
            modelBuilder.Entity<EqpBpu>().Property(item => item.Freq).HasColumnName("FREQ");
            modelBuilder.Entity<EqpCdTravaux>().ToTable("CD_TRAVAUX_EQP","EQP");
            modelBuilder.Entity<EqpCdTravaux>().HasKey(item => new {item.Code });
            modelBuilder.Entity<EqpCdTravaux>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<EqpCdTravaux>().Property(item => item.Code).HasMaxLength(60);
            modelBuilder.Entity<EqpCdTravaux>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<EqpCdStypeSv>().ToTable("CD_STYPE_SV_EQP","EQP");
            modelBuilder.Entity<EqpCdStypeSv>().HasKey(item => new {item.CdFamSvEqpFamille,item.CdTypeSvEqpType,item.SType });
            modelBuilder.Entity<EqpCdStypeSv>().Property(item => item.CdFamSvEqpFamille).IsRequired();
            modelBuilder.Entity<EqpCdStypeSv>().Property(item => item.CdFamSvEqpFamille).HasMaxLength(6);
            modelBuilder.Entity<EqpCdStypeSv>().Property(item => item.CdFamSvEqpFamille).HasColumnName("CD_FAM_SV_EQP__FAMILLE");
            modelBuilder.Entity<EqpCdStypeSv>().Property(item => item.CdTypeSvEqpType).IsRequired();
            modelBuilder.Entity<EqpCdStypeSv>().Property(item => item.CdTypeSvEqpType).HasMaxLength(12);
            modelBuilder.Entity<EqpCdStypeSv>().Property(item => item.CdTypeSvEqpType).HasColumnName("CD_TYPE_SV_EQP__TYPE");
            modelBuilder.Entity<EqpCdStypeSv>().Property(item => item.SType).IsRequired();
            modelBuilder.Entity<EqpCdStypeSv>().Property(item => item.SType).HasMaxLength(60);
            modelBuilder.Entity<EqpCdStypeSv>().Property(item => item.SType).HasColumnName("S_TYPE");
            modelBuilder.Entity<EqpCdStypeSv>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<EqpCdStypeSv>().Property(item => item.Libelle).HasMaxLength(500);
            modelBuilder.Entity<EqpCdStypeSv>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<EqpCdStypeSv>().Property(item => item.NOrdre).IsRequired();
            modelBuilder.Entity<EqpCdStypeSv>().Property(item => item.NOrdre).HasColumnName("N_ORDRE");
            modelBuilder.Entity<EqpDictionnaire>().ToTable("DICTIONNAIRE_EQP","EQP");
            modelBuilder.Entity<EqpDictionnaire>().HasKey(item => new {item.Nom });
            modelBuilder.Entity<EqpDictionnaire>().Property(item => item.Nom).IsRequired();
            modelBuilder.Entity<EqpDictionnaire>().Property(item => item.Nom).HasMaxLength(100);
            modelBuilder.Entity<EqpDictionnaire>().Property(item => item.Nom).HasColumnName("NOM");
            modelBuilder.Entity<EqpDictionnaire>().Property(item => item.Description).HasMaxLength(255);
            modelBuilder.Entity<EqpDictionnaire>().Property(item => item.Description).HasColumnName("DESCRIPTION");
            modelBuilder.Entity<EqpDictionnaire>().Property(item => item.Definition).HasMaxLength(1000);
            modelBuilder.Entity<EqpDictionnaire>().Property(item => item.Definition).HasColumnName("DEFINITION");
            modelBuilder.Entity<EqpDictionnaire>().Property(item => item.Motscles).HasMaxLength(255);
            modelBuilder.Entity<EqpDictionnaire>().Property(item => item.Motscles).HasColumnName("MOTSCLES");
            modelBuilder.Entity<EqpCdEvt>().ToTable("CD_EVT_EQP","EQP");
            modelBuilder.Entity<EqpCdEvt>().HasKey(item => new {item.Type });
            modelBuilder.Entity<EqpCdEvt>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<EqpCdEvt>().Property(item => item.Type).HasMaxLength(25);
            modelBuilder.Entity<EqpCdEvt>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<EqpCdEvt>().Property(item => item.Impact).HasColumnName("IMPACT");
            modelBuilder.Entity<EqpDscSv>().ToTable("DSC_SV_EQP","EQP");
            modelBuilder.Entity<EqpDscSv>().HasKey(item => new {item.CdPositEqpPosit,item.NumExploit });
            modelBuilder.Entity<EqpDscSv>().Property(item => item.CdPositEqpPosit).IsRequired();
            modelBuilder.Entity<EqpDscSv>().Property(item => item.CdPositEqpPosit).HasMaxLength(60);
            modelBuilder.Entity<EqpDscSv>().Property(item => item.CdPositEqpPosit).HasColumnName("CD_POSIT_EQP__POSIT");
            modelBuilder.Entity<EqpDscSv>().Property(item => item.NumExploit).IsRequired();
            modelBuilder.Entity<EqpDscSv>().Property(item => item.NumExploit).HasMaxLength(30);
            modelBuilder.Entity<EqpDscSv>().Property(item => item.NumExploit).HasColumnName("NUM_EXPLOIT");
            modelBuilder.Entity<EqpDscSv>().Property(item => item.CdFondationEqpFondation).HasMaxLength(60);
            modelBuilder.Entity<EqpDscSv>().Property(item => item.CdFondationEqpFondation).HasColumnName("CD_FONDATION_EQP__FONDATION");
            modelBuilder.Entity<EqpDscSv>().Property(item => item.CdEntpEqpEntreprise).HasMaxLength(60);
            modelBuilder.Entity<EqpDscSv>().Property(item => item.CdEntpEqpEntreprise).HasColumnName("CD_ENTP_EQP__ENTREPRISE");
            modelBuilder.Entity<EqpDscSv>().Property(item => item.CdSupportSvEqpSupport).HasMaxLength(60);
            modelBuilder.Entity<EqpDscSv>().Property(item => item.CdSupportSvEqpSupport).HasColumnName("CD_SUPPORT_SV_EQP__SUPPORT");
            modelBuilder.Entity<EqpDscSv>().Property(item => item.CdProtectEqpProtect).HasMaxLength(60);
            modelBuilder.Entity<EqpDscSv>().Property(item => item.CdProtectEqpProtect).HasColumnName("CD_PROTECT_EQP__PROTECT");
            modelBuilder.Entity<EqpDscSv>().Property(item => item.CdFamSvEqpFamille).IsRequired();
            modelBuilder.Entity<EqpDscSv>().Property(item => item.CdFamSvEqpFamille).HasMaxLength(6);
            modelBuilder.Entity<EqpDscSv>().Property(item => item.CdFamSvEqpFamille).HasColumnName("CD_FAM_SV_EQP__FAMILLE");
            modelBuilder.Entity<EqpDscSv>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<EqpDscSv>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<EqpDscSv>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<EqpDscSv>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<EqpDscSv>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<EqpDscSv>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<EqpDscSv>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<EqpDscSv>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<EqpDscSv>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<EqpDscSv>().Property(item => item.Massif).HasMaxLength(20);
            modelBuilder.Entity<EqpDscSv>().Property(item => item.Massif).HasColumnName("MASSIF");
            modelBuilder.Entity<EqpDscSv>().Property(item => item.NbreSupport).HasColumnName("NBRE_SUPPORT");
            modelBuilder.Entity<EqpDscSv>().Property(item => item.Resist).HasColumnName("RESIST");
            modelBuilder.Entity<EqpDscSv>().Property(item => item.Eclairage).HasColumnName("ECLAIRAGE");
            modelBuilder.Entity<EqpDscSv>().Property(item => item.Accessibilite).HasColumnName("ACCESSIBILITE");
            modelBuilder.Entity<EqpDscSv>().Property(item => item.HauteurSp).HasColumnName("HAUTEUR_SP");
            modelBuilder.Entity<EqpDscSv>().Property(item => item.Commentaire).HasMaxLength(255);
            modelBuilder.Entity<EqpDscSv>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<EqpDscSv>().Property(item => item.X1).HasColumnName("X1");
            modelBuilder.Entity<EqpDscSv>().Property(item => item.Y1).HasColumnName("Y1");
            modelBuilder.Entity<EqpDscSv>().Property(item => item.Z1).HasColumnName("Z1");
            modelBuilder.Entity<EqpDscSv>().Property(item => item.DateReleve).HasColumnName("DATE_RELEVE");
            modelBuilder.Entity<EqpDscSv>().Property(item => item.Terrain).HasColumnName("TERRAIN");
            modelBuilder.Entity<EqpCdFabricant>().ToTable("CD_FABRICANT_EQP","EQP");
            modelBuilder.Entity<EqpCdFabricant>().HasKey(item => new {item.Nom });
            modelBuilder.Entity<EqpCdFabricant>().Property(item => item.Nom).IsRequired();
            modelBuilder.Entity<EqpCdFabricant>().Property(item => item.Nom).HasMaxLength(60);
            modelBuilder.Entity<EqpCdFabricant>().Property(item => item.Nom).HasColumnName("NOM");
            modelBuilder.Entity<EqpCdProtect>().ToTable("CD_PROTECT_EQP","EQP");
            modelBuilder.Entity<EqpCdProtect>().HasKey(item => new {item.Protect });
            modelBuilder.Entity<EqpCdProtect>().Property(item => item.Protect).IsRequired();
            modelBuilder.Entity<EqpCdProtect>().Property(item => item.Protect).HasMaxLength(60);
            modelBuilder.Entity<EqpCdProtect>().Property(item => item.Protect).HasColumnName("PROTECT");
            modelBuilder.Entity<EqpCdClasseSv>().ToTable("CD_CLASSE_SV_EQP","EQP");
            modelBuilder.Entity<EqpCdClasseSv>().HasKey(item => new {item.Classe });
            modelBuilder.Entity<EqpCdClasseSv>().Property(item => item.Classe).IsRequired();
            modelBuilder.Entity<EqpCdClasseSv>().Property(item => item.Classe).HasMaxLength(5);
            modelBuilder.Entity<EqpCdClasseSv>().Property(item => item.Classe).HasColumnName("CLASSE");
            modelBuilder.Entity<EqpCdGammeSv>().ToTable("CD_GAMME_SV_EQP","EQP");
            modelBuilder.Entity<EqpCdGammeSv>().HasKey(item => new {item.Gamme });
            modelBuilder.Entity<EqpCdGammeSv>().Property(item => item.Gamme).IsRequired();
            modelBuilder.Entity<EqpCdGammeSv>().Property(item => item.Gamme).HasMaxLength(20);
            modelBuilder.Entity<EqpCdGammeSv>().Property(item => item.Gamme).HasColumnName("GAMME");
            modelBuilder.Entity<EqpCdGammeSv>().Property(item => item.Dimension).HasColumnName("DIMENSION");
            modelBuilder.Entity<EqpCdSupportSv>().ToTable("CD_SUPPORT_SV_EQP","EQP");
            modelBuilder.Entity<EqpCdSupportSv>().HasKey(item => new {item.Support });
            modelBuilder.Entity<EqpCdSupportSv>().Property(item => item.Support).IsRequired();
            modelBuilder.Entity<EqpCdSupportSv>().Property(item => item.Support).HasMaxLength(60);
            modelBuilder.Entity<EqpCdSupportSv>().Property(item => item.Support).HasColumnName("SUPPORT");
            modelBuilder.Entity<EqpCdSupportSv>().Property(item => item.Garantie).HasColumnName("GARANTIE");
            modelBuilder.Entity<EqpCdSupportSv>().Property(item => item.Dvt).HasColumnName("DVT");
            modelBuilder.Entity<EqpCdFondation>().ToTable("CD_FONDATION_EQP","EQP");
            modelBuilder.Entity<EqpCdFondation>().HasKey(item => new {item.Fondation });
            modelBuilder.Entity<EqpCdFondation>().Property(item => item.Fondation).IsRequired();
            modelBuilder.Entity<EqpCdFondation>().Property(item => item.Fondation).HasMaxLength(60);
            modelBuilder.Entity<EqpCdFondation>().Property(item => item.Fondation).HasColumnName("FONDATION");
            modelBuilder.Entity<EqpDscSh>().ToTable("DSC_SH_EQP","EQP");
            modelBuilder.Entity<EqpDscSh>().HasKey(item => new {item.CdPositEqpPosit,item.Liaison,item.AbsDeb,item.Sens });
            modelBuilder.Entity<EqpDscSh>().Property(item => item.CdPositEqpPosit).IsRequired();
            modelBuilder.Entity<EqpDscSh>().Property(item => item.CdPositEqpPosit).HasMaxLength(60);
            modelBuilder.Entity<EqpDscSh>().Property(item => item.CdPositEqpPosit).HasColumnName("CD_POSIT_EQP__POSIT");
            modelBuilder.Entity<EqpDscSh>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<EqpDscSh>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<EqpDscSh>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<EqpDscSh>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<EqpDscSh>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<EqpDscSh>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<EqpDscSh>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<EqpDscSh>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<EqpDscSh>().Property(item => item.NumExploit).HasMaxLength(30);
            modelBuilder.Entity<EqpDscSh>().Property(item => item.NumExploit).HasColumnName("NUM_EXPLOIT");
            modelBuilder.Entity<EqpDscSh>().Property(item => item.CdModShEqpMod).IsRequired();
            modelBuilder.Entity<EqpDscSh>().Property(item => item.CdModShEqpMod).HasMaxLength(6);
            modelBuilder.Entity<EqpDscSh>().Property(item => item.CdModShEqpMod).HasColumnName("CD_MOD_SH_EQP__MOD");
            modelBuilder.Entity<EqpDscSh>().Property(item => item.CdMarquageShEqpMarquage).IsRequired();
            modelBuilder.Entity<EqpDscSh>().Property(item => item.CdMarquageShEqpMarquage).HasMaxLength(255);
            modelBuilder.Entity<EqpDscSh>().Property(item => item.CdMarquageShEqpMarquage).HasColumnName("CD_MARQUAGE_SH_EQP__MARQUAGE");
            modelBuilder.Entity<EqpDscSh>().Property(item => item.CdEntpEqpEntreprise).HasMaxLength(60);
            modelBuilder.Entity<EqpDscSh>().Property(item => item.CdEntpEqpEntreprise).HasColumnName("CD_ENTP_EQP__ENTREPRISE");
            modelBuilder.Entity<EqpDscSh>().Property(item => item.CdBarretteShEqpBarette).HasMaxLength(60);
            modelBuilder.Entity<EqpDscSh>().Property(item => item.CdBarretteShEqpBarette).HasColumnName("CD_BARRETTE_SH_EQP__BARETTE");
            modelBuilder.Entity<EqpDscSh>().Property(item => item.CdProduitShEqpProduit).HasMaxLength(60);
            modelBuilder.Entity<EqpDscSh>().Property(item => item.CdProduitShEqpProduit).HasColumnName("CD_PRODUIT_SH_EQP__PRODUIT");
            modelBuilder.Entity<EqpDscSh>().Property(item => item.CdFabricantEqpNom).HasMaxLength(60);
            modelBuilder.Entity<EqpDscSh>().Property(item => item.CdFabricantEqpNom).HasColumnName("CD_FABRICANT_EQP__NOM");
            modelBuilder.Entity<EqpDscSh>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<EqpDscSh>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<EqpDscSh>().Property(item => item.RevetementVntp).HasColumnName("REVETEMENT_VNTP");
            modelBuilder.Entity<EqpDscSh>().Property(item => item.Saupoudrage).HasColumnName("SAUPOUDRAGE");
            modelBuilder.Entity<EqpDscSh>().Property(item => item.Commentaire).HasMaxLength(255);
            modelBuilder.Entity<EqpDscSh>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<EqpDscSh>().Property(item => item.X1).HasColumnName("X1");
            modelBuilder.Entity<EqpDscSh>().Property(item => item.Y1).HasColumnName("Y1");
            modelBuilder.Entity<EqpDscSh>().Property(item => item.Z1).HasColumnName("Z1");
            modelBuilder.Entity<EqpDscSh>().Property(item => item.X2).HasColumnName("X2");
            modelBuilder.Entity<EqpDscSh>().Property(item => item.Y2).HasColumnName("Y2");
            modelBuilder.Entity<EqpDscSh>().Property(item => item.Z2).HasColumnName("Z2");
            modelBuilder.Entity<EqpDscSh>().Property(item => item.DateReleve).HasColumnName("DATE_RELEVE");
            modelBuilder.Entity<EqpDscSh>().Property(item => item.Terrain).HasColumnName("TERRAIN");
            modelBuilder.Entity<EqpDscEs>().ToTable("DSC_ES_EQP","EQP");
            modelBuilder.Entity<EqpDscEs>().HasKey(item => new {item.CdPositEqpPosit,item.Liaison,item.Sens,item.AbsDeb });
            modelBuilder.Entity<EqpDscEs>().Property(item => item.CdPositEqpPosit).IsRequired();
            modelBuilder.Entity<EqpDscEs>().Property(item => item.CdPositEqpPosit).HasMaxLength(60);
            modelBuilder.Entity<EqpDscEs>().Property(item => item.CdPositEqpPosit).HasColumnName("CD_POSIT_EQP__POSIT");
            modelBuilder.Entity<EqpDscEs>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<EqpDscEs>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<EqpDscEs>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<EqpDscEs>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<EqpDscEs>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<EqpDscEs>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<EqpDscEs>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<EqpDscEs>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<EqpDscEs>().Property(item => item.NumExploit).HasMaxLength(30);
            modelBuilder.Entity<EqpDscEs>().Property(item => item.NumExploit).HasColumnName("NUM_EXPLOIT");
            modelBuilder.Entity<EqpDscEs>().Property(item => item.CdEntpEqpEntreprise).HasMaxLength(60);
            modelBuilder.Entity<EqpDscEs>().Property(item => item.CdEntpEqpEntreprise).HasColumnName("CD_ENTP_EQP__ENTREPRISE");
            modelBuilder.Entity<EqpDscEs>().Property(item => item.CdExtAvEqpExtFin).HasMaxLength(60);
            modelBuilder.Entity<EqpDscEs>().Property(item => item.CdExtAvEqpExtFin).HasColumnName("CD_EXT_AV_EQP__EXT_FIN");
            modelBuilder.Entity<EqpDscEs>().Property(item => item.CdFabricantEqpNom).HasMaxLength(60);
            modelBuilder.Entity<EqpDscEs>().Property(item => item.CdFabricantEqpNom).HasColumnName("CD_FABRICANT_EQP__NOM");
            modelBuilder.Entity<EqpDscEs>().Property(item => item.CdMateriauEqpMateriaux).IsRequired();
            modelBuilder.Entity<EqpDscEs>().Property(item => item.CdMateriauEqpMateriaux).HasMaxLength(60);
            modelBuilder.Entity<EqpDscEs>().Property(item => item.CdMateriauEqpMateriaux).HasColumnName("CD_MATERIAU_EQP__MATERIAUX");
            modelBuilder.Entity<EqpDscEs>().Property(item => item.CdRetenueEqpDispositif).IsRequired();
            modelBuilder.Entity<EqpDscEs>().Property(item => item.CdRetenueEqpDispositif).HasMaxLength(60);
            modelBuilder.Entity<EqpDscEs>().Property(item => item.CdRetenueEqpDispositif).HasColumnName("CD_RETENUE_EQP__DISPOSITIF");
            modelBuilder.Entity<EqpDscEs>().Property(item => item.CdExtAmEqpExtDeb).HasMaxLength(60);
            modelBuilder.Entity<EqpDscEs>().Property(item => item.CdExtAmEqpExtDeb).HasColumnName("CD_EXT_AM_EQP__EXT_DEB");
            modelBuilder.Entity<EqpDscEs>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<EqpDscEs>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<EqpDscEs>().Property(item => item.Commentaire).HasMaxLength(255);
            modelBuilder.Entity<EqpDscEs>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<EqpDscEs>().Property(item => item.X1).HasColumnName("X1");
            modelBuilder.Entity<EqpDscEs>().Property(item => item.Y1).HasColumnName("Y1");
            modelBuilder.Entity<EqpDscEs>().Property(item => item.Z1).HasColumnName("Z1");
            modelBuilder.Entity<EqpDscEs>().Property(item => item.X2).HasColumnName("X2");
            modelBuilder.Entity<EqpDscEs>().Property(item => item.Y2).HasColumnName("Y2");
            modelBuilder.Entity<EqpDscEs>().Property(item => item.Z2).HasColumnName("Z2");
            modelBuilder.Entity<EqpDscEs>().Property(item => item.DateReleve).HasColumnName("DATE_RELEVE");
            modelBuilder.Entity<EqpDscEs>().Property(item => item.Terrain).HasColumnName("TERRAIN");
            modelBuilder.Entity<EqpCdProduitSh>().ToTable("CD_PRODUIT_SH_EQP","EQP");
            modelBuilder.Entity<EqpCdProduitSh>().HasKey(item => new {item.Produit });
            modelBuilder.Entity<EqpCdProduitSh>().Property(item => item.Produit).IsRequired();
            modelBuilder.Entity<EqpCdProduitSh>().Property(item => item.Produit).HasMaxLength(60);
            modelBuilder.Entity<EqpCdProduitSh>().Property(item => item.Produit).HasColumnName("PRODUIT");
            modelBuilder.Entity<EqpCdProduitSh>().Property(item => item.Garantie).HasColumnName("GARANTIE");
            modelBuilder.Entity<EqpCdProduitSh>().Property(item => item.Dvt).HasColumnName("DVT");
            modelBuilder.Entity<EqpCdBarretteSh>().ToTable("CD_BARRETTE_SH_EQP","EQP");
            modelBuilder.Entity<EqpCdBarretteSh>().HasKey(item => new {item.Barette });
            modelBuilder.Entity<EqpCdBarretteSh>().Property(item => item.Barette).IsRequired();
            modelBuilder.Entity<EqpCdBarretteSh>().Property(item => item.Barette).HasMaxLength(60);
            modelBuilder.Entity<EqpCdBarretteSh>().Property(item => item.Barette).HasColumnName("BARETTE");
            modelBuilder.Entity<EqpCdMarquageSh>().ToTable("CD_MARQUAGE_SH_EQP","EQP");
            modelBuilder.Entity<EqpCdMarquageSh>().HasKey(item => new {item.CdModShEqpMod,item.Marquage });
            modelBuilder.Entity<EqpCdMarquageSh>().Property(item => item.CdModShEqpMod).IsRequired();
            modelBuilder.Entity<EqpCdMarquageSh>().Property(item => item.CdModShEqpMod).HasMaxLength(6);
            modelBuilder.Entity<EqpCdMarquageSh>().Property(item => item.CdModShEqpMod).HasColumnName("CD_MOD_SH_EQP__MOD");
            modelBuilder.Entity<EqpCdMarquageSh>().Property(item => item.Marquage).IsRequired();
            modelBuilder.Entity<EqpCdMarquageSh>().Property(item => item.Marquage).HasMaxLength(255);
            modelBuilder.Entity<EqpCdMarquageSh>().Property(item => item.Marquage).HasColumnName("MARQUAGE");
            modelBuilder.Entity<EqpCdMarquageSh>().Property(item => item.Largeur).HasColumnName("LARGEUR");
            modelBuilder.Entity<EqpCdModSh>().ToTable("CD_MOD_SH_EQP","EQP");
            modelBuilder.Entity<EqpCdModSh>().HasKey(item => new {item.Mod });
            modelBuilder.Entity<EqpCdModSh>().Property(item => item.Mod).IsRequired();
            modelBuilder.Entity<EqpCdModSh>().Property(item => item.Mod).HasMaxLength(6);
            modelBuilder.Entity<EqpCdModSh>().Property(item => item.Mod).HasColumnName("MOD");
            modelBuilder.Entity<EqpCdModSh>().Property(item => item.Libelle).HasMaxLength(500);
            modelBuilder.Entity<EqpCdModSh>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<EqpCdType>().ToTable("CD_TYPE_EQP","EQP");
            modelBuilder.Entity<EqpCdType>().HasKey(item => new {item.TypeEquip });
            modelBuilder.Entity<EqpCdType>().Property(item => item.TypeEquip).IsRequired();
            modelBuilder.Entity<EqpCdType>().Property(item => item.TypeEquip).HasMaxLength(6);
            modelBuilder.Entity<EqpCdType>().Property(item => item.TypeEquip).HasColumnName("TYPE_EQUIP");
            modelBuilder.Entity<EqpCdType>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<EqpCdType>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<EqpCdRetenue>().ToTable("CD_RETENUE_EQP","EQP");
            modelBuilder.Entity<EqpCdRetenue>().HasKey(item => new {item.CdMateriauEqpMateriaux,item.Dispositif });
            modelBuilder.Entity<EqpCdRetenue>().Property(item => item.CdMateriauEqpMateriaux).IsRequired();
            modelBuilder.Entity<EqpCdRetenue>().Property(item => item.CdMateriauEqpMateriaux).HasMaxLength(60);
            modelBuilder.Entity<EqpCdRetenue>().Property(item => item.CdMateriauEqpMateriaux).HasColumnName("CD_MATERIAU_EQP__MATERIAUX");
            modelBuilder.Entity<EqpCdRetenue>().Property(item => item.Dispositif).IsRequired();
            modelBuilder.Entity<EqpCdRetenue>().Property(item => item.Dispositif).HasMaxLength(60);
            modelBuilder.Entity<EqpCdRetenue>().Property(item => item.Dispositif).HasColumnName("DISPOSITIF");
            modelBuilder.Entity<EqpCdRetenue>().Property(item => item.Libelle).HasMaxLength(500);
            modelBuilder.Entity<EqpCdRetenue>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<EqpCdRetenue>().Property(item => item.Garantie).HasColumnName("GARANTIE");
            modelBuilder.Entity<EqpCdRetenue>().Property(item => item.Dvt).HasColumnName("DVT");
            modelBuilder.Entity<EqpCdMateriau>().ToTable("CD_MATERIAU_EQP","EQP");
            modelBuilder.Entity<EqpCdMateriau>().HasKey(item => new {item.Materiaux });
            modelBuilder.Entity<EqpCdMateriau>().Property(item => item.Materiaux).IsRequired();
            modelBuilder.Entity<EqpCdMateriau>().Property(item => item.Materiaux).HasMaxLength(60);
            modelBuilder.Entity<EqpCdMateriau>().Property(item => item.Materiaux).HasColumnName("MATERIAUX");
            modelBuilder.Entity<EqpCdExtAm>().ToTable("CD_EXT_AM_EQP","EQP");
            modelBuilder.Entity<EqpCdExtAm>().HasKey(item => new {item.ExtDeb });
            modelBuilder.Entity<EqpCdExtAm>().Property(item => item.ExtDeb).IsRequired();
            modelBuilder.Entity<EqpCdExtAm>().Property(item => item.ExtDeb).HasMaxLength(60);
            modelBuilder.Entity<EqpCdExtAm>().Property(item => item.ExtDeb).HasColumnName("EXT_DEB");
            modelBuilder.Entity<EqpCdExtAv>().ToTable("CD_EXT_AV_EQP","EQP");
            modelBuilder.Entity<EqpCdExtAv>().HasKey(item => new {item.ExtFin });
            modelBuilder.Entity<EqpCdExtAv>().Property(item => item.ExtFin).IsRequired();
            modelBuilder.Entity<EqpCdExtAv>().Property(item => item.ExtFin).HasMaxLength(60);
            modelBuilder.Entity<EqpCdExtAv>().Property(item => item.ExtFin).HasColumnName("EXT_FIN");
            modelBuilder.Entity<EqpDscPo>().ToTable("DSC_PO_EQP","EQP");
            modelBuilder.Entity<EqpDscPo>().HasKey(item => new {item.NumExploit });
            modelBuilder.Entity<EqpDscPo>().Property(item => item.NumExploit).IsRequired();
            modelBuilder.Entity<EqpDscPo>().Property(item => item.NumExploit).HasMaxLength(30);
            modelBuilder.Entity<EqpDscPo>().Property(item => item.NumExploit).HasColumnName("NUM_EXPLOIT");
            modelBuilder.Entity<EqpDscPo>().Property(item => item.CdEntpEqpEntreprise).HasMaxLength(60);
            modelBuilder.Entity<EqpDscPo>().Property(item => item.CdEntpEqpEntreprise).HasColumnName("CD_ENTP_EQP__ENTREPRISE");
            modelBuilder.Entity<EqpDscPo>().Property(item => item.CdPortailEqpPortail).IsRequired();
            modelBuilder.Entity<EqpDscPo>().Property(item => item.CdPortailEqpPortail).HasMaxLength(60);
            modelBuilder.Entity<EqpDscPo>().Property(item => item.CdPortailEqpPortail).HasColumnName("CD_PORTAIL_EQP__PORTAIL");
            modelBuilder.Entity<EqpDscPo>().Property(item => item.CdFabricantEqpNom).HasMaxLength(60);
            modelBuilder.Entity<EqpDscPo>().Property(item => item.CdFabricantEqpNom).HasColumnName("CD_FABRICANT_EQP__NOM");
            modelBuilder.Entity<EqpDscPo>().Property(item => item.CdPositEqpPosit).HasMaxLength(60);
            modelBuilder.Entity<EqpDscPo>().Property(item => item.CdPositEqpPosit).HasColumnName("CD_POSIT_EQP__POSIT");
            modelBuilder.Entity<EqpDscPo>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<EqpDscPo>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<EqpDscPo>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<EqpDscPo>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<EqpDscPo>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<EqpDscPo>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<EqpDscPo>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<EqpDscPo>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<EqpDscPo>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<EqpDscPo>().Property(item => item.Largeur).HasColumnName("LARGEUR");
            modelBuilder.Entity<EqpDscPo>().Property(item => item.Hauteur).HasColumnName("HAUTEUR");
            modelBuilder.Entity<EqpDscPo>().Property(item => item.DispoAcces).HasColumnName("DISPO_ACCES");
            modelBuilder.Entity<EqpDscPo>().Property(item => item.Commentaire).HasMaxLength(255);
            modelBuilder.Entity<EqpDscPo>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<EqpDscPo>().Property(item => item.X1).HasColumnName("X1");
            modelBuilder.Entity<EqpDscPo>().Property(item => item.Y1).HasColumnName("Y1");
            modelBuilder.Entity<EqpDscPo>().Property(item => item.Z1).HasColumnName("Z1");
            modelBuilder.Entity<EqpDscPo>().Property(item => item.DateReleve).HasColumnName("DATE_RELEVE");
            modelBuilder.Entity<EqpDscPo>().Property(item => item.Terrain).HasColumnName("TERRAIN");
            modelBuilder.Entity<EqpCdPortail>().ToTable("CD_PORTAIL_EQP","EQP");
            modelBuilder.Entity<EqpCdPortail>().HasKey(item => new {item.Portail });
            modelBuilder.Entity<EqpCdPortail>().Property(item => item.Portail).IsRequired();
            modelBuilder.Entity<EqpCdPortail>().Property(item => item.Portail).HasMaxLength(60);
            modelBuilder.Entity<EqpCdPortail>().Property(item => item.Portail).HasColumnName("PORTAIL");
            modelBuilder.Entity<EqpCdPortail>().Property(item => item.Garantie).HasColumnName("GARANTIE");
            modelBuilder.Entity<EqpCdPortail>().Property(item => item.Dvt).HasColumnName("DVT");
            modelBuilder.Entity<EqpDscCl>().ToTable("DSC_CL_EQP","EQP");
            modelBuilder.Entity<EqpDscCl>().HasKey(item => new {item.CdPositEqpPosit,item.Liaison,item.Sens,item.AbsDeb });
            modelBuilder.Entity<EqpDscCl>().Property(item => item.CdPositEqpPosit).IsRequired();
            modelBuilder.Entity<EqpDscCl>().Property(item => item.CdPositEqpPosit).HasMaxLength(60);
            modelBuilder.Entity<EqpDscCl>().Property(item => item.CdPositEqpPosit).HasColumnName("CD_POSIT_EQP__POSIT");
            modelBuilder.Entity<EqpDscCl>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<EqpDscCl>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<EqpDscCl>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<EqpDscCl>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<EqpDscCl>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<EqpDscCl>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<EqpDscCl>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<EqpDscCl>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<EqpDscCl>().Property(item => item.NumExploit).HasMaxLength(30);
            modelBuilder.Entity<EqpDscCl>().Property(item => item.NumExploit).HasColumnName("NUM_EXPLOIT");
            modelBuilder.Entity<EqpDscCl>().Property(item => item.CdFondationEqpFondation).HasMaxLength(60);
            modelBuilder.Entity<EqpDscCl>().Property(item => item.CdFondationEqpFondation).HasColumnName("CD_FONDATION_EQP__FONDATION");
            modelBuilder.Entity<EqpDscCl>().Property(item => item.CdMailleEqpMaille).HasMaxLength(60);
            modelBuilder.Entity<EqpDscCl>().Property(item => item.CdMailleEqpMaille).HasColumnName("CD_MAILLE_EQP__MAILLE");
            modelBuilder.Entity<EqpDscCl>().Property(item => item.CdEntpEqpEntreprise).HasMaxLength(60);
            modelBuilder.Entity<EqpDscCl>().Property(item => item.CdEntpEqpEntreprise).HasColumnName("CD_ENTP_EQP__ENTREPRISE");
            modelBuilder.Entity<EqpDscCl>().Property(item => item.CdFabricantEqpNom).HasMaxLength(60);
            modelBuilder.Entity<EqpDscCl>().Property(item => item.CdFabricantEqpNom).HasColumnName("CD_FABRICANT_EQP__NOM");
            modelBuilder.Entity<EqpDscCl>().Property(item => item.CdPoteauClEqpPoteaux).HasMaxLength(60);
            modelBuilder.Entity<EqpDscCl>().Property(item => item.CdPoteauClEqpPoteaux).HasColumnName("CD_POTEAU_CL_EQP__POTEAUX");
            modelBuilder.Entity<EqpDscCl>().Property(item => item.CdFranchEqpAntiFranch).HasMaxLength(60);
            modelBuilder.Entity<EqpDscCl>().Property(item => item.CdFranchEqpAntiFranch).HasColumnName("CD_FRANCH_EQP__ANTI_FRANCH");
            modelBuilder.Entity<EqpDscCl>().Property(item => item.CdClotureEqpCloture).HasMaxLength(60);
            modelBuilder.Entity<EqpDscCl>().Property(item => item.CdClotureEqpCloture).HasColumnName("CD_CLOTURE_EQP__CLOTURE");
            modelBuilder.Entity<EqpDscCl>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<EqpDscCl>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<EqpDscCl>().Property(item => item.Hauteur).HasColumnName("HAUTEUR");
            modelBuilder.Entity<EqpDscCl>().Property(item => item.Distance).HasColumnName("DISTANCE");
            modelBuilder.Entity<EqpDscCl>().Property(item => item.Commentaire).HasMaxLength(255);
            modelBuilder.Entity<EqpDscCl>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<EqpDscCl>().Property(item => item.X1).HasColumnName("X1");
            modelBuilder.Entity<EqpDscCl>().Property(item => item.Y1).HasColumnName("Y1");
            modelBuilder.Entity<EqpDscCl>().Property(item => item.Z1).HasColumnName("Z1");
            modelBuilder.Entity<EqpDscCl>().Property(item => item.X2).HasColumnName("X2");
            modelBuilder.Entity<EqpDscCl>().Property(item => item.Y2).HasColumnName("Y2");
            modelBuilder.Entity<EqpDscCl>().Property(item => item.Z2).HasColumnName("Z2");
            modelBuilder.Entity<EqpDscCl>().Property(item => item.DateReleve).HasColumnName("DATE_RELEVE");
            modelBuilder.Entity<EqpDscCl>().Property(item => item.Terrain).HasColumnName("TERRAIN");
            modelBuilder.Entity<EqpCdCloture>().ToTable("CD_CLOTURE_EQP","EQP");
            modelBuilder.Entity<EqpCdCloture>().HasKey(item => new {item.Cloture });
            modelBuilder.Entity<EqpCdCloture>().Property(item => item.Cloture).IsRequired();
            modelBuilder.Entity<EqpCdCloture>().Property(item => item.Cloture).HasMaxLength(60);
            modelBuilder.Entity<EqpCdCloture>().Property(item => item.Cloture).HasColumnName("CLOTURE");
            modelBuilder.Entity<EqpCdCloture>().Property(item => item.Garantie).HasColumnName("GARANTIE");
            modelBuilder.Entity<EqpCdCloture>().Property(item => item.Dvt).HasColumnName("DVT");
            modelBuilder.Entity<EqpCdMaille>().ToTable("CD_MAILLE_EQP","EQP");
            modelBuilder.Entity<EqpCdMaille>().HasKey(item => new {item.Maille });
            modelBuilder.Entity<EqpCdMaille>().Property(item => item.Maille).IsRequired();
            modelBuilder.Entity<EqpCdMaille>().Property(item => item.Maille).HasMaxLength(60);
            modelBuilder.Entity<EqpCdMaille>().Property(item => item.Maille).HasColumnName("MAILLE");
            modelBuilder.Entity<EqpCdFranch>().ToTable("CD_FRANCH_EQP","EQP");
            modelBuilder.Entity<EqpCdFranch>().HasKey(item => new {item.AntiFranch });
            modelBuilder.Entity<EqpCdFranch>().Property(item => item.AntiFranch).IsRequired();
            modelBuilder.Entity<EqpCdFranch>().Property(item => item.AntiFranch).HasMaxLength(60);
            modelBuilder.Entity<EqpCdFranch>().Property(item => item.AntiFranch).HasColumnName("ANTI_FRANCH");
            modelBuilder.Entity<EqpCdPoteauCl>().ToTable("CD_POTEAU_CL_EQP","EQP");
            modelBuilder.Entity<EqpCdPoteauCl>().HasKey(item => new {item.Poteaux });
            modelBuilder.Entity<EqpCdPoteauCl>().Property(item => item.Poteaux).IsRequired();
            modelBuilder.Entity<EqpCdPoteauCl>().Property(item => item.Poteaux).HasMaxLength(60);
            modelBuilder.Entity<EqpCdPoteauCl>().Property(item => item.Poteaux).HasColumnName("POTEAUX");
            modelBuilder.Entity<EqpPanneau>().ToTable("PANNEAU_EQP","EQP");
            modelBuilder.Entity<EqpPanneau>().HasKey(item => new {item.CdPositEqpPosit,item.DscSvEqpNumExploit,item.Ordre });
            modelBuilder.Entity<EqpPanneau>().Property(item => item.CdPositEqpPosit).IsRequired();
            modelBuilder.Entity<EqpPanneau>().Property(item => item.CdPositEqpPosit).HasMaxLength(60);
            modelBuilder.Entity<EqpPanneau>().Property(item => item.CdPositEqpPosit).HasColumnName("CD_POSIT_EQP__POSIT");
            modelBuilder.Entity<EqpPanneau>().Property(item => item.DscSvEqpNumExploit).IsRequired();
            modelBuilder.Entity<EqpPanneau>().Property(item => item.DscSvEqpNumExploit).HasMaxLength(30);
            modelBuilder.Entity<EqpPanneau>().Property(item => item.DscSvEqpNumExploit).HasColumnName("DSC_SV_EQP__NUM_EXPLOIT");
            modelBuilder.Entity<EqpPanneau>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<EqpPanneau>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<EqpPanneau>().Property(item => item.CdFamSvEqpFamille).IsRequired();
            modelBuilder.Entity<EqpPanneau>().Property(item => item.CdFamSvEqpFamille).HasMaxLength(6);
            modelBuilder.Entity<EqpPanneau>().Property(item => item.CdFamSvEqpFamille).HasColumnName("CD_FAM_SV_EQP__FAMILLE");
            modelBuilder.Entity<EqpPanneau>().Property(item => item.CdTypeSvEqpType).IsRequired();
            modelBuilder.Entity<EqpPanneau>().Property(item => item.CdTypeSvEqpType).HasMaxLength(12);
            modelBuilder.Entity<EqpPanneau>().Property(item => item.CdTypeSvEqpType).HasColumnName("CD_TYPE_SV_EQP__TYPE");
            modelBuilder.Entity<EqpPanneau>().Property(item => item.CdStypeSvEqpSType).IsRequired();
            modelBuilder.Entity<EqpPanneau>().Property(item => item.CdStypeSvEqpSType).HasMaxLength(60);
            modelBuilder.Entity<EqpPanneau>().Property(item => item.CdStypeSvEqpSType).HasColumnName("CD_STYPE_SV_EQP__S_TYPE");
            modelBuilder.Entity<EqpPanneau>().Property(item => item.CdGammeSvEqpGamme).HasMaxLength(20);
            modelBuilder.Entity<EqpPanneau>().Property(item => item.CdGammeSvEqpGamme).HasColumnName("CD_GAMME_SV_EQP__GAMME");
            modelBuilder.Entity<EqpPanneau>().Property(item => item.CdClasseSvEqpClasse).HasMaxLength(5);
            modelBuilder.Entity<EqpPanneau>().Property(item => item.CdClasseSvEqpClasse).HasColumnName("CD_CLASSE_SV_EQP__CLASSE");
            modelBuilder.Entity<EqpPanneau>().Property(item => item.CdMatSvEqpMateriaux).HasMaxLength(60);
            modelBuilder.Entity<EqpPanneau>().Property(item => item.CdMatSvEqpMateriaux).HasColumnName("CD_MAT_SV_EQP__MATERIAUX");
            modelBuilder.Entity<EqpPanneau>().Property(item => item.CdFabricantEqpNom).HasMaxLength(60);
            modelBuilder.Entity<EqpPanneau>().Property(item => item.CdFabricantEqpNom).HasColumnName("CD_FABRICANT_EQP__NOM");
            modelBuilder.Entity<EqpPanneau>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<EqpPanneau>().Property(item => item.Hauteur).HasColumnName("HAUTEUR");
            modelBuilder.Entity<EqpPanneau>().Property(item => item.Largeur).HasColumnName("LARGEUR");
            modelBuilder.Entity<EqpPanneau>().Property(item => item.Reserve).HasColumnName("RESERVE");
            modelBuilder.Entity<EqpPanneau>().Property(item => item.AntiGraffiti).HasColumnName("ANTI_GRAFFITI");
            modelBuilder.Entity<EqpPanneau>().Property(item => item.Mention).HasMaxLength(255);
            modelBuilder.Entity<EqpPanneau>().Property(item => item.Mention).HasColumnName("MENTION");
            modelBuilder.Entity<EqpTravaux>().ToTable("TRAVAUX_EQP","EQP");
            modelBuilder.Entity<EqpTravaux>().HasKey(item => new {item.CdTravauxEqpCode,item.NatureTravEqpNature,item.CdTypeEqpTypeEquip,item.IdTrav });
            modelBuilder.Entity<EqpTravaux>().Property(item => item.CdTravauxEqpCode).IsRequired();
            modelBuilder.Entity<EqpTravaux>().Property(item => item.CdTravauxEqpCode).HasMaxLength(60);
            modelBuilder.Entity<EqpTravaux>().Property(item => item.CdTravauxEqpCode).HasColumnName("CD_TRAVAUX_EQP__CODE");
            modelBuilder.Entity<EqpTravaux>().Property(item => item.NatureTravEqpNature).IsRequired();
            modelBuilder.Entity<EqpTravaux>().Property(item => item.NatureTravEqpNature).HasMaxLength(100);
            modelBuilder.Entity<EqpTravaux>().Property(item => item.NatureTravEqpNature).HasColumnName("NATURE_TRAV_EQP__NATURE");
            modelBuilder.Entity<EqpTravaux>().Property(item => item.CdTypeEqpTypeEquip).IsRequired();
            modelBuilder.Entity<EqpTravaux>().Property(item => item.CdTypeEqpTypeEquip).HasMaxLength(6);
            modelBuilder.Entity<EqpTravaux>().Property(item => item.CdTypeEqpTypeEquip).HasColumnName("CD_TYPE_EQP__TYPE_EQUIP");
            modelBuilder.Entity<EqpTravaux>().Property(item => item.IdTrav).IsRequired();
            modelBuilder.Entity<EqpTravaux>().Property(item => item.IdTrav).HasColumnName("ID_TRAV");
            modelBuilder.Entity<EqpTravaux>().Property(item => item.CdEntpEqpEntreprise).IsRequired();
            modelBuilder.Entity<EqpTravaux>().Property(item => item.CdEntpEqpEntreprise).HasMaxLength(60);
            modelBuilder.Entity<EqpTravaux>().Property(item => item.CdEntpEqpEntreprise).HasColumnName("CD_ENTP_EQP__ENTREPRISE");
            modelBuilder.Entity<EqpTravaux>().Property(item => item.Ouvrage).HasMaxLength(30);
            modelBuilder.Entity<EqpTravaux>().Property(item => item.Ouvrage).HasColumnName("OUVRAGE");
            modelBuilder.Entity<EqpTravaux>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<EqpTravaux>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<EqpTravaux>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<EqpTravaux>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<EqpTravaux>().Property(item => item.Position).HasMaxLength(60);
            modelBuilder.Entity<EqpTravaux>().Property(item => item.Position).HasColumnName("POSITION");
            modelBuilder.Entity<EqpTravaux>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<EqpTravaux>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<EqpTravaux>().Property(item => item.DateRcp).HasColumnName("DATE_RCP");
            modelBuilder.Entity<EqpTravaux>().Property(item => item.Cout).HasColumnName("COUT");
            modelBuilder.Entity<EqpTravaux>().Property(item => item.DateFinGar).HasColumnName("DATE_FIN_GAR");
            modelBuilder.Entity<EqpTravaux>().Property(item => item.Marche).HasMaxLength(25);
            modelBuilder.Entity<EqpTravaux>().Property(item => item.Marche).HasColumnName("MARCHE");
            modelBuilder.Entity<EqpTravaux>().Property(item => item.Commentaire).HasMaxLength(500);
            modelBuilder.Entity<EqpTravaux>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<EqpPrevision>().ToTable("PREVISION_EQP","EQP");
            modelBuilder.Entity<EqpPrevision>().HasKey(item => new {item.BpuEqpTechn,item.CdTypeEqpTypeEquip,item.IdPrev });
            modelBuilder.Entity<EqpPrevision>().Property(item => item.BpuEqpTechn).IsRequired();
            modelBuilder.Entity<EqpPrevision>().Property(item => item.BpuEqpTechn).HasMaxLength(250);
            modelBuilder.Entity<EqpPrevision>().Property(item => item.BpuEqpTechn).HasColumnName("BPU_EQP__TECHN");
            modelBuilder.Entity<EqpPrevision>().Property(item => item.CdTypeEqpTypeEquip).IsRequired();
            modelBuilder.Entity<EqpPrevision>().Property(item => item.CdTypeEqpTypeEquip).HasMaxLength(6);
            modelBuilder.Entity<EqpPrevision>().Property(item => item.CdTypeEqpTypeEquip).HasColumnName("CD_TYPE_EQP__TYPE_EQUIP");
            modelBuilder.Entity<EqpPrevision>().Property(item => item.IdPrev).IsRequired();
            modelBuilder.Entity<EqpPrevision>().Property(item => item.IdPrev).HasColumnName("ID_PREV");
            modelBuilder.Entity<EqpPrevision>().Property(item => item.CdContrainteEqpType).HasMaxLength(100);
            modelBuilder.Entity<EqpPrevision>().Property(item => item.CdContrainteEqpType).HasColumnName("CD_CONTRAINTE_EQP__TYPE");
            modelBuilder.Entity<EqpPrevision>().Property(item => item.Ouvrage).HasMaxLength(30);
            modelBuilder.Entity<EqpPrevision>().Property(item => item.Ouvrage).HasColumnName("OUVRAGE");
            modelBuilder.Entity<EqpPrevision>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<EqpPrevision>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<EqpPrevision>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<EqpPrevision>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<EqpPrevision>().Property(item => item.Position).HasMaxLength(60);
            modelBuilder.Entity<EqpPrevision>().Property(item => item.Position).HasColumnName("POSITION");
            modelBuilder.Entity<EqpPrevision>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<EqpPrevision>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<EqpPrevision>().Property(item => item.DateDebut).IsRequired();
            modelBuilder.Entity<EqpPrevision>().Property(item => item.DateDebut).HasColumnName("DATE_DEBUT");
            modelBuilder.Entity<EqpPrevision>().Property(item => item.Montant).HasColumnName("MONTANT");
            modelBuilder.Entity<EqpPrevision>().Property(item => item.DateFin).HasColumnName("DATE_FIN");
            modelBuilder.Entity<EqpPrevision>().Property(item => item.Commentaire).HasMaxLength(255);
            modelBuilder.Entity<EqpPrevision>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<EqpPrevision>().Property(item => item.Realise).HasColumnName("REALISE");
            modelBuilder.Entity<EqpEvt>().ToTable("EVT_EQP","EQP");
            modelBuilder.Entity<EqpEvt>().HasKey(item => new {item.CdTypeEqpTypeEquip,item.CdEvtEqpType,item.IdEvt });
            modelBuilder.Entity<EqpEvt>().Property(item => item.CdTypeEqpTypeEquip).IsRequired();
            modelBuilder.Entity<EqpEvt>().Property(item => item.CdTypeEqpTypeEquip).HasMaxLength(6);
            modelBuilder.Entity<EqpEvt>().Property(item => item.CdTypeEqpTypeEquip).HasColumnName("CD_TYPE_EQP__TYPE_EQUIP");
            modelBuilder.Entity<EqpEvt>().Property(item => item.CdEvtEqpType).IsRequired();
            modelBuilder.Entity<EqpEvt>().Property(item => item.CdEvtEqpType).HasMaxLength(25);
            modelBuilder.Entity<EqpEvt>().Property(item => item.CdEvtEqpType).HasColumnName("CD_EVT_EQP__TYPE");
            modelBuilder.Entity<EqpEvt>().Property(item => item.IdEvt).IsRequired();
            modelBuilder.Entity<EqpEvt>().Property(item => item.IdEvt).HasColumnName("ID_EVT");
            modelBuilder.Entity<EqpEvt>().Property(item => item.CdPositEqpPosit).HasMaxLength(60);
            modelBuilder.Entity<EqpEvt>().Property(item => item.CdPositEqpPosit).HasColumnName("CD_POSIT_EQP__POSIT");
            modelBuilder.Entity<EqpEvt>().Property(item => item.Ouvrage).HasMaxLength(30);
            modelBuilder.Entity<EqpEvt>().Property(item => item.Ouvrage).HasColumnName("OUVRAGE");
            modelBuilder.Entity<EqpEvt>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<EqpEvt>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<EqpEvt>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<EqpEvt>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<EqpEvt>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<EqpEvt>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<EqpEvt>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<EqpEvt>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<EqpEvt>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<EqpEvt>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<EqpEvt>().Property(item => item.DateRel).IsRequired();
            modelBuilder.Entity<EqpEvt>().Property(item => item.DateRel).HasColumnName("DATE_REL");
            modelBuilder.Entity<EqpEvt>().Property(item => item.Obsv).HasMaxLength(255);
            modelBuilder.Entity<EqpEvt>().Property(item => item.Obsv).HasColumnName("OBSV");
            modelBuilder.Entity<EqpEvt>().Property(item => item.DateTrt).HasColumnName("DATE_TRT");
            modelBuilder.Entity<EqpCdEntp>().ToTable("CD_ENTP_EQP","EQP");
            modelBuilder.Entity<EqpCdEntp>().HasKey(item => new {item.Entreprise });
            modelBuilder.Entity<EqpCdEntp>().Property(item => item.Entreprise).IsRequired();
            modelBuilder.Entity<EqpCdEntp>().Property(item => item.Entreprise).HasMaxLength(60);
            modelBuilder.Entity<EqpCdEntp>().Property(item => item.Entreprise).HasColumnName("ENTREPRISE");
            modelBuilder.Entity<EqpCdPosit>().ToTable("CD_POSIT_EQP","EQP");
            modelBuilder.Entity<EqpCdPosit>().HasKey(item => new {item.Posit });
            modelBuilder.Entity<EqpCdPosit>().Property(item => item.Posit).IsRequired();
            modelBuilder.Entity<EqpCdPosit>().Property(item => item.Posit).HasMaxLength(60);
            modelBuilder.Entity<EqpCdPosit>().Property(item => item.Posit).HasColumnName("POSIT");
            modelBuilder.Entity<EqpCdMatSv>().ToTable("CD_MAT_SV_EQP","EQP");
            modelBuilder.Entity<EqpCdMatSv>().HasKey(item => new {item.Materiaux });
            modelBuilder.Entity<EqpCdMatSv>().Property(item => item.Materiaux).IsRequired();
            modelBuilder.Entity<EqpCdMatSv>().Property(item => item.Materiaux).HasMaxLength(60);
            modelBuilder.Entity<EqpCdMatSv>().Property(item => item.Materiaux).HasColumnName("MATERIAUX");
            modelBuilder.Entity<EqpCdMatSv>().Property(item => item.Garantie).HasColumnName("GARANTIE");
            modelBuilder.Entity<EqpCdMatSv>().Property(item => item.Dvt).HasColumnName("DVT");
            modelBuilder.Entity<EqpCdContrainte>().ToTable("CD_CONTRAINTE_EQP","EQP");
            modelBuilder.Entity<EqpCdContrainte>().HasKey(item => new {item.Type });
            modelBuilder.Entity<EqpCdContrainte>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<EqpCdContrainte>().Property(item => item.Type).HasMaxLength(100);
            modelBuilder.Entity<EqpCdContrainte>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<EqpCdTypeDv>().ToTable("CD_TYPE_DV_EQP","EQP");
            modelBuilder.Entity<EqpCdTypeDv>().HasKey(item => new {item.Code });
            modelBuilder.Entity<EqpCdTypeDv>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<EqpCdTypeDv>().Property(item => item.Code).HasMaxLength(15);
            modelBuilder.Entity<EqpCdTypeDv>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<EqpCdTypeDv>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<EqpCdTypeDv>().Property(item => item.Libelle).HasMaxLength(255);
            modelBuilder.Entity<EqpCdTypeDv>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<EqpDscDv>().ToTable("DSC_DV_EQP","EQP");
            modelBuilder.Entity<EqpDscDv>().HasKey(item => new {item.CdPositEqpPosit,item.CdTypeDvEqpCode,item.Liaison,item.Sens,item.AbsDeb });
            modelBuilder.Entity<EqpDscDv>().Property(item => item.CdPositEqpPosit).IsRequired();
            modelBuilder.Entity<EqpDscDv>().Property(item => item.CdPositEqpPosit).HasMaxLength(60);
            modelBuilder.Entity<EqpDscDv>().Property(item => item.CdPositEqpPosit).HasColumnName("CD_POSIT_EQP__POSIT");
            modelBuilder.Entity<EqpDscDv>().Property(item => item.CdTypeDvEqpCode).IsRequired();
            modelBuilder.Entity<EqpDscDv>().Property(item => item.CdTypeDvEqpCode).HasMaxLength(15);
            modelBuilder.Entity<EqpDscDv>().Property(item => item.CdTypeDvEqpCode).HasColumnName("CD_TYPE_DV_EQP__CODE");
            modelBuilder.Entity<EqpDscDv>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<EqpDscDv>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<EqpDscDv>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<EqpDscDv>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<EqpDscDv>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<EqpDscDv>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<EqpDscDv>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<EqpDscDv>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<EqpDscDv>().Property(item => item.NumExploit).HasMaxLength(30);
            modelBuilder.Entity<EqpDscDv>().Property(item => item.NumExploit).HasColumnName("NUM_EXPLOIT");
            modelBuilder.Entity<EqpDscDv>().Property(item => item.CdEntpEqpEntreprise).HasMaxLength(60);
            modelBuilder.Entity<EqpDscDv>().Property(item => item.CdEntpEqpEntreprise).HasColumnName("CD_ENTP_EQP__ENTREPRISE");
            modelBuilder.Entity<EqpDscDv>().Property(item => item.CdFabricantEqpNom).HasMaxLength(60);
            modelBuilder.Entity<EqpDscDv>().Property(item => item.CdFabricantEqpNom).HasColumnName("CD_FABRICANT_EQP__NOM");
            modelBuilder.Entity<EqpDscDv>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<EqpDscDv>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<EqpDscDv>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<EqpDscDv>().Property(item => item.Alimentation).HasMaxLength(60);
            modelBuilder.Entity<EqpDscDv>().Property(item => item.Alimentation).HasColumnName("ALIMENTATION");
            modelBuilder.Entity<EqpDscDv>().Property(item => item.Commentaire).HasMaxLength(255);
            modelBuilder.Entity<EqpDscDv>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<EqpContact>().ToTable("CONTACT_EQP","EQP");
            modelBuilder.Entity<EqpContact>().HasKey(item => new {item.DocEqpId });
            modelBuilder.Entity<EqpContact>().Property(item => item.DocEqpId).IsRequired();
            modelBuilder.Entity<EqpContact>().Property(item => item.DocEqpId).HasColumnName("DOC_EQP__ID");
            modelBuilder.Entity<EqpContact>().Property(item => item.Givenname).HasMaxLength(60);
            modelBuilder.Entity<EqpContact>().Property(item => item.Givenname).HasColumnName("GIVENNAME");
            modelBuilder.Entity<EqpContact>().Property(item => item.Sn).HasMaxLength(60);
            modelBuilder.Entity<EqpContact>().Property(item => item.Sn).HasColumnName("SN");
            modelBuilder.Entity<EqpContact>().Property(item => item.Cn).HasMaxLength(125);
            modelBuilder.Entity<EqpContact>().Property(item => item.Cn).HasColumnName("CN");
            modelBuilder.Entity<EqpContact>().Property(item => item.O).HasMaxLength(60);
            modelBuilder.Entity<EqpContact>().Property(item => item.O).HasColumnName("O");
            modelBuilder.Entity<EqpContact>().Property(item => item.Mail).HasMaxLength(60);
            modelBuilder.Entity<EqpContact>().Property(item => item.Mail).HasColumnName("MAIL");
            modelBuilder.Entity<EqpContact>().Property(item => item.Telephonenumber).HasMaxLength(20);
            modelBuilder.Entity<EqpContact>().Property(item => item.Telephonenumber).HasColumnName("TELEPHONENUMBER");
            modelBuilder.Entity<EqpContact>().Property(item => item.Mobile).HasMaxLength(20);
            modelBuilder.Entity<EqpContact>().Property(item => item.Mobile).HasColumnName("MOBILE");
            modelBuilder.Entity<EqpContact>().Property(item => item.Facsimiletelephonenumber).HasMaxLength(20);
            modelBuilder.Entity<EqpContact>().Property(item => item.Facsimiletelephonenumber).HasColumnName("FACSIMILETELEPHONENUMBER");
            modelBuilder.Entity<EqpContact>().Property(item => item.Street).HasMaxLength(60);
            modelBuilder.Entity<EqpContact>().Property(item => item.Street).HasColumnName("STREET");
            modelBuilder.Entity<EqpContact>().Property(item => item.Mozillaworkstreet2).HasMaxLength(60);
            modelBuilder.Entity<EqpContact>().Property(item => item.Mozillaworkstreet2).HasColumnName("MOZILLAWORKSTREET2");
            modelBuilder.Entity<EqpContact>().Property(item => item.L).HasMaxLength(60);
            modelBuilder.Entity<EqpContact>().Property(item => item.L).HasColumnName("L");
            modelBuilder.Entity<EqpContact>().Property(item => item.Postalcode).HasMaxLength(12);
            modelBuilder.Entity<EqpContact>().Property(item => item.Postalcode).HasColumnName("POSTALCODE");
            modelBuilder.Entity<EqpContact>().Property(item => item.Modifytimestamp).HasColumnName("MODIFYTIMESTAMP");
            modelBuilder.Entity<EqpClsDoc>().ToTable("CLS_DOC_EQP","EQP");
            modelBuilder.Entity<EqpClsDoc>().HasKey(item => new {item.ClsEqpId,item.DocEqpId });
            modelBuilder.Entity<EqpClsDoc>().Property(item => item.ClsEqpId).IsRequired();
            modelBuilder.Entity<EqpClsDoc>().Property(item => item.ClsEqpId).HasColumnName("CLS_EQP__ID");
            modelBuilder.Entity<EqpClsDoc>().Property(item => item.DocEqpId).IsRequired();
            modelBuilder.Entity<EqpClsDoc>().Property(item => item.DocEqpId).HasColumnName("DOC_EQP__ID");
            modelBuilder.Entity<EqpClsDoc>().Property(item => item.Defaut).HasColumnName("DEFAUT");
            modelBuilder.Entity<EqpClsDoc>().Property(item => item.Dossier).HasMaxLength(15);
            modelBuilder.Entity<EqpClsDoc>().Property(item => item.Dossier).HasColumnName("DOSSIER");
            modelBuilder.Entity<GmsCdType>().ToTable("CD_TYPE_GMS","GMS");
            modelBuilder.Entity<GmsCdType>().HasKey(item => new {item.Type });
            modelBuilder.Entity<GmsCdType>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<GmsCdType>().Property(item => item.Type).HasMaxLength(60);
            modelBuilder.Entity<GmsCdType>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<GmsCdFam>().ToTable("CD_FAM_GMS","GMS");
            modelBuilder.Entity<GmsCdFam>().HasKey(item => new {item.Famille });
            modelBuilder.Entity<GmsCdFam>().Property(item => item.Famille).IsRequired();
            modelBuilder.Entity<GmsCdFam>().Property(item => item.Famille).HasMaxLength(20);
            modelBuilder.Entity<GmsCdFam>().Property(item => item.Famille).HasColumnName("FAMILLE");
            modelBuilder.Entity<GmsCdFam>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<GmsCdFam>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<GmsCdEntp>().ToTable("CD_ENTP_GMS","GMS");
            modelBuilder.Entity<GmsCdEntp>().HasKey(item => new {item.Entreprise });
            modelBuilder.Entity<GmsCdEntp>().Property(item => item.Entreprise).IsRequired();
            modelBuilder.Entity<GmsCdEntp>().Property(item => item.Entreprise).HasMaxLength(60);
            modelBuilder.Entity<GmsCdEntp>().Property(item => item.Entreprise).HasColumnName("ENTREPRISE");
            modelBuilder.Entity<GmsDsc>().ToTable("DSC_GMS","GMS");
            modelBuilder.Entity<GmsDsc>().HasKey(item => new {item.NumGms });
            modelBuilder.Entity<GmsDsc>().Property(item => item.NumGms).IsRequired();
            modelBuilder.Entity<GmsDsc>().Property(item => item.NumGms).HasMaxLength(17);
            modelBuilder.Entity<GmsDsc>().Property(item => item.NumGms).HasColumnName("NUM_GMS");
            modelBuilder.Entity<GmsDsc>().Property(item => item.CdPoteauGmsType).HasMaxLength(60);
            modelBuilder.Entity<GmsDsc>().Property(item => item.CdPoteauGmsType).HasColumnName("CD_POTEAU_GMS__TYPE");
            modelBuilder.Entity<GmsDsc>().Property(item => item.CdPosMatGmsPosit).IsRequired();
            modelBuilder.Entity<GmsDsc>().Property(item => item.CdPosMatGmsPosit).HasMaxLength(4);
            modelBuilder.Entity<GmsDsc>().Property(item => item.CdPosMatGmsPosit).HasColumnName("CD_POS_MAT_GMS__POSIT");
            modelBuilder.Entity<GmsDsc>().Property(item => item.CdEntpGmsEntreprise).HasMaxLength(60);
            modelBuilder.Entity<GmsDsc>().Property(item => item.CdEntpGmsEntreprise).HasColumnName("CD_ENTP_GMS__ENTREPRISE");
            modelBuilder.Entity<GmsDsc>().Property(item => item.CdAncrageGmsType).HasMaxLength(60);
            modelBuilder.Entity<GmsDsc>().Property(item => item.CdAncrageGmsType).HasColumnName("CD_ANCRAGE_GMS__TYPE");
            modelBuilder.Entity<GmsDsc>().Property(item => item.CdAccesGmsType).HasMaxLength(60);
            modelBuilder.Entity<GmsDsc>().Property(item => item.CdAccesGmsType).HasColumnName("CD_ACCES_GMS__TYPE");
            modelBuilder.Entity<GmsDsc>().Property(item => item.CdPoutreGmsType).HasMaxLength(60);
            modelBuilder.Entity<GmsDsc>().Property(item => item.CdPoutreGmsType).HasColumnName("CD_POUTRE_GMS__TYPE");
            modelBuilder.Entity<GmsDsc>().Property(item => item.CdFournisseurGmsNom).HasMaxLength(60);
            modelBuilder.Entity<GmsDsc>().Property(item => item.CdFournisseurGmsNom).HasColumnName("CD_FOURNISSEUR_GMS__NOM");
            modelBuilder.Entity<GmsDsc>().Property(item => item.CdFamGmsFamille).IsRequired();
            modelBuilder.Entity<GmsDsc>().Property(item => item.CdFamGmsFamille).HasMaxLength(20);
            modelBuilder.Entity<GmsDsc>().Property(item => item.CdFamGmsFamille).HasColumnName("CD_FAM_GMS__FAMILLE");
            modelBuilder.Entity<GmsDsc>().Property(item => item.CdTypeGmsType).HasMaxLength(60);
            modelBuilder.Entity<GmsDsc>().Property(item => item.CdTypeGmsType).HasColumnName("CD_TYPE_GMS__TYPE");
            modelBuilder.Entity<GmsDsc>().Property(item => item.CdInterfaceGmsType).HasMaxLength(60);
            modelBuilder.Entity<GmsDsc>().Property(item => item.CdInterfaceGmsType).HasColumnName("CD_INTERFACE_GMS__TYPE");
            modelBuilder.Entity<GmsDsc>().Property(item => item.CdQualiteGmsQualite).HasMaxLength(25);
            modelBuilder.Entity<GmsDsc>().Property(item => item.CdQualiteGmsQualite).HasColumnName("CD_QUALITE_GMS__QUALITE");
            modelBuilder.Entity<GmsDsc>().Property(item => item.CdProtecGmsProtec).HasMaxLength(60);
            modelBuilder.Entity<GmsDsc>().Property(item => item.CdProtecGmsProtec).HasColumnName("CD_PROTEC_GMS__PROTEC");
            modelBuilder.Entity<GmsDsc>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<GmsDsc>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<GmsDsc>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<GmsDsc>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<GmsDsc>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<GmsDsc>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<GmsDsc>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<GmsDsc>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<GmsDsc>().Property(item => item.NumExploit).HasMaxLength(17);
            modelBuilder.Entity<GmsDsc>().Property(item => item.NumExploit).HasColumnName("NUM_EXPLOIT");
            modelBuilder.Entity<GmsDsc>().Property(item => item.NomUsage).HasMaxLength(255);
            modelBuilder.Entity<GmsDsc>().Property(item => item.NomUsage).HasColumnName("NOM_USAGE");
            modelBuilder.Entity<GmsDsc>().Property(item => item.DateMs).IsRequired();
            modelBuilder.Entity<GmsDsc>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<GmsDsc>().Property(item => item.Haut).HasColumnName("HAUT");
            modelBuilder.Entity<GmsDsc>().Property(item => item.Tirair).HasColumnName("TIRAIR");
            modelBuilder.Entity<GmsDsc>().Property(item => item.Vent).HasColumnName("VENT");
            modelBuilder.Entity<GmsDsc>().Property(item => item.Ancrage).HasMaxLength(60);
            modelBuilder.Entity<GmsDsc>().Property(item => item.Ancrage).HasColumnName("ANCRAGE");
            modelBuilder.Entity<GmsDsc>().Property(item => item.Larg).HasColumnName("LARG");
            modelBuilder.Entity<GmsDsc>().Property(item => item.Traverse).HasColumnName("TRAVERSE");
            modelBuilder.Entity<GmsDsc>().Property(item => item.Element).HasColumnName("ELEMENT");
            modelBuilder.Entity<GmsDsc>().Property(item => item.NbPoteaux).HasColumnName("NB_POTEAUX");
            modelBuilder.Entity<GmsDsc>().Property(item => item.Eclairage).HasColumnName("ECLAIRAGE");
            modelBuilder.Entity<GmsDsc>().Property(item => item.Condamne).HasColumnName("CONDAMNE");
            modelBuilder.Entity<GmsDsc>().Property(item => item.Note1).HasColumnName("NOTE1");
            modelBuilder.Entity<GmsDsc>().Property(item => item.Note2).HasColumnName("NOTE2");
            modelBuilder.Entity<GmsDsc>().Property(item => item.Note3).HasColumnName("NOTE3");
            modelBuilder.Entity<GmsDsc>().Property(item => item.Note4).HasColumnName("NOTE4");
            modelBuilder.Entity<GmsDsc>().Property(item => item.Note5).HasColumnName("NOTE5");
            modelBuilder.Entity<GmsDsc>().Property(item => item.Urgence).HasMaxLength(5);
            modelBuilder.Entity<GmsDsc>().Property(item => item.Urgence).HasColumnName("URGENCE");
            modelBuilder.Entity<GmsDsc>().Property(item => item.DescInva).HasMaxLength(1000);
            modelBuilder.Entity<GmsDsc>().Property(item => item.DescInva).HasColumnName("DESC_INVA");
            modelBuilder.Entity<GmsDsc>().Property(item => item.Securite).HasColumnName("SECURITE");
            modelBuilder.Entity<GmsDsc>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<GmsDsc>().Property(item => item.ProsurvAnnee).HasColumnName("PROSURV_ANNEE");
            modelBuilder.Entity<GmsDsc>().Property(item => item.DernInsp).HasColumnName("DERN_INSP");
            modelBuilder.Entity<GmsDsc>().Property(item => item.DernVst).HasColumnName("DERN_VST");
            modelBuilder.Entity<GmsDsc>().Property(item => item.NoteVst).HasMaxLength(5);
            modelBuilder.Entity<GmsDsc>().Property(item => item.NoteVst).HasColumnName("NOTE_VST");
            modelBuilder.Entity<GmsDsc>().Property(item => item.Archive).HasMaxLength(255);
            modelBuilder.Entity<GmsDsc>().Property(item => item.Archive).HasColumnName("ARCHIVE");
            modelBuilder.Entity<GmsDsc>().Property(item => item.Commentaire).HasMaxLength(1000);
            modelBuilder.Entity<GmsDsc>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<GmsDsc>().Property(item => item.X1).HasColumnName("X1");
            modelBuilder.Entity<GmsDsc>().Property(item => item.Y1).HasColumnName("Y1");
            modelBuilder.Entity<GmsDsc>().Property(item => item.Z1).HasColumnName("Z1");
            modelBuilder.Entity<GmsDsc>().Property(item => item.DateReleve).HasColumnName("DATE_RELEVE");
            modelBuilder.Entity<GmsDsc>().Property(item => item.Terrain).HasColumnName("TERRAIN");
            modelBuilder.Entity<GmsCls>().ToTable("CLS_GMS","GMS");
            modelBuilder.Entity<GmsCls>().HasKey(item => new {item.Id });
            modelBuilder.Entity<GmsCls>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<GmsCls>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<GmsCls>().Property(item => item.TableName).HasMaxLength(30);
            modelBuilder.Entity<GmsCls>().Property(item => item.TableName).HasColumnName("TABLE_NAME");
            modelBuilder.Entity<GmsCls>().Property(item => item.KeyValue).HasMaxLength(100);
            modelBuilder.Entity<GmsCls>().Property(item => item.KeyValue).HasColumnName("KEY_VALUE");
            modelBuilder.Entity<GmsDoc>().ToTable("DOC_GMS","GMS");
            modelBuilder.Entity<GmsDoc>().HasKey(item => new {item.Id });
            modelBuilder.Entity<GmsDoc>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<GmsDoc>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<GmsDoc>().Property(item => item.CdDocGmsCode).IsRequired();
            modelBuilder.Entity<GmsDoc>().Property(item => item.CdDocGmsCode).HasMaxLength(15);
            modelBuilder.Entity<GmsDoc>().Property(item => item.CdDocGmsCode).HasColumnName("CD_DOC_GMS__CODE");
            modelBuilder.Entity<GmsDoc>().Property(item => item.Libelle).HasMaxLength(100);
            modelBuilder.Entity<GmsDoc>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<GmsDoc>().Property(item => item.Ref).HasMaxLength(50);
            modelBuilder.Entity<GmsDoc>().Property(item => item.Ref).HasColumnName("REF");
            modelBuilder.Entity<GmsCdDoc>().ToTable("CD_DOC_GMS","GMS");
            modelBuilder.Entity<GmsCdDoc>().HasKey(item => new {item.Code });
            modelBuilder.Entity<GmsCdDoc>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<GmsCdDoc>().Property(item => item.Code).HasMaxLength(15);
            modelBuilder.Entity<GmsCdDoc>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<GmsCdDoc>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<GmsCdDoc>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<GmsCdDoc>().Property(item => item.Path).HasMaxLength(255);
            modelBuilder.Entity<GmsCdDoc>().Property(item => item.Path).HasColumnName("PATH");
            modelBuilder.Entity<GmsElt>().ToTable("ELT_GMS","GMS");
            modelBuilder.Entity<GmsElt>().HasKey(item => new {item.GrpGmsIdGrp,item.PrtGmsIdPrt,item.SprtGmsIdSprt,item.IdElem });
            modelBuilder.Entity<GmsElt>().Property(item => item.GrpGmsIdGrp).IsRequired();
            modelBuilder.Entity<GmsElt>().Property(item => item.GrpGmsIdGrp).HasColumnName("GRP_GMS__ID_GRP");
            modelBuilder.Entity<GmsElt>().Property(item => item.PrtGmsIdPrt).IsRequired();
            modelBuilder.Entity<GmsElt>().Property(item => item.PrtGmsIdPrt).HasColumnName("PRT_GMS__ID_PRT");
            modelBuilder.Entity<GmsElt>().Property(item => item.SprtGmsIdSprt).IsRequired();
            modelBuilder.Entity<GmsElt>().Property(item => item.SprtGmsIdSprt).HasColumnName("SPRT_GMS__ID_SPRT");
            modelBuilder.Entity<GmsElt>().Property(item => item.IdElem).IsRequired();
            modelBuilder.Entity<GmsElt>().Property(item => item.IdElem).HasColumnName("ID_ELEM");
            modelBuilder.Entity<GmsElt>().Property(item => item.Libe).IsRequired();
            modelBuilder.Entity<GmsElt>().Property(item => item.Libe).HasMaxLength(500);
            modelBuilder.Entity<GmsElt>().Property(item => item.Libe).HasColumnName("LIBE");
            modelBuilder.Entity<GmsElt>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<GmsElt>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<GmsElt>().Property(item => item.Aide).HasMaxLength(500);
            modelBuilder.Entity<GmsElt>().Property(item => item.Aide).HasColumnName("AIDE");
            modelBuilder.Entity<GmsElt>().Property(item => item.Indice1).HasMaxLength(500);
            modelBuilder.Entity<GmsElt>().Property(item => item.Indice1).HasColumnName("INDICE1");
            modelBuilder.Entity<GmsElt>().Property(item => item.Indice2).HasMaxLength(500);
            modelBuilder.Entity<GmsElt>().Property(item => item.Indice2).HasColumnName("INDICE2");
            modelBuilder.Entity<GmsElt>().Property(item => item.Indice3).HasMaxLength(500);
            modelBuilder.Entity<GmsElt>().Property(item => item.Indice3).HasColumnName("INDICE3");
            modelBuilder.Entity<GmsSprt>().ToTable("SPRT_GMS","GMS");
            modelBuilder.Entity<GmsSprt>().HasKey(item => new {item.GrpGmsIdGrp,item.PrtGmsIdPrt,item.IdSprt });
            modelBuilder.Entity<GmsSprt>().Property(item => item.GrpGmsIdGrp).IsRequired();
            modelBuilder.Entity<GmsSprt>().Property(item => item.GrpGmsIdGrp).HasColumnName("GRP_GMS__ID_GRP");
            modelBuilder.Entity<GmsSprt>().Property(item => item.PrtGmsIdPrt).IsRequired();
            modelBuilder.Entity<GmsSprt>().Property(item => item.PrtGmsIdPrt).HasColumnName("PRT_GMS__ID_PRT");
            modelBuilder.Entity<GmsSprt>().Property(item => item.IdSprt).IsRequired();
            modelBuilder.Entity<GmsSprt>().Property(item => item.IdSprt).HasColumnName("ID_SPRT");
            modelBuilder.Entity<GmsSprt>().Property(item => item.Libs).IsRequired();
            modelBuilder.Entity<GmsSprt>().Property(item => item.Libs).HasMaxLength(500);
            modelBuilder.Entity<GmsSprt>().Property(item => item.Libs).HasColumnName("LIBS");
            modelBuilder.Entity<GmsSprt>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<GmsSprt>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<GmsPrt>().ToTable("PRT_GMS","GMS");
            modelBuilder.Entity<GmsPrt>().HasKey(item => new {item.GrpGmsIdGrp,item.IdPrt });
            modelBuilder.Entity<GmsPrt>().Property(item => item.GrpGmsIdGrp).IsRequired();
            modelBuilder.Entity<GmsPrt>().Property(item => item.GrpGmsIdGrp).HasColumnName("GRP_GMS__ID_GRP");
            modelBuilder.Entity<GmsPrt>().Property(item => item.IdPrt).IsRequired();
            modelBuilder.Entity<GmsPrt>().Property(item => item.IdPrt).HasColumnName("ID_PRT");
            modelBuilder.Entity<GmsPrt>().Property(item => item.Libp).IsRequired();
            modelBuilder.Entity<GmsPrt>().Property(item => item.Libp).HasMaxLength(500);
            modelBuilder.Entity<GmsPrt>().Property(item => item.Libp).HasColumnName("LIBP");
            modelBuilder.Entity<GmsPrt>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<GmsPrt>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<GmsGrp>().ToTable("GRP_GMS","GMS");
            modelBuilder.Entity<GmsGrp>().HasKey(item => new {item.IdGrp });
            modelBuilder.Entity<GmsGrp>().Property(item => item.IdGrp).IsRequired();
            modelBuilder.Entity<GmsGrp>().Property(item => item.IdGrp).HasColumnName("ID_GRP");
            modelBuilder.Entity<GmsGrp>().Property(item => item.Libg).IsRequired();
            modelBuilder.Entity<GmsGrp>().Property(item => item.Libg).HasMaxLength(500);
            modelBuilder.Entity<GmsGrp>().Property(item => item.Libg).HasColumnName("LIBG");
            modelBuilder.Entity<GmsGrp>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<GmsGrp>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<GmsEltInsp>().ToTable("ELT_INSP_GMS","GMS");
            modelBuilder.Entity<GmsEltInsp>().HasKey(item => new {item.GrpGmsIdGrp,item.PrtGmsIdPrt,item.SprtGmsIdSprt,item.EltGmsIdElem,item.CampGmsIdCamp,item.DscGmsNumGms });
            modelBuilder.Entity<GmsEltInsp>().Property(item => item.GrpGmsIdGrp).IsRequired();
            modelBuilder.Entity<GmsEltInsp>().Property(item => item.GrpGmsIdGrp).HasColumnName("GRP_GMS__ID_GRP");
            modelBuilder.Entity<GmsEltInsp>().Property(item => item.PrtGmsIdPrt).IsRequired();
            modelBuilder.Entity<GmsEltInsp>().Property(item => item.PrtGmsIdPrt).HasColumnName("PRT_GMS__ID_PRT");
            modelBuilder.Entity<GmsEltInsp>().Property(item => item.SprtGmsIdSprt).IsRequired();
            modelBuilder.Entity<GmsEltInsp>().Property(item => item.SprtGmsIdSprt).HasColumnName("SPRT_GMS__ID_SPRT");
            modelBuilder.Entity<GmsEltInsp>().Property(item => item.EltGmsIdElem).IsRequired();
            modelBuilder.Entity<GmsEltInsp>().Property(item => item.EltGmsIdElem).HasColumnName("ELT_GMS__ID_ELEM");
            modelBuilder.Entity<GmsEltInsp>().Property(item => item.CampGmsIdCamp).IsRequired();
            modelBuilder.Entity<GmsEltInsp>().Property(item => item.CampGmsIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GmsEltInsp>().Property(item => item.CampGmsIdCamp).HasColumnName("CAMP_GMS__ID_CAMP");
            modelBuilder.Entity<GmsEltInsp>().Property(item => item.DscGmsNumGms).IsRequired();
            modelBuilder.Entity<GmsEltInsp>().Property(item => item.DscGmsNumGms).HasMaxLength(17);
            modelBuilder.Entity<GmsEltInsp>().Property(item => item.DscGmsNumGms).HasColumnName("DSC_GMS__NUM_GMS");
            modelBuilder.Entity<GmsEltInsp>().Property(item => item.Indice).IsRequired();
            modelBuilder.Entity<GmsEltInsp>().Property(item => item.Indice).HasColumnName("INDICE");
            modelBuilder.Entity<GmsEltInsp>().Property(item => item.Obs).HasMaxLength(255);
            modelBuilder.Entity<GmsEltInsp>().Property(item => item.Obs).HasColumnName("OBS");
            modelBuilder.Entity<GmsCdMeteo>().ToTable("CD_METEO_GMS","GMS");
            modelBuilder.Entity<GmsCdMeteo>().HasKey(item => new {item.Meteo });
            modelBuilder.Entity<GmsCdMeteo>().Property(item => item.Meteo).IsRequired();
            modelBuilder.Entity<GmsCdMeteo>().Property(item => item.Meteo).HasMaxLength(60);
            modelBuilder.Entity<GmsCdMeteo>().Property(item => item.Meteo).HasColumnName("METEO");
            modelBuilder.Entity<GmsTravaux>().ToTable("TRAVAUX_GMS","GMS");
            modelBuilder.Entity<GmsTravaux>().HasKey(item => new {item.DscGmsNumGms,item.CdTravauxGmsCode,item.NatureTravGmsNature,item.DateRcp });
            modelBuilder.Entity<GmsTravaux>().Property(item => item.DscGmsNumGms).IsRequired();
            modelBuilder.Entity<GmsTravaux>().Property(item => item.DscGmsNumGms).HasMaxLength(17);
            modelBuilder.Entity<GmsTravaux>().Property(item => item.DscGmsNumGms).HasColumnName("DSC_GMS__NUM_GMS");
            modelBuilder.Entity<GmsTravaux>().Property(item => item.CdTravauxGmsCode).IsRequired();
            modelBuilder.Entity<GmsTravaux>().Property(item => item.CdTravauxGmsCode).HasMaxLength(60);
            modelBuilder.Entity<GmsTravaux>().Property(item => item.CdTravauxGmsCode).HasColumnName("CD_TRAVAUX_GMS__CODE");
            modelBuilder.Entity<GmsTravaux>().Property(item => item.NatureTravGmsNature).IsRequired();
            modelBuilder.Entity<GmsTravaux>().Property(item => item.NatureTravGmsNature).HasMaxLength(255);
            modelBuilder.Entity<GmsTravaux>().Property(item => item.NatureTravGmsNature).HasColumnName("NATURE_TRAV_GMS__NATURE");
            modelBuilder.Entity<GmsTravaux>().Property(item => item.DateRcp).IsRequired();
            modelBuilder.Entity<GmsTravaux>().Property(item => item.DateRcp).HasColumnName("DATE_RCP");
            modelBuilder.Entity<GmsTravaux>().Property(item => item.CdEntpGmsEntreprise).IsRequired();
            modelBuilder.Entity<GmsTravaux>().Property(item => item.CdEntpGmsEntreprise).HasMaxLength(60);
            modelBuilder.Entity<GmsTravaux>().Property(item => item.CdEntpGmsEntreprise).HasColumnName("CD_ENTP_GMS__ENTREPRISE");
            modelBuilder.Entity<GmsTravaux>().Property(item => item.DateFinGar).HasColumnName("DATE_FIN_GAR");
            modelBuilder.Entity<GmsTravaux>().Property(item => item.Cout).HasColumnName("COUT");
            modelBuilder.Entity<GmsTravaux>().Property(item => item.Marche).HasMaxLength(25);
            modelBuilder.Entity<GmsTravaux>().Property(item => item.Marche).HasColumnName("MARCHE");
            modelBuilder.Entity<GmsTravaux>().Property(item => item.Commentaire).HasMaxLength(500);
            modelBuilder.Entity<GmsTravaux>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<GmsNatureTrav>().ToTable("NATURE_TRAV_GMS","GMS");
            modelBuilder.Entity<GmsNatureTrav>().HasKey(item => new {item.CdTravauxGmsCode,item.Nature });
            modelBuilder.Entity<GmsNatureTrav>().Property(item => item.CdTravauxGmsCode).IsRequired();
            modelBuilder.Entity<GmsNatureTrav>().Property(item => item.CdTravauxGmsCode).HasMaxLength(60);
            modelBuilder.Entity<GmsNatureTrav>().Property(item => item.CdTravauxGmsCode).HasColumnName("CD_TRAVAUX_GMS__CODE");
            modelBuilder.Entity<GmsNatureTrav>().Property(item => item.Nature).IsRequired();
            modelBuilder.Entity<GmsNatureTrav>().Property(item => item.Nature).HasMaxLength(255);
            modelBuilder.Entity<GmsNatureTrav>().Property(item => item.Nature).HasColumnName("NATURE");
            modelBuilder.Entity<GmsCdTravaux>().ToTable("CD_TRAVAUX_GMS","GMS");
            modelBuilder.Entity<GmsCdTravaux>().HasKey(item => new {item.Code });
            modelBuilder.Entity<GmsCdTravaux>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<GmsCdTravaux>().Property(item => item.Code).HasMaxLength(60);
            modelBuilder.Entity<GmsCdTravaux>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<GmsCdPoutre>().ToTable("CD_POUTRE_GMS","GMS");
            modelBuilder.Entity<GmsCdPoutre>().HasKey(item => new {item.Type });
            modelBuilder.Entity<GmsCdPoutre>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<GmsCdPoutre>().Property(item => item.Type).HasMaxLength(60);
            modelBuilder.Entity<GmsCdPoutre>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<GmsCdPoutre>().Property(item => item.Garantie).HasColumnName("GARANTIE");
            modelBuilder.Entity<GmsCdPoutre>().Property(item => item.Dvt).HasColumnName("DVT");
            modelBuilder.Entity<GmsPrevision>().ToTable("PREVISION_GMS","GMS");
            modelBuilder.Entity<GmsPrevision>().HasKey(item => new {item.DscGmsNumGms,item.BpuGmsIdBpu,item.DateDebut });
            modelBuilder.Entity<GmsPrevision>().Property(item => item.DscGmsNumGms).IsRequired();
            modelBuilder.Entity<GmsPrevision>().Property(item => item.DscGmsNumGms).HasMaxLength(17);
            modelBuilder.Entity<GmsPrevision>().Property(item => item.DscGmsNumGms).HasColumnName("DSC_GMS__NUM_GMS");
            modelBuilder.Entity<GmsPrevision>().Property(item => item.BpuGmsIdBpu).IsRequired();
            modelBuilder.Entity<GmsPrevision>().Property(item => item.BpuGmsIdBpu).HasColumnName("BPU_GMS__ID_BPU");
            modelBuilder.Entity<GmsPrevision>().Property(item => item.DateDebut).IsRequired();
            modelBuilder.Entity<GmsPrevision>().Property(item => item.DateDebut).HasColumnName("DATE_DEBUT");
            modelBuilder.Entity<GmsPrevision>().Property(item => item.CdContrainteGmsType).HasMaxLength(100);
            modelBuilder.Entity<GmsPrevision>().Property(item => item.CdContrainteGmsType).HasColumnName("CD_CONTRAINTE_GMS__TYPE");
            modelBuilder.Entity<GmsPrevision>().Property(item => item.DateFin).HasColumnName("DATE_FIN");
            modelBuilder.Entity<GmsPrevision>().Property(item => item.Montant).HasColumnName("MONTANT");
            modelBuilder.Entity<GmsPrevision>().Property(item => item.DateDemPub).HasColumnName("DATE_DEM_PUB");
            modelBuilder.Entity<GmsPrevision>().Property(item => item.Commentaire).HasMaxLength(255);
            modelBuilder.Entity<GmsPrevision>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<GmsPrevision>().Property(item => item.Realise).HasColumnName("REALISE");
            modelBuilder.Entity<GmsCdAncrage>().ToTable("CD_ANCRAGE_GMS","GMS");
            modelBuilder.Entity<GmsCdAncrage>().HasKey(item => new {item.Type });
            modelBuilder.Entity<GmsCdAncrage>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<GmsCdAncrage>().Property(item => item.Type).HasMaxLength(60);
            modelBuilder.Entity<GmsCdAncrage>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<GmsPanneau>().ToTable("PANNEAU_GMS","GMS");
            modelBuilder.Entity<GmsPanneau>().HasKey(item => new {item.DscGmsNumGms,item.CdPosPanGmsPosit });
            modelBuilder.Entity<GmsPanneau>().Property(item => item.DscGmsNumGms).IsRequired();
            modelBuilder.Entity<GmsPanneau>().Property(item => item.DscGmsNumGms).HasMaxLength(17);
            modelBuilder.Entity<GmsPanneau>().Property(item => item.DscGmsNumGms).HasColumnName("DSC_GMS__NUM_GMS");
            modelBuilder.Entity<GmsPanneau>().Property(item => item.CdPosPanGmsPosit).IsRequired();
            modelBuilder.Entity<GmsPanneau>().Property(item => item.CdPosPanGmsPosit).HasMaxLength(4);
            modelBuilder.Entity<GmsPanneau>().Property(item => item.CdPosPanGmsPosit).HasColumnName("CD_POS_PAN_GMS__POSIT");
            modelBuilder.Entity<GmsPanneau>().Property(item => item.CdPanneauGmsType).HasMaxLength(60);
            modelBuilder.Entity<GmsPanneau>().Property(item => item.CdPanneauGmsType).HasColumnName("CD_PANNEAU_GMS__TYPE");
            modelBuilder.Entity<GmsPanneau>().Property(item => item.CdInterfaceGmsType).HasMaxLength(60);
            modelBuilder.Entity<GmsPanneau>().Property(item => item.CdInterfaceGmsType).HasColumnName("CD_INTERFACE_GMS__TYPE");
            modelBuilder.Entity<GmsPanneau>().Property(item => item.CdEntpGmsEntreprise).HasMaxLength(60);
            modelBuilder.Entity<GmsPanneau>().Property(item => item.CdEntpGmsEntreprise).HasColumnName("CD_ENTP_GMS__ENTREPRISE");
            modelBuilder.Entity<GmsPanneau>().Property(item => item.CdFournisseurGmsNom).HasMaxLength(60);
            modelBuilder.Entity<GmsPanneau>().Property(item => item.CdFournisseurGmsNom).HasColumnName("CD_FOURNISSEUR_GMS__NOM");
            modelBuilder.Entity<GmsPanneau>().Property(item => item.DateMs).IsRequired();
            modelBuilder.Entity<GmsPanneau>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<GmsPanneau>().Property(item => item.Hauteur).HasColumnName("HAUTEUR");
            modelBuilder.Entity<GmsPanneau>().Property(item => item.Largeur).HasColumnName("LARGEUR");
            modelBuilder.Entity<GmsPanneau>().Property(item => item.Mention).HasMaxLength(255);
            modelBuilder.Entity<GmsPanneau>().Property(item => item.Mention).HasColumnName("MENTION");
            modelBuilder.Entity<GmsPanneau>().Property(item => item.Reserve).HasColumnName("RESERVE");
            modelBuilder.Entity<GmsCdPanneau>().ToTable("CD_PANNEAU_GMS","GMS");
            modelBuilder.Entity<GmsCdPanneau>().HasKey(item => new {item.Type });
            modelBuilder.Entity<GmsCdPanneau>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<GmsCdPanneau>().Property(item => item.Type).HasMaxLength(60);
            modelBuilder.Entity<GmsCdPanneau>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<GmsCdPanneau>().Property(item => item.Garantie).HasColumnName("GARANTIE");
            modelBuilder.Entity<GmsCdPanneau>().Property(item => item.Dvt).HasColumnName("DVT");
            modelBuilder.Entity<GmsCdAcces>().ToTable("CD_ACCES_GMS","GMS");
            modelBuilder.Entity<GmsCdAcces>().HasKey(item => new {item.Type });
            modelBuilder.Entity<GmsCdAcces>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<GmsCdAcces>().Property(item => item.Type).HasMaxLength(60);
            modelBuilder.Entity<GmsCdAcces>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<GmsSysUser>().ToTable("SYS_USER_GMS","GMS");
            modelBuilder.Entity<GmsSysUser>().HasKey(item => new {item.CodeDbs,item.CodeTable,item.CodeColonne,item.NomUser,item.CodePrp });
            modelBuilder.Entity<GmsSysUser>().Property(item => item.CodeDbs).IsRequired();
            modelBuilder.Entity<GmsSysUser>().Property(item => item.CodeDbs).HasMaxLength(50);
            modelBuilder.Entity<GmsSysUser>().Property(item => item.CodeDbs).HasColumnName("CODE_DBS");
            modelBuilder.Entity<GmsSysUser>().Property(item => item.CodeTable).IsRequired();
            modelBuilder.Entity<GmsSysUser>().Property(item => item.CodeTable).HasMaxLength(100);
            modelBuilder.Entity<GmsSysUser>().Property(item => item.CodeTable).HasColumnName("CODE_TABLE");
            modelBuilder.Entity<GmsSysUser>().Property(item => item.CodeColonne).IsRequired();
            modelBuilder.Entity<GmsSysUser>().Property(item => item.CodeColonne).HasMaxLength(100);
            modelBuilder.Entity<GmsSysUser>().Property(item => item.CodeColonne).HasColumnName("CODE_COLONNE");
            modelBuilder.Entity<GmsSysUser>().Property(item => item.NomUser).IsRequired();
            modelBuilder.Entity<GmsSysUser>().Property(item => item.NomUser).HasMaxLength(150);
            modelBuilder.Entity<GmsSysUser>().Property(item => item.NomUser).HasColumnName("NOM_USER");
            modelBuilder.Entity<GmsSysUser>().Property(item => item.CodePrp).IsRequired();
            modelBuilder.Entity<GmsSysUser>().Property(item => item.CodePrp).HasMaxLength(255);
            modelBuilder.Entity<GmsSysUser>().Property(item => item.CodePrp).HasColumnName("CODE_PRP");
            modelBuilder.Entity<GmsSysUser>().Property(item => item.ValPrp).IsRequired();
            modelBuilder.Entity<GmsSysUser>().Property(item => item.ValPrp).HasMaxLength(500);
            modelBuilder.Entity<GmsSysUser>().Property(item => item.ValPrp).HasColumnName("VAL_PRP");
            modelBuilder.Entity<GmsBpu>().ToTable("BPU_GMS","GMS");
            modelBuilder.Entity<GmsBpu>().HasKey(item => new {item.IdBpu });
            modelBuilder.Entity<GmsBpu>().Property(item => item.IdBpu).IsRequired();
            modelBuilder.Entity<GmsBpu>().Property(item => item.IdBpu).HasColumnName("ID_BPU");
            modelBuilder.Entity<GmsBpu>().Property(item => item.CdUniteGmsUnite).HasMaxLength(12);
            modelBuilder.Entity<GmsBpu>().Property(item => item.CdUniteGmsUnite).HasColumnName("CD_UNITE_GMS__UNITE");
            modelBuilder.Entity<GmsBpu>().Property(item => item.CdTravauxGmsCode).IsRequired();
            modelBuilder.Entity<GmsBpu>().Property(item => item.CdTravauxGmsCode).HasMaxLength(60);
            modelBuilder.Entity<GmsBpu>().Property(item => item.CdTravauxGmsCode).HasColumnName("CD_TRAVAUX_GMS__CODE");
            modelBuilder.Entity<GmsBpu>().Property(item => item.Techn).IsRequired();
            modelBuilder.Entity<GmsBpu>().Property(item => item.Techn).HasMaxLength(255);
            modelBuilder.Entity<GmsBpu>().Property(item => item.Techn).HasColumnName("TECHN");
            modelBuilder.Entity<GmsBpu>().Property(item => item.Prix).HasColumnName("PRIX");
            modelBuilder.Entity<GmsBpu>().Property(item => item.DateMaj).HasColumnName("DATE_MAJ");
            modelBuilder.Entity<GmsBpu>().Property(item => item.Freq).HasColumnName("FREQ");
            modelBuilder.Entity<GmsBpu>().Property(item => item.PrecoVst).HasColumnName("PRECO_VST");
            modelBuilder.Entity<GmsBpu>().Property(item => item.RealisVst).HasColumnName("REALIS_VST");
            modelBuilder.Entity<GmsCdContrainte>().ToTable("CD_CONTRAINTE_GMS","GMS");
            modelBuilder.Entity<GmsCdContrainte>().HasKey(item => new {item.Type });
            modelBuilder.Entity<GmsCdContrainte>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<GmsCdContrainte>().Property(item => item.Type).HasMaxLength(100);
            modelBuilder.Entity<GmsCdContrainte>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<GmsCamp>().ToTable("CAMP_GMS","GMS");
            modelBuilder.Entity<GmsCamp>().HasKey(item => new {item.IdCamp });
            modelBuilder.Entity<GmsCamp>().Property(item => item.IdCamp).IsRequired();
            modelBuilder.Entity<GmsCamp>().Property(item => item.IdCamp).HasMaxLength(100);
            modelBuilder.Entity<GmsCamp>().Property(item => item.IdCamp).HasColumnName("ID_CAMP");
            modelBuilder.Entity<GmsCamp>().Property(item => item.CdTypePvGmsCode).IsRequired();
            modelBuilder.Entity<GmsCamp>().Property(item => item.CdTypePvGmsCode).HasMaxLength(15);
            modelBuilder.Entity<GmsCamp>().Property(item => item.CdTypePvGmsCode).HasColumnName("CD_TYPE_PV_GMS__CODE");
            modelBuilder.Entity<GmsCamp>().Property(item => item.CdPrestaGmsPrestataire).IsRequired();
            modelBuilder.Entity<GmsCamp>().Property(item => item.CdPrestaGmsPrestataire).HasMaxLength(50);
            modelBuilder.Entity<GmsCamp>().Property(item => item.CdPrestaGmsPrestataire).HasColumnName("CD_PRESTA_GMS__PRESTATAIRE");
            modelBuilder.Entity<GmsCamp>().Property(item => item.Annee).IsRequired();
            modelBuilder.Entity<GmsCamp>().Property(item => item.Annee).HasColumnName("ANNEE");
            modelBuilder.Entity<GmsCamp>().Property(item => item.Dater).IsRequired();
            modelBuilder.Entity<GmsCamp>().Property(item => item.Dater).HasColumnName("DATER");
            modelBuilder.Entity<GmsCamp>().Property(item => item.Dateg).HasColumnName("DATEG");
            modelBuilder.Entity<GmsCamp>().Property(item => item.Userg).HasMaxLength(2555);
            modelBuilder.Entity<GmsCamp>().Property(item => item.Userg).HasColumnName("USERG");
            modelBuilder.Entity<GmsCamp>().Property(item => item.Observ).HasMaxLength(255);
            modelBuilder.Entity<GmsCamp>().Property(item => item.Observ).HasColumnName("OBSERV");
            modelBuilder.Entity<GmsCdPresta>().ToTable("CD_PRESTA_GMS","GMS");
            modelBuilder.Entity<GmsCdPresta>().HasKey(item => new {item.Prestataire });
            modelBuilder.Entity<GmsCdPresta>().Property(item => item.Prestataire).IsRequired();
            modelBuilder.Entity<GmsCdPresta>().Property(item => item.Prestataire).HasMaxLength(50);
            modelBuilder.Entity<GmsCdPresta>().Property(item => item.Prestataire).HasColumnName("PRESTATAIRE");
            modelBuilder.Entity<GmsCdTypePv>().ToTable("CD_TYPE_PV_GMS","GMS");
            modelBuilder.Entity<GmsCdTypePv>().HasKey(item => new {item.Code });
            modelBuilder.Entity<GmsCdTypePv>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<GmsCdTypePv>().Property(item => item.Code).HasMaxLength(15);
            modelBuilder.Entity<GmsCdTypePv>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<GmsCdTypePv>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<GmsCdTypePv>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<GmsCdTypePv>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<GmsCdTypePv>().Property(item => item.Cycle).HasColumnName("CYCLE");
            modelBuilder.Entity<GmsCdTypePv>().Property(item => item.Cout).HasColumnName("COUT");
            modelBuilder.Entity<GmsPhotoEltInsp>().ToTable("PHOTO_ELT_INSP_GMS","GMS");
            modelBuilder.Entity<GmsPhotoEltInsp>().HasKey(item => new {item.GrpGmsIdGrp,item.PrtGmsIdPrt,item.SprtGmsIdSprt,item.EltGmsIdElem,item.CampGmsIdCamp,item.DscGmsNumGms,item.Id });
            modelBuilder.Entity<GmsPhotoEltInsp>().Property(item => item.GrpGmsIdGrp).IsRequired();
            modelBuilder.Entity<GmsPhotoEltInsp>().Property(item => item.GrpGmsIdGrp).HasColumnName("GRP_GMS__ID_GRP");
            modelBuilder.Entity<GmsPhotoEltInsp>().Property(item => item.PrtGmsIdPrt).IsRequired();
            modelBuilder.Entity<GmsPhotoEltInsp>().Property(item => item.PrtGmsIdPrt).HasColumnName("PRT_GMS__ID_PRT");
            modelBuilder.Entity<GmsPhotoEltInsp>().Property(item => item.SprtGmsIdSprt).IsRequired();
            modelBuilder.Entity<GmsPhotoEltInsp>().Property(item => item.SprtGmsIdSprt).HasColumnName("SPRT_GMS__ID_SPRT");
            modelBuilder.Entity<GmsPhotoEltInsp>().Property(item => item.EltGmsIdElem).IsRequired();
            modelBuilder.Entity<GmsPhotoEltInsp>().Property(item => item.EltGmsIdElem).HasColumnName("ELT_GMS__ID_ELEM");
            modelBuilder.Entity<GmsPhotoEltInsp>().Property(item => item.CampGmsIdCamp).IsRequired();
            modelBuilder.Entity<GmsPhotoEltInsp>().Property(item => item.CampGmsIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GmsPhotoEltInsp>().Property(item => item.CampGmsIdCamp).HasColumnName("CAMP_GMS__ID_CAMP");
            modelBuilder.Entity<GmsPhotoEltInsp>().Property(item => item.DscGmsNumGms).IsRequired();
            modelBuilder.Entity<GmsPhotoEltInsp>().Property(item => item.DscGmsNumGms).HasMaxLength(17);
            modelBuilder.Entity<GmsPhotoEltInsp>().Property(item => item.DscGmsNumGms).HasColumnName("DSC_GMS__NUM_GMS");
            modelBuilder.Entity<GmsPhotoEltInsp>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<GmsPhotoEltInsp>().Property(item => item.Id).HasMaxLength(50);
            modelBuilder.Entity<GmsPhotoEltInsp>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<GmsPhotoEltInsp>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<GmsPhotoEltInsp>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<GmsInsp>().ToTable("INSP_GMS","GMS");
            modelBuilder.Entity<GmsInsp>().HasKey(item => new {item.CampGmsIdCamp,item.DscGmsNumGms });
            modelBuilder.Entity<GmsInsp>().Property(item => item.CampGmsIdCamp).IsRequired();
            modelBuilder.Entity<GmsInsp>().Property(item => item.CampGmsIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GmsInsp>().Property(item => item.CampGmsIdCamp).HasColumnName("CAMP_GMS__ID_CAMP");
            modelBuilder.Entity<GmsInsp>().Property(item => item.DscGmsNumGms).IsRequired();
            modelBuilder.Entity<GmsInsp>().Property(item => item.DscGmsNumGms).HasMaxLength(17);
            modelBuilder.Entity<GmsInsp>().Property(item => item.DscGmsNumGms).HasColumnName("DSC_GMS__NUM_GMS");
            modelBuilder.Entity<GmsInsp>().Property(item => item.CdEtudeGmsEtude).HasMaxLength(65);
            modelBuilder.Entity<GmsInsp>().Property(item => item.CdEtudeGmsEtude).HasColumnName("CD_ETUDE_GMS__ETUDE");
            modelBuilder.Entity<GmsInsp>().Property(item => item.InspecteurGmsNom).HasMaxLength(60);
            modelBuilder.Entity<GmsInsp>().Property(item => item.InspecteurGmsNom).HasColumnName("INSPECTEUR_GMS__NOM");
            modelBuilder.Entity<GmsInsp>().Property(item => item.CdMeteoGmsMeteo).HasMaxLength(60);
            modelBuilder.Entity<GmsInsp>().Property(item => item.CdMeteoGmsMeteo).HasColumnName("CD_METEO_GMS__METEO");
            modelBuilder.Entity<GmsInsp>().Property(item => item.Etat).IsRequired();
            modelBuilder.Entity<GmsInsp>().Property(item => item.Etat).HasMaxLength(25);
            modelBuilder.Entity<GmsInsp>().Property(item => item.Etat).HasColumnName("ETAT");
            modelBuilder.Entity<GmsInsp>().Property(item => item.Datev).HasColumnName("DATEV");
            modelBuilder.Entity<GmsInsp>().Property(item => item.Temperature).HasColumnName("TEMPERATURE");
            modelBuilder.Entity<GmsInsp>().Property(item => item.Moyen).HasMaxLength(500);
            modelBuilder.Entity<GmsInsp>().Property(item => item.Moyen).HasColumnName("MOYEN");
            modelBuilder.Entity<GmsInsp>().Property(item => item.Conditions).HasMaxLength(500);
            modelBuilder.Entity<GmsInsp>().Property(item => item.Conditions).HasColumnName("CONDITIONS");
            modelBuilder.Entity<GmsInsp>().Property(item => item.DateValid).HasColumnName("DATE_VALID");
            modelBuilder.Entity<GmsInsp>().Property(item => item.NomValid).HasMaxLength(255);
            modelBuilder.Entity<GmsInsp>().Property(item => item.NomValid).HasColumnName("NOM_VALID");
            modelBuilder.Entity<GmsInsp>().Property(item => item.DescInva).HasMaxLength(1000);
            modelBuilder.Entity<GmsInsp>().Property(item => item.DescInva).HasColumnName("DESC_INVA");
            modelBuilder.Entity<GmsInsp>().Property(item => item.Securite).HasMaxLength(1000);
            modelBuilder.Entity<GmsInsp>().Property(item => item.Securite).HasColumnName("SECURITE");
            modelBuilder.Entity<GmsInsp>().Property(item => item.Prioritaire).HasMaxLength(1000);
            modelBuilder.Entity<GmsInsp>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<GmsInsp>().Property(item => item.Note1).HasColumnName("NOTE1");
            modelBuilder.Entity<GmsInsp>().Property(item => item.Note2).HasColumnName("NOTE2");
            modelBuilder.Entity<GmsInsp>().Property(item => item.Note3).HasColumnName("NOTE3");
            modelBuilder.Entity<GmsInsp>().Property(item => item.Note4).HasColumnName("NOTE4");
            modelBuilder.Entity<GmsInsp>().Property(item => item.Note5).HasColumnName("NOTE5");
            modelBuilder.Entity<GmsInsp>().Property(item => item.Urgence).HasMaxLength(5);
            modelBuilder.Entity<GmsInsp>().Property(item => item.Urgence).HasColumnName("URGENCE");
            modelBuilder.Entity<GmsInsp>().Property(item => item.Qualite).HasMaxLength(25);
            modelBuilder.Entity<GmsInsp>().Property(item => item.Qualite).HasColumnName("QUALITE");
            modelBuilder.Entity<GmsPhotoInsp>().ToTable("PHOTO_INSP_GMS","GMS");
            modelBuilder.Entity<GmsPhotoInsp>().HasKey(item => new {item.Id });
            modelBuilder.Entity<GmsPhotoInsp>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<GmsPhotoInsp>().Property(item => item.Id).HasMaxLength(30);
            modelBuilder.Entity<GmsPhotoInsp>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<GmsPhotoInsp>().Property(item => item.CampGmsIdCamp).IsRequired();
            modelBuilder.Entity<GmsPhotoInsp>().Property(item => item.CampGmsIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GmsPhotoInsp>().Property(item => item.CampGmsIdCamp).HasColumnName("CAMP_GMS__ID_CAMP");
            modelBuilder.Entity<GmsPhotoInsp>().Property(item => item.DscGmsNumGms).IsRequired();
            modelBuilder.Entity<GmsPhotoInsp>().Property(item => item.DscGmsNumGms).HasMaxLength(17);
            modelBuilder.Entity<GmsPhotoInsp>().Property(item => item.DscGmsNumGms).HasColumnName("DSC_GMS__NUM_GMS");
            modelBuilder.Entity<GmsPhotoInsp>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<GmsPhotoInsp>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<GmsCdEtude>().ToTable("CD_ETUDE_GMS","GMS");
            modelBuilder.Entity<GmsCdEtude>().HasKey(item => new {item.Etude });
            modelBuilder.Entity<GmsCdEtude>().Property(item => item.Etude).IsRequired();
            modelBuilder.Entity<GmsCdEtude>().Property(item => item.Etude).HasMaxLength(65);
            modelBuilder.Entity<GmsCdEtude>().Property(item => item.Etude).HasColumnName("ETUDE");
            modelBuilder.Entity<GmsSeuilQualite>().ToTable("SEUIL_QUALITE_GMS","GMS");
            modelBuilder.Entity<GmsSeuilQualite>().HasKey(item => new {item.CdQualiteGmsQualite,item.IndiceUrgence });
            modelBuilder.Entity<GmsSeuilQualite>().Property(item => item.CdQualiteGmsQualite).IsRequired();
            modelBuilder.Entity<GmsSeuilQualite>().Property(item => item.CdQualiteGmsQualite).HasMaxLength(25);
            modelBuilder.Entity<GmsSeuilQualite>().Property(item => item.CdQualiteGmsQualite).HasColumnName("CD_QUALITE_GMS__QUALITE");
            modelBuilder.Entity<GmsSeuilQualite>().Property(item => item.IndiceUrgence).IsRequired();
            modelBuilder.Entity<GmsSeuilQualite>().Property(item => item.IndiceUrgence).HasMaxLength(5);
            modelBuilder.Entity<GmsSeuilQualite>().Property(item => item.IndiceUrgence).HasColumnName("INDICE_URGENCE");
            modelBuilder.Entity<GmsSeuilUrgence>().ToTable("SEUIL_URGENCE_GMS","GMS");
            modelBuilder.Entity<GmsSeuilUrgence>().HasKey(item => new {item.Ordre });
            modelBuilder.Entity<GmsSeuilUrgence>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<GmsSeuilUrgence>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<GmsSeuilUrgence>().Property(item => item.NbrNote).HasColumnName("NBR_NOTE");
            modelBuilder.Entity<GmsSeuilUrgence>().Property(item => item.ValNote).HasColumnName("VAL_NOTE");
            modelBuilder.Entity<GmsSeuilUrgence>().Property(item => item.Indice).HasColumnName("INDICE");
            modelBuilder.Entity<GmsSprtVst>().ToTable("SPRT_VST_GMS","GMS");
            modelBuilder.Entity<GmsSprtVst>().HasKey(item => new {item.CampGmsIdCamp,item.DscGmsNumGms,item.CdChapitreGmsIdChap,item.CdLigneGmsIdLigne });
            modelBuilder.Entity<GmsSprtVst>().Property(item => item.CampGmsIdCamp).IsRequired();
            modelBuilder.Entity<GmsSprtVst>().Property(item => item.CampGmsIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GmsSprtVst>().Property(item => item.CampGmsIdCamp).HasColumnName("CAMP_GMS__ID_CAMP");
            modelBuilder.Entity<GmsSprtVst>().Property(item => item.DscGmsNumGms).IsRequired();
            modelBuilder.Entity<GmsSprtVst>().Property(item => item.DscGmsNumGms).HasMaxLength(17);
            modelBuilder.Entity<GmsSprtVst>().Property(item => item.DscGmsNumGms).HasColumnName("DSC_GMS__NUM_GMS");
            modelBuilder.Entity<GmsSprtVst>().Property(item => item.CdChapitreGmsIdChap).IsRequired();
            modelBuilder.Entity<GmsSprtVst>().Property(item => item.CdChapitreGmsIdChap).HasColumnName("CD_CHAPITRE_GMS__ID_CHAP");
            modelBuilder.Entity<GmsSprtVst>().Property(item => item.CdLigneGmsIdLigne).IsRequired();
            modelBuilder.Entity<GmsSprtVst>().Property(item => item.CdLigneGmsIdLigne).HasColumnName("CD_LIGNE_GMS__ID_LIGNE");
            modelBuilder.Entity<GmsSprtVst>().Property(item => item.Indice).IsRequired();
            modelBuilder.Entity<GmsSprtVst>().Property(item => item.Indice).HasColumnName("INDICE");
            modelBuilder.Entity<GmsSprtVst>().Property(item => item.Obs).HasMaxLength(500);
            modelBuilder.Entity<GmsSprtVst>().Property(item => item.Obs).HasColumnName("OBS");
            modelBuilder.Entity<GmsPhotoSprtVst>().ToTable("PHOTO_SPRT_VST_GMS","GMS");
            modelBuilder.Entity<GmsPhotoSprtVst>().HasKey(item => new {item.CampGmsIdCamp,item.DscGmsNumGms,item.CdChapitreGmsIdChap,item.CdLigneGmsIdLigne,item.Id });
            modelBuilder.Entity<GmsPhotoSprtVst>().Property(item => item.CampGmsIdCamp).IsRequired();
            modelBuilder.Entity<GmsPhotoSprtVst>().Property(item => item.CampGmsIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GmsPhotoSprtVst>().Property(item => item.CampGmsIdCamp).HasColumnName("CAMP_GMS__ID_CAMP");
            modelBuilder.Entity<GmsPhotoSprtVst>().Property(item => item.DscGmsNumGms).IsRequired();
            modelBuilder.Entity<GmsPhotoSprtVst>().Property(item => item.DscGmsNumGms).HasMaxLength(17);
            modelBuilder.Entity<GmsPhotoSprtVst>().Property(item => item.DscGmsNumGms).HasColumnName("DSC_GMS__NUM_GMS");
            modelBuilder.Entity<GmsPhotoSprtVst>().Property(item => item.CdChapitreGmsIdChap).IsRequired();
            modelBuilder.Entity<GmsPhotoSprtVst>().Property(item => item.CdChapitreGmsIdChap).HasColumnName("CD_CHAPITRE_GMS__ID_CHAP");
            modelBuilder.Entity<GmsPhotoSprtVst>().Property(item => item.CdLigneGmsIdLigne).IsRequired();
            modelBuilder.Entity<GmsPhotoSprtVst>().Property(item => item.CdLigneGmsIdLigne).HasColumnName("CD_LIGNE_GMS__ID_LIGNE");
            modelBuilder.Entity<GmsPhotoSprtVst>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<GmsPhotoSprtVst>().Property(item => item.Id).HasMaxLength(50);
            modelBuilder.Entity<GmsPhotoSprtVst>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<GmsPhotoSprtVst>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<GmsPhotoSprtVst>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<GmsPhotoVst>().ToTable("PHOTO_VST_GMS","GMS");
            modelBuilder.Entity<GmsPhotoVst>().HasKey(item => new {item.Id });
            modelBuilder.Entity<GmsPhotoVst>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<GmsPhotoVst>().Property(item => item.Id).HasMaxLength(30);
            modelBuilder.Entity<GmsPhotoVst>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<GmsPhotoVst>().Property(item => item.CampGmsIdCamp).IsRequired();
            modelBuilder.Entity<GmsPhotoVst>().Property(item => item.CampGmsIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GmsPhotoVst>().Property(item => item.CampGmsIdCamp).HasColumnName("CAMP_GMS__ID_CAMP");
            modelBuilder.Entity<GmsPhotoVst>().Property(item => item.DscGmsNumGms).IsRequired();
            modelBuilder.Entity<GmsPhotoVst>().Property(item => item.DscGmsNumGms).HasMaxLength(17);
            modelBuilder.Entity<GmsPhotoVst>().Property(item => item.DscGmsNumGms).HasColumnName("DSC_GMS__NUM_GMS");
            modelBuilder.Entity<GmsPhotoVst>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<GmsPhotoVst>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<GmsCdPosPan>().ToTable("CD_POS_PAN_GMS","GMS");
            modelBuilder.Entity<GmsCdPosPan>().HasKey(item => new {item.Posit });
            modelBuilder.Entity<GmsCdPosPan>().Property(item => item.Posit).IsRequired();
            modelBuilder.Entity<GmsCdPosPan>().Property(item => item.Posit).HasMaxLength(4);
            modelBuilder.Entity<GmsCdPosPan>().Property(item => item.Posit).HasColumnName("POSIT");
            modelBuilder.Entity<GmsCdPosPan>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<GmsCdPosPan>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<GmsCdPosMat>().ToTable("CD_POS_MAT_GMS","GMS");
            modelBuilder.Entity<GmsCdPosMat>().HasKey(item => new {item.Posit });
            modelBuilder.Entity<GmsCdPosMat>().Property(item => item.Posit).IsRequired();
            modelBuilder.Entity<GmsCdPosMat>().Property(item => item.Posit).HasMaxLength(4);
            modelBuilder.Entity<GmsCdPosMat>().Property(item => item.Posit).HasColumnName("POSIT");
            modelBuilder.Entity<GmsCdPosMat>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<GmsCdPosMat>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<GmsCdQualite>().ToTable("CD_QUALITE_GMS","GMS");
            modelBuilder.Entity<GmsCdQualite>().HasKey(item => new {item.Qualite });
            modelBuilder.Entity<GmsCdQualite>().Property(item => item.Qualite).IsRequired();
            modelBuilder.Entity<GmsCdQualite>().Property(item => item.Qualite).HasMaxLength(25);
            modelBuilder.Entity<GmsCdQualite>().Property(item => item.Qualite).HasColumnName("QUALITE");
            modelBuilder.Entity<GmsCdProtec>().ToTable("CD_PROTEC_GMS","GMS");
            modelBuilder.Entity<GmsCdProtec>().HasKey(item => new {item.Protec });
            modelBuilder.Entity<GmsCdProtec>().Property(item => item.Protec).IsRequired();
            modelBuilder.Entity<GmsCdProtec>().Property(item => item.Protec).HasMaxLength(60);
            modelBuilder.Entity<GmsCdProtec>().Property(item => item.Protec).HasColumnName("PROTEC");
            modelBuilder.Entity<GmsHistoNote>().ToTable("HISTO_NOTE_GMS","GMS");
            modelBuilder.Entity<GmsHistoNote>().HasKey(item => new {item.DscGmsNumGms,item.DateNote });
            modelBuilder.Entity<GmsHistoNote>().Property(item => item.DscGmsNumGms).IsRequired();
            modelBuilder.Entity<GmsHistoNote>().Property(item => item.DscGmsNumGms).HasMaxLength(17);
            modelBuilder.Entity<GmsHistoNote>().Property(item => item.DscGmsNumGms).HasColumnName("DSC_GMS__NUM_GMS");
            modelBuilder.Entity<GmsHistoNote>().Property(item => item.DateNote).IsRequired();
            modelBuilder.Entity<GmsHistoNote>().Property(item => item.DateNote).HasColumnName("DATE_NOTE");
            modelBuilder.Entity<GmsHistoNote>().Property(item => item.CdOriginGmsOrigine).IsRequired();
            modelBuilder.Entity<GmsHistoNote>().Property(item => item.CdOriginGmsOrigine).HasMaxLength(20);
            modelBuilder.Entity<GmsHistoNote>().Property(item => item.CdOriginGmsOrigine).HasColumnName("CD_ORIGIN_GMS__ORIGINE");
            modelBuilder.Entity<GmsHistoNote>().Property(item => item.Note1).HasColumnName("NOTE1");
            modelBuilder.Entity<GmsHistoNote>().Property(item => item.Note2).HasColumnName("NOTE2");
            modelBuilder.Entity<GmsHistoNote>().Property(item => item.Note3).HasColumnName("NOTE3");
            modelBuilder.Entity<GmsHistoNote>().Property(item => item.Note4).HasColumnName("NOTE4");
            modelBuilder.Entity<GmsHistoNote>().Property(item => item.Note5).HasColumnName("NOTE5");
            modelBuilder.Entity<GmsHistoNote>().Property(item => item.Urgence).HasMaxLength(5);
            modelBuilder.Entity<GmsHistoNote>().Property(item => item.Urgence).HasColumnName("URGENCE");
            modelBuilder.Entity<GmsHistoNote>().Property(item => item.Securite).HasColumnName("SECURITE");
            modelBuilder.Entity<GmsHistoNote>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<GmsCdOrigin>().ToTable("CD_ORIGIN_GMS","GMS");
            modelBuilder.Entity<GmsCdOrigin>().HasKey(item => new {item.Origine });
            modelBuilder.Entity<GmsCdOrigin>().Property(item => item.Origine).IsRequired();
            modelBuilder.Entity<GmsCdOrigin>().Property(item => item.Origine).HasMaxLength(20);
            modelBuilder.Entity<GmsCdOrigin>().Property(item => item.Origine).HasColumnName("ORIGINE");
            modelBuilder.Entity<GmsDictionnaire>().ToTable("DICTIONNAIRE_GMS","GMS");
            modelBuilder.Entity<GmsDictionnaire>().HasKey(item => new {item.Nom });
            modelBuilder.Entity<GmsDictionnaire>().Property(item => item.Nom).IsRequired();
            modelBuilder.Entity<GmsDictionnaire>().Property(item => item.Nom).HasMaxLength(100);
            modelBuilder.Entity<GmsDictionnaire>().Property(item => item.Nom).HasColumnName("NOM");
            modelBuilder.Entity<GmsDictionnaire>().Property(item => item.Description).HasMaxLength(255);
            modelBuilder.Entity<GmsDictionnaire>().Property(item => item.Description).HasColumnName("DESCRIPTION");
            modelBuilder.Entity<GmsDictionnaire>().Property(item => item.Definition).HasMaxLength(500);
            modelBuilder.Entity<GmsDictionnaire>().Property(item => item.Definition).HasColumnName("DEFINITION");
            modelBuilder.Entity<GmsDictionnaire>().Property(item => item.Motscles).HasMaxLength(255);
            modelBuilder.Entity<GmsDictionnaire>().Property(item => item.Motscles).HasColumnName("MOTSCLES");
            modelBuilder.Entity<GmsCdEvt>().ToTable("CD_EVT_GMS","GMS");
            modelBuilder.Entity<GmsCdEvt>().HasKey(item => new {item.Type });
            modelBuilder.Entity<GmsCdEvt>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<GmsCdEvt>().Property(item => item.Type).HasMaxLength(25);
            modelBuilder.Entity<GmsCdEvt>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<GmsCdEvt>().Property(item => item.Impact).HasColumnName("IMPACT");
            modelBuilder.Entity<GmsEvt>().ToTable("EVT_GMS","GMS");
            modelBuilder.Entity<GmsEvt>().HasKey(item => new {item.CdEvtGmsType,item.DscGmsNumGms,item.DateRel });
            modelBuilder.Entity<GmsEvt>().Property(item => item.CdEvtGmsType).IsRequired();
            modelBuilder.Entity<GmsEvt>().Property(item => item.CdEvtGmsType).HasMaxLength(25);
            modelBuilder.Entity<GmsEvt>().Property(item => item.CdEvtGmsType).HasColumnName("CD_EVT_GMS__TYPE");
            modelBuilder.Entity<GmsEvt>().Property(item => item.DscGmsNumGms).IsRequired();
            modelBuilder.Entity<GmsEvt>().Property(item => item.DscGmsNumGms).HasMaxLength(17);
            modelBuilder.Entity<GmsEvt>().Property(item => item.DscGmsNumGms).HasColumnName("DSC_GMS__NUM_GMS");
            modelBuilder.Entity<GmsEvt>().Property(item => item.DateRel).IsRequired();
            modelBuilder.Entity<GmsEvt>().Property(item => item.DateRel).HasColumnName("DATE_REL");
            modelBuilder.Entity<GmsEvt>().Property(item => item.DateTrt).HasColumnName("DATE_TRT");
            modelBuilder.Entity<GmsEvt>().Property(item => item.Obsv).HasMaxLength(255);
            modelBuilder.Entity<GmsEvt>().Property(item => item.Obsv).HasColumnName("OBSV");
            modelBuilder.Entity<GmsCdInterface>().ToTable("CD_INTERFACE_GMS","GMS");
            modelBuilder.Entity<GmsCdInterface>().HasKey(item => new {item.Type });
            modelBuilder.Entity<GmsCdInterface>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<GmsCdInterface>().Property(item => item.Type).HasMaxLength(60);
            modelBuilder.Entity<GmsCdInterface>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<GmsCdInterface>().Property(item => item.Frequence).HasColumnName("FREQUENCE");
            modelBuilder.Entity<GmsCdFournisseur>().ToTable("CD_FOURNISSEUR_GMS","GMS");
            modelBuilder.Entity<GmsCdFournisseur>().HasKey(item => new {item.Nom });
            modelBuilder.Entity<GmsCdFournisseur>().Property(item => item.Nom).IsRequired();
            modelBuilder.Entity<GmsCdFournisseur>().Property(item => item.Nom).HasMaxLength(60);
            modelBuilder.Entity<GmsCdFournisseur>().Property(item => item.Nom).HasColumnName("NOM");
            modelBuilder.Entity<GmsCdPoteau>().ToTable("CD_POTEAU_GMS","GMS");
            modelBuilder.Entity<GmsCdPoteau>().HasKey(item => new {item.Type });
            modelBuilder.Entity<GmsCdPoteau>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<GmsCdPoteau>().Property(item => item.Type).HasMaxLength(60);
            modelBuilder.Entity<GmsCdPoteau>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<GmsCdPoteau>().Property(item => item.Garantie).HasColumnName("GARANTIE");
            modelBuilder.Entity<GmsCdPoteau>().Property(item => item.Dvt).HasColumnName("DVT");
            modelBuilder.Entity<GmsCdEntete>().ToTable("CD_ENTETE_GMS","GMS");
            modelBuilder.Entity<GmsCdEntete>().HasKey(item => new {item.IdEntete });
            modelBuilder.Entity<GmsCdEntete>().Property(item => item.IdEntete).IsRequired();
            modelBuilder.Entity<GmsCdEntete>().Property(item => item.IdEntete).HasColumnName("ID_ENTETE");
            modelBuilder.Entity<GmsCdEntete>().Property(item => item.CdComposantGmsTypeComp).IsRequired();
            modelBuilder.Entity<GmsCdEntete>().Property(item => item.CdComposantGmsTypeComp).HasMaxLength(6);
            modelBuilder.Entity<GmsCdEntete>().Property(item => item.CdComposantGmsTypeComp).HasColumnName("CD_COMPOSANT_GMS__TYPE_COMP");
            modelBuilder.Entity<GmsCdEntete>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<GmsCdEntete>().Property(item => item.Libelle).HasMaxLength(500);
            modelBuilder.Entity<GmsCdEntete>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<GmsCdEntete>().Property(item => item.OrdreEnt).IsRequired();
            modelBuilder.Entity<GmsCdEntete>().Property(item => item.OrdreEnt).HasColumnName("ORDRE_ENT");
            modelBuilder.Entity<GmsCdEntete>().Property(item => item.Guide).HasMaxLength(500);
            modelBuilder.Entity<GmsCdEntete>().Property(item => item.Guide).HasColumnName("GUIDE");
            modelBuilder.Entity<GmsCdChapitre>().ToTable("CD_CHAPITRE_GMS","GMS");
            modelBuilder.Entity<GmsCdChapitre>().HasKey(item => new {item.IdChap });
            modelBuilder.Entity<GmsCdChapitre>().Property(item => item.IdChap).IsRequired();
            modelBuilder.Entity<GmsCdChapitre>().Property(item => item.IdChap).HasColumnName("ID_CHAP");
            modelBuilder.Entity<GmsCdChapitre>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<GmsCdChapitre>().Property(item => item.Libelle).HasMaxLength(500);
            modelBuilder.Entity<GmsCdChapitre>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<GmsCdChapitre>().Property(item => item.OrdreChap).IsRequired();
            modelBuilder.Entity<GmsCdChapitre>().Property(item => item.OrdreChap).HasColumnName("ORDRE_CHAP");
            modelBuilder.Entity<GmsCdChapitre>().Property(item => item.Ponderation).HasColumnName("PONDERATION");
            modelBuilder.Entity<GmsCdLigne>().ToTable("CD_LIGNE_GMS","GMS");
            modelBuilder.Entity<GmsCdLigne>().HasKey(item => new {item.CdChapitreGmsIdChap,item.IdLigne });
            modelBuilder.Entity<GmsCdLigne>().Property(item => item.CdChapitreGmsIdChap).IsRequired();
            modelBuilder.Entity<GmsCdLigne>().Property(item => item.CdChapitreGmsIdChap).HasColumnName("CD_CHAPITRE_GMS__ID_CHAP");
            modelBuilder.Entity<GmsCdLigne>().Property(item => item.IdLigne).IsRequired();
            modelBuilder.Entity<GmsCdLigne>().Property(item => item.IdLigne).HasColumnName("ID_LIGNE");
            modelBuilder.Entity<GmsCdLigne>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<GmsCdLigne>().Property(item => item.Libelle).HasMaxLength(500);
            modelBuilder.Entity<GmsCdLigne>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<GmsCdLigne>().Property(item => item.OrdreLigne).HasColumnName("ORDRE_LIGNE");
            modelBuilder.Entity<GmsEntete>().ToTable("ENTETE_GMS","GMS");
            modelBuilder.Entity<GmsEntete>().HasKey(item => new {item.CampGmsIdCamp,item.DscGmsNumGms,item.CdEnteteGmsIdEntete });
            modelBuilder.Entity<GmsEntete>().Property(item => item.CampGmsIdCamp).IsRequired();
            modelBuilder.Entity<GmsEntete>().Property(item => item.CampGmsIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GmsEntete>().Property(item => item.CampGmsIdCamp).HasColumnName("CAMP_GMS__ID_CAMP");
            modelBuilder.Entity<GmsEntete>().Property(item => item.DscGmsNumGms).IsRequired();
            modelBuilder.Entity<GmsEntete>().Property(item => item.DscGmsNumGms).HasMaxLength(17);
            modelBuilder.Entity<GmsEntete>().Property(item => item.DscGmsNumGms).HasColumnName("DSC_GMS__NUM_GMS");
            modelBuilder.Entity<GmsEntete>().Property(item => item.CdEnteteGmsIdEntete).IsRequired();
            modelBuilder.Entity<GmsEntete>().Property(item => item.CdEnteteGmsIdEntete).HasColumnName("CD_ENTETE_GMS__ID_ENTETE");
            modelBuilder.Entity<GmsEntete>().Property(item => item.Valeur).HasMaxLength(250);
            modelBuilder.Entity<GmsEntete>().Property(item => item.Valeur).HasColumnName("VALEUR");
            modelBuilder.Entity<GmsContact>().ToTable("CONTACT_GMS","GMS");
            modelBuilder.Entity<GmsContact>().HasKey(item => new {item.DocGmsId });
            modelBuilder.Entity<GmsContact>().Property(item => item.DocGmsId).IsRequired();
            modelBuilder.Entity<GmsContact>().Property(item => item.DocGmsId).HasColumnName("DOC_GMS__ID");
            modelBuilder.Entity<GmsContact>().Property(item => item.Givenname).HasMaxLength(60);
            modelBuilder.Entity<GmsContact>().Property(item => item.Givenname).HasColumnName("GIVENNAME");
            modelBuilder.Entity<GmsContact>().Property(item => item.Sn).HasMaxLength(60);
            modelBuilder.Entity<GmsContact>().Property(item => item.Sn).HasColumnName("SN");
            modelBuilder.Entity<GmsContact>().Property(item => item.Cn).HasMaxLength(125);
            modelBuilder.Entity<GmsContact>().Property(item => item.Cn).HasColumnName("CN");
            modelBuilder.Entity<GmsContact>().Property(item => item.O).HasMaxLength(60);
            modelBuilder.Entity<GmsContact>().Property(item => item.O).HasColumnName("O");
            modelBuilder.Entity<GmsContact>().Property(item => item.Mail).HasMaxLength(60);
            modelBuilder.Entity<GmsContact>().Property(item => item.Mail).HasColumnName("MAIL");
            modelBuilder.Entity<GmsContact>().Property(item => item.Telephonenumber).HasMaxLength(20);
            modelBuilder.Entity<GmsContact>().Property(item => item.Telephonenumber).HasColumnName("TELEPHONENUMBER");
            modelBuilder.Entity<GmsContact>().Property(item => item.Mobile).HasMaxLength(20);
            modelBuilder.Entity<GmsContact>().Property(item => item.Mobile).HasColumnName("MOBILE");
            modelBuilder.Entity<GmsContact>().Property(item => item.Facsimiletelephonenumber).HasMaxLength(20);
            modelBuilder.Entity<GmsContact>().Property(item => item.Facsimiletelephonenumber).HasColumnName("FACSIMILETELEPHONENUMBER");
            modelBuilder.Entity<GmsContact>().Property(item => item.Street).HasMaxLength(60);
            modelBuilder.Entity<GmsContact>().Property(item => item.Street).HasColumnName("STREET");
            modelBuilder.Entity<GmsContact>().Property(item => item.Mozillaworkstreet2).HasMaxLength(60);
            modelBuilder.Entity<GmsContact>().Property(item => item.Mozillaworkstreet2).HasColumnName("MOZILLAWORKSTREET2");
            modelBuilder.Entity<GmsContact>().Property(item => item.L).HasMaxLength(60);
            modelBuilder.Entity<GmsContact>().Property(item => item.L).HasColumnName("L");
            modelBuilder.Entity<GmsContact>().Property(item => item.Postalcode).HasMaxLength(12);
            modelBuilder.Entity<GmsContact>().Property(item => item.Postalcode).HasColumnName("POSTALCODE");
            modelBuilder.Entity<GmsContact>().Property(item => item.Modifytimestamp).HasColumnName("MODIFYTIMESTAMP");
            modelBuilder.Entity<GmsCdUnite>().ToTable("CD_UNITE_GMS","GMS");
            modelBuilder.Entity<GmsCdUnite>().HasKey(item => new {item.Unite });
            modelBuilder.Entity<GmsCdUnite>().Property(item => item.Unite).IsRequired();
            modelBuilder.Entity<GmsCdUnite>().Property(item => item.Unite).HasMaxLength(12);
            modelBuilder.Entity<GmsCdUnite>().Property(item => item.Unite).HasColumnName("UNITE");
            modelBuilder.Entity<GmsInspecteur>().ToTable("INSPECTEUR_GMS","GMS");
            modelBuilder.Entity<GmsInspecteur>().HasKey(item => new {item.Nom });
            modelBuilder.Entity<GmsInspecteur>().Property(item => item.Nom).IsRequired();
            modelBuilder.Entity<GmsInspecteur>().Property(item => item.Nom).HasMaxLength(60);
            modelBuilder.Entity<GmsInspecteur>().Property(item => item.Nom).HasColumnName("NOM");
            modelBuilder.Entity<GmsInspecteur>().Property(item => item.CdPrestaGmsPrestataire).IsRequired();
            modelBuilder.Entity<GmsInspecteur>().Property(item => item.CdPrestaGmsPrestataire).HasMaxLength(50);
            modelBuilder.Entity<GmsInspecteur>().Property(item => item.CdPrestaGmsPrestataire).HasColumnName("CD_PRESTA_GMS__PRESTATAIRE");
            modelBuilder.Entity<GmsInspecteur>().Property(item => item.Fonc).HasMaxLength(60);
            modelBuilder.Entity<GmsInspecteur>().Property(item => item.Fonc).HasColumnName("FONC");
            modelBuilder.Entity<GmsCdComposant>().ToTable("CD_COMPOSANT_GMS","GMS");
            modelBuilder.Entity<GmsCdComposant>().HasKey(item => new {item.TypeComp });
            modelBuilder.Entity<GmsCdComposant>().Property(item => item.TypeComp).IsRequired();
            modelBuilder.Entity<GmsCdComposant>().Property(item => item.TypeComp).HasMaxLength(6);
            modelBuilder.Entity<GmsCdComposant>().Property(item => item.TypeComp).HasColumnName("TYPE_COMP");
            modelBuilder.Entity<GmsCdComposant>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<GmsCdComposant>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<GmsVst>().ToTable("VST_GMS","GMS");
            modelBuilder.Entity<GmsVst>().HasKey(item => new {item.CampGmsIdCamp,item.DscGmsNumGms });
            modelBuilder.Entity<GmsVst>().Property(item => item.CampGmsIdCamp).IsRequired();
            modelBuilder.Entity<GmsVst>().Property(item => item.CampGmsIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GmsVst>().Property(item => item.CampGmsIdCamp).HasColumnName("CAMP_GMS__ID_CAMP");
            modelBuilder.Entity<GmsVst>().Property(item => item.DscGmsNumGms).IsRequired();
            modelBuilder.Entity<GmsVst>().Property(item => item.DscGmsNumGms).HasMaxLength(17);
            modelBuilder.Entity<GmsVst>().Property(item => item.DscGmsNumGms).HasColumnName("DSC_GMS__NUM_GMS");
            modelBuilder.Entity<GmsVst>().Property(item => item.InspecteurGmsNom).HasMaxLength(60);
            modelBuilder.Entity<GmsVst>().Property(item => item.InspecteurGmsNom).HasColumnName("INSPECTEUR_GMS__NOM");
            modelBuilder.Entity<GmsVst>().Property(item => item.Etat).IsRequired();
            modelBuilder.Entity<GmsVst>().Property(item => item.Etat).HasMaxLength(25);
            modelBuilder.Entity<GmsVst>().Property(item => item.Etat).HasColumnName("ETAT");
            modelBuilder.Entity<GmsVst>().Property(item => item.Datev).HasColumnName("DATEV");
            modelBuilder.Entity<GmsVst>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<GmsVst>().Property(item => item.Observ).HasMaxLength(500);
            modelBuilder.Entity<GmsVst>().Property(item => item.Observ).HasColumnName("OBSERV");
            modelBuilder.Entity<GmsVst>().Property(item => item.NoteVst).HasMaxLength(5);
            modelBuilder.Entity<GmsVst>().Property(item => item.NoteVst).HasColumnName("NOTE_VST");
            modelBuilder.Entity<GmsCdConclusion>().ToTable("CD_CONCLUSION_GMS","GMS");
            modelBuilder.Entity<GmsCdConclusion>().HasKey(item => new {item.IdConc });
            modelBuilder.Entity<GmsCdConclusion>().Property(item => item.IdConc).IsRequired();
            modelBuilder.Entity<GmsCdConclusion>().Property(item => item.IdConc).HasColumnName("ID_CONC");
            modelBuilder.Entity<GmsCdConclusion>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<GmsCdConclusion>().Property(item => item.Libelle).HasMaxLength(500);
            modelBuilder.Entity<GmsCdConclusion>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<GmsCdConclusion>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<GmsCdConclusion>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<GmsDscTemp>().ToTable("DSC_TEMP_GMS","GMS");
            modelBuilder.Entity<GmsDscTemp>().HasKey(item => new {item.CampGmsIdCamp,item.NumGms });
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.CampGmsIdCamp).IsRequired();
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.CampGmsIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.CampGmsIdCamp).HasColumnName("CAMP_GMS__ID_CAMP");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.NumGms).IsRequired();
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.NumGms).HasMaxLength(17);
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.NumGms).HasColumnName("NUM_GMS");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.CdFournisseurGmsNom).HasMaxLength(60);
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.CdFournisseurGmsNom).HasColumnName("CD_FOURNISSEUR_GMS__NOM");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.CdPosMatGmsPosit).IsRequired();
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.CdPosMatGmsPosit).HasMaxLength(4);
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.CdPosMatGmsPosit).HasColumnName("CD_POS_MAT_GMS__POSIT");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.CdInterfaceGmsType).HasMaxLength(60);
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.CdInterfaceGmsType).HasColumnName("CD_INTERFACE_GMS__TYPE");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.DscGmsNumGms).HasMaxLength(17);
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.DscGmsNumGms).HasColumnName("DSC_GMS__NUM_GMS");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.CdEntpGmsEntreprise).HasMaxLength(60);
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.CdEntpGmsEntreprise).HasColumnName("CD_ENTP_GMS__ENTREPRISE");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.CdFamGmsFamille).IsRequired();
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.CdFamGmsFamille).HasMaxLength(20);
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.CdFamGmsFamille).HasColumnName("CD_FAM_GMS__FAMILLE");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.CdAccesGmsType).HasMaxLength(60);
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.CdAccesGmsType).HasColumnName("CD_ACCES_GMS__TYPE");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.CdTypeGmsType).HasMaxLength(60);
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.CdTypeGmsType).HasColumnName("CD_TYPE_GMS__TYPE");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.CdProtecGmsProtec).HasMaxLength(60);
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.CdProtecGmsProtec).HasColumnName("CD_PROTEC_GMS__PROTEC");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.CdAncrageGmsType).HasMaxLength(60);
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.CdAncrageGmsType).HasColumnName("CD_ANCRAGE_GMS__TYPE");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.CdPoteauGmsType).HasMaxLength(60);
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.CdPoteauGmsType).HasColumnName("CD_POTEAU_GMS__TYPE");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.CdPoutreGmsType).HasMaxLength(60);
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.CdPoutreGmsType).HasColumnName("CD_POUTRE_GMS__TYPE");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.NumExploit).HasMaxLength(17);
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.NumExploit).HasColumnName("NUM_EXPLOIT");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.NomUsage).HasMaxLength(255);
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.NomUsage).HasColumnName("NOM_USAGE");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.DateMs).IsRequired();
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Haut).HasColumnName("HAUT");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Tirair).HasColumnName("TIRAIR");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Vent).HasColumnName("VENT");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Ancrage).HasMaxLength(60);
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Ancrage).HasColumnName("ANCRAGE");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Larg).HasColumnName("LARG");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Traverse).HasColumnName("TRAVERSE");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Element).HasColumnName("ELEMENT");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.NbPoteaux).HasColumnName("NB_POTEAUX");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Eclairage).HasColumnName("ECLAIRAGE");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Condamne).HasColumnName("CONDAMNE");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Note1).HasColumnName("NOTE1");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Note2).HasColumnName("NOTE2");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Note3).HasColumnName("NOTE3");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Note4).HasColumnName("NOTE4");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Note5).HasColumnName("NOTE5");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Urgence).HasMaxLength(5);
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Urgence).HasColumnName("URGENCE");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.DescInva).HasMaxLength(1000);
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.DescInva).HasColumnName("DESC_INVA");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Securite).HasColumnName("SECURITE");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.ProsurvAnnee).HasColumnName("PROSURV_ANNEE");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.DernInsp).HasColumnName("DERN_INSP");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.DernVst).HasColumnName("DERN_VST");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.NoteVst).HasMaxLength(5);
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.NoteVst).HasColumnName("NOTE_VST");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Archive).HasMaxLength(255);
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Archive).HasColumnName("ARCHIVE");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Commentaire).HasMaxLength(1000);
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.X1).HasColumnName("X1");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Y1).HasColumnName("Y1");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Z1).HasColumnName("Z1");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.DateReleve).HasColumnName("DATE_RELEVE");
            modelBuilder.Entity<GmsDscTemp>().Property(item => item.Terrain).HasColumnName("TERRAIN");
            modelBuilder.Entity<GmsEltInspTmp>().ToTable("ELT_INSP_TMP_GMS","GMS");
            modelBuilder.Entity<GmsEltInspTmp>().HasKey(item => new {item.CampGmsIdCamp,item.DscTempGmsNumGms,item.GrpGmsIdGrp,item.PrtGmsIdPrt,item.SprtGmsIdSprt,item.EltGmsIdElem });
            modelBuilder.Entity<GmsEltInspTmp>().Property(item => item.CampGmsIdCamp).IsRequired();
            modelBuilder.Entity<GmsEltInspTmp>().Property(item => item.CampGmsIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GmsEltInspTmp>().Property(item => item.CampGmsIdCamp).HasColumnName("CAMP_GMS__ID_CAMP");
            modelBuilder.Entity<GmsEltInspTmp>().Property(item => item.DscTempGmsNumGms).IsRequired();
            modelBuilder.Entity<GmsEltInspTmp>().Property(item => item.DscTempGmsNumGms).HasMaxLength(17);
            modelBuilder.Entity<GmsEltInspTmp>().Property(item => item.DscTempGmsNumGms).HasColumnName("DSC_TEMP_GMS__NUM_GMS");
            modelBuilder.Entity<GmsEltInspTmp>().Property(item => item.GrpGmsIdGrp).IsRequired();
            modelBuilder.Entity<GmsEltInspTmp>().Property(item => item.GrpGmsIdGrp).HasColumnName("GRP_GMS__ID_GRP");
            modelBuilder.Entity<GmsEltInspTmp>().Property(item => item.PrtGmsIdPrt).IsRequired();
            modelBuilder.Entity<GmsEltInspTmp>().Property(item => item.PrtGmsIdPrt).HasColumnName("PRT_GMS__ID_PRT");
            modelBuilder.Entity<GmsEltInspTmp>().Property(item => item.SprtGmsIdSprt).IsRequired();
            modelBuilder.Entity<GmsEltInspTmp>().Property(item => item.SprtGmsIdSprt).HasColumnName("SPRT_GMS__ID_SPRT");
            modelBuilder.Entity<GmsEltInspTmp>().Property(item => item.EltGmsIdElem).IsRequired();
            modelBuilder.Entity<GmsEltInspTmp>().Property(item => item.EltGmsIdElem).HasColumnName("ELT_GMS__ID_ELEM");
            modelBuilder.Entity<GmsEltInspTmp>().Property(item => item.Indice).IsRequired();
            modelBuilder.Entity<GmsEltInspTmp>().Property(item => item.Indice).HasColumnName("INDICE");
            modelBuilder.Entity<GmsEltInspTmp>().Property(item => item.Obs).HasMaxLength(255);
            modelBuilder.Entity<GmsEltInspTmp>().Property(item => item.Obs).HasColumnName("OBS");
            modelBuilder.Entity<GmsPhotoEltInspTmp>().ToTable("PHOTO_ELT_INSP_TMP_GMS","GMS");
            modelBuilder.Entity<GmsPhotoEltInspTmp>().HasKey(item => new {item.GrpGmsIdGrp,item.PrtGmsIdPrt,item.SprtGmsIdSprt,item.CampGmsIdCamp,item.DscTempGmsNumGms,item.EltGmsIdElem,item.Id });
            modelBuilder.Entity<GmsPhotoEltInspTmp>().Property(item => item.GrpGmsIdGrp).IsRequired();
            modelBuilder.Entity<GmsPhotoEltInspTmp>().Property(item => item.GrpGmsIdGrp).HasColumnName("GRP_GMS__ID_GRP");
            modelBuilder.Entity<GmsPhotoEltInspTmp>().Property(item => item.PrtGmsIdPrt).IsRequired();
            modelBuilder.Entity<GmsPhotoEltInspTmp>().Property(item => item.PrtGmsIdPrt).HasColumnName("PRT_GMS__ID_PRT");
            modelBuilder.Entity<GmsPhotoEltInspTmp>().Property(item => item.SprtGmsIdSprt).IsRequired();
            modelBuilder.Entity<GmsPhotoEltInspTmp>().Property(item => item.SprtGmsIdSprt).HasColumnName("SPRT_GMS__ID_SPRT");
            modelBuilder.Entity<GmsPhotoEltInspTmp>().Property(item => item.CampGmsIdCamp).IsRequired();
            modelBuilder.Entity<GmsPhotoEltInspTmp>().Property(item => item.CampGmsIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GmsPhotoEltInspTmp>().Property(item => item.CampGmsIdCamp).HasColumnName("CAMP_GMS__ID_CAMP");
            modelBuilder.Entity<GmsPhotoEltInspTmp>().Property(item => item.DscTempGmsNumGms).IsRequired();
            modelBuilder.Entity<GmsPhotoEltInspTmp>().Property(item => item.DscTempGmsNumGms).HasMaxLength(17);
            modelBuilder.Entity<GmsPhotoEltInspTmp>().Property(item => item.DscTempGmsNumGms).HasColumnName("DSC_TEMP_GMS__NUM_GMS");
            modelBuilder.Entity<GmsPhotoEltInspTmp>().Property(item => item.EltGmsIdElem).IsRequired();
            modelBuilder.Entity<GmsPhotoEltInspTmp>().Property(item => item.EltGmsIdElem).HasColumnName("ELT_GMS__ID_ELEM");
            modelBuilder.Entity<GmsPhotoEltInspTmp>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<GmsPhotoEltInspTmp>().Property(item => item.Id).HasMaxLength(50);
            modelBuilder.Entity<GmsPhotoEltInspTmp>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<GmsPhotoEltInspTmp>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<GmsPhotoEltInspTmp>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<GmsInspTmp>().ToTable("INSP_TMP_GMS","GMS");
            modelBuilder.Entity<GmsInspTmp>().HasKey(item => new {item.CampGmsIdCamp,item.DscTempGmsNumGms });
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.CampGmsIdCamp).IsRequired();
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.CampGmsIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.CampGmsIdCamp).HasColumnName("CAMP_GMS__ID_CAMP");
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.DscTempGmsNumGms).IsRequired();
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.DscTempGmsNumGms).HasMaxLength(17);
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.DscTempGmsNumGms).HasColumnName("DSC_TEMP_GMS__NUM_GMS");
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.CdEtudeGmsEtude).HasMaxLength(65);
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.CdEtudeGmsEtude).HasColumnName("CD_ETUDE_GMS__ETUDE");
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.InspecteurGmsNom).HasMaxLength(60);
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.InspecteurGmsNom).HasColumnName("INSPECTEUR_GMS__NOM");
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.CdMeteoGmsMeteo).HasMaxLength(60);
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.CdMeteoGmsMeteo).HasColumnName("CD_METEO_GMS__METEO");
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.Etat).IsRequired();
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.Etat).HasMaxLength(25);
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.Etat).HasColumnName("ETAT");
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.Datev).HasColumnName("DATEV");
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.Temperature).HasColumnName("TEMPERATURE");
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.Moyen).HasMaxLength(500);
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.Moyen).HasColumnName("MOYEN");
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.Conditions).HasMaxLength(500);
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.Conditions).HasColumnName("CONDITIONS");
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.DateValid).HasColumnName("DATE_VALID");
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.NomValid).HasMaxLength(255);
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.NomValid).HasColumnName("NOM_VALID");
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.DescInva).HasMaxLength(1000);
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.DescInva).HasColumnName("DESC_INVA");
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.Securite).HasMaxLength(1000);
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.Securite).HasColumnName("SECURITE");
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.Prioritaire).HasMaxLength(1000);
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.Note1).HasColumnName("NOTE1");
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.Note2).HasColumnName("NOTE2");
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.Note3).HasColumnName("NOTE3");
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.Note4).HasColumnName("NOTE4");
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.Note5).HasColumnName("NOTE5");
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.Urgence).HasMaxLength(5);
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.Urgence).HasColumnName("URGENCE");
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.Qualite).HasMaxLength(25);
            modelBuilder.Entity<GmsInspTmp>().Property(item => item.Qualite).HasColumnName("QUALITE");
            modelBuilder.Entity<GmsPhotoInspTmp>().ToTable("PHOTO_INSP_TMP_GMS","GMS");
            modelBuilder.Entity<GmsPhotoInspTmp>().HasKey(item => new {item.Id });
            modelBuilder.Entity<GmsPhotoInspTmp>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<GmsPhotoInspTmp>().Property(item => item.Id).HasMaxLength(30);
            modelBuilder.Entity<GmsPhotoInspTmp>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<GmsPhotoInspTmp>().Property(item => item.CampGmsIdCamp).IsRequired();
            modelBuilder.Entity<GmsPhotoInspTmp>().Property(item => item.CampGmsIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GmsPhotoInspTmp>().Property(item => item.CampGmsIdCamp).HasColumnName("CAMP_GMS__ID_CAMP");
            modelBuilder.Entity<GmsPhotoInspTmp>().Property(item => item.DscTempGmsNumGms).IsRequired();
            modelBuilder.Entity<GmsPhotoInspTmp>().Property(item => item.DscTempGmsNumGms).HasMaxLength(17);
            modelBuilder.Entity<GmsPhotoInspTmp>().Property(item => item.DscTempGmsNumGms).HasColumnName("DSC_TEMP_GMS__NUM_GMS");
            modelBuilder.Entity<GmsPhotoInspTmp>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<GmsPhotoInspTmp>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<GmsClsDoc>().ToTable("CLS_DOC_GMS","GMS");
            modelBuilder.Entity<GmsClsDoc>().HasKey(item => new {item.ClsGmsId,item.DocGmsId });
            modelBuilder.Entity<GmsClsDoc>().Property(item => item.ClsGmsId).IsRequired();
            modelBuilder.Entity<GmsClsDoc>().Property(item => item.ClsGmsId).HasColumnName("CLS_GMS__ID");
            modelBuilder.Entity<GmsClsDoc>().Property(item => item.DocGmsId).IsRequired();
            modelBuilder.Entity<GmsClsDoc>().Property(item => item.DocGmsId).HasColumnName("DOC_GMS__ID");
            modelBuilder.Entity<GmsClsDoc>().Property(item => item.Defaut).HasColumnName("DEFAUT");
            modelBuilder.Entity<GmsClsDoc>().Property(item => item.Dossier).HasMaxLength(15);
            modelBuilder.Entity<GmsClsDoc>().Property(item => item.Dossier).HasColumnName("DOSSIER");
            modelBuilder.Entity<GmsDscCamp>().ToTable("DSC_CAMP_GMS","GMS");
            modelBuilder.Entity<GmsDscCamp>().HasKey(item => new {item.DscGmsNumGms,item.CampGmsIdCamp });
            modelBuilder.Entity<GmsDscCamp>().Property(item => item.DscGmsNumGms).IsRequired();
            modelBuilder.Entity<GmsDscCamp>().Property(item => item.DscGmsNumGms).HasMaxLength(17);
            modelBuilder.Entity<GmsDscCamp>().Property(item => item.DscGmsNumGms).HasColumnName("DSC_GMS__NUM_GMS");
            modelBuilder.Entity<GmsDscCamp>().Property(item => item.CampGmsIdCamp).IsRequired();
            modelBuilder.Entity<GmsDscCamp>().Property(item => item.CampGmsIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GmsDscCamp>().Property(item => item.CampGmsIdCamp).HasColumnName("CAMP_GMS__ID_CAMP");
            modelBuilder.Entity<GmsDscCamp>().Property(item => item.Realiser).HasColumnName("REALISER");
            modelBuilder.Entity<GmsCdPrecoSprtVst>().ToTable("CD_PRECO__SPRT_VST_GMS","GMS");
            modelBuilder.Entity<GmsCdPrecoSprtVst>().HasKey(item => new {item.CampGmsIdCamp,item.DscGmsNumGms,item.CdChapitreGmsIdChap,item.CdLigneGmsIdLigne,item.BpuGmsIdBpu });
            modelBuilder.Entity<GmsCdPrecoSprtVst>().Property(item => item.CampGmsIdCamp).IsRequired();
            modelBuilder.Entity<GmsCdPrecoSprtVst>().Property(item => item.CampGmsIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GmsCdPrecoSprtVst>().Property(item => item.CampGmsIdCamp).HasColumnName("CAMP_GMS__ID_CAMP");
            modelBuilder.Entity<GmsCdPrecoSprtVst>().Property(item => item.DscGmsNumGms).IsRequired();
            modelBuilder.Entity<GmsCdPrecoSprtVst>().Property(item => item.DscGmsNumGms).HasMaxLength(17);
            modelBuilder.Entity<GmsCdPrecoSprtVst>().Property(item => item.DscGmsNumGms).HasColumnName("DSC_GMS__NUM_GMS");
            modelBuilder.Entity<GmsCdPrecoSprtVst>().Property(item => item.CdChapitreGmsIdChap).IsRequired();
            modelBuilder.Entity<GmsCdPrecoSprtVst>().Property(item => item.CdChapitreGmsIdChap).HasColumnName("CD_CHAPITRE_GMS__ID_CHAP");
            modelBuilder.Entity<GmsCdPrecoSprtVst>().Property(item => item.CdLigneGmsIdLigne).IsRequired();
            modelBuilder.Entity<GmsCdPrecoSprtVst>().Property(item => item.CdLigneGmsIdLigne).HasColumnName("CD_LIGNE_GMS__ID_LIGNE");
            modelBuilder.Entity<GmsCdPrecoSprtVst>().Property(item => item.BpuGmsIdBpu).IsRequired();
            modelBuilder.Entity<GmsCdPrecoSprtVst>().Property(item => item.BpuGmsIdBpu).HasColumnName("BPU_GMS__ID_BPU");
            modelBuilder.Entity<GmsCdPrecoSprtVst>().Property(item => item.Realise).HasColumnName("REALISE");
            modelBuilder.Entity<GmsCdConclusionInsp>().ToTable("CD_CONCLUSION__INSP_GMS","GMS");
            modelBuilder.Entity<GmsCdConclusionInsp>().HasKey(item => new {item.CampGmsIdCamp,item.DscGmsNumGms,item.CdConclusionGmsIdConc });
            modelBuilder.Entity<GmsCdConclusionInsp>().Property(item => item.CampGmsIdCamp).IsRequired();
            modelBuilder.Entity<GmsCdConclusionInsp>().Property(item => item.CampGmsIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GmsCdConclusionInsp>().Property(item => item.CampGmsIdCamp).HasColumnName("CAMP_GMS__ID_CAMP");
            modelBuilder.Entity<GmsCdConclusionInsp>().Property(item => item.DscGmsNumGms).IsRequired();
            modelBuilder.Entity<GmsCdConclusionInsp>().Property(item => item.DscGmsNumGms).HasMaxLength(17);
            modelBuilder.Entity<GmsCdConclusionInsp>().Property(item => item.DscGmsNumGms).HasColumnName("DSC_GMS__NUM_GMS");
            modelBuilder.Entity<GmsCdConclusionInsp>().Property(item => item.CdConclusionGmsIdConc).IsRequired();
            modelBuilder.Entity<GmsCdConclusionInsp>().Property(item => item.CdConclusionGmsIdConc).HasColumnName("CD_CONCLUSION_GMS__ID_CONC");
            modelBuilder.Entity<GmsCdConclusionInsp>().Property(item => item.Contenu).HasMaxLength(1000);
            modelBuilder.Entity<GmsCdConclusionInsp>().Property(item => item.Contenu).HasColumnName("CONTENU");
            modelBuilder.Entity<GmsCdConclusionInspTmp>().ToTable("CD_CONCLUSION__INSP_TMP_GMS","GMS");
            modelBuilder.Entity<GmsCdConclusionInspTmp>().HasKey(item => new {item.CampGmsIdCamp,item.DscTempGmsNumGms,item.CdConclusionGmsIdConc });
            modelBuilder.Entity<GmsCdConclusionInspTmp>().Property(item => item.CampGmsIdCamp).IsRequired();
            modelBuilder.Entity<GmsCdConclusionInspTmp>().Property(item => item.CampGmsIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GmsCdConclusionInspTmp>().Property(item => item.CampGmsIdCamp).HasColumnName("CAMP_GMS__ID_CAMP");
            modelBuilder.Entity<GmsCdConclusionInspTmp>().Property(item => item.DscTempGmsNumGms).IsRequired();
            modelBuilder.Entity<GmsCdConclusionInspTmp>().Property(item => item.DscTempGmsNumGms).HasMaxLength(17);
            modelBuilder.Entity<GmsCdConclusionInspTmp>().Property(item => item.DscTempGmsNumGms).HasColumnName("DSC_TEMP_GMS__NUM_GMS");
            modelBuilder.Entity<GmsCdConclusionInspTmp>().Property(item => item.CdConclusionGmsIdConc).IsRequired();
            modelBuilder.Entity<GmsCdConclusionInspTmp>().Property(item => item.CdConclusionGmsIdConc).HasColumnName("CD_CONCLUSION_GMS__ID_CONC");
            modelBuilder.Entity<GmsCdConclusionInspTmp>().Property(item => item.Contenu).HasMaxLength(1000);
            modelBuilder.Entity<GmsCdConclusionInspTmp>().Property(item => item.Contenu).HasColumnName("CONTENU");
            modelBuilder.Entity<GotCdEntp>().ToTable("CD_ENTP_GOT","GOT");
            modelBuilder.Entity<GotCdEntp>().HasKey(item => new {item.Entreprise });
            modelBuilder.Entity<GotCdEntp>().Property(item => item.Entreprise).IsRequired();
            modelBuilder.Entity<GotCdEntp>().Property(item => item.Entreprise).HasMaxLength(60);
            modelBuilder.Entity<GotCdEntp>().Property(item => item.Entreprise).HasColumnName("ENTREPRISE");
            modelBuilder.Entity<GotDsc>().ToTable("DSC_GOT","GOT");
            modelBuilder.Entity<GotDsc>().HasKey(item => new {item.NumGot });
            modelBuilder.Entity<GotDsc>().Property(item => item.NumGot).IsRequired();
            modelBuilder.Entity<GotDsc>().Property(item => item.NumGot).HasMaxLength(17);
            modelBuilder.Entity<GotDsc>().Property(item => item.NumGot).HasColumnName("NUM_GOT");
            modelBuilder.Entity<GotDsc>().Property(item => item.CdFamGotFamille).IsRequired();
            modelBuilder.Entity<GotDsc>().Property(item => item.CdFamGotFamille).HasMaxLength(20);
            modelBuilder.Entity<GotDsc>().Property(item => item.CdFamGotFamille).HasColumnName("CD_FAM_GOT__FAMILLE");
            modelBuilder.Entity<GotDsc>().Property(item => item.CdQualiteGotQualite).HasMaxLength(25);
            modelBuilder.Entity<GotDsc>().Property(item => item.CdQualiteGotQualite).HasColumnName("CD_QUALITE_GOT__QUALITE");
            modelBuilder.Entity<GotDsc>().Property(item => item.CdGeoGotGeologie).HasMaxLength(60);
            modelBuilder.Entity<GotDsc>().Property(item => item.CdGeoGotGeologie).HasColumnName("CD_GEO_GOT__GEOLOGIE");
            modelBuilder.Entity<GotDsc>().Property(item => item.CdProtectGotType).HasMaxLength(60);
            modelBuilder.Entity<GotDsc>().Property(item => item.CdProtectGotType).HasColumnName("CD_PROTECT_GOT__TYPE");
            modelBuilder.Entity<GotDsc>().Property(item => item.CdTypeGotType).HasMaxLength(20);
            modelBuilder.Entity<GotDsc>().Property(item => item.CdTypeGotType).HasColumnName("CD_TYPE_GOT__TYPE");
            modelBuilder.Entity<GotDsc>().Property(item => item.CdEntpGotEntreprise).HasMaxLength(60);
            modelBuilder.Entity<GotDsc>().Property(item => item.CdEntpGotEntreprise).HasColumnName("CD_ENTP_GOT__ENTREPRISE");
            modelBuilder.Entity<GotDsc>().Property(item => item.CdRisqueGotRisque).HasMaxLength(3);
            modelBuilder.Entity<GotDsc>().Property(item => item.CdRisqueGotRisque).HasColumnName("CD_RISQUE_GOT__RISQUE");
            modelBuilder.Entity<GotDsc>().Property(item => item.CdPenteGotPente).HasMaxLength(25);
            modelBuilder.Entity<GotDsc>().Property(item => item.CdPenteGotPente).HasColumnName("CD_PENTE_GOT__PENTE");
            modelBuilder.Entity<GotDsc>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<GotDsc>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<GotDsc>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<GotDsc>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<GotDsc>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<GotDsc>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<GotDsc>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<GotDsc>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<GotDsc>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<GotDsc>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<GotDsc>().Property(item => item.NumExploit).HasMaxLength(30);
            modelBuilder.Entity<GotDsc>().Property(item => item.NumExploit).HasColumnName("NUM_EXPLOIT");
            modelBuilder.Entity<GotDsc>().Property(item => item.DateConst).HasColumnName("DATE_CONST");
            modelBuilder.Entity<GotDsc>().Property(item => item.PenteTn).HasColumnName("PENTE_TN");
            modelBuilder.Entity<GotDsc>().Property(item => item.Haut).HasColumnName("HAUT");
            modelBuilder.Entity<GotDsc>().Property(item => item.LargCrete).HasColumnName("LARG_CRETE");
            modelBuilder.Entity<GotDsc>().Property(item => item.Volume).HasColumnName("VOLUME");
            modelBuilder.Entity<GotDsc>().Property(item => item.RisbNbr).HasColumnName("RISB_NBR");
            modelBuilder.Entity<GotDsc>().Property(item => item.RisbEsp).HasColumnName("RISB_ESP");
            modelBuilder.Entity<GotDsc>().Property(item => item.RisbLarg).HasColumnName("RISB_LARG");
            modelBuilder.Entity<GotDsc>().Property(item => item.HautEau).HasColumnName("HAUT_EAU");
            modelBuilder.Entity<GotDsc>().Property(item => item.Instable).HasColumnName("INSTABLE");
            modelBuilder.Entity<GotDsc>().Property(item => item.NomUsage).HasMaxLength(255);
            modelBuilder.Entity<GotDsc>().Property(item => item.NomUsage).HasColumnName("NOM_USAGE");
            modelBuilder.Entity<GotDsc>().Property(item => item.Note1).HasColumnName("NOTE1");
            modelBuilder.Entity<GotDsc>().Property(item => item.Note2).HasColumnName("NOTE2");
            modelBuilder.Entity<GotDsc>().Property(item => item.Note3).HasColumnName("NOTE3");
            modelBuilder.Entity<GotDsc>().Property(item => item.Note4).HasColumnName("NOTE4");
            modelBuilder.Entity<GotDsc>().Property(item => item.Note5).HasColumnName("NOTE5");
            modelBuilder.Entity<GotDsc>().Property(item => item.Urgence).HasMaxLength(5);
            modelBuilder.Entity<GotDsc>().Property(item => item.Urgence).HasColumnName("URGENCE");
            modelBuilder.Entity<GotDsc>().Property(item => item.DescInva).HasMaxLength(1000);
            modelBuilder.Entity<GotDsc>().Property(item => item.DescInva).HasColumnName("DESC_INVA");
            modelBuilder.Entity<GotDsc>().Property(item => item.Securite).HasColumnName("SECURITE");
            modelBuilder.Entity<GotDsc>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<GotDsc>().Property(item => item.ProsurvAnnee).HasColumnName("PROSURV_ANNEE");
            modelBuilder.Entity<GotDsc>().Property(item => item.DernInsp).HasColumnName("DERN_INSP");
            modelBuilder.Entity<GotDsc>().Property(item => item.DernVst).HasColumnName("DERN_VST");
            modelBuilder.Entity<GotDsc>().Property(item => item.NoteVst).HasMaxLength(5);
            modelBuilder.Entity<GotDsc>().Property(item => item.NoteVst).HasColumnName("NOTE_VST");
            modelBuilder.Entity<GotDsc>().Property(item => item.Archive).HasMaxLength(255);
            modelBuilder.Entity<GotDsc>().Property(item => item.Archive).HasColumnName("ARCHIVE");
            modelBuilder.Entity<GotDsc>().Property(item => item.Commentaire).HasMaxLength(500);
            modelBuilder.Entity<GotDsc>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<GotDsc>().Property(item => item.X1).HasColumnName("X1");
            modelBuilder.Entity<GotDsc>().Property(item => item.Y1).HasColumnName("Y1");
            modelBuilder.Entity<GotDsc>().Property(item => item.Z1).HasColumnName("Z1");
            modelBuilder.Entity<GotDsc>().Property(item => item.DateReleve).HasColumnName("DATE_RELEVE");
            modelBuilder.Entity<GotDsc>().Property(item => item.Terrain).HasColumnName("TERRAIN");
            modelBuilder.Entity<GotDsc>().Property(item => item.Y2).HasColumnName("Y2");
            modelBuilder.Entity<GotDsc>().Property(item => item.Z2).HasColumnName("Z2");
            modelBuilder.Entity<GotDsc>().Property(item => item.X2).HasColumnName("X2");
            modelBuilder.Entity<GotCls>().ToTable("CLS_GOT","GOT");
            modelBuilder.Entity<GotCls>().HasKey(item => new {item.Id });
            modelBuilder.Entity<GotCls>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<GotCls>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<GotCls>().Property(item => item.TableName).HasMaxLength(30);
            modelBuilder.Entity<GotCls>().Property(item => item.TableName).HasColumnName("TABLE_NAME");
            modelBuilder.Entity<GotCls>().Property(item => item.KeyValue).HasMaxLength(100);
            modelBuilder.Entity<GotCls>().Property(item => item.KeyValue).HasColumnName("KEY_VALUE");
            modelBuilder.Entity<GotDoc>().ToTable("DOC_GOT","GOT");
            modelBuilder.Entity<GotDoc>().HasKey(item => new {item.Id });
            modelBuilder.Entity<GotDoc>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<GotDoc>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<GotDoc>().Property(item => item.CdDocGotCode).IsRequired();
            modelBuilder.Entity<GotDoc>().Property(item => item.CdDocGotCode).HasMaxLength(15);
            modelBuilder.Entity<GotDoc>().Property(item => item.CdDocGotCode).HasColumnName("CD_DOC_GOT__CODE");
            modelBuilder.Entity<GotDoc>().Property(item => item.Libelle).HasMaxLength(100);
            modelBuilder.Entity<GotDoc>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<GotDoc>().Property(item => item.Ref).HasMaxLength(50);
            modelBuilder.Entity<GotDoc>().Property(item => item.Ref).HasColumnName("REF");
            modelBuilder.Entity<GotCdDoc>().ToTable("CD_DOC_GOT","GOT");
            modelBuilder.Entity<GotCdDoc>().HasKey(item => new {item.Code });
            modelBuilder.Entity<GotCdDoc>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<GotCdDoc>().Property(item => item.Code).HasMaxLength(15);
            modelBuilder.Entity<GotCdDoc>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<GotCdDoc>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<GotCdDoc>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<GotCdDoc>().Property(item => item.Path).HasMaxLength(255);
            modelBuilder.Entity<GotCdDoc>().Property(item => item.Path).HasColumnName("PATH");
            modelBuilder.Entity<GotElt>().ToTable("ELT_GOT","GOT");
            modelBuilder.Entity<GotElt>().HasKey(item => new {item.GrpGotIdGrp,item.PrtGotIdPrt,item.SprtGotIdSprt,item.IdElem });
            modelBuilder.Entity<GotElt>().Property(item => item.GrpGotIdGrp).IsRequired();
            modelBuilder.Entity<GotElt>().Property(item => item.GrpGotIdGrp).HasColumnName("GRP_GOT__ID_GRP");
            modelBuilder.Entity<GotElt>().Property(item => item.PrtGotIdPrt).IsRequired();
            modelBuilder.Entity<GotElt>().Property(item => item.PrtGotIdPrt).HasColumnName("PRT_GOT__ID_PRT");
            modelBuilder.Entity<GotElt>().Property(item => item.SprtGotIdSprt).IsRequired();
            modelBuilder.Entity<GotElt>().Property(item => item.SprtGotIdSprt).HasColumnName("SPRT_GOT__ID_SPRT");
            modelBuilder.Entity<GotElt>().Property(item => item.IdElem).IsRequired();
            modelBuilder.Entity<GotElt>().Property(item => item.IdElem).HasColumnName("ID_ELEM");
            modelBuilder.Entity<GotElt>().Property(item => item.Libe).IsRequired();
            modelBuilder.Entity<GotElt>().Property(item => item.Libe).HasMaxLength(500);
            modelBuilder.Entity<GotElt>().Property(item => item.Libe).HasColumnName("LIBE");
            modelBuilder.Entity<GotElt>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<GotElt>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<GotElt>().Property(item => item.Aide).HasMaxLength(500);
            modelBuilder.Entity<GotElt>().Property(item => item.Aide).HasColumnName("AIDE");
            modelBuilder.Entity<GotElt>().Property(item => item.Indice1).HasMaxLength(500);
            modelBuilder.Entity<GotElt>().Property(item => item.Indice1).HasColumnName("INDICE1");
            modelBuilder.Entity<GotElt>().Property(item => item.Indice2).HasMaxLength(500);
            modelBuilder.Entity<GotElt>().Property(item => item.Indice2).HasColumnName("INDICE2");
            modelBuilder.Entity<GotElt>().Property(item => item.Indice3).HasMaxLength(500);
            modelBuilder.Entity<GotElt>().Property(item => item.Indice3).HasColumnName("INDICE3");
            modelBuilder.Entity<GotPrt>().ToTable("PRT_GOT","GOT");
            modelBuilder.Entity<GotPrt>().HasKey(item => new {item.GrpGotIdGrp,item.IdPrt });
            modelBuilder.Entity<GotPrt>().Property(item => item.GrpGotIdGrp).IsRequired();
            modelBuilder.Entity<GotPrt>().Property(item => item.GrpGotIdGrp).HasColumnName("GRP_GOT__ID_GRP");
            modelBuilder.Entity<GotPrt>().Property(item => item.IdPrt).IsRequired();
            modelBuilder.Entity<GotPrt>().Property(item => item.IdPrt).HasColumnName("ID_PRT");
            modelBuilder.Entity<GotPrt>().Property(item => item.Libp).IsRequired();
            modelBuilder.Entity<GotPrt>().Property(item => item.Libp).HasMaxLength(500);
            modelBuilder.Entity<GotPrt>().Property(item => item.Libp).HasColumnName("LIBP");
            modelBuilder.Entity<GotPrt>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<GotPrt>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<GotGrp>().ToTable("GRP_GOT","GOT");
            modelBuilder.Entity<GotGrp>().HasKey(item => new {item.IdGrp });
            modelBuilder.Entity<GotGrp>().Property(item => item.IdGrp).IsRequired();
            modelBuilder.Entity<GotGrp>().Property(item => item.IdGrp).HasColumnName("ID_GRP");
            modelBuilder.Entity<GotGrp>().Property(item => item.Libg).IsRequired();
            modelBuilder.Entity<GotGrp>().Property(item => item.Libg).HasMaxLength(500);
            modelBuilder.Entity<GotGrp>().Property(item => item.Libg).HasColumnName("LIBG");
            modelBuilder.Entity<GotGrp>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<GotGrp>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<GotEltInsp>().ToTable("ELT_INSP_GOT","GOT");
            modelBuilder.Entity<GotEltInsp>().HasKey(item => new {item.DscGotNumGot,item.CampGotIdCamp,item.GrpGotIdGrp,item.PrtGotIdPrt,item.SprtGotIdSprt,item.EltGotIdElem });
            modelBuilder.Entity<GotEltInsp>().Property(item => item.DscGotNumGot).IsRequired();
            modelBuilder.Entity<GotEltInsp>().Property(item => item.DscGotNumGot).HasMaxLength(17);
            modelBuilder.Entity<GotEltInsp>().Property(item => item.DscGotNumGot).HasColumnName("DSC_GOT__NUM_GOT");
            modelBuilder.Entity<GotEltInsp>().Property(item => item.CampGotIdCamp).IsRequired();
            modelBuilder.Entity<GotEltInsp>().Property(item => item.CampGotIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GotEltInsp>().Property(item => item.CampGotIdCamp).HasColumnName("CAMP_GOT__ID_CAMP");
            modelBuilder.Entity<GotEltInsp>().Property(item => item.GrpGotIdGrp).IsRequired();
            modelBuilder.Entity<GotEltInsp>().Property(item => item.GrpGotIdGrp).HasColumnName("GRP_GOT__ID_GRP");
            modelBuilder.Entity<GotEltInsp>().Property(item => item.PrtGotIdPrt).IsRequired();
            modelBuilder.Entity<GotEltInsp>().Property(item => item.PrtGotIdPrt).HasColumnName("PRT_GOT__ID_PRT");
            modelBuilder.Entity<GotEltInsp>().Property(item => item.SprtGotIdSprt).IsRequired();
            modelBuilder.Entity<GotEltInsp>().Property(item => item.SprtGotIdSprt).HasColumnName("SPRT_GOT__ID_SPRT");
            modelBuilder.Entity<GotEltInsp>().Property(item => item.EltGotIdElem).IsRequired();
            modelBuilder.Entity<GotEltInsp>().Property(item => item.EltGotIdElem).HasColumnName("ELT_GOT__ID_ELEM");
            modelBuilder.Entity<GotEltInsp>().Property(item => item.Indice).IsRequired();
            modelBuilder.Entity<GotEltInsp>().Property(item => item.Indice).HasColumnName("INDICE");
            modelBuilder.Entity<GotEltInsp>().Property(item => item.Obs).HasMaxLength(255);
            modelBuilder.Entity<GotEltInsp>().Property(item => item.Obs).HasColumnName("OBS");
            modelBuilder.Entity<GotPhotoEltInsp>().ToTable("PHOTO_ELT_INSP_GOT","GOT");
            modelBuilder.Entity<GotPhotoEltInsp>().HasKey(item => new {item.GrpGotIdGrp,item.PrtGotIdPrt,item.DscGotNumGot,item.CampGotIdCamp,item.SprtGotIdSprt,item.EltGotIdElem,item.Id });
            modelBuilder.Entity<GotPhotoEltInsp>().Property(item => item.GrpGotIdGrp).IsRequired();
            modelBuilder.Entity<GotPhotoEltInsp>().Property(item => item.GrpGotIdGrp).HasColumnName("GRP_GOT__ID_GRP");
            modelBuilder.Entity<GotPhotoEltInsp>().Property(item => item.PrtGotIdPrt).IsRequired();
            modelBuilder.Entity<GotPhotoEltInsp>().Property(item => item.PrtGotIdPrt).HasColumnName("PRT_GOT__ID_PRT");
            modelBuilder.Entity<GotPhotoEltInsp>().Property(item => item.DscGotNumGot).IsRequired();
            modelBuilder.Entity<GotPhotoEltInsp>().Property(item => item.DscGotNumGot).HasMaxLength(17);
            modelBuilder.Entity<GotPhotoEltInsp>().Property(item => item.DscGotNumGot).HasColumnName("DSC_GOT__NUM_GOT");
            modelBuilder.Entity<GotPhotoEltInsp>().Property(item => item.CampGotIdCamp).IsRequired();
            modelBuilder.Entity<GotPhotoEltInsp>().Property(item => item.CampGotIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GotPhotoEltInsp>().Property(item => item.CampGotIdCamp).HasColumnName("CAMP_GOT__ID_CAMP");
            modelBuilder.Entity<GotPhotoEltInsp>().Property(item => item.SprtGotIdSprt).IsRequired();
            modelBuilder.Entity<GotPhotoEltInsp>().Property(item => item.SprtGotIdSprt).HasColumnName("SPRT_GOT__ID_SPRT");
            modelBuilder.Entity<GotPhotoEltInsp>().Property(item => item.EltGotIdElem).IsRequired();
            modelBuilder.Entity<GotPhotoEltInsp>().Property(item => item.EltGotIdElem).HasColumnName("ELT_GOT__ID_ELEM");
            modelBuilder.Entity<GotPhotoEltInsp>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<GotPhotoEltInsp>().Property(item => item.Id).HasMaxLength(50);
            modelBuilder.Entity<GotPhotoEltInsp>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<GotPhotoEltInsp>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<GotPhotoEltInsp>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<GotCamp>().ToTable("CAMP_GOT","GOT");
            modelBuilder.Entity<GotCamp>().HasKey(item => new {item.IdCamp });
            modelBuilder.Entity<GotCamp>().Property(item => item.IdCamp).IsRequired();
            modelBuilder.Entity<GotCamp>().Property(item => item.IdCamp).HasMaxLength(100);
            modelBuilder.Entity<GotCamp>().Property(item => item.IdCamp).HasColumnName("ID_CAMP");
            modelBuilder.Entity<GotCamp>().Property(item => item.CdTypePvGotCode).IsRequired();
            modelBuilder.Entity<GotCamp>().Property(item => item.CdTypePvGotCode).HasMaxLength(15);
            modelBuilder.Entity<GotCamp>().Property(item => item.CdTypePvGotCode).HasColumnName("CD_TYPE_PV_GOT__CODE");
            modelBuilder.Entity<GotCamp>().Property(item => item.CdPrestaGotPrestataire).IsRequired();
            modelBuilder.Entity<GotCamp>().Property(item => item.CdPrestaGotPrestataire).HasMaxLength(50);
            modelBuilder.Entity<GotCamp>().Property(item => item.CdPrestaGotPrestataire).HasColumnName("CD_PRESTA_GOT__PRESTATAIRE");
            modelBuilder.Entity<GotCamp>().Property(item => item.Annee).IsRequired();
            modelBuilder.Entity<GotCamp>().Property(item => item.Annee).HasColumnName("ANNEE");
            modelBuilder.Entity<GotCamp>().Property(item => item.Dater).IsRequired();
            modelBuilder.Entity<GotCamp>().Property(item => item.Dater).HasColumnName("DATER");
            modelBuilder.Entity<GotCamp>().Property(item => item.Dateg).HasColumnName("DATEG");
            modelBuilder.Entity<GotCamp>().Property(item => item.Userg).HasMaxLength(255);
            modelBuilder.Entity<GotCamp>().Property(item => item.Userg).HasColumnName("USERG");
            modelBuilder.Entity<GotCamp>().Property(item => item.Observ).HasMaxLength(255);
            modelBuilder.Entity<GotCamp>().Property(item => item.Observ).HasColumnName("OBSERV");
            modelBuilder.Entity<GotCdMeteo>().ToTable("CD_METEO_GOT","GOT");
            modelBuilder.Entity<GotCdMeteo>().HasKey(item => new {item.Meteo });
            modelBuilder.Entity<GotCdMeteo>().Property(item => item.Meteo).IsRequired();
            modelBuilder.Entity<GotCdMeteo>().Property(item => item.Meteo).HasMaxLength(60);
            modelBuilder.Entity<GotCdMeteo>().Property(item => item.Meteo).HasColumnName("METEO");
            modelBuilder.Entity<GotCdPresta>().ToTable("CD_PRESTA_GOT","GOT");
            modelBuilder.Entity<GotCdPresta>().HasKey(item => new {item.Prestataire });
            modelBuilder.Entity<GotCdPresta>().Property(item => item.Prestataire).IsRequired();
            modelBuilder.Entity<GotCdPresta>().Property(item => item.Prestataire).HasMaxLength(50);
            modelBuilder.Entity<GotCdPresta>().Property(item => item.Prestataire).HasColumnName("PRESTATAIRE");
            modelBuilder.Entity<GotTravaux>().ToTable("TRAVAUX_GOT","GOT");
            modelBuilder.Entity<GotTravaux>().HasKey(item => new {item.DscGotNumGot,item.CdTravauxGotCode,item.NatureTravGotNature,item.DateRcp });
            modelBuilder.Entity<GotTravaux>().Property(item => item.DscGotNumGot).IsRequired();
            modelBuilder.Entity<GotTravaux>().Property(item => item.DscGotNumGot).HasMaxLength(17);
            modelBuilder.Entity<GotTravaux>().Property(item => item.DscGotNumGot).HasColumnName("DSC_GOT__NUM_GOT");
            modelBuilder.Entity<GotTravaux>().Property(item => item.CdTravauxGotCode).IsRequired();
            modelBuilder.Entity<GotTravaux>().Property(item => item.CdTravauxGotCode).HasMaxLength(60);
            modelBuilder.Entity<GotTravaux>().Property(item => item.CdTravauxGotCode).HasColumnName("CD_TRAVAUX_GOT__CODE");
            modelBuilder.Entity<GotTravaux>().Property(item => item.NatureTravGotNature).IsRequired();
            modelBuilder.Entity<GotTravaux>().Property(item => item.NatureTravGotNature).HasMaxLength(255);
            modelBuilder.Entity<GotTravaux>().Property(item => item.NatureTravGotNature).HasColumnName("NATURE_TRAV_GOT__NATURE");
            modelBuilder.Entity<GotTravaux>().Property(item => item.DateRcp).IsRequired();
            modelBuilder.Entity<GotTravaux>().Property(item => item.DateRcp).HasColumnName("DATE_RCP");
            modelBuilder.Entity<GotTravaux>().Property(item => item.CdEntpGotEntreprise).IsRequired();
            modelBuilder.Entity<GotTravaux>().Property(item => item.CdEntpGotEntreprise).HasMaxLength(60);
            modelBuilder.Entity<GotTravaux>().Property(item => item.CdEntpGotEntreprise).HasColumnName("CD_ENTP_GOT__ENTREPRISE");
            modelBuilder.Entity<GotTravaux>().Property(item => item.DateFinGar).HasColumnName("DATE_FIN_GAR");
            modelBuilder.Entity<GotTravaux>().Property(item => item.Cout).HasColumnName("COUT");
            modelBuilder.Entity<GotTravaux>().Property(item => item.Marche).HasMaxLength(25);
            modelBuilder.Entity<GotTravaux>().Property(item => item.Marche).HasColumnName("MARCHE");
            modelBuilder.Entity<GotTravaux>().Property(item => item.Commentaire).HasMaxLength(500);
            modelBuilder.Entity<GotTravaux>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<GotNatureTrav>().ToTable("NATURE_TRAV_GOT","GOT");
            modelBuilder.Entity<GotNatureTrav>().HasKey(item => new {item.CdTravauxGotCode,item.Nature });
            modelBuilder.Entity<GotNatureTrav>().Property(item => item.CdTravauxGotCode).IsRequired();
            modelBuilder.Entity<GotNatureTrav>().Property(item => item.CdTravauxGotCode).HasMaxLength(60);
            modelBuilder.Entity<GotNatureTrav>().Property(item => item.CdTravauxGotCode).HasColumnName("CD_TRAVAUX_GOT__CODE");
            modelBuilder.Entity<GotNatureTrav>().Property(item => item.Nature).IsRequired();
            modelBuilder.Entity<GotNatureTrav>().Property(item => item.Nature).HasMaxLength(255);
            modelBuilder.Entity<GotNatureTrav>().Property(item => item.Nature).HasColumnName("NATURE");
            modelBuilder.Entity<GotCdTravaux>().ToTable("CD_TRAVAUX_GOT","GOT");
            modelBuilder.Entity<GotCdTravaux>().HasKey(item => new {item.Code });
            modelBuilder.Entity<GotCdTravaux>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<GotCdTravaux>().Property(item => item.Code).HasMaxLength(60);
            modelBuilder.Entity<GotCdTravaux>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<GotCdFam>().ToTable("CD_FAM_GOT","GOT");
            modelBuilder.Entity<GotCdFam>().HasKey(item => new {item.Famille });
            modelBuilder.Entity<GotCdFam>().Property(item => item.Famille).IsRequired();
            modelBuilder.Entity<GotCdFam>().Property(item => item.Famille).HasMaxLength(20);
            modelBuilder.Entity<GotCdFam>().Property(item => item.Famille).HasColumnName("FAMILLE");
            modelBuilder.Entity<GotCdFam>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<GotCdFam>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<GotCdPente>().ToTable("CD_PENTE_GOT","GOT");
            modelBuilder.Entity<GotCdPente>().HasKey(item => new {item.Pente });
            modelBuilder.Entity<GotCdPente>().Property(item => item.Pente).IsRequired();
            modelBuilder.Entity<GotCdPente>().Property(item => item.Pente).HasMaxLength(25);
            modelBuilder.Entity<GotCdPente>().Property(item => item.Pente).HasColumnName("PENTE");
            modelBuilder.Entity<GotCdPente>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<GotCdPente>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<GotCdProtect>().ToTable("CD_PROTECT_GOT","GOT");
            modelBuilder.Entity<GotCdProtect>().HasKey(item => new {item.Type });
            modelBuilder.Entity<GotCdProtect>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<GotCdProtect>().Property(item => item.Type).HasMaxLength(60);
            modelBuilder.Entity<GotCdProtect>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<GotCdGeo>().ToTable("CD_GEO_GOT","GOT");
            modelBuilder.Entity<GotCdGeo>().HasKey(item => new {item.Geologie });
            modelBuilder.Entity<GotCdGeo>().Property(item => item.Geologie).IsRequired();
            modelBuilder.Entity<GotCdGeo>().Property(item => item.Geologie).HasMaxLength(60);
            modelBuilder.Entity<GotCdGeo>().Property(item => item.Geologie).HasColumnName("GEOLOGIE");
            modelBuilder.Entity<GotCdMateriau>().ToTable("CD_MATERIAU_GOT","GOT");
            modelBuilder.Entity<GotCdMateriau>().HasKey(item => new {item.Type });
            modelBuilder.Entity<GotCdMateriau>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<GotCdMateriau>().Property(item => item.Type).HasMaxLength(60);
            modelBuilder.Entity<GotCdMateriau>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<GotCdHydrique>().ToTable("CD_HYDRIQUE_GOT","GOT");
            modelBuilder.Entity<GotCdHydrique>().HasKey(item => new {item.Etat });
            modelBuilder.Entity<GotCdHydrique>().Property(item => item.Etat).IsRequired();
            modelBuilder.Entity<GotCdHydrique>().Property(item => item.Etat).HasMaxLength(25);
            modelBuilder.Entity<GotCdHydrique>().Property(item => item.Etat).HasColumnName("ETAT");
            modelBuilder.Entity<GotCdTraitement>().ToTable("CD_TRAITEMENT_GOT","GOT");
            modelBuilder.Entity<GotCdTraitement>().HasKey(item => new {item.Type });
            modelBuilder.Entity<GotCdTraitement>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<GotCdTraitement>().Property(item => item.Type).HasMaxLength(25);
            modelBuilder.Entity<GotCdTraitement>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<GotSprt>().ToTable("SPRT_GOT","GOT");
            modelBuilder.Entity<GotSprt>().HasKey(item => new {item.GrpGotIdGrp,item.PrtGotIdPrt,item.IdSprt });
            modelBuilder.Entity<GotSprt>().Property(item => item.GrpGotIdGrp).IsRequired();
            modelBuilder.Entity<GotSprt>().Property(item => item.GrpGotIdGrp).HasColumnName("GRP_GOT__ID_GRP");
            modelBuilder.Entity<GotSprt>().Property(item => item.PrtGotIdPrt).IsRequired();
            modelBuilder.Entity<GotSprt>().Property(item => item.PrtGotIdPrt).HasColumnName("PRT_GOT__ID_PRT");
            modelBuilder.Entity<GotSprt>().Property(item => item.IdSprt).IsRequired();
            modelBuilder.Entity<GotSprt>().Property(item => item.IdSprt).HasColumnName("ID_SPRT");
            modelBuilder.Entity<GotSprt>().Property(item => item.Libs).IsRequired();
            modelBuilder.Entity<GotSprt>().Property(item => item.Libs).HasMaxLength(500);
            modelBuilder.Entity<GotSprt>().Property(item => item.Libs).HasColumnName("LIBS");
            modelBuilder.Entity<GotSprt>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<GotSprt>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<GotSysUser>().ToTable("SYS_USER_GOT","GOT");
            modelBuilder.Entity<GotSysUser>().HasKey(item => new {item.CodeDbs,item.CodeTable,item.CodeColonne,item.NomUser,item.CodePrp });
            modelBuilder.Entity<GotSysUser>().Property(item => item.CodeDbs).IsRequired();
            modelBuilder.Entity<GotSysUser>().Property(item => item.CodeDbs).HasMaxLength(50);
            modelBuilder.Entity<GotSysUser>().Property(item => item.CodeDbs).HasColumnName("CODE_DBS");
            modelBuilder.Entity<GotSysUser>().Property(item => item.CodeTable).IsRequired();
            modelBuilder.Entity<GotSysUser>().Property(item => item.CodeTable).HasMaxLength(100);
            modelBuilder.Entity<GotSysUser>().Property(item => item.CodeTable).HasColumnName("CODE_TABLE");
            modelBuilder.Entity<GotSysUser>().Property(item => item.CodeColonne).IsRequired();
            modelBuilder.Entity<GotSysUser>().Property(item => item.CodeColonne).HasMaxLength(100);
            modelBuilder.Entity<GotSysUser>().Property(item => item.CodeColonne).HasColumnName("CODE_COLONNE");
            modelBuilder.Entity<GotSysUser>().Property(item => item.NomUser).IsRequired();
            modelBuilder.Entity<GotSysUser>().Property(item => item.NomUser).HasMaxLength(150);
            modelBuilder.Entity<GotSysUser>().Property(item => item.NomUser).HasColumnName("NOM_USER");
            modelBuilder.Entity<GotSysUser>().Property(item => item.CodePrp).IsRequired();
            modelBuilder.Entity<GotSysUser>().Property(item => item.CodePrp).HasMaxLength(255);
            modelBuilder.Entity<GotSysUser>().Property(item => item.CodePrp).HasColumnName("CODE_PRP");
            modelBuilder.Entity<GotSysUser>().Property(item => item.ValPrp).IsRequired();
            modelBuilder.Entity<GotSysUser>().Property(item => item.ValPrp).HasMaxLength(500);
            modelBuilder.Entity<GotSysUser>().Property(item => item.ValPrp).HasColumnName("VAL_PRP");
            modelBuilder.Entity<GotCdTypePv>().ToTable("CD_TYPE_PV_GOT","GOT");
            modelBuilder.Entity<GotCdTypePv>().HasKey(item => new {item.Code });
            modelBuilder.Entity<GotCdTypePv>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<GotCdTypePv>().Property(item => item.Code).HasMaxLength(15);
            modelBuilder.Entity<GotCdTypePv>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<GotCdTypePv>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<GotCdTypePv>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<GotCdTypePv>().Property(item => item.Cycle).HasColumnName("CYCLE");
            modelBuilder.Entity<GotCdTypePv>().Property(item => item.Cout).HasColumnName("COUT");
            modelBuilder.Entity<GotInsp>().ToTable("INSP_GOT","GOT");
            modelBuilder.Entity<GotInsp>().HasKey(item => new {item.DscGotNumGot,item.CampGotIdCamp });
            modelBuilder.Entity<GotInsp>().Property(item => item.DscGotNumGot).IsRequired();
            modelBuilder.Entity<GotInsp>().Property(item => item.DscGotNumGot).HasMaxLength(17);
            modelBuilder.Entity<GotInsp>().Property(item => item.DscGotNumGot).HasColumnName("DSC_GOT__NUM_GOT");
            modelBuilder.Entity<GotInsp>().Property(item => item.CampGotIdCamp).IsRequired();
            modelBuilder.Entity<GotInsp>().Property(item => item.CampGotIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GotInsp>().Property(item => item.CampGotIdCamp).HasColumnName("CAMP_GOT__ID_CAMP");
            modelBuilder.Entity<GotInsp>().Property(item => item.CdMeteoGotMeteo).HasMaxLength(60);
            modelBuilder.Entity<GotInsp>().Property(item => item.CdMeteoGotMeteo).HasColumnName("CD_METEO_GOT__METEO");
            modelBuilder.Entity<GotInsp>().Property(item => item.CdEtudeGotEtude).HasMaxLength(65);
            modelBuilder.Entity<GotInsp>().Property(item => item.CdEtudeGotEtude).HasColumnName("CD_ETUDE_GOT__ETUDE");
            modelBuilder.Entity<GotInsp>().Property(item => item.InspecteurGotNom).HasMaxLength(60);
            modelBuilder.Entity<GotInsp>().Property(item => item.InspecteurGotNom).HasColumnName("INSPECTEUR_GOT__NOM");
            modelBuilder.Entity<GotInsp>().Property(item => item.Etat).IsRequired();
            modelBuilder.Entity<GotInsp>().Property(item => item.Etat).HasMaxLength(25);
            modelBuilder.Entity<GotInsp>().Property(item => item.Etat).HasColumnName("ETAT");
            modelBuilder.Entity<GotInsp>().Property(item => item.Datev).HasColumnName("DATEV");
            modelBuilder.Entity<GotInsp>().Property(item => item.Temperature).HasColumnName("TEMPERATURE");
            modelBuilder.Entity<GotInsp>().Property(item => item.Moyen).HasMaxLength(500);
            modelBuilder.Entity<GotInsp>().Property(item => item.Moyen).HasColumnName("MOYEN");
            modelBuilder.Entity<GotInsp>().Property(item => item.Conditions).HasMaxLength(500);
            modelBuilder.Entity<GotInsp>().Property(item => item.Conditions).HasColumnName("CONDITIONS");
            modelBuilder.Entity<GotInsp>().Property(item => item.DateValid).HasColumnName("DATE_VALID");
            modelBuilder.Entity<GotInsp>().Property(item => item.NomValid).HasMaxLength(255);
            modelBuilder.Entity<GotInsp>().Property(item => item.NomValid).HasColumnName("NOM_VALID");
            modelBuilder.Entity<GotInsp>().Property(item => item.DescInva).HasMaxLength(1000);
            modelBuilder.Entity<GotInsp>().Property(item => item.DescInva).HasColumnName("DESC_INVA");
            modelBuilder.Entity<GotInsp>().Property(item => item.Securite).HasMaxLength(1000);
            modelBuilder.Entity<GotInsp>().Property(item => item.Securite).HasColumnName("SECURITE");
            modelBuilder.Entity<GotInsp>().Property(item => item.Prioritaire).HasMaxLength(1000);
            modelBuilder.Entity<GotInsp>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<GotInsp>().Property(item => item.Note1).HasColumnName("NOTE1");
            modelBuilder.Entity<GotInsp>().Property(item => item.Note2).HasColumnName("NOTE2");
            modelBuilder.Entity<GotInsp>().Property(item => item.Note3).HasColumnName("NOTE3");
            modelBuilder.Entity<GotInsp>().Property(item => item.Note4).HasColumnName("NOTE4");
            modelBuilder.Entity<GotInsp>().Property(item => item.Note5).HasColumnName("NOTE5");
            modelBuilder.Entity<GotInsp>().Property(item => item.Urgence).HasMaxLength(5);
            modelBuilder.Entity<GotInsp>().Property(item => item.Urgence).HasColumnName("URGENCE");
            modelBuilder.Entity<GotInsp>().Property(item => item.Qualite).HasMaxLength(25);
            modelBuilder.Entity<GotInsp>().Property(item => item.Qualite).HasColumnName("QUALITE");
            modelBuilder.Entity<GotCdCouche>().ToTable("CD_COUCHE_GOT","GOT");
            modelBuilder.Entity<GotCdCouche>().HasKey(item => new {item.Code });
            modelBuilder.Entity<GotCdCouche>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<GotCdCouche>().Property(item => item.Code).HasMaxLength(50);
            modelBuilder.Entity<GotCdCouche>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<GotCdCouche>().Property(item => item.Posit).HasColumnName("POSIT");
            modelBuilder.Entity<GotCdCouche>().Property(item => item.Couleur).HasMaxLength(16);
            modelBuilder.Entity<GotCdCouche>().Property(item => item.Couleur).HasColumnName("COULEUR");
            modelBuilder.Entity<GotCdCompactage>().ToTable("CD_COMPACTAGE_GOT","GOT");
            modelBuilder.Entity<GotCdCompactage>().HasKey(item => new {item.Code });
            modelBuilder.Entity<GotCdCompactage>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<GotCdCompactage>().Property(item => item.Code).HasMaxLength(50);
            modelBuilder.Entity<GotCdCompactage>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<GotCdEtude>().ToTable("CD_ETUDE_GOT","GOT");
            modelBuilder.Entity<GotCdEtude>().HasKey(item => new {item.Etude });
            modelBuilder.Entity<GotCdEtude>().Property(item => item.Etude).IsRequired();
            modelBuilder.Entity<GotCdEtude>().Property(item => item.Etude).HasMaxLength(65);
            modelBuilder.Entity<GotCdEtude>().Property(item => item.Etude).HasColumnName("ETUDE");
            modelBuilder.Entity<GotSeuilQualite>().ToTable("SEUIL_QUALITE_GOT","GOT");
            modelBuilder.Entity<GotSeuilQualite>().HasKey(item => new {item.CdQualiteGotQualite,item.IndiceUrgence });
            modelBuilder.Entity<GotSeuilQualite>().Property(item => item.CdQualiteGotQualite).IsRequired();
            modelBuilder.Entity<GotSeuilQualite>().Property(item => item.CdQualiteGotQualite).HasMaxLength(25);
            modelBuilder.Entity<GotSeuilQualite>().Property(item => item.CdQualiteGotQualite).HasColumnName("CD_QUALITE_GOT__QUALITE");
            modelBuilder.Entity<GotSeuilQualite>().Property(item => item.IndiceUrgence).IsRequired();
            modelBuilder.Entity<GotSeuilQualite>().Property(item => item.IndiceUrgence).HasMaxLength(5);
            modelBuilder.Entity<GotSeuilQualite>().Property(item => item.IndiceUrgence).HasColumnName("INDICE_URGENCE");
            modelBuilder.Entity<GotSeuilUrgence>().ToTable("SEUIL_URGENCE_GOT","GOT");
            modelBuilder.Entity<GotSeuilUrgence>().HasKey(item => new {item.Ordre });
            modelBuilder.Entity<GotSeuilUrgence>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<GotSeuilUrgence>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<GotSeuilUrgence>().Property(item => item.NbrNote).HasColumnName("NBR_NOTE");
            modelBuilder.Entity<GotSeuilUrgence>().Property(item => item.ValNote).HasColumnName("VAL_NOTE");
            modelBuilder.Entity<GotSeuilUrgence>().Property(item => item.Indice).HasColumnName("INDICE");
            modelBuilder.Entity<GotVst>().ToTable("VST_GOT","GOT");
            modelBuilder.Entity<GotVst>().HasKey(item => new {item.DscGotNumGot,item.CampGotIdCamp });
            modelBuilder.Entity<GotVst>().Property(item => item.DscGotNumGot).IsRequired();
            modelBuilder.Entity<GotVst>().Property(item => item.DscGotNumGot).HasMaxLength(17);
            modelBuilder.Entity<GotVst>().Property(item => item.DscGotNumGot).HasColumnName("DSC_GOT__NUM_GOT");
            modelBuilder.Entity<GotVst>().Property(item => item.CampGotIdCamp).IsRequired();
            modelBuilder.Entity<GotVst>().Property(item => item.CampGotIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GotVst>().Property(item => item.CampGotIdCamp).HasColumnName("CAMP_GOT__ID_CAMP");
            modelBuilder.Entity<GotVst>().Property(item => item.InspecteurGotNom).HasMaxLength(60);
            modelBuilder.Entity<GotVst>().Property(item => item.InspecteurGotNom).HasColumnName("INSPECTEUR_GOT__NOM");
            modelBuilder.Entity<GotVst>().Property(item => item.Etat).IsRequired();
            modelBuilder.Entity<GotVst>().Property(item => item.Etat).HasMaxLength(25);
            modelBuilder.Entity<GotVst>().Property(item => item.Etat).HasColumnName("ETAT");
            modelBuilder.Entity<GotVst>().Property(item => item.Datev).HasColumnName("DATEV");
            modelBuilder.Entity<GotVst>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<GotVst>().Property(item => item.Observ).HasMaxLength(500);
            modelBuilder.Entity<GotVst>().Property(item => item.Observ).HasColumnName("OBSERV");
            modelBuilder.Entity<GotVst>().Property(item => item.NoteVst).HasMaxLength(5);
            modelBuilder.Entity<GotVst>().Property(item => item.NoteVst).HasColumnName("NOTE_VST");
            modelBuilder.Entity<GotPhotoSprtVst>().ToTable("PHOTO_SPRT_VST_GOT","GOT");
            modelBuilder.Entity<GotPhotoSprtVst>().HasKey(item => new {item.DscGotNumGot,item.CampGotIdCamp,item.CdChapitreGotIdChap,item.CdLigneGotIdLigne,item.Id });
            modelBuilder.Entity<GotPhotoSprtVst>().Property(item => item.DscGotNumGot).IsRequired();
            modelBuilder.Entity<GotPhotoSprtVst>().Property(item => item.DscGotNumGot).HasMaxLength(17);
            modelBuilder.Entity<GotPhotoSprtVst>().Property(item => item.DscGotNumGot).HasColumnName("DSC_GOT__NUM_GOT");
            modelBuilder.Entity<GotPhotoSprtVst>().Property(item => item.CampGotIdCamp).IsRequired();
            modelBuilder.Entity<GotPhotoSprtVst>().Property(item => item.CampGotIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GotPhotoSprtVst>().Property(item => item.CampGotIdCamp).HasColumnName("CAMP_GOT__ID_CAMP");
            modelBuilder.Entity<GotPhotoSprtVst>().Property(item => item.CdChapitreGotIdChap).IsRequired();
            modelBuilder.Entity<GotPhotoSprtVst>().Property(item => item.CdChapitreGotIdChap).HasColumnName("CD_CHAPITRE_GOT__ID_CHAP");
            modelBuilder.Entity<GotPhotoSprtVst>().Property(item => item.CdLigneGotIdLigne).IsRequired();
            modelBuilder.Entity<GotPhotoSprtVst>().Property(item => item.CdLigneGotIdLigne).HasColumnName("CD_LIGNE_GOT__ID_LIGNE");
            modelBuilder.Entity<GotPhotoSprtVst>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<GotPhotoSprtVst>().Property(item => item.Id).HasMaxLength(50);
            modelBuilder.Entity<GotPhotoSprtVst>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<GotPhotoSprtVst>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<GotPhotoSprtVst>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<GotBpu>().ToTable("BPU_GOT","GOT");
            modelBuilder.Entity<GotBpu>().HasKey(item => new {item.IdBpu });
            modelBuilder.Entity<GotBpu>().Property(item => item.IdBpu).IsRequired();
            modelBuilder.Entity<GotBpu>().Property(item => item.IdBpu).HasColumnName("ID_BPU");
            modelBuilder.Entity<GotBpu>().Property(item => item.CdTravauxGotCode).IsRequired();
            modelBuilder.Entity<GotBpu>().Property(item => item.CdTravauxGotCode).HasMaxLength(60);
            modelBuilder.Entity<GotBpu>().Property(item => item.CdTravauxGotCode).HasColumnName("CD_TRAVAUX_GOT__CODE");
            modelBuilder.Entity<GotBpu>().Property(item => item.CdUniteGotUnite).HasMaxLength(12);
            modelBuilder.Entity<GotBpu>().Property(item => item.CdUniteGotUnite).HasColumnName("CD_UNITE_GOT__UNITE");
            modelBuilder.Entity<GotBpu>().Property(item => item.Techn).IsRequired();
            modelBuilder.Entity<GotBpu>().Property(item => item.Techn).HasMaxLength(255);
            modelBuilder.Entity<GotBpu>().Property(item => item.Techn).HasColumnName("TECHN");
            modelBuilder.Entity<GotBpu>().Property(item => item.Prix).IsRequired();
            modelBuilder.Entity<GotBpu>().Property(item => item.Prix).HasColumnName("PRIX");
            modelBuilder.Entity<GotBpu>().Property(item => item.DateMaj).HasColumnName("DATE_MAJ");
            modelBuilder.Entity<GotBpu>().Property(item => item.Freq).HasColumnName("FREQ");
            modelBuilder.Entity<GotBpu>().Property(item => item.PrecoVst).HasColumnName("PRECO_VST");
            modelBuilder.Entity<GotBpu>().Property(item => item.RealisVst).HasColumnName("REALIS_VST");
            modelBuilder.Entity<GotPrevision>().ToTable("PREVISION_GOT","GOT");
            modelBuilder.Entity<GotPrevision>().HasKey(item => new {item.BpuGotIdBpu,item.DscGotNumGot,item.DateDebut });
            modelBuilder.Entity<GotPrevision>().Property(item => item.BpuGotIdBpu).IsRequired();
            modelBuilder.Entity<GotPrevision>().Property(item => item.BpuGotIdBpu).HasColumnName("BPU_GOT__ID_BPU");
            modelBuilder.Entity<GotPrevision>().Property(item => item.DscGotNumGot).IsRequired();
            modelBuilder.Entity<GotPrevision>().Property(item => item.DscGotNumGot).HasMaxLength(17);
            modelBuilder.Entity<GotPrevision>().Property(item => item.DscGotNumGot).HasColumnName("DSC_GOT__NUM_GOT");
            modelBuilder.Entity<GotPrevision>().Property(item => item.DateDebut).IsRequired();
            modelBuilder.Entity<GotPrevision>().Property(item => item.DateDebut).HasColumnName("DATE_DEBUT");
            modelBuilder.Entity<GotPrevision>().Property(item => item.CdContrainteGotType).HasMaxLength(100);
            modelBuilder.Entity<GotPrevision>().Property(item => item.CdContrainteGotType).HasColumnName("CD_CONTRAINTE_GOT__TYPE");
            modelBuilder.Entity<GotPrevision>().Property(item => item.DateFin).HasColumnName("DATE_FIN");
            modelBuilder.Entity<GotPrevision>().Property(item => item.Montant).HasColumnName("MONTANT");
            modelBuilder.Entity<GotPrevision>().Property(item => item.DateDemPub).HasColumnName("DATE_DEM_PUB");
            modelBuilder.Entity<GotPrevision>().Property(item => item.Commentaire).HasMaxLength(255);
            modelBuilder.Entity<GotPrevision>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<GotPrevision>().Property(item => item.Realise).HasColumnName("REALISE");
            modelBuilder.Entity<GotCdContrainte>().ToTable("CD_CONTRAINTE_GOT","GOT");
            modelBuilder.Entity<GotCdContrainte>().HasKey(item => new {item.Type });
            modelBuilder.Entity<GotCdContrainte>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<GotCdContrainte>().Property(item => item.Type).HasMaxLength(100);
            modelBuilder.Entity<GotCdContrainte>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<GotPhotoInsp>().ToTable("PHOTO_INSP_GOT","GOT");
            modelBuilder.Entity<GotPhotoInsp>().HasKey(item => new {item.Id });
            modelBuilder.Entity<GotPhotoInsp>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<GotPhotoInsp>().Property(item => item.Id).HasMaxLength(30);
            modelBuilder.Entity<GotPhotoInsp>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<GotPhotoInsp>().Property(item => item.DscGotNumGot).IsRequired();
            modelBuilder.Entity<GotPhotoInsp>().Property(item => item.DscGotNumGot).HasMaxLength(17);
            modelBuilder.Entity<GotPhotoInsp>().Property(item => item.DscGotNumGot).HasColumnName("DSC_GOT__NUM_GOT");
            modelBuilder.Entity<GotPhotoInsp>().Property(item => item.CampGotIdCamp).IsRequired();
            modelBuilder.Entity<GotPhotoInsp>().Property(item => item.CampGotIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GotPhotoInsp>().Property(item => item.CampGotIdCamp).HasColumnName("CAMP_GOT__ID_CAMP");
            modelBuilder.Entity<GotPhotoInsp>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<GotPhotoInsp>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<GotPhotoVst>().ToTable("PHOTO_VST_GOT","GOT");
            modelBuilder.Entity<GotPhotoVst>().HasKey(item => new {item.Id });
            modelBuilder.Entity<GotPhotoVst>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<GotPhotoVst>().Property(item => item.Id).HasMaxLength(30);
            modelBuilder.Entity<GotPhotoVst>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<GotPhotoVst>().Property(item => item.DscGotNumGot).IsRequired();
            modelBuilder.Entity<GotPhotoVst>().Property(item => item.DscGotNumGot).HasMaxLength(17);
            modelBuilder.Entity<GotPhotoVst>().Property(item => item.DscGotNumGot).HasColumnName("DSC_GOT__NUM_GOT");
            modelBuilder.Entity<GotPhotoVst>().Property(item => item.CampGotIdCamp).IsRequired();
            modelBuilder.Entity<GotPhotoVst>().Property(item => item.CampGotIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GotPhotoVst>().Property(item => item.CampGotIdCamp).HasColumnName("CAMP_GOT__ID_CAMP");
            modelBuilder.Entity<GotPhotoVst>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<GotPhotoVst>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<GotCdQualite>().ToTable("CD_QUALITE_GOT","GOT");
            modelBuilder.Entity<GotCdQualite>().HasKey(item => new {item.Qualite });
            modelBuilder.Entity<GotCdQualite>().Property(item => item.Qualite).IsRequired();
            modelBuilder.Entity<GotCdQualite>().Property(item => item.Qualite).HasMaxLength(25);
            modelBuilder.Entity<GotCdQualite>().Property(item => item.Qualite).HasColumnName("QUALITE");
            modelBuilder.Entity<GotHistoNote>().ToTable("HISTO_NOTE_GOT","GOT");
            modelBuilder.Entity<GotHistoNote>().HasKey(item => new {item.DscGotNumGot,item.DateNote });
            modelBuilder.Entity<GotHistoNote>().Property(item => item.DscGotNumGot).IsRequired();
            modelBuilder.Entity<GotHistoNote>().Property(item => item.DscGotNumGot).HasMaxLength(17);
            modelBuilder.Entity<GotHistoNote>().Property(item => item.DscGotNumGot).HasColumnName("DSC_GOT__NUM_GOT");
            modelBuilder.Entity<GotHistoNote>().Property(item => item.DateNote).IsRequired();
            modelBuilder.Entity<GotHistoNote>().Property(item => item.DateNote).HasColumnName("DATE_NOTE");
            modelBuilder.Entity<GotHistoNote>().Property(item => item.CdOriginGotOrigine).IsRequired();
            modelBuilder.Entity<GotHistoNote>().Property(item => item.CdOriginGotOrigine).HasMaxLength(20);
            modelBuilder.Entity<GotHistoNote>().Property(item => item.CdOriginGotOrigine).HasColumnName("CD_ORIGIN_GOT__ORIGINE");
            modelBuilder.Entity<GotHistoNote>().Property(item => item.CdRisqueGotRisque).HasMaxLength(3);
            modelBuilder.Entity<GotHistoNote>().Property(item => item.CdRisqueGotRisque).HasColumnName("CD_RISQUE_GOT__RISQUE");
            modelBuilder.Entity<GotHistoNote>().Property(item => item.Note1).HasColumnName("NOTE1");
            modelBuilder.Entity<GotHistoNote>().Property(item => item.Note2).HasColumnName("NOTE2");
            modelBuilder.Entity<GotHistoNote>().Property(item => item.Note3).HasColumnName("NOTE3");
            modelBuilder.Entity<GotHistoNote>().Property(item => item.Note4).HasColumnName("NOTE4");
            modelBuilder.Entity<GotHistoNote>().Property(item => item.Note5).HasColumnName("NOTE5");
            modelBuilder.Entity<GotHistoNote>().Property(item => item.Urgence).HasMaxLength(5);
            modelBuilder.Entity<GotHistoNote>().Property(item => item.Urgence).HasColumnName("URGENCE");
            modelBuilder.Entity<GotHistoNote>().Property(item => item.Securite).HasColumnName("SECURITE");
            modelBuilder.Entity<GotHistoNote>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<GotCdOrigin>().ToTable("CD_ORIGIN_GOT","GOT");
            modelBuilder.Entity<GotCdOrigin>().HasKey(item => new {item.Origine });
            modelBuilder.Entity<GotCdOrigin>().Property(item => item.Origine).IsRequired();
            modelBuilder.Entity<GotCdOrigin>().Property(item => item.Origine).HasMaxLength(20);
            modelBuilder.Entity<GotCdOrigin>().Property(item => item.Origine).HasColumnName("ORIGINE");
            modelBuilder.Entity<GotCdRisque>().ToTable("CD_RISQUE_GOT","GOT");
            modelBuilder.Entity<GotCdRisque>().HasKey(item => new {item.Risque });
            modelBuilder.Entity<GotCdRisque>().Property(item => item.Risque).IsRequired();
            modelBuilder.Entity<GotCdRisque>().Property(item => item.Risque).HasMaxLength(3);
            modelBuilder.Entity<GotCdRisque>().Property(item => item.Risque).HasColumnName("RISQUE");
            modelBuilder.Entity<GotDictionnaire>().ToTable("DICTIONNAIRE_GOT","GOT");
            modelBuilder.Entity<GotDictionnaire>().HasKey(item => new {item.Nom });
            modelBuilder.Entity<GotDictionnaire>().Property(item => item.Nom).IsRequired();
            modelBuilder.Entity<GotDictionnaire>().Property(item => item.Nom).HasMaxLength(100);
            modelBuilder.Entity<GotDictionnaire>().Property(item => item.Nom).HasColumnName("NOM");
            modelBuilder.Entity<GotDictionnaire>().Property(item => item.Description).HasMaxLength(255);
            modelBuilder.Entity<GotDictionnaire>().Property(item => item.Description).HasColumnName("DESCRIPTION");
            modelBuilder.Entity<GotDictionnaire>().Property(item => item.Definition).HasMaxLength(500);
            modelBuilder.Entity<GotDictionnaire>().Property(item => item.Definition).HasColumnName("DEFINITION");
            modelBuilder.Entity<GotDictionnaire>().Property(item => item.Motscles).HasMaxLength(255);
            modelBuilder.Entity<GotDictionnaire>().Property(item => item.Motscles).HasColumnName("MOTSCLES");
            modelBuilder.Entity<GotCdType>().ToTable("CD_TYPE_GOT","GOT");
            modelBuilder.Entity<GotCdType>().HasKey(item => new {item.Type });
            modelBuilder.Entity<GotCdType>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<GotCdType>().Property(item => item.Type).HasMaxLength(20);
            modelBuilder.Entity<GotCdType>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<GotCdEvt>().ToTable("CD_EVT_GOT","GOT");
            modelBuilder.Entity<GotCdEvt>().HasKey(item => new {item.Type });
            modelBuilder.Entity<GotCdEvt>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<GotCdEvt>().Property(item => item.Type).HasMaxLength(25);
            modelBuilder.Entity<GotCdEvt>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<GotCdEvt>().Property(item => item.Impact).HasColumnName("IMPACT");
            modelBuilder.Entity<GotEvt>().ToTable("EVT_GOT","GOT");
            modelBuilder.Entity<GotEvt>().HasKey(item => new {item.CdEvtGotType,item.DscGotNumGot,item.DateRel });
            modelBuilder.Entity<GotEvt>().Property(item => item.CdEvtGotType).IsRequired();
            modelBuilder.Entity<GotEvt>().Property(item => item.CdEvtGotType).HasMaxLength(25);
            modelBuilder.Entity<GotEvt>().Property(item => item.CdEvtGotType).HasColumnName("CD_EVT_GOT__TYPE");
            modelBuilder.Entity<GotEvt>().Property(item => item.DscGotNumGot).IsRequired();
            modelBuilder.Entity<GotEvt>().Property(item => item.DscGotNumGot).HasMaxLength(17);
            modelBuilder.Entity<GotEvt>().Property(item => item.DscGotNumGot).HasColumnName("DSC_GOT__NUM_GOT");
            modelBuilder.Entity<GotEvt>().Property(item => item.DateRel).IsRequired();
            modelBuilder.Entity<GotEvt>().Property(item => item.DateRel).HasColumnName("DATE_REL");
            modelBuilder.Entity<GotEvt>().Property(item => item.DateTrt).HasColumnName("DATE_TRT");
            modelBuilder.Entity<GotEvt>().Property(item => item.Obsv).HasMaxLength(255);
            modelBuilder.Entity<GotEvt>().Property(item => item.Obsv).HasColumnName("OBSV");
            modelBuilder.Entity<GotCdLigne>().ToTable("CD_LIGNE_GOT","GOT");
            modelBuilder.Entity<GotCdLigne>().HasKey(item => new {item.CdChapitreGotIdChap,item.IdLigne });
            modelBuilder.Entity<GotCdLigne>().Property(item => item.CdChapitreGotIdChap).IsRequired();
            modelBuilder.Entity<GotCdLigne>().Property(item => item.CdChapitreGotIdChap).HasColumnName("CD_CHAPITRE_GOT__ID_CHAP");
            modelBuilder.Entity<GotCdLigne>().Property(item => item.IdLigne).IsRequired();
            modelBuilder.Entity<GotCdLigne>().Property(item => item.IdLigne).HasColumnName("ID_LIGNE");
            modelBuilder.Entity<GotCdLigne>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<GotCdLigne>().Property(item => item.Libelle).HasMaxLength(500);
            modelBuilder.Entity<GotCdLigne>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<GotCdLigne>().Property(item => item.OrdreLigne).IsRequired();
            modelBuilder.Entity<GotCdLigne>().Property(item => item.OrdreLigne).HasColumnName("ORDRE_LIGNE");
            modelBuilder.Entity<GotCdChapitre>().ToTable("CD_CHAPITRE_GOT","GOT");
            modelBuilder.Entity<GotCdChapitre>().HasKey(item => new {item.IdChap });
            modelBuilder.Entity<GotCdChapitre>().Property(item => item.IdChap).IsRequired();
            modelBuilder.Entity<GotCdChapitre>().Property(item => item.IdChap).HasColumnName("ID_CHAP");
            modelBuilder.Entity<GotCdChapitre>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<GotCdChapitre>().Property(item => item.Libelle).HasMaxLength(500);
            modelBuilder.Entity<GotCdChapitre>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<GotCdChapitre>().Property(item => item.OrdreChap).IsRequired();
            modelBuilder.Entity<GotCdChapitre>().Property(item => item.OrdreChap).HasColumnName("ORDRE_CHAP");
            modelBuilder.Entity<GotCdChapitre>().Property(item => item.Ponderation).HasColumnName("PONDERATION");
            modelBuilder.Entity<GotSprtVst>().ToTable("SPRT_VST_GOT","GOT");
            modelBuilder.Entity<GotSprtVst>().HasKey(item => new {item.DscGotNumGot,item.CampGotIdCamp,item.CdChapitreGotIdChap,item.CdLigneGotIdLigne });
            modelBuilder.Entity<GotSprtVst>().Property(item => item.DscGotNumGot).IsRequired();
            modelBuilder.Entity<GotSprtVst>().Property(item => item.DscGotNumGot).HasMaxLength(17);
            modelBuilder.Entity<GotSprtVst>().Property(item => item.DscGotNumGot).HasColumnName("DSC_GOT__NUM_GOT");
            modelBuilder.Entity<GotSprtVst>().Property(item => item.CampGotIdCamp).IsRequired();
            modelBuilder.Entity<GotSprtVst>().Property(item => item.CampGotIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GotSprtVst>().Property(item => item.CampGotIdCamp).HasColumnName("CAMP_GOT__ID_CAMP");
            modelBuilder.Entity<GotSprtVst>().Property(item => item.CdChapitreGotIdChap).IsRequired();
            modelBuilder.Entity<GotSprtVst>().Property(item => item.CdChapitreGotIdChap).HasColumnName("CD_CHAPITRE_GOT__ID_CHAP");
            modelBuilder.Entity<GotSprtVst>().Property(item => item.CdLigneGotIdLigne).IsRequired();
            modelBuilder.Entity<GotSprtVst>().Property(item => item.CdLigneGotIdLigne).HasColumnName("CD_LIGNE_GOT__ID_LIGNE");
            modelBuilder.Entity<GotSprtVst>().Property(item => item.Indice).IsRequired();
            modelBuilder.Entity<GotSprtVst>().Property(item => item.Indice).HasColumnName("INDICE");
            modelBuilder.Entity<GotSprtVst>().Property(item => item.Obs).HasMaxLength(500);
            modelBuilder.Entity<GotSprtVst>().Property(item => item.Obs).HasColumnName("OBS");
            modelBuilder.Entity<GotCdEntete>().ToTable("CD_ENTETE_GOT","GOT");
            modelBuilder.Entity<GotCdEntete>().HasKey(item => new {item.IdEntete });
            modelBuilder.Entity<GotCdEntete>().Property(item => item.IdEntete).IsRequired();
            modelBuilder.Entity<GotCdEntete>().Property(item => item.IdEntete).HasColumnName("ID_ENTETE");
            modelBuilder.Entity<GotCdEntete>().Property(item => item.CdComposantGotTypeComp).IsRequired();
            modelBuilder.Entity<GotCdEntete>().Property(item => item.CdComposantGotTypeComp).HasMaxLength(6);
            modelBuilder.Entity<GotCdEntete>().Property(item => item.CdComposantGotTypeComp).HasColumnName("CD_COMPOSANT_GOT__TYPE_COMP");
            modelBuilder.Entity<GotCdEntete>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<GotCdEntete>().Property(item => item.Libelle).HasMaxLength(500);
            modelBuilder.Entity<GotCdEntete>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<GotCdEntete>().Property(item => item.OrdreEnt).IsRequired();
            modelBuilder.Entity<GotCdEntete>().Property(item => item.OrdreEnt).HasColumnName("ORDRE_ENT");
            modelBuilder.Entity<GotCdEntete>().Property(item => item.Guide).HasMaxLength(500);
            modelBuilder.Entity<GotCdEntete>().Property(item => item.Guide).HasColumnName("GUIDE");
            modelBuilder.Entity<GotEntete>().ToTable("ENTETE_GOT","GOT");
            modelBuilder.Entity<GotEntete>().HasKey(item => new {item.DscGotNumGot,item.CampGotIdCamp,item.CdEnteteGotIdEntete });
            modelBuilder.Entity<GotEntete>().Property(item => item.DscGotNumGot).IsRequired();
            modelBuilder.Entity<GotEntete>().Property(item => item.DscGotNumGot).HasMaxLength(17);
            modelBuilder.Entity<GotEntete>().Property(item => item.DscGotNumGot).HasColumnName("DSC_GOT__NUM_GOT");
            modelBuilder.Entity<GotEntete>().Property(item => item.CampGotIdCamp).IsRequired();
            modelBuilder.Entity<GotEntete>().Property(item => item.CampGotIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GotEntete>().Property(item => item.CampGotIdCamp).HasColumnName("CAMP_GOT__ID_CAMP");
            modelBuilder.Entity<GotEntete>().Property(item => item.CdEnteteGotIdEntete).IsRequired();
            modelBuilder.Entity<GotEntete>().Property(item => item.CdEnteteGotIdEntete).HasColumnName("CD_ENTETE_GOT__ID_ENTETE");
            modelBuilder.Entity<GotEntete>().Property(item => item.Valeur).HasMaxLength(250);
            modelBuilder.Entity<GotEntete>().Property(item => item.Valeur).HasColumnName("VALEUR");
            modelBuilder.Entity<GotContact>().ToTable("CONTACT_GOT","GOT");
            modelBuilder.Entity<GotContact>().HasKey(item => new {item.DocGotId });
            modelBuilder.Entity<GotContact>().Property(item => item.DocGotId).IsRequired();
            modelBuilder.Entity<GotContact>().Property(item => item.DocGotId).HasColumnName("DOC_GOT__ID");
            modelBuilder.Entity<GotContact>().Property(item => item.Givenname).HasMaxLength(60);
            modelBuilder.Entity<GotContact>().Property(item => item.Givenname).HasColumnName("GIVENNAME");
            modelBuilder.Entity<GotContact>().Property(item => item.Sn).HasMaxLength(60);
            modelBuilder.Entity<GotContact>().Property(item => item.Sn).HasColumnName("SN");
            modelBuilder.Entity<GotContact>().Property(item => item.Cn).HasMaxLength(125);
            modelBuilder.Entity<GotContact>().Property(item => item.Cn).HasColumnName("CN");
            modelBuilder.Entity<GotContact>().Property(item => item.O).HasMaxLength(60);
            modelBuilder.Entity<GotContact>().Property(item => item.O).HasColumnName("O");
            modelBuilder.Entity<GotContact>().Property(item => item.Mail).HasMaxLength(60);
            modelBuilder.Entity<GotContact>().Property(item => item.Mail).HasColumnName("MAIL");
            modelBuilder.Entity<GotContact>().Property(item => item.Telephonenumber).HasMaxLength(20);
            modelBuilder.Entity<GotContact>().Property(item => item.Telephonenumber).HasColumnName("TELEPHONENUMBER");
            modelBuilder.Entity<GotContact>().Property(item => item.Mobile).HasMaxLength(20);
            modelBuilder.Entity<GotContact>().Property(item => item.Mobile).HasColumnName("MOBILE");
            modelBuilder.Entity<GotContact>().Property(item => item.Facsimiletelephonenumber).HasMaxLength(20);
            modelBuilder.Entity<GotContact>().Property(item => item.Facsimiletelephonenumber).HasColumnName("FACSIMILETELEPHONENUMBER");
            modelBuilder.Entity<GotContact>().Property(item => item.Street).HasMaxLength(60);
            modelBuilder.Entity<GotContact>().Property(item => item.Street).HasColumnName("STREET");
            modelBuilder.Entity<GotContact>().Property(item => item.Mozillaworkstreet2).HasMaxLength(60);
            modelBuilder.Entity<GotContact>().Property(item => item.Mozillaworkstreet2).HasColumnName("MOZILLAWORKSTREET2");
            modelBuilder.Entity<GotContact>().Property(item => item.L).HasMaxLength(60);
            modelBuilder.Entity<GotContact>().Property(item => item.L).HasColumnName("L");
            modelBuilder.Entity<GotContact>().Property(item => item.Postalcode).HasMaxLength(12);
            modelBuilder.Entity<GotContact>().Property(item => item.Postalcode).HasColumnName("POSTALCODE");
            modelBuilder.Entity<GotContact>().Property(item => item.Modifytimestamp).HasColumnName("MODIFYTIMESTAMP");
            modelBuilder.Entity<GotCdComposant>().ToTable("CD_COMPOSANT_GOT","GOT");
            modelBuilder.Entity<GotCdComposant>().HasKey(item => new {item.TypeComp });
            modelBuilder.Entity<GotCdComposant>().Property(item => item.TypeComp).IsRequired();
            modelBuilder.Entity<GotCdComposant>().Property(item => item.TypeComp).HasMaxLength(6);
            modelBuilder.Entity<GotCdComposant>().Property(item => item.TypeComp).HasColumnName("TYPE_COMP");
            modelBuilder.Entity<GotCdComposant>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<GotCdComposant>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<GotInspecteur>().ToTable("INSPECTEUR_GOT","GOT");
            modelBuilder.Entity<GotInspecteur>().HasKey(item => new {item.Nom });
            modelBuilder.Entity<GotInspecteur>().Property(item => item.Nom).IsRequired();
            modelBuilder.Entity<GotInspecteur>().Property(item => item.Nom).HasMaxLength(60);
            modelBuilder.Entity<GotInspecteur>().Property(item => item.Nom).HasColumnName("NOM");
            modelBuilder.Entity<GotInspecteur>().Property(item => item.CdPrestaGotPrestataire).IsRequired();
            modelBuilder.Entity<GotInspecteur>().Property(item => item.CdPrestaGotPrestataire).HasMaxLength(50);
            modelBuilder.Entity<GotInspecteur>().Property(item => item.CdPrestaGotPrestataire).HasColumnName("CD_PRESTA_GOT__PRESTATAIRE");
            modelBuilder.Entity<GotInspecteur>().Property(item => item.Fonc).HasMaxLength(60);
            modelBuilder.Entity<GotInspecteur>().Property(item => item.Fonc).HasColumnName("FONC");
            modelBuilder.Entity<GotCdUnite>().ToTable("CD_UNITE_GOT","GOT");
            modelBuilder.Entity<GotCdUnite>().HasKey(item => new {item.Unite });
            modelBuilder.Entity<GotCdUnite>().Property(item => item.Unite).IsRequired();
            modelBuilder.Entity<GotCdUnite>().Property(item => item.Unite).HasMaxLength(12);
            modelBuilder.Entity<GotCdUnite>().Property(item => item.Unite).HasColumnName("UNITE");
            modelBuilder.Entity<GotCdConclusion>().ToTable("CD_CONCLUSION_GOT","GOT");
            modelBuilder.Entity<GotCdConclusion>().HasKey(item => new {item.IdConc });
            modelBuilder.Entity<GotCdConclusion>().Property(item => item.IdConc).IsRequired();
            modelBuilder.Entity<GotCdConclusion>().Property(item => item.IdConc).HasColumnName("ID_CONC");
            modelBuilder.Entity<GotCdConclusion>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<GotCdConclusion>().Property(item => item.Libelle).HasMaxLength(500);
            modelBuilder.Entity<GotCdConclusion>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<GotCdConclusion>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<GotCdConclusion>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<GotDscTemp>().ToTable("DSC_TEMP_GOT","GOT");
            modelBuilder.Entity<GotDscTemp>().HasKey(item => new {item.CampGotIdCamp,item.NumGot });
            modelBuilder.Entity<GotDscTemp>().Property(item => item.CampGotIdCamp).IsRequired();
            modelBuilder.Entity<GotDscTemp>().Property(item => item.CampGotIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GotDscTemp>().Property(item => item.CampGotIdCamp).HasColumnName("CAMP_GOT__ID_CAMP");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.NumGot).IsRequired();
            modelBuilder.Entity<GotDscTemp>().Property(item => item.NumGot).HasMaxLength(17);
            modelBuilder.Entity<GotDscTemp>().Property(item => item.NumGot).HasColumnName("NUM_GOT");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.CdEntpGotEntreprise).HasMaxLength(60);
            modelBuilder.Entity<GotDscTemp>().Property(item => item.CdEntpGotEntreprise).HasColumnName("CD_ENTP_GOT__ENTREPRISE");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.CdTypeGotType).HasMaxLength(20);
            modelBuilder.Entity<GotDscTemp>().Property(item => item.CdTypeGotType).HasColumnName("CD_TYPE_GOT__TYPE");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.CdPenteGotPente).HasMaxLength(25);
            modelBuilder.Entity<GotDscTemp>().Property(item => item.CdPenteGotPente).HasColumnName("CD_PENTE_GOT__PENTE");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.CdProtectGotType).HasMaxLength(60);
            modelBuilder.Entity<GotDscTemp>().Property(item => item.CdProtectGotType).HasColumnName("CD_PROTECT_GOT__TYPE");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.CdFamGotFamille).IsRequired();
            modelBuilder.Entity<GotDscTemp>().Property(item => item.CdFamGotFamille).HasMaxLength(20);
            modelBuilder.Entity<GotDscTemp>().Property(item => item.CdFamGotFamille).HasColumnName("CD_FAM_GOT__FAMILLE");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.CdGeoGotGeologie).HasMaxLength(60);
            modelBuilder.Entity<GotDscTemp>().Property(item => item.CdGeoGotGeologie).HasColumnName("CD_GEO_GOT__GEOLOGIE");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.DscGotNumGot).HasMaxLength(17);
            modelBuilder.Entity<GotDscTemp>().Property(item => item.DscGotNumGot).HasColumnName("DSC_GOT__NUM_GOT");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<GotDscTemp>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<GotDscTemp>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<GotDscTemp>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<GotDscTemp>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<GotDscTemp>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<GotDscTemp>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.NumExploit).HasMaxLength(30);
            modelBuilder.Entity<GotDscTemp>().Property(item => item.NumExploit).HasColumnName("NUM_EXPLOIT");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.DateConst).HasColumnName("DATE_CONST");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.PenteTn).HasColumnName("PENTE_TN");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.Haut).HasColumnName("HAUT");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.LargCrete).HasColumnName("LARG_CRETE");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.Volume).HasColumnName("VOLUME");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.RisbNbr).HasColumnName("RISB_NBR");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.RisbEsp).HasColumnName("RISB_ESP");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.RisbLarg).HasColumnName("RISB_LARG");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.HautEau).HasColumnName("HAUT_EAU");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.Instable).HasColumnName("INSTABLE");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.NomUsage).HasMaxLength(255);
            modelBuilder.Entity<GotDscTemp>().Property(item => item.NomUsage).HasColumnName("NOM_USAGE");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.Note1).HasColumnName("NOTE1");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.Note2).HasColumnName("NOTE2");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.Note3).HasColumnName("NOTE3");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.Note4).HasColumnName("NOTE4");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.Note5).HasColumnName("NOTE5");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.Urgence).HasMaxLength(5);
            modelBuilder.Entity<GotDscTemp>().Property(item => item.Urgence).HasColumnName("URGENCE");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.DescInva).HasMaxLength(1000);
            modelBuilder.Entity<GotDscTemp>().Property(item => item.DescInva).HasColumnName("DESC_INVA");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.Securite).HasColumnName("SECURITE");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.ProsurvAnnee).HasColumnName("PROSURV_ANNEE");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.DernInsp).HasColumnName("DERN_INSP");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.DernVst).HasColumnName("DERN_VST");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.NoteVst).HasMaxLength(5);
            modelBuilder.Entity<GotDscTemp>().Property(item => item.NoteVst).HasColumnName("NOTE_VST");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.Archive).HasMaxLength(255);
            modelBuilder.Entity<GotDscTemp>().Property(item => item.Archive).HasColumnName("ARCHIVE");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.Commentaire).HasMaxLength(500);
            modelBuilder.Entity<GotDscTemp>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.X1).HasColumnName("X1");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.Y1).HasColumnName("Y1");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.Z1).HasColumnName("Z1");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.DateReleve).HasColumnName("DATE_RELEVE");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.Terrain).HasColumnName("TERRAIN");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.X2).HasColumnName("X2");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.Y2).HasColumnName("Y2");
            modelBuilder.Entity<GotDscTemp>().Property(item => item.Z2).HasColumnName("Z2");
            modelBuilder.Entity<GotEltInspTmp>().ToTable("ELT_INSP_TMP_GOT","GOT");
            modelBuilder.Entity<GotEltInspTmp>().HasKey(item => new {item.CampGotIdCamp,item.DscTempGotNumGot,item.GrpGotIdGrp,item.PrtGotIdPrt,item.SprtGotIdSprt,item.EltGotIdElem });
            modelBuilder.Entity<GotEltInspTmp>().Property(item => item.CampGotIdCamp).IsRequired();
            modelBuilder.Entity<GotEltInspTmp>().Property(item => item.CampGotIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GotEltInspTmp>().Property(item => item.CampGotIdCamp).HasColumnName("CAMP_GOT__ID_CAMP");
            modelBuilder.Entity<GotEltInspTmp>().Property(item => item.DscTempGotNumGot).IsRequired();
            modelBuilder.Entity<GotEltInspTmp>().Property(item => item.DscTempGotNumGot).HasMaxLength(17);
            modelBuilder.Entity<GotEltInspTmp>().Property(item => item.DscTempGotNumGot).HasColumnName("DSC_TEMP_GOT__NUM_GOT");
            modelBuilder.Entity<GotEltInspTmp>().Property(item => item.GrpGotIdGrp).IsRequired();
            modelBuilder.Entity<GotEltInspTmp>().Property(item => item.GrpGotIdGrp).HasColumnName("GRP_GOT__ID_GRP");
            modelBuilder.Entity<GotEltInspTmp>().Property(item => item.PrtGotIdPrt).IsRequired();
            modelBuilder.Entity<GotEltInspTmp>().Property(item => item.PrtGotIdPrt).HasColumnName("PRT_GOT__ID_PRT");
            modelBuilder.Entity<GotEltInspTmp>().Property(item => item.SprtGotIdSprt).IsRequired();
            modelBuilder.Entity<GotEltInspTmp>().Property(item => item.SprtGotIdSprt).HasColumnName("SPRT_GOT__ID_SPRT");
            modelBuilder.Entity<GotEltInspTmp>().Property(item => item.EltGotIdElem).IsRequired();
            modelBuilder.Entity<GotEltInspTmp>().Property(item => item.EltGotIdElem).HasColumnName("ELT_GOT__ID_ELEM");
            modelBuilder.Entity<GotEltInspTmp>().Property(item => item.Indice).IsRequired();
            modelBuilder.Entity<GotEltInspTmp>().Property(item => item.Indice).HasColumnName("INDICE");
            modelBuilder.Entity<GotEltInspTmp>().Property(item => item.Obs).HasMaxLength(255);
            modelBuilder.Entity<GotEltInspTmp>().Property(item => item.Obs).HasColumnName("OBS");
            modelBuilder.Entity<GotPhotoEltInspTmp>().ToTable("PHOTO_ELT_INSP_TMP_GOT","GOT");
            modelBuilder.Entity<GotPhotoEltInspTmp>().HasKey(item => new {item.GrpGotIdGrp,item.PrtGotIdPrt,item.SprtGotIdSprt,item.CampGotIdCamp,item.DscTempGotNumGot,item.EltGotIdElem,item.Id });
            modelBuilder.Entity<GotPhotoEltInspTmp>().Property(item => item.GrpGotIdGrp).IsRequired();
            modelBuilder.Entity<GotPhotoEltInspTmp>().Property(item => item.GrpGotIdGrp).HasColumnName("GRP_GOT__ID_GRP");
            modelBuilder.Entity<GotPhotoEltInspTmp>().Property(item => item.PrtGotIdPrt).IsRequired();
            modelBuilder.Entity<GotPhotoEltInspTmp>().Property(item => item.PrtGotIdPrt).HasColumnName("PRT_GOT__ID_PRT");
            modelBuilder.Entity<GotPhotoEltInspTmp>().Property(item => item.SprtGotIdSprt).IsRequired();
            modelBuilder.Entity<GotPhotoEltInspTmp>().Property(item => item.SprtGotIdSprt).HasColumnName("SPRT_GOT__ID_SPRT");
            modelBuilder.Entity<GotPhotoEltInspTmp>().Property(item => item.CampGotIdCamp).IsRequired();
            modelBuilder.Entity<GotPhotoEltInspTmp>().Property(item => item.CampGotIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GotPhotoEltInspTmp>().Property(item => item.CampGotIdCamp).HasColumnName("CAMP_GOT__ID_CAMP");
            modelBuilder.Entity<GotPhotoEltInspTmp>().Property(item => item.DscTempGotNumGot).IsRequired();
            modelBuilder.Entity<GotPhotoEltInspTmp>().Property(item => item.DscTempGotNumGot).HasMaxLength(17);
            modelBuilder.Entity<GotPhotoEltInspTmp>().Property(item => item.DscTempGotNumGot).HasColumnName("DSC_TEMP_GOT__NUM_GOT");
            modelBuilder.Entity<GotPhotoEltInspTmp>().Property(item => item.EltGotIdElem).IsRequired();
            modelBuilder.Entity<GotPhotoEltInspTmp>().Property(item => item.EltGotIdElem).HasColumnName("ELT_GOT__ID_ELEM");
            modelBuilder.Entity<GotPhotoEltInspTmp>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<GotPhotoEltInspTmp>().Property(item => item.Id).HasMaxLength(50);
            modelBuilder.Entity<GotPhotoEltInspTmp>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<GotPhotoEltInspTmp>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<GotPhotoEltInspTmp>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<GotInspTmp>().ToTable("INSP_TMP_GOT","GOT");
            modelBuilder.Entity<GotInspTmp>().HasKey(item => new {item.CampGotIdCamp,item.DscTempGotNumGot });
            modelBuilder.Entity<GotInspTmp>().Property(item => item.CampGotIdCamp).IsRequired();
            modelBuilder.Entity<GotInspTmp>().Property(item => item.CampGotIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GotInspTmp>().Property(item => item.CampGotIdCamp).HasColumnName("CAMP_GOT__ID_CAMP");
            modelBuilder.Entity<GotInspTmp>().Property(item => item.DscTempGotNumGot).IsRequired();
            modelBuilder.Entity<GotInspTmp>().Property(item => item.DscTempGotNumGot).HasMaxLength(17);
            modelBuilder.Entity<GotInspTmp>().Property(item => item.DscTempGotNumGot).HasColumnName("DSC_TEMP_GOT__NUM_GOT");
            modelBuilder.Entity<GotInspTmp>().Property(item => item.CdMeteoGotMeteo).HasMaxLength(60);
            modelBuilder.Entity<GotInspTmp>().Property(item => item.CdMeteoGotMeteo).HasColumnName("CD_METEO_GOT__METEO");
            modelBuilder.Entity<GotInspTmp>().Property(item => item.CdEtudeGotEtude).HasMaxLength(65);
            modelBuilder.Entity<GotInspTmp>().Property(item => item.CdEtudeGotEtude).HasColumnName("CD_ETUDE_GOT__ETUDE");
            modelBuilder.Entity<GotInspTmp>().Property(item => item.InspecteurGotNom).HasMaxLength(60);
            modelBuilder.Entity<GotInspTmp>().Property(item => item.InspecteurGotNom).HasColumnName("INSPECTEUR_GOT__NOM");
            modelBuilder.Entity<GotInspTmp>().Property(item => item.Etat).IsRequired();
            modelBuilder.Entity<GotInspTmp>().Property(item => item.Etat).HasMaxLength(25);
            modelBuilder.Entity<GotInspTmp>().Property(item => item.Etat).HasColumnName("ETAT");
            modelBuilder.Entity<GotInspTmp>().Property(item => item.Datev).HasColumnName("DATEV");
            modelBuilder.Entity<GotInspTmp>().Property(item => item.Temperature).HasColumnName("TEMPERATURE");
            modelBuilder.Entity<GotInspTmp>().Property(item => item.Moyen).HasMaxLength(500);
            modelBuilder.Entity<GotInspTmp>().Property(item => item.Moyen).HasColumnName("MOYEN");
            modelBuilder.Entity<GotInspTmp>().Property(item => item.Conditions).HasMaxLength(500);
            modelBuilder.Entity<GotInspTmp>().Property(item => item.Conditions).HasColumnName("CONDITIONS");
            modelBuilder.Entity<GotInspTmp>().Property(item => item.DateValid).HasColumnName("DATE_VALID");
            modelBuilder.Entity<GotInspTmp>().Property(item => item.NomValid).HasMaxLength(255);
            modelBuilder.Entity<GotInspTmp>().Property(item => item.NomValid).HasColumnName("NOM_VALID");
            modelBuilder.Entity<GotInspTmp>().Property(item => item.DescInva).HasMaxLength(1000);
            modelBuilder.Entity<GotInspTmp>().Property(item => item.DescInva).HasColumnName("DESC_INVA");
            modelBuilder.Entity<GotInspTmp>().Property(item => item.Securite).HasMaxLength(1000);
            modelBuilder.Entity<GotInspTmp>().Property(item => item.Securite).HasColumnName("SECURITE");
            modelBuilder.Entity<GotInspTmp>().Property(item => item.Prioritaire).HasMaxLength(1000);
            modelBuilder.Entity<GotInspTmp>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<GotInspTmp>().Property(item => item.Note1).HasColumnName("NOTE1");
            modelBuilder.Entity<GotInspTmp>().Property(item => item.Note2).HasColumnName("NOTE2");
            modelBuilder.Entity<GotInspTmp>().Property(item => item.Note3).HasColumnName("NOTE3");
            modelBuilder.Entity<GotInspTmp>().Property(item => item.Note4).HasColumnName("NOTE4");
            modelBuilder.Entity<GotInspTmp>().Property(item => item.Note5).HasColumnName("NOTE5");
            modelBuilder.Entity<GotInspTmp>().Property(item => item.Urgence).HasMaxLength(5);
            modelBuilder.Entity<GotInspTmp>().Property(item => item.Urgence).HasColumnName("URGENCE");
            modelBuilder.Entity<GotInspTmp>().Property(item => item.Qualite).HasMaxLength(25);
            modelBuilder.Entity<GotInspTmp>().Property(item => item.Qualite).HasColumnName("QUALITE");
            modelBuilder.Entity<GotPhotoInspTmp>().ToTable("PHOTO_INSP_TMP_GOT","GOT");
            modelBuilder.Entity<GotPhotoInspTmp>().HasKey(item => new {item.Id });
            modelBuilder.Entity<GotPhotoInspTmp>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<GotPhotoInspTmp>().Property(item => item.Id).HasMaxLength(30);
            modelBuilder.Entity<GotPhotoInspTmp>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<GotPhotoInspTmp>().Property(item => item.CampGotIdCamp).IsRequired();
            modelBuilder.Entity<GotPhotoInspTmp>().Property(item => item.CampGotIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GotPhotoInspTmp>().Property(item => item.CampGotIdCamp).HasColumnName("CAMP_GOT__ID_CAMP");
            modelBuilder.Entity<GotPhotoInspTmp>().Property(item => item.DscTempGotNumGot).IsRequired();
            modelBuilder.Entity<GotPhotoInspTmp>().Property(item => item.DscTempGotNumGot).HasMaxLength(17);
            modelBuilder.Entity<GotPhotoInspTmp>().Property(item => item.DscTempGotNumGot).HasColumnName("DSC_TEMP_GOT__NUM_GOT");
            modelBuilder.Entity<GotPhotoInspTmp>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<GotPhotoInspTmp>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<GotClsDoc>().ToTable("CLS_DOC_GOT","GOT");
            modelBuilder.Entity<GotClsDoc>().HasKey(item => new {item.ClsGotId,item.DocGotId });
            modelBuilder.Entity<GotClsDoc>().Property(item => item.ClsGotId).IsRequired();
            modelBuilder.Entity<GotClsDoc>().Property(item => item.ClsGotId).HasColumnName("CLS_GOT__ID");
            modelBuilder.Entity<GotClsDoc>().Property(item => item.DocGotId).IsRequired();
            modelBuilder.Entity<GotClsDoc>().Property(item => item.DocGotId).HasColumnName("DOC_GOT__ID");
            modelBuilder.Entity<GotClsDoc>().Property(item => item.Defaut).HasColumnName("DEFAUT");
            modelBuilder.Entity<GotClsDoc>().Property(item => item.Dossier).HasMaxLength(15);
            modelBuilder.Entity<GotClsDoc>().Property(item => item.Dossier).HasColumnName("DOSSIER");
            modelBuilder.Entity<GotCouche>().ToTable("COUCHE_GOT","GOT");
            modelBuilder.Entity<GotCouche>().HasKey(item => new {item.CdCoucheGotCode,item.DscGotNumGot,item.CdTraitementGotType,item.CdHydriqueGotEtat,item.CdMateriauGotType,item.CdCompactageGotCode });
            modelBuilder.Entity<GotCouche>().Property(item => item.CdCoucheGotCode).IsRequired();
            modelBuilder.Entity<GotCouche>().Property(item => item.CdCoucheGotCode).HasMaxLength(50);
            modelBuilder.Entity<GotCouche>().Property(item => item.CdCoucheGotCode).HasColumnName("CD_COUCHE_GOT__CODE");
            modelBuilder.Entity<GotCouche>().Property(item => item.DscGotNumGot).IsRequired();
            modelBuilder.Entity<GotCouche>().Property(item => item.DscGotNumGot).HasMaxLength(17);
            modelBuilder.Entity<GotCouche>().Property(item => item.DscGotNumGot).HasColumnName("DSC_GOT__NUM_GOT");
            modelBuilder.Entity<GotCouche>().Property(item => item.CdTraitementGotType).IsRequired();
            modelBuilder.Entity<GotCouche>().Property(item => item.CdTraitementGotType).HasMaxLength(25);
            modelBuilder.Entity<GotCouche>().Property(item => item.CdTraitementGotType).HasColumnName("CD_TRAITEMENT_GOT__TYPE");
            modelBuilder.Entity<GotCouche>().Property(item => item.CdHydriqueGotEtat).IsRequired();
            modelBuilder.Entity<GotCouche>().Property(item => item.CdHydriqueGotEtat).HasMaxLength(25);
            modelBuilder.Entity<GotCouche>().Property(item => item.CdHydriqueGotEtat).HasColumnName("CD_HYDRIQUE_GOT__ETAT");
            modelBuilder.Entity<GotCouche>().Property(item => item.CdMateriauGotType).IsRequired();
            modelBuilder.Entity<GotCouche>().Property(item => item.CdMateriauGotType).HasMaxLength(60);
            modelBuilder.Entity<GotCouche>().Property(item => item.CdMateriauGotType).HasColumnName("CD_MATERIAU_GOT__TYPE");
            modelBuilder.Entity<GotCouche>().Property(item => item.CdCompactageGotCode).IsRequired();
            modelBuilder.Entity<GotCouche>().Property(item => item.CdCompactageGotCode).HasMaxLength(50);
            modelBuilder.Entity<GotCouche>().Property(item => item.CdCompactageGotCode).HasColumnName("CD_COMPACTAGE_GOT__CODE");
            modelBuilder.Entity<GotCouche>().Property(item => item.Epai).HasColumnName("EPAI");
            modelBuilder.Entity<GotCouche>().Property(item => item.Obs).HasMaxLength(255);
            modelBuilder.Entity<GotCouche>().Property(item => item.Obs).HasColumnName("OBS");
            modelBuilder.Entity<GotDscCamp>().ToTable("DSC_CAMP_GOT","GOT");
            modelBuilder.Entity<GotDscCamp>().HasKey(item => new {item.DscGotNumGot,item.CampGotIdCamp });
            modelBuilder.Entity<GotDscCamp>().Property(item => item.DscGotNumGot).IsRequired();
            modelBuilder.Entity<GotDscCamp>().Property(item => item.DscGotNumGot).HasMaxLength(17);
            modelBuilder.Entity<GotDscCamp>().Property(item => item.DscGotNumGot).HasColumnName("DSC_GOT__NUM_GOT");
            modelBuilder.Entity<GotDscCamp>().Property(item => item.CampGotIdCamp).IsRequired();
            modelBuilder.Entity<GotDscCamp>().Property(item => item.CampGotIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GotDscCamp>().Property(item => item.CampGotIdCamp).HasColumnName("CAMP_GOT__ID_CAMP");
            modelBuilder.Entity<GotDscCamp>().Property(item => item.Realiser).HasColumnName("REALISER");
            modelBuilder.Entity<GotCdPrecoSprtVst>().ToTable("CD_PRECO__SPRT_VST_GOT","GOT");
            modelBuilder.Entity<GotCdPrecoSprtVst>().HasKey(item => new {item.DscGotNumGot,item.CampGotIdCamp,item.BpuGotIdBpu });
            modelBuilder.Entity<GotCdPrecoSprtVst>().Property(item => item.DscGotNumGot).IsRequired();
            modelBuilder.Entity<GotCdPrecoSprtVst>().Property(item => item.DscGotNumGot).HasMaxLength(17);
            modelBuilder.Entity<GotCdPrecoSprtVst>().Property(item => item.DscGotNumGot).HasColumnName("DSC_GOT__NUM_GOT");
            modelBuilder.Entity<GotCdPrecoSprtVst>().Property(item => item.CampGotIdCamp).IsRequired();
            modelBuilder.Entity<GotCdPrecoSprtVst>().Property(item => item.CampGotIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GotCdPrecoSprtVst>().Property(item => item.CampGotIdCamp).HasColumnName("CAMP_GOT__ID_CAMP");
            modelBuilder.Entity<GotCdPrecoSprtVst>().Property(item => item.BpuGotIdBpu).IsRequired();
            modelBuilder.Entity<GotCdPrecoSprtVst>().Property(item => item.BpuGotIdBpu).HasColumnName("BPU_GOT__ID_BPU");
            modelBuilder.Entity<GotCdPrecoSprtVst>().Property(item => item.Realise).HasColumnName("REALISE");
            modelBuilder.Entity<GotCdConclusionInsp>().ToTable("CD_CONCLUSION__INSP_GOT","GOT");
            modelBuilder.Entity<GotCdConclusionInsp>().HasKey(item => new {item.DscGotNumGot,item.CampGotIdCamp,item.CdConclusionGotIdConc });
            modelBuilder.Entity<GotCdConclusionInsp>().Property(item => item.DscGotNumGot).IsRequired();
            modelBuilder.Entity<GotCdConclusionInsp>().Property(item => item.DscGotNumGot).HasMaxLength(17);
            modelBuilder.Entity<GotCdConclusionInsp>().Property(item => item.DscGotNumGot).HasColumnName("DSC_GOT__NUM_GOT");
            modelBuilder.Entity<GotCdConclusionInsp>().Property(item => item.CampGotIdCamp).IsRequired();
            modelBuilder.Entity<GotCdConclusionInsp>().Property(item => item.CampGotIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GotCdConclusionInsp>().Property(item => item.CampGotIdCamp).HasColumnName("CAMP_GOT__ID_CAMP");
            modelBuilder.Entity<GotCdConclusionInsp>().Property(item => item.CdConclusionGotIdConc).IsRequired();
            modelBuilder.Entity<GotCdConclusionInsp>().Property(item => item.CdConclusionGotIdConc).HasColumnName("CD_CONCLUSION_GOT__ID_CONC");
            modelBuilder.Entity<GotCdConclusionInsp>().Property(item => item.Contenu).HasMaxLength(1000);
            modelBuilder.Entity<GotCdConclusionInsp>().Property(item => item.Contenu).HasColumnName("CONTENU");
            modelBuilder.Entity<GotCdConclusionInspTmp>().ToTable("CD_CONCLUSION__INSP_TMP_GOT","GOT");
            modelBuilder.Entity<GotCdConclusionInspTmp>().HasKey(item => new {item.CampGotIdCamp,item.DscTempGotNumGot,item.CdConclusionGotIdConc });
            modelBuilder.Entity<GotCdConclusionInspTmp>().Property(item => item.CampGotIdCamp).IsRequired();
            modelBuilder.Entity<GotCdConclusionInspTmp>().Property(item => item.CampGotIdCamp).HasMaxLength(100);
            modelBuilder.Entity<GotCdConclusionInspTmp>().Property(item => item.CampGotIdCamp).HasColumnName("CAMP_GOT__ID_CAMP");
            modelBuilder.Entity<GotCdConclusionInspTmp>().Property(item => item.DscTempGotNumGot).IsRequired();
            modelBuilder.Entity<GotCdConclusionInspTmp>().Property(item => item.DscTempGotNumGot).HasMaxLength(17);
            modelBuilder.Entity<GotCdConclusionInspTmp>().Property(item => item.DscTempGotNumGot).HasColumnName("DSC_TEMP_GOT__NUM_GOT");
            modelBuilder.Entity<GotCdConclusionInspTmp>().Property(item => item.CdConclusionGotIdConc).IsRequired();
            modelBuilder.Entity<GotCdConclusionInspTmp>().Property(item => item.CdConclusionGotIdConc).HasColumnName("CD_CONCLUSION_GOT__ID_CONC");
            modelBuilder.Entity<GotCdConclusionInspTmp>().Property(item => item.Contenu).HasMaxLength(1000);
            modelBuilder.Entity<GotCdConclusionInspTmp>().Property(item => item.Contenu).HasColumnName("CONTENU");
            modelBuilder.Entity<InfLiaison>().ToTable("LIAISON_INF","INF");
            modelBuilder.Entity<InfLiaison>().HasKey(item => new {item.Liaison });
            modelBuilder.Entity<InfLiaison>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<InfLiaison>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<InfLiaison>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<InfLiaison>().Property(item => item.CdLiaisonInfCdLiaison).IsRequired();
            modelBuilder.Entity<InfLiaison>().Property(item => item.CdLiaisonInfCdLiaison).HasMaxLength(5);
            modelBuilder.Entity<InfLiaison>().Property(item => item.CdLiaisonInfCdLiaison).HasColumnName("CD_LIAISON_INF__CD_LIAISON");
            modelBuilder.Entity<InfLiaison>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<InfLiaison>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<InfCdLiaison>().ToTable("CD_LIAISON_INF","INF");
            modelBuilder.Entity<InfCdLiaison>().HasKey(item => new {item.CdLiaison });
            modelBuilder.Entity<InfCdLiaison>().Property(item => item.CdLiaison).IsRequired();
            modelBuilder.Entity<InfCdLiaison>().Property(item => item.CdLiaison).HasMaxLength(5);
            modelBuilder.Entity<InfCdLiaison>().Property(item => item.CdLiaison).HasColumnName("CD_LIAISON");
            modelBuilder.Entity<InfCdLiaison>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<InfCdLiaison>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<InfCdLiaison>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<InfChaussee>().ToTable("CHAUSSEE_INF","INF");
            modelBuilder.Entity<InfChaussee>().HasKey(item => new {item.LiaisonInfLiaison,item.Sens });
            modelBuilder.Entity<InfChaussee>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfChaussee>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfChaussee>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfChaussee>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<InfChaussee>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<InfChaussee>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<InfChaussee>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<InfChaussee>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<InfChaussee>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<InfChaussee>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<InfChaussee>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<InfChaussee>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<InfChaussee>().Property(item => item.Tenant).HasMaxLength(60);
            modelBuilder.Entity<InfChaussee>().Property(item => item.Tenant).HasColumnName("TENANT");
            modelBuilder.Entity<InfChaussee>().Property(item => item.About).HasMaxLength(60);
            modelBuilder.Entity<InfChaussee>().Property(item => item.About).HasColumnName("ABOUT");
            modelBuilder.Entity<InfPtSing>().ToTable("PT_SING_INF","INF");
            modelBuilder.Entity<InfPtSing>().HasKey(item => new {item.LiaisonInfLiaison,item.ChausseeInfSens,item.CdPtSingInfCode,item.AbsDeb });
            modelBuilder.Entity<InfPtSing>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfPtSing>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfPtSing>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfPtSing>().Property(item => item.ChausseeInfSens).IsRequired();
            modelBuilder.Entity<InfPtSing>().Property(item => item.ChausseeInfSens).HasMaxLength(6);
            modelBuilder.Entity<InfPtSing>().Property(item => item.ChausseeInfSens).HasColumnName("CHAUSSEE_INF__SENS");
            modelBuilder.Entity<InfPtSing>().Property(item => item.CdPtSingInfCode).IsRequired();
            modelBuilder.Entity<InfPtSing>().Property(item => item.CdPtSingInfCode).HasMaxLength(6);
            modelBuilder.Entity<InfPtSing>().Property(item => item.CdPtSingInfCode).HasColumnName("CD_PT_SING_INF__CODE");
            modelBuilder.Entity<InfPtSing>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<InfPtSing>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<InfPtSing>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<InfPtSing>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<InfPtSing>().Property(item => item.NomUsage).HasMaxLength(60);
            modelBuilder.Entity<InfPtSing>().Property(item => item.NomUsage).HasColumnName("NOM_USAGE");
            modelBuilder.Entity<InfPtSing>().Property(item => item.Commentaire).HasMaxLength(1000);
            modelBuilder.Entity<InfPtSing>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<InfCdPtSing>().ToTable("CD_PT_SING_INF","INF");
            modelBuilder.Entity<InfCdPtSing>().HasKey(item => new {item.Code });
            modelBuilder.Entity<InfCdPtSing>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<InfCdPtSing>().Property(item => item.Code).HasMaxLength(6);
            modelBuilder.Entity<InfCdPtSing>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<InfCdPtSing>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<InfCdPtSing>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<InfCdPtSing>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<InfCls>().ToTable("CLS_INF","INF");
            modelBuilder.Entity<InfCls>().HasKey(item => new {item.Id });
            modelBuilder.Entity<InfCls>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<InfCls>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<InfCls>().Property(item => item.TableName).IsRequired();
            modelBuilder.Entity<InfCls>().Property(item => item.TableName).HasMaxLength(40);
            modelBuilder.Entity<InfCls>().Property(item => item.TableName).HasColumnName("TABLE_NAME");
            modelBuilder.Entity<InfCls>().Property(item => item.KeyValue).IsRequired();
            modelBuilder.Entity<InfCls>().Property(item => item.KeyValue).HasMaxLength(100);
            modelBuilder.Entity<InfCls>().Property(item => item.KeyValue).HasColumnName("KEY_VALUE");
            modelBuilder.Entity<InfCdDoc>().ToTable("CD_DOC_INF","INF");
            modelBuilder.Entity<InfCdDoc>().HasKey(item => new {item.Code });
            modelBuilder.Entity<InfCdDoc>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<InfCdDoc>().Property(item => item.Code).HasMaxLength(15);
            modelBuilder.Entity<InfCdDoc>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<InfCdDoc>().Property(item => item.Path).IsRequired();
            modelBuilder.Entity<InfCdDoc>().Property(item => item.Path).HasMaxLength(255);
            modelBuilder.Entity<InfCdDoc>().Property(item => item.Path).HasColumnName("PATH");
            modelBuilder.Entity<InfCdDoc>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<InfCdDoc>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<InfCdDoc>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<InfDoc>().ToTable("DOC_INF","INF");
            modelBuilder.Entity<InfDoc>().HasKey(item => new {item.Id });
            modelBuilder.Entity<InfDoc>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<InfDoc>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<InfDoc>().Property(item => item.CdDocInfCode).IsRequired();
            modelBuilder.Entity<InfDoc>().Property(item => item.CdDocInfCode).HasMaxLength(15);
            modelBuilder.Entity<InfDoc>().Property(item => item.CdDocInfCode).HasColumnName("CD_DOC_INF__CODE");
            modelBuilder.Entity<InfDoc>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<InfDoc>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<InfDoc>().Property(item => item.Ref).IsRequired();
            modelBuilder.Entity<InfDoc>().Property(item => item.Ref).HasMaxLength(50);
            modelBuilder.Entity<InfDoc>().Property(item => item.Ref).HasColumnName("REF");
            modelBuilder.Entity<InfCdDec>().ToTable("CD_DEC_INF","INF");
            modelBuilder.Entity<InfCdDec>().HasKey(item => new {item.FamDecInfFamDec,item.CdDec });
            modelBuilder.Entity<InfCdDec>().Property(item => item.FamDecInfFamDec).IsRequired();
            modelBuilder.Entity<InfCdDec>().Property(item => item.FamDecInfFamDec).HasMaxLength(6);
            modelBuilder.Entity<InfCdDec>().Property(item => item.FamDecInfFamDec).HasColumnName("FAM_DEC_INF__FAM_DEC");
            modelBuilder.Entity<InfCdDec>().Property(item => item.CdDec).IsRequired();
            modelBuilder.Entity<InfCdDec>().Property(item => item.CdDec).HasMaxLength(15);
            modelBuilder.Entity<InfCdDec>().Property(item => item.CdDec).HasColumnName("CD_DEC");
            modelBuilder.Entity<InfCdDec>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<InfCdDec>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<InfCdDec>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<InfFamDec>().ToTable("FAM_DEC_INF","INF");
            modelBuilder.Entity<InfFamDec>().HasKey(item => new {item.FamDec });
            modelBuilder.Entity<InfFamDec>().Property(item => item.FamDec).IsRequired();
            modelBuilder.Entity<InfFamDec>().Property(item => item.FamDec).HasMaxLength(6);
            modelBuilder.Entity<InfFamDec>().Property(item => item.FamDec).HasColumnName("FAM_DEC");
            modelBuilder.Entity<InfFamDec>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<InfFamDec>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<InfFamDec>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<InfTrDec>().ToTable("TR_DEC_INF","INF");
            modelBuilder.Entity<InfTrDec>().HasKey(item => new {item.LiaisonInfLiaison,item.ChausseeInfSens,item.FamDecInfFamDec,item.CdDecInfCdDec,item.AbsDeb });
            modelBuilder.Entity<InfTrDec>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfTrDec>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfTrDec>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfTrDec>().Property(item => item.ChausseeInfSens).IsRequired();
            modelBuilder.Entity<InfTrDec>().Property(item => item.ChausseeInfSens).HasMaxLength(6);
            modelBuilder.Entity<InfTrDec>().Property(item => item.ChausseeInfSens).HasColumnName("CHAUSSEE_INF__SENS");
            modelBuilder.Entity<InfTrDec>().Property(item => item.FamDecInfFamDec).IsRequired();
            modelBuilder.Entity<InfTrDec>().Property(item => item.FamDecInfFamDec).HasMaxLength(6);
            modelBuilder.Entity<InfTrDec>().Property(item => item.FamDecInfFamDec).HasColumnName("FAM_DEC_INF__FAM_DEC");
            modelBuilder.Entity<InfTrDec>().Property(item => item.CdDecInfCdDec).IsRequired();
            modelBuilder.Entity<InfTrDec>().Property(item => item.CdDecInfCdDec).HasMaxLength(15);
            modelBuilder.Entity<InfTrDec>().Property(item => item.CdDecInfCdDec).HasColumnName("CD_DEC_INF__CD_DEC");
            modelBuilder.Entity<InfTrDec>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<InfTrDec>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<InfTrDec>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<InfTrDec>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<InfTpc>().ToTable("TPC_INF","INF");
            modelBuilder.Entity<InfTpc>().HasKey(item => new {item.CdTpcInfCode,item.LiaisonInfLiaison,item.ChausseeInfSens,item.AbsDeb });
            modelBuilder.Entity<InfTpc>().Property(item => item.CdTpcInfCode).IsRequired();
            modelBuilder.Entity<InfTpc>().Property(item => item.CdTpcInfCode).HasMaxLength(6);
            modelBuilder.Entity<InfTpc>().Property(item => item.CdTpcInfCode).HasColumnName("CD_TPC_INF__CODE");
            modelBuilder.Entity<InfTpc>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfTpc>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfTpc>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfTpc>().Property(item => item.ChausseeInfSens).IsRequired();
            modelBuilder.Entity<InfTpc>().Property(item => item.ChausseeInfSens).HasMaxLength(6);
            modelBuilder.Entity<InfTpc>().Property(item => item.ChausseeInfSens).HasColumnName("CHAUSSEE_INF__SENS");
            modelBuilder.Entity<InfTpc>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<InfTpc>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<InfTpc>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<InfTpc>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<InfTpc>().Property(item => item.Largeur).HasColumnName("LARGEUR");
            modelBuilder.Entity<InfCdTpc>().ToTable("CD_TPC_INF","INF");
            modelBuilder.Entity<InfCdTpc>().HasKey(item => new {item.Code });
            modelBuilder.Entity<InfCdTpc>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<InfCdTpc>().Property(item => item.Code).HasMaxLength(6);
            modelBuilder.Entity<InfCdTpc>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<InfCdTpc>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<InfCdTpc>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<InfCdTpc>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<InfDictionnaire>().ToTable("DICTIONNAIRE_INF","INF");
            modelBuilder.Entity<InfDictionnaire>().HasKey(item => new {item.Nom });
            modelBuilder.Entity<InfDictionnaire>().Property(item => item.Nom).IsRequired();
            modelBuilder.Entity<InfDictionnaire>().Property(item => item.Nom).HasMaxLength(100);
            modelBuilder.Entity<InfDictionnaire>().Property(item => item.Nom).HasColumnName("NOM");
            modelBuilder.Entity<InfDictionnaire>().Property(item => item.Description).HasMaxLength(255);
            modelBuilder.Entity<InfDictionnaire>().Property(item => item.Description).HasColumnName("DESCRIPTION");
            modelBuilder.Entity<InfDictionnaire>().Property(item => item.Motscles).HasMaxLength(255);
            modelBuilder.Entity<InfDictionnaire>().Property(item => item.Motscles).HasColumnName("MOTSCLES");
            modelBuilder.Entity<InfDictionnaire>().Property(item => item.Definition).HasMaxLength(1000);
            modelBuilder.Entity<InfDictionnaire>().Property(item => item.Definition).HasColumnName("DEFINITION");
            modelBuilder.Entity<InfRepere>().ToTable("REPERE_INF","INF");
            modelBuilder.Entity<InfRepere>().HasKey(item => new {item.LiaisonInfLiaison,item.ChausseeInfSens,item.Num });
            modelBuilder.Entity<InfRepere>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfRepere>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfRepere>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfRepere>().Property(item => item.ChausseeInfSens).IsRequired();
            modelBuilder.Entity<InfRepere>().Property(item => item.ChausseeInfSens).HasMaxLength(6);
            modelBuilder.Entity<InfRepere>().Property(item => item.ChausseeInfSens).HasColumnName("CHAUSSEE_INF__SENS");
            modelBuilder.Entity<InfRepere>().Property(item => item.Num).IsRequired();
            modelBuilder.Entity<InfRepere>().Property(item => item.Num).HasColumnName("NUM");
            modelBuilder.Entity<InfRepere>().Property(item => item.Inter).IsRequired();
            modelBuilder.Entity<InfRepere>().Property(item => item.Inter).HasColumnName("INTER");
            modelBuilder.Entity<InfRepere>().Property(item => item.AbsCum).HasColumnName("ABS_CUM");
            modelBuilder.Entity<InfPrevSge>().ToTable("PREV_SGE_INF","INF");
            modelBuilder.Entity<InfPrevSge>().HasKey(item => new {item.LiaisonInfLiaison,item.ChausseeInfSens,item.Schema,item.DateDeb,item.AbsDeb,item.Nature,item.NumOuvrage });
            modelBuilder.Entity<InfPrevSge>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfPrevSge>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfPrevSge>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfPrevSge>().Property(item => item.ChausseeInfSens).IsRequired();
            modelBuilder.Entity<InfPrevSge>().Property(item => item.ChausseeInfSens).HasMaxLength(6);
            modelBuilder.Entity<InfPrevSge>().Property(item => item.ChausseeInfSens).HasColumnName("CHAUSSEE_INF__SENS");
            modelBuilder.Entity<InfPrevSge>().Property(item => item.Schema).IsRequired();
            modelBuilder.Entity<InfPrevSge>().Property(item => item.Schema).HasMaxLength(5);
            modelBuilder.Entity<InfPrevSge>().Property(item => item.Schema).HasColumnName("SCHEMA");
            modelBuilder.Entity<InfPrevSge>().Property(item => item.DateDeb).IsRequired();
            modelBuilder.Entity<InfPrevSge>().Property(item => item.DateDeb).HasColumnName("DATE_DEB");
            modelBuilder.Entity<InfPrevSge>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<InfPrevSge>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<InfPrevSge>().Property(item => item.Nature).IsRequired();
            modelBuilder.Entity<InfPrevSge>().Property(item => item.Nature).HasMaxLength(125);
            modelBuilder.Entity<InfPrevSge>().Property(item => item.Nature).HasColumnName("NATURE");
            modelBuilder.Entity<InfPrevSge>().Property(item => item.NumOuvrage).IsRequired();
            modelBuilder.Entity<InfPrevSge>().Property(item => item.NumOuvrage).HasMaxLength(20);
            modelBuilder.Entity<InfPrevSge>().Property(item => item.NumOuvrage).HasColumnName("NUM_OUVRAGE");
            modelBuilder.Entity<InfPrevSge>().Property(item => item.DateFin).HasColumnName("DATE_FIN");
            modelBuilder.Entity<InfPrevSge>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<InfPrevSge>().Property(item => item.Ce).HasMaxLength(100);
            modelBuilder.Entity<InfPrevSge>().Property(item => item.Ce).HasColumnName("CE");
            modelBuilder.Entity<InfPrevSge>().Property(item => item.DatePub).HasColumnName("DATE_PUB");
            modelBuilder.Entity<InfPrevSge>().Property(item => item.DateFinpub).HasColumnName("DATE_FINPUB");
            modelBuilder.Entity<InfPrevSge>().Property(item => item.DateDemande).HasColumnName("DATE_DEMANDE");
            modelBuilder.Entity<InfPrevSge>().Property(item => item.NomUsage).HasMaxLength(30);
            modelBuilder.Entity<InfPrevSge>().Property(item => item.NomUsage).HasColumnName("NOM_USAGE");
            modelBuilder.Entity<InfPrevSge>().Property(item => item.Commentaire).HasMaxLength(255);
            modelBuilder.Entity<InfPrevSge>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<InfPk>().ToTable("PK_INF","INF");
            modelBuilder.Entity<InfPk>().HasKey(item => new {item.LiaisonInfLiaison,item.ChausseeInfSens,item.AbsCum });
            modelBuilder.Entity<InfPk>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfPk>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfPk>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfPk>().Property(item => item.ChausseeInfSens).IsRequired();
            modelBuilder.Entity<InfPk>().Property(item => item.ChausseeInfSens).HasMaxLength(6);
            modelBuilder.Entity<InfPk>().Property(item => item.ChausseeInfSens).HasColumnName("CHAUSSEE_INF__SENS");
            modelBuilder.Entity<InfPk>().Property(item => item.AbsCum).IsRequired();
            modelBuilder.Entity<InfPk>().Property(item => item.AbsCum).HasColumnName("ABS_CUM");
            modelBuilder.Entity<InfPk>().Property(item => item.Num).IsRequired();
            modelBuilder.Entity<InfPk>().Property(item => item.Num).HasColumnName("NUM");
            modelBuilder.Entity<InfPk>().Property(item => item.Inter).IsRequired();
            modelBuilder.Entity<InfPk>().Property(item => item.Inter).HasColumnName("INTER");
            modelBuilder.Entity<InfPrOld>().ToTable("PR_OLD_INF","INF");
            modelBuilder.Entity<InfPrOld>().HasKey(item => new {item.LiaisonInfLiaison,item.ChausseeInfSens,item.Num });
            modelBuilder.Entity<InfPrOld>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfPrOld>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfPrOld>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfPrOld>().Property(item => item.ChausseeInfSens).IsRequired();
            modelBuilder.Entity<InfPrOld>().Property(item => item.ChausseeInfSens).HasMaxLength(6);
            modelBuilder.Entity<InfPrOld>().Property(item => item.ChausseeInfSens).HasColumnName("CHAUSSEE_INF__SENS");
            modelBuilder.Entity<InfPrOld>().Property(item => item.Num).IsRequired();
            modelBuilder.Entity<InfPrOld>().Property(item => item.Num).HasColumnName("NUM");
            modelBuilder.Entity<InfPrOld>().Property(item => item.Inter).IsRequired();
            modelBuilder.Entity<InfPrOld>().Property(item => item.Inter).HasColumnName("INTER");
            modelBuilder.Entity<InfPrOld>().Property(item => item.AbsCum).HasColumnName("ABS_CUM");
            modelBuilder.Entity<InfSysUser>().ToTable("SYS_USER_INF","INF");
            modelBuilder.Entity<InfSysUser>().HasKey(item => new {item.CodeDbs,item.CodeTable,item.CodeColonne,item.NomUser,item.CodePrp });
            modelBuilder.Entity<InfSysUser>().Property(item => item.CodeDbs).IsRequired();
            modelBuilder.Entity<InfSysUser>().Property(item => item.CodeDbs).HasMaxLength(50);
            modelBuilder.Entity<InfSysUser>().Property(item => item.CodeDbs).HasColumnName("CODE_DBS");
            modelBuilder.Entity<InfSysUser>().Property(item => item.CodeTable).IsRequired();
            modelBuilder.Entity<InfSysUser>().Property(item => item.CodeTable).HasMaxLength(100);
            modelBuilder.Entity<InfSysUser>().Property(item => item.CodeTable).HasColumnName("CODE_TABLE");
            modelBuilder.Entity<InfSysUser>().Property(item => item.CodeColonne).IsRequired();
            modelBuilder.Entity<InfSysUser>().Property(item => item.CodeColonne).HasMaxLength(100);
            modelBuilder.Entity<InfSysUser>().Property(item => item.CodeColonne).HasColumnName("CODE_COLONNE");
            modelBuilder.Entity<InfSysUser>().Property(item => item.NomUser).IsRequired();
            modelBuilder.Entity<InfSysUser>().Property(item => item.NomUser).HasMaxLength(150);
            modelBuilder.Entity<InfSysUser>().Property(item => item.NomUser).HasColumnName("NOM_USER");
            modelBuilder.Entity<InfSysUser>().Property(item => item.CodePrp).IsRequired();
            modelBuilder.Entity<InfSysUser>().Property(item => item.CodePrp).HasMaxLength(255);
            modelBuilder.Entity<InfSysUser>().Property(item => item.CodePrp).HasColumnName("CODE_PRP");
            modelBuilder.Entity<InfSysUser>().Property(item => item.ValPrp).IsRequired();
            modelBuilder.Entity<InfSysUser>().Property(item => item.ValPrp).HasMaxLength(500);
            modelBuilder.Entity<InfSysUser>().Property(item => item.ValPrp).HasColumnName("VAL_PRP");
            modelBuilder.Entity<InfSensible>().ToTable("SENSIBLE_INF","INF");
            modelBuilder.Entity<InfSensible>().HasKey(item => new {item.CdSensibleInfCode,item.LiaisonInfLiaison,item.ChausseeInfSens,item.AbsDeb });
            modelBuilder.Entity<InfSensible>().Property(item => item.CdSensibleInfCode).IsRequired();
            modelBuilder.Entity<InfSensible>().Property(item => item.CdSensibleInfCode).HasMaxLength(25);
            modelBuilder.Entity<InfSensible>().Property(item => item.CdSensibleInfCode).HasColumnName("CD_SENSIBLE_INF__CODE");
            modelBuilder.Entity<InfSensible>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfSensible>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfSensible>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfSensible>().Property(item => item.ChausseeInfSens).IsRequired();
            modelBuilder.Entity<InfSensible>().Property(item => item.ChausseeInfSens).HasMaxLength(6);
            modelBuilder.Entity<InfSensible>().Property(item => item.ChausseeInfSens).HasColumnName("CHAUSSEE_INF__SENS");
            modelBuilder.Entity<InfSensible>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<InfSensible>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<InfSensible>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<InfSensible>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<InfSensible>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<InfCdSensible>().ToTable("CD_SENSIBLE_INF","INF");
            modelBuilder.Entity<InfCdSensible>().HasKey(item => new {item.Code });
            modelBuilder.Entity<InfCdSensible>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<InfCdSensible>().Property(item => item.Code).HasMaxLength(25);
            modelBuilder.Entity<InfCdSensible>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<InfClim>().ToTable("CLIM_INF","INF");
            modelBuilder.Entity<InfClim>().HasKey(item => new {item.CdClimInfCode,item.LiaisonInfLiaison,item.ChausseeInfSens,item.AbsDeb });
            modelBuilder.Entity<InfClim>().Property(item => item.CdClimInfCode).IsRequired();
            modelBuilder.Entity<InfClim>().Property(item => item.CdClimInfCode).HasMaxLength(25);
            modelBuilder.Entity<InfClim>().Property(item => item.CdClimInfCode).HasColumnName("CD_CLIM_INF__CODE");
            modelBuilder.Entity<InfClim>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfClim>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfClim>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfClim>().Property(item => item.ChausseeInfSens).IsRequired();
            modelBuilder.Entity<InfClim>().Property(item => item.ChausseeInfSens).HasMaxLength(6);
            modelBuilder.Entity<InfClim>().Property(item => item.ChausseeInfSens).HasColumnName("CHAUSSEE_INF__SENS");
            modelBuilder.Entity<InfClim>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<InfClim>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<InfClim>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<InfClim>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<InfClim>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<InfCdClim>().ToTable("CD_CLIM_INF","INF");
            modelBuilder.Entity<InfCdClim>().HasKey(item => new {item.Code });
            modelBuilder.Entity<InfCdClim>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<InfCdClim>().Property(item => item.Code).HasMaxLength(25);
            modelBuilder.Entity<InfCdClim>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<InfAmenagement>().ToTable("AMENAGEMENT_INF","INF");
            modelBuilder.Entity<InfAmenagement>().HasKey(item => new {item.CdAmenagInfTypeAmenag,item.LiaisonInfLiaison,item.ChausseeInfSens,item.DateDeb,item.AbsDeb });
            modelBuilder.Entity<InfAmenagement>().Property(item => item.CdAmenagInfTypeAmenag).IsRequired();
            modelBuilder.Entity<InfAmenagement>().Property(item => item.CdAmenagInfTypeAmenag).HasMaxLength(60);
            modelBuilder.Entity<InfAmenagement>().Property(item => item.CdAmenagInfTypeAmenag).HasColumnName("CD_AMENAG_INF__TYPE_AMENAG");
            modelBuilder.Entity<InfAmenagement>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfAmenagement>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfAmenagement>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfAmenagement>().Property(item => item.ChausseeInfSens).IsRequired();
            modelBuilder.Entity<InfAmenagement>().Property(item => item.ChausseeInfSens).HasMaxLength(6);
            modelBuilder.Entity<InfAmenagement>().Property(item => item.ChausseeInfSens).HasColumnName("CHAUSSEE_INF__SENS");
            modelBuilder.Entity<InfAmenagement>().Property(item => item.DateDeb).IsRequired();
            modelBuilder.Entity<InfAmenagement>().Property(item => item.DateDeb).HasColumnName("DATE_DEB");
            modelBuilder.Entity<InfAmenagement>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<InfAmenagement>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<InfAmenagement>().Property(item => item.DateFin).HasColumnName("DATE_FIN");
            modelBuilder.Entity<InfAmenagement>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<InfAmenagement>().Property(item => item.Cout).HasColumnName("COUT");
            modelBuilder.Entity<InfAmenagement>().Property(item => item.Observ).HasMaxLength(255);
            modelBuilder.Entity<InfAmenagement>().Property(item => item.Observ).HasColumnName("OBSERV");
            modelBuilder.Entity<InfCdAmenag>().ToTable("CD_AMENAG_INF","INF");
            modelBuilder.Entity<InfCdAmenag>().HasKey(item => new {item.TypeAmenag });
            modelBuilder.Entity<InfCdAmenag>().Property(item => item.TypeAmenag).IsRequired();
            modelBuilder.Entity<InfCdAmenag>().Property(item => item.TypeAmenag).HasMaxLength(60);
            modelBuilder.Entity<InfCdAmenag>().Property(item => item.TypeAmenag).HasColumnName("TYPE_AMENAG");
            modelBuilder.Entity<InfAccident>().ToTable("ACCIDENT_INF","INF");
            modelBuilder.Entity<InfAccident>().HasKey(item => new {item.LiaisonInfLiaison,item.ChausseeInfSens,item.Annee,item.AbsDeb,item.Mois });
            modelBuilder.Entity<InfAccident>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfAccident>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfAccident>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfAccident>().Property(item => item.ChausseeInfSens).IsRequired();
            modelBuilder.Entity<InfAccident>().Property(item => item.ChausseeInfSens).HasMaxLength(6);
            modelBuilder.Entity<InfAccident>().Property(item => item.ChausseeInfSens).HasColumnName("CHAUSSEE_INF__SENS");
            modelBuilder.Entity<InfAccident>().Property(item => item.Annee).IsRequired();
            modelBuilder.Entity<InfAccident>().Property(item => item.Annee).HasColumnName("ANNEE");
            modelBuilder.Entity<InfAccident>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<InfAccident>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<InfAccident>().Property(item => item.Mois).IsRequired();
            modelBuilder.Entity<InfAccident>().Property(item => item.Mois).HasColumnName("MOIS");
            modelBuilder.Entity<InfAccident>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<InfAccident>().Property(item => item.NbrAcc).HasColumnName("NBR_ACC");
            modelBuilder.Entity<InfAccident>().Property(item => item.NbrAccMois).HasColumnName("NBR_ACC_MOIS");
            modelBuilder.Entity<InfDscOa>().ToTable("DSC_OA_INF","INF");
            modelBuilder.Entity<InfDscOa>().HasKey(item => new {item.CodeOa });
            modelBuilder.Entity<InfDscOa>().Property(item => item.CodeOa).IsRequired();
            modelBuilder.Entity<InfDscOa>().Property(item => item.CodeOa).HasColumnName("CODE_OA");
            modelBuilder.Entity<InfDscOa>().Property(item => item.NumOa).HasMaxLength(40);
            modelBuilder.Entity<InfDscOa>().Property(item => item.NumOa).HasColumnName("NUM_OA");
            modelBuilder.Entity<InfDscOa>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<InfDscOa>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<InfDscOa>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<InfDscOa>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<InfDscOa>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<InfDscOa>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<InfDscOa>().Property(item => item.PrOa).HasMaxLength(10);
            modelBuilder.Entity<InfDscOa>().Property(item => item.PrOa).HasColumnName("PR_OA");
            modelBuilder.Entity<InfDscOa>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<InfDscOa>().Property(item => item.NumExploit).HasMaxLength(80);
            modelBuilder.Entity<InfDscOa>().Property(item => item.NumExploit).HasColumnName("NUM_EXPLOIT");
            modelBuilder.Entity<InfDscOa>().Property(item => item.NomUsage).HasMaxLength(100);
            modelBuilder.Entity<InfDscOa>().Property(item => item.NomUsage).HasColumnName("NOM_USAGE");
            modelBuilder.Entity<InfDscOa>().Property(item => item.Famille).HasMaxLength(80);
            modelBuilder.Entity<InfDscOa>().Property(item => item.Famille).HasColumnName("FAMILLE");
            modelBuilder.Entity<InfDscOa>().Property(item => item.TypeOuvrage).HasMaxLength(80);
            modelBuilder.Entity<InfDscOa>().Property(item => item.TypeOuvrage).HasColumnName("TYPE_OUVRAGE");
            modelBuilder.Entity<InfDscOa>().Property(item => item.Materiaux).HasMaxLength(80);
            modelBuilder.Entity<InfDscOa>().Property(item => item.Materiaux).HasColumnName("MATERIAUX");
            modelBuilder.Entity<InfDscOa>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<InfDscOa>().Property(item => item.NbreTabliers).HasColumnName("NBRE_TABLIERS");
            modelBuilder.Entity<InfDscOa>().Property(item => item.NbreTravee).HasColumnName("NBRE_TRAVEE");
            modelBuilder.Entity<InfDscOa>().Property(item => item.Gabarit).HasColumnName("GABARIT");
            modelBuilder.Entity<InfDscOa>().Property(item => item.Longueur).HasColumnName("LONGUEUR");
            modelBuilder.Entity<InfDscOa>().Property(item => item.Largeur).HasColumnName("LARGEUR");
            modelBuilder.Entity<InfDscOa>().Property(item => item.SectCourante).HasColumnName("SECT_COURANTE");
            modelBuilder.Entity<InfDscOa>().Property(item => item.Iqoa).HasMaxLength(8);
            modelBuilder.Entity<InfDscOa>().Property(item => item.Iqoa).HasColumnName("IQOA");
            modelBuilder.Entity<InfDscOa>().Property(item => item.NoteUrgence).HasColumnName("NOTE_URGENCE");
            modelBuilder.Entity<InfCorrespondance>().ToTable("CORRESPONDANCE_INF","INF");
            modelBuilder.Entity<InfCorrespondance>().HasKey(item => new {item.LiaisonInfLiaison,item.ChausseeInfSens,item.AxeSae,item.EmplaceSae,item.SensSae });
            modelBuilder.Entity<InfCorrespondance>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfCorrespondance>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfCorrespondance>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfCorrespondance>().Property(item => item.ChausseeInfSens).IsRequired();
            modelBuilder.Entity<InfCorrespondance>().Property(item => item.ChausseeInfSens).HasMaxLength(6);
            modelBuilder.Entity<InfCorrespondance>().Property(item => item.ChausseeInfSens).HasColumnName("CHAUSSEE_INF__SENS");
            modelBuilder.Entity<InfCorrespondance>().Property(item => item.AxeSae).IsRequired();
            modelBuilder.Entity<InfCorrespondance>().Property(item => item.AxeSae).HasMaxLength(60);
            modelBuilder.Entity<InfCorrespondance>().Property(item => item.AxeSae).HasColumnName("AXE_SAE");
            modelBuilder.Entity<InfCorrespondance>().Property(item => item.EmplaceSae).IsRequired();
            modelBuilder.Entity<InfCorrespondance>().Property(item => item.EmplaceSae).HasMaxLength(60);
            modelBuilder.Entity<InfCorrespondance>().Property(item => item.EmplaceSae).HasColumnName("EMPLACE_SAE");
            modelBuilder.Entity<InfCorrespondance>().Property(item => item.SensSae).IsRequired();
            modelBuilder.Entity<InfCorrespondance>().Property(item => item.SensSae).HasMaxLength(60);
            modelBuilder.Entity<InfCorrespondance>().Property(item => item.SensSae).HasColumnName("SENS_SAE");
            modelBuilder.Entity<InfCorrespondance>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<InfCorrespondance>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<InfCorrespondance>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<InfCorrespondance>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<InfCdPosit>().ToTable("CD_POSIT_INF","INF");
            modelBuilder.Entity<InfCdPosit>().HasKey(item => new {item.Posit });
            modelBuilder.Entity<InfCdPosit>().Property(item => item.Posit).IsRequired();
            modelBuilder.Entity<InfCdPosit>().Property(item => item.Posit).HasMaxLength(12);
            modelBuilder.Entity<InfCdPosit>().Property(item => item.Posit).HasColumnName("POSIT");
            modelBuilder.Entity<InfCdPosit>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<InfSecurite>().ToTable("SECURITE_INF","INF");
            modelBuilder.Entity<InfSecurite>().HasKey(item => new {item.LiaisonInfLiaison,item.ChausseeInfSens,item.CdSecurInfType,item.CdPositInfPosit,item.AbsDeb });
            modelBuilder.Entity<InfSecurite>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfSecurite>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfSecurite>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfSecurite>().Property(item => item.ChausseeInfSens).IsRequired();
            modelBuilder.Entity<InfSecurite>().Property(item => item.ChausseeInfSens).HasMaxLength(6);
            modelBuilder.Entity<InfSecurite>().Property(item => item.ChausseeInfSens).HasColumnName("CHAUSSEE_INF__SENS");
            modelBuilder.Entity<InfSecurite>().Property(item => item.CdSecurInfType).IsRequired();
            modelBuilder.Entity<InfSecurite>().Property(item => item.CdSecurInfType).HasMaxLength(25);
            modelBuilder.Entity<InfSecurite>().Property(item => item.CdSecurInfType).HasColumnName("CD_SECUR_INF__TYPE");
            modelBuilder.Entity<InfSecurite>().Property(item => item.CdPositInfPosit).IsRequired();
            modelBuilder.Entity<InfSecurite>().Property(item => item.CdPositInfPosit).HasMaxLength(12);
            modelBuilder.Entity<InfSecurite>().Property(item => item.CdPositInfPosit).HasColumnName("CD_POSIT_INF__POSIT");
            modelBuilder.Entity<InfSecurite>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<InfSecurite>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<InfSecurite>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<InfEclairage>().ToTable("ECLAIRAGE_INF","INF");
            modelBuilder.Entity<InfEclairage>().HasKey(item => new {item.CdEclairInfType,item.CdPositInfPosit,item.LiaisonInfLiaison,item.ChausseeInfSens,item.AbsDeb });
            modelBuilder.Entity<InfEclairage>().Property(item => item.CdEclairInfType).IsRequired();
            modelBuilder.Entity<InfEclairage>().Property(item => item.CdEclairInfType).HasMaxLength(25);
            modelBuilder.Entity<InfEclairage>().Property(item => item.CdEclairInfType).HasColumnName("CD_ECLAIR_INF__TYPE");
            modelBuilder.Entity<InfEclairage>().Property(item => item.CdPositInfPosit).IsRequired();
            modelBuilder.Entity<InfEclairage>().Property(item => item.CdPositInfPosit).HasMaxLength(12);
            modelBuilder.Entity<InfEclairage>().Property(item => item.CdPositInfPosit).HasColumnName("CD_POSIT_INF__POSIT");
            modelBuilder.Entity<InfEclairage>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfEclairage>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfEclairage>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfEclairage>().Property(item => item.ChausseeInfSens).IsRequired();
            modelBuilder.Entity<InfEclairage>().Property(item => item.ChausseeInfSens).HasMaxLength(6);
            modelBuilder.Entity<InfEclairage>().Property(item => item.ChausseeInfSens).HasColumnName("CHAUSSEE_INF__SENS");
            modelBuilder.Entity<InfEclairage>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<InfEclairage>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<InfCdSecur>().ToTable("CD_SECUR_INF","INF");
            modelBuilder.Entity<InfCdSecur>().HasKey(item => new {item.Type });
            modelBuilder.Entity<InfCdSecur>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<InfCdSecur>().Property(item => item.Type).HasMaxLength(25);
            modelBuilder.Entity<InfCdSecur>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<InfCdEclair>().ToTable("CD_ECLAIR_INF","INF");
            modelBuilder.Entity<InfCdEclair>().HasKey(item => new {item.Type });
            modelBuilder.Entity<InfCdEclair>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<InfCdEclair>().Property(item => item.Type).HasMaxLength(25);
            modelBuilder.Entity<InfCdEclair>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<InfOccupation>().ToTable("OCCUPATION_INF","INF");
            modelBuilder.Entity<InfOccupation>().HasKey(item => new {item.CdOccupInfType,item.CdOccupantInfNom,item.LiaisonInfLiaison,item.ChausseeInfSens,item.AbsDeb });
            modelBuilder.Entity<InfOccupation>().Property(item => item.CdOccupInfType).IsRequired();
            modelBuilder.Entity<InfOccupation>().Property(item => item.CdOccupInfType).HasMaxLength(60);
            modelBuilder.Entity<InfOccupation>().Property(item => item.CdOccupInfType).HasColumnName("CD_OCCUP_INF__TYPE");
            modelBuilder.Entity<InfOccupation>().Property(item => item.CdOccupantInfNom).IsRequired();
            modelBuilder.Entity<InfOccupation>().Property(item => item.CdOccupantInfNom).HasMaxLength(60);
            modelBuilder.Entity<InfOccupation>().Property(item => item.CdOccupantInfNom).HasColumnName("CD_OCCUPANT_INF__NOM");
            modelBuilder.Entity<InfOccupation>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfOccupation>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfOccupation>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfOccupation>().Property(item => item.ChausseeInfSens).IsRequired();
            modelBuilder.Entity<InfOccupation>().Property(item => item.ChausseeInfSens).HasMaxLength(6);
            modelBuilder.Entity<InfOccupation>().Property(item => item.ChausseeInfSens).HasColumnName("CHAUSSEE_INF__SENS");
            modelBuilder.Entity<InfOccupation>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<InfOccupation>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<InfOccupation>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<InfOccupation>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<InfOccupation>().Property(item => item.DateFv).HasColumnName("DATE_FV");
            modelBuilder.Entity<InfOccupation>().Property(item => item.Trav).HasColumnName("TRAV");
            modelBuilder.Entity<InfOccupation>().Property(item => item.Obs).HasMaxLength(255);
            modelBuilder.Entity<InfOccupation>().Property(item => item.Obs).HasColumnName("OBS");
            modelBuilder.Entity<InfCdOccup>().ToTable("CD_OCCUP_INF","INF");
            modelBuilder.Entity<InfCdOccup>().HasKey(item => new {item.Type });
            modelBuilder.Entity<InfCdOccup>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<InfCdOccup>().Property(item => item.Type).HasMaxLength(60);
            modelBuilder.Entity<InfCdOccup>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<InfCdOccupant>().ToTable("CD_OCCUPANT_INF","INF");
            modelBuilder.Entity<InfCdOccupant>().HasKey(item => new {item.Nom });
            modelBuilder.Entity<InfCdOccupant>().Property(item => item.Nom).IsRequired();
            modelBuilder.Entity<InfCdOccupant>().Property(item => item.Nom).HasMaxLength(60);
            modelBuilder.Entity<InfCdOccupant>().Property(item => item.Nom).HasColumnName("NOM");
            modelBuilder.Entity<InfTalus>().ToTable("TALUS_INF","INF");
            modelBuilder.Entity<InfTalus>().HasKey(item => new {item.CdTalusInfType,item.LiaisonInfLiaison,item.ChausseeInfSens,item.AbsDeb });
            modelBuilder.Entity<InfTalus>().Property(item => item.CdTalusInfType).IsRequired();
            modelBuilder.Entity<InfTalus>().Property(item => item.CdTalusInfType).HasMaxLength(25);
            modelBuilder.Entity<InfTalus>().Property(item => item.CdTalusInfType).HasColumnName("CD_TALUS_INF__TYPE");
            modelBuilder.Entity<InfTalus>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfTalus>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfTalus>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfTalus>().Property(item => item.ChausseeInfSens).IsRequired();
            modelBuilder.Entity<InfTalus>().Property(item => item.ChausseeInfSens).HasMaxLength(6);
            modelBuilder.Entity<InfTalus>().Property(item => item.ChausseeInfSens).HasColumnName("CHAUSSEE_INF__SENS");
            modelBuilder.Entity<InfTalus>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<InfTalus>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<InfTalus>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<InfTalus>().Property(item => item.Haut).HasColumnName("HAUT");
            modelBuilder.Entity<InfCdTalus>().ToTable("CD_TALUS_INF","INF");
            modelBuilder.Entity<InfCdTalus>().HasKey(item => new {item.Type });
            modelBuilder.Entity<InfCdTalus>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<InfCdTalus>().Property(item => item.Type).HasMaxLength(25);
            modelBuilder.Entity<InfCdTalus>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<InfWgs>().ToTable("WGS_INF","INF");
            modelBuilder.Entity<InfWgs>().HasKey(item => new {item.LayerName,item.Liaison,item.Sens,item.AbsDeb });
            modelBuilder.Entity<InfWgs>().Property(item => item.LineIndex).IsRequired();
            modelBuilder.Entity<InfWgs>().Property(item => item.LineIndex).HasColumnName("LINE_INDEX");
            modelBuilder.Entity<InfWgs>().Property(item => item.LayerName).IsRequired();
            modelBuilder.Entity<InfWgs>().Property(item => item.LayerName).HasMaxLength(100);
            modelBuilder.Entity<InfWgs>().Property(item => item.LayerName).HasColumnName("LAYER_NAME");
            modelBuilder.Entity<InfWgs>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<InfWgs>().Property(item => item.Liaison).HasMaxLength(16);
            modelBuilder.Entity<InfWgs>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<InfWgs>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<InfWgs>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<InfWgs>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<InfWgs>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<InfWgs>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<InfWgs>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<InfWgs>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<InfWgs>().Property(item => item.X1).IsRequired();
            modelBuilder.Entity<InfWgs>().Property(item => item.X1).HasColumnName("X1");
            modelBuilder.Entity<InfWgs>().Property(item => item.Y1).IsRequired();
            modelBuilder.Entity<InfWgs>().Property(item => item.Y1).HasColumnName("Y1");
            modelBuilder.Entity<InfWgs>().Property(item => item.X2).IsRequired();
            modelBuilder.Entity<InfWgs>().Property(item => item.X2).HasColumnName("X2");
            modelBuilder.Entity<InfWgs>().Property(item => item.Y2).IsRequired();
            modelBuilder.Entity<InfWgs>().Property(item => item.Y2).HasColumnName("Y2");
            modelBuilder.Entity<InfCdVoie>().ToTable("CD_VOIE_INF","INF");
            modelBuilder.Entity<InfCdVoie>().HasKey(item => new {item.Voie });
            modelBuilder.Entity<InfCdVoie>().Property(item => item.Voie).IsRequired();
            modelBuilder.Entity<InfCdVoie>().Property(item => item.Voie).HasMaxLength(6);
            modelBuilder.Entity<InfCdVoie>().Property(item => item.Voie).HasColumnName("VOIE");
            modelBuilder.Entity<InfCdVoie>().Property(item => item.Posit).IsRequired();
            modelBuilder.Entity<InfCdVoie>().Property(item => item.Posit).HasColumnName("POSIT");
            modelBuilder.Entity<InfCdVoie>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<InfCdVoie>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<InfCdVoie>().Property(item => item.Roulable).HasColumnName("ROULABLE");
            modelBuilder.Entity<InfPaveVoie>().ToTable("PAVE_VOIE_INF","INF");
            modelBuilder.Entity<InfPaveVoie>().HasKey(item => new {item.CdVoieInfVoie,item.LiaisonInfLiaison,item.ChausseeInfSens,item.AbsDeb });
            modelBuilder.Entity<InfPaveVoie>().Property(item => item.CdVoieInfVoie).IsRequired();
            modelBuilder.Entity<InfPaveVoie>().Property(item => item.CdVoieInfVoie).HasMaxLength(6);
            modelBuilder.Entity<InfPaveVoie>().Property(item => item.CdVoieInfVoie).HasColumnName("CD_VOIE_INF__VOIE");
            modelBuilder.Entity<InfPaveVoie>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfPaveVoie>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfPaveVoie>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfPaveVoie>().Property(item => item.ChausseeInfSens).IsRequired();
            modelBuilder.Entity<InfPaveVoie>().Property(item => item.ChausseeInfSens).HasMaxLength(6);
            modelBuilder.Entity<InfPaveVoie>().Property(item => item.ChausseeInfSens).HasColumnName("CHAUSSEE_INF__SENS");
            modelBuilder.Entity<InfPaveVoie>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<InfPaveVoie>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<InfPaveVoie>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<InfPaveVoie>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<InfPaveVoie>().Property(item => item.Largeur).IsRequired();
            modelBuilder.Entity<InfPaveVoie>().Property(item => item.Largeur).HasColumnName("LARGEUR");
            modelBuilder.Entity<InfPaveVoie>().Property(item => item.DateMs).IsRequired();
            modelBuilder.Entity<InfPaveVoie>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<InfClVoie>().ToTable("CL_VOIE_INF","INF");
            modelBuilder.Entity<InfClVoie>().HasKey(item => new {item.CdVoieInfVoie,item.LiaisonInfLiaison,item.ChausseeInfSens,item.AbsDeb,item.NumVnr });
            modelBuilder.Entity<InfClVoie>().Property(item => item.CdVoieInfVoie).IsRequired();
            modelBuilder.Entity<InfClVoie>().Property(item => item.CdVoieInfVoie).HasMaxLength(6);
            modelBuilder.Entity<InfClVoie>().Property(item => item.CdVoieInfVoie).HasColumnName("CD_VOIE_INF__VOIE");
            modelBuilder.Entity<InfClVoie>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfClVoie>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfClVoie>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfClVoie>().Property(item => item.ChausseeInfSens).IsRequired();
            modelBuilder.Entity<InfClVoie>().Property(item => item.ChausseeInfSens).HasMaxLength(6);
            modelBuilder.Entity<InfClVoie>().Property(item => item.ChausseeInfSens).HasColumnName("CHAUSSEE_INF__SENS");
            modelBuilder.Entity<InfClVoie>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<InfClVoie>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<InfClVoie>().Property(item => item.NumVnr).IsRequired();
            modelBuilder.Entity<InfClVoie>().Property(item => item.NumVnr).HasColumnName("NUM_VNR");
            modelBuilder.Entity<InfClVoie>().Property(item => item.AbsFin).IsRequired();
            modelBuilder.Entity<InfClVoie>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<InfClVoie>().Property(item => item.Num).HasColumnName("NUM");
            modelBuilder.Entity<InfClVoie>().Property(item => item.Nbre).HasColumnName("NBRE");
            modelBuilder.Entity<InfClVoie>().Property(item => item.NbreVnr).IsRequired();
            modelBuilder.Entity<InfClVoie>().Property(item => item.NbreVnr).HasColumnName("NBRE_VNR");
            modelBuilder.Entity<InfTrafic>().ToTable("TRAFIC_INF","INF");
            modelBuilder.Entity<InfTrafic>().HasKey(item => new {item.LiaisonInfLiaison,item.ChausseeInfSens,item.Annee });
            modelBuilder.Entity<InfTrafic>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfTrafic>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfTrafic>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfTrafic>().Property(item => item.ChausseeInfSens).IsRequired();
            modelBuilder.Entity<InfTrafic>().Property(item => item.ChausseeInfSens).HasMaxLength(6);
            modelBuilder.Entity<InfTrafic>().Property(item => item.ChausseeInfSens).HasColumnName("CHAUSSEE_INF__SENS");
            modelBuilder.Entity<InfTrafic>().Property(item => item.Annee).IsRequired();
            modelBuilder.Entity<InfTrafic>().Property(item => item.Annee).HasColumnName("ANNEE");
            modelBuilder.Entity<InfTrafic>().Property(item => item.Pl).HasColumnName("PL");
            modelBuilder.Entity<InfTrafic>().Property(item => item.Tmja).HasColumnName("TMJA");
            modelBuilder.Entity<InfSectionTrafic>().ToTable("SECTION_TRAFIC_INF","INF");
            modelBuilder.Entity<InfSectionTrafic>().HasKey(item => new {item.LiaisonInfLiaison,item.ChausseeInfSens,item.AbsDeb });
            modelBuilder.Entity<InfSectionTrafic>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfSectionTrafic>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfSectionTrafic>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfSectionTrafic>().Property(item => item.ChausseeInfSens).IsRequired();
            modelBuilder.Entity<InfSectionTrafic>().Property(item => item.ChausseeInfSens).HasMaxLength(6);
            modelBuilder.Entity<InfSectionTrafic>().Property(item => item.ChausseeInfSens).HasColumnName("CHAUSSEE_INF__SENS");
            modelBuilder.Entity<InfSectionTrafic>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<InfSectionTrafic>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<InfSectionTrafic>().Property(item => item.CdClassTrafInfCode).IsRequired();
            modelBuilder.Entity<InfSectionTrafic>().Property(item => item.CdClassTrafInfCode).HasMaxLength(6);
            modelBuilder.Entity<InfSectionTrafic>().Property(item => item.CdClassTrafInfCode).HasColumnName("CD_CLASS_TRAF_INF__CODE");
            modelBuilder.Entity<InfSectionTrafic>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<InfSectionTrafic>().Property(item => item.Tenant).HasMaxLength(60);
            modelBuilder.Entity<InfSectionTrafic>().Property(item => item.Tenant).HasColumnName("TENANT");
            modelBuilder.Entity<InfSectionTrafic>().Property(item => item.Aboutis).HasMaxLength(60);
            modelBuilder.Entity<InfSectionTrafic>().Property(item => item.Aboutis).HasColumnName("ABOUTIS");
            modelBuilder.Entity<InfCdClassTraf>().ToTable("CD_CLASS_TRAF_INF","INF");
            modelBuilder.Entity<InfCdClassTraf>().HasKey(item => new {item.Code });
            modelBuilder.Entity<InfCdClassTraf>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<InfCdClassTraf>().Property(item => item.Code).HasMaxLength(6);
            modelBuilder.Entity<InfCdClassTraf>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<InfRepartitionTrafic>().ToTable("REPARTITION_TRAFIC_INF","INF");
            modelBuilder.Entity<InfRepartitionTrafic>().HasKey(item => new {item.LiaisonInfLiaison,item.ChausseeInfSens,item.AbsDeb,item.Annee });
            modelBuilder.Entity<InfRepartitionTrafic>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfRepartitionTrafic>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfRepartitionTrafic>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfRepartitionTrafic>().Property(item => item.ChausseeInfSens).IsRequired();
            modelBuilder.Entity<InfRepartitionTrafic>().Property(item => item.ChausseeInfSens).HasMaxLength(6);
            modelBuilder.Entity<InfRepartitionTrafic>().Property(item => item.ChausseeInfSens).HasColumnName("CHAUSSEE_INF__SENS");
            modelBuilder.Entity<InfRepartitionTrafic>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<InfRepartitionTrafic>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<InfRepartitionTrafic>().Property(item => item.Annee).IsRequired();
            modelBuilder.Entity<InfRepartitionTrafic>().Property(item => item.Annee).HasColumnName("ANNEE");
            modelBuilder.Entity<InfRepartitionTrafic>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<InfRepartitionTrafic>().Property(item => item.PPl).HasColumnName("P_PL");
            modelBuilder.Entity<InfGare>().ToTable("GARE_INF","INF");
            modelBuilder.Entity<InfGare>().HasKey(item => new {item.CdGareInfType,item.LiaisonInfLiaison,item.ChausseeInfSens,item.AbsDeb });
            modelBuilder.Entity<InfGare>().Property(item => item.CdGareInfType).IsRequired();
            modelBuilder.Entity<InfGare>().Property(item => item.CdGareInfType).HasMaxLength(60);
            modelBuilder.Entity<InfGare>().Property(item => item.CdGareInfType).HasColumnName("CD_GARE_INF__TYPE");
            modelBuilder.Entity<InfGare>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfGare>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfGare>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfGare>().Property(item => item.ChausseeInfSens).IsRequired();
            modelBuilder.Entity<InfGare>().Property(item => item.ChausseeInfSens).HasMaxLength(6);
            modelBuilder.Entity<InfGare>().Property(item => item.ChausseeInfSens).HasColumnName("CHAUSSEE_INF__SENS");
            modelBuilder.Entity<InfGare>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<InfGare>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<InfGare>().Property(item => item.NumExploit).HasMaxLength(15);
            modelBuilder.Entity<InfGare>().Property(item => item.NumExploit).HasColumnName("NUM_EXPLOIT");
            modelBuilder.Entity<InfGare>().Property(item => item.Nom).HasMaxLength(60);
            modelBuilder.Entity<InfGare>().Property(item => item.Nom).HasColumnName("NOM");
            modelBuilder.Entity<InfGare>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<InfGare>().Property(item => item.VoiEntree).HasColumnName("VOI_ENTREE");
            modelBuilder.Entity<InfGare>().Property(item => item.VoiSortie).HasColumnName("VOI_SORTIE");
            modelBuilder.Entity<InfGare>().Property(item => item.VoiMixte).HasColumnName("VOI_MIXTE");
            modelBuilder.Entity<InfGare>().Property(item => item.VoiTsa).HasColumnName("VOI_TSA");
            modelBuilder.Entity<InfGare>().Property(item => item.Observ).HasMaxLength(250);
            modelBuilder.Entity<InfGare>().Property(item => item.Observ).HasColumnName("OBSERV");
            modelBuilder.Entity<InfGare>().Property(item => item.X1).HasColumnName("X1");
            modelBuilder.Entity<InfGare>().Property(item => item.Y1).HasColumnName("Y1");
            modelBuilder.Entity<InfGare>().Property(item => item.Z1).HasColumnName("Z1");
            modelBuilder.Entity<InfGare>().Property(item => item.DateReleve).HasColumnName("DATE_RELEVE");
            modelBuilder.Entity<InfGare>().Property(item => item.Terrain).HasColumnName("TERRAIN");
            modelBuilder.Entity<InfCdGare>().ToTable("CD_GARE_INF","INF");
            modelBuilder.Entity<InfCdGare>().HasKey(item => new {item.Type });
            modelBuilder.Entity<InfCdGare>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<InfCdGare>().Property(item => item.Type).HasMaxLength(60);
            modelBuilder.Entity<InfCdGare>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<InfAire>().ToTable("AIRE_INF","INF");
            modelBuilder.Entity<InfAire>().HasKey(item => new {item.CdAireInfType,item.LiaisonInfLiaison,item.ChausseeInfSens,item.AbsDeb });
            modelBuilder.Entity<InfAire>().Property(item => item.CdAireInfType).IsRequired();
            modelBuilder.Entity<InfAire>().Property(item => item.CdAireInfType).HasMaxLength(60);
            modelBuilder.Entity<InfAire>().Property(item => item.CdAireInfType).HasColumnName("CD_AIRE_INF__TYPE");
            modelBuilder.Entity<InfAire>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfAire>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfAire>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfAire>().Property(item => item.ChausseeInfSens).IsRequired();
            modelBuilder.Entity<InfAire>().Property(item => item.ChausseeInfSens).HasMaxLength(6);
            modelBuilder.Entity<InfAire>().Property(item => item.ChausseeInfSens).HasColumnName("CHAUSSEE_INF__SENS");
            modelBuilder.Entity<InfAire>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<InfAire>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<InfAire>().Property(item => item.NumExploit).HasMaxLength(15);
            modelBuilder.Entity<InfAire>().Property(item => item.NumExploit).HasColumnName("NUM_EXPLOIT");
            modelBuilder.Entity<InfAire>().Property(item => item.Nom).HasMaxLength(60);
            modelBuilder.Entity<InfAire>().Property(item => item.Nom).HasColumnName("NOM");
            modelBuilder.Entity<InfAire>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<InfAire>().Property(item => item.Passerelle).HasColumnName("PASSERELLE");
            modelBuilder.Entity<InfAire>().Property(item => item.DemiTour).HasColumnName("DEMI_TOUR");
            modelBuilder.Entity<InfAire>().Property(item => item.Bilaterale).HasColumnName("BILATERALE");
            modelBuilder.Entity<InfAire>().Property(item => item.Observ).HasMaxLength(250);
            modelBuilder.Entity<InfAire>().Property(item => item.Observ).HasColumnName("OBSERV");
            modelBuilder.Entity<InfAire>().Property(item => item.X1).HasColumnName("X1");
            modelBuilder.Entity<InfAire>().Property(item => item.Y1).HasColumnName("Y1");
            modelBuilder.Entity<InfAire>().Property(item => item.Z1).HasColumnName("Z1");
            modelBuilder.Entity<InfAire>().Property(item => item.DateReleve).HasColumnName("DATE_RELEVE");
            modelBuilder.Entity<InfAire>().Property(item => item.Terrain).HasColumnName("TERRAIN");
            modelBuilder.Entity<InfCdAire>().ToTable("CD_AIRE_INF","INF");
            modelBuilder.Entity<InfCdAire>().HasKey(item => new {item.Type });
            modelBuilder.Entity<InfCdAire>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<InfCdAire>().Property(item => item.Type).HasMaxLength(60);
            modelBuilder.Entity<InfCdAire>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<InfCdPrestataire>().ToTable("CD_PRESTATAIRE_INF","INF");
            modelBuilder.Entity<InfCdPrestataire>().HasKey(item => new {item.Type });
            modelBuilder.Entity<InfCdPrestataire>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<InfCdPrestataire>().Property(item => item.Type).HasMaxLength(60);
            modelBuilder.Entity<InfCdPrestataire>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<InfPrestataire>().ToTable("PRESTATAIRE_INF","INF");
            modelBuilder.Entity<InfPrestataire>().HasKey(item => new {item.CdPrestataireInfType,item.Nom });
            modelBuilder.Entity<InfPrestataire>().Property(item => item.CdPrestataireInfType).IsRequired();
            modelBuilder.Entity<InfPrestataire>().Property(item => item.CdPrestataireInfType).HasMaxLength(60);
            modelBuilder.Entity<InfPrestataire>().Property(item => item.CdPrestataireInfType).HasColumnName("CD_PRESTATAIRE_INF__TYPE");
            modelBuilder.Entity<InfPrestataire>().Property(item => item.Nom).IsRequired();
            modelBuilder.Entity<InfPrestataire>().Property(item => item.Nom).HasMaxLength(60);
            modelBuilder.Entity<InfPrestataire>().Property(item => item.Nom).HasColumnName("NOM");
            modelBuilder.Entity<InfCdService>().ToTable("CD_SERVICE_INF","INF");
            modelBuilder.Entity<InfCdService>().HasKey(item => new {item.Service });
            modelBuilder.Entity<InfCdService>().Property(item => item.Service).IsRequired();
            modelBuilder.Entity<InfCdService>().Property(item => item.Service).HasMaxLength(60);
            modelBuilder.Entity<InfCdService>().Property(item => item.Service).HasColumnName("SERVICE");
            modelBuilder.Entity<InfCdBif>().ToTable("CD_BIF_INF","INF");
            modelBuilder.Entity<InfCdBif>().HasKey(item => new {item.Type });
            modelBuilder.Entity<InfCdBif>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<InfCdBif>().Property(item => item.Type).HasMaxLength(60);
            modelBuilder.Entity<InfCdBif>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<InfBifurcation>().ToTable("BIFURCATION_INF","INF");
            modelBuilder.Entity<InfBifurcation>().HasKey(item => new {item.CdBifInfType,item.LiaisonInfLiaison,item.ChausseeInfSens,item.AbsDeb });
            modelBuilder.Entity<InfBifurcation>().Property(item => item.CdBifInfType).IsRequired();
            modelBuilder.Entity<InfBifurcation>().Property(item => item.CdBifInfType).HasMaxLength(60);
            modelBuilder.Entity<InfBifurcation>().Property(item => item.CdBifInfType).HasColumnName("CD_BIF_INF__TYPE");
            modelBuilder.Entity<InfBifurcation>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfBifurcation>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfBifurcation>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfBifurcation>().Property(item => item.ChausseeInfSens).IsRequired();
            modelBuilder.Entity<InfBifurcation>().Property(item => item.ChausseeInfSens).HasMaxLength(6);
            modelBuilder.Entity<InfBifurcation>().Property(item => item.ChausseeInfSens).HasColumnName("CHAUSSEE_INF__SENS");
            modelBuilder.Entity<InfBifurcation>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<InfBifurcation>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<InfBifurcation>().Property(item => item.Nom).HasMaxLength(60);
            modelBuilder.Entity<InfBifurcation>().Property(item => item.Nom).HasColumnName("NOM");
            modelBuilder.Entity<InfBifurcation>().Property(item => item.NumExploit).HasMaxLength(15);
            modelBuilder.Entity<InfBifurcation>().Property(item => item.NumExploit).HasColumnName("NUM_EXPLOIT");
            modelBuilder.Entity<InfBifurcation>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<InfBifurcation>().Property(item => item.Observ).HasMaxLength(250);
            modelBuilder.Entity<InfBifurcation>().Property(item => item.Observ).HasColumnName("OBSERV");
            modelBuilder.Entity<InfBifurcation>().Property(item => item.X1).HasColumnName("X1");
            modelBuilder.Entity<InfBifurcation>().Property(item => item.Y1).HasColumnName("Y1");
            modelBuilder.Entity<InfBifurcation>().Property(item => item.Z1).HasColumnName("Z1");
            modelBuilder.Entity<InfBifurcation>().Property(item => item.DateReleve).HasColumnName("DATE_RELEVE");
            modelBuilder.Entity<InfBifurcation>().Property(item => item.Terrain).HasColumnName("TERRAIN");
            modelBuilder.Entity<InfBretelle>().ToTable("BRETELLE_INF","INF");
            modelBuilder.Entity<InfBretelle>().HasKey(item => new {item.LiaisonInfLiaison,item.ChausseeInfSens,item.AbsDeb });
            modelBuilder.Entity<InfBretelle>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfBretelle>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfBretelle>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfBretelle>().Property(item => item.ChausseeInfSens).IsRequired();
            modelBuilder.Entity<InfBretelle>().Property(item => item.ChausseeInfSens).HasMaxLength(6);
            modelBuilder.Entity<InfBretelle>().Property(item => item.ChausseeInfSens).HasColumnName("CHAUSSEE_INF__SENS");
            modelBuilder.Entity<InfBretelle>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<InfBretelle>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<InfBretelle>().Property(item => item.NumExploit).HasMaxLength(15);
            modelBuilder.Entity<InfBretelle>().Property(item => item.NumExploit).HasColumnName("NUM_EXPLOIT");
            modelBuilder.Entity<InfBretelle>().Property(item => item.NumBretelle).HasMaxLength(15);
            modelBuilder.Entity<InfBretelle>().Property(item => item.NumBretelle).HasColumnName("NUM_BRETELLE");
            modelBuilder.Entity<InfBretelle>().Property(item => item.NomBretelle).HasMaxLength(15);
            modelBuilder.Entity<InfBretelle>().Property(item => item.NomBretelle).HasColumnName("NOM_BRETELLE");
            modelBuilder.Entity<InfBretelle>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<InfBretelle>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<InfBretelle>().Property(item => item.Type).HasMaxLength(60);
            modelBuilder.Entity<InfBretelle>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<InfBretelle>().Property(item => item.Extremite).HasMaxLength(60);
            modelBuilder.Entity<InfBretelle>().Property(item => item.Extremite).HasColumnName("EXTREMITE");
            modelBuilder.Entity<InfCdPlace>().ToTable("CD_PLACE_INF","INF");
            modelBuilder.Entity<InfCdPlace>().HasKey(item => new {item.Parking });
            modelBuilder.Entity<InfCdPlace>().Property(item => item.Parking).IsRequired();
            modelBuilder.Entity<InfCdPlace>().Property(item => item.Parking).HasMaxLength(60);
            modelBuilder.Entity<InfCdPlace>().Property(item => item.Parking).HasColumnName("PARKING");
            modelBuilder.Entity<InfCdEvt>().ToTable("CD_EVT_INF","INF");
            modelBuilder.Entity<InfCdEvt>().HasKey(item => new {item.Type });
            modelBuilder.Entity<InfCdEvt>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<InfCdEvt>().Property(item => item.Type).HasMaxLength(25);
            modelBuilder.Entity<InfCdEvt>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<InfCdEvt>().Property(item => item.Impact).HasColumnName("IMPACT");
            modelBuilder.Entity<InfEvt>().ToTable("EVT_INF","INF");
            modelBuilder.Entity<InfEvt>().HasKey(item => new {item.CdEvtInfType,item.IdEvt });
            modelBuilder.Entity<InfEvt>().Property(item => item.CdEvtInfType).IsRequired();
            modelBuilder.Entity<InfEvt>().Property(item => item.CdEvtInfType).HasMaxLength(25);
            modelBuilder.Entity<InfEvt>().Property(item => item.CdEvtInfType).HasColumnName("CD_EVT_INF__TYPE");
            modelBuilder.Entity<InfEvt>().Property(item => item.IdEvt).IsRequired();
            modelBuilder.Entity<InfEvt>().Property(item => item.IdEvt).HasColumnName("ID_EVT");
            modelBuilder.Entity<InfEvt>().Property(item => item.CdPositInfPosit).HasMaxLength(12);
            modelBuilder.Entity<InfEvt>().Property(item => item.CdPositInfPosit).HasColumnName("CD_POSIT_INF__POSIT");
            modelBuilder.Entity<InfEvt>().Property(item => item.NomTable).IsRequired();
            modelBuilder.Entity<InfEvt>().Property(item => item.NomTable).HasMaxLength(60);
            modelBuilder.Entity<InfEvt>().Property(item => item.NomTable).HasColumnName("NOM_TABLE");
            modelBuilder.Entity<InfEvt>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<InfEvt>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<InfEvt>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<InfEvt>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<InfEvt>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<InfEvt>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<InfEvt>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<InfEvt>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<InfEvt>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<InfEvt>().Property(item => item.DateRel).IsRequired();
            modelBuilder.Entity<InfEvt>().Property(item => item.DateRel).HasColumnName("DATE_REL");
            modelBuilder.Entity<InfEvt>().Property(item => item.Obsv).HasMaxLength(255);
            modelBuilder.Entity<InfEvt>().Property(item => item.Obsv).HasColumnName("OBSV");
            modelBuilder.Entity<InfEvt>().Property(item => item.DateTrt).HasColumnName("DATE_TRT");
            modelBuilder.Entity<InfContact>().ToTable("CONTACT_INF","INF");
            modelBuilder.Entity<InfContact>().HasKey(item => new {item.DocInfId });
            modelBuilder.Entity<InfContact>().Property(item => item.DocInfId).IsRequired();
            modelBuilder.Entity<InfContact>().Property(item => item.DocInfId).HasColumnName("DOC_INF__ID");
            modelBuilder.Entity<InfContact>().Property(item => item.Givenname).HasMaxLength(60);
            modelBuilder.Entity<InfContact>().Property(item => item.Givenname).HasColumnName("givenName");
            modelBuilder.Entity<InfContact>().Property(item => item.Sn).HasMaxLength(60);
            modelBuilder.Entity<InfContact>().Property(item => item.Sn).HasColumnName("sn");
            modelBuilder.Entity<InfContact>().Property(item => item.Cn).HasMaxLength(125);
            modelBuilder.Entity<InfContact>().Property(item => item.Cn).HasColumnName("cn");
            modelBuilder.Entity<InfContact>().Property(item => item.O).HasMaxLength(60);
            modelBuilder.Entity<InfContact>().Property(item => item.O).HasColumnName("o");
            modelBuilder.Entity<InfContact>().Property(item => item.Mail).HasMaxLength(60);
            modelBuilder.Entity<InfContact>().Property(item => item.Mail).HasColumnName("mail");
            modelBuilder.Entity<InfContact>().Property(item => item.Telephonenumber).HasMaxLength(20);
            modelBuilder.Entity<InfContact>().Property(item => item.Telephonenumber).HasColumnName("telephoneNumber");
            modelBuilder.Entity<InfContact>().Property(item => item.Mobile).HasMaxLength(20);
            modelBuilder.Entity<InfContact>().Property(item => item.Mobile).HasColumnName("mobile");
            modelBuilder.Entity<InfContact>().Property(item => item.Facsimiletelephonenumber).HasMaxLength(20);
            modelBuilder.Entity<InfContact>().Property(item => item.Facsimiletelephonenumber).HasColumnName("facsimiletelephonenumber");
            modelBuilder.Entity<InfContact>().Property(item => item.Street).HasMaxLength(60);
            modelBuilder.Entity<InfContact>().Property(item => item.Street).HasColumnName("street");
            modelBuilder.Entity<InfContact>().Property(item => item.Mozillaworkstreet2).HasMaxLength(60);
            modelBuilder.Entity<InfContact>().Property(item => item.Mozillaworkstreet2).HasColumnName("mozillaWorkStreet2");
            modelBuilder.Entity<InfContact>().Property(item => item.L).HasMaxLength(60);
            modelBuilder.Entity<InfContact>().Property(item => item.L).HasColumnName("l");
            modelBuilder.Entity<InfContact>().Property(item => item.Postalcode).HasMaxLength(12);
            modelBuilder.Entity<InfContact>().Property(item => item.Postalcode).HasColumnName("postalCode");
            modelBuilder.Entity<InfContact>().Property(item => item.Modifytimestamp).HasColumnName("modifytimestamp");
            modelBuilder.Entity<InfClsDoc>().ToTable("CLS_DOC_INF","INF");
            modelBuilder.Entity<InfClsDoc>().HasKey(item => new {item.DocInfId,item.ClsInfId });
            modelBuilder.Entity<InfClsDoc>().Property(item => item.DocInfId).IsRequired();
            modelBuilder.Entity<InfClsDoc>().Property(item => item.DocInfId).HasColumnName("DOC_INF__ID");
            modelBuilder.Entity<InfClsDoc>().Property(item => item.ClsInfId).IsRequired();
            modelBuilder.Entity<InfClsDoc>().Property(item => item.ClsInfId).HasColumnName("CLS_INF__ID");
            modelBuilder.Entity<InfClsDoc>().Property(item => item.Defaut).HasColumnName("DEFAUT");
            modelBuilder.Entity<InfClsDoc>().Property(item => item.Dossier).HasMaxLength(15);
            modelBuilder.Entity<InfClsDoc>().Property(item => item.Dossier).HasColumnName("DOSSIER");
            modelBuilder.Entity<InfAirePrestataire>().ToTable("AIRE__PRESTATAIRE_INF","INF");
            modelBuilder.Entity<InfAirePrestataire>().HasKey(item => new {item.LiaisonInfLiaison,item.CdAireInfType,item.ChausseeInfSens,item.AireInfAbsDeb,item.CdPrestataireInfType,item.PrestataireInfNom });
            modelBuilder.Entity<InfAirePrestataire>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfAirePrestataire>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfAirePrestataire>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfAirePrestataire>().Property(item => item.CdAireInfType).IsRequired();
            modelBuilder.Entity<InfAirePrestataire>().Property(item => item.CdAireInfType).HasMaxLength(60);
            modelBuilder.Entity<InfAirePrestataire>().Property(item => item.CdAireInfType).HasColumnName("CD_AIRE_INF__TYPE");
            modelBuilder.Entity<InfAirePrestataire>().Property(item => item.ChausseeInfSens).IsRequired();
            modelBuilder.Entity<InfAirePrestataire>().Property(item => item.ChausseeInfSens).HasMaxLength(6);
            modelBuilder.Entity<InfAirePrestataire>().Property(item => item.ChausseeInfSens).HasColumnName("CHAUSSEE_INF__SENS");
            modelBuilder.Entity<InfAirePrestataire>().Property(item => item.AireInfAbsDeb).IsRequired();
            modelBuilder.Entity<InfAirePrestataire>().Property(item => item.AireInfAbsDeb).HasColumnName("AIRE_INF__ABS_DEB");
            modelBuilder.Entity<InfAirePrestataire>().Property(item => item.CdPrestataireInfType).IsRequired();
            modelBuilder.Entity<InfAirePrestataire>().Property(item => item.CdPrestataireInfType).HasMaxLength(60);
            modelBuilder.Entity<InfAirePrestataire>().Property(item => item.CdPrestataireInfType).HasColumnName("CD_PRESTATAIRE_INF__TYPE");
            modelBuilder.Entity<InfAirePrestataire>().Property(item => item.PrestataireInfNom).IsRequired();
            modelBuilder.Entity<InfAirePrestataire>().Property(item => item.PrestataireInfNom).HasMaxLength(60);
            modelBuilder.Entity<InfAirePrestataire>().Property(item => item.PrestataireInfNom).HasColumnName("PRESTATAIRE_INF__NOM");
            modelBuilder.Entity<InfAireService>().ToTable("AIRE__SERVICE_INF","INF");
            modelBuilder.Entity<InfAireService>().HasKey(item => new {item.CdServiceInfService,item.LiaisonInfLiaison,item.CdAireInfType,item.ChausseeInfSens,item.AireInfAbsDeb });
            modelBuilder.Entity<InfAireService>().Property(item => item.CdServiceInfService).IsRequired();
            modelBuilder.Entity<InfAireService>().Property(item => item.CdServiceInfService).HasMaxLength(60);
            modelBuilder.Entity<InfAireService>().Property(item => item.CdServiceInfService).HasColumnName("CD_SERVICE_INF__SERVICE");
            modelBuilder.Entity<InfAireService>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfAireService>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfAireService>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfAireService>().Property(item => item.CdAireInfType).IsRequired();
            modelBuilder.Entity<InfAireService>().Property(item => item.CdAireInfType).HasMaxLength(60);
            modelBuilder.Entity<InfAireService>().Property(item => item.CdAireInfType).HasColumnName("CD_AIRE_INF__TYPE");
            modelBuilder.Entity<InfAireService>().Property(item => item.ChausseeInfSens).IsRequired();
            modelBuilder.Entity<InfAireService>().Property(item => item.ChausseeInfSens).HasMaxLength(6);
            modelBuilder.Entity<InfAireService>().Property(item => item.ChausseeInfSens).HasColumnName("CHAUSSEE_INF__SENS");
            modelBuilder.Entity<InfAireService>().Property(item => item.AireInfAbsDeb).IsRequired();
            modelBuilder.Entity<InfAireService>().Property(item => item.AireInfAbsDeb).HasColumnName("AIRE_INF__ABS_DEB");
            modelBuilder.Entity<InfAirePlace>().ToTable("AIRE__PLACE_INF","INF");
            modelBuilder.Entity<InfAirePlace>().HasKey(item => new {item.CdPlaceInfParking,item.LiaisonInfLiaison,item.CdAireInfType,item.ChausseeInfSens,item.AireInfAbsDeb });
            modelBuilder.Entity<InfAirePlace>().Property(item => item.CdPlaceInfParking).IsRequired();
            modelBuilder.Entity<InfAirePlace>().Property(item => item.CdPlaceInfParking).HasMaxLength(60);
            modelBuilder.Entity<InfAirePlace>().Property(item => item.CdPlaceInfParking).HasColumnName("CD_PLACE_INF__PARKING");
            modelBuilder.Entity<InfAirePlace>().Property(item => item.LiaisonInfLiaison).IsRequired();
            modelBuilder.Entity<InfAirePlace>().Property(item => item.LiaisonInfLiaison).HasMaxLength(15);
            modelBuilder.Entity<InfAirePlace>().Property(item => item.LiaisonInfLiaison).HasColumnName("LIAISON_INF__LIAISON");
            modelBuilder.Entity<InfAirePlace>().Property(item => item.CdAireInfType).IsRequired();
            modelBuilder.Entity<InfAirePlace>().Property(item => item.CdAireInfType).HasMaxLength(60);
            modelBuilder.Entity<InfAirePlace>().Property(item => item.CdAireInfType).HasColumnName("CD_AIRE_INF__TYPE");
            modelBuilder.Entity<InfAirePlace>().Property(item => item.ChausseeInfSens).IsRequired();
            modelBuilder.Entity<InfAirePlace>().Property(item => item.ChausseeInfSens).HasMaxLength(6);
            modelBuilder.Entity<InfAirePlace>().Property(item => item.ChausseeInfSens).HasColumnName("CHAUSSEE_INF__SENS");
            modelBuilder.Entity<InfAirePlace>().Property(item => item.AireInfAbsDeb).IsRequired();
            modelBuilder.Entity<InfAirePlace>().Property(item => item.AireInfAbsDeb).HasColumnName("AIRE_INF__ABS_DEB");
            modelBuilder.Entity<InfAirePlace>().Property(item => item.Nbre).HasColumnName("NBRE");
            modelBuilder.Entity<OaCdFam>().ToTable("CD_FAM_OA","OA");
            modelBuilder.Entity<OaCdFam>().HasKey(item => new {item.Famille });
            modelBuilder.Entity<OaCdFam>().Property(item => item.Famille).IsRequired();
            modelBuilder.Entity<OaCdFam>().Property(item => item.Famille).HasMaxLength(20);
            modelBuilder.Entity<OaCdFam>().Property(item => item.Famille).HasColumnName("FAMILLE");
            modelBuilder.Entity<OaCdFam>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<OaCdFam>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<OaCdType>().ToTable("CD_TYPE_OA","OA");
            modelBuilder.Entity<OaCdType>().HasKey(item => new {item.Type });
            modelBuilder.Entity<OaCdType>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<OaCdType>().Property(item => item.Type).HasMaxLength(20);
            modelBuilder.Entity<OaCdType>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<OaCdType>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<OaCdType>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<OaCdEntp>().ToTable("CD_ENTP_OA","OA");
            modelBuilder.Entity<OaCdEntp>().HasKey(item => new {item.Entreprise });
            modelBuilder.Entity<OaCdEntp>().Property(item => item.Entreprise).IsRequired();
            modelBuilder.Entity<OaCdEntp>().Property(item => item.Entreprise).HasMaxLength(60);
            modelBuilder.Entity<OaCdEntp>().Property(item => item.Entreprise).HasColumnName("ENTREPRISE");
            modelBuilder.Entity<OaDsc>().ToTable("DSC_OA","OA");
            modelBuilder.Entity<OaDsc>().HasKey(item => new {item.NumOa });
            modelBuilder.Entity<OaDsc>().Property(item => item.NumOa).IsRequired();
            modelBuilder.Entity<OaDsc>().Property(item => item.NumOa).HasMaxLength(20);
            modelBuilder.Entity<OaDsc>().Property(item => item.NumOa).HasColumnName("NUM_OA");
            modelBuilder.Entity<OaDsc>().Property(item => item.CdIqoaOaNoteIqoa).HasMaxLength(3);
            modelBuilder.Entity<OaDsc>().Property(item => item.CdIqoaOaNoteIqoa).HasColumnName("CD_IQOA_OA__NOTE_IQOA");
            modelBuilder.Entity<OaDsc>().Property(item => item.CdQualiteOaQualite).HasMaxLength(25);
            modelBuilder.Entity<OaDsc>().Property(item => item.CdQualiteOaQualite).HasColumnName("CD_QUALITE_OA__QUALITE");
            modelBuilder.Entity<OaDsc>().Property(item => item.CdFamOaFamille).IsRequired();
            modelBuilder.Entity<OaDsc>().Property(item => item.CdFamOaFamille).HasMaxLength(20);
            modelBuilder.Entity<OaDsc>().Property(item => item.CdFamOaFamille).HasColumnName("CD_FAM_OA__FAMILLE");
            modelBuilder.Entity<OaDsc>().Property(item => item.CdEntpOaEntreprise).HasMaxLength(60);
            modelBuilder.Entity<OaDsc>().Property(item => item.CdEntpOaEntreprise).HasColumnName("CD_ENTP_OA__ENTREPRISE");
            modelBuilder.Entity<OaDsc>().Property(item => item.CdTablierOaTablier).HasMaxLength(60);
            modelBuilder.Entity<OaDsc>().Property(item => item.CdTablierOaTablier).HasColumnName("CD_TABLIER_OA__TABLIER");
            modelBuilder.Entity<OaDsc>().Property(item => item.CdTypeOaType).IsRequired();
            modelBuilder.Entity<OaDsc>().Property(item => item.CdTypeOaType).HasMaxLength(20);
            modelBuilder.Entity<OaDsc>().Property(item => item.CdTypeOaType).HasColumnName("CD_TYPE_OA__TYPE");
            modelBuilder.Entity<OaDsc>().Property(item => item.CdGestOaGestionnaire).HasMaxLength(60);
            modelBuilder.Entity<OaDsc>().Property(item => item.CdGestOaGestionnaire).HasColumnName("CD_GEST_OA__GESTIONNAIRE");
            modelBuilder.Entity<OaDsc>().Property(item => item.CdHierarchieOaHierarchie).HasMaxLength(60);
            modelBuilder.Entity<OaDsc>().Property(item => item.CdHierarchieOaHierarchie).HasColumnName("CD_HIERARCHIE_OA__HIERARCHIE");
            modelBuilder.Entity<OaDsc>().Property(item => item.CdMatOaMateriaux).HasMaxLength(60);
            modelBuilder.Entity<OaDsc>().Property(item => item.CdMatOaMateriaux).HasColumnName("CD_MAT_OA__MATERIAUX");
            modelBuilder.Entity<OaDsc>().Property(item => item.CdChargeOaSurcharge).HasMaxLength(60);
            modelBuilder.Entity<OaDsc>().Property(item => item.CdChargeOaSurcharge).HasColumnName("CD_CHARGE_OA__SURCHARGE");
            modelBuilder.Entity<OaDsc>().Property(item => item.CdBeOaBureau).HasMaxLength(60);
            modelBuilder.Entity<OaDsc>().Property(item => item.CdBeOaBureau).HasColumnName("CD_BE_OA__BUREAU");
            modelBuilder.Entity<OaDsc>().Property(item => item.CdMoOaMaitreOuvr).HasMaxLength(60);
            modelBuilder.Entity<OaDsc>().Property(item => item.CdMoOaMaitreOuvr).HasColumnName("CD_MO_OA__MAITRE_OUVR");
            modelBuilder.Entity<OaDsc>().Property(item => item.CdFondOaType).HasMaxLength(60);
            modelBuilder.Entity<OaDsc>().Property(item => item.CdFondOaType).HasColumnName("CD_FOND_OA__TYPE");
            modelBuilder.Entity<OaDsc>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<OaDsc>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<OaDsc>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<OaDsc>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<OaDsc>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<OaDsc>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<OaDsc>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<OaDsc>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<OaDsc>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<OaDsc>().Property(item => item.NumExploit).HasMaxLength(30);
            modelBuilder.Entity<OaDsc>().Property(item => item.NumExploit).HasColumnName("NUM_EXPLOIT");
            modelBuilder.Entity<OaDsc>().Property(item => item.NomUsage).HasMaxLength(255);
            modelBuilder.Entity<OaDsc>().Property(item => item.NomUsage).HasColumnName("NOM_USAGE");
            modelBuilder.Entity<OaDsc>().Property(item => item.DateConst).HasColumnName("DATE_CONST");
            modelBuilder.Entity<OaDsc>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<OaDsc>().Property(item => item.Vpf).HasMaxLength(60);
            modelBuilder.Entity<OaDsc>().Property(item => item.Vpf).HasColumnName("VPF");
            modelBuilder.Entity<OaDsc>().Property(item => item.TraficVpf).HasColumnName("TRAFIC_VPF");
            modelBuilder.Entity<OaDsc>().Property(item => item.Deviation).HasColumnName("DEVIATION");
            modelBuilder.Entity<OaDsc>().Property(item => item.Nbpilesinter).HasColumnName("NBPILESINTER");
            modelBuilder.Entity<OaDsc>().Property(item => item.Travure).HasColumnName("TRAVURE");
            modelBuilder.Entity<OaDsc>().Property(item => item.LongMaxTrav).HasColumnName("LONG_MAX_TRAV");
            modelBuilder.Entity<OaDsc>().Property(item => item.GabMini).HasColumnName("GAB_MINI");
            modelBuilder.Entity<OaDsc>().Property(item => item.GabGra).HasColumnName("GAB_GRA");
            modelBuilder.Entity<OaDsc>().Property(item => item.Biais).HasColumnName("BIAIS");
            modelBuilder.Entity<OaDsc>().Property(item => item.LongBiaise).HasColumnName("LONG_BIAISE");
            modelBuilder.Entity<OaDsc>().Property(item => item.LargTrav).HasColumnName("LARG_TRAV");
            modelBuilder.Entity<OaDsc>().Property(item => item.LargBiaise).HasColumnName("LARG_BIAISE");
            modelBuilder.Entity<OaDsc>().Property(item => item.LargGs).HasColumnName("LARG_GS");
            modelBuilder.Entity<OaDsc>().Property(item => item.SurfTablier).HasColumnName("SURF_TABLIER");
            modelBuilder.Entity<OaDsc>().Property(item => item.SurfVpf).HasColumnName("SURF_VPF");
            modelBuilder.Entity<OaDsc>().Property(item => item.Immerge).HasColumnName("IMMERGE");
            modelBuilder.Entity<OaDsc>().Property(item => item.Sismicite).HasColumnName("SISMICITE");
            modelBuilder.Entity<OaDsc>().Property(item => item.Dalle).HasColumnName("DALLE");
            modelBuilder.Entity<OaDsc>().Property(item => item.Corn).HasColumnName("CORN");
            modelBuilder.Entity<OaDsc>().Property(item => item.Lanterneau).HasColumnName("LANTERNEAU");
            modelBuilder.Entity<OaDsc>().Property(item => item.EquipVst).HasColumnName("EQUIP_VST");
            modelBuilder.Entity<OaDsc>().Property(item => item.Note1).HasColumnName("NOTE1");
            modelBuilder.Entity<OaDsc>().Property(item => item.Note2).HasColumnName("NOTE2");
            modelBuilder.Entity<OaDsc>().Property(item => item.Note3).HasColumnName("NOTE3");
            modelBuilder.Entity<OaDsc>().Property(item => item.Urgence).HasMaxLength(5);
            modelBuilder.Entity<OaDsc>().Property(item => item.Urgence).HasColumnName("URGENCE");
            modelBuilder.Entity<OaDsc>().Property(item => item.DescInva).HasMaxLength(1000);
            modelBuilder.Entity<OaDsc>().Property(item => item.DescInva).HasColumnName("DESC_INVA");
            modelBuilder.Entity<OaDsc>().Property(item => item.Securite).HasColumnName("SECURITE");
            modelBuilder.Entity<OaDsc>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<OaDsc>().Property(item => item.ProsurvAnnee).HasColumnName("PROSURV_ANNEE");
            modelBuilder.Entity<OaDsc>().Property(item => item.DernInsp).HasColumnName("DERN_INSP");
            modelBuilder.Entity<OaDsc>().Property(item => item.DernVst).HasColumnName("DERN_VST");
            modelBuilder.Entity<OaDsc>().Property(item => item.NoteVst).HasMaxLength(5);
            modelBuilder.Entity<OaDsc>().Property(item => item.NoteVst).HasColumnName("NOTE_VST");
            modelBuilder.Entity<OaDsc>().Property(item => item.Archive).HasMaxLength(255);
            modelBuilder.Entity<OaDsc>().Property(item => item.Archive).HasColumnName("ARCHIVE");
            modelBuilder.Entity<OaDsc>().Property(item => item.Commentaire).HasMaxLength(1000);
            modelBuilder.Entity<OaDsc>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<OaDsc>().Property(item => item.X1).HasColumnName("X1");
            modelBuilder.Entity<OaDsc>().Property(item => item.Y1).HasColumnName("Y1");
            modelBuilder.Entity<OaDsc>().Property(item => item.Z1).HasColumnName("Z1");
            modelBuilder.Entity<OaDsc>().Property(item => item.X2).HasColumnName("X2");
            modelBuilder.Entity<OaDsc>().Property(item => item.Y2).HasColumnName("Y2");
            modelBuilder.Entity<OaDsc>().Property(item => item.Z2).HasColumnName("Z2");
            modelBuilder.Entity<OaDsc>().Property(item => item.DateReleve).HasColumnName("DATE_RELEVE");
            modelBuilder.Entity<OaDsc>().Property(item => item.Terrain).HasColumnName("TERRAIN");
            modelBuilder.Entity<OaCdCharge>().ToTable("CD_CHARGE_OA","OA");
            modelBuilder.Entity<OaCdCharge>().HasKey(item => new {item.Surcharge });
            modelBuilder.Entity<OaCdCharge>().Property(item => item.Surcharge).IsRequired();
            modelBuilder.Entity<OaCdCharge>().Property(item => item.Surcharge).HasMaxLength(60);
            modelBuilder.Entity<OaCdCharge>().Property(item => item.Surcharge).HasColumnName("SURCHARGE");
            modelBuilder.Entity<OaCdFond>().ToTable("CD_FOND_OA","OA");
            modelBuilder.Entity<OaCdFond>().HasKey(item => new {item.Type });
            modelBuilder.Entity<OaCdFond>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<OaCdFond>().Property(item => item.Type).HasMaxLength(60);
            modelBuilder.Entity<OaCdFond>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<OaCdFamAppui>().ToTable("CD_FAM_APPUI_OA","OA");
            modelBuilder.Entity<OaCdFamAppui>().HasKey(item => new {item.FamApp });
            modelBuilder.Entity<OaCdFamAppui>().Property(item => item.FamApp).IsRequired();
            modelBuilder.Entity<OaCdFamAppui>().Property(item => item.FamApp).HasMaxLength(60);
            modelBuilder.Entity<OaCdFamAppui>().Property(item => item.FamApp).HasColumnName("FAM_APP");
            modelBuilder.Entity<OaCdAppui>().ToTable("CD_APPUI_OA","OA");
            modelBuilder.Entity<OaCdAppui>().HasKey(item => new {item.App });
            modelBuilder.Entity<OaCdAppui>().Property(item => item.App).IsRequired();
            modelBuilder.Entity<OaCdAppui>().Property(item => item.App).HasMaxLength(60);
            modelBuilder.Entity<OaCdAppui>().Property(item => item.App).HasColumnName("APP");
            modelBuilder.Entity<OaCdAppAppui>().ToTable("CD_APP_APPUI_OA","OA");
            modelBuilder.Entity<OaCdAppAppui>().HasKey(item => new {item.Appui });
            modelBuilder.Entity<OaCdAppAppui>().Property(item => item.Appui).IsRequired();
            modelBuilder.Entity<OaCdAppAppui>().Property(item => item.Appui).HasMaxLength(60);
            modelBuilder.Entity<OaCdAppAppui>().Property(item => item.Appui).HasColumnName("APPUI");
            modelBuilder.Entity<OaCdAppAppui>().Property(item => item.Garantie).HasColumnName("GARANTIE");
            modelBuilder.Entity<OaCdAppAppui>().Property(item => item.Dvt).HasColumnName("DVT");
            modelBuilder.Entity<OaCdChape>().ToTable("CD_CHAPE_OA","OA");
            modelBuilder.Entity<OaCdChape>().HasKey(item => new {item.Chape });
            modelBuilder.Entity<OaCdChape>().Property(item => item.Chape).IsRequired();
            modelBuilder.Entity<OaCdChape>().Property(item => item.Chape).HasMaxLength(60);
            modelBuilder.Entity<OaCdChape>().Property(item => item.Chape).HasColumnName("CHAPE");
            modelBuilder.Entity<OaCdChape>().Property(item => item.Garantie).HasColumnName("GARANTIE");
            modelBuilder.Entity<OaCdChape>().Property(item => item.Dvt).HasColumnName("DVT");
            modelBuilder.Entity<OaTablier>().ToTable("TABLIER_OA","OA");
            modelBuilder.Entity<OaTablier>().HasKey(item => new {item.DscOaNumOa,item.NumTab });
            modelBuilder.Entity<OaTablier>().Property(item => item.DscOaNumOa).IsRequired();
            modelBuilder.Entity<OaTablier>().Property(item => item.DscOaNumOa).HasMaxLength(20);
            modelBuilder.Entity<OaTablier>().Property(item => item.DscOaNumOa).HasColumnName("DSC_OA__NUM_OA");
            modelBuilder.Entity<OaTablier>().Property(item => item.NumTab).IsRequired();
            modelBuilder.Entity<OaTablier>().Property(item => item.NumTab).HasColumnName("NUM_TAB");
            modelBuilder.Entity<OaTablier>().Property(item => item.CdEntpOaEntreprise).HasMaxLength(60);
            modelBuilder.Entity<OaTablier>().Property(item => item.CdEntpOaEntreprise).HasColumnName("CD_ENTP_OA__ENTREPRISE");
            modelBuilder.Entity<OaTablier>().Property(item => item.CdTechOaTechnique).HasMaxLength(12);
            modelBuilder.Entity<OaTablier>().Property(item => item.CdTechOaTechnique).HasColumnName("CD_TECH_OA__TECHNIQUE");
            modelBuilder.Entity<OaTablier>().Property(item => item.CdChapeOaChape).HasMaxLength(60);
            modelBuilder.Entity<OaTablier>().Property(item => item.CdChapeOaChape).HasColumnName("CD_CHAPE_OA__CHAPE");
            modelBuilder.Entity<OaTablier>().Property(item => item.DateMsChape).HasColumnName("DATE_MS_CHAPE");
            modelBuilder.Entity<OaTablier>().Property(item => item.SurfChape).HasColumnName("SURF_CHAPE");
            modelBuilder.Entity<OaTablier>().Property(item => item.EpaisChape).HasColumnName("EPAIS_CHAPE");
            modelBuilder.Entity<OaTablier>().Property(item => item.DateMsBb).HasColumnName("DATE_MS_BB");
            modelBuilder.Entity<OaTablier>().Property(item => item.Epais).HasColumnName("EPAIS");
            modelBuilder.Entity<OaTablier>().Property(item => item.Granulo).HasMaxLength(8);
            modelBuilder.Entity<OaTablier>().Property(item => item.Granulo).HasColumnName("GRANULO");
            modelBuilder.Entity<OaTablier>().Property(item => item.Commentaire).HasMaxLength(255);
            modelBuilder.Entity<OaTablier>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<OaCdDpr>().ToTable("CD_DPR_OA","OA");
            modelBuilder.Entity<OaCdDpr>().HasKey(item => new {item.Dpr });
            modelBuilder.Entity<OaCdDpr>().Property(item => item.Dpr).IsRequired();
            modelBuilder.Entity<OaCdDpr>().Property(item => item.Dpr).HasMaxLength(60);
            modelBuilder.Entity<OaCdDpr>().Property(item => item.Dpr).HasColumnName("DPR");
            modelBuilder.Entity<OaCdDpr>().Property(item => item.Garantie).HasColumnName("GARANTIE");
            modelBuilder.Entity<OaCdDpr>().Property(item => item.Dvt).HasColumnName("DVT");
            modelBuilder.Entity<OaEquipement>().ToTable("EQUIPEMENT_OA","OA");
            modelBuilder.Entity<OaEquipement>().HasKey(item => new {item.DscOaNumOa,item.TablierOaNumTab,item.Cote });
            modelBuilder.Entity<OaEquipement>().Property(item => item.DscOaNumOa).IsRequired();
            modelBuilder.Entity<OaEquipement>().Property(item => item.DscOaNumOa).HasMaxLength(20);
            modelBuilder.Entity<OaEquipement>().Property(item => item.DscOaNumOa).HasColumnName("DSC_OA__NUM_OA");
            modelBuilder.Entity<OaEquipement>().Property(item => item.TablierOaNumTab).IsRequired();
            modelBuilder.Entity<OaEquipement>().Property(item => item.TablierOaNumTab).HasColumnName("TABLIER_OA__NUM_TAB");
            modelBuilder.Entity<OaEquipement>().Property(item => item.Cote).IsRequired();
            modelBuilder.Entity<OaEquipement>().Property(item => item.Cote).HasMaxLength(1);
            modelBuilder.Entity<OaEquipement>().Property(item => item.Cote).HasColumnName("COTE");
            modelBuilder.Entity<OaEquipement>().Property(item => item.CdDprOaDpr).HasMaxLength(60);
            modelBuilder.Entity<OaEquipement>().Property(item => item.CdDprOaDpr).HasColumnName("CD_DPR_OA__DPR");
            modelBuilder.Entity<OaEquipement>().Property(item => item.CdGcOaGardeCorps).HasMaxLength(60);
            modelBuilder.Entity<OaEquipement>().Property(item => item.CdGcOaGardeCorps).HasColumnName("CD_GC_OA__GARDE_CORPS");
            modelBuilder.Entity<OaEquipement>().Property(item => item.DateDpr).HasColumnName("DATE_DPR");
            modelBuilder.Entity<OaEquipement>().Property(item => item.DateGc).HasColumnName("DATE_GC");
            modelBuilder.Entity<OaEquipement>().Property(item => item.Commentaire).HasMaxLength(255);
            modelBuilder.Entity<OaEquipement>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<OaCdGc>().ToTable("CD_GC_OA","OA");
            modelBuilder.Entity<OaCdGc>().HasKey(item => new {item.GardeCorps });
            modelBuilder.Entity<OaCdGc>().Property(item => item.GardeCorps).IsRequired();
            modelBuilder.Entity<OaCdGc>().Property(item => item.GardeCorps).HasMaxLength(60);
            modelBuilder.Entity<OaCdGc>().Property(item => item.GardeCorps).HasColumnName("GARDE_CORPS");
            modelBuilder.Entity<OaCdGc>().Property(item => item.Garantie).HasColumnName("GARANTIE");
            modelBuilder.Entity<OaCdGc>().Property(item => item.Dvt).HasColumnName("DVT");
            modelBuilder.Entity<OaJoint>().ToTable("JOINT_OA","OA");
            modelBuilder.Entity<OaJoint>().HasKey(item => new {item.DscOaNumOa,item.TablierOaNumTab,item.NumJoint });
            modelBuilder.Entity<OaJoint>().Property(item => item.DscOaNumOa).IsRequired();
            modelBuilder.Entity<OaJoint>().Property(item => item.DscOaNumOa).HasMaxLength(20);
            modelBuilder.Entity<OaJoint>().Property(item => item.DscOaNumOa).HasColumnName("DSC_OA__NUM_OA");
            modelBuilder.Entity<OaJoint>().Property(item => item.TablierOaNumTab).IsRequired();
            modelBuilder.Entity<OaJoint>().Property(item => item.TablierOaNumTab).HasColumnName("TABLIER_OA__NUM_TAB");
            modelBuilder.Entity<OaJoint>().Property(item => item.NumJoint).IsRequired();
            modelBuilder.Entity<OaJoint>().Property(item => item.NumJoint).HasColumnName("NUM_JOINT");
            modelBuilder.Entity<OaJoint>().Property(item => item.CdJointOaType).IsRequired();
            modelBuilder.Entity<OaJoint>().Property(item => item.CdJointOaType).HasMaxLength(60);
            modelBuilder.Entity<OaJoint>().Property(item => item.CdJointOaType).HasColumnName("CD_JOINT_OA__TYPE");
            modelBuilder.Entity<OaJoint>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<OaJoint>().Property(item => item.Longueur).HasColumnName("LONGUEUR");
            modelBuilder.Entity<OaJoint>().Property(item => item.Commentaire).HasMaxLength(255);
            modelBuilder.Entity<OaJoint>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<OaCdJoint>().ToTable("CD_JOINT_OA","OA");
            modelBuilder.Entity<OaCdJoint>().HasKey(item => new {item.Type });
            modelBuilder.Entity<OaCdJoint>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<OaCdJoint>().Property(item => item.Type).HasMaxLength(60);
            modelBuilder.Entity<OaCdJoint>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<OaCdJoint>().Property(item => item.Garantie).HasColumnName("GARANTIE");
            modelBuilder.Entity<OaCdJoint>().Property(item => item.Dvt).HasColumnName("DVT");
            modelBuilder.Entity<OaCdTablier>().ToTable("CD_TABLIER_OA","OA");
            modelBuilder.Entity<OaCdTablier>().HasKey(item => new {item.Tablier });
            modelBuilder.Entity<OaCdTablier>().Property(item => item.Tablier).IsRequired();
            modelBuilder.Entity<OaCdTablier>().Property(item => item.Tablier).HasMaxLength(60);
            modelBuilder.Entity<OaCdTablier>().Property(item => item.Tablier).HasColumnName("TABLIER");
            modelBuilder.Entity<OaCdMat>().ToTable("CD_MAT_OA","OA");
            modelBuilder.Entity<OaCdMat>().HasKey(item => new {item.Materiaux });
            modelBuilder.Entity<OaCdMat>().Property(item => item.Materiaux).IsRequired();
            modelBuilder.Entity<OaCdMat>().Property(item => item.Materiaux).HasMaxLength(60);
            modelBuilder.Entity<OaCdMat>().Property(item => item.Materiaux).HasColumnName("MATERIAUX");
            modelBuilder.Entity<OaCls>().ToTable("CLS_OA","OA");
            modelBuilder.Entity<OaCls>().HasKey(item => new {item.Id });
            modelBuilder.Entity<OaCls>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<OaCls>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<OaCls>().Property(item => item.TableName).IsRequired();
            modelBuilder.Entity<OaCls>().Property(item => item.TableName).HasMaxLength(30);
            modelBuilder.Entity<OaCls>().Property(item => item.TableName).HasColumnName("TABLE_NAME");
            modelBuilder.Entity<OaCls>().Property(item => item.KeyValue).IsRequired();
            modelBuilder.Entity<OaCls>().Property(item => item.KeyValue).HasMaxLength(1000);
            modelBuilder.Entity<OaCls>().Property(item => item.KeyValue).HasColumnName("KEY_VALUE");
            modelBuilder.Entity<OaDoc>().ToTable("DOC_OA","OA");
            modelBuilder.Entity<OaDoc>().HasKey(item => new {item.Id });
            modelBuilder.Entity<OaDoc>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<OaDoc>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<OaDoc>().Property(item => item.CdDocOaCode).IsRequired();
            modelBuilder.Entity<OaDoc>().Property(item => item.CdDocOaCode).HasMaxLength(15);
            modelBuilder.Entity<OaDoc>().Property(item => item.CdDocOaCode).HasColumnName("CD_DOC_OA__CODE");
            modelBuilder.Entity<OaDoc>().Property(item => item.Libelle).HasMaxLength(100);
            modelBuilder.Entity<OaDoc>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<OaDoc>().Property(item => item.Ref).IsRequired();
            modelBuilder.Entity<OaDoc>().Property(item => item.Ref).HasMaxLength(50);
            modelBuilder.Entity<OaDoc>().Property(item => item.Ref).HasColumnName("REF");
            modelBuilder.Entity<OaCdDoc>().ToTable("CD_DOC_OA","OA");
            modelBuilder.Entity<OaCdDoc>().HasKey(item => new {item.Code });
            modelBuilder.Entity<OaCdDoc>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<OaCdDoc>().Property(item => item.Code).HasMaxLength(15);
            modelBuilder.Entity<OaCdDoc>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<OaCdDoc>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<OaCdDoc>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<OaCdDoc>().Property(item => item.Path).HasMaxLength(255);
            modelBuilder.Entity<OaCdDoc>().Property(item => item.Path).HasColumnName("PATH");
            modelBuilder.Entity<OaSysUser>().ToTable("SYS_USER_OA","OA");
            modelBuilder.Entity<OaSysUser>().HasKey(item => new {item.CodeDbs,item.CodeTable,item.CodeColonne,item.NomUser,item.CodePrp });
            modelBuilder.Entity<OaSysUser>().Property(item => item.CodeDbs).IsRequired();
            modelBuilder.Entity<OaSysUser>().Property(item => item.CodeDbs).HasMaxLength(50);
            modelBuilder.Entity<OaSysUser>().Property(item => item.CodeDbs).HasColumnName("CODE_DBS");
            modelBuilder.Entity<OaSysUser>().Property(item => item.CodeTable).IsRequired();
            modelBuilder.Entity<OaSysUser>().Property(item => item.CodeTable).HasMaxLength(100);
            modelBuilder.Entity<OaSysUser>().Property(item => item.CodeTable).HasColumnName("CODE_TABLE");
            modelBuilder.Entity<OaSysUser>().Property(item => item.CodeColonne).IsRequired();
            modelBuilder.Entity<OaSysUser>().Property(item => item.CodeColonne).HasMaxLength(100);
            modelBuilder.Entity<OaSysUser>().Property(item => item.CodeColonne).HasColumnName("CODE_COLONNE");
            modelBuilder.Entity<OaSysUser>().Property(item => item.NomUser).IsRequired();
            modelBuilder.Entity<OaSysUser>().Property(item => item.NomUser).HasMaxLength(150);
            modelBuilder.Entity<OaSysUser>().Property(item => item.NomUser).HasColumnName("NOM_USER");
            modelBuilder.Entity<OaSysUser>().Property(item => item.CodePrp).IsRequired();
            modelBuilder.Entity<OaSysUser>().Property(item => item.CodePrp).HasMaxLength(255);
            modelBuilder.Entity<OaSysUser>().Property(item => item.CodePrp).HasColumnName("CODE_PRP");
            modelBuilder.Entity<OaSysUser>().Property(item => item.ValPrp).IsRequired();
            modelBuilder.Entity<OaSysUser>().Property(item => item.ValPrp).HasMaxLength(500);
            modelBuilder.Entity<OaSysUser>().Property(item => item.ValPrp).HasColumnName("VAL_PRP");
            modelBuilder.Entity<OaCdBe>().ToTable("CD_BE_OA","OA");
            modelBuilder.Entity<OaCdBe>().HasKey(item => new {item.Bureau });
            modelBuilder.Entity<OaCdBe>().Property(item => item.Bureau).IsRequired();
            modelBuilder.Entity<OaCdBe>().Property(item => item.Bureau).HasMaxLength(60);
            modelBuilder.Entity<OaCdBe>().Property(item => item.Bureau).HasColumnName("BUREAU");
            modelBuilder.Entity<OaCdGest>().ToTable("CD_GEST_OA","OA");
            modelBuilder.Entity<OaCdGest>().HasKey(item => new {item.Gestionnaire });
            modelBuilder.Entity<OaCdGest>().Property(item => item.Gestionnaire).IsRequired();
            modelBuilder.Entity<OaCdGest>().Property(item => item.Gestionnaire).HasMaxLength(60);
            modelBuilder.Entity<OaCdGest>().Property(item => item.Gestionnaire).HasColumnName("GESTIONNAIRE");
            modelBuilder.Entity<OaElt>().ToTable("ELT_OA","OA");
            modelBuilder.Entity<OaElt>().HasKey(item => new {item.GrpOaIdGrp,item.PrtOaIdPrt,item.SprtOaIdSprt,item.IdElem });
            modelBuilder.Entity<OaElt>().Property(item => item.GrpOaIdGrp).IsRequired();
            modelBuilder.Entity<OaElt>().Property(item => item.GrpOaIdGrp).HasColumnName("GRP_OA__ID_GRP");
            modelBuilder.Entity<OaElt>().Property(item => item.PrtOaIdPrt).IsRequired();
            modelBuilder.Entity<OaElt>().Property(item => item.PrtOaIdPrt).HasColumnName("PRT_OA__ID_PRT");
            modelBuilder.Entity<OaElt>().Property(item => item.SprtOaIdSprt).IsRequired();
            modelBuilder.Entity<OaElt>().Property(item => item.SprtOaIdSprt).HasColumnName("SPRT_OA__ID_SPRT");
            modelBuilder.Entity<OaElt>().Property(item => item.IdElem).IsRequired();
            modelBuilder.Entity<OaElt>().Property(item => item.IdElem).HasColumnName("ID_ELEM");
            modelBuilder.Entity<OaElt>().Property(item => item.Libe).IsRequired();
            modelBuilder.Entity<OaElt>().Property(item => item.Libe).HasMaxLength(500);
            modelBuilder.Entity<OaElt>().Property(item => item.Libe).HasColumnName("LIBE");
            modelBuilder.Entity<OaElt>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<OaElt>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<OaElt>().Property(item => item.Aide).HasMaxLength(500);
            modelBuilder.Entity<OaElt>().Property(item => item.Aide).HasColumnName("AIDE");
            modelBuilder.Entity<OaElt>().Property(item => item.Indice1).HasMaxLength(500);
            modelBuilder.Entity<OaElt>().Property(item => item.Indice1).HasColumnName("INDICE1");
            modelBuilder.Entity<OaElt>().Property(item => item.Indice2).HasMaxLength(500);
            modelBuilder.Entity<OaElt>().Property(item => item.Indice2).HasColumnName("INDICE2");
            modelBuilder.Entity<OaElt>().Property(item => item.Indice3).HasMaxLength(500);
            modelBuilder.Entity<OaElt>().Property(item => item.Indice3).HasColumnName("INDICE3");
            modelBuilder.Entity<OaSprt>().ToTable("SPRT_OA","OA");
            modelBuilder.Entity<OaSprt>().HasKey(item => new {item.GrpOaIdGrp,item.PrtOaIdPrt,item.IdSprt });
            modelBuilder.Entity<OaSprt>().Property(item => item.GrpOaIdGrp).IsRequired();
            modelBuilder.Entity<OaSprt>().Property(item => item.GrpOaIdGrp).HasColumnName("GRP_OA__ID_GRP");
            modelBuilder.Entity<OaSprt>().Property(item => item.PrtOaIdPrt).IsRequired();
            modelBuilder.Entity<OaSprt>().Property(item => item.PrtOaIdPrt).HasColumnName("PRT_OA__ID_PRT");
            modelBuilder.Entity<OaSprt>().Property(item => item.IdSprt).IsRequired();
            modelBuilder.Entity<OaSprt>().Property(item => item.IdSprt).HasColumnName("ID_SPRT");
            modelBuilder.Entity<OaSprt>().Property(item => item.Libs).IsRequired();
            modelBuilder.Entity<OaSprt>().Property(item => item.Libs).HasMaxLength(500);
            modelBuilder.Entity<OaSprt>().Property(item => item.Libs).HasColumnName("LIBS");
            modelBuilder.Entity<OaSprt>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<OaSprt>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<OaPrt>().ToTable("PRT_OA","OA");
            modelBuilder.Entity<OaPrt>().HasKey(item => new {item.GrpOaIdGrp,item.IdPrt });
            modelBuilder.Entity<OaPrt>().Property(item => item.GrpOaIdGrp).IsRequired();
            modelBuilder.Entity<OaPrt>().Property(item => item.GrpOaIdGrp).HasColumnName("GRP_OA__ID_GRP");
            modelBuilder.Entity<OaPrt>().Property(item => item.IdPrt).IsRequired();
            modelBuilder.Entity<OaPrt>().Property(item => item.IdPrt).HasColumnName("ID_PRT");
            modelBuilder.Entity<OaPrt>().Property(item => item.Libp).IsRequired();
            modelBuilder.Entity<OaPrt>().Property(item => item.Libp).HasMaxLength(500);
            modelBuilder.Entity<OaPrt>().Property(item => item.Libp).HasColumnName("LIBP");
            modelBuilder.Entity<OaPrt>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<OaPrt>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<OaGrp>().ToTable("GRP_OA","OA");
            modelBuilder.Entity<OaGrp>().HasKey(item => new {item.IdGrp });
            modelBuilder.Entity<OaGrp>().Property(item => item.IdGrp).IsRequired();
            modelBuilder.Entity<OaGrp>().Property(item => item.IdGrp).HasColumnName("ID_GRP");
            modelBuilder.Entity<OaGrp>().Property(item => item.Libg).IsRequired();
            modelBuilder.Entity<OaGrp>().Property(item => item.Libg).HasMaxLength(500);
            modelBuilder.Entity<OaGrp>().Property(item => item.Libg).HasColumnName("LIBG");
            modelBuilder.Entity<OaGrp>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<OaGrp>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<OaInsp>().ToTable("INSP_OA","OA");
            modelBuilder.Entity<OaInsp>().HasKey(item => new {item.DscOaNumOa,item.CampOaIdCamp });
            modelBuilder.Entity<OaInsp>().Property(item => item.DscOaNumOa).IsRequired();
            modelBuilder.Entity<OaInsp>().Property(item => item.DscOaNumOa).HasMaxLength(20);
            modelBuilder.Entity<OaInsp>().Property(item => item.DscOaNumOa).HasColumnName("DSC_OA__NUM_OA");
            modelBuilder.Entity<OaInsp>().Property(item => item.CampOaIdCamp).IsRequired();
            modelBuilder.Entity<OaInsp>().Property(item => item.CampOaIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OaInsp>().Property(item => item.CampOaIdCamp).HasColumnName("CAMP_OA__ID_CAMP");
            modelBuilder.Entity<OaInsp>().Property(item => item.CdMeteoOaMeteo).HasMaxLength(60);
            modelBuilder.Entity<OaInsp>().Property(item => item.CdMeteoOaMeteo).HasColumnName("CD_METEO_OA__METEO");
            modelBuilder.Entity<OaInsp>().Property(item => item.CdIqoaOaNoteIqoa).IsRequired();
            modelBuilder.Entity<OaInsp>().Property(item => item.CdIqoaOaNoteIqoa).HasMaxLength(3);
            modelBuilder.Entity<OaInsp>().Property(item => item.CdIqoaOaNoteIqoa).HasColumnName("CD_IQOA_OA__NOTE_IQOA");
            modelBuilder.Entity<OaInsp>().Property(item => item.InspecteurOaNom).HasMaxLength(60);
            modelBuilder.Entity<OaInsp>().Property(item => item.InspecteurOaNom).HasColumnName("INSPECTEUR_OA__NOM");
            modelBuilder.Entity<OaInsp>().Property(item => item.CdEtudeOaEtude).HasMaxLength(60);
            modelBuilder.Entity<OaInsp>().Property(item => item.CdEtudeOaEtude).HasColumnName("CD_ETUDE_OA__ETUDE");
            modelBuilder.Entity<OaInsp>().Property(item => item.Etat).IsRequired();
            modelBuilder.Entity<OaInsp>().Property(item => item.Etat).HasMaxLength(25);
            modelBuilder.Entity<OaInsp>().Property(item => item.Etat).HasColumnName("ETAT");
            modelBuilder.Entity<OaInsp>().Property(item => item.Datev).HasColumnName("DATEV");
            modelBuilder.Entity<OaInsp>().Property(item => item.Temperature).HasColumnName("TEMPERATURE");
            modelBuilder.Entity<OaInsp>().Property(item => item.Moyen).HasMaxLength(500);
            modelBuilder.Entity<OaInsp>().Property(item => item.Moyen).HasColumnName("MOYEN");
            modelBuilder.Entity<OaInsp>().Property(item => item.Conditions).HasMaxLength(500);
            modelBuilder.Entity<OaInsp>().Property(item => item.Conditions).HasColumnName("CONDITIONS");
            modelBuilder.Entity<OaInsp>().Property(item => item.DateValid).HasColumnName("DATE_VALID");
            modelBuilder.Entity<OaInsp>().Property(item => item.NomValid).HasMaxLength(255);
            modelBuilder.Entity<OaInsp>().Property(item => item.NomValid).HasColumnName("NOM_VALID");
            modelBuilder.Entity<OaInsp>().Property(item => item.DescInva).HasMaxLength(1000);
            modelBuilder.Entity<OaInsp>().Property(item => item.DescInva).HasColumnName("DESC_INVA");
            modelBuilder.Entity<OaInsp>().Property(item => item.Prioritaire).HasMaxLength(1000);
            modelBuilder.Entity<OaInsp>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<OaInsp>().Property(item => item.Securite).HasMaxLength(1000);
            modelBuilder.Entity<OaInsp>().Property(item => item.Securite).HasColumnName("SECURITE");
            modelBuilder.Entity<OaInsp>().Property(item => item.Note1).HasColumnName("NOTE1");
            modelBuilder.Entity<OaInsp>().Property(item => item.Note2).HasColumnName("NOTE2");
            modelBuilder.Entity<OaInsp>().Property(item => item.Note3).HasColumnName("NOTE3");
            modelBuilder.Entity<OaInsp>().Property(item => item.Urgence).HasMaxLength(5);
            modelBuilder.Entity<OaInsp>().Property(item => item.Urgence).HasColumnName("URGENCE");
            modelBuilder.Entity<OaInsp>().Property(item => item.Qualite).HasMaxLength(25);
            modelBuilder.Entity<OaInsp>().Property(item => item.Qualite).HasColumnName("QUALITE");
            modelBuilder.Entity<OaEltInsp>().ToTable("ELT_INSP_OA","OA");
            modelBuilder.Entity<OaEltInsp>().HasKey(item => new {item.DscOaNumOa,item.CampOaIdCamp,item.GrpOaIdGrp,item.PrtOaIdPrt,item.SprtOaIdSprt,item.EltOaIdElem });
            modelBuilder.Entity<OaEltInsp>().Property(item => item.DscOaNumOa).IsRequired();
            modelBuilder.Entity<OaEltInsp>().Property(item => item.DscOaNumOa).HasMaxLength(20);
            modelBuilder.Entity<OaEltInsp>().Property(item => item.DscOaNumOa).HasColumnName("DSC_OA__NUM_OA");
            modelBuilder.Entity<OaEltInsp>().Property(item => item.CampOaIdCamp).IsRequired();
            modelBuilder.Entity<OaEltInsp>().Property(item => item.CampOaIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OaEltInsp>().Property(item => item.CampOaIdCamp).HasColumnName("CAMP_OA__ID_CAMP");
            modelBuilder.Entity<OaEltInsp>().Property(item => item.GrpOaIdGrp).IsRequired();
            modelBuilder.Entity<OaEltInsp>().Property(item => item.GrpOaIdGrp).HasColumnName("GRP_OA__ID_GRP");
            modelBuilder.Entity<OaEltInsp>().Property(item => item.PrtOaIdPrt).IsRequired();
            modelBuilder.Entity<OaEltInsp>().Property(item => item.PrtOaIdPrt).HasColumnName("PRT_OA__ID_PRT");
            modelBuilder.Entity<OaEltInsp>().Property(item => item.SprtOaIdSprt).IsRequired();
            modelBuilder.Entity<OaEltInsp>().Property(item => item.SprtOaIdSprt).HasColumnName("SPRT_OA__ID_SPRT");
            modelBuilder.Entity<OaEltInsp>().Property(item => item.EltOaIdElem).IsRequired();
            modelBuilder.Entity<OaEltInsp>().Property(item => item.EltOaIdElem).HasColumnName("ELT_OA__ID_ELEM");
            modelBuilder.Entity<OaEltInsp>().Property(item => item.Indice).IsRequired();
            modelBuilder.Entity<OaEltInsp>().Property(item => item.Indice).HasColumnName("INDICE");
            modelBuilder.Entity<OaEltInsp>().Property(item => item.Obs).HasMaxLength(255);
            modelBuilder.Entity<OaEltInsp>().Property(item => item.Obs).HasColumnName("OBS");
            modelBuilder.Entity<OaPhotoEltInsp>().ToTable("PHOTO_ELT_INSP_OA","OA");
            modelBuilder.Entity<OaPhotoEltInsp>().HasKey(item => new {item.GrpOaIdGrp,item.PrtOaIdPrt,item.SprtOaIdSprt,item.DscOaNumOa,item.CampOaIdCamp,item.EltOaIdElem,item.Id });
            modelBuilder.Entity<OaPhotoEltInsp>().Property(item => item.GrpOaIdGrp).IsRequired();
            modelBuilder.Entity<OaPhotoEltInsp>().Property(item => item.GrpOaIdGrp).HasColumnName("GRP_OA__ID_GRP");
            modelBuilder.Entity<OaPhotoEltInsp>().Property(item => item.PrtOaIdPrt).IsRequired();
            modelBuilder.Entity<OaPhotoEltInsp>().Property(item => item.PrtOaIdPrt).HasColumnName("PRT_OA__ID_PRT");
            modelBuilder.Entity<OaPhotoEltInsp>().Property(item => item.SprtOaIdSprt).IsRequired();
            modelBuilder.Entity<OaPhotoEltInsp>().Property(item => item.SprtOaIdSprt).HasColumnName("SPRT_OA__ID_SPRT");
            modelBuilder.Entity<OaPhotoEltInsp>().Property(item => item.DscOaNumOa).IsRequired();
            modelBuilder.Entity<OaPhotoEltInsp>().Property(item => item.DscOaNumOa).HasMaxLength(20);
            modelBuilder.Entity<OaPhotoEltInsp>().Property(item => item.DscOaNumOa).HasColumnName("DSC_OA__NUM_OA");
            modelBuilder.Entity<OaPhotoEltInsp>().Property(item => item.CampOaIdCamp).IsRequired();
            modelBuilder.Entity<OaPhotoEltInsp>().Property(item => item.CampOaIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OaPhotoEltInsp>().Property(item => item.CampOaIdCamp).HasColumnName("CAMP_OA__ID_CAMP");
            modelBuilder.Entity<OaPhotoEltInsp>().Property(item => item.EltOaIdElem).IsRequired();
            modelBuilder.Entity<OaPhotoEltInsp>().Property(item => item.EltOaIdElem).HasColumnName("ELT_OA__ID_ELEM");
            modelBuilder.Entity<OaPhotoEltInsp>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<OaPhotoEltInsp>().Property(item => item.Id).HasMaxLength(50);
            modelBuilder.Entity<OaPhotoEltInsp>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<OaPhotoEltInsp>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<OaPhotoEltInsp>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<OaCamp>().ToTable("CAMP_OA","OA");
            modelBuilder.Entity<OaCamp>().HasKey(item => new {item.IdCamp });
            modelBuilder.Entity<OaCamp>().Property(item => item.IdCamp).IsRequired();
            modelBuilder.Entity<OaCamp>().Property(item => item.IdCamp).HasMaxLength(100);
            modelBuilder.Entity<OaCamp>().Property(item => item.IdCamp).HasColumnName("ID_CAMP");
            modelBuilder.Entity<OaCamp>().Property(item => item.CdTypePvOaCode).IsRequired();
            modelBuilder.Entity<OaCamp>().Property(item => item.CdTypePvOaCode).HasMaxLength(15);
            modelBuilder.Entity<OaCamp>().Property(item => item.CdTypePvOaCode).HasColumnName("CD_TYPE_PV_OA__CODE");
            modelBuilder.Entity<OaCamp>().Property(item => item.CdPrestaOaPrestataire).IsRequired();
            modelBuilder.Entity<OaCamp>().Property(item => item.CdPrestaOaPrestataire).HasMaxLength(50);
            modelBuilder.Entity<OaCamp>().Property(item => item.CdPrestaOaPrestataire).HasColumnName("CD_PRESTA_OA__PRESTATAIRE");
            modelBuilder.Entity<OaCamp>().Property(item => item.Annee).IsRequired();
            modelBuilder.Entity<OaCamp>().Property(item => item.Annee).HasColumnName("ANNEE");
            modelBuilder.Entity<OaCamp>().Property(item => item.Dater).IsRequired();
            modelBuilder.Entity<OaCamp>().Property(item => item.Dater).HasColumnName("DATER");
            modelBuilder.Entity<OaCamp>().Property(item => item.Dateg).HasColumnName("DATEG");
            modelBuilder.Entity<OaCamp>().Property(item => item.Userg).HasMaxLength(255);
            modelBuilder.Entity<OaCamp>().Property(item => item.Userg).HasColumnName("USERG");
            modelBuilder.Entity<OaCamp>().Property(item => item.Observ).HasMaxLength(255);
            modelBuilder.Entity<OaCamp>().Property(item => item.Observ).HasColumnName("OBSERV");
            modelBuilder.Entity<OaCdMeteo>().ToTable("CD_METEO_OA","OA");
            modelBuilder.Entity<OaCdMeteo>().HasKey(item => new {item.Meteo });
            modelBuilder.Entity<OaCdMeteo>().Property(item => item.Meteo).IsRequired();
            modelBuilder.Entity<OaCdMeteo>().Property(item => item.Meteo).HasMaxLength(60);
            modelBuilder.Entity<OaCdMeteo>().Property(item => item.Meteo).HasColumnName("METEO");
            modelBuilder.Entity<OaCdPresta>().ToTable("CD_PRESTA_OA","OA");
            modelBuilder.Entity<OaCdPresta>().HasKey(item => new {item.Prestataire });
            modelBuilder.Entity<OaCdPresta>().Property(item => item.Prestataire).IsRequired();
            modelBuilder.Entity<OaCdPresta>().Property(item => item.Prestataire).HasMaxLength(50);
            modelBuilder.Entity<OaCdPresta>().Property(item => item.Prestataire).HasColumnName("PRESTATAIRE");
            modelBuilder.Entity<OaTravaux>().ToTable("TRAVAUX_OA","OA");
            modelBuilder.Entity<OaTravaux>().HasKey(item => new {item.DscOaNumOa,item.CdTravauxOaCode,item.NatureTravOaNature,item.DateRcp });
            modelBuilder.Entity<OaTravaux>().Property(item => item.DscOaNumOa).IsRequired();
            modelBuilder.Entity<OaTravaux>().Property(item => item.DscOaNumOa).HasMaxLength(20);
            modelBuilder.Entity<OaTravaux>().Property(item => item.DscOaNumOa).HasColumnName("DSC_OA__NUM_OA");
            modelBuilder.Entity<OaTravaux>().Property(item => item.CdTravauxOaCode).IsRequired();
            modelBuilder.Entity<OaTravaux>().Property(item => item.CdTravauxOaCode).HasMaxLength(60);
            modelBuilder.Entity<OaTravaux>().Property(item => item.CdTravauxOaCode).HasColumnName("CD_TRAVAUX_OA__CODE");
            modelBuilder.Entity<OaTravaux>().Property(item => item.NatureTravOaNature).IsRequired();
            modelBuilder.Entity<OaTravaux>().Property(item => item.NatureTravOaNature).HasMaxLength(100);
            modelBuilder.Entity<OaTravaux>().Property(item => item.NatureTravOaNature).HasColumnName("NATURE_TRAV_OA__NATURE");
            modelBuilder.Entity<OaTravaux>().Property(item => item.DateRcp).IsRequired();
            modelBuilder.Entity<OaTravaux>().Property(item => item.DateRcp).HasColumnName("DATE_RCP");
            modelBuilder.Entity<OaTravaux>().Property(item => item.CdEntpOaEntreprise).HasMaxLength(60);
            modelBuilder.Entity<OaTravaux>().Property(item => item.CdEntpOaEntreprise).HasColumnName("CD_ENTP_OA__ENTREPRISE");
            modelBuilder.Entity<OaTravaux>().Property(item => item.DateFinGar).HasColumnName("DATE_FIN_GAR");
            modelBuilder.Entity<OaTravaux>().Property(item => item.Cout).HasColumnName("COUT");
            modelBuilder.Entity<OaTravaux>().Property(item => item.Marche).HasMaxLength(25);
            modelBuilder.Entity<OaTravaux>().Property(item => item.Marche).HasColumnName("MARCHE");
            modelBuilder.Entity<OaTravaux>().Property(item => item.Commentaire).HasMaxLength(1000);
            modelBuilder.Entity<OaTravaux>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<OaNatureTrav>().ToTable("NATURE_TRAV_OA","OA");
            modelBuilder.Entity<OaNatureTrav>().HasKey(item => new {item.CdTravauxOaCode,item.Nature });
            modelBuilder.Entity<OaNatureTrav>().Property(item => item.CdTravauxOaCode).IsRequired();
            modelBuilder.Entity<OaNatureTrav>().Property(item => item.CdTravauxOaCode).HasMaxLength(60);
            modelBuilder.Entity<OaNatureTrav>().Property(item => item.CdTravauxOaCode).HasColumnName("CD_TRAVAUX_OA__CODE");
            modelBuilder.Entity<OaNatureTrav>().Property(item => item.Nature).IsRequired();
            modelBuilder.Entity<OaNatureTrav>().Property(item => item.Nature).HasMaxLength(100);
            modelBuilder.Entity<OaNatureTrav>().Property(item => item.Nature).HasColumnName("NATURE");
            modelBuilder.Entity<OaCdIqoa>().ToTable("CD_IQOA_OA","OA");
            modelBuilder.Entity<OaCdIqoa>().HasKey(item => new {item.NoteIqoa });
            modelBuilder.Entity<OaCdIqoa>().Property(item => item.NoteIqoa).IsRequired();
            modelBuilder.Entity<OaCdIqoa>().Property(item => item.NoteIqoa).HasMaxLength(3);
            modelBuilder.Entity<OaCdIqoa>().Property(item => item.NoteIqoa).HasColumnName("NOTE_IQOA");
            modelBuilder.Entity<OaCdIqoa>().Property(item => item.Commentaire).HasMaxLength(1000);
            modelBuilder.Entity<OaCdIqoa>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<OaCdMo>().ToTable("CD_MO_OA","OA");
            modelBuilder.Entity<OaCdMo>().HasKey(item => new {item.MaitreOuvr });
            modelBuilder.Entity<OaCdMo>().Property(item => item.MaitreOuvr).IsRequired();
            modelBuilder.Entity<OaCdMo>().Property(item => item.MaitreOuvr).HasMaxLength(60);
            modelBuilder.Entity<OaCdMo>().Property(item => item.MaitreOuvr).HasColumnName("MAITRE_OUVR");
            modelBuilder.Entity<OaBpu>().ToTable("BPU_OA","OA");
            modelBuilder.Entity<OaBpu>().HasKey(item => new {item.IdBpu });
            modelBuilder.Entity<OaBpu>().Property(item => item.IdBpu).IsRequired();
            modelBuilder.Entity<OaBpu>().Property(item => item.IdBpu).HasColumnName("ID_BPU");
            modelBuilder.Entity<OaBpu>().Property(item => item.CdTravauxOaCode).IsRequired();
            modelBuilder.Entity<OaBpu>().Property(item => item.CdTravauxOaCode).HasMaxLength(60);
            modelBuilder.Entity<OaBpu>().Property(item => item.CdTravauxOaCode).HasColumnName("CD_TRAVAUX_OA__CODE");
            modelBuilder.Entity<OaBpu>().Property(item => item.CdUniteOaUnite).HasMaxLength(12);
            modelBuilder.Entity<OaBpu>().Property(item => item.CdUniteOaUnite).HasColumnName("CD_UNITE_OA__UNITE");
            modelBuilder.Entity<OaBpu>().Property(item => item.Techn).IsRequired();
            modelBuilder.Entity<OaBpu>().Property(item => item.Techn).HasMaxLength(255);
            modelBuilder.Entity<OaBpu>().Property(item => item.Techn).HasColumnName("TECHN");
            modelBuilder.Entity<OaBpu>().Property(item => item.Prix).IsRequired();
            modelBuilder.Entity<OaBpu>().Property(item => item.Prix).HasColumnName("PRIX");
            modelBuilder.Entity<OaBpu>().Property(item => item.DateMaj).HasColumnName("DATE_MAJ");
            modelBuilder.Entity<OaBpu>().Property(item => item.Freq).HasColumnName("FREQ");
            modelBuilder.Entity<OaBpu>().Property(item => item.PrecoVst).HasColumnName("PRECO_VST");
            modelBuilder.Entity<OaBpu>().Property(item => item.RealisVst).HasColumnName("REALIS_VST");
            modelBuilder.Entity<OaCdTravaux>().ToTable("CD_TRAVAUX_OA","OA");
            modelBuilder.Entity<OaCdTravaux>().HasKey(item => new {item.Code });
            modelBuilder.Entity<OaCdTravaux>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<OaCdTravaux>().Property(item => item.Code).HasMaxLength(60);
            modelBuilder.Entity<OaCdTravaux>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<OaCdTech>().ToTable("CD_TECH_OA","OA");
            modelBuilder.Entity<OaCdTech>().HasKey(item => new {item.Technique });
            modelBuilder.Entity<OaCdTech>().Property(item => item.Technique).IsRequired();
            modelBuilder.Entity<OaCdTech>().Property(item => item.Technique).HasMaxLength(12);
            modelBuilder.Entity<OaCdTech>().Property(item => item.Technique).HasColumnName("TECHNIQUE");
            modelBuilder.Entity<OaCdTech>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<OaCdTech>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<OaCdTech>().Property(item => item.Garantie).HasColumnName("GARANTIE");
            modelBuilder.Entity<OaCdTech>().Property(item => item.Dvt).HasColumnName("DVT");
            modelBuilder.Entity<OaCdOrigin>().ToTable("CD_ORIGIN_OA","OA");
            modelBuilder.Entity<OaCdOrigin>().HasKey(item => new {item.Origine });
            modelBuilder.Entity<OaCdOrigin>().Property(item => item.Origine).IsRequired();
            modelBuilder.Entity<OaCdOrigin>().Property(item => item.Origine).HasMaxLength(20);
            modelBuilder.Entity<OaCdOrigin>().Property(item => item.Origine).HasColumnName("ORIGINE");
            modelBuilder.Entity<OaHistoNote>().ToTable("HISTO_NOTE_OA","OA");
            modelBuilder.Entity<OaHistoNote>().HasKey(item => new {item.DscOaNumOa,item.DateNote });
            modelBuilder.Entity<OaHistoNote>().Property(item => item.DscOaNumOa).IsRequired();
            modelBuilder.Entity<OaHistoNote>().Property(item => item.DscOaNumOa).HasMaxLength(20);
            modelBuilder.Entity<OaHistoNote>().Property(item => item.DscOaNumOa).HasColumnName("DSC_OA__NUM_OA");
            modelBuilder.Entity<OaHistoNote>().Property(item => item.DateNote).IsRequired();
            modelBuilder.Entity<OaHistoNote>().Property(item => item.DateNote).HasColumnName("DATE_NOTE");
            modelBuilder.Entity<OaHistoNote>().Property(item => item.CdOriginOaOrigine).IsRequired();
            modelBuilder.Entity<OaHistoNote>().Property(item => item.CdOriginOaOrigine).HasMaxLength(20);
            modelBuilder.Entity<OaHistoNote>().Property(item => item.CdOriginOaOrigine).HasColumnName("CD_ORIGIN_OA__ORIGINE");
            modelBuilder.Entity<OaHistoNote>().Property(item => item.NoteIqoa).HasMaxLength(3);
            modelBuilder.Entity<OaHistoNote>().Property(item => item.NoteIqoa).HasColumnName("NOTE_IQOA");
            modelBuilder.Entity<OaHistoNote>().Property(item => item.Note1).HasColumnName("NOTE1");
            modelBuilder.Entity<OaHistoNote>().Property(item => item.Note2).HasColumnName("NOTE2");
            modelBuilder.Entity<OaHistoNote>().Property(item => item.Note3).HasColumnName("NOTE3");
            modelBuilder.Entity<OaHistoNote>().Property(item => item.Urgence).HasMaxLength(5);
            modelBuilder.Entity<OaHistoNote>().Property(item => item.Urgence).HasColumnName("URGENCE");
            modelBuilder.Entity<OaHistoNote>().Property(item => item.Securite).HasColumnName("SECURITE");
            modelBuilder.Entity<OaHistoNote>().Property(item => item.Prioritaire).IsRequired();
            modelBuilder.Entity<OaHistoNote>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<OaCdEvt>().ToTable("CD_EVT_OA","OA");
            modelBuilder.Entity<OaCdEvt>().HasKey(item => new {item.Type });
            modelBuilder.Entity<OaCdEvt>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<OaCdEvt>().Property(item => item.Type).HasMaxLength(25);
            modelBuilder.Entity<OaCdEvt>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<OaCdEvt>().Property(item => item.Impact).HasColumnName("IMPACT");
            modelBuilder.Entity<OaEvt>().ToTable("EVT_OA","OA");
            modelBuilder.Entity<OaEvt>().HasKey(item => new {item.CdEvtOaType,item.DscOaNumOa,item.DateRel });
            modelBuilder.Entity<OaEvt>().Property(item => item.CdEvtOaType).IsRequired();
            modelBuilder.Entity<OaEvt>().Property(item => item.CdEvtOaType).HasMaxLength(25);
            modelBuilder.Entity<OaEvt>().Property(item => item.CdEvtOaType).HasColumnName("CD_EVT_OA__TYPE");
            modelBuilder.Entity<OaEvt>().Property(item => item.DscOaNumOa).IsRequired();
            modelBuilder.Entity<OaEvt>().Property(item => item.DscOaNumOa).HasMaxLength(20);
            modelBuilder.Entity<OaEvt>().Property(item => item.DscOaNumOa).HasColumnName("DSC_OA__NUM_OA");
            modelBuilder.Entity<OaEvt>().Property(item => item.DateRel).IsRequired();
            modelBuilder.Entity<OaEvt>().Property(item => item.DateRel).HasColumnName("DATE_REL");
            modelBuilder.Entity<OaEvt>().Property(item => item.DateTrt).HasColumnName("DATE_TRT");
            modelBuilder.Entity<OaEvt>().Property(item => item.Obsv).HasMaxLength(255);
            modelBuilder.Entity<OaEvt>().Property(item => item.Obsv).HasColumnName("OBSV");
            modelBuilder.Entity<OaPrevision>().ToTable("PREVISION_OA","OA");
            modelBuilder.Entity<OaPrevision>().HasKey(item => new {item.DscOaNumOa,item.BpuOaIdBpu,item.DateDebut });
            modelBuilder.Entity<OaPrevision>().Property(item => item.DscOaNumOa).IsRequired();
            modelBuilder.Entity<OaPrevision>().Property(item => item.DscOaNumOa).HasMaxLength(20);
            modelBuilder.Entity<OaPrevision>().Property(item => item.DscOaNumOa).HasColumnName("DSC_OA__NUM_OA");
            modelBuilder.Entity<OaPrevision>().Property(item => item.BpuOaIdBpu).IsRequired();
            modelBuilder.Entity<OaPrevision>().Property(item => item.BpuOaIdBpu).HasColumnName("BPU_OA__ID_BPU");
            modelBuilder.Entity<OaPrevision>().Property(item => item.DateDebut).IsRequired();
            modelBuilder.Entity<OaPrevision>().Property(item => item.DateDebut).HasColumnName("DATE_DEBUT");
            modelBuilder.Entity<OaPrevision>().Property(item => item.CdContrainteOaType).HasMaxLength(100);
            modelBuilder.Entity<OaPrevision>().Property(item => item.CdContrainteOaType).HasColumnName("CD_CONTRAINTE_OA__TYPE");
            modelBuilder.Entity<OaPrevision>().Property(item => item.DateFin).HasColumnName("DATE_FIN");
            modelBuilder.Entity<OaPrevision>().Property(item => item.Montant).HasColumnName("MONTANT");
            modelBuilder.Entity<OaPrevision>().Property(item => item.DateDemPub).HasColumnName("DATE_DEM_PUB");
            modelBuilder.Entity<OaPrevision>().Property(item => item.Commentaire).HasMaxLength(255);
            modelBuilder.Entity<OaPrevision>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<OaPrevision>().Property(item => item.Realise).HasColumnName("REALISE");
            modelBuilder.Entity<OaCdContrainte>().ToTable("CD_CONTRAINTE_OA","OA");
            modelBuilder.Entity<OaCdContrainte>().HasKey(item => new {item.Type });
            modelBuilder.Entity<OaCdContrainte>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<OaCdContrainte>().Property(item => item.Type).HasMaxLength(100);
            modelBuilder.Entity<OaCdContrainte>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<OaSeuilUrgence>().ToTable("SEUIL_URGENCE_OA","OA");
            modelBuilder.Entity<OaSeuilUrgence>().HasKey(item => new {item.Ordre });
            modelBuilder.Entity<OaSeuilUrgence>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<OaSeuilUrgence>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<OaSeuilUrgence>().Property(item => item.NbrNote).HasColumnName("NBR_NOTE");
            modelBuilder.Entity<OaSeuilUrgence>().Property(item => item.ValNote).HasColumnName("VAL_NOTE");
            modelBuilder.Entity<OaSeuilUrgence>().Property(item => item.Indice).HasColumnName("INDICE");
            modelBuilder.Entity<OaDictionnaire>().ToTable("DICTIONNAIRE_OA","OA");
            modelBuilder.Entity<OaDictionnaire>().HasKey(item => new {item.Nom });
            modelBuilder.Entity<OaDictionnaire>().Property(item => item.Nom).IsRequired();
            modelBuilder.Entity<OaDictionnaire>().Property(item => item.Nom).HasMaxLength(100);
            modelBuilder.Entity<OaDictionnaire>().Property(item => item.Nom).HasColumnName("NOM");
            modelBuilder.Entity<OaDictionnaire>().Property(item => item.Description).HasMaxLength(255);
            modelBuilder.Entity<OaDictionnaire>().Property(item => item.Description).HasColumnName("DESCRIPTION");
            modelBuilder.Entity<OaDictionnaire>().Property(item => item.Definition).HasMaxLength(1000);
            modelBuilder.Entity<OaDictionnaire>().Property(item => item.Definition).HasColumnName("DEFINITION");
            modelBuilder.Entity<OaDictionnaire>().Property(item => item.Motscles).HasMaxLength(255);
            modelBuilder.Entity<OaDictionnaire>().Property(item => item.Motscles).HasColumnName("MOTSCLES");
            modelBuilder.Entity<OaPhotoInsp>().ToTable("PHOTO_INSP_OA","OA");
            modelBuilder.Entity<OaPhotoInsp>().HasKey(item => new {item.Id });
            modelBuilder.Entity<OaPhotoInsp>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<OaPhotoInsp>().Property(item => item.Id).HasMaxLength(30);
            modelBuilder.Entity<OaPhotoInsp>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<OaPhotoInsp>().Property(item => item.DscOaNumOa).IsRequired();
            modelBuilder.Entity<OaPhotoInsp>().Property(item => item.DscOaNumOa).HasMaxLength(20);
            modelBuilder.Entity<OaPhotoInsp>().Property(item => item.DscOaNumOa).HasColumnName("DSC_OA__NUM_OA");
            modelBuilder.Entity<OaPhotoInsp>().Property(item => item.CampOaIdCamp).IsRequired();
            modelBuilder.Entity<OaPhotoInsp>().Property(item => item.CampOaIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OaPhotoInsp>().Property(item => item.CampOaIdCamp).HasColumnName("CAMP_OA__ID_CAMP");
            modelBuilder.Entity<OaPhotoInsp>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<OaPhotoInsp>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<OaCdEtude>().ToTable("CD_ETUDE_OA","OA");
            modelBuilder.Entity<OaCdEtude>().HasKey(item => new {item.Etude });
            modelBuilder.Entity<OaCdEtude>().Property(item => item.Etude).IsRequired();
            modelBuilder.Entity<OaCdEtude>().Property(item => item.Etude).HasMaxLength(60);
            modelBuilder.Entity<OaCdEtude>().Property(item => item.Etude).HasColumnName("ETUDE");
            modelBuilder.Entity<OaCdTypePv>().ToTable("CD_TYPE_PV_OA","OA");
            modelBuilder.Entity<OaCdTypePv>().HasKey(item => new {item.Code });
            modelBuilder.Entity<OaCdTypePv>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<OaCdTypePv>().Property(item => item.Code).HasMaxLength(15);
            modelBuilder.Entity<OaCdTypePv>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<OaCdTypePv>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<OaCdTypePv>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<OaCdTypePv>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<OaCdTypePv>().Property(item => item.Cycle).HasColumnName("CYCLE");
            modelBuilder.Entity<OaCdTypePv>().Property(item => item.Cout).HasColumnName("COUT");
            modelBuilder.Entity<OaCdQualite>().ToTable("CD_QUALITE_OA","OA");
            modelBuilder.Entity<OaCdQualite>().HasKey(item => new {item.CdIqoaOaNoteIqoa,item.Qualite });
            modelBuilder.Entity<OaCdQualite>().Property(item => item.CdIqoaOaNoteIqoa).IsRequired();
            modelBuilder.Entity<OaCdQualite>().Property(item => item.CdIqoaOaNoteIqoa).HasMaxLength(3);
            modelBuilder.Entity<OaCdQualite>().Property(item => item.CdIqoaOaNoteIqoa).HasColumnName("CD_IQOA_OA__NOTE_IQOA");
            modelBuilder.Entity<OaCdQualite>().Property(item => item.Qualite).IsRequired();
            modelBuilder.Entity<OaCdQualite>().Property(item => item.Qualite).HasMaxLength(25);
            modelBuilder.Entity<OaCdQualite>().Property(item => item.Qualite).HasColumnName("QUALITE");
            modelBuilder.Entity<OaPhotoVst>().ToTable("PHOTO_VST_OA","OA");
            modelBuilder.Entity<OaPhotoVst>().HasKey(item => new {item.Id });
            modelBuilder.Entity<OaPhotoVst>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<OaPhotoVst>().Property(item => item.Id).HasMaxLength(30);
            modelBuilder.Entity<OaPhotoVst>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<OaPhotoVst>().Property(item => item.DscOaNumOa).IsRequired();
            modelBuilder.Entity<OaPhotoVst>().Property(item => item.DscOaNumOa).HasMaxLength(20);
            modelBuilder.Entity<OaPhotoVst>().Property(item => item.DscOaNumOa).HasColumnName("DSC_OA__NUM_OA");
            modelBuilder.Entity<OaPhotoVst>().Property(item => item.CampOaIdCamp).IsRequired();
            modelBuilder.Entity<OaPhotoVst>().Property(item => item.CampOaIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OaPhotoVst>().Property(item => item.CampOaIdCamp).HasColumnName("CAMP_OA__ID_CAMP");
            modelBuilder.Entity<OaPhotoVst>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<OaPhotoVst>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<OaSprtVst>().ToTable("SPRT_VST_OA","OA");
            modelBuilder.Entity<OaSprtVst>().HasKey(item => new {item.DscOaNumOa,item.CampOaIdCamp,item.CdChapitreOaIdChap,item.CdLigneOaIdLigne });
            modelBuilder.Entity<OaSprtVst>().Property(item => item.DscOaNumOa).IsRequired();
            modelBuilder.Entity<OaSprtVst>().Property(item => item.DscOaNumOa).HasMaxLength(20);
            modelBuilder.Entity<OaSprtVst>().Property(item => item.DscOaNumOa).HasColumnName("DSC_OA__NUM_OA");
            modelBuilder.Entity<OaSprtVst>().Property(item => item.CampOaIdCamp).IsRequired();
            modelBuilder.Entity<OaSprtVst>().Property(item => item.CampOaIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OaSprtVst>().Property(item => item.CampOaIdCamp).HasColumnName("CAMP_OA__ID_CAMP");
            modelBuilder.Entity<OaSprtVst>().Property(item => item.CdChapitreOaIdChap).IsRequired();
            modelBuilder.Entity<OaSprtVst>().Property(item => item.CdChapitreOaIdChap).HasColumnName("CD_CHAPITRE_OA__ID_CHAP");
            modelBuilder.Entity<OaSprtVst>().Property(item => item.CdLigneOaIdLigne).IsRequired();
            modelBuilder.Entity<OaSprtVst>().Property(item => item.CdLigneOaIdLigne).HasColumnName("CD_LIGNE_OA__ID_LIGNE");
            modelBuilder.Entity<OaSprtVst>().Property(item => item.Indice).IsRequired();
            modelBuilder.Entity<OaSprtVst>().Property(item => item.Indice).HasColumnName("INDICE");
            modelBuilder.Entity<OaSprtVst>().Property(item => item.Obs).HasMaxLength(500);
            modelBuilder.Entity<OaSprtVst>().Property(item => item.Obs).HasColumnName("OBS");
            modelBuilder.Entity<OaPhotoSprtVst>().ToTable("PHOTO_SPRT_VST_OA","OA");
            modelBuilder.Entity<OaPhotoSprtVst>().HasKey(item => new {item.DscOaNumOa,item.CampOaIdCamp,item.CdChapitreOaIdChap,item.CdLigneOaIdLigne,item.Id });
            modelBuilder.Entity<OaPhotoSprtVst>().Property(item => item.DscOaNumOa).IsRequired();
            modelBuilder.Entity<OaPhotoSprtVst>().Property(item => item.DscOaNumOa).HasMaxLength(20);
            modelBuilder.Entity<OaPhotoSprtVst>().Property(item => item.DscOaNumOa).HasColumnName("DSC_OA__NUM_OA");
            modelBuilder.Entity<OaPhotoSprtVst>().Property(item => item.CampOaIdCamp).IsRequired();
            modelBuilder.Entity<OaPhotoSprtVst>().Property(item => item.CampOaIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OaPhotoSprtVst>().Property(item => item.CampOaIdCamp).HasColumnName("CAMP_OA__ID_CAMP");
            modelBuilder.Entity<OaPhotoSprtVst>().Property(item => item.CdChapitreOaIdChap).IsRequired();
            modelBuilder.Entity<OaPhotoSprtVst>().Property(item => item.CdChapitreOaIdChap).HasColumnName("CD_CHAPITRE_OA__ID_CHAP");
            modelBuilder.Entity<OaPhotoSprtVst>().Property(item => item.CdLigneOaIdLigne).IsRequired();
            modelBuilder.Entity<OaPhotoSprtVst>().Property(item => item.CdLigneOaIdLigne).HasColumnName("CD_LIGNE_OA__ID_LIGNE");
            modelBuilder.Entity<OaPhotoSprtVst>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<OaPhotoSprtVst>().Property(item => item.Id).HasMaxLength(50);
            modelBuilder.Entity<OaPhotoSprtVst>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<OaPhotoSprtVst>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<OaPhotoSprtVst>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<OaVst>().ToTable("VST_OA","OA");
            modelBuilder.Entity<OaVst>().HasKey(item => new {item.DscOaNumOa,item.CampOaIdCamp });
            modelBuilder.Entity<OaVst>().Property(item => item.DscOaNumOa).IsRequired();
            modelBuilder.Entity<OaVst>().Property(item => item.DscOaNumOa).HasMaxLength(20);
            modelBuilder.Entity<OaVst>().Property(item => item.DscOaNumOa).HasColumnName("DSC_OA__NUM_OA");
            modelBuilder.Entity<OaVst>().Property(item => item.CampOaIdCamp).IsRequired();
            modelBuilder.Entity<OaVst>().Property(item => item.CampOaIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OaVst>().Property(item => item.CampOaIdCamp).HasColumnName("CAMP_OA__ID_CAMP");
            modelBuilder.Entity<OaVst>().Property(item => item.InspecteurOaNom).HasMaxLength(60);
            modelBuilder.Entity<OaVst>().Property(item => item.InspecteurOaNom).HasColumnName("INSPECTEUR_OA__NOM");
            modelBuilder.Entity<OaVst>().Property(item => item.Etat).IsRequired();
            modelBuilder.Entity<OaVst>().Property(item => item.Etat).HasMaxLength(25);
            modelBuilder.Entity<OaVst>().Property(item => item.Etat).HasColumnName("ETAT");
            modelBuilder.Entity<OaVst>().Property(item => item.Datev).HasColumnName("DATEV");
            modelBuilder.Entity<OaVst>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<OaVst>().Property(item => item.Observ).HasMaxLength(500);
            modelBuilder.Entity<OaVst>().Property(item => item.Observ).HasColumnName("OBSERV");
            modelBuilder.Entity<OaVst>().Property(item => item.NoteVst).HasMaxLength(5);
            modelBuilder.Entity<OaVst>().Property(item => item.NoteVst).HasColumnName("NOTE_VST");
            modelBuilder.Entity<OaCdHierarchie>().ToTable("CD_HIERARCHIE_OA","OA");
            modelBuilder.Entity<OaCdHierarchie>().HasKey(item => new {item.Hierarchie });
            modelBuilder.Entity<OaCdHierarchie>().Property(item => item.Hierarchie).IsRequired();
            modelBuilder.Entity<OaCdHierarchie>().Property(item => item.Hierarchie).HasMaxLength(60);
            modelBuilder.Entity<OaCdHierarchie>().Property(item => item.Hierarchie).HasColumnName("HIERARCHIE");
            modelBuilder.Entity<OaCdEntete>().ToTable("CD_ENTETE_OA","OA");
            modelBuilder.Entity<OaCdEntete>().HasKey(item => new {item.IdEntete });
            modelBuilder.Entity<OaCdEntete>().Property(item => item.IdEntete).IsRequired();
            modelBuilder.Entity<OaCdEntete>().Property(item => item.IdEntete).HasColumnName("ID_ENTETE");
            modelBuilder.Entity<OaCdEntete>().Property(item => item.CdComposantOaTypeComp).IsRequired();
            modelBuilder.Entity<OaCdEntete>().Property(item => item.CdComposantOaTypeComp).HasMaxLength(6);
            modelBuilder.Entity<OaCdEntete>().Property(item => item.CdComposantOaTypeComp).HasColumnName("CD_COMPOSANT_OA__TYPE_COMP");
            modelBuilder.Entity<OaCdEntete>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<OaCdEntete>().Property(item => item.Libelle).HasMaxLength(500);
            modelBuilder.Entity<OaCdEntete>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<OaCdEntete>().Property(item => item.OrdreEnt).IsRequired();
            modelBuilder.Entity<OaCdEntete>().Property(item => item.OrdreEnt).HasColumnName("ORDRE_ENT");
            modelBuilder.Entity<OaCdEntete>().Property(item => item.Guide).HasMaxLength(500);
            modelBuilder.Entity<OaCdEntete>().Property(item => item.Guide).HasColumnName("GUIDE");
            modelBuilder.Entity<OaCdChapitre>().ToTable("CD_CHAPITRE_OA","OA");
            modelBuilder.Entity<OaCdChapitre>().HasKey(item => new {item.IdChap });
            modelBuilder.Entity<OaCdChapitre>().Property(item => item.IdChap).IsRequired();
            modelBuilder.Entity<OaCdChapitre>().Property(item => item.IdChap).HasColumnName("ID_CHAP");
            modelBuilder.Entity<OaCdChapitre>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<OaCdChapitre>().Property(item => item.Libelle).HasMaxLength(500);
            modelBuilder.Entity<OaCdChapitre>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<OaCdChapitre>().Property(item => item.OrdreChap).IsRequired();
            modelBuilder.Entity<OaCdChapitre>().Property(item => item.OrdreChap).HasColumnName("ORDRE_CHAP");
            modelBuilder.Entity<OaCdChapitre>().Property(item => item.Ponderation).HasColumnName("PONDERATION");
            modelBuilder.Entity<OaCdLigne>().ToTable("CD_LIGNE_OA","OA");
            modelBuilder.Entity<OaCdLigne>().HasKey(item => new {item.CdChapitreOaIdChap,item.IdLigne });
            modelBuilder.Entity<OaCdLigne>().Property(item => item.CdChapitreOaIdChap).IsRequired();
            modelBuilder.Entity<OaCdLigne>().Property(item => item.CdChapitreOaIdChap).HasColumnName("CD_CHAPITRE_OA__ID_CHAP");
            modelBuilder.Entity<OaCdLigne>().Property(item => item.IdLigne).IsRequired();
            modelBuilder.Entity<OaCdLigne>().Property(item => item.IdLigne).HasColumnName("ID_LIGNE");
            modelBuilder.Entity<OaCdLigne>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<OaCdLigne>().Property(item => item.Libelle).HasMaxLength(500);
            modelBuilder.Entity<OaCdLigne>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<OaCdLigne>().Property(item => item.OrdreLigne).IsRequired();
            modelBuilder.Entity<OaCdLigne>().Property(item => item.OrdreLigne).HasColumnName("ORDRE_LIGNE");
            modelBuilder.Entity<OaEntete>().ToTable("ENTETE_OA","OA");
            modelBuilder.Entity<OaEntete>().HasKey(item => new {item.DscOaNumOa,item.CampOaIdCamp,item.CdEnteteOaIdEntete });
            modelBuilder.Entity<OaEntete>().Property(item => item.DscOaNumOa).IsRequired();
            modelBuilder.Entity<OaEntete>().Property(item => item.DscOaNumOa).HasMaxLength(20);
            modelBuilder.Entity<OaEntete>().Property(item => item.DscOaNumOa).HasColumnName("DSC_OA__NUM_OA");
            modelBuilder.Entity<OaEntete>().Property(item => item.CampOaIdCamp).IsRequired();
            modelBuilder.Entity<OaEntete>().Property(item => item.CampOaIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OaEntete>().Property(item => item.CampOaIdCamp).HasColumnName("CAMP_OA__ID_CAMP");
            modelBuilder.Entity<OaEntete>().Property(item => item.CdEnteteOaIdEntete).IsRequired();
            modelBuilder.Entity<OaEntete>().Property(item => item.CdEnteteOaIdEntete).HasColumnName("CD_ENTETE_OA__ID_ENTETE");
            modelBuilder.Entity<OaEntete>().Property(item => item.Valeur).HasMaxLength(250);
            modelBuilder.Entity<OaEntete>().Property(item => item.Valeur).HasColumnName("VALEUR");
            modelBuilder.Entity<OaContact>().ToTable("CONTACT_OA","OA");
            modelBuilder.Entity<OaContact>().HasKey(item => new {item.DocOaId });
            modelBuilder.Entity<OaContact>().Property(item => item.DocOaId).IsRequired();
            modelBuilder.Entity<OaContact>().Property(item => item.DocOaId).HasColumnName("DOC_OA__ID");
            modelBuilder.Entity<OaContact>().Property(item => item.Givenname).HasMaxLength(60);
            modelBuilder.Entity<OaContact>().Property(item => item.Givenname).HasColumnName("GIVENNAME");
            modelBuilder.Entity<OaContact>().Property(item => item.Sn).HasMaxLength(60);
            modelBuilder.Entity<OaContact>().Property(item => item.Sn).HasColumnName("SN");
            modelBuilder.Entity<OaContact>().Property(item => item.Cn).HasMaxLength(125);
            modelBuilder.Entity<OaContact>().Property(item => item.Cn).HasColumnName("CN");
            modelBuilder.Entity<OaContact>().Property(item => item.O).HasMaxLength(60);
            modelBuilder.Entity<OaContact>().Property(item => item.O).HasColumnName("O");
            modelBuilder.Entity<OaContact>().Property(item => item.Mail).HasMaxLength(60);
            modelBuilder.Entity<OaContact>().Property(item => item.Mail).HasColumnName("MAIL");
            modelBuilder.Entity<OaContact>().Property(item => item.Telephonenumber).HasMaxLength(20);
            modelBuilder.Entity<OaContact>().Property(item => item.Telephonenumber).HasColumnName("TELEPHONENUMBER");
            modelBuilder.Entity<OaContact>().Property(item => item.Mobile).HasMaxLength(20);
            modelBuilder.Entity<OaContact>().Property(item => item.Mobile).HasColumnName("MOBILE");
            modelBuilder.Entity<OaContact>().Property(item => item.Facsimiletelephonenumber).HasMaxLength(20);
            modelBuilder.Entity<OaContact>().Property(item => item.Facsimiletelephonenumber).HasColumnName("FACSIMILETELEPHONENUMBER");
            modelBuilder.Entity<OaContact>().Property(item => item.Street).HasMaxLength(60);
            modelBuilder.Entity<OaContact>().Property(item => item.Street).HasColumnName("STREET");
            modelBuilder.Entity<OaContact>().Property(item => item.Mozillaworkstreet2).HasMaxLength(60);
            modelBuilder.Entity<OaContact>().Property(item => item.Mozillaworkstreet2).HasColumnName("MOZILLAWORKSTREET2");
            modelBuilder.Entity<OaContact>().Property(item => item.L).HasMaxLength(60);
            modelBuilder.Entity<OaContact>().Property(item => item.L).HasColumnName("L");
            modelBuilder.Entity<OaContact>().Property(item => item.Postalcode).HasMaxLength(12);
            modelBuilder.Entity<OaContact>().Property(item => item.Postalcode).HasColumnName("POSTALCODE");
            modelBuilder.Entity<OaContact>().Property(item => item.Modifytimestamp).HasColumnName("MODIFYTIMESTAMP");
            modelBuilder.Entity<OaInspecteur>().ToTable("INSPECTEUR_OA","OA");
            modelBuilder.Entity<OaInspecteur>().HasKey(item => new {item.Nom });
            modelBuilder.Entity<OaInspecteur>().Property(item => item.Nom).IsRequired();
            modelBuilder.Entity<OaInspecteur>().Property(item => item.Nom).HasMaxLength(60);
            modelBuilder.Entity<OaInspecteur>().Property(item => item.Nom).HasColumnName("NOM");
            modelBuilder.Entity<OaInspecteur>().Property(item => item.CdPrestaOaPrestataire).IsRequired();
            modelBuilder.Entity<OaInspecteur>().Property(item => item.CdPrestaOaPrestataire).HasMaxLength(50);
            modelBuilder.Entity<OaInspecteur>().Property(item => item.CdPrestaOaPrestataire).HasColumnName("CD_PRESTA_OA__PRESTATAIRE");
            modelBuilder.Entity<OaInspecteur>().Property(item => item.Fonc).HasMaxLength(60);
            modelBuilder.Entity<OaInspecteur>().Property(item => item.Fonc).HasColumnName("FONC");
            modelBuilder.Entity<OaCdUnite>().ToTable("CD_UNITE_OA","OA");
            modelBuilder.Entity<OaCdUnite>().HasKey(item => new {item.Unite });
            modelBuilder.Entity<OaCdUnite>().Property(item => item.Unite).IsRequired();
            modelBuilder.Entity<OaCdUnite>().Property(item => item.Unite).HasMaxLength(12);
            modelBuilder.Entity<OaCdUnite>().Property(item => item.Unite).HasColumnName("UNITE");
            modelBuilder.Entity<OaCdComposant>().ToTable("CD_COMPOSANT_OA","OA");
            modelBuilder.Entity<OaCdComposant>().HasKey(item => new {item.TypeComp });
            modelBuilder.Entity<OaCdComposant>().Property(item => item.TypeComp).IsRequired();
            modelBuilder.Entity<OaCdComposant>().Property(item => item.TypeComp).HasMaxLength(6);
            modelBuilder.Entity<OaCdComposant>().Property(item => item.TypeComp).HasColumnName("TYPE_COMP");
            modelBuilder.Entity<OaCdComposant>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<OaCdComposant>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<OaCdConclusion>().ToTable("CD_CONCLUSION_OA","OA");
            modelBuilder.Entity<OaCdConclusion>().HasKey(item => new {item.IdConc });
            modelBuilder.Entity<OaCdConclusion>().Property(item => item.IdConc).IsRequired();
            modelBuilder.Entity<OaCdConclusion>().Property(item => item.IdConc).HasColumnName("ID_CONC");
            modelBuilder.Entity<OaCdConclusion>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<OaCdConclusion>().Property(item => item.Libelle).HasMaxLength(500);
            modelBuilder.Entity<OaCdConclusion>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<OaCdConclusion>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<OaCdConclusion>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<OaDscTemp>().ToTable("DSC_TEMP_OA","OA");
            modelBuilder.Entity<OaDscTemp>().HasKey(item => new {item.CampOaIdCamp,item.NumOa });
            modelBuilder.Entity<OaDscTemp>().Property(item => item.CampOaIdCamp).IsRequired();
            modelBuilder.Entity<OaDscTemp>().Property(item => item.CampOaIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OaDscTemp>().Property(item => item.CampOaIdCamp).HasColumnName("CAMP_OA__ID_CAMP");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.NumOa).IsRequired();
            modelBuilder.Entity<OaDscTemp>().Property(item => item.NumOa).HasMaxLength(20);
            modelBuilder.Entity<OaDscTemp>().Property(item => item.NumOa).HasColumnName("NUM_OA");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.CdBeOaBureau).HasMaxLength(60);
            modelBuilder.Entity<OaDscTemp>().Property(item => item.CdBeOaBureau).HasColumnName("CD_BE_OA__BUREAU");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.CdGestOaGestionnaire).HasMaxLength(60);
            modelBuilder.Entity<OaDscTemp>().Property(item => item.CdGestOaGestionnaire).HasColumnName("CD_GEST_OA__GESTIONNAIRE");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.CdChargeOaSurcharge).HasMaxLength(60);
            modelBuilder.Entity<OaDscTemp>().Property(item => item.CdChargeOaSurcharge).HasColumnName("CD_CHARGE_OA__SURCHARGE");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.CdTypeOaType).IsRequired();
            modelBuilder.Entity<OaDscTemp>().Property(item => item.CdTypeOaType).HasMaxLength(20);
            modelBuilder.Entity<OaDscTemp>().Property(item => item.CdTypeOaType).HasColumnName("CD_TYPE_OA__TYPE");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.DscOaNumOa).HasMaxLength(20);
            modelBuilder.Entity<OaDscTemp>().Property(item => item.DscOaNumOa).HasColumnName("DSC_OA__NUM_OA");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.CdEntpOaEntreprise).HasMaxLength(60);
            modelBuilder.Entity<OaDscTemp>().Property(item => item.CdEntpOaEntreprise).HasColumnName("CD_ENTP_OA__ENTREPRISE");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.CdTablierOaTablier).HasMaxLength(60);
            modelBuilder.Entity<OaDscTemp>().Property(item => item.CdTablierOaTablier).HasColumnName("CD_TABLIER_OA__TABLIER");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.CdFondOaType).HasMaxLength(60);
            modelBuilder.Entity<OaDscTemp>().Property(item => item.CdFondOaType).HasColumnName("CD_FOND_OA__TYPE");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.CdMatOaMateriaux).HasMaxLength(60);
            modelBuilder.Entity<OaDscTemp>().Property(item => item.CdMatOaMateriaux).HasColumnName("CD_MAT_OA__MATERIAUX");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.CdMoOaMaitreOuvr).HasMaxLength(60);
            modelBuilder.Entity<OaDscTemp>().Property(item => item.CdMoOaMaitreOuvr).HasColumnName("CD_MO_OA__MAITRE_OUVR");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.CdFamOaFamille).IsRequired();
            modelBuilder.Entity<OaDscTemp>().Property(item => item.CdFamOaFamille).HasMaxLength(20);
            modelBuilder.Entity<OaDscTemp>().Property(item => item.CdFamOaFamille).HasColumnName("CD_FAM_OA__FAMILLE");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<OaDscTemp>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.NumExploit).HasMaxLength(30);
            modelBuilder.Entity<OaDscTemp>().Property(item => item.NumExploit).HasColumnName("NUM_EXPLOIT");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.NomUsage).HasMaxLength(255);
            modelBuilder.Entity<OaDscTemp>().Property(item => item.NomUsage).HasColumnName("NOM_USAGE");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.DateConst).HasColumnName("DATE_CONST");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Vpf).HasMaxLength(60);
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Vpf).HasColumnName("VPF");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.TraficVpf).HasColumnName("TRAFIC_VPF");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Deviation).HasColumnName("DEVIATION");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Nbpilesinter).HasColumnName("NBPILESINTER");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Travure).HasColumnName("TRAVURE");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.LongMaxTrav).HasColumnName("LONG_MAX_TRAV");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.GabMini).HasColumnName("GAB_MINI");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.GabGra).HasColumnName("GAB_GRA");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Biais).HasColumnName("BIAIS");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.LongBiaise).HasColumnName("LONG_BIAISE");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.LargTrav).HasColumnName("LARG_TRAV");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.LargBiaise).HasColumnName("LARG_BIAISE");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.LargGs).HasColumnName("LARG_GS");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.SurfTablier).HasColumnName("SURF_TABLIER");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.SurfVpf).HasColumnName("SURF_VPF");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Immerge).HasColumnName("IMMERGE");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Sismicite).HasColumnName("SISMICITE");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Dalle).HasColumnName("DALLE");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Corn).HasColumnName("CORN");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Lanterneau).HasColumnName("LANTERNEAU");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.EquipVst).HasColumnName("EQUIP_VST");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Note1).HasColumnName("NOTE1");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Note2).HasColumnName("NOTE2");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Note3).HasColumnName("NOTE3");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Urgence).HasMaxLength(5);
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Urgence).HasColumnName("URGENCE");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.DescInva).HasMaxLength(1000);
            modelBuilder.Entity<OaDscTemp>().Property(item => item.DescInva).HasColumnName("DESC_INVA");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Securite).HasColumnName("SECURITE");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.ProsurvAnnee).HasColumnName("PROSURV_ANNEE");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.DernInsp).HasColumnName("DERN_INSP");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.DernVst).HasColumnName("DERN_VST");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.NoteVst).HasMaxLength(5);
            modelBuilder.Entity<OaDscTemp>().Property(item => item.NoteVst).HasColumnName("NOTE_VST");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Archive).HasMaxLength(255);
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Archive).HasColumnName("ARCHIVE");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Commentaire).HasMaxLength(1000);
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.X1).HasColumnName("X1");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Y1).HasColumnName("Y1");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Z1).HasColumnName("Z1");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.X2).HasColumnName("X2");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Y2).HasColumnName("Y2");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Z2).HasColumnName("Z2");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.DateReleve).HasColumnName("DATE_RELEVE");
            modelBuilder.Entity<OaDscTemp>().Property(item => item.Terrain).HasColumnName("TERRAIN");
            modelBuilder.Entity<OaInspTmp>().ToTable("INSP_TMP_OA","OA");
            modelBuilder.Entity<OaInspTmp>().HasKey(item => new {item.CampOaIdCamp,item.DscTempOaNumOa });
            modelBuilder.Entity<OaInspTmp>().Property(item => item.CampOaIdCamp).IsRequired();
            modelBuilder.Entity<OaInspTmp>().Property(item => item.CampOaIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OaInspTmp>().Property(item => item.CampOaIdCamp).HasColumnName("CAMP_OA__ID_CAMP");
            modelBuilder.Entity<OaInspTmp>().Property(item => item.DscTempOaNumOa).IsRequired();
            modelBuilder.Entity<OaInspTmp>().Property(item => item.DscTempOaNumOa).HasMaxLength(20);
            modelBuilder.Entity<OaInspTmp>().Property(item => item.DscTempOaNumOa).HasColumnName("DSC_TEMP_OA__NUM_OA");
            modelBuilder.Entity<OaInspTmp>().Property(item => item.CdIqoaOaNoteIqoa).IsRequired();
            modelBuilder.Entity<OaInspTmp>().Property(item => item.CdIqoaOaNoteIqoa).HasMaxLength(3);
            modelBuilder.Entity<OaInspTmp>().Property(item => item.CdIqoaOaNoteIqoa).HasColumnName("CD_IQOA_OA__NOTE_IQOA");
            modelBuilder.Entity<OaInspTmp>().Property(item => item.CdMeteoOaMeteo).HasMaxLength(60);
            modelBuilder.Entity<OaInspTmp>().Property(item => item.CdMeteoOaMeteo).HasColumnName("CD_METEO_OA__METEO");
            modelBuilder.Entity<OaInspTmp>().Property(item => item.CdEtudeOaEtude).HasMaxLength(60);
            modelBuilder.Entity<OaInspTmp>().Property(item => item.CdEtudeOaEtude).HasColumnName("CD_ETUDE_OA__ETUDE");
            modelBuilder.Entity<OaInspTmp>().Property(item => item.InspecteurOaNom).HasMaxLength(60);
            modelBuilder.Entity<OaInspTmp>().Property(item => item.InspecteurOaNom).HasColumnName("INSPECTEUR_OA__NOM");
            modelBuilder.Entity<OaInspTmp>().Property(item => item.Etat).IsRequired();
            modelBuilder.Entity<OaInspTmp>().Property(item => item.Etat).HasMaxLength(25);
            modelBuilder.Entity<OaInspTmp>().Property(item => item.Etat).HasColumnName("ETAT");
            modelBuilder.Entity<OaInspTmp>().Property(item => item.Datev).HasColumnName("DATEV");
            modelBuilder.Entity<OaInspTmp>().Property(item => item.Temperature).HasColumnName("TEMPERATURE");
            modelBuilder.Entity<OaInspTmp>().Property(item => item.Moyen).HasMaxLength(500);
            modelBuilder.Entity<OaInspTmp>().Property(item => item.Moyen).HasColumnName("MOYEN");
            modelBuilder.Entity<OaInspTmp>().Property(item => item.Conditions).HasMaxLength(500);
            modelBuilder.Entity<OaInspTmp>().Property(item => item.Conditions).HasColumnName("CONDITIONS");
            modelBuilder.Entity<OaInspTmp>().Property(item => item.DateValid).HasColumnName("DATE_VALID");
            modelBuilder.Entity<OaInspTmp>().Property(item => item.NomValid).HasMaxLength(255);
            modelBuilder.Entity<OaInspTmp>().Property(item => item.NomValid).HasColumnName("NOM_VALID");
            modelBuilder.Entity<OaInspTmp>().Property(item => item.DescInva).HasMaxLength(1000);
            modelBuilder.Entity<OaInspTmp>().Property(item => item.DescInva).HasColumnName("DESC_INVA");
            modelBuilder.Entity<OaInspTmp>().Property(item => item.Prioritaire).HasMaxLength(1000);
            modelBuilder.Entity<OaInspTmp>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<OaInspTmp>().Property(item => item.Securite).HasMaxLength(1000);
            modelBuilder.Entity<OaInspTmp>().Property(item => item.Securite).HasColumnName("SECURITE");
            modelBuilder.Entity<OaInspTmp>().Property(item => item.Note1).HasColumnName("NOTE1");
            modelBuilder.Entity<OaInspTmp>().Property(item => item.Note2).HasColumnName("NOTE2");
            modelBuilder.Entity<OaInspTmp>().Property(item => item.Note3).HasColumnName("NOTE3");
            modelBuilder.Entity<OaInspTmp>().Property(item => item.Urgence).HasMaxLength(5);
            modelBuilder.Entity<OaInspTmp>().Property(item => item.Urgence).HasColumnName("URGENCE");
            modelBuilder.Entity<OaInspTmp>().Property(item => item.Qualite).HasMaxLength(25);
            modelBuilder.Entity<OaInspTmp>().Property(item => item.Qualite).HasColumnName("QUALITE");
            modelBuilder.Entity<OaEltInspTmp>().ToTable("ELT_INSP_TMP_OA","OA");
            modelBuilder.Entity<OaEltInspTmp>().HasKey(item => new {item.CampOaIdCamp,item.DscTempOaNumOa,item.GrpOaIdGrp,item.PrtOaIdPrt,item.SprtOaIdSprt,item.EltOaIdElem });
            modelBuilder.Entity<OaEltInspTmp>().Property(item => item.CampOaIdCamp).IsRequired();
            modelBuilder.Entity<OaEltInspTmp>().Property(item => item.CampOaIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OaEltInspTmp>().Property(item => item.CampOaIdCamp).HasColumnName("CAMP_OA__ID_CAMP");
            modelBuilder.Entity<OaEltInspTmp>().Property(item => item.DscTempOaNumOa).IsRequired();
            modelBuilder.Entity<OaEltInspTmp>().Property(item => item.DscTempOaNumOa).HasMaxLength(20);
            modelBuilder.Entity<OaEltInspTmp>().Property(item => item.DscTempOaNumOa).HasColumnName("DSC_TEMP_OA__NUM_OA");
            modelBuilder.Entity<OaEltInspTmp>().Property(item => item.GrpOaIdGrp).IsRequired();
            modelBuilder.Entity<OaEltInspTmp>().Property(item => item.GrpOaIdGrp).HasColumnName("GRP_OA__ID_GRP");
            modelBuilder.Entity<OaEltInspTmp>().Property(item => item.PrtOaIdPrt).IsRequired();
            modelBuilder.Entity<OaEltInspTmp>().Property(item => item.PrtOaIdPrt).HasColumnName("PRT_OA__ID_PRT");
            modelBuilder.Entity<OaEltInspTmp>().Property(item => item.SprtOaIdSprt).IsRequired();
            modelBuilder.Entity<OaEltInspTmp>().Property(item => item.SprtOaIdSprt).HasColumnName("SPRT_OA__ID_SPRT");
            modelBuilder.Entity<OaEltInspTmp>().Property(item => item.EltOaIdElem).IsRequired();
            modelBuilder.Entity<OaEltInspTmp>().Property(item => item.EltOaIdElem).HasColumnName("ELT_OA__ID_ELEM");
            modelBuilder.Entity<OaEltInspTmp>().Property(item => item.Indice).IsRequired();
            modelBuilder.Entity<OaEltInspTmp>().Property(item => item.Indice).HasColumnName("INDICE");
            modelBuilder.Entity<OaEltInspTmp>().Property(item => item.Obs).HasMaxLength(255);
            modelBuilder.Entity<OaEltInspTmp>().Property(item => item.Obs).HasColumnName("OBS");
            modelBuilder.Entity<OaPhotoInspTmp>().ToTable("PHOTO_INSP_TMP_OA","OA");
            modelBuilder.Entity<OaPhotoInspTmp>().HasKey(item => new {item.Id });
            modelBuilder.Entity<OaPhotoInspTmp>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<OaPhotoInspTmp>().Property(item => item.Id).HasMaxLength(30);
            modelBuilder.Entity<OaPhotoInspTmp>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<OaPhotoInspTmp>().Property(item => item.CampOaIdCamp).IsRequired();
            modelBuilder.Entity<OaPhotoInspTmp>().Property(item => item.CampOaIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OaPhotoInspTmp>().Property(item => item.CampOaIdCamp).HasColumnName("CAMP_OA__ID_CAMP");
            modelBuilder.Entity<OaPhotoInspTmp>().Property(item => item.DscTempOaNumOa).IsRequired();
            modelBuilder.Entity<OaPhotoInspTmp>().Property(item => item.DscTempOaNumOa).HasMaxLength(20);
            modelBuilder.Entity<OaPhotoInspTmp>().Property(item => item.DscTempOaNumOa).HasColumnName("DSC_TEMP_OA__NUM_OA");
            modelBuilder.Entity<OaPhotoInspTmp>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<OaPhotoInspTmp>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<OaPhotoEltInspTmp>().ToTable("PHOTO_ELT_INSP_TMP_OA","OA");
            modelBuilder.Entity<OaPhotoEltInspTmp>().HasKey(item => new {item.GrpOaIdGrp,item.PrtOaIdPrt,item.SprtOaIdSprt,item.CampOaIdCamp,item.DscTempOaNumOa,item.EltOaIdElem,item.Id });
            modelBuilder.Entity<OaPhotoEltInspTmp>().Property(item => item.GrpOaIdGrp).IsRequired();
            modelBuilder.Entity<OaPhotoEltInspTmp>().Property(item => item.GrpOaIdGrp).HasColumnName("GRP_OA__ID_GRP");
            modelBuilder.Entity<OaPhotoEltInspTmp>().Property(item => item.PrtOaIdPrt).IsRequired();
            modelBuilder.Entity<OaPhotoEltInspTmp>().Property(item => item.PrtOaIdPrt).HasColumnName("PRT_OA__ID_PRT");
            modelBuilder.Entity<OaPhotoEltInspTmp>().Property(item => item.SprtOaIdSprt).IsRequired();
            modelBuilder.Entity<OaPhotoEltInspTmp>().Property(item => item.SprtOaIdSprt).HasColumnName("SPRT_OA__ID_SPRT");
            modelBuilder.Entity<OaPhotoEltInspTmp>().Property(item => item.CampOaIdCamp).IsRequired();
            modelBuilder.Entity<OaPhotoEltInspTmp>().Property(item => item.CampOaIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OaPhotoEltInspTmp>().Property(item => item.CampOaIdCamp).HasColumnName("CAMP_OA__ID_CAMP");
            modelBuilder.Entity<OaPhotoEltInspTmp>().Property(item => item.DscTempOaNumOa).IsRequired();
            modelBuilder.Entity<OaPhotoEltInspTmp>().Property(item => item.DscTempOaNumOa).HasMaxLength(20);
            modelBuilder.Entity<OaPhotoEltInspTmp>().Property(item => item.DscTempOaNumOa).HasColumnName("DSC_TEMP_OA__NUM_OA");
            modelBuilder.Entity<OaPhotoEltInspTmp>().Property(item => item.EltOaIdElem).IsRequired();
            modelBuilder.Entity<OaPhotoEltInspTmp>().Property(item => item.EltOaIdElem).HasColumnName("ELT_OA__ID_ELEM");
            modelBuilder.Entity<OaPhotoEltInspTmp>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<OaPhotoEltInspTmp>().Property(item => item.Id).HasMaxLength(50);
            modelBuilder.Entity<OaPhotoEltInspTmp>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<OaPhotoEltInspTmp>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<OaPhotoEltInspTmp>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<OaCdOccupant>().ToTable("CD_OCCUPANT_OA","OA");
            modelBuilder.Entity<OaCdOccupant>().HasKey(item => new {item.Nom });
            modelBuilder.Entity<OaCdOccupant>().Property(item => item.Nom).IsRequired();
            modelBuilder.Entity<OaCdOccupant>().Property(item => item.Nom).HasMaxLength(60);
            modelBuilder.Entity<OaCdOccupant>().Property(item => item.Nom).HasColumnName("NOM");
            modelBuilder.Entity<OaOccupation>().ToTable("OCCUPATION_OA","OA");
            modelBuilder.Entity<OaOccupation>().HasKey(item => new {item.DscOaNumOa,item.CdOccupantOaNom,item.CdOccupOaType });
            modelBuilder.Entity<OaOccupation>().Property(item => item.DscOaNumOa).IsRequired();
            modelBuilder.Entity<OaOccupation>().Property(item => item.DscOaNumOa).HasMaxLength(20);
            modelBuilder.Entity<OaOccupation>().Property(item => item.DscOaNumOa).HasColumnName("DSC_OA__NUM_OA");
            modelBuilder.Entity<OaOccupation>().Property(item => item.CdOccupantOaNom).IsRequired();
            modelBuilder.Entity<OaOccupation>().Property(item => item.CdOccupantOaNom).HasMaxLength(60);
            modelBuilder.Entity<OaOccupation>().Property(item => item.CdOccupantOaNom).HasColumnName("CD_OCCUPANT_OA__NOM");
            modelBuilder.Entity<OaOccupation>().Property(item => item.CdOccupOaType).IsRequired();
            modelBuilder.Entity<OaOccupation>().Property(item => item.CdOccupOaType).HasMaxLength(60);
            modelBuilder.Entity<OaOccupation>().Property(item => item.CdOccupOaType).HasColumnName("CD_OCCUP_OA__TYPE");
            modelBuilder.Entity<OaOccupation>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<OaOccupation>().Property(item => item.DateFv).HasColumnName("DATE_FV");
            modelBuilder.Entity<OaOccupation>().Property(item => item.Trav).HasColumnName("TRAV");
            modelBuilder.Entity<OaOccupation>().Property(item => item.NumConv).HasMaxLength(60);
            modelBuilder.Entity<OaOccupation>().Property(item => item.NumConv).HasColumnName("NUM_CONV");
            modelBuilder.Entity<OaOccupation>().Property(item => item.Observ).HasMaxLength(255);
            modelBuilder.Entity<OaOccupation>().Property(item => item.Observ).HasColumnName("OBSERV");
            modelBuilder.Entity<OaCdOccup>().ToTable("CD_OCCUP_OA","OA");
            modelBuilder.Entity<OaCdOccup>().HasKey(item => new {item.Type });
            modelBuilder.Entity<OaCdOccup>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<OaCdOccup>().Property(item => item.Type).HasMaxLength(60);
            modelBuilder.Entity<OaCdOccup>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<OaArchive3>().ToTable("ARCHIVE_3_OA","OA");
            modelBuilder.Entity<OaArchive3>().HasKey(item => new {item.DateCalc });
            modelBuilder.Entity<OaArchive3>().Property(item => item.DateCalc).IsRequired();
            modelBuilder.Entity<OaArchive3>().Property(item => item.DateCalc).HasColumnName("DATE_CALC");
            modelBuilder.Entity<OaArchive3>().Property(item => item.Nbre).IsRequired();
            modelBuilder.Entity<OaArchive3>().Property(item => item.Nbre).HasColumnName("NBRE");
            modelBuilder.Entity<OaArchive3>().Property(item => item.Surf).IsRequired();
            modelBuilder.Entity<OaArchive3>().Property(item => item.Surf).HasColumnName("SURF");
            modelBuilder.Entity<OaArchive3>().Property(item => item.Etat3x).IsRequired();
            modelBuilder.Entity<OaArchive3>().Property(item => item.Etat3x).HasMaxLength(3);
            modelBuilder.Entity<OaArchive3>().Property(item => item.Etat3x).HasColumnName("ETAT_3X");
            modelBuilder.Entity<OaArchive3>().Property(item => item.Delai).HasColumnName("DELAI");
            modelBuilder.Entity<OaArchive3>().Property(item => item.EtatLolf).HasColumnName("ETAT_LOLF");
            modelBuilder.Entity<OaArchive3>().Property(item => item.Montant).HasColumnName("MONTANT");
            modelBuilder.Entity<OaArchive3>().Property(item => item.Obsv).HasMaxLength(255);
            modelBuilder.Entity<OaArchive3>().Property(item => item.Obsv).HasColumnName("OBSV");
            modelBuilder.Entity<OaClsDoc>().ToTable("CLS_DOC_OA","OA");
            modelBuilder.Entity<OaClsDoc>().HasKey(item => new {item.ClsOaId,item.DocOaId });
            modelBuilder.Entity<OaClsDoc>().Property(item => item.ClsOaId).IsRequired();
            modelBuilder.Entity<OaClsDoc>().Property(item => item.ClsOaId).HasColumnName("CLS_OA__ID");
            modelBuilder.Entity<OaClsDoc>().Property(item => item.DocOaId).IsRequired();
            modelBuilder.Entity<OaClsDoc>().Property(item => item.DocOaId).HasColumnName("DOC_OA__ID");
            modelBuilder.Entity<OaClsDoc>().Property(item => item.Defaut).HasColumnName("DEFAUT");
            modelBuilder.Entity<OaClsDoc>().Property(item => item.Dossier).HasMaxLength(15);
            modelBuilder.Entity<OaClsDoc>().Property(item => item.Dossier).HasColumnName("DOSSIER");
            modelBuilder.Entity<OaAppuis>().ToTable("APPUIS_OA","OA");
            modelBuilder.Entity<OaAppuis>().HasKey(item => new {item.DscOaNumOa,item.CdFamAppuiOaFamApp,item.CdAppuiOaApp,item.CdAppAppuiOaAppui });
            modelBuilder.Entity<OaAppuis>().Property(item => item.DscOaNumOa).IsRequired();
            modelBuilder.Entity<OaAppuis>().Property(item => item.DscOaNumOa).HasMaxLength(20);
            modelBuilder.Entity<OaAppuis>().Property(item => item.DscOaNumOa).HasColumnName("DSC_OA__NUM_OA");
            modelBuilder.Entity<OaAppuis>().Property(item => item.CdFamAppuiOaFamApp).IsRequired();
            modelBuilder.Entity<OaAppuis>().Property(item => item.CdFamAppuiOaFamApp).HasMaxLength(60);
            modelBuilder.Entity<OaAppuis>().Property(item => item.CdFamAppuiOaFamApp).HasColumnName("CD_FAM_APPUI_OA__FAM_APP");
            modelBuilder.Entity<OaAppuis>().Property(item => item.CdAppuiOaApp).IsRequired();
            modelBuilder.Entity<OaAppuis>().Property(item => item.CdAppuiOaApp).HasMaxLength(60);
            modelBuilder.Entity<OaAppuis>().Property(item => item.CdAppuiOaApp).HasColumnName("CD_APPUI_OA__APP");
            modelBuilder.Entity<OaAppuis>().Property(item => item.CdAppAppuiOaAppui).IsRequired();
            modelBuilder.Entity<OaAppuis>().Property(item => item.CdAppAppuiOaAppui).HasMaxLength(60);
            modelBuilder.Entity<OaAppuis>().Property(item => item.CdAppAppuiOaAppui).HasColumnName("CD_APP_APPUI_OA__APPUI");
            modelBuilder.Entity<OaAppuis>().Property(item => item.NbrAppareil).HasColumnName("NBR_APPAREIL");
            modelBuilder.Entity<OaAppuis>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<OaAppuis>().Property(item => item.Commentaire).HasMaxLength(255);
            modelBuilder.Entity<OaAppuis>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<OaDscCamp>().ToTable("DSC_CAMP_OA","OA");
            modelBuilder.Entity<OaDscCamp>().HasKey(item => new {item.DscOaNumOa,item.CampOaIdCamp });
            modelBuilder.Entity<OaDscCamp>().Property(item => item.DscOaNumOa).IsRequired();
            modelBuilder.Entity<OaDscCamp>().Property(item => item.DscOaNumOa).HasMaxLength(20);
            modelBuilder.Entity<OaDscCamp>().Property(item => item.DscOaNumOa).HasColumnName("DSC_OA__NUM_OA");
            modelBuilder.Entity<OaDscCamp>().Property(item => item.CampOaIdCamp).IsRequired();
            modelBuilder.Entity<OaDscCamp>().Property(item => item.CampOaIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OaDscCamp>().Property(item => item.CampOaIdCamp).HasColumnName("CAMP_OA__ID_CAMP");
            modelBuilder.Entity<OaDscCamp>().Property(item => item.Realiser).HasColumnName("REALISER");
            modelBuilder.Entity<OaCdPrecoSprtVst>().ToTable("CD_PRECO__SPRT_VST_OA","OA");
            modelBuilder.Entity<OaCdPrecoSprtVst>().HasKey(item => new {item.DscOaNumOa,item.CampOaIdCamp,item.BpuOaIdBpu });
            modelBuilder.Entity<OaCdPrecoSprtVst>().Property(item => item.DscOaNumOa).IsRequired();
            modelBuilder.Entity<OaCdPrecoSprtVst>().Property(item => item.DscOaNumOa).HasMaxLength(20);
            modelBuilder.Entity<OaCdPrecoSprtVst>().Property(item => item.DscOaNumOa).HasColumnName("DSC_OA__NUM_OA");
            modelBuilder.Entity<OaCdPrecoSprtVst>().Property(item => item.CampOaIdCamp).IsRequired();
            modelBuilder.Entity<OaCdPrecoSprtVst>().Property(item => item.CampOaIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OaCdPrecoSprtVst>().Property(item => item.CampOaIdCamp).HasColumnName("CAMP_OA__ID_CAMP");
            modelBuilder.Entity<OaCdPrecoSprtVst>().Property(item => item.BpuOaIdBpu).IsRequired();
            modelBuilder.Entity<OaCdPrecoSprtVst>().Property(item => item.BpuOaIdBpu).HasColumnName("BPU_OA__ID_BPU");
            modelBuilder.Entity<OaCdPrecoSprtVst>().Property(item => item.CdPrecoSprtVstOhRealise).HasColumnName("CD_PRECO__SPRT_VST_OH__REALISE");
            modelBuilder.Entity<OaCdConclusionInsp>().ToTable("CD_CONCLUSION__INSP_OA","OA");
            modelBuilder.Entity<OaCdConclusionInsp>().HasKey(item => new {item.DscOaNumOa,item.CampOaIdCamp,item.CdConclusionOaIdConc });
            modelBuilder.Entity<OaCdConclusionInsp>().Property(item => item.DscOaNumOa).IsRequired();
            modelBuilder.Entity<OaCdConclusionInsp>().Property(item => item.DscOaNumOa).HasMaxLength(20);
            modelBuilder.Entity<OaCdConclusionInsp>().Property(item => item.DscOaNumOa).HasColumnName("DSC_OA__NUM_OA");
            modelBuilder.Entity<OaCdConclusionInsp>().Property(item => item.CampOaIdCamp).IsRequired();
            modelBuilder.Entity<OaCdConclusionInsp>().Property(item => item.CampOaIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OaCdConclusionInsp>().Property(item => item.CampOaIdCamp).HasColumnName("CAMP_OA__ID_CAMP");
            modelBuilder.Entity<OaCdConclusionInsp>().Property(item => item.CdConclusionOaIdConc).IsRequired();
            modelBuilder.Entity<OaCdConclusionInsp>().Property(item => item.CdConclusionOaIdConc).HasColumnName("CD_CONCLUSION_OA__ID_CONC");
            modelBuilder.Entity<OaCdConclusionInsp>().Property(item => item.Contenu).HasMaxLength(1000);
            modelBuilder.Entity<OaCdConclusionInsp>().Property(item => item.Contenu).HasColumnName("CONTENU");
            modelBuilder.Entity<OaCdConclusionInspTmp>().ToTable("CD_CONCLUSION__INSP_TMP_OA","OA");
            modelBuilder.Entity<OaCdConclusionInspTmp>().HasKey(item => new {item.CampOaIdCamp,item.DscTempOaNumOa,item.CdConclusionOaIdConc });
            modelBuilder.Entity<OaCdConclusionInspTmp>().Property(item => item.CampOaIdCamp).IsRequired();
            modelBuilder.Entity<OaCdConclusionInspTmp>().Property(item => item.CampOaIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OaCdConclusionInspTmp>().Property(item => item.CampOaIdCamp).HasColumnName("CAMP_OA__ID_CAMP");
            modelBuilder.Entity<OaCdConclusionInspTmp>().Property(item => item.DscTempOaNumOa).IsRequired();
            modelBuilder.Entity<OaCdConclusionInspTmp>().Property(item => item.DscTempOaNumOa).HasMaxLength(20);
            modelBuilder.Entity<OaCdConclusionInspTmp>().Property(item => item.DscTempOaNumOa).HasColumnName("DSC_TEMP_OA__NUM_OA");
            modelBuilder.Entity<OaCdConclusionInspTmp>().Property(item => item.CdConclusionOaIdConc).IsRequired();
            modelBuilder.Entity<OaCdConclusionInspTmp>().Property(item => item.CdConclusionOaIdConc).HasColumnName("CD_CONCLUSION_OA__ID_CONC");
            modelBuilder.Entity<OaCdConclusionInspTmp>().Property(item => item.Contenu).HasMaxLength(1000);
            modelBuilder.Entity<OaCdConclusionInspTmp>().Property(item => item.Contenu).HasColumnName("CONTENU");
            modelBuilder.Entity<OaDscArchive3>().ToTable("DSC__ARCHIVE_3_OA","OA");
            modelBuilder.Entity<OaDscArchive3>().HasKey(item => new {item.Archive3OaDateCalc,item.DscOaNumOa });
            modelBuilder.Entity<OaDscArchive3>().Property(item => item.Archive3OaDateCalc).IsRequired();
            modelBuilder.Entity<OaDscArchive3>().Property(item => item.Archive3OaDateCalc).HasColumnName("ARCHIVE_3_OA__DATE_CALC");
            modelBuilder.Entity<OaDscArchive3>().Property(item => item.DscOaNumOa).IsRequired();
            modelBuilder.Entity<OaDscArchive3>().Property(item => item.DscOaNumOa).HasMaxLength(20);
            modelBuilder.Entity<OaDscArchive3>().Property(item => item.DscOaNumOa).HasColumnName("DSC_OA__NUM_OA");
            modelBuilder.Entity<OaDscArchive3>().Property(item => item.Note3x).IsRequired();
            modelBuilder.Entity<OaDscArchive3>().Property(item => item.Note3x).HasMaxLength(3);
            modelBuilder.Entity<OaDscArchive3>().Property(item => item.Note3x).HasColumnName("NOTE3X");
            modelBuilder.Entity<OaDscArchive3>().Property(item => item.Ecarte).HasColumnName("ECARTE");
            modelBuilder.Entity<OhCdType>().ToTable("CD_TYPE_OH","OH");
            modelBuilder.Entity<OhCdType>().HasKey(item => new {item.Type });
            modelBuilder.Entity<OhCdType>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<OhCdType>().Property(item => item.Type).HasMaxLength(60);
            modelBuilder.Entity<OhCdType>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<OhCdFam>().ToTable("CD_FAM_OH","OH");
            modelBuilder.Entity<OhCdFam>().HasKey(item => new {item.Famille });
            modelBuilder.Entity<OhCdFam>().Property(item => item.Famille).IsRequired();
            modelBuilder.Entity<OhCdFam>().Property(item => item.Famille).HasMaxLength(20);
            modelBuilder.Entity<OhCdFam>().Property(item => item.Famille).HasColumnName("FAMILLE");
            modelBuilder.Entity<OhCdFam>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<OhCdFam>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<OhCdEntp>().ToTable("CD_ENTP_OH","OH");
            modelBuilder.Entity<OhCdEntp>().HasKey(item => new {item.Entreprise });
            modelBuilder.Entity<OhCdEntp>().Property(item => item.Entreprise).IsRequired();
            modelBuilder.Entity<OhCdEntp>().Property(item => item.Entreprise).HasMaxLength(60);
            modelBuilder.Entity<OhCdEntp>().Property(item => item.Entreprise).HasColumnName("ENTREPRISE");
            modelBuilder.Entity<OhDsc>().ToTable("DSC_OH","OH");
            modelBuilder.Entity<OhDsc>().HasKey(item => new {item.NumOh });
            modelBuilder.Entity<OhDsc>().Property(item => item.NumOh).IsRequired();
            modelBuilder.Entity<OhDsc>().Property(item => item.NumOh).HasMaxLength(20);
            modelBuilder.Entity<OhDsc>().Property(item => item.NumOh).HasColumnName("NUM_OH");
            modelBuilder.Entity<OhDsc>().Property(item => item.CdMatOhCode).HasMaxLength(60);
            modelBuilder.Entity<OhDsc>().Property(item => item.CdMatOhCode).HasColumnName("CD_MAT_OH__CODE");
            modelBuilder.Entity<OhDsc>().Property(item => item.CdTeteAvOhTeteAv).HasMaxLength(60);
            modelBuilder.Entity<OhDsc>().Property(item => item.CdTeteAvOhTeteAv).HasColumnName("CD_TETE_AV_OH__TETE_AV");
            modelBuilder.Entity<OhDsc>().Property(item => item.CdOuvOhOuv).HasMaxLength(60);
            modelBuilder.Entity<OhDsc>().Property(item => item.CdOuvOhOuv).HasColumnName("CD_OUV_OH__OUV");
            modelBuilder.Entity<OhDsc>().Property(item => item.CdEcoulOhEcoul).HasMaxLength(60);
            modelBuilder.Entity<OhDsc>().Property(item => item.CdEcoulOhEcoul).HasColumnName("CD_ECOUL_OH__ECOUL");
            modelBuilder.Entity<OhDsc>().Property(item => item.CdExtOhType).HasMaxLength(60);
            modelBuilder.Entity<OhDsc>().Property(item => item.CdExtOhType).HasColumnName("CD_EXT_OH__TYPE");
            modelBuilder.Entity<OhDsc>().Property(item => item.CdEauOhEau).HasMaxLength(60);
            modelBuilder.Entity<OhDsc>().Property(item => item.CdEauOhEau).HasColumnName("CD_EAU_OH__EAU");
            modelBuilder.Entity<OhDsc>().Property(item => item.CdEntpOhEntreprise).HasMaxLength(60);
            modelBuilder.Entity<OhDsc>().Property(item => item.CdEntpOhEntreprise).HasColumnName("CD_ENTP_OH__ENTREPRISE");
            modelBuilder.Entity<OhDsc>().Property(item => item.CdTypeOhType).IsRequired();
            modelBuilder.Entity<OhDsc>().Property(item => item.CdTypeOhType).HasMaxLength(60);
            modelBuilder.Entity<OhDsc>().Property(item => item.CdTypeOhType).HasColumnName("CD_TYPE_OH__TYPE");
            modelBuilder.Entity<OhDsc>().Property(item => item.CdProAvOhProtect).HasMaxLength(60);
            modelBuilder.Entity<OhDsc>().Property(item => item.CdProAvOhProtect).HasColumnName("CD_PRO_AV_OH__PROTECT");
            modelBuilder.Entity<OhDsc>().Property(item => item.CdQualiteOhQualite).HasMaxLength(25);
            modelBuilder.Entity<OhDsc>().Property(item => item.CdQualiteOhQualite).HasColumnName("CD_QUALITE_OH__QUALITE");
            modelBuilder.Entity<OhDsc>().Property(item => item.CdMoOhMo).HasMaxLength(60);
            modelBuilder.Entity<OhDsc>().Property(item => item.CdMoOhMo).HasColumnName("CD_MO_OH__MO");
            modelBuilder.Entity<OhDsc>().Property(item => item.CdTeteAmOhTeteAm).HasMaxLength(60);
            modelBuilder.Entity<OhDsc>().Property(item => item.CdTeteAmOhTeteAm).HasColumnName("CD_TETE_AM_OH__TETE_AM");
            modelBuilder.Entity<OhDsc>().Property(item => item.CdNomEauOhNom).HasMaxLength(60);
            modelBuilder.Entity<OhDsc>().Property(item => item.CdNomEauOhNom).HasColumnName("CD_NOM_EAU_OH__NOM");
            modelBuilder.Entity<OhDsc>().Property(item => item.CdSousTypeOhSousType).HasMaxLength(60);
            modelBuilder.Entity<OhDsc>().Property(item => item.CdSousTypeOhSousType).HasColumnName("CD_SOUS_TYPE_OH__SOUS_TYPE");
            modelBuilder.Entity<OhDsc>().Property(item => item.CdProAmOhProtect).HasMaxLength(60);
            modelBuilder.Entity<OhDsc>().Property(item => item.CdProAmOhProtect).HasColumnName("CD_PRO_AM_OH__PROTECT");
            modelBuilder.Entity<OhDsc>().Property(item => item.CdFamOhFamille).IsRequired();
            modelBuilder.Entity<OhDsc>().Property(item => item.CdFamOhFamille).HasMaxLength(20);
            modelBuilder.Entity<OhDsc>().Property(item => item.CdFamOhFamille).HasColumnName("CD_FAM_OH__FAMILLE");
            modelBuilder.Entity<OhDsc>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<OhDsc>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<OhDsc>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<OhDsc>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<OhDsc>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<OhDsc>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<OhDsc>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<OhDsc>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<OhDsc>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<OhDsc>().Property(item => item.NumExploit).HasMaxLength(30);
            modelBuilder.Entity<OhDsc>().Property(item => item.NumExploit).HasColumnName("NUM_EXPLOIT");
            modelBuilder.Entity<OhDsc>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<OhDsc>().Property(item => item.Longueur).HasColumnName("LONGUEUR");
            modelBuilder.Entity<OhDsc>().Property(item => item.Hauteur).HasColumnName("HAUTEUR");
            modelBuilder.Entity<OhDsc>().Property(item => item.Biais).HasColumnName("BIAIS");
            modelBuilder.Entity<OhDsc>().Property(item => item.Pente).HasColumnName("PENTE");
            modelBuilder.Entity<OhDsc>().Property(item => item.Portee).HasColumnName("PORTEE");
            modelBuilder.Entity<OhDsc>().Property(item => item.Jum).HasColumnName("JUM");
            modelBuilder.Entity<OhDsc>().Property(item => item.Elem).HasColumnName("ELEM");
            modelBuilder.Entity<OhDsc>().Property(item => item.Regard).HasColumnName("REGARD");
            modelBuilder.Entity<OhDsc>().Property(item => item.Perche).HasColumnName("PERCHE");
            modelBuilder.Entity<OhDsc>().Property(item => item.Vulnerable).HasColumnName("VULNERABLE");
            modelBuilder.Entity<OhDsc>().Property(item => item.Faune).HasColumnName("FAUNE");
            modelBuilder.Entity<OhDsc>().Property(item => item.Loi).HasColumnName("LOI");
            modelBuilder.Entity<OhDsc>().Property(item => item.Phe).HasColumnName("PHE");
            modelBuilder.Entity<OhDsc>().Property(item => item.Debit).HasColumnName("DEBIT");
            modelBuilder.Entity<OhDsc>().Property(item => item.OuvAval).HasMaxLength(200);
            modelBuilder.Entity<OhDsc>().Property(item => item.OuvAval).HasColumnName("OUV_AVAL");
            modelBuilder.Entity<OhDsc>().Property(item => item.Note1).HasColumnName("NOTE1");
            modelBuilder.Entity<OhDsc>().Property(item => item.Note2).HasColumnName("NOTE2");
            modelBuilder.Entity<OhDsc>().Property(item => item.Note3).HasColumnName("NOTE3");
            modelBuilder.Entity<OhDsc>().Property(item => item.Note4).HasColumnName("NOTE4");
            modelBuilder.Entity<OhDsc>().Property(item => item.Note5).HasColumnName("NOTE5");
            modelBuilder.Entity<OhDsc>().Property(item => item.Urgence).HasMaxLength(5);
            modelBuilder.Entity<OhDsc>().Property(item => item.Urgence).HasColumnName("URGENCE");
            modelBuilder.Entity<OhDsc>().Property(item => item.DescInva).HasMaxLength(1000);
            modelBuilder.Entity<OhDsc>().Property(item => item.DescInva).HasColumnName("DESC_INVA");
            modelBuilder.Entity<OhDsc>().Property(item => item.Securite).HasColumnName("SECURITE");
            modelBuilder.Entity<OhDsc>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<OhDsc>().Property(item => item.ProsurvAnnee).HasColumnName("PROSURV_ANNEE");
            modelBuilder.Entity<OhDsc>().Property(item => item.DernInsp).HasColumnName("DERN_INSP");
            modelBuilder.Entity<OhDsc>().Property(item => item.DernVst).HasColumnName("DERN_VST");
            modelBuilder.Entity<OhDsc>().Property(item => item.NoteVst).HasMaxLength(5);
            modelBuilder.Entity<OhDsc>().Property(item => item.NoteVst).HasColumnName("NOTE_VST");
            modelBuilder.Entity<OhDsc>().Property(item => item.Archive).HasMaxLength(255);
            modelBuilder.Entity<OhDsc>().Property(item => item.Archive).HasColumnName("ARCHIVE");
            modelBuilder.Entity<OhDsc>().Property(item => item.Commentaire).HasMaxLength(1000);
            modelBuilder.Entity<OhDsc>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<OhDsc>().Property(item => item.X1).HasColumnName("X1");
            modelBuilder.Entity<OhDsc>().Property(item => item.Y1).HasColumnName("Y1");
            modelBuilder.Entity<OhDsc>().Property(item => item.Z1).HasColumnName("Z1");
            modelBuilder.Entity<OhDsc>().Property(item => item.X2).HasColumnName("X2");
            modelBuilder.Entity<OhDsc>().Property(item => item.Y2).HasColumnName("Y2");
            modelBuilder.Entity<OhDsc>().Property(item => item.Z2).HasColumnName("Z2");
            modelBuilder.Entity<OhDsc>().Property(item => item.DateReleve).HasColumnName("DATE_RELEVE");
            modelBuilder.Entity<OhDsc>().Property(item => item.Terrain).HasColumnName("TERRAIN");
            modelBuilder.Entity<OhCls>().ToTable("CLS_OH","OH");
            modelBuilder.Entity<OhCls>().HasKey(item => new {item.Id });
            modelBuilder.Entity<OhCls>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<OhCls>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<OhCls>().Property(item => item.TableName).IsRequired();
            modelBuilder.Entity<OhCls>().Property(item => item.TableName).HasMaxLength(30);
            modelBuilder.Entity<OhCls>().Property(item => item.TableName).HasColumnName("TABLE_NAME");
            modelBuilder.Entity<OhCls>().Property(item => item.KeyValue).IsRequired();
            modelBuilder.Entity<OhCls>().Property(item => item.KeyValue).HasMaxLength(500);
            modelBuilder.Entity<OhCls>().Property(item => item.KeyValue).HasColumnName("KEY_VALUE");
            modelBuilder.Entity<OhDoc>().ToTable("DOC_OH","OH");
            modelBuilder.Entity<OhDoc>().HasKey(item => new {item.Id });
            modelBuilder.Entity<OhDoc>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<OhDoc>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<OhDoc>().Property(item => item.CdDocOhCode).IsRequired();
            modelBuilder.Entity<OhDoc>().Property(item => item.CdDocOhCode).HasMaxLength(15);
            modelBuilder.Entity<OhDoc>().Property(item => item.CdDocOhCode).HasColumnName("CD_DOC_OH__CODE");
            modelBuilder.Entity<OhDoc>().Property(item => item.Libelle).HasMaxLength(100);
            modelBuilder.Entity<OhDoc>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<OhDoc>().Property(item => item.Ref).IsRequired();
            modelBuilder.Entity<OhDoc>().Property(item => item.Ref).HasMaxLength(50);
            modelBuilder.Entity<OhDoc>().Property(item => item.Ref).HasColumnName("REF");
            modelBuilder.Entity<OhCdDoc>().ToTable("CD_DOC_OH","OH");
            modelBuilder.Entity<OhCdDoc>().HasKey(item => new {item.Code });
            modelBuilder.Entity<OhCdDoc>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<OhCdDoc>().Property(item => item.Code).HasMaxLength(15);
            modelBuilder.Entity<OhCdDoc>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<OhCdDoc>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<OhCdDoc>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<OhCdDoc>().Property(item => item.Path).HasMaxLength(255);
            modelBuilder.Entity<OhCdDoc>().Property(item => item.Path).HasColumnName("PATH");
            modelBuilder.Entity<OhElt>().ToTable("ELT_OH","OH");
            modelBuilder.Entity<OhElt>().HasKey(item => new {item.GrpOhIdGrp,item.PrtOhIdPrt,item.SprtOhIdSprt,item.IdElem });
            modelBuilder.Entity<OhElt>().Property(item => item.GrpOhIdGrp).IsRequired();
            modelBuilder.Entity<OhElt>().Property(item => item.GrpOhIdGrp).HasColumnName("GRP_OH__ID_GRP");
            modelBuilder.Entity<OhElt>().Property(item => item.PrtOhIdPrt).IsRequired();
            modelBuilder.Entity<OhElt>().Property(item => item.PrtOhIdPrt).HasColumnName("PRT_OH__ID_PRT");
            modelBuilder.Entity<OhElt>().Property(item => item.SprtOhIdSprt).IsRequired();
            modelBuilder.Entity<OhElt>().Property(item => item.SprtOhIdSprt).HasColumnName("SPRT_OH__ID_SPRT");
            modelBuilder.Entity<OhElt>().Property(item => item.IdElem).IsRequired();
            modelBuilder.Entity<OhElt>().Property(item => item.IdElem).HasColumnName("ID_ELEM");
            modelBuilder.Entity<OhElt>().Property(item => item.Libe).IsRequired();
            modelBuilder.Entity<OhElt>().Property(item => item.Libe).HasMaxLength(500);
            modelBuilder.Entity<OhElt>().Property(item => item.Libe).HasColumnName("LIBE");
            modelBuilder.Entity<OhElt>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<OhElt>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<OhElt>().Property(item => item.Aide).HasMaxLength(500);
            modelBuilder.Entity<OhElt>().Property(item => item.Aide).HasColumnName("AIDE");
            modelBuilder.Entity<OhElt>().Property(item => item.Indice1).HasMaxLength(500);
            modelBuilder.Entity<OhElt>().Property(item => item.Indice1).HasColumnName("INDICE1");
            modelBuilder.Entity<OhElt>().Property(item => item.Indice2).HasMaxLength(500);
            modelBuilder.Entity<OhElt>().Property(item => item.Indice2).HasColumnName("INDICE2");
            modelBuilder.Entity<OhElt>().Property(item => item.Indice3).HasMaxLength(500);
            modelBuilder.Entity<OhElt>().Property(item => item.Indice3).HasColumnName("INDICE3");
            modelBuilder.Entity<OhSprt>().ToTable("SPRT_OH","OH");
            modelBuilder.Entity<OhSprt>().HasKey(item => new {item.GrpOhIdGrp,item.PrtOhIdPrt,item.IdSprt });
            modelBuilder.Entity<OhSprt>().Property(item => item.GrpOhIdGrp).IsRequired();
            modelBuilder.Entity<OhSprt>().Property(item => item.GrpOhIdGrp).HasColumnName("GRP_OH__ID_GRP");
            modelBuilder.Entity<OhSprt>().Property(item => item.PrtOhIdPrt).IsRequired();
            modelBuilder.Entity<OhSprt>().Property(item => item.PrtOhIdPrt).HasColumnName("PRT_OH__ID_PRT");
            modelBuilder.Entity<OhSprt>().Property(item => item.IdSprt).IsRequired();
            modelBuilder.Entity<OhSprt>().Property(item => item.IdSprt).HasColumnName("ID_SPRT");
            modelBuilder.Entity<OhSprt>().Property(item => item.Libs).IsRequired();
            modelBuilder.Entity<OhSprt>().Property(item => item.Libs).HasMaxLength(500);
            modelBuilder.Entity<OhSprt>().Property(item => item.Libs).HasColumnName("LIBS");
            modelBuilder.Entity<OhSprt>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<OhSprt>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<OhPrt>().ToTable("PRT_OH","OH");
            modelBuilder.Entity<OhPrt>().HasKey(item => new {item.GrpOhIdGrp,item.IdPrt });
            modelBuilder.Entity<OhPrt>().Property(item => item.GrpOhIdGrp).IsRequired();
            modelBuilder.Entity<OhPrt>().Property(item => item.GrpOhIdGrp).HasColumnName("GRP_OH__ID_GRP");
            modelBuilder.Entity<OhPrt>().Property(item => item.IdPrt).IsRequired();
            modelBuilder.Entity<OhPrt>().Property(item => item.IdPrt).HasColumnName("ID_PRT");
            modelBuilder.Entity<OhPrt>().Property(item => item.Libp).IsRequired();
            modelBuilder.Entity<OhPrt>().Property(item => item.Libp).HasMaxLength(500);
            modelBuilder.Entity<OhPrt>().Property(item => item.Libp).HasColumnName("LIBP");
            modelBuilder.Entity<OhPrt>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<OhPrt>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<OhGrp>().ToTable("GRP_OH","OH");
            modelBuilder.Entity<OhGrp>().HasKey(item => new {item.IdGrp });
            modelBuilder.Entity<OhGrp>().Property(item => item.IdGrp).IsRequired();
            modelBuilder.Entity<OhGrp>().Property(item => item.IdGrp).HasColumnName("ID_GRP");
            modelBuilder.Entity<OhGrp>().Property(item => item.Libg).IsRequired();
            modelBuilder.Entity<OhGrp>().Property(item => item.Libg).HasMaxLength(500);
            modelBuilder.Entity<OhGrp>().Property(item => item.Libg).HasColumnName("LIBG");
            modelBuilder.Entity<OhGrp>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<OhGrp>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<OhInsp>().ToTable("INSP_OH","OH");
            modelBuilder.Entity<OhInsp>().HasKey(item => new {item.CampOhIdCamp,item.DscOhNumOh });
            modelBuilder.Entity<OhInsp>().Property(item => item.CampOhIdCamp).IsRequired();
            modelBuilder.Entity<OhInsp>().Property(item => item.CampOhIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OhInsp>().Property(item => item.CampOhIdCamp).HasColumnName("CAMP_OH__ID_CAMP");
            modelBuilder.Entity<OhInsp>().Property(item => item.DscOhNumOh).IsRequired();
            modelBuilder.Entity<OhInsp>().Property(item => item.DscOhNumOh).HasMaxLength(20);
            modelBuilder.Entity<OhInsp>().Property(item => item.DscOhNumOh).HasColumnName("DSC_OH__NUM_OH");
            modelBuilder.Entity<OhInsp>().Property(item => item.CdMeteoOhMeteo).HasMaxLength(60);
            modelBuilder.Entity<OhInsp>().Property(item => item.CdMeteoOhMeteo).HasColumnName("CD_METEO_OH__METEO");
            modelBuilder.Entity<OhInsp>().Property(item => item.InspecteurOhNom).HasMaxLength(60);
            modelBuilder.Entity<OhInsp>().Property(item => item.InspecteurOhNom).HasColumnName("INSPECTEUR_OH__NOM");
            modelBuilder.Entity<OhInsp>().Property(item => item.CdEtudeOhEtude).HasMaxLength(65);
            modelBuilder.Entity<OhInsp>().Property(item => item.CdEtudeOhEtude).HasColumnName("CD_ETUDE_OH__ETUDE");
            modelBuilder.Entity<OhInsp>().Property(item => item.Etat).IsRequired();
            modelBuilder.Entity<OhInsp>().Property(item => item.Etat).HasMaxLength(25);
            modelBuilder.Entity<OhInsp>().Property(item => item.Etat).HasColumnName("ETAT");
            modelBuilder.Entity<OhInsp>().Property(item => item.Datev).HasColumnName("DATEV");
            modelBuilder.Entity<OhInsp>().Property(item => item.Temperature).HasColumnName("TEMPERATURE");
            modelBuilder.Entity<OhInsp>().Property(item => item.Moyen).HasMaxLength(500);
            modelBuilder.Entity<OhInsp>().Property(item => item.Moyen).HasColumnName("MOYEN");
            modelBuilder.Entity<OhInsp>().Property(item => item.Conditions).HasMaxLength(500);
            modelBuilder.Entity<OhInsp>().Property(item => item.Conditions).HasColumnName("CONDITIONS");
            modelBuilder.Entity<OhInsp>().Property(item => item.NomValid).HasMaxLength(250);
            modelBuilder.Entity<OhInsp>().Property(item => item.NomValid).HasColumnName("NOM_VALID");
            modelBuilder.Entity<OhInsp>().Property(item => item.DateValid).HasColumnName("DATE_VALID");
            modelBuilder.Entity<OhInsp>().Property(item => item.DescInva).HasMaxLength(1000);
            modelBuilder.Entity<OhInsp>().Property(item => item.DescInva).HasColumnName("DESC_INVA");
            modelBuilder.Entity<OhInsp>().Property(item => item.Prioritaire).HasMaxLength(1000);
            modelBuilder.Entity<OhInsp>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<OhInsp>().Property(item => item.Securite).HasMaxLength(1000);
            modelBuilder.Entity<OhInsp>().Property(item => item.Securite).HasColumnName("SECURITE");
            modelBuilder.Entity<OhInsp>().Property(item => item.Note1).HasColumnName("NOTE1");
            modelBuilder.Entity<OhInsp>().Property(item => item.Note2).HasColumnName("NOTE2");
            modelBuilder.Entity<OhInsp>().Property(item => item.Note3).HasColumnName("NOTE3");
            modelBuilder.Entity<OhInsp>().Property(item => item.Note4).HasColumnName("NOTE4");
            modelBuilder.Entity<OhInsp>().Property(item => item.Note5).HasColumnName("NOTE5");
            modelBuilder.Entity<OhInsp>().Property(item => item.Urgence).HasMaxLength(5);
            modelBuilder.Entity<OhInsp>().Property(item => item.Urgence).HasColumnName("URGENCE");
            modelBuilder.Entity<OhInsp>().Property(item => item.Qualite).HasMaxLength(25);
            modelBuilder.Entity<OhInsp>().Property(item => item.Qualite).HasColumnName("QUALITE");
            modelBuilder.Entity<OhEltInsp>().ToTable("ELT_INSP_OH","OH");
            modelBuilder.Entity<OhEltInsp>().HasKey(item => new {item.GrpOhIdGrp,item.PrtOhIdPrt,item.SprtOhIdSprt,item.EltOhIdElem,item.CampOhIdCamp,item.DscOhNumOh });
            modelBuilder.Entity<OhEltInsp>().Property(item => item.GrpOhIdGrp).IsRequired();
            modelBuilder.Entity<OhEltInsp>().Property(item => item.GrpOhIdGrp).HasColumnName("GRP_OH__ID_GRP");
            modelBuilder.Entity<OhEltInsp>().Property(item => item.PrtOhIdPrt).IsRequired();
            modelBuilder.Entity<OhEltInsp>().Property(item => item.PrtOhIdPrt).HasColumnName("PRT_OH__ID_PRT");
            modelBuilder.Entity<OhEltInsp>().Property(item => item.SprtOhIdSprt).IsRequired();
            modelBuilder.Entity<OhEltInsp>().Property(item => item.SprtOhIdSprt).HasColumnName("SPRT_OH__ID_SPRT");
            modelBuilder.Entity<OhEltInsp>().Property(item => item.EltOhIdElem).IsRequired();
            modelBuilder.Entity<OhEltInsp>().Property(item => item.EltOhIdElem).HasColumnName("ELT_OH__ID_ELEM");
            modelBuilder.Entity<OhEltInsp>().Property(item => item.CampOhIdCamp).IsRequired();
            modelBuilder.Entity<OhEltInsp>().Property(item => item.CampOhIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OhEltInsp>().Property(item => item.CampOhIdCamp).HasColumnName("CAMP_OH__ID_CAMP");
            modelBuilder.Entity<OhEltInsp>().Property(item => item.DscOhNumOh).IsRequired();
            modelBuilder.Entity<OhEltInsp>().Property(item => item.DscOhNumOh).HasMaxLength(20);
            modelBuilder.Entity<OhEltInsp>().Property(item => item.DscOhNumOh).HasColumnName("DSC_OH__NUM_OH");
            modelBuilder.Entity<OhEltInsp>().Property(item => item.Indice).IsRequired();
            modelBuilder.Entity<OhEltInsp>().Property(item => item.Indice).HasColumnName("INDICE");
            modelBuilder.Entity<OhEltInsp>().Property(item => item.Obs).HasMaxLength(255);
            modelBuilder.Entity<OhEltInsp>().Property(item => item.Obs).HasColumnName("OBS");
            modelBuilder.Entity<OhPhotoEltInsp>().ToTable("PHOTO_ELT_INSP_OH","OH");
            modelBuilder.Entity<OhPhotoEltInsp>().HasKey(item => new {item.GrpOhIdGrp,item.PrtOhIdPrt,item.SprtOhIdSprt,item.CampOhIdCamp,item.EltOhIdElem,item.DscOhNumOh,item.Id });
            modelBuilder.Entity<OhPhotoEltInsp>().Property(item => item.GrpOhIdGrp).IsRequired();
            modelBuilder.Entity<OhPhotoEltInsp>().Property(item => item.GrpOhIdGrp).HasColumnName("GRP_OH__ID_GRP");
            modelBuilder.Entity<OhPhotoEltInsp>().Property(item => item.PrtOhIdPrt).IsRequired();
            modelBuilder.Entity<OhPhotoEltInsp>().Property(item => item.PrtOhIdPrt).HasColumnName("PRT_OH__ID_PRT");
            modelBuilder.Entity<OhPhotoEltInsp>().Property(item => item.SprtOhIdSprt).IsRequired();
            modelBuilder.Entity<OhPhotoEltInsp>().Property(item => item.SprtOhIdSprt).HasColumnName("SPRT_OH__ID_SPRT");
            modelBuilder.Entity<OhPhotoEltInsp>().Property(item => item.CampOhIdCamp).IsRequired();
            modelBuilder.Entity<OhPhotoEltInsp>().Property(item => item.CampOhIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OhPhotoEltInsp>().Property(item => item.CampOhIdCamp).HasColumnName("CAMP_OH__ID_CAMP");
            modelBuilder.Entity<OhPhotoEltInsp>().Property(item => item.EltOhIdElem).IsRequired();
            modelBuilder.Entity<OhPhotoEltInsp>().Property(item => item.EltOhIdElem).HasColumnName("ELT_OH__ID_ELEM");
            modelBuilder.Entity<OhPhotoEltInsp>().Property(item => item.DscOhNumOh).IsRequired();
            modelBuilder.Entity<OhPhotoEltInsp>().Property(item => item.DscOhNumOh).HasMaxLength(20);
            modelBuilder.Entity<OhPhotoEltInsp>().Property(item => item.DscOhNumOh).HasColumnName("DSC_OH__NUM_OH");
            modelBuilder.Entity<OhPhotoEltInsp>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<OhPhotoEltInsp>().Property(item => item.Id).HasMaxLength(50);
            modelBuilder.Entity<OhPhotoEltInsp>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<OhPhotoEltInsp>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<OhPhotoEltInsp>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<OhCamp>().ToTable("CAMP_OH","OH");
            modelBuilder.Entity<OhCamp>().HasKey(item => new {item.IdCamp });
            modelBuilder.Entity<OhCamp>().Property(item => item.IdCamp).IsRequired();
            modelBuilder.Entity<OhCamp>().Property(item => item.IdCamp).HasMaxLength(100);
            modelBuilder.Entity<OhCamp>().Property(item => item.IdCamp).HasColumnName("ID_CAMP");
            modelBuilder.Entity<OhCamp>().Property(item => item.CdPrestaOhPrestataire).IsRequired();
            modelBuilder.Entity<OhCamp>().Property(item => item.CdPrestaOhPrestataire).HasMaxLength(50);
            modelBuilder.Entity<OhCamp>().Property(item => item.CdPrestaOhPrestataire).HasColumnName("CD_PRESTA_OH__PRESTATAIRE");
            modelBuilder.Entity<OhCamp>().Property(item => item.CdTypePvOhCode).IsRequired();
            modelBuilder.Entity<OhCamp>().Property(item => item.CdTypePvOhCode).HasMaxLength(15);
            modelBuilder.Entity<OhCamp>().Property(item => item.CdTypePvOhCode).HasColumnName("CD_TYPE_PV_OH__CODE");
            modelBuilder.Entity<OhCamp>().Property(item => item.Annee).IsRequired();
            modelBuilder.Entity<OhCamp>().Property(item => item.Annee).HasColumnName("ANNEE");
            modelBuilder.Entity<OhCamp>().Property(item => item.Dater).IsRequired();
            modelBuilder.Entity<OhCamp>().Property(item => item.Dater).HasColumnName("DATER");
            modelBuilder.Entity<OhCamp>().Property(item => item.Dateg).HasColumnName("DATEG");
            modelBuilder.Entity<OhCamp>().Property(item => item.Userg).HasMaxLength(250);
            modelBuilder.Entity<OhCamp>().Property(item => item.Userg).HasColumnName("USERG");
            modelBuilder.Entity<OhCamp>().Property(item => item.Observ).HasMaxLength(500);
            modelBuilder.Entity<OhCamp>().Property(item => item.Observ).HasColumnName("OBSERV");
            modelBuilder.Entity<OhCdMeteo>().ToTable("CD_METEO_OH","OH");
            modelBuilder.Entity<OhCdMeteo>().HasKey(item => new {item.Meteo });
            modelBuilder.Entity<OhCdMeteo>().Property(item => item.Meteo).IsRequired();
            modelBuilder.Entity<OhCdMeteo>().Property(item => item.Meteo).HasMaxLength(60);
            modelBuilder.Entity<OhCdMeteo>().Property(item => item.Meteo).HasColumnName("METEO");
            modelBuilder.Entity<OhCdPresta>().ToTable("CD_PRESTA_OH","OH");
            modelBuilder.Entity<OhCdPresta>().HasKey(item => new {item.Prestataire });
            modelBuilder.Entity<OhCdPresta>().Property(item => item.Prestataire).IsRequired();
            modelBuilder.Entity<OhCdPresta>().Property(item => item.Prestataire).HasMaxLength(50);
            modelBuilder.Entity<OhCdPresta>().Property(item => item.Prestataire).HasColumnName("PRESTATAIRE");
            modelBuilder.Entity<OhTravaux>().ToTable("TRAVAUX_OH","OH");
            modelBuilder.Entity<OhTravaux>().HasKey(item => new {item.DscOhNumOh,item.CdTravauxOhCode,item.NatureTravOhNature,item.DateRcp });
            modelBuilder.Entity<OhTravaux>().Property(item => item.DscOhNumOh).IsRequired();
            modelBuilder.Entity<OhTravaux>().Property(item => item.DscOhNumOh).HasMaxLength(20);
            modelBuilder.Entity<OhTravaux>().Property(item => item.DscOhNumOh).HasColumnName("DSC_OH__NUM_OH");
            modelBuilder.Entity<OhTravaux>().Property(item => item.CdTravauxOhCode).IsRequired();
            modelBuilder.Entity<OhTravaux>().Property(item => item.CdTravauxOhCode).HasMaxLength(60);
            modelBuilder.Entity<OhTravaux>().Property(item => item.CdTravauxOhCode).HasColumnName("CD_TRAVAUX_OH__CODE");
            modelBuilder.Entity<OhTravaux>().Property(item => item.NatureTravOhNature).IsRequired();
            modelBuilder.Entity<OhTravaux>().Property(item => item.NatureTravOhNature).HasMaxLength(100);
            modelBuilder.Entity<OhTravaux>().Property(item => item.NatureTravOhNature).HasColumnName("NATURE_TRAV_OH__NATURE");
            modelBuilder.Entity<OhTravaux>().Property(item => item.DateRcp).IsRequired();
            modelBuilder.Entity<OhTravaux>().Property(item => item.DateRcp).HasColumnName("DATE_RCP");
            modelBuilder.Entity<OhTravaux>().Property(item => item.CdEntpOhEntreprise).IsRequired();
            modelBuilder.Entity<OhTravaux>().Property(item => item.CdEntpOhEntreprise).HasMaxLength(60);
            modelBuilder.Entity<OhTravaux>().Property(item => item.CdEntpOhEntreprise).HasColumnName("CD_ENTP_OH__ENTREPRISE");
            modelBuilder.Entity<OhTravaux>().Property(item => item.DateFinGar).HasColumnName("DATE_FIN_GAR");
            modelBuilder.Entity<OhTravaux>().Property(item => item.Cout).HasColumnName("COUT");
            modelBuilder.Entity<OhTravaux>().Property(item => item.Marche).HasMaxLength(25);
            modelBuilder.Entity<OhTravaux>().Property(item => item.Marche).HasColumnName("MARCHE");
            modelBuilder.Entity<OhTravaux>().Property(item => item.Commentaire).HasMaxLength(500);
            modelBuilder.Entity<OhTravaux>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<OhNatureTrav>().ToTable("NATURE_TRAV_OH","OH");
            modelBuilder.Entity<OhNatureTrav>().HasKey(item => new {item.CdTravauxOhCode,item.Nature });
            modelBuilder.Entity<OhNatureTrav>().Property(item => item.CdTravauxOhCode).IsRequired();
            modelBuilder.Entity<OhNatureTrav>().Property(item => item.CdTravauxOhCode).HasMaxLength(60);
            modelBuilder.Entity<OhNatureTrav>().Property(item => item.CdTravauxOhCode).HasColumnName("CD_TRAVAUX_OH__CODE");
            modelBuilder.Entity<OhNatureTrav>().Property(item => item.Nature).IsRequired();
            modelBuilder.Entity<OhNatureTrav>().Property(item => item.Nature).HasMaxLength(100);
            modelBuilder.Entity<OhNatureTrav>().Property(item => item.Nature).HasColumnName("NATURE");
            modelBuilder.Entity<OhCdMat>().ToTable("CD_MAT_OH","OH");
            modelBuilder.Entity<OhCdMat>().HasKey(item => new {item.Code });
            modelBuilder.Entity<OhCdMat>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<OhCdMat>().Property(item => item.Code).HasMaxLength(60);
            modelBuilder.Entity<OhCdMat>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<OhCdExt>().ToTable("CD_EXT_OH","OH");
            modelBuilder.Entity<OhCdExt>().HasKey(item => new {item.Type });
            modelBuilder.Entity<OhCdExt>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<OhCdExt>().Property(item => item.Type).HasMaxLength(60);
            modelBuilder.Entity<OhCdExt>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<OhCdExt>().Property(item => item.IsOh).IsRequired();
            modelBuilder.Entity<OhCdExt>().Property(item => item.IsOh).HasColumnName("IS_OH");
            modelBuilder.Entity<OhCdExt>().Property(item => item.IsBsn).IsRequired();
            modelBuilder.Entity<OhCdExt>().Property(item => item.IsBsn).HasColumnName("IS_BSN");
            modelBuilder.Entity<OhCdEau>().ToTable("CD_EAU_OH","OH");
            modelBuilder.Entity<OhCdEau>().HasKey(item => new {item.Eau });
            modelBuilder.Entity<OhCdEau>().Property(item => item.Eau).IsRequired();
            modelBuilder.Entity<OhCdEau>().Property(item => item.Eau).HasMaxLength(60);
            modelBuilder.Entity<OhCdEau>().Property(item => item.Eau).HasColumnName("EAU");
            modelBuilder.Entity<OhCdOuv>().ToTable("CD_OUV_OH","OH");
            modelBuilder.Entity<OhCdOuv>().HasKey(item => new {item.Ouv });
            modelBuilder.Entity<OhCdOuv>().Property(item => item.Ouv).IsRequired();
            modelBuilder.Entity<OhCdOuv>().Property(item => item.Ouv).HasMaxLength(60);
            modelBuilder.Entity<OhCdOuv>().Property(item => item.Ouv).HasColumnName("OUV");
            modelBuilder.Entity<OhCdEcoul>().ToTable("CD_ECOUL_OH","OH");
            modelBuilder.Entity<OhCdEcoul>().HasKey(item => new {item.Ecoul });
            modelBuilder.Entity<OhCdEcoul>().Property(item => item.Ecoul).IsRequired();
            modelBuilder.Entity<OhCdEcoul>().Property(item => item.Ecoul).HasMaxLength(60);
            modelBuilder.Entity<OhCdEcoul>().Property(item => item.Ecoul).HasColumnName("ECOUL");
            modelBuilder.Entity<OhCdProAv>().ToTable("CD_PRO_AV_OH","OH");
            modelBuilder.Entity<OhCdProAv>().HasKey(item => new {item.Protect });
            modelBuilder.Entity<OhCdProAv>().Property(item => item.Protect).IsRequired();
            modelBuilder.Entity<OhCdProAv>().Property(item => item.Protect).HasMaxLength(60);
            modelBuilder.Entity<OhCdProAv>().Property(item => item.Protect).HasColumnName("PROTECT");
            modelBuilder.Entity<OhSysUser>().ToTable("SYS_USER_OH","OH");
            modelBuilder.Entity<OhSysUser>().HasKey(item => new {item.CodeDbs,item.CodeTable,item.CodeColonne,item.NomUser,item.CodePrp });
            modelBuilder.Entity<OhSysUser>().Property(item => item.CodeDbs).IsRequired();
            modelBuilder.Entity<OhSysUser>().Property(item => item.CodeDbs).HasMaxLength(50);
            modelBuilder.Entity<OhSysUser>().Property(item => item.CodeDbs).HasColumnName("CODE_DBS");
            modelBuilder.Entity<OhSysUser>().Property(item => item.CodeTable).IsRequired();
            modelBuilder.Entity<OhSysUser>().Property(item => item.CodeTable).HasMaxLength(100);
            modelBuilder.Entity<OhSysUser>().Property(item => item.CodeTable).HasColumnName("CODE_TABLE");
            modelBuilder.Entity<OhSysUser>().Property(item => item.CodeColonne).IsRequired();
            modelBuilder.Entity<OhSysUser>().Property(item => item.CodeColonne).HasMaxLength(100);
            modelBuilder.Entity<OhSysUser>().Property(item => item.CodeColonne).HasColumnName("CODE_COLONNE");
            modelBuilder.Entity<OhSysUser>().Property(item => item.NomUser).IsRequired();
            modelBuilder.Entity<OhSysUser>().Property(item => item.NomUser).HasMaxLength(150);
            modelBuilder.Entity<OhSysUser>().Property(item => item.NomUser).HasColumnName("NOM_USER");
            modelBuilder.Entity<OhSysUser>().Property(item => item.CodePrp).IsRequired();
            modelBuilder.Entity<OhSysUser>().Property(item => item.CodePrp).HasMaxLength(255);
            modelBuilder.Entity<OhSysUser>().Property(item => item.CodePrp).HasColumnName("CODE_PRP");
            modelBuilder.Entity<OhSysUser>().Property(item => item.ValPrp).IsRequired();
            modelBuilder.Entity<OhSysUser>().Property(item => item.ValPrp).HasMaxLength(500);
            modelBuilder.Entity<OhSysUser>().Property(item => item.ValPrp).HasColumnName("VAL_PRP");
            modelBuilder.Entity<OhCdProAm>().ToTable("CD_PRO_AM_OH","OH");
            modelBuilder.Entity<OhCdProAm>().HasKey(item => new {item.Protect });
            modelBuilder.Entity<OhCdProAm>().Property(item => item.Protect).IsRequired();
            modelBuilder.Entity<OhCdProAm>().Property(item => item.Protect).HasMaxLength(60);
            modelBuilder.Entity<OhCdProAm>().Property(item => item.Protect).HasColumnName("PROTECT");
            modelBuilder.Entity<OhCdTypePv>().ToTable("CD_TYPE_PV_OH","OH");
            modelBuilder.Entity<OhCdTypePv>().HasKey(item => new {item.Code });
            modelBuilder.Entity<OhCdTypePv>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<OhCdTypePv>().Property(item => item.Code).HasMaxLength(15);
            modelBuilder.Entity<OhCdTypePv>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<OhCdTypePv>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<OhCdTypePv>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<OhCdTypePv>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<OhCdTypePv>().Property(item => item.Cycle).HasColumnName("CYCLE");
            modelBuilder.Entity<OhCdTypePv>().Property(item => item.Cout).HasColumnName("COUT");
            modelBuilder.Entity<OhCdEtude>().ToTable("CD_ETUDE_OH","OH");
            modelBuilder.Entity<OhCdEtude>().HasKey(item => new {item.Etude });
            modelBuilder.Entity<OhCdEtude>().Property(item => item.Etude).IsRequired();
            modelBuilder.Entity<OhCdEtude>().Property(item => item.Etude).HasMaxLength(65);
            modelBuilder.Entity<OhCdEtude>().Property(item => item.Etude).HasColumnName("ETUDE");
            modelBuilder.Entity<OhBpu>().ToTable("BPU_OH","OH");
            modelBuilder.Entity<OhBpu>().HasKey(item => new {item.IdBpu });
            modelBuilder.Entity<OhBpu>().Property(item => item.IdBpu).IsRequired();
            modelBuilder.Entity<OhBpu>().Property(item => item.IdBpu).HasColumnName("ID_BPU");
            modelBuilder.Entity<OhBpu>().Property(item => item.CdUniteOhUnite).HasMaxLength(12);
            modelBuilder.Entity<OhBpu>().Property(item => item.CdUniteOhUnite).HasColumnName("CD_UNITE_OH__UNITE");
            modelBuilder.Entity<OhBpu>().Property(item => item.CdTravauxOhCode).IsRequired();
            modelBuilder.Entity<OhBpu>().Property(item => item.CdTravauxOhCode).HasMaxLength(60);
            modelBuilder.Entity<OhBpu>().Property(item => item.CdTravauxOhCode).HasColumnName("CD_TRAVAUX_OH__CODE");
            modelBuilder.Entity<OhBpu>().Property(item => item.Techn).IsRequired();
            modelBuilder.Entity<OhBpu>().Property(item => item.Techn).HasMaxLength(255);
            modelBuilder.Entity<OhBpu>().Property(item => item.Techn).HasColumnName("TECHN");
            modelBuilder.Entity<OhBpu>().Property(item => item.Prix).HasColumnName("PRIX");
            modelBuilder.Entity<OhBpu>().Property(item => item.DateMaj).HasColumnName("DATE_MAJ");
            modelBuilder.Entity<OhBpu>().Property(item => item.Freq).HasColumnName("FREQ");
            modelBuilder.Entity<OhBpu>().Property(item => item.PrecoVst).HasColumnName("PRECO_VST");
            modelBuilder.Entity<OhBpu>().Property(item => item.RealisVst).HasColumnName("REALIS_VST");
            modelBuilder.Entity<OhCdContrainte>().ToTable("CD_CONTRAINTE_OH","OH");
            modelBuilder.Entity<OhCdContrainte>().HasKey(item => new {item.Type });
            modelBuilder.Entity<OhCdContrainte>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<OhCdContrainte>().Property(item => item.Type).HasMaxLength(100);
            modelBuilder.Entity<OhCdContrainte>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<OhCdTravaux>().ToTable("CD_TRAVAUX_OH","OH");
            modelBuilder.Entity<OhCdTravaux>().HasKey(item => new {item.Code });
            modelBuilder.Entity<OhCdTravaux>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<OhCdTravaux>().Property(item => item.Code).HasMaxLength(60);
            modelBuilder.Entity<OhCdTravaux>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<OhCdSousType>().ToTable("CD_SOUS_TYPE_OH","OH");
            modelBuilder.Entity<OhCdSousType>().HasKey(item => new {item.SousType });
            modelBuilder.Entity<OhCdSousType>().Property(item => item.SousType).IsRequired();
            modelBuilder.Entity<OhCdSousType>().Property(item => item.SousType).HasMaxLength(60);
            modelBuilder.Entity<OhCdSousType>().Property(item => item.SousType).HasColumnName("SOUS_TYPE");
            modelBuilder.Entity<OhSeuilQualite>().ToTable("SEUIL_QUALITE_OH","OH");
            modelBuilder.Entity<OhSeuilQualite>().HasKey(item => new {item.CdQualiteOhQualite,item.IndiceUrgence });
            modelBuilder.Entity<OhSeuilQualite>().Property(item => item.CdQualiteOhQualite).IsRequired();
            modelBuilder.Entity<OhSeuilQualite>().Property(item => item.CdQualiteOhQualite).HasMaxLength(25);
            modelBuilder.Entity<OhSeuilQualite>().Property(item => item.CdQualiteOhQualite).HasColumnName("CD_QUALITE_OH__QUALITE");
            modelBuilder.Entity<OhSeuilQualite>().Property(item => item.IndiceUrgence).IsRequired();
            modelBuilder.Entity<OhSeuilQualite>().Property(item => item.IndiceUrgence).HasMaxLength(5);
            modelBuilder.Entity<OhSeuilQualite>().Property(item => item.IndiceUrgence).HasColumnName("INDICE_URGENCE");
            modelBuilder.Entity<OhSeuilUrgence>().ToTable("SEUIL_URGENCE_OH","OH");
            modelBuilder.Entity<OhSeuilUrgence>().HasKey(item => new {item.Ordre });
            modelBuilder.Entity<OhSeuilUrgence>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<OhSeuilUrgence>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<OhSeuilUrgence>().Property(item => item.NbrNote).HasColumnName("NBR_NOTE");
            modelBuilder.Entity<OhSeuilUrgence>().Property(item => item.ValNote).HasColumnName("VAL_NOTE");
            modelBuilder.Entity<OhSeuilUrgence>().Property(item => item.Indice).HasColumnName("INDICE");
            modelBuilder.Entity<OhPrevision>().ToTable("PREVISION_OH","OH");
            modelBuilder.Entity<OhPrevision>().HasKey(item => new {item.DscOhNumOh,item.BpuOhIdBpu,item.DateDebut });
            modelBuilder.Entity<OhPrevision>().Property(item => item.DscOhNumOh).IsRequired();
            modelBuilder.Entity<OhPrevision>().Property(item => item.DscOhNumOh).HasMaxLength(20);
            modelBuilder.Entity<OhPrevision>().Property(item => item.DscOhNumOh).HasColumnName("DSC_OH__NUM_OH");
            modelBuilder.Entity<OhPrevision>().Property(item => item.BpuOhIdBpu).IsRequired();
            modelBuilder.Entity<OhPrevision>().Property(item => item.BpuOhIdBpu).HasColumnName("BPU_OH__ID_BPU");
            modelBuilder.Entity<OhPrevision>().Property(item => item.DateDebut).IsRequired();
            modelBuilder.Entity<OhPrevision>().Property(item => item.DateDebut).HasColumnName("DATE_DEBUT");
            modelBuilder.Entity<OhPrevision>().Property(item => item.CdContrainteOhType).HasMaxLength(100);
            modelBuilder.Entity<OhPrevision>().Property(item => item.CdContrainteOhType).HasColumnName("CD_CONTRAINTE_OH__TYPE");
            modelBuilder.Entity<OhPrevision>().Property(item => item.DateFin).HasColumnName("DATE_FIN");
            modelBuilder.Entity<OhPrevision>().Property(item => item.Montant).HasColumnName("MONTANT");
            modelBuilder.Entity<OhPrevision>().Property(item => item.DateDemPub).HasColumnName("DATE_DEM_PUB");
            modelBuilder.Entity<OhPrevision>().Property(item => item.Commentaire).HasMaxLength(255);
            modelBuilder.Entity<OhPrevision>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<OhPrevision>().Property(item => item.Realise).HasColumnName("REALISE");
            modelBuilder.Entity<OhVst>().ToTable("VST_OH","OH");
            modelBuilder.Entity<OhVst>().HasKey(item => new {item.CampOhIdCamp,item.DscOhNumOh });
            modelBuilder.Entity<OhVst>().Property(item => item.CampOhIdCamp).IsRequired();
            modelBuilder.Entity<OhVst>().Property(item => item.CampOhIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OhVst>().Property(item => item.CampOhIdCamp).HasColumnName("CAMP_OH__ID_CAMP");
            modelBuilder.Entity<OhVst>().Property(item => item.DscOhNumOh).IsRequired();
            modelBuilder.Entity<OhVst>().Property(item => item.DscOhNumOh).HasMaxLength(20);
            modelBuilder.Entity<OhVst>().Property(item => item.DscOhNumOh).HasColumnName("DSC_OH__NUM_OH");
            modelBuilder.Entity<OhVst>().Property(item => item.InspecteurOhNom).HasMaxLength(60);
            modelBuilder.Entity<OhVst>().Property(item => item.InspecteurOhNom).HasColumnName("INSPECTEUR_OH__NOM");
            modelBuilder.Entity<OhVst>().Property(item => item.Etat).IsRequired();
            modelBuilder.Entity<OhVst>().Property(item => item.Etat).HasMaxLength(25);
            modelBuilder.Entity<OhVst>().Property(item => item.Etat).HasColumnName("ETAT");
            modelBuilder.Entity<OhVst>().Property(item => item.Datev).HasColumnName("DATEV");
            modelBuilder.Entity<OhVst>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<OhVst>().Property(item => item.Observ).HasMaxLength(500);
            modelBuilder.Entity<OhVst>().Property(item => item.Observ).HasColumnName("OBSERV");
            modelBuilder.Entity<OhVst>().Property(item => item.NoteVst).HasMaxLength(5);
            modelBuilder.Entity<OhVst>().Property(item => item.NoteVst).HasColumnName("NOTE_VST");
            modelBuilder.Entity<OhSprtVst>().ToTable("SPRT_VST_OH","OH");
            modelBuilder.Entity<OhSprtVst>().HasKey(item => new {item.CampOhIdCamp,item.DscOhNumOh,item.CdChapitreOhIdChap,item.CdLigneOhIdLigne });
            modelBuilder.Entity<OhSprtVst>().Property(item => item.CampOhIdCamp).IsRequired();
            modelBuilder.Entity<OhSprtVst>().Property(item => item.CampOhIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OhSprtVst>().Property(item => item.CampOhIdCamp).HasColumnName("CAMP_OH__ID_CAMP");
            modelBuilder.Entity<OhSprtVst>().Property(item => item.DscOhNumOh).IsRequired();
            modelBuilder.Entity<OhSprtVst>().Property(item => item.DscOhNumOh).HasMaxLength(20);
            modelBuilder.Entity<OhSprtVst>().Property(item => item.DscOhNumOh).HasColumnName("DSC_OH__NUM_OH");
            modelBuilder.Entity<OhSprtVst>().Property(item => item.CdChapitreOhIdChap).IsRequired();
            modelBuilder.Entity<OhSprtVst>().Property(item => item.CdChapitreOhIdChap).HasColumnName("CD_CHAPITRE_OH__ID_CHAP");
            modelBuilder.Entity<OhSprtVst>().Property(item => item.CdLigneOhIdLigne).IsRequired();
            modelBuilder.Entity<OhSprtVst>().Property(item => item.CdLigneOhIdLigne).HasColumnName("CD_LIGNE_OH__ID_LIGNE");
            modelBuilder.Entity<OhSprtVst>().Property(item => item.Indice).IsRequired();
            modelBuilder.Entity<OhSprtVst>().Property(item => item.Indice).HasColumnName("INDICE");
            modelBuilder.Entity<OhSprtVst>().Property(item => item.Obs).HasMaxLength(500);
            modelBuilder.Entity<OhSprtVst>().Property(item => item.Obs).HasColumnName("OBS");
            modelBuilder.Entity<OhPhotoSprtVst>().ToTable("PHOTO_SPRT_VST_OH","OH");
            modelBuilder.Entity<OhPhotoSprtVst>().HasKey(item => new {item.CampOhIdCamp,item.DscOhNumOh,item.CdChapitreOhIdChap,item.CdLigneOhIdLigne,item.Id });
            modelBuilder.Entity<OhPhotoSprtVst>().Property(item => item.CampOhIdCamp).IsRequired();
            modelBuilder.Entity<OhPhotoSprtVst>().Property(item => item.CampOhIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OhPhotoSprtVst>().Property(item => item.CampOhIdCamp).HasColumnName("CAMP_OH__ID_CAMP");
            modelBuilder.Entity<OhPhotoSprtVst>().Property(item => item.DscOhNumOh).IsRequired();
            modelBuilder.Entity<OhPhotoSprtVst>().Property(item => item.DscOhNumOh).HasMaxLength(20);
            modelBuilder.Entity<OhPhotoSprtVst>().Property(item => item.DscOhNumOh).HasColumnName("DSC_OH__NUM_OH");
            modelBuilder.Entity<OhPhotoSprtVst>().Property(item => item.CdChapitreOhIdChap).IsRequired();
            modelBuilder.Entity<OhPhotoSprtVst>().Property(item => item.CdChapitreOhIdChap).HasColumnName("CD_CHAPITRE_OH__ID_CHAP");
            modelBuilder.Entity<OhPhotoSprtVst>().Property(item => item.CdLigneOhIdLigne).IsRequired();
            modelBuilder.Entity<OhPhotoSprtVst>().Property(item => item.CdLigneOhIdLigne).HasColumnName("CD_LIGNE_OH__ID_LIGNE");
            modelBuilder.Entity<OhPhotoSprtVst>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<OhPhotoSprtVst>().Property(item => item.Id).HasMaxLength(50);
            modelBuilder.Entity<OhPhotoSprtVst>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<OhPhotoSprtVst>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<OhPhotoSprtVst>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<OhPhotoVst>().ToTable("PHOTO_VST_OH","OH");
            modelBuilder.Entity<OhPhotoVst>().HasKey(item => new {item.Id });
            modelBuilder.Entity<OhPhotoVst>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<OhPhotoVst>().Property(item => item.Id).HasMaxLength(30);
            modelBuilder.Entity<OhPhotoVst>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<OhPhotoVst>().Property(item => item.CampOhIdCamp).IsRequired();
            modelBuilder.Entity<OhPhotoVst>().Property(item => item.CampOhIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OhPhotoVst>().Property(item => item.CampOhIdCamp).HasColumnName("CAMP_OH__ID_CAMP");
            modelBuilder.Entity<OhPhotoVst>().Property(item => item.DscOhNumOh).IsRequired();
            modelBuilder.Entity<OhPhotoVst>().Property(item => item.DscOhNumOh).HasMaxLength(20);
            modelBuilder.Entity<OhPhotoVst>().Property(item => item.DscOhNumOh).HasColumnName("DSC_OH__NUM_OH");
            modelBuilder.Entity<OhPhotoVst>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<OhPhotoVst>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<OhPhotoInsp>().ToTable("PHOTO_INSP_OH","OH");
            modelBuilder.Entity<OhPhotoInsp>().HasKey(item => new {item.Id });
            modelBuilder.Entity<OhPhotoInsp>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<OhPhotoInsp>().Property(item => item.Id).HasMaxLength(30);
            modelBuilder.Entity<OhPhotoInsp>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<OhPhotoInsp>().Property(item => item.CampOhIdCamp).IsRequired();
            modelBuilder.Entity<OhPhotoInsp>().Property(item => item.CampOhIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OhPhotoInsp>().Property(item => item.CampOhIdCamp).HasColumnName("CAMP_OH__ID_CAMP");
            modelBuilder.Entity<OhPhotoInsp>().Property(item => item.DscOhNumOh).IsRequired();
            modelBuilder.Entity<OhPhotoInsp>().Property(item => item.DscOhNumOh).HasMaxLength(20);
            modelBuilder.Entity<OhPhotoInsp>().Property(item => item.DscOhNumOh).HasColumnName("DSC_OH__NUM_OH");
            modelBuilder.Entity<OhPhotoInsp>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<OhPhotoInsp>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<OhCdQualite>().ToTable("CD_QUALITE_OH","OH");
            modelBuilder.Entity<OhCdQualite>().HasKey(item => new {item.Qualite });
            modelBuilder.Entity<OhCdQualite>().Property(item => item.Qualite).IsRequired();
            modelBuilder.Entity<OhCdQualite>().Property(item => item.Qualite).HasMaxLength(25);
            modelBuilder.Entity<OhCdQualite>().Property(item => item.Qualite).HasColumnName("QUALITE");
            modelBuilder.Entity<OhCdNomEau>().ToTable("CD_NOM_EAU_OH","OH");
            modelBuilder.Entity<OhCdNomEau>().HasKey(item => new {item.Nom });
            modelBuilder.Entity<OhCdNomEau>().Property(item => item.Nom).IsRequired();
            modelBuilder.Entity<OhCdNomEau>().Property(item => item.Nom).HasMaxLength(60);
            modelBuilder.Entity<OhCdNomEau>().Property(item => item.Nom).HasColumnName("NOM");
            modelBuilder.Entity<OhHistoNote>().ToTable("HISTO_NOTE_OH","OH");
            modelBuilder.Entity<OhHistoNote>().HasKey(item => new {item.DscOhNumOh,item.DateNote });
            modelBuilder.Entity<OhHistoNote>().Property(item => item.DscOhNumOh).IsRequired();
            modelBuilder.Entity<OhHistoNote>().Property(item => item.DscOhNumOh).HasMaxLength(20);
            modelBuilder.Entity<OhHistoNote>().Property(item => item.DscOhNumOh).HasColumnName("DSC_OH__NUM_OH");
            modelBuilder.Entity<OhHistoNote>().Property(item => item.DateNote).IsRequired();
            modelBuilder.Entity<OhHistoNote>().Property(item => item.DateNote).HasColumnName("DATE_NOTE");
            modelBuilder.Entity<OhHistoNote>().Property(item => item.CdOriginOhOrigine).IsRequired();
            modelBuilder.Entity<OhHistoNote>().Property(item => item.CdOriginOhOrigine).HasMaxLength(20);
            modelBuilder.Entity<OhHistoNote>().Property(item => item.CdOriginOhOrigine).HasColumnName("CD_ORIGIN_OH__ORIGINE");
            modelBuilder.Entity<OhHistoNote>().Property(item => item.Note1).HasColumnName("NOTE1");
            modelBuilder.Entity<OhHistoNote>().Property(item => item.Note2).HasColumnName("NOTE2");
            modelBuilder.Entity<OhHistoNote>().Property(item => item.Note3).HasColumnName("NOTE3");
            modelBuilder.Entity<OhHistoNote>().Property(item => item.Note4).HasColumnName("NOTE4");
            modelBuilder.Entity<OhHistoNote>().Property(item => item.Note5).HasColumnName("NOTE5");
            modelBuilder.Entity<OhHistoNote>().Property(item => item.Urgence).HasMaxLength(5);
            modelBuilder.Entity<OhHistoNote>().Property(item => item.Urgence).HasColumnName("URGENCE");
            modelBuilder.Entity<OhHistoNote>().Property(item => item.Securite).HasColumnName("SECURITE");
            modelBuilder.Entity<OhHistoNote>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<OhCdOrigin>().ToTable("CD_ORIGIN_OH","OH");
            modelBuilder.Entity<OhCdOrigin>().HasKey(item => new {item.Origine });
            modelBuilder.Entity<OhCdOrigin>().Property(item => item.Origine).IsRequired();
            modelBuilder.Entity<OhCdOrigin>().Property(item => item.Origine).HasMaxLength(20);
            modelBuilder.Entity<OhCdOrigin>().Property(item => item.Origine).HasColumnName("ORIGINE");
            modelBuilder.Entity<OhDictionnaire>().ToTable("DICTIONNAIRE_OH","OH");
            modelBuilder.Entity<OhDictionnaire>().HasKey(item => new {item.Nom });
            modelBuilder.Entity<OhDictionnaire>().Property(item => item.Nom).IsRequired();
            modelBuilder.Entity<OhDictionnaire>().Property(item => item.Nom).HasMaxLength(100);
            modelBuilder.Entity<OhDictionnaire>().Property(item => item.Nom).HasColumnName("NOM");
            modelBuilder.Entity<OhDictionnaire>().Property(item => item.Description).HasMaxLength(255);
            modelBuilder.Entity<OhDictionnaire>().Property(item => item.Description).HasColumnName("DESCRIPTION");
            modelBuilder.Entity<OhDictionnaire>().Property(item => item.Definition).HasMaxLength(500);
            modelBuilder.Entity<OhDictionnaire>().Property(item => item.Definition).HasColumnName("DEFINITION");
            modelBuilder.Entity<OhDictionnaire>().Property(item => item.Motscles).HasMaxLength(255);
            modelBuilder.Entity<OhDictionnaire>().Property(item => item.Motscles).HasColumnName("MOTSCLES");
            modelBuilder.Entity<OhCdEvt>().ToTable("CD_EVT_OH","OH");
            modelBuilder.Entity<OhCdEvt>().HasKey(item => new {item.Type });
            modelBuilder.Entity<OhCdEvt>().Property(item => item.Type).IsRequired();
            modelBuilder.Entity<OhCdEvt>().Property(item => item.Type).HasMaxLength(25);
            modelBuilder.Entity<OhCdEvt>().Property(item => item.Type).HasColumnName("TYPE");
            modelBuilder.Entity<OhCdEvt>().Property(item => item.Impact).HasColumnName("IMPACT");
            modelBuilder.Entity<OhEvt>().ToTable("EVT_OH","OH");
            modelBuilder.Entity<OhEvt>().HasKey(item => new {item.CdEvtOhType,item.DscOhNumOh,item.DateRel });
            modelBuilder.Entity<OhEvt>().Property(item => item.CdEvtOhType).IsRequired();
            modelBuilder.Entity<OhEvt>().Property(item => item.CdEvtOhType).HasMaxLength(25);
            modelBuilder.Entity<OhEvt>().Property(item => item.CdEvtOhType).HasColumnName("CD_EVT_OH__TYPE");
            modelBuilder.Entity<OhEvt>().Property(item => item.DscOhNumOh).IsRequired();
            modelBuilder.Entity<OhEvt>().Property(item => item.DscOhNumOh).HasMaxLength(20);
            modelBuilder.Entity<OhEvt>().Property(item => item.DscOhNumOh).HasColumnName("DSC_OH__NUM_OH");
            modelBuilder.Entity<OhEvt>().Property(item => item.DateRel).IsRequired();
            modelBuilder.Entity<OhEvt>().Property(item => item.DateRel).HasColumnName("DATE_REL");
            modelBuilder.Entity<OhEvt>().Property(item => item.DateTrt).HasColumnName("DATE_TRT");
            modelBuilder.Entity<OhEvt>().Property(item => item.Obsv).HasMaxLength(255);
            modelBuilder.Entity<OhEvt>().Property(item => item.Obsv).HasColumnName("OBSV");
            modelBuilder.Entity<OhCdTeteAm>().ToTable("CD_TETE_AM_OH","OH");
            modelBuilder.Entity<OhCdTeteAm>().HasKey(item => new {item.TeteAm });
            modelBuilder.Entity<OhCdTeteAm>().Property(item => item.TeteAm).IsRequired();
            modelBuilder.Entity<OhCdTeteAm>().Property(item => item.TeteAm).HasMaxLength(60);
            modelBuilder.Entity<OhCdTeteAm>().Property(item => item.TeteAm).HasColumnName("TETE_AM");
            modelBuilder.Entity<OhCdTeteAv>().ToTable("CD_TETE_AV_OH","OH");
            modelBuilder.Entity<OhCdTeteAv>().HasKey(item => new {item.TeteAv });
            modelBuilder.Entity<OhCdTeteAv>().Property(item => item.TeteAv).IsRequired();
            modelBuilder.Entity<OhCdTeteAv>().Property(item => item.TeteAv).HasMaxLength(60);
            modelBuilder.Entity<OhCdTeteAv>().Property(item => item.TeteAv).HasColumnName("TETE_AV");
            modelBuilder.Entity<OhCdEntete>().ToTable("CD_ENTETE_OH","OH");
            modelBuilder.Entity<OhCdEntete>().HasKey(item => new {item.IdEntete });
            modelBuilder.Entity<OhCdEntete>().Property(item => item.IdEntete).IsRequired();
            modelBuilder.Entity<OhCdEntete>().Property(item => item.IdEntete).HasColumnName("ID_ENTETE");
            modelBuilder.Entity<OhCdEntete>().Property(item => item.CdComposantOhTypeComp).IsRequired();
            modelBuilder.Entity<OhCdEntete>().Property(item => item.CdComposantOhTypeComp).HasMaxLength(6);
            modelBuilder.Entity<OhCdEntete>().Property(item => item.CdComposantOhTypeComp).HasColumnName("CD_COMPOSANT_OH__TYPE_COMP");
            modelBuilder.Entity<OhCdEntete>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<OhCdEntete>().Property(item => item.Libelle).HasMaxLength(500);
            modelBuilder.Entity<OhCdEntete>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<OhCdEntete>().Property(item => item.OrdreEnt).IsRequired();
            modelBuilder.Entity<OhCdEntete>().Property(item => item.OrdreEnt).HasColumnName("ORDRE_ENT");
            modelBuilder.Entity<OhCdEntete>().Property(item => item.Guide).HasMaxLength(500);
            modelBuilder.Entity<OhCdEntete>().Property(item => item.Guide).HasColumnName("GUIDE");
            modelBuilder.Entity<OhCdChapitre>().ToTable("CD_CHAPITRE_OH","OH");
            modelBuilder.Entity<OhCdChapitre>().HasKey(item => new {item.IdChap });
            modelBuilder.Entity<OhCdChapitre>().Property(item => item.IdChap).IsRequired();
            modelBuilder.Entity<OhCdChapitre>().Property(item => item.IdChap).HasColumnName("ID_CHAP");
            modelBuilder.Entity<OhCdChapitre>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<OhCdChapitre>().Property(item => item.Libelle).HasMaxLength(500);
            modelBuilder.Entity<OhCdChapitre>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<OhCdChapitre>().Property(item => item.OrdreChap).IsRequired();
            modelBuilder.Entity<OhCdChapitre>().Property(item => item.OrdreChap).HasColumnName("ORDRE_CHAP");
            modelBuilder.Entity<OhCdChapitre>().Property(item => item.Ponderation).HasColumnName("PONDERATION");
            modelBuilder.Entity<OhCdLigne>().ToTable("CD_LIGNE_OH","OH");
            modelBuilder.Entity<OhCdLigne>().HasKey(item => new {item.CdChapitreOhIdChap,item.IdLigne });
            modelBuilder.Entity<OhCdLigne>().Property(item => item.CdChapitreOhIdChap).IsRequired();
            modelBuilder.Entity<OhCdLigne>().Property(item => item.CdChapitreOhIdChap).HasColumnName("CD_CHAPITRE_OH__ID_CHAP");
            modelBuilder.Entity<OhCdLigne>().Property(item => item.IdLigne).IsRequired();
            modelBuilder.Entity<OhCdLigne>().Property(item => item.IdLigne).HasColumnName("ID_LIGNE");
            modelBuilder.Entity<OhCdLigne>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<OhCdLigne>().Property(item => item.Libelle).HasMaxLength(500);
            modelBuilder.Entity<OhCdLigne>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<OhCdLigne>().Property(item => item.OrdreLigne).IsRequired();
            modelBuilder.Entity<OhCdLigne>().Property(item => item.OrdreLigne).HasColumnName("ORDRE_LIGNE");
            modelBuilder.Entity<OhEntete>().ToTable("ENTETE_OH","OH");
            modelBuilder.Entity<OhEntete>().HasKey(item => new {item.CampOhIdCamp,item.DscOhNumOh,item.CdEnteteOhIdEntete });
            modelBuilder.Entity<OhEntete>().Property(item => item.CampOhIdCamp).IsRequired();
            modelBuilder.Entity<OhEntete>().Property(item => item.CampOhIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OhEntete>().Property(item => item.CampOhIdCamp).HasColumnName("CAMP_OH__ID_CAMP");
            modelBuilder.Entity<OhEntete>().Property(item => item.DscOhNumOh).IsRequired();
            modelBuilder.Entity<OhEntete>().Property(item => item.DscOhNumOh).HasMaxLength(20);
            modelBuilder.Entity<OhEntete>().Property(item => item.DscOhNumOh).HasColumnName("DSC_OH__NUM_OH");
            modelBuilder.Entity<OhEntete>().Property(item => item.CdEnteteOhIdEntete).IsRequired();
            modelBuilder.Entity<OhEntete>().Property(item => item.CdEnteteOhIdEntete).HasColumnName("CD_ENTETE_OH__ID_ENTETE");
            modelBuilder.Entity<OhEntete>().Property(item => item.Valeur).HasMaxLength(250);
            modelBuilder.Entity<OhEntete>().Property(item => item.Valeur).HasColumnName("VALEUR");
            modelBuilder.Entity<OhContact>().ToTable("CONTACT_OH","OH");
            modelBuilder.Entity<OhContact>().HasKey(item => new {item.DocOhId });
            modelBuilder.Entity<OhContact>().Property(item => item.DocOhId).IsRequired();
            modelBuilder.Entity<OhContact>().Property(item => item.DocOhId).HasColumnName("DOC_OH__ID");
            modelBuilder.Entity<OhContact>().Property(item => item.Givenname).HasMaxLength(60);
            modelBuilder.Entity<OhContact>().Property(item => item.Givenname).HasColumnName("GIVENNAME");
            modelBuilder.Entity<OhContact>().Property(item => item.Sn).HasMaxLength(60);
            modelBuilder.Entity<OhContact>().Property(item => item.Sn).HasColumnName("SN");
            modelBuilder.Entity<OhContact>().Property(item => item.Cn).HasMaxLength(125);
            modelBuilder.Entity<OhContact>().Property(item => item.Cn).HasColumnName("CN");
            modelBuilder.Entity<OhContact>().Property(item => item.O).HasMaxLength(60);
            modelBuilder.Entity<OhContact>().Property(item => item.O).HasColumnName("O");
            modelBuilder.Entity<OhContact>().Property(item => item.Mail).HasMaxLength(60);
            modelBuilder.Entity<OhContact>().Property(item => item.Mail).HasColumnName("MAIL");
            modelBuilder.Entity<OhContact>().Property(item => item.Telephonenumber).HasMaxLength(20);
            modelBuilder.Entity<OhContact>().Property(item => item.Telephonenumber).HasColumnName("TELEPHONENUMBER");
            modelBuilder.Entity<OhContact>().Property(item => item.Mobile).HasMaxLength(20);
            modelBuilder.Entity<OhContact>().Property(item => item.Mobile).HasColumnName("MOBILE");
            modelBuilder.Entity<OhContact>().Property(item => item.Facsimiletelephonenumber).HasMaxLength(20);
            modelBuilder.Entity<OhContact>().Property(item => item.Facsimiletelephonenumber).HasColumnName("FACSIMILETELEPHONENUMBER");
            modelBuilder.Entity<OhContact>().Property(item => item.Street).HasMaxLength(60);
            modelBuilder.Entity<OhContact>().Property(item => item.Street).HasColumnName("STREET");
            modelBuilder.Entity<OhContact>().Property(item => item.Mozillaworkstreet2).HasMaxLength(60);
            modelBuilder.Entity<OhContact>().Property(item => item.Mozillaworkstreet2).HasColumnName("MOZILLAWORKSTREET2");
            modelBuilder.Entity<OhContact>().Property(item => item.L).HasMaxLength(60);
            modelBuilder.Entity<OhContact>().Property(item => item.L).HasColumnName("L");
            modelBuilder.Entity<OhContact>().Property(item => item.Postalcode).HasMaxLength(12);
            modelBuilder.Entity<OhContact>().Property(item => item.Postalcode).HasColumnName("POSTALCODE");
            modelBuilder.Entity<OhContact>().Property(item => item.Modifytimestamp).HasColumnName("MODIFYTIMESTAMP");
            modelBuilder.Entity<OhCdComposant>().ToTable("CD_COMPOSANT_OH","OH");
            modelBuilder.Entity<OhCdComposant>().HasKey(item => new {item.TypeComp });
            modelBuilder.Entity<OhCdComposant>().Property(item => item.TypeComp).IsRequired();
            modelBuilder.Entity<OhCdComposant>().Property(item => item.TypeComp).HasMaxLength(6);
            modelBuilder.Entity<OhCdComposant>().Property(item => item.TypeComp).HasColumnName("TYPE_COMP");
            modelBuilder.Entity<OhCdComposant>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<OhCdComposant>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<OhInspecteur>().ToTable("INSPECTEUR_OH","OH");
            modelBuilder.Entity<OhInspecteur>().HasKey(item => new {item.Nom });
            modelBuilder.Entity<OhInspecteur>().Property(item => item.Nom).IsRequired();
            modelBuilder.Entity<OhInspecteur>().Property(item => item.Nom).HasMaxLength(60);
            modelBuilder.Entity<OhInspecteur>().Property(item => item.Nom).HasColumnName("NOM");
            modelBuilder.Entity<OhInspecteur>().Property(item => item.CdPrestaOhPrestataire).IsRequired();
            modelBuilder.Entity<OhInspecteur>().Property(item => item.CdPrestaOhPrestataire).HasMaxLength(50);
            modelBuilder.Entity<OhInspecteur>().Property(item => item.CdPrestaOhPrestataire).HasColumnName("CD_PRESTA_OH__PRESTATAIRE");
            modelBuilder.Entity<OhInspecteur>().Property(item => item.Fonc).HasMaxLength(60);
            modelBuilder.Entity<OhInspecteur>().Property(item => item.Fonc).HasColumnName("FONC");
            modelBuilder.Entity<OhCdUnite>().ToTable("CD_UNITE_OH","OH");
            modelBuilder.Entity<OhCdUnite>().HasKey(item => new {item.Unite });
            modelBuilder.Entity<OhCdUnite>().Property(item => item.Unite).IsRequired();
            modelBuilder.Entity<OhCdUnite>().Property(item => item.Unite).HasMaxLength(12);
            modelBuilder.Entity<OhCdUnite>().Property(item => item.Unite).HasColumnName("UNITE");
            modelBuilder.Entity<OhCdMo>().ToTable("CD_MO_OH","OH");
            modelBuilder.Entity<OhCdMo>().HasKey(item => new {item.Mo });
            modelBuilder.Entity<OhCdMo>().Property(item => item.Mo).IsRequired();
            modelBuilder.Entity<OhCdMo>().Property(item => item.Mo).HasMaxLength(60);
            modelBuilder.Entity<OhCdMo>().Property(item => item.Mo).HasColumnName("MO");
            modelBuilder.Entity<OhCdConclusion>().ToTable("CD_CONCLUSION_OH","OH");
            modelBuilder.Entity<OhCdConclusion>().HasKey(item => new {item.IdConc });
            modelBuilder.Entity<OhCdConclusion>().Property(item => item.IdConc).IsRequired();
            modelBuilder.Entity<OhCdConclusion>().Property(item => item.IdConc).HasColumnName("ID_CONC");
            modelBuilder.Entity<OhCdConclusion>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<OhCdConclusion>().Property(item => item.Libelle).HasMaxLength(500);
            modelBuilder.Entity<OhCdConclusion>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<OhCdConclusion>().Property(item => item.Ordre).IsRequired();
            modelBuilder.Entity<OhCdConclusion>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<OhDscTemp>().ToTable("DSC_TEMP_OH","OH");
            modelBuilder.Entity<OhDscTemp>().HasKey(item => new {item.CampOhIdCamp,item.NumOh });
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CampOhIdCamp).IsRequired();
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CampOhIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CampOhIdCamp).HasColumnName("CAMP_OH__ID_CAMP");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.NumOh).IsRequired();
            modelBuilder.Entity<OhDscTemp>().Property(item => item.NumOh).HasMaxLength(20);
            modelBuilder.Entity<OhDscTemp>().Property(item => item.NumOh).HasColumnName("NUM_OH");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdProAmOhProtect).HasMaxLength(60);
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdProAmOhProtect).HasColumnName("CD_PRO_AM_OH__PROTECT");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdOuvOhOuv).HasMaxLength(60);
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdOuvOhOuv).HasColumnName("CD_OUV_OH__OUV");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdExtOhType).HasMaxLength(60);
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdExtOhType).HasColumnName("CD_EXT_OH__TYPE");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.DscOhNumOh).HasMaxLength(20);
            modelBuilder.Entity<OhDscTemp>().Property(item => item.DscOhNumOh).HasColumnName("DSC_OH__NUM_OH");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdTeteAmOhTeteAm).HasMaxLength(60);
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdTeteAmOhTeteAm).HasColumnName("CD_TETE_AM_OH__TETE_AM");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdNomEauOhNom).HasMaxLength(60);
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdNomEauOhNom).HasColumnName("CD_NOM_EAU_OH__NOM");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdTypeOhType).IsRequired();
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdTypeOhType).HasMaxLength(60);
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdTypeOhType).HasColumnName("CD_TYPE_OH__TYPE");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdEauOhEau).HasMaxLength(60);
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdEauOhEau).HasColumnName("CD_EAU_OH__EAU");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdEcoulOhEcoul).HasMaxLength(60);
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdEcoulOhEcoul).HasColumnName("CD_ECOUL_OH__ECOUL");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdMatOhCode).HasMaxLength(60);
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdMatOhCode).HasColumnName("CD_MAT_OH__CODE");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdTeteAvOhTeteAv).HasMaxLength(60);
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdTeteAvOhTeteAv).HasColumnName("CD_TETE_AV_OH__TETE_AV");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdMoOhMo).HasMaxLength(60);
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdMoOhMo).HasColumnName("CD_MO_OH__MO");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdEntpOhEntreprise).HasMaxLength(60);
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdEntpOhEntreprise).HasColumnName("CD_ENTP_OH__ENTREPRISE");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdFamOhFamille).IsRequired();
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdFamOhFamille).HasMaxLength(20);
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdFamOhFamille).HasColumnName("CD_FAM_OH__FAMILLE");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdProAvOhProtect).HasMaxLength(60);
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdProAvOhProtect).HasColumnName("CD_PRO_AV_OH__PROTECT");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdSousTypeOhSousType).HasMaxLength(60);
            modelBuilder.Entity<OhDscTemp>().Property(item => item.CdSousTypeOhSousType).HasColumnName("CD_SOUS_TYPE_OH__SOUS_TYPE");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Liaison).IsRequired();
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Liaison).HasMaxLength(15);
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Liaison).HasColumnName("LIAISON");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Sens).IsRequired();
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Sens).HasMaxLength(6);
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Sens).HasColumnName("SENS");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.AbsDeb).IsRequired();
            modelBuilder.Entity<OhDscTemp>().Property(item => item.AbsDeb).HasColumnName("ABS_DEB");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.AbsFin).HasColumnName("ABS_FIN");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.NumExploit).HasMaxLength(30);
            modelBuilder.Entity<OhDscTemp>().Property(item => item.NumExploit).HasColumnName("NUM_EXPLOIT");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.DateMs).HasColumnName("DATE_MS");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Longueur).HasColumnName("LONGUEUR");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Hauteur).HasColumnName("HAUTEUR");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Biais).HasColumnName("BIAIS");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Pente).HasColumnName("PENTE");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Portee).HasColumnName("PORTEE");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Jum).HasColumnName("JUM");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Elem).HasColumnName("ELEM");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Regard).HasColumnName("REGARD");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Perche).HasColumnName("PERCHE");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Vulnerable).HasColumnName("VULNERABLE");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Faune).HasColumnName("FAUNE");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Loi).HasColumnName("LOI");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Phe).HasColumnName("PHE");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Debit).HasColumnName("DEBIT");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.OuvAval).HasMaxLength(200);
            modelBuilder.Entity<OhDscTemp>().Property(item => item.OuvAval).HasColumnName("OUV_AVAL");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Note1).HasColumnName("NOTE1");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Note2).HasColumnName("NOTE2");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Note3).HasColumnName("NOTE3");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Note4).HasColumnName("NOTE4");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Note5).HasColumnName("NOTE5");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Urgence).HasMaxLength(5);
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Urgence).HasColumnName("URGENCE");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.DescInva).HasMaxLength(1000);
            modelBuilder.Entity<OhDscTemp>().Property(item => item.DescInva).HasColumnName("DESC_INVA");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Securite).HasColumnName("SECURITE");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.ProsurvAnnee).HasColumnName("PROSURV_ANNEE");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.DernInsp).HasColumnName("DERN_INSP");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.DernVst).HasColumnName("DERN_VST");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.NoteVst).HasMaxLength(5);
            modelBuilder.Entity<OhDscTemp>().Property(item => item.NoteVst).HasColumnName("NOTE_VST");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Archive).HasMaxLength(255);
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Archive).HasColumnName("ARCHIVE");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Commentaire).HasMaxLength(1000);
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.X1).HasColumnName("X1");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Y1).HasColumnName("Y1");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Z1).HasColumnName("Z1");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.X2).HasColumnName("X2");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Y2).HasColumnName("Y2");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Z2).HasColumnName("Z2");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.DateReleve).HasColumnName("DATE_RELEVE");
            modelBuilder.Entity<OhDscTemp>().Property(item => item.Terrain).HasColumnName("TERRAIN");
            modelBuilder.Entity<OhInspTmp>().ToTable("INSP_TMP_OH","OH");
            modelBuilder.Entity<OhInspTmp>().HasKey(item => new {item.CampOhIdCamp,item.DscTempOhNumOh });
            modelBuilder.Entity<OhInspTmp>().Property(item => item.CampOhIdCamp).IsRequired();
            modelBuilder.Entity<OhInspTmp>().Property(item => item.CampOhIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OhInspTmp>().Property(item => item.CampOhIdCamp).HasColumnName("CAMP_OH__ID_CAMP");
            modelBuilder.Entity<OhInspTmp>().Property(item => item.DscTempOhNumOh).IsRequired();
            modelBuilder.Entity<OhInspTmp>().Property(item => item.DscTempOhNumOh).HasMaxLength(20);
            modelBuilder.Entity<OhInspTmp>().Property(item => item.DscTempOhNumOh).HasColumnName("DSC_TEMP_OH__NUM_OH");
            modelBuilder.Entity<OhInspTmp>().Property(item => item.InspecteurOhNom).HasMaxLength(60);
            modelBuilder.Entity<OhInspTmp>().Property(item => item.InspecteurOhNom).HasColumnName("INSPECTEUR_OH__NOM");
            modelBuilder.Entity<OhInspTmp>().Property(item => item.CdEtudeOhEtude).HasMaxLength(65);
            modelBuilder.Entity<OhInspTmp>().Property(item => item.CdEtudeOhEtude).HasColumnName("CD_ETUDE_OH__ETUDE");
            modelBuilder.Entity<OhInspTmp>().Property(item => item.CdMeteoOhMeteo).HasMaxLength(60);
            modelBuilder.Entity<OhInspTmp>().Property(item => item.CdMeteoOhMeteo).HasColumnName("CD_METEO_OH__METEO");
            modelBuilder.Entity<OhInspTmp>().Property(item => item.Etat).IsRequired();
            modelBuilder.Entity<OhInspTmp>().Property(item => item.Etat).HasMaxLength(25);
            modelBuilder.Entity<OhInspTmp>().Property(item => item.Etat).HasColumnName("ETAT");
            modelBuilder.Entity<OhInspTmp>().Property(item => item.Datev).HasColumnName("DATEV");
            modelBuilder.Entity<OhInspTmp>().Property(item => item.Temperature).HasColumnName("TEMPERATURE");
            modelBuilder.Entity<OhInspTmp>().Property(item => item.Moyen).HasMaxLength(500);
            modelBuilder.Entity<OhInspTmp>().Property(item => item.Moyen).HasColumnName("MOYEN");
            modelBuilder.Entity<OhInspTmp>().Property(item => item.Conditions).HasMaxLength(500);
            modelBuilder.Entity<OhInspTmp>().Property(item => item.Conditions).HasColumnName("CONDITIONS");
            modelBuilder.Entity<OhInspTmp>().Property(item => item.NomValid).HasMaxLength(250);
            modelBuilder.Entity<OhInspTmp>().Property(item => item.NomValid).HasColumnName("NOM_VALID");
            modelBuilder.Entity<OhInspTmp>().Property(item => item.DateValid).HasColumnName("DATE_VALID");
            modelBuilder.Entity<OhInspTmp>().Property(item => item.DescInva).HasMaxLength(1000);
            modelBuilder.Entity<OhInspTmp>().Property(item => item.DescInva).HasColumnName("DESC_INVA");
            modelBuilder.Entity<OhInspTmp>().Property(item => item.Prioritaire).HasMaxLength(1000);
            modelBuilder.Entity<OhInspTmp>().Property(item => item.Prioritaire).HasColumnName("PRIORITAIRE");
            modelBuilder.Entity<OhInspTmp>().Property(item => item.Securite).HasMaxLength(1000);
            modelBuilder.Entity<OhInspTmp>().Property(item => item.Securite).HasColumnName("SECURITE");
            modelBuilder.Entity<OhInspTmp>().Property(item => item.Note1).HasColumnName("NOTE1");
            modelBuilder.Entity<OhInspTmp>().Property(item => item.Note2).HasColumnName("NOTE2");
            modelBuilder.Entity<OhInspTmp>().Property(item => item.Note3).HasColumnName("NOTE3");
            modelBuilder.Entity<OhInspTmp>().Property(item => item.Note4).HasColumnName("NOTE4");
            modelBuilder.Entity<OhInspTmp>().Property(item => item.Note5).HasColumnName("NOTE5");
            modelBuilder.Entity<OhInspTmp>().Property(item => item.Urgence).HasMaxLength(5);
            modelBuilder.Entity<OhInspTmp>().Property(item => item.Urgence).HasColumnName("URGENCE");
            modelBuilder.Entity<OhInspTmp>().Property(item => item.Qualite).HasMaxLength(25);
            modelBuilder.Entity<OhInspTmp>().Property(item => item.Qualite).HasColumnName("QUALITE");
            modelBuilder.Entity<OhEltInspTmp>().ToTable("ELT_INSP_TMP_OH","OH");
            modelBuilder.Entity<OhEltInspTmp>().HasKey(item => new {item.CampOhIdCamp,item.DscTempOhNumOh,item.GrpOhIdGrp,item.PrtOhIdPrt,item.SprtOhIdSprt,item.EltOhIdElem });
            modelBuilder.Entity<OhEltInspTmp>().Property(item => item.CampOhIdCamp).IsRequired();
            modelBuilder.Entity<OhEltInspTmp>().Property(item => item.CampOhIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OhEltInspTmp>().Property(item => item.CampOhIdCamp).HasColumnName("CAMP_OH__ID_CAMP");
            modelBuilder.Entity<OhEltInspTmp>().Property(item => item.DscTempOhNumOh).IsRequired();
            modelBuilder.Entity<OhEltInspTmp>().Property(item => item.DscTempOhNumOh).HasMaxLength(20);
            modelBuilder.Entity<OhEltInspTmp>().Property(item => item.DscTempOhNumOh).HasColumnName("DSC_TEMP_OH__NUM_OH");
            modelBuilder.Entity<OhEltInspTmp>().Property(item => item.GrpOhIdGrp).IsRequired();
            modelBuilder.Entity<OhEltInspTmp>().Property(item => item.GrpOhIdGrp).HasColumnName("GRP_OH__ID_GRP");
            modelBuilder.Entity<OhEltInspTmp>().Property(item => item.PrtOhIdPrt).IsRequired();
            modelBuilder.Entity<OhEltInspTmp>().Property(item => item.PrtOhIdPrt).HasColumnName("PRT_OH__ID_PRT");
            modelBuilder.Entity<OhEltInspTmp>().Property(item => item.SprtOhIdSprt).IsRequired();
            modelBuilder.Entity<OhEltInspTmp>().Property(item => item.SprtOhIdSprt).HasColumnName("SPRT_OH__ID_SPRT");
            modelBuilder.Entity<OhEltInspTmp>().Property(item => item.EltOhIdElem).IsRequired();
            modelBuilder.Entity<OhEltInspTmp>().Property(item => item.EltOhIdElem).HasColumnName("ELT_OH__ID_ELEM");
            modelBuilder.Entity<OhEltInspTmp>().Property(item => item.Indice).IsRequired();
            modelBuilder.Entity<OhEltInspTmp>().Property(item => item.Indice).HasColumnName("INDICE");
            modelBuilder.Entity<OhEltInspTmp>().Property(item => item.Obs).HasMaxLength(255);
            modelBuilder.Entity<OhEltInspTmp>().Property(item => item.Obs).HasColumnName("OBS");
            modelBuilder.Entity<OhPhotoEltInspTmp>().ToTable("PHOTO_ELT_INSP_TMP_OH","OH");
            modelBuilder.Entity<OhPhotoEltInspTmp>().HasKey(item => new {item.GrpOhIdGrp,item.PrtOhIdPrt,item.SprtOhIdSprt,item.CampOhIdCamp,item.DscTempOhNumOh,item.EltOhIdElem,item.Id });
            modelBuilder.Entity<OhPhotoEltInspTmp>().Property(item => item.GrpOhIdGrp).IsRequired();
            modelBuilder.Entity<OhPhotoEltInspTmp>().Property(item => item.GrpOhIdGrp).HasColumnName("GRP_OH__ID_GRP");
            modelBuilder.Entity<OhPhotoEltInspTmp>().Property(item => item.PrtOhIdPrt).IsRequired();
            modelBuilder.Entity<OhPhotoEltInspTmp>().Property(item => item.PrtOhIdPrt).HasColumnName("PRT_OH__ID_PRT");
            modelBuilder.Entity<OhPhotoEltInspTmp>().Property(item => item.SprtOhIdSprt).IsRequired();
            modelBuilder.Entity<OhPhotoEltInspTmp>().Property(item => item.SprtOhIdSprt).HasColumnName("SPRT_OH__ID_SPRT");
            modelBuilder.Entity<OhPhotoEltInspTmp>().Property(item => item.CampOhIdCamp).IsRequired();
            modelBuilder.Entity<OhPhotoEltInspTmp>().Property(item => item.CampOhIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OhPhotoEltInspTmp>().Property(item => item.CampOhIdCamp).HasColumnName("CAMP_OH__ID_CAMP");
            modelBuilder.Entity<OhPhotoEltInspTmp>().Property(item => item.DscTempOhNumOh).IsRequired();
            modelBuilder.Entity<OhPhotoEltInspTmp>().Property(item => item.DscTempOhNumOh).HasMaxLength(20);
            modelBuilder.Entity<OhPhotoEltInspTmp>().Property(item => item.DscTempOhNumOh).HasColumnName("DSC_TEMP_OH__NUM_OH");
            modelBuilder.Entity<OhPhotoEltInspTmp>().Property(item => item.EltOhIdElem).IsRequired();
            modelBuilder.Entity<OhPhotoEltInspTmp>().Property(item => item.EltOhIdElem).HasColumnName("ELT_OH__ID_ELEM");
            modelBuilder.Entity<OhPhotoEltInspTmp>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<OhPhotoEltInspTmp>().Property(item => item.Id).HasMaxLength(50);
            modelBuilder.Entity<OhPhotoEltInspTmp>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<OhPhotoEltInspTmp>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<OhPhotoEltInspTmp>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<OhPhotoInspTmp>().ToTable("PHOTO_INSP_TMP_OH","OH");
            modelBuilder.Entity<OhPhotoInspTmp>().HasKey(item => new {item.Id });
            modelBuilder.Entity<OhPhotoInspTmp>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<OhPhotoInspTmp>().Property(item => item.Id).HasMaxLength(30);
            modelBuilder.Entity<OhPhotoInspTmp>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<OhPhotoInspTmp>().Property(item => item.CampOhIdCamp).IsRequired();
            modelBuilder.Entity<OhPhotoInspTmp>().Property(item => item.CampOhIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OhPhotoInspTmp>().Property(item => item.CampOhIdCamp).HasColumnName("CAMP_OH__ID_CAMP");
            modelBuilder.Entity<OhPhotoInspTmp>().Property(item => item.DscTempOhNumOh).IsRequired();
            modelBuilder.Entity<OhPhotoInspTmp>().Property(item => item.DscTempOhNumOh).HasMaxLength(20);
            modelBuilder.Entity<OhPhotoInspTmp>().Property(item => item.DscTempOhNumOh).HasColumnName("DSC_TEMP_OH__NUM_OH");
            modelBuilder.Entity<OhPhotoInspTmp>().Property(item => item.Commentaire).HasMaxLength(100);
            modelBuilder.Entity<OhPhotoInspTmp>().Property(item => item.Commentaire).HasColumnName("COMMENTAIRE");
            modelBuilder.Entity<OhClsDoc>().ToTable("CLS_DOC_OH","OH");
            modelBuilder.Entity<OhClsDoc>().HasKey(item => new {item.ClsOhId,item.DocOhId });
            modelBuilder.Entity<OhClsDoc>().Property(item => item.ClsOhId).IsRequired();
            modelBuilder.Entity<OhClsDoc>().Property(item => item.ClsOhId).HasColumnName("CLS_OH__ID");
            modelBuilder.Entity<OhClsDoc>().Property(item => item.DocOhId).IsRequired();
            modelBuilder.Entity<OhClsDoc>().Property(item => item.DocOhId).HasColumnName("DOC_OH__ID");
            modelBuilder.Entity<OhClsDoc>().Property(item => item.Defaut).HasColumnName("DEFAUT");
            modelBuilder.Entity<OhClsDoc>().Property(item => item.Dossier).HasMaxLength(15);
            modelBuilder.Entity<OhClsDoc>().Property(item => item.Dossier).HasColumnName("DOSSIER");
            modelBuilder.Entity<OhCdConclusionInsp>().ToTable("CD_CONCLUSION__INSP_OH","OH");
            modelBuilder.Entity<OhCdConclusionInsp>().HasKey(item => new {item.CampOhIdCamp,item.DscOhNumOh,item.CdConclusionOhIdConc });
            modelBuilder.Entity<OhCdConclusionInsp>().Property(item => item.CampOhIdCamp).IsRequired();
            modelBuilder.Entity<OhCdConclusionInsp>().Property(item => item.CampOhIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OhCdConclusionInsp>().Property(item => item.CampOhIdCamp).HasColumnName("CAMP_OH__ID_CAMP");
            modelBuilder.Entity<OhCdConclusionInsp>().Property(item => item.DscOhNumOh).IsRequired();
            modelBuilder.Entity<OhCdConclusionInsp>().Property(item => item.DscOhNumOh).HasMaxLength(20);
            modelBuilder.Entity<OhCdConclusionInsp>().Property(item => item.DscOhNumOh).HasColumnName("DSC_OH__NUM_OH");
            modelBuilder.Entity<OhCdConclusionInsp>().Property(item => item.CdConclusionOhIdConc).IsRequired();
            modelBuilder.Entity<OhCdConclusionInsp>().Property(item => item.CdConclusionOhIdConc).HasColumnName("CD_CONCLUSION_OH__ID_CONC");
            modelBuilder.Entity<OhCdConclusionInsp>().Property(item => item.Contenu).HasMaxLength(1000);
            modelBuilder.Entity<OhCdConclusionInsp>().Property(item => item.Contenu).HasColumnName("CONTENU");
            modelBuilder.Entity<OhDscCamp>().ToTable("DSC_CAMP_OH","OH");
            modelBuilder.Entity<OhDscCamp>().HasKey(item => new {item.DscOhNumOh,item.CampOhIdCamp });
            modelBuilder.Entity<OhDscCamp>().Property(item => item.DscOhNumOh).IsRequired();
            modelBuilder.Entity<OhDscCamp>().Property(item => item.DscOhNumOh).HasMaxLength(20);
            modelBuilder.Entity<OhDscCamp>().Property(item => item.DscOhNumOh).HasColumnName("DSC_OH__NUM_OH");
            modelBuilder.Entity<OhDscCamp>().Property(item => item.CampOhIdCamp).IsRequired();
            modelBuilder.Entity<OhDscCamp>().Property(item => item.CampOhIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OhDscCamp>().Property(item => item.CampOhIdCamp).HasColumnName("CAMP_OH__ID_CAMP");
            modelBuilder.Entity<OhDscCamp>().Property(item => item.Realiser).HasColumnName("REALISER");
            modelBuilder.Entity<OhCdPrecoSprtVst>().ToTable("CD_PRECO__SPRT_VST_OH","OH");
            modelBuilder.Entity<OhCdPrecoSprtVst>().HasKey(item => new {item.CampOhIdCamp,item.DscOhNumOh,item.CdChapitreOhIdChap,item.CdLigneOhIdLigne,item.BpuOhIdBpu });
            modelBuilder.Entity<OhCdPrecoSprtVst>().Property(item => item.CampOhIdCamp).IsRequired();
            modelBuilder.Entity<OhCdPrecoSprtVst>().Property(item => item.CampOhIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OhCdPrecoSprtVst>().Property(item => item.CampOhIdCamp).HasColumnName("CAMP_OH__ID_CAMP");
            modelBuilder.Entity<OhCdPrecoSprtVst>().Property(item => item.DscOhNumOh).IsRequired();
            modelBuilder.Entity<OhCdPrecoSprtVst>().Property(item => item.DscOhNumOh).HasMaxLength(20);
            modelBuilder.Entity<OhCdPrecoSprtVst>().Property(item => item.DscOhNumOh).HasColumnName("DSC_OH__NUM_OH");
            modelBuilder.Entity<OhCdPrecoSprtVst>().Property(item => item.CdChapitreOhIdChap).IsRequired();
            modelBuilder.Entity<OhCdPrecoSprtVst>().Property(item => item.CdChapitreOhIdChap).HasColumnName("CD_CHAPITRE_OH__ID_CHAP");
            modelBuilder.Entity<OhCdPrecoSprtVst>().Property(item => item.CdLigneOhIdLigne).IsRequired();
            modelBuilder.Entity<OhCdPrecoSprtVst>().Property(item => item.CdLigneOhIdLigne).HasColumnName("CD_LIGNE_OH__ID_LIGNE");
            modelBuilder.Entity<OhCdPrecoSprtVst>().Property(item => item.BpuOhIdBpu).IsRequired();
            modelBuilder.Entity<OhCdPrecoSprtVst>().Property(item => item.BpuOhIdBpu).HasColumnName("BPU_OH__ID_BPU");
            modelBuilder.Entity<OhCdPrecoSprtVst>().Property(item => item.Realise).HasColumnName("REALISE");
            modelBuilder.Entity<OhCdConclusionInspTmp>().ToTable("CD_CONCLUSION__INSP_TMP_OH","OH");
            modelBuilder.Entity<OhCdConclusionInspTmp>().HasKey(item => new {item.CampOhIdCamp,item.DscTempOhNumOh,item.CdConclusionOhIdConc });
            modelBuilder.Entity<OhCdConclusionInspTmp>().Property(item => item.CampOhIdCamp).IsRequired();
            modelBuilder.Entity<OhCdConclusionInspTmp>().Property(item => item.CampOhIdCamp).HasMaxLength(100);
            modelBuilder.Entity<OhCdConclusionInspTmp>().Property(item => item.CampOhIdCamp).HasColumnName("CAMP_OH__ID_CAMP");
            modelBuilder.Entity<OhCdConclusionInspTmp>().Property(item => item.DscTempOhNumOh).IsRequired();
            modelBuilder.Entity<OhCdConclusionInspTmp>().Property(item => item.DscTempOhNumOh).HasMaxLength(20);
            modelBuilder.Entity<OhCdConclusionInspTmp>().Property(item => item.DscTempOhNumOh).HasColumnName("DSC_TEMP_OH__NUM_OH");
            modelBuilder.Entity<OhCdConclusionInspTmp>().Property(item => item.CdConclusionOhIdConc).IsRequired();
            modelBuilder.Entity<OhCdConclusionInspTmp>().Property(item => item.CdConclusionOhIdConc).HasColumnName("CD_CONCLUSION_OH__ID_CONC");
            modelBuilder.Entity<OhCdConclusionInspTmp>().Property(item => item.Contenu).HasMaxLength(1000);
            modelBuilder.Entity<OhCdConclusionInspTmp>().Property(item => item.Contenu).HasColumnName("CONTENU");
            modelBuilder.Entity<PrfBmUser>().ToTable("BM_USER","PRF");
            modelBuilder.Entity<PrfBmUser>().HasKey(item => new {item.Login });
            modelBuilder.Entity<PrfBmUser>().Property(item => item.Login).IsRequired();
            modelBuilder.Entity<PrfBmUser>().Property(item => item.Login).HasMaxLength(50);
            modelBuilder.Entity<PrfBmUser>().Property(item => item.Login).HasColumnName("LOGIN");
            modelBuilder.Entity<PrfBmUser>().Property(item => item.Nom).HasMaxLength(60);
            modelBuilder.Entity<PrfBmUser>().Property(item => item.Nom).HasColumnName("NOM");
            modelBuilder.Entity<PrfBmUser>().Property(item => item.Prenom).HasMaxLength(60);
            modelBuilder.Entity<PrfBmUser>().Property(item => item.Prenom).HasColumnName("PRENOM");
            modelBuilder.Entity<PrfBmUser>().Property(item => item.Passwords).HasMaxLength(100);
            modelBuilder.Entity<PrfBmUser>().Property(item => item.Passwords).HasColumnName("PASSWORDS");
            modelBuilder.Entity<PrfBmUser>().Property(item => item.FamDecInf).HasMaxLength(6);
            modelBuilder.Entity<PrfBmUser>().Property(item => item.FamDecInf).HasColumnName("FAM_DEC_INF");
            modelBuilder.Entity<PrfBmUser>().Property(item => item.CdDecInf).HasMaxLength(15);
            modelBuilder.Entity<PrfBmUser>().Property(item => item.CdDecInf).HasColumnName("CD_DEC_INF");
            modelBuilder.Entity<PrfBmSchema>().ToTable("BM_SCHEMA","PRF");
            modelBuilder.Entity<PrfBmSchema>().HasKey(item => new {item.Schema });
            modelBuilder.Entity<PrfBmSchema>().Property(item => item.Schema).IsRequired();
            modelBuilder.Entity<PrfBmSchema>().Property(item => item.Schema).HasMaxLength(20);
            modelBuilder.Entity<PrfBmSchema>().Property(item => item.Schema).HasColumnName("SCHEMA");
            modelBuilder.Entity<PrfBmSchema>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<PrfBmSchema>().Property(item => item.Libelle).HasMaxLength(200);
            modelBuilder.Entity<PrfBmSchema>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<PrfBmTable>().ToTable("BM_TABLE","PRF");
            modelBuilder.Entity<PrfBmTable>().HasKey(item => new {item.Nom });
            modelBuilder.Entity<PrfBmTable>().Property(item => item.Nom).IsRequired();
            modelBuilder.Entity<PrfBmTable>().Property(item => item.Nom).HasMaxLength(30);
            modelBuilder.Entity<PrfBmTable>().Property(item => item.Nom).HasColumnName("NOM");
            modelBuilder.Entity<PrfBmTable>().Property(item => item.BmSchemaSchema).IsRequired();
            modelBuilder.Entity<PrfBmTable>().Property(item => item.BmSchemaSchema).HasMaxLength(20);
            modelBuilder.Entity<PrfBmTable>().Property(item => item.BmSchemaSchema).HasColumnName("BM_SCHEMA__SCHEMA");
            modelBuilder.Entity<PrfBmTable>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<PrfBmTable>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<PrfBmTable>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<PrfBmProfil>().ToTable("BM_PROFIL","PRF");
            modelBuilder.Entity<PrfBmProfil>().HasKey(item => new {item.Profil });
            modelBuilder.Entity<PrfBmProfil>().Property(item => item.Profil).IsRequired();
            modelBuilder.Entity<PrfBmProfil>().Property(item => item.Profil).HasMaxLength(20);
            modelBuilder.Entity<PrfBmProfil>().Property(item => item.Profil).HasColumnName("PROFIL");
            modelBuilder.Entity<PrfBmProfil>().Property(item => item.BmSchemaSchema).IsRequired();
            modelBuilder.Entity<PrfBmProfil>().Property(item => item.BmSchemaSchema).HasMaxLength(20);
            modelBuilder.Entity<PrfBmProfil>().Property(item => item.BmSchemaSchema).HasColumnName("BM_SCHEMA__SCHEMA");
            modelBuilder.Entity<PrfBmProfil>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<PrfBmProfil>().Property(item => item.Libelle).HasMaxLength(60);
            modelBuilder.Entity<PrfBmProfil>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<PrfSysLang>().ToTable("SYS_LANG","PRF");
            modelBuilder.Entity<PrfSysLang>().HasKey(item => new {item.CodeApp,item.CodePrp });
            modelBuilder.Entity<PrfSysLang>().Property(item => item.CodeApp).IsRequired();
            modelBuilder.Entity<PrfSysLang>().Property(item => item.CodeApp).HasMaxLength(50);
            modelBuilder.Entity<PrfSysLang>().Property(item => item.CodeApp).HasColumnName("CODE_APP");
            modelBuilder.Entity<PrfSysLang>().Property(item => item.CodePrp).IsRequired();
            modelBuilder.Entity<PrfSysLang>().Property(item => item.CodePrp).HasMaxLength(1000);
            modelBuilder.Entity<PrfSysLang>().Property(item => item.CodePrp).HasColumnName("CODE_PRP");
            modelBuilder.Entity<PrfSysLang>().Property(item => item.ValPrp).HasMaxLength(1000);
            modelBuilder.Entity<PrfSysLang>().Property(item => item.ValPrp).HasColumnName("VAL_PRP");
            modelBuilder.Entity<PrfSysLang>().Property(item => item.SortTrad).HasColumnName("SORT_TRAD");
            modelBuilder.Entity<PrfBmParam>().ToTable("BM_PARAM","PRF");
            modelBuilder.Entity<PrfBmParam>().HasKey(item => new {item.Code });
            modelBuilder.Entity<PrfBmParam>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<PrfBmParam>().Property(item => item.Code).HasMaxLength(25);
            modelBuilder.Entity<PrfBmParam>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<PrfBmParam>().Property(item => item.Valeur).HasMaxLength(500);
            modelBuilder.Entity<PrfBmParam>().Property(item => item.Valeur).HasColumnName("VALEUR");
            modelBuilder.Entity<PrfBmProfilTable>().ToTable("BM_PROFIL_TABLE","PRF");
            modelBuilder.Entity<PrfBmProfilTable>().HasKey(item => new {item.BmProfilProfil,item.BmTableNom });
            modelBuilder.Entity<PrfBmProfilTable>().Property(item => item.BmProfilProfil).IsRequired();
            modelBuilder.Entity<PrfBmProfilTable>().Property(item => item.BmProfilProfil).HasMaxLength(20);
            modelBuilder.Entity<PrfBmProfilTable>().Property(item => item.BmProfilProfil).HasColumnName("BM_PROFIL__PROFIL");
            modelBuilder.Entity<PrfBmProfilTable>().Property(item => item.BmTableNom).IsRequired();
            modelBuilder.Entity<PrfBmProfilTable>().Property(item => item.BmTableNom).HasMaxLength(30);
            modelBuilder.Entity<PrfBmProfilTable>().Property(item => item.BmTableNom).HasColumnName("BM_TABLE__NOM");
            modelBuilder.Entity<PrfBmProfilTable>().Property(item => item.Ecrire).IsRequired();
            modelBuilder.Entity<PrfBmProfilTable>().Property(item => item.Ecrire).HasColumnName("ECRIRE");
            modelBuilder.Entity<PrfBmProfilTable>().Property(item => item.Importer).IsRequired();
            modelBuilder.Entity<PrfBmProfilTable>().Property(item => item.Importer).HasColumnName("IMPORTER");
            modelBuilder.Entity<PrfBmProfilTable>().Property(item => item.Afficher).HasColumnName("AFFICHER");
            modelBuilder.Entity<PrfBmUserProfil>().ToTable("BM_USER_PROFIL","PRF");
            modelBuilder.Entity<PrfBmUserProfil>().HasKey(item => new {item.BmUserLogin,item.BmProfilProfil });
            modelBuilder.Entity<PrfBmUserProfil>().Property(item => item.BmUserLogin).IsRequired();
            modelBuilder.Entity<PrfBmUserProfil>().Property(item => item.BmUserLogin).HasMaxLength(50);
            modelBuilder.Entity<PrfBmUserProfil>().Property(item => item.BmUserLogin).HasColumnName("BM_USER__LOGIN");
            modelBuilder.Entity<PrfBmUserProfil>().Property(item => item.BmProfilProfil).IsRequired();
            modelBuilder.Entity<PrfBmUserProfil>().Property(item => item.BmProfilProfil).HasMaxLength(20);
            modelBuilder.Entity<PrfBmUserProfil>().Property(item => item.BmProfilProfil).HasColumnName("BM_PROFIL__PROFIL");
            modelBuilder.Entity<MapinfoTbGroupe>().ToTable("TB_GROUPE","MAPINFO");
            modelBuilder.Entity<MapinfoTbGroupe>().HasKey(item => new {item.TbModeleModele,item.TbTemplateTpl,item.Groupe });
            modelBuilder.Entity<MapinfoTbGroupe>().Property(item => item.TbModeleModele).IsRequired();
            modelBuilder.Entity<MapinfoTbGroupe>().Property(item => item.TbModeleModele).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbGroupe>().Property(item => item.TbModeleModele).HasColumnName("TB_MODELE__MODELE");
            modelBuilder.Entity<MapinfoTbGroupe>().Property(item => item.TbTemplateTpl).IsRequired();
            modelBuilder.Entity<MapinfoTbGroupe>().Property(item => item.TbTemplateTpl).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbGroupe>().Property(item => item.TbTemplateTpl).HasColumnName("TB_TEMPLATE__TPL");
            modelBuilder.Entity<MapinfoTbGroupe>().Property(item => item.Groupe).IsRequired();
            modelBuilder.Entity<MapinfoTbGroupe>().Property(item => item.Groupe).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbGroupe>().Property(item => item.Groupe).HasColumnName("GROUPE");
            modelBuilder.Entity<MapinfoTbGroupe>().Property(item => item.Titre).IsRequired();
            modelBuilder.Entity<MapinfoTbGroupe>().Property(item => item.Titre).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbGroupe>().Property(item => item.Titre).HasColumnName("TITRE");
            modelBuilder.Entity<MapinfoTbGroupe>().Property(item => item.Rang).IsRequired();
            modelBuilder.Entity<MapinfoTbGroupe>().Property(item => item.Rang).HasColumnName("RANG");
            modelBuilder.Entity<MapinfoTbGroupe>().Property(item => item.Chemin).HasMaxLength(254);
            modelBuilder.Entity<MapinfoTbGroupe>().Property(item => item.Chemin).HasColumnName("CHEMIN");
            modelBuilder.Entity<MapinfoTbGroupe>().Property(item => item.Boardvisible).HasColumnName("BOARDVISIBLE");
            modelBuilder.Entity<MapinfoTbTemplate>().ToTable("TB_TEMPLATE","MAPINFO");
            modelBuilder.Entity<MapinfoTbTemplate>().HasKey(item => new {item.TbModeleModele,item.Tpl });
            modelBuilder.Entity<MapinfoTbTemplate>().Property(item => item.TbModeleModele).IsRequired();
            modelBuilder.Entity<MapinfoTbTemplate>().Property(item => item.TbModeleModele).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbTemplate>().Property(item => item.TbModeleModele).HasColumnName("TB_MODELE__MODELE");
            modelBuilder.Entity<MapinfoTbTemplate>().Property(item => item.Tpl).IsRequired();
            modelBuilder.Entity<MapinfoTbTemplate>().Property(item => item.Tpl).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbTemplate>().Property(item => item.Tpl).HasColumnName("TPL");
            modelBuilder.Entity<MapinfoTbTemplate>().Property(item => item.Titre).IsRequired();
            modelBuilder.Entity<MapinfoTbTemplate>().Property(item => item.Titre).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbTemplate>().Property(item => item.Titre).HasColumnName("TITRE");
            modelBuilder.Entity<MapinfoTbTemplate>().Property(item => item.Rang).IsRequired();
            modelBuilder.Entity<MapinfoTbTemplate>().Property(item => item.Rang).HasColumnName("RANG");
            modelBuilder.Entity<MapinfoTbTemplate>().Property(item => item.Chemin).HasMaxLength(254);
            modelBuilder.Entity<MapinfoTbTemplate>().Property(item => item.Chemin).HasColumnName("CHEMIN");
            modelBuilder.Entity<MapinfoTbTemplate>().Property(item => item.Isgeocode).HasColumnName("ISGEOCODE");
            modelBuilder.Entity<MapinfoTbTemplateCfg>().ToTable("TB_TEMPLATE_CFG","MAPINFO");
            modelBuilder.Entity<MapinfoTbTemplateCfg>().HasKey(item => new {item.TbModeleModele,item.TbTemplateTpl,item.Usercode,item.CodePrp });
            modelBuilder.Entity<MapinfoTbTemplateCfg>().Property(item => item.TbModeleModele).IsRequired();
            modelBuilder.Entity<MapinfoTbTemplateCfg>().Property(item => item.TbModeleModele).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbTemplateCfg>().Property(item => item.TbModeleModele).HasColumnName("TB_MODELE__MODELE");
            modelBuilder.Entity<MapinfoTbTemplateCfg>().Property(item => item.TbTemplateTpl).IsRequired();
            modelBuilder.Entity<MapinfoTbTemplateCfg>().Property(item => item.TbTemplateTpl).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbTemplateCfg>().Property(item => item.TbTemplateTpl).HasColumnName("TB_TEMPLATE__TPL");
            modelBuilder.Entity<MapinfoTbTemplateCfg>().Property(item => item.Usercode).IsRequired();
            modelBuilder.Entity<MapinfoTbTemplateCfg>().Property(item => item.Usercode).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbTemplateCfg>().Property(item => item.Usercode).HasColumnName("USERCODE");
            modelBuilder.Entity<MapinfoTbTemplateCfg>().Property(item => item.CodePrp).IsRequired();
            modelBuilder.Entity<MapinfoTbTemplateCfg>().Property(item => item.CodePrp).HasMaxLength(20);
            modelBuilder.Entity<MapinfoTbTemplateCfg>().Property(item => item.CodePrp).HasColumnName("CODE_PRP");
            modelBuilder.Entity<MapinfoTbTemplateCfg>().Property(item => item.ValPrp).IsRequired();
            modelBuilder.Entity<MapinfoTbTemplateCfg>().Property(item => item.ValPrp).HasMaxLength(254);
            modelBuilder.Entity<MapinfoTbTemplateCfg>().Property(item => item.ValPrp).HasColumnName("VAL_PRP");
            modelBuilder.Entity<MapinfoTbGroupeCfg>().ToTable("TB_GROUPE_CFG","MAPINFO");
            modelBuilder.Entity<MapinfoTbGroupeCfg>().HasKey(item => new {item.TbModeleModele,item.TbTemplateTpl,item.TbGroupeGroupe,item.Usercode,item.CodePrp });
            modelBuilder.Entity<MapinfoTbGroupeCfg>().Property(item => item.TbModeleModele).IsRequired();
            modelBuilder.Entity<MapinfoTbGroupeCfg>().Property(item => item.TbModeleModele).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbGroupeCfg>().Property(item => item.TbModeleModele).HasColumnName("TB_MODELE__MODELE");
            modelBuilder.Entity<MapinfoTbGroupeCfg>().Property(item => item.TbTemplateTpl).IsRequired();
            modelBuilder.Entity<MapinfoTbGroupeCfg>().Property(item => item.TbTemplateTpl).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbGroupeCfg>().Property(item => item.TbTemplateTpl).HasColumnName("TB_TEMPLATE__TPL");
            modelBuilder.Entity<MapinfoTbGroupeCfg>().Property(item => item.TbGroupeGroupe).IsRequired();
            modelBuilder.Entity<MapinfoTbGroupeCfg>().Property(item => item.TbGroupeGroupe).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbGroupeCfg>().Property(item => item.TbGroupeGroupe).HasColumnName("TB_GROUPE__GROUPE");
            modelBuilder.Entity<MapinfoTbGroupeCfg>().Property(item => item.Usercode).IsRequired();
            modelBuilder.Entity<MapinfoTbGroupeCfg>().Property(item => item.Usercode).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbGroupeCfg>().Property(item => item.Usercode).HasColumnName("USERCODE");
            modelBuilder.Entity<MapinfoTbGroupeCfg>().Property(item => item.CodePrp).IsRequired();
            modelBuilder.Entity<MapinfoTbGroupeCfg>().Property(item => item.CodePrp).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbGroupeCfg>().Property(item => item.CodePrp).HasColumnName("CODE_PRP");
            modelBuilder.Entity<MapinfoTbGroupeCfg>().Property(item => item.ValPrp).HasMaxLength(254);
            modelBuilder.Entity<MapinfoTbGroupeCfg>().Property(item => item.ValPrp).HasColumnName("VAL_PRP");
            modelBuilder.Entity<MapinfoTbMap>().ToTable("TB_MAP","MAPINFO");
            modelBuilder.Entity<MapinfoTbMap>().HasKey(item => new {item.TbModeleModele,item.TbTemplateTpl,item.TbGroupeGroupe,item.Map });
            modelBuilder.Entity<MapinfoTbMap>().Property(item => item.TbModeleModele).IsRequired();
            modelBuilder.Entity<MapinfoTbMap>().Property(item => item.TbModeleModele).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbMap>().Property(item => item.TbModeleModele).HasColumnName("TB_MODELE__MODELE");
            modelBuilder.Entity<MapinfoTbMap>().Property(item => item.TbTemplateTpl).IsRequired();
            modelBuilder.Entity<MapinfoTbMap>().Property(item => item.TbTemplateTpl).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbMap>().Property(item => item.TbTemplateTpl).HasColumnName("TB_TEMPLATE__TPL");
            modelBuilder.Entity<MapinfoTbMap>().Property(item => item.TbGroupeGroupe).IsRequired();
            modelBuilder.Entity<MapinfoTbMap>().Property(item => item.TbGroupeGroupe).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbMap>().Property(item => item.TbGroupeGroupe).HasColumnName("TB_GROUPE__GROUPE");
            modelBuilder.Entity<MapinfoTbMap>().Property(item => item.Map).IsRequired();
            modelBuilder.Entity<MapinfoTbMap>().Property(item => item.Map).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbMap>().Property(item => item.Map).HasColumnName("MAP");
            modelBuilder.Entity<MapinfoTbMap>().Property(item => item.Titre).IsRequired();
            modelBuilder.Entity<MapinfoTbMap>().Property(item => item.Titre).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbMap>().Property(item => item.Titre).HasColumnName("TITRE");
            modelBuilder.Entity<MapinfoTbMap>().Property(item => item.Objtype).HasColumnName("OBJTYPE");
            modelBuilder.Entity<MapinfoTbMap>().Property(item => item.Rang).HasColumnName("RANG");
            modelBuilder.Entity<MapinfoTbMap>().Property(item => item.MapOrder).IsRequired();
            modelBuilder.Entity<MapinfoTbMap>().Property(item => item.MapOrder).HasColumnName("MAP_ORDER");
            modelBuilder.Entity<MapinfoTbMap>().Property(item => item.Owner).IsRequired();
            modelBuilder.Entity<MapinfoTbMap>().Property(item => item.Owner).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbMap>().Property(item => item.Owner).HasColumnName("OWNER");
            modelBuilder.Entity<MapinfoTbMap>().Property(item => item.Isgeocode).HasColumnName("ISGEOCODE");
            modelBuilder.Entity<MapinfoTbMap>().Property(item => item.Chemin).IsRequired();
            modelBuilder.Entity<MapinfoTbMap>().Property(item => item.Chemin).HasMaxLength(254);
            modelBuilder.Entity<MapinfoTbMap>().Property(item => item.Chemin).HasColumnName("CHEMIN");
            modelBuilder.Entity<MapinfoCdMotsReserve>().ToTable("CD_MOTS_RESERVE","MAPINFO");
            modelBuilder.Entity<MapinfoCdMotsReserve>().HasKey(item => new {item.Keyword });
            modelBuilder.Entity<MapinfoCdMotsReserve>().Property(item => item.Keyword).IsRequired();
            modelBuilder.Entity<MapinfoCdMotsReserve>().Property(item => item.Keyword).HasMaxLength(50);
            modelBuilder.Entity<MapinfoCdMotsReserve>().Property(item => item.Keyword).HasColumnName("KEYWORD");
            modelBuilder.Entity<MapinfoTbMapCfg>().ToTable("TB_MAP_CFG","MAPINFO");
            modelBuilder.Entity<MapinfoTbMapCfg>().HasKey(item => new {item.TbModeleModele,item.TbTemplateTpl,item.TbGroupeGroupe,item.TbMapMap,item.Usercode,item.CodePrp });
            modelBuilder.Entity<MapinfoTbMapCfg>().Property(item => item.TbModeleModele).IsRequired();
            modelBuilder.Entity<MapinfoTbMapCfg>().Property(item => item.TbModeleModele).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbMapCfg>().Property(item => item.TbModeleModele).HasColumnName("TB_MODELE__MODELE");
            modelBuilder.Entity<MapinfoTbMapCfg>().Property(item => item.TbTemplateTpl).IsRequired();
            modelBuilder.Entity<MapinfoTbMapCfg>().Property(item => item.TbTemplateTpl).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbMapCfg>().Property(item => item.TbTemplateTpl).HasColumnName("TB_TEMPLATE__TPL");
            modelBuilder.Entity<MapinfoTbMapCfg>().Property(item => item.TbGroupeGroupe).IsRequired();
            modelBuilder.Entity<MapinfoTbMapCfg>().Property(item => item.TbGroupeGroupe).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbMapCfg>().Property(item => item.TbGroupeGroupe).HasColumnName("TB_GROUPE__GROUPE");
            modelBuilder.Entity<MapinfoTbMapCfg>().Property(item => item.TbMapMap).IsRequired();
            modelBuilder.Entity<MapinfoTbMapCfg>().Property(item => item.TbMapMap).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbMapCfg>().Property(item => item.TbMapMap).HasColumnName("TB_MAP__MAP");
            modelBuilder.Entity<MapinfoTbMapCfg>().Property(item => item.Usercode).IsRequired();
            modelBuilder.Entity<MapinfoTbMapCfg>().Property(item => item.Usercode).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbMapCfg>().Property(item => item.Usercode).HasColumnName("USERCODE");
            modelBuilder.Entity<MapinfoTbMapCfg>().Property(item => item.CodePrp).IsRequired();
            modelBuilder.Entity<MapinfoTbMapCfg>().Property(item => item.CodePrp).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbMapCfg>().Property(item => item.CodePrp).HasColumnName("CODE_PRP");
            modelBuilder.Entity<MapinfoTbMapCfg>().Property(item => item.ValPrp).IsRequired();
            modelBuilder.Entity<MapinfoTbMapCfg>().Property(item => item.ValPrp).HasMaxLength(254);
            modelBuilder.Entity<MapinfoTbMapCfg>().Property(item => item.ValPrp).HasColumnName("VAL_PRP");
            modelBuilder.Entity<MapinfoSysUser>().ToTable("SYS_USER_MAPINFO","MAPINFO");
            modelBuilder.Entity<MapinfoSysUser>().HasKey(item => new {item.CodeDbs,item.CodeTable,item.CodeColonne,item.NomUser,item.CodePrp });
            modelBuilder.Entity<MapinfoSysUser>().Property(item => item.CodeDbs).IsRequired();
            modelBuilder.Entity<MapinfoSysUser>().Property(item => item.CodeDbs).HasMaxLength(50);
            modelBuilder.Entity<MapinfoSysUser>().Property(item => item.CodeDbs).HasColumnName("CODE_DBS");
            modelBuilder.Entity<MapinfoSysUser>().Property(item => item.CodeTable).IsRequired();
            modelBuilder.Entity<MapinfoSysUser>().Property(item => item.CodeTable).HasMaxLength(100);
            modelBuilder.Entity<MapinfoSysUser>().Property(item => item.CodeTable).HasColumnName("CODE_TABLE");
            modelBuilder.Entity<MapinfoSysUser>().Property(item => item.CodeColonne).IsRequired();
            modelBuilder.Entity<MapinfoSysUser>().Property(item => item.CodeColonne).HasMaxLength(100);
            modelBuilder.Entity<MapinfoSysUser>().Property(item => item.CodeColonne).HasColumnName("CODE_COLONNE");
            modelBuilder.Entity<MapinfoSysUser>().Property(item => item.NomUser).IsRequired();
            modelBuilder.Entity<MapinfoSysUser>().Property(item => item.NomUser).HasMaxLength(150);
            modelBuilder.Entity<MapinfoSysUser>().Property(item => item.NomUser).HasColumnName("NOM_USER");
            modelBuilder.Entity<MapinfoSysUser>().Property(item => item.CodePrp).IsRequired();
            modelBuilder.Entity<MapinfoSysUser>().Property(item => item.CodePrp).HasMaxLength(255);
            modelBuilder.Entity<MapinfoSysUser>().Property(item => item.CodePrp).HasColumnName("CODE_PRP");
            modelBuilder.Entity<MapinfoSysUser>().Property(item => item.ValPrp).IsRequired();
            modelBuilder.Entity<MapinfoSysUser>().Property(item => item.ValPrp).HasMaxLength(500);
            modelBuilder.Entity<MapinfoSysUser>().Property(item => item.ValPrp).HasColumnName("VAL_PRP");
            modelBuilder.Entity<MapinfoTbMapGeoStyle>().ToTable("TB_MAP_GEO_STYLE","MAPINFO");
            modelBuilder.Entity<MapinfoTbMapGeoStyle>().HasKey(item => new {item.Map,item.Username,item.Representation });
            modelBuilder.Entity<MapinfoTbMapGeoStyle>().Property(item => item.Map).IsRequired();
            modelBuilder.Entity<MapinfoTbMapGeoStyle>().Property(item => item.Map).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbMapGeoStyle>().Property(item => item.Map).HasColumnName("MAP");
            modelBuilder.Entity<MapinfoTbMapGeoStyle>().Property(item => item.Username).IsRequired();
            modelBuilder.Entity<MapinfoTbMapGeoStyle>().Property(item => item.Username).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbMapGeoStyle>().Property(item => item.Username).HasColumnName("USERNAME");
            modelBuilder.Entity<MapinfoTbMapGeoStyle>().Property(item => item.Representation).IsRequired();
            modelBuilder.Entity<MapinfoTbMapGeoStyle>().Property(item => item.Representation).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbMapGeoStyle>().Property(item => item.Representation).HasColumnName("REPRESENTATION");
            modelBuilder.Entity<MapinfoTbMapGeoStyle>().Property(item => item.Color).IsRequired();
            modelBuilder.Entity<MapinfoTbMapGeoStyle>().Property(item => item.Color).HasColumnName("COLOR");
            modelBuilder.Entity<MapinfoTbMapGeoStyle>().Property(item => item.Width).IsRequired();
            modelBuilder.Entity<MapinfoTbMapGeoStyle>().Property(item => item.Width).HasColumnName("WIDTH");
            modelBuilder.Entity<MapinfoTbMapGeoStyle>().Property(item => item.Font).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbMapGeoStyle>().Property(item => item.Font).HasColumnName("FONT");
            modelBuilder.Entity<MapinfoTbMapGeoStyle>().Property(item => item.Ascii).HasColumnName("ASCII");
            modelBuilder.Entity<MapinfoTbMapGeoStyle>().Property(item => item.Style).HasColumnName("STYLE");
            modelBuilder.Entity<MapinfoTbMapGeoStyle>().Property(item => item.Interleaved).HasColumnName("INTERLEAVED");
            modelBuilder.Entity<MapinfoTbMapGeoStyle>().Property(item => item.Bordercolor).HasColumnName("BORDERCOLOR");
            modelBuilder.Entity<MapinfoTbMapGeoStyle>().Property(item => item.Borderstyle).HasColumnName("BORDERSTYLE");
            modelBuilder.Entity<MapinfoTbMapGeoStyle>().Property(item => item.Regionbackground).HasColumnName("REGIONBACKGROUND");
            modelBuilder.Entity<MapinfoTbModele>().ToTable("TB_MODELE","MAPINFO");
            modelBuilder.Entity<MapinfoTbModele>().HasKey(item => new {item.Modele });
            modelBuilder.Entity<MapinfoTbModele>().Property(item => item.Modele).IsRequired();
            modelBuilder.Entity<MapinfoTbModele>().Property(item => item.Modele).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbModele>().Property(item => item.Modele).HasColumnName("MODELE");
            modelBuilder.Entity<MapinfoTbModele>().Property(item => item.Ordre).HasColumnName("ORDRE");
            modelBuilder.Entity<MapinfoTbModele>().Property(item => item.LayerName).IsRequired();
            modelBuilder.Entity<MapinfoTbModele>().Property(item => item.LayerName).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbModele>().Property(item => item.LayerName).HasColumnName("LAYER_NAME");
            modelBuilder.Entity<MapinfoTbModele>().Property(item => item.Path).IsRequired();
            modelBuilder.Entity<MapinfoTbModele>().Property(item => item.Path).HasMaxLength(255);
            modelBuilder.Entity<MapinfoTbModele>().Property(item => item.Path).HasColumnName("PATH");
            modelBuilder.Entity<MapinfoTbModele>().Property(item => item.TypeModele).IsRequired();
            modelBuilder.Entity<MapinfoTbModele>().Property(item => item.TypeModele).HasColumnName("TYPE_MODELE");
            modelBuilder.Entity<MapinfoTbModeleCfg>().ToTable("TB_MODELE_CFG","MAPINFO");
            modelBuilder.Entity<MapinfoTbModeleCfg>().HasKey(item => new {item.TbModeleModele,item.Usercode });
            modelBuilder.Entity<MapinfoTbModeleCfg>().Property(item => item.TbModeleModele).IsRequired();
            modelBuilder.Entity<MapinfoTbModeleCfg>().Property(item => item.TbModeleModele).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbModeleCfg>().Property(item => item.TbModeleModele).HasColumnName("TB_MODELE__MODELE");
            modelBuilder.Entity<MapinfoTbModeleCfg>().Property(item => item.Usercode).IsRequired();
            modelBuilder.Entity<MapinfoTbModeleCfg>().Property(item => item.Usercode).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbModeleCfg>().Property(item => item.Usercode).HasColumnName("USERCODE");
            modelBuilder.Entity<MapinfoTbModeleCfg>().Property(item => item.CodePrp).IsRequired();
            modelBuilder.Entity<MapinfoTbModeleCfg>().Property(item => item.CodePrp).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbModeleCfg>().Property(item => item.CodePrp).HasColumnName("CODE_PRP");
            modelBuilder.Entity<MapinfoTbModeleCfg>().Property(item => item.ValPrp).IsRequired();
            modelBuilder.Entity<MapinfoTbModeleCfg>().Property(item => item.ValPrp).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbModeleCfg>().Property(item => item.ValPrp).HasColumnName("VAL_PRP");
            modelBuilder.Entity<MapinfoTbAnaThema>().ToTable("TB_ANA_THEMA","MAPINFO");
            modelBuilder.Entity<MapinfoTbAnaThema>().HasKey(item => new {item.Usercode,item.Map,item.Modele,item.CodePrp });
            modelBuilder.Entity<MapinfoTbAnaThema>().Property(item => item.Usercode).IsRequired();
            modelBuilder.Entity<MapinfoTbAnaThema>().Property(item => item.Usercode).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbAnaThema>().Property(item => item.Usercode).HasColumnName("USERCODE");
            modelBuilder.Entity<MapinfoTbAnaThema>().Property(item => item.Map).IsRequired();
            modelBuilder.Entity<MapinfoTbAnaThema>().Property(item => item.Map).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbAnaThema>().Property(item => item.Map).HasColumnName("MAP");
            modelBuilder.Entity<MapinfoTbAnaThema>().Property(item => item.Modele).IsRequired();
            modelBuilder.Entity<MapinfoTbAnaThema>().Property(item => item.Modele).HasMaxLength(100);
            modelBuilder.Entity<MapinfoTbAnaThema>().Property(item => item.Modele).HasColumnName("MODELE");
            modelBuilder.Entity<MapinfoTbAnaThema>().Property(item => item.CodePrp).IsRequired();
            modelBuilder.Entity<MapinfoTbAnaThema>().Property(item => item.CodePrp).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbAnaThema>().Property(item => item.CodePrp).HasColumnName("CODE_PRP");
            modelBuilder.Entity<MapinfoTbAnaThema>().Property(item => item.ValPrp).HasMaxLength(254);
            modelBuilder.Entity<MapinfoTbAnaThema>().Property(item => item.ValPrp).HasColumnName("VAL_PRP");
            modelBuilder.Entity<MapinfoSiModel>().ToTable("SI_MODEL","MAPINFO");
            modelBuilder.Entity<MapinfoSiModel>().HasKey(item => new {item.NomModel });
            modelBuilder.Entity<MapinfoSiModel>().Property(item => item.NomModel).IsRequired();
            modelBuilder.Entity<MapinfoSiModel>().Property(item => item.NomModel).HasMaxLength(100);
            modelBuilder.Entity<MapinfoSiModel>().Property(item => item.NomModel).HasColumnName("NOM_MODEL");
            modelBuilder.Entity<MapinfoSiZone>().ToTable("SI_ZONE","MAPINFO");
            modelBuilder.Entity<MapinfoSiZone>().HasKey(item => new {item.SiModelNomModel,item.NomZone });
            modelBuilder.Entity<MapinfoSiZone>().Property(item => item.SiModelNomModel).IsRequired();
            modelBuilder.Entity<MapinfoSiZone>().Property(item => item.SiModelNomModel).HasMaxLength(100);
            modelBuilder.Entity<MapinfoSiZone>().Property(item => item.SiModelNomModel).HasColumnName("SI_MODEL__NOM_MODEL");
            modelBuilder.Entity<MapinfoSiZone>().Property(item => item.NomZone).IsRequired();
            modelBuilder.Entity<MapinfoSiZone>().Property(item => item.NomZone).HasMaxLength(50);
            modelBuilder.Entity<MapinfoSiZone>().Property(item => item.NomZone).HasColumnName("NOM_ZONE");
            modelBuilder.Entity<MapinfoSiZone>().Property(item => item.SchemaZone).HasMaxLength(100);
            modelBuilder.Entity<MapinfoSiZone>().Property(item => item.SchemaZone).HasColumnName("SCHEMA_ZONE");
            modelBuilder.Entity<MapinfoSiZone>().Property(item => item.TableZone).HasMaxLength(100);
            modelBuilder.Entity<MapinfoSiZone>().Property(item => item.TableZone).HasColumnName("TABLE_ZONE");
            modelBuilder.Entity<MapinfoSiZone>().Property(item => item.FieldZone).HasMaxLength(100);
            modelBuilder.Entity<MapinfoSiZone>().Property(item => item.FieldZone).HasColumnName("FIELD_ZONE");
            modelBuilder.Entity<MapinfoSiZone>().Property(item => item.TypeZone).HasMaxLength(25);
            modelBuilder.Entity<MapinfoSiZone>().Property(item => item.TypeZone).HasColumnName("TYPE_ZONE");
            modelBuilder.Entity<MapinfoSiZone>().Property(item => item.Position).HasColumnName("POSITION");
            modelBuilder.Entity<MapinfoSiZone>().Property(item => item.Hauteur).HasColumnName("HAUTEUR");
            modelBuilder.Entity<MapinfoSiZone>().Property(item => item.Valeur).HasMaxLength(100);
            modelBuilder.Entity<MapinfoSiZone>().Property(item => item.Valeur).HasColumnName("VALEUR");
            modelBuilder.Entity<MapinfoSiZone>().Property(item => item.ValeurSub).HasMaxLength(100);
            modelBuilder.Entity<MapinfoSiZone>().Property(item => item.ValeurSub).HasColumnName("VALEUR_SUB");
            modelBuilder.Entity<MapinfoSiZone>().Property(item => item.AnneeMesure).HasColumnName("ANNEE_MESURE");
            modelBuilder.Entity<MapinfoSiZone>().Property(item => item.PositionEtiquette).HasMaxLength(20);
            modelBuilder.Entity<MapinfoSiZone>().Property(item => item.PositionEtiquette).HasColumnName("POSITION_ETIQUETTE");
            modelBuilder.Entity<MapinfoSiZone>().Property(item => item.ChampEtiquette).HasMaxLength(50);
            modelBuilder.Entity<MapinfoSiZone>().Property(item => item.ChampEtiquette).HasColumnName("CHAMP_ETIQUETTE");
            modelBuilder.Entity<MapinfoSiZone>().Property(item => item.Withcote).HasColumnName("WITHCOTE");
            modelBuilder.Entity<MapinfoSiStyleValeur>().ToTable("SI_STYLE_VALEUR","MAPINFO");
            modelBuilder.Entity<MapinfoSiStyleValeur>().HasKey(item => new {item.SiModelNomModel,item.SiZoneNomZone,item.Valeur });
            modelBuilder.Entity<MapinfoSiStyleValeur>().Property(item => item.SiModelNomModel).IsRequired();
            modelBuilder.Entity<MapinfoSiStyleValeur>().Property(item => item.SiModelNomModel).HasMaxLength(100);
            modelBuilder.Entity<MapinfoSiStyleValeur>().Property(item => item.SiModelNomModel).HasColumnName("SI_MODEL__NOM_MODEL");
            modelBuilder.Entity<MapinfoSiStyleValeur>().Property(item => item.SiZoneNomZone).IsRequired();
            modelBuilder.Entity<MapinfoSiStyleValeur>().Property(item => item.SiZoneNomZone).HasMaxLength(50);
            modelBuilder.Entity<MapinfoSiStyleValeur>().Property(item => item.SiZoneNomZone).HasColumnName("SI_ZONE__NOM_ZONE");
            modelBuilder.Entity<MapinfoSiStyleValeur>().Property(item => item.Valeur).IsRequired();
            modelBuilder.Entity<MapinfoSiStyleValeur>().Property(item => item.Valeur).HasMaxLength(100);
            modelBuilder.Entity<MapinfoSiStyleValeur>().Property(item => item.Valeur).HasColumnName("VALEUR");
            modelBuilder.Entity<MapinfoSiStyleValeur>().Property(item => item.Couleur).HasMaxLength(9);
            modelBuilder.Entity<MapinfoSiStyleValeur>().Property(item => item.Couleur).HasColumnName("COULEUR");
            modelBuilder.Entity<MapinfoSiStyleValeur>().Property(item => item.Border).HasColumnName("BORDER");
            modelBuilder.Entity<MapinfoSiStyleValeur>().Property(item => item.Taille).HasColumnName("TAILLE");
            modelBuilder.Entity<MapinfoSiStyleValeur>().Property(item => item.Representation).HasMaxLength(20);
            modelBuilder.Entity<MapinfoSiStyleValeur>().Property(item => item.Representation).HasColumnName("REPRESENTATION");
            modelBuilder.Entity<MapinfoSiStyleValeur>().Property(item => item.Chemin).HasMaxLength(1024);
            modelBuilder.Entity<MapinfoSiStyleValeur>().Property(item => item.Chemin).HasColumnName("CHEMIN");
            modelBuilder.Entity<MapinfoSiStyleValeur>().Property(item => item.FontName).HasMaxLength(50);
            modelBuilder.Entity<MapinfoSiStyleValeur>().Property(item => item.FontName).HasColumnName("FONT_NAME");
            modelBuilder.Entity<MapinfoSiStyleValeur>().Property(item => item.FontChar).HasColumnName("FONT_CHAR");
            modelBuilder.Entity<MapinfoSiStyleValeur>().Property(item => item.Opacity).HasColumnName("OPACITY");
            modelBuilder.Entity<MapinfoTbMapMetier>().ToTable("TB_MAP_METIER","MAPINFO");
            modelBuilder.Entity<MapinfoTbMapMetier>().HasKey(item => new {item.SchemaName,item.TableName });
            modelBuilder.Entity<MapinfoTbMapMetier>().Property(item => item.SchemaName).IsRequired();
            modelBuilder.Entity<MapinfoTbMapMetier>().Property(item => item.SchemaName).HasMaxLength(20);
            modelBuilder.Entity<MapinfoTbMapMetier>().Property(item => item.SchemaName).HasColumnName("SCHEMA_NAME");
            modelBuilder.Entity<MapinfoTbMapMetier>().Property(item => item.TableName).IsRequired();
            modelBuilder.Entity<MapinfoTbMapMetier>().Property(item => item.TableName).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbMapMetier>().Property(item => item.TableName).HasColumnName("TABLE_NAME");
            modelBuilder.Entity<MapinfoTbMapMetier>().Property(item => item.Title).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbMapMetier>().Property(item => item.Title).HasColumnName("TITLE");
            modelBuilder.Entity<MapinfoTbMapMetier>().Property(item => item.MapOrder).HasColumnName("MAP_ORDER");
            modelBuilder.Entity<MapinfoTbMapMetier>().Property(item => item.Rang).HasColumnName("RANG");
            modelBuilder.Entity<MapinfoTbMapMetier>().Property(item => item.Objtype).HasColumnName("OBJTYPE");
            modelBuilder.Entity<MapinfoTbMapMetierCfg>().ToTable("TB_MAP_METIER_CFG","MAPINFO");
            modelBuilder.Entity<MapinfoTbMapMetierCfg>().HasKey(item => new {item.TbMapMetierSchemaName,item.TbMapMetierTableName,item.Usercode,item.CodePrp });
            modelBuilder.Entity<MapinfoTbMapMetierCfg>().Property(item => item.TbMapMetierSchemaName).IsRequired();
            modelBuilder.Entity<MapinfoTbMapMetierCfg>().Property(item => item.TbMapMetierSchemaName).HasMaxLength(20);
            modelBuilder.Entity<MapinfoTbMapMetierCfg>().Property(item => item.TbMapMetierSchemaName).HasColumnName("TB_MAP_METIER__SCHEMA_NAME");
            modelBuilder.Entity<MapinfoTbMapMetierCfg>().Property(item => item.TbMapMetierTableName).IsRequired();
            modelBuilder.Entity<MapinfoTbMapMetierCfg>().Property(item => item.TbMapMetierTableName).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbMapMetierCfg>().Property(item => item.TbMapMetierTableName).HasColumnName("TB_MAP_METIER__TABLE_NAME");
            modelBuilder.Entity<MapinfoTbMapMetierCfg>().Property(item => item.Usercode).IsRequired();
            modelBuilder.Entity<MapinfoTbMapMetierCfg>().Property(item => item.Usercode).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbMapMetierCfg>().Property(item => item.Usercode).HasColumnName("USERCODE");
            modelBuilder.Entity<MapinfoTbMapMetierCfg>().Property(item => item.CodePrp).IsRequired();
            modelBuilder.Entity<MapinfoTbMapMetierCfg>().Property(item => item.CodePrp).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbMapMetierCfg>().Property(item => item.CodePrp).HasColumnName("CODE_PRP");
            modelBuilder.Entity<MapinfoTbMapMetierCfg>().Property(item => item.ValPrp).IsRequired();
            modelBuilder.Entity<MapinfoTbMapMetierCfg>().Property(item => item.ValPrp).HasMaxLength(254);
            modelBuilder.Entity<MapinfoTbMapMetierCfg>().Property(item => item.ValPrp).HasColumnName("VAL_PRP");
            modelBuilder.Entity<MapinfoTbMapMetierColumns>().ToTable("TB_MAP_METIER_COLUMNS","MAPINFO");
            modelBuilder.Entity<MapinfoTbMapMetierColumns>().HasKey(item => new {item.TbMapMetierSchemaName,item.TbMapMetierTableName,item.ColName });
            modelBuilder.Entity<MapinfoTbMapMetierColumns>().Property(item => item.TbMapMetierSchemaName).IsRequired();
            modelBuilder.Entity<MapinfoTbMapMetierColumns>().Property(item => item.TbMapMetierSchemaName).HasMaxLength(20);
            modelBuilder.Entity<MapinfoTbMapMetierColumns>().Property(item => item.TbMapMetierSchemaName).HasColumnName("TB_MAP_METIER__SCHEMA_NAME");
            modelBuilder.Entity<MapinfoTbMapMetierColumns>().Property(item => item.TbMapMetierTableName).IsRequired();
            modelBuilder.Entity<MapinfoTbMapMetierColumns>().Property(item => item.TbMapMetierTableName).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbMapMetierColumns>().Property(item => item.TbMapMetierTableName).HasColumnName("TB_MAP_METIER__TABLE_NAME");
            modelBuilder.Entity<MapinfoTbMapMetierColumns>().Property(item => item.ColName).IsRequired();
            modelBuilder.Entity<MapinfoTbMapMetierColumns>().Property(item => item.ColName).HasMaxLength(100);
            modelBuilder.Entity<MapinfoTbMapMetierColumns>().Property(item => item.ColName).HasColumnName("COL_NAME");
            modelBuilder.Entity<MapinfoTbMapMetierColumns>().Property(item => item.ColLibelle).IsRequired();
            modelBuilder.Entity<MapinfoTbMapMetierColumns>().Property(item => item.ColLibelle).HasMaxLength(50);
            modelBuilder.Entity<MapinfoTbMapMetierColumns>().Property(item => item.ColLibelle).HasColumnName("COL_LIBELLE");
            modelBuilder.Entity<MapinfoTbMapMetierColumns>().Property(item => item.ColOrder).HasColumnName("COL_ORDER");
            modelBuilder.Entity<MapinfoTbMapMetierColumns>().Property(item => item.ColVisible).HasColumnName("COL_VISIBLE");
            modelBuilder.Entity<MapinfoSiModelPredef>().ToTable("SI_MODEL_PREDEF","MAPINFO");
            modelBuilder.Entity<MapinfoSiModelPredef>().HasKey(item => new {item.Nomtable,item.Nomschema,item.NomModel });
            modelBuilder.Entity<MapinfoSiModelPredef>().Property(item => item.Nomtable).IsRequired();
            modelBuilder.Entity<MapinfoSiModelPredef>().Property(item => item.Nomtable).HasMaxLength(100);
            modelBuilder.Entity<MapinfoSiModelPredef>().Property(item => item.Nomtable).HasColumnName("NOMTABLE");
            modelBuilder.Entity<MapinfoSiModelPredef>().Property(item => item.Nomschema).IsRequired();
            modelBuilder.Entity<MapinfoSiModelPredef>().Property(item => item.Nomschema).HasMaxLength(100);
            modelBuilder.Entity<MapinfoSiModelPredef>().Property(item => item.Nomschema).HasColumnName("NOMSCHEMA");
            modelBuilder.Entity<MapinfoSiModelPredef>().Property(item => item.NomModel).IsRequired();
            modelBuilder.Entity<MapinfoSiModelPredef>().Property(item => item.NomModel).HasMaxLength(100);
            modelBuilder.Entity<MapinfoSiModelPredef>().Property(item => item.NomModel).HasColumnName("NOM_MODEL");
            modelBuilder.Entity<MapinfoSiPrp>().ToTable("SI_PRP","MAPINFO");
            modelBuilder.Entity<MapinfoSiPrp>().HasKey(item => new {item.CodePrp,item.ValPrp });
            modelBuilder.Entity<MapinfoSiPrp>().Property(item => item.CodePrp).IsRequired();
            modelBuilder.Entity<MapinfoSiPrp>().Property(item => item.CodePrp).HasMaxLength(50);
            modelBuilder.Entity<MapinfoSiPrp>().Property(item => item.CodePrp).HasColumnName("CODE_PRP");
            modelBuilder.Entity<MapinfoSiPrp>().Property(item => item.ValPrp).IsRequired();
            modelBuilder.Entity<MapinfoSiPrp>().Property(item => item.ValPrp).HasMaxLength(1024);
            modelBuilder.Entity<MapinfoSiPrp>().Property(item => item.ValPrp).HasColumnName("VAL_PRP");
            modelBuilder.Entity<WebNode>().ToTable("NODE_WEB","WEB");
            modelBuilder.Entity<WebNode>().HasKey(item => new {item.Id });
            modelBuilder.Entity<WebNode>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<WebNode>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<WebNode>().Property(item => item.CdNodeWebName).IsRequired();
            modelBuilder.Entity<WebNode>().Property(item => item.CdNodeWebName).HasMaxLength(255);
            modelBuilder.Entity<WebNode>().Property(item => item.CdNodeWebName).HasColumnName("CD_NODE_WEB__NAME");
            modelBuilder.Entity<WebNode>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<WebNode>().Property(item => item.Libelle).HasMaxLength(255);
            modelBuilder.Entity<WebNode>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<WebNode>().Property(item => item.ParentId).HasColumnName("PARENT_ID");
            modelBuilder.Entity<WebNode>().Property(item => item.TreeOrder).HasColumnName("TREE_ORDER");
            modelBuilder.Entity<WebCdNode>().ToTable("CD_NODE_WEB","WEB");
            modelBuilder.Entity<WebCdNode>().HasKey(item => new {item.Name });
            modelBuilder.Entity<WebCdNode>().Property(item => item.Name).IsRequired();
            modelBuilder.Entity<WebCdNode>().Property(item => item.Name).HasMaxLength(255);
            modelBuilder.Entity<WebCdNode>().Property(item => item.Name).HasColumnName("NAME");
            modelBuilder.Entity<WebNodeParam>().ToTable("NODE_PARAM_WEB","WEB");
            modelBuilder.Entity<WebNodeParam>().HasKey(item => new {item.NodeWebId,item.Code });
            modelBuilder.Entity<WebNodeParam>().Property(item => item.NodeWebId).IsRequired();
            modelBuilder.Entity<WebNodeParam>().Property(item => item.NodeWebId).HasColumnName("NODE_WEB__ID");
            modelBuilder.Entity<WebNodeParam>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<WebNodeParam>().Property(item => item.Code).HasMaxLength(255);
            modelBuilder.Entity<WebNodeParam>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<WebNodeParam>().Property(item => item.Valeur).IsRequired();
            modelBuilder.Entity<WebNodeParam>().Property(item => item.Valeur).HasMaxLength(255);
            modelBuilder.Entity<WebNodeParam>().Property(item => item.Valeur).HasColumnName("VALEUR");
            modelBuilder.Entity<WebSysUser>().ToTable("SYS_USER_WEB","WEB");
            modelBuilder.Entity<WebSysUser>().HasKey(item => new {item.CodeDbs,item.CodeTable,item.CodeColonne,item.NomUser,item.CodePrp });
            modelBuilder.Entity<WebSysUser>().Property(item => item.CodeDbs).IsRequired();
            modelBuilder.Entity<WebSysUser>().Property(item => item.CodeDbs).HasMaxLength(50);
            modelBuilder.Entity<WebSysUser>().Property(item => item.CodeDbs).HasColumnName("CODE_DBS");
            modelBuilder.Entity<WebSysUser>().Property(item => item.CodeTable).IsRequired();
            modelBuilder.Entity<WebSysUser>().Property(item => item.CodeTable).HasMaxLength(200);
            modelBuilder.Entity<WebSysUser>().Property(item => item.CodeTable).HasColumnName("CODE_TABLE");
            modelBuilder.Entity<WebSysUser>().Property(item => item.CodeColonne).IsRequired();
            modelBuilder.Entity<WebSysUser>().Property(item => item.CodeColonne).HasMaxLength(200);
            modelBuilder.Entity<WebSysUser>().Property(item => item.CodeColonne).HasColumnName("CODE_COLONNE");
            modelBuilder.Entity<WebSysUser>().Property(item => item.NomUser).IsRequired();
            modelBuilder.Entity<WebSysUser>().Property(item => item.NomUser).HasMaxLength(200);
            modelBuilder.Entity<WebSysUser>().Property(item => item.NomUser).HasColumnName("NOM_USER");
            modelBuilder.Entity<WebSysUser>().Property(item => item.CodePrp).IsRequired();
            modelBuilder.Entity<WebSysUser>().Property(item => item.CodePrp).HasMaxLength(255);
            modelBuilder.Entity<WebSysUser>().Property(item => item.CodePrp).HasColumnName("CODE_PRP");
            modelBuilder.Entity<WebSysUser>().Property(item => item.ValPrp).IsRequired();
            modelBuilder.Entity<WebSysUser>().Property(item => item.ValPrp).HasMaxLength(255);
            modelBuilder.Entity<WebSysUser>().Property(item => item.ValPrp).HasColumnName("VAL_PRP");
            modelBuilder.Entity<WebStyle>().ToTable("STYLE_WEB","WEB");
            modelBuilder.Entity<WebStyle>().HasKey(item => new {item.Id });
            modelBuilder.Entity<WebStyle>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<WebStyle>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<WebStyle>().Property(item => item.SchemaName).HasMaxLength(255);
            modelBuilder.Entity<WebStyle>().Property(item => item.SchemaName).HasColumnName("SCHEMA_NAME");
            modelBuilder.Entity<WebStyle>().Property(item => item.TableName).HasMaxLength(255);
            modelBuilder.Entity<WebStyle>().Property(item => item.TableName).HasColumnName("TABLE_NAME");
            modelBuilder.Entity<WebStyle>().Property(item => item.ColumnName).HasMaxLength(255);
            modelBuilder.Entity<WebStyle>().Property(item => item.ColumnName).HasColumnName("COLUMN_NAME");
            modelBuilder.Entity<WebStyle>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<WebStyle>().Property(item => item.Libelle).HasMaxLength(255);
            modelBuilder.Entity<WebStyle>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<WebStyle>().Property(item => item.Defaut).IsRequired();
            modelBuilder.Entity<WebStyle>().Property(item => item.Defaut).HasColumnName("DEFAUT");
            modelBuilder.Entity<WebStyleRule>().ToTable("STYLE_RULE_WEB","WEB");
            modelBuilder.Entity<WebStyleRule>().HasKey(item => new {item.Id });
            modelBuilder.Entity<WebStyleRule>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<WebStyleRule>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<WebStyleRule>().Property(item => item.StyleWebId).IsRequired();
            modelBuilder.Entity<WebStyleRule>().Property(item => item.StyleWebId).HasColumnName("STYLE_WEB__ID");
            modelBuilder.Entity<WebStyleRule>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<WebStyleRule>().Property(item => item.Libelle).HasMaxLength(255);
            modelBuilder.Entity<WebStyleRule>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<WebStyleRule>().Property(item => item.IncrementRange).HasColumnName("INCREMENT_RANGE");
            modelBuilder.Entity<WebStyleRule>().Property(item => item.IsActive).IsRequired();
            modelBuilder.Entity<WebStyleRule>().Property(item => item.IsActive).HasColumnName("IS_ACTIVE");
            modelBuilder.Entity<WebStyleRule>().Property(item => item.MaxRange).HasColumnName("MAX_RANGE");
            modelBuilder.Entity<WebStyleRule>().Property(item => item.MinRange).HasColumnName("MIN_RANGE");
            modelBuilder.Entity<WebStyleRule>().Property(item => item.MaxValue).HasColumnName("MAX_VALUE");
            modelBuilder.Entity<WebStyleRule>().Property(item => item.MinValue).HasColumnName("MIN_VALUE");
            modelBuilder.Entity<WebStyleRule>().Property(item => item.UniqueValue).HasMaxLength(255);
            modelBuilder.Entity<WebStyleRule>().Property(item => item.UniqueValue).HasColumnName("UNIQUE_VALUE");
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PointSize).IsRequired();
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PointSize).HasColumnName("POINT_SIZE");
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PointStrokeColor).IsRequired();
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PointStrokeColor).HasMaxLength(10);
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PointStrokeColor).HasColumnName("POINT_STROKE_COLOR");
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PointStrokeOpacity).IsRequired();
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PointStrokeOpacity).HasColumnName("POINT_STROKE_OPACITY");
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PointStrokeStyle).IsRequired();
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PointStrokeStyle).HasMaxLength(50);
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PointStrokeStyle).HasColumnName("POINT_STROKE_STYLE");
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PointStrokeSize).IsRequired();
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PointStrokeSize).HasColumnName("POINT_STROKE_SIZE");
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PointFillColor).IsRequired();
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PointFillColor).HasMaxLength(10);
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PointFillColor).HasColumnName("POINT_FILL_COLOR");
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PointFillOpacity).IsRequired();
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PointFillOpacity).HasColumnName("POINT_FILL_OPACITY");
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PointSymbol).IsRequired();
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PointSymbol).HasMaxLength(50);
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PointSymbol).HasColumnName("POINT_SYMBOL");
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PointImage).IsRequired();
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PointImage).HasMaxLength(255);
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PointImage).HasColumnName("POINT_IMAGE");
            modelBuilder.Entity<WebStyleRule>().Property(item => item.LineSize).IsRequired();
            modelBuilder.Entity<WebStyleRule>().Property(item => item.LineSize).HasColumnName("LINE_SIZE");
            modelBuilder.Entity<WebStyleRule>().Property(item => item.LineStrokeColor).IsRequired();
            modelBuilder.Entity<WebStyleRule>().Property(item => item.LineStrokeColor).HasMaxLength(10);
            modelBuilder.Entity<WebStyleRule>().Property(item => item.LineStrokeColor).HasColumnName("LINE_STROKE_COLOR");
            modelBuilder.Entity<WebStyleRule>().Property(item => item.LineStrokeOpacity).IsRequired();
            modelBuilder.Entity<WebStyleRule>().Property(item => item.LineStrokeOpacity).HasColumnName("LINE_STROKE_OPACITY");
            modelBuilder.Entity<WebStyleRule>().Property(item => item.LineStrokeStyle).IsRequired();
            modelBuilder.Entity<WebStyleRule>().Property(item => item.LineStrokeStyle).HasMaxLength(50);
            modelBuilder.Entity<WebStyleRule>().Property(item => item.LineStrokeStyle).HasColumnName("LINE_STROKE_STYLE");
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PolyStrokeColor).IsRequired();
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PolyStrokeColor).HasMaxLength(10);
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PolyStrokeColor).HasColumnName("POLY_STROKE_COLOR");
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PolyStrokeOpacity).IsRequired();
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PolyStrokeOpacity).HasColumnName("POLY_STROKE_OPACITY");
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PolyStrokeStyle).IsRequired();
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PolyStrokeStyle).HasMaxLength(50);
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PolyStrokeStyle).HasColumnName("POLY_STROKE_STYLE");
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PolyStrokeSize).IsRequired();
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PolyStrokeSize).HasColumnName("POLY_STROKE_SIZE");
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PolyFillColor).IsRequired();
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PolyFillColor).HasMaxLength(10);
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PolyFillColor).HasColumnName("POLY_FILL_COLOR");
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PolyFillOpacity).IsRequired();
            modelBuilder.Entity<WebStyleRule>().Property(item => item.PolyFillOpacity).HasColumnName("POLY_FILL_OPACITY");
            modelBuilder.Entity<WebModele>().ToTable("MODELE_WEB","WEB");
            modelBuilder.Entity<WebModele>().HasKey(item => new {item.Id });
            modelBuilder.Entity<WebModele>().Property(item => item.Id).IsRequired();
            modelBuilder.Entity<WebModele>().Property(item => item.Id).HasColumnName("ID");
            modelBuilder.Entity<WebModele>().Property(item => item.CdModeleWebCode).IsRequired();
            modelBuilder.Entity<WebModele>().Property(item => item.CdModeleWebCode).HasMaxLength(50);
            modelBuilder.Entity<WebModele>().Property(item => item.CdModeleWebCode).HasColumnName("CD_MODELE_WEB__CODE");
            modelBuilder.Entity<WebModele>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<WebModele>().Property(item => item.Libelle).HasMaxLength(255);
            modelBuilder.Entity<WebModele>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<WebModele>().Property(item => item.IsPublic).HasColumnName("IS_PUBLIC");
            modelBuilder.Entity<WebCdModele>().ToTable("CD_MODELE_WEB","WEB");
            modelBuilder.Entity<WebCdModele>().HasKey(item => new {item.Code });
            modelBuilder.Entity<WebCdModele>().Property(item => item.Code).IsRequired();
            modelBuilder.Entity<WebCdModele>().Property(item => item.Code).HasMaxLength(50);
            modelBuilder.Entity<WebCdModele>().Property(item => item.Code).HasColumnName("CODE");
            modelBuilder.Entity<WebCdModele>().Property(item => item.Libelle).IsRequired();
            modelBuilder.Entity<WebCdModele>().Property(item => item.Libelle).HasMaxLength(255);
            modelBuilder.Entity<WebCdModele>().Property(item => item.Libelle).HasColumnName("LIBELLE");
            modelBuilder.Entity<WebModeleWebNode>().ToTable("MODELE_WEB__NODE_WEB","WEB");
            modelBuilder.Entity<WebModeleWebNode>().HasKey(item => new {item.NodeWebId,item.ModeleWebId });
            modelBuilder.Entity<WebModeleWebNode>().Property(item => item.NodeWebId).IsRequired();
            modelBuilder.Entity<WebModeleWebNode>().Property(item => item.NodeWebId).HasColumnName("NODE_WEB__ID");
            modelBuilder.Entity<WebModeleWebNode>().Property(item => item.ModeleWebId).IsRequired();
            modelBuilder.Entity<WebModeleWebNode>().Property(item => item.ModeleWebId).HasColumnName("MODELE_WEB__ID");
            modelBuilder.Entity<WebModeleWebNode>().Property(item => item.MapOrder).HasColumnName("MAP_ORDER");
            modelBuilder.Entity<WebModeleWebNode>().Property(item => item.StyleWebId).HasColumnName("STYLE_WEB__ID");
            modelBuilder.Entity<WebNodeWebStyle>().ToTable("NODE_WEB__STYLE_WEB","WEB");
            modelBuilder.Entity<WebNodeWebStyle>().HasKey(item => new {item.NodeWebId,item.StyleWebId });
            modelBuilder.Entity<WebNodeWebStyle>().Property(item => item.NodeWebId).IsRequired();
            modelBuilder.Entity<WebNodeWebStyle>().Property(item => item.NodeWebId).HasColumnName("NODE_WEB__ID");
            modelBuilder.Entity<WebNodeWebStyle>().Property(item => item.StyleWebId).IsRequired();
            modelBuilder.Entity<WebNodeWebStyle>().Property(item => item.StyleWebId).HasColumnName("STYLE_WEB__ID");
        }
    }
}
