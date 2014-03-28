/*################################################################################################*/
/* Script     : INF_Tables.sql                                                                    */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

-- ---------------------------------------------------------
-- Table SYS_PRP_INF
-- ---------------------------------------------------------

CREATE TABLE SYS_PRP_INF 
( 
	CODE_TABLE                    VARCHAR2(60 CHAR)        NOT NULL,
	CODE_COLONNE                  VARCHAR2(60 CHAR)        NOT NULL,
	NOM_USER                      VARCHAR2(30 CHAR)        NOT NULL,
	CODE_PRP                      VARCHAR2(60 CHAR)        NOT NULL,
	VAL_PRP                       VARCHAR2(255 CHAR)       );
COMMENT ON TABLE SYS_PRP_INF IS 'MétaDonnées du schéma INF';

-- ---------------------------------------------------------
-- Table SYS_INSTANCE_INF
-- ---------------------------------------------------------

CREATE TABLE SYS_INSTANCE_INF 
( 
	CODE                   VARCHAR2(100 CHAR) NOT NULL,
	VALEUR                 CLOB);
COMMENT ON TABLE SYS_INSTANCE_INF IS 'Informations du schéma INF';

-- ---------------------------------------------------------
-- Table ACCIDENT_INF
-- ---------------------------------------------------------
CREATE TABLE ACCIDENT_INF 
( 
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	CHAUSSEE_INF__SENS                      VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	ABS_FIN                                 NUMBER(6),
	NBR_ACC                                 NUMBER(2),
	ANNEE                                   NUMBER(4) NOT NULL,
	MOIS                                    NUMBER(2) NOT NULL,
	NBR_ACC_MOIS                            NUMBER(2)
);
COMMENT ON TABLE ACCIDENT_INF IS 'Accidents';
COMMENT ON COLUMN ACCIDENT_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN ACCIDENT_INF.CHAUSSEE_INF__SENS IS 'Sens';
COMMENT ON COLUMN ACCIDENT_INF.ABS_DEB IS 'Début';
COMMENT ON COLUMN ACCIDENT_INF.ABS_FIN IS 'Fin';
COMMENT ON COLUMN ACCIDENT_INF.NBR_ACC IS 'Nbre Accidents';
COMMENT ON COLUMN ACCIDENT_INF.ANNEE IS 'Année';
COMMENT ON COLUMN ACCIDENT_INF.MOIS IS 'Mois';
COMMENT ON COLUMN ACCIDENT_INF.NBR_ACC_MOIS IS 'AM';

-- ---------------------------------------------------------
-- Table AIRE_INF
-- ---------------------------------------------------------
CREATE TABLE AIRE_INF 
( 
	CD_AIRE_INF__TYPE                       VARCHAR2(60 CHAR) NOT NULL,
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	CHAUSSEE_INF__SENS                      VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	NUM_EXPLOIT                             VARCHAR2(15 CHAR),
	NOM                                     VARCHAR2(60 CHAR),
	DATE_MS                                 DATE,
	DEMI_TOUR                               NUMBER,
	BILATERALE                              NUMBER,
	PASSERELLE                              NUMBER,
	OBSERV                                  VARCHAR2(250 CHAR),
	X1                                      NUMBER(22,11),
	Y1                                      NUMBER(22,11),
	Z1                                      NUMBER(22,11),
	DATE_RELEVE                             DATE,
	TERRAIN                                 NUMBER
);
COMMENT ON TABLE AIRE_INF IS 'Aires';
COMMENT ON COLUMN AIRE_INF.CD_AIRE_INF__TYPE IS 'Type Aire';
COMMENT ON COLUMN AIRE_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN AIRE_INF.CHAUSSEE_INF__SENS IS 'Sens';
COMMENT ON COLUMN AIRE_INF.ABS_DEB IS 'Début';
COMMENT ON COLUMN AIRE_INF.NUM_EXPLOIT IS 'N° Exploitation';
COMMENT ON COLUMN AIRE_INF.NOM IS 'Nom d''usage';
COMMENT ON COLUMN AIRE_INF.DATE_MS IS 'Date MS';
COMMENT ON COLUMN AIRE_INF.DEMI_TOUR IS 'Demi tour';
COMMENT ON COLUMN AIRE_INF.BILATERALE IS 'Bilatérale';
COMMENT ON COLUMN AIRE_INF.PASSERELLE IS 'Passerelle';
COMMENT ON COLUMN AIRE_INF.OBSERV IS 'Commentaires';
COMMENT ON COLUMN AIRE_INF.X1 IS 'X1';
COMMENT ON COLUMN AIRE_INF.Y1 IS 'Y1';
COMMENT ON COLUMN AIRE_INF.Z1 IS 'Z1';
COMMENT ON COLUMN AIRE_INF.DATE_RELEVE IS 'Date relevé';
COMMENT ON COLUMN AIRE_INF.TERRAIN IS 'Terrain';

-- ---------------------------------------------------------
-- Table PR_OLD_INF
-- ---------------------------------------------------------
CREATE TABLE PR_OLD_INF 
( 
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	CHAUSSEE_INF__SENS                      VARCHAR2(6 CHAR) NOT NULL,
	NUM                                     NUMBER(6) NOT NULL,
	INTER                                   NUMBER(4) NOT NULL,
	ABS_CUM                                 NUMBER(6)
);
COMMENT ON TABLE PR_OLD_INF IS 'Ancien PR';
COMMENT ON COLUMN PR_OLD_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN PR_OLD_INF.CHAUSSEE_INF__SENS IS 'Sens';
COMMENT ON COLUMN PR_OLD_INF.NUM IS 'Numéro PR';
COMMENT ON COLUMN PR_OLD_INF.INTER IS 'Inter PR';
COMMENT ON COLUMN PR_OLD_INF.ABS_CUM IS 'Abscisse cumulée';

-- ---------------------------------------------------------
-- Table BIFURCATION_INF
-- ---------------------------------------------------------
CREATE TABLE BIFURCATION_INF 
( 
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	CHAUSSEE_INF__SENS                      VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	CD_BIF_INF__TYPE                        VARCHAR2(60 CHAR) NOT NULL,
	NOM                                     VARCHAR2(60 CHAR),
	DATE_MS                                 DATE,
	OBSERV                                  VARCHAR2(250 CHAR),
	NUM_EXPLOIT                             VARCHAR2(15 CHAR),
	X1                                      NUMBER(22,11),
	Y1                                      NUMBER(22,11),
	Z1                                      NUMBER(22,11),
	DATE_RELEVE                             DATE,
	TERRAIN                                 NUMBER
);
COMMENT ON TABLE BIFURCATION_INF IS 'Bifurcation';
COMMENT ON COLUMN BIFURCATION_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN BIFURCATION_INF.CHAUSSEE_INF__SENS IS 'Sens';
COMMENT ON COLUMN BIFURCATION_INF.ABS_DEB IS 'Pr Axe';
COMMENT ON COLUMN BIFURCATION_INF.CD_BIF_INF__TYPE IS 'Type Bifurcation';
COMMENT ON COLUMN BIFURCATION_INF.NOM IS 'Nom d''usage';
COMMENT ON COLUMN BIFURCATION_INF.DATE_MS IS 'Date MS';
COMMENT ON COLUMN BIFURCATION_INF.OBSERV IS 'Commentaire';
COMMENT ON COLUMN BIFURCATION_INF.NUM_EXPLOIT IS 'N° Exploitation';
COMMENT ON COLUMN BIFURCATION_INF.X1 IS 'X1';
COMMENT ON COLUMN BIFURCATION_INF.Y1 IS 'Y1';
COMMENT ON COLUMN BIFURCATION_INF.Z1 IS 'Z1';
COMMENT ON COLUMN BIFURCATION_INF.DATE_RELEVE IS 'Date relevé';
COMMENT ON COLUMN BIFURCATION_INF.TERRAIN IS 'Terrain';

-- ---------------------------------------------------------
-- Table BRETELLE_INF
-- ---------------------------------------------------------
CREATE TABLE BRETELLE_INF 
( 
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	CHAUSSEE_INF__SENS                      VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	EXTREMITE                               VARCHAR2(60 CHAR),
	NUM_EXPLOIT                             VARCHAR2(15 CHAR),
	NUM_BRETELLE                            VARCHAR2(15 CHAR),
	NOM_BRETELLE                            VARCHAR2(15 CHAR),
	LIBELLE                                 VARCHAR2(60 CHAR),
	TYPE                                    VARCHAR2(60 CHAR)
);
COMMENT ON TABLE BRETELLE_INF IS 'Bretelle';
COMMENT ON COLUMN BRETELLE_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN BRETELLE_INF.CHAUSSEE_INF__SENS IS 'Sens';
COMMENT ON COLUMN BRETELLE_INF.ABS_DEB IS 'Pr raccordement';
COMMENT ON COLUMN BRETELLE_INF.EXTREMITE IS 'Extremité';
COMMENT ON COLUMN BRETELLE_INF.NUM_EXPLOIT IS 'N° Exploitation';
COMMENT ON COLUMN BRETELLE_INF.NUM_BRETELLE IS 'N° Bretelle';
COMMENT ON COLUMN BRETELLE_INF.NOM_BRETELLE IS 'Nom Bretelle';
COMMENT ON COLUMN BRETELLE_INF.LIBELLE IS 'Libellé';
COMMENT ON COLUMN BRETELLE_INF.TYPE IS 'Type';

-- ---------------------------------------------------------
-- Table CHAUSSEE_INF
-- ---------------------------------------------------------
CREATE TABLE CHAUSSEE_INF 
( 
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	SENS                                    VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	ABS_FIN                                 NUMBER(6) NOT NULL,
	LIBELLE                                 VARCHAR2(60 CHAR),
	TENANT                                  VARCHAR2(60 CHAR),
	ABOUT                                   VARCHAR2(60 CHAR)
);
COMMENT ON TABLE CHAUSSEE_INF IS 'Chaussée';
COMMENT ON COLUMN CHAUSSEE_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN CHAUSSEE_INF.SENS IS 'Sens';
COMMENT ON COLUMN CHAUSSEE_INF.ABS_DEB IS 'Début';
COMMENT ON COLUMN CHAUSSEE_INF.ABS_FIN IS 'Fin';
COMMENT ON COLUMN CHAUSSEE_INF.LIBELLE IS 'Libellé';
COMMENT ON COLUMN CHAUSSEE_INF.TENANT IS 'Tenant';
COMMENT ON COLUMN CHAUSSEE_INF.ABOUT IS 'Aboutissant';

-- ---------------------------------------------------------
-- Table CD_CLASS_TRAF_INF
-- ---------------------------------------------------------
CREATE TABLE CD_CLASS_TRAF_INF 
( 
	CODE                                    VARCHAR2(6 CHAR) NOT NULL
);
COMMENT ON TABLE CD_CLASS_TRAF_INF IS 'Classe de trafic';
COMMENT ON COLUMN CD_CLASS_TRAF_INF.CODE IS 'Classe de trafic';

-- ---------------------------------------------------------
-- Table CLS_INF
-- ---------------------------------------------------------
CREATE TABLE CLS_INF 
( 
	ID                                      NUMBER(6,0) NOT NULL,
	TABLE_NAME                              VARCHAR2(40 CHAR) NOT NULL,
	KEY_VALUE                               VARCHAR2(100 CHAR) NOT NULL
);
COMMENT ON TABLE CLS_INF IS 'Classeur';
COMMENT ON COLUMN CLS_INF.ID IS 'Identifiant (cpt)';
COMMENT ON COLUMN CLS_INF.TABLE_NAME IS 'Nom de la table';
COMMENT ON COLUMN CLS_INF.KEY_VALUE IS 'Enregistrement';

-- ---------------------------------------------------------
-- Table CLIM_INF
-- ---------------------------------------------------------
CREATE TABLE CLIM_INF 
( 
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	CHAUSSEE_INF__SENS                      VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	ABS_FIN                                 NUMBER(6),
	CD_CLIM_INF__CODE                       VARCHAR2(25 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(60 CHAR)
);
COMMENT ON TABLE CLIM_INF IS 'Climats';
COMMENT ON COLUMN CLIM_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN CLIM_INF.CHAUSSEE_INF__SENS IS 'Sens';
COMMENT ON COLUMN CLIM_INF.ABS_DEB IS 'Début';
COMMENT ON COLUMN CLIM_INF.ABS_FIN IS 'Fin';
COMMENT ON COLUMN CLIM_INF.CD_CLIM_INF__CODE IS 'Type Climat';
COMMENT ON COLUMN CLIM_INF.LIBELLE IS 'Libellé';

-- ---------------------------------------------------------
-- Table CLS_DOC_INF
-- ---------------------------------------------------------
CREATE TABLE CLS_DOC_INF 
( 
	DOC__ID                                 NUMBER(6) NOT NULL,
	CLS__ID                                 NUMBER(6) NOT NULL,
	DEFAUT                                  NUMBER,
	DOSSIER                                 VARCHAR2(15 CHAR)
);
COMMENT ON TABLE CLS_DOC_INF IS 'CLS_DOC_INF';
COMMENT ON COLUMN CLS_DOC_INF.DOC__ID IS 'Identificant(cpt)';
COMMENT ON COLUMN CLS_DOC_INF.CLS__ID IS 'Identifiant (cpt)';
COMMENT ON COLUMN CLS_DOC_INF.DEFAUT IS 'Document par défaut';
COMMENT ON COLUMN CLS_DOC_INF.DOSSIER IS 'Dossier';

-- ---------------------------------------------------------
-- Table CD_DEC_INF
-- ---------------------------------------------------------
CREATE TABLE CD_DEC_INF 
( 
	FAM_DEC_INF__FAM_DEC                    VARCHAR2(6 CHAR) NOT NULL,
	CD_DEC                                  VARCHAR2(15 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_DEC_INF IS 'Code Découpage';
COMMENT ON COLUMN CD_DEC_INF.FAM_DEC_INF__FAM_DEC IS 'Code famille';
COMMENT ON COLUMN CD_DEC_INF.CD_DEC IS 'Code decoupage';
COMMENT ON COLUMN CD_DEC_INF.LIBELLE IS 'Libellé';

-- ---------------------------------------------------------
-- Table CD_POSIT_INF
-- ---------------------------------------------------------
CREATE TABLE CD_POSIT_INF 
( 
	POSIT                                   VARCHAR2(12 CHAR) NOT NULL,
	ORDRE                                   NUMBER(2)
);
COMMENT ON TABLE CD_POSIT_INF IS 'Code Position';
COMMENT ON COLUMN CD_POSIT_INF.POSIT IS 'Position';
COMMENT ON COLUMN CD_POSIT_INF.ORDRE IS 'N° Ordre';

-- ---------------------------------------------------------
-- Table CD_VOIE_INF
-- ---------------------------------------------------------
CREATE TABLE CD_VOIE_INF 
( 
	VOIE                                    VARCHAR2(6 CHAR) NOT NULL,
	POSIT                                   NUMBER(2) NOT NULL,
	LIBELLE                                 VARCHAR2(60 CHAR),
	ROULABLE                                NUMBER
);
COMMENT ON TABLE CD_VOIE_INF IS 'Code Voie';
COMMENT ON COLUMN CD_VOIE_INF.VOIE IS 'Type Voie';
COMMENT ON COLUMN CD_VOIE_INF.POSIT IS 'Position';
COMMENT ON COLUMN CD_VOIE_INF.LIBELLE IS 'Libellé';
COMMENT ON COLUMN CD_VOIE_INF.ROULABLE IS 'Roulable';

-- ---------------------------------------------------------
-- Table CONTACT_INF
-- ---------------------------------------------------------
CREATE TABLE CONTACT_INF 
( 
	DOC__ID                                 NUMBER(6) NOT NULL,
	givenName                               VARCHAR2(60 CHAR),
	sn                                      VARCHAR2(60 CHAR),
	cn                                      VARCHAR2(125 CHAR),
	o                                       VARCHAR2(60 CHAR),
	mail                                    VARCHAR2(60 CHAR),
	telephoneNumber                         VARCHAR2(20 CHAR),
	mobile                                  VARCHAR2(20 CHAR),
	facsimiletelephonenumber                VARCHAR2(20 CHAR),
	street                                  VARCHAR2(60 CHAR),
	mozillaWorkStreet2                      VARCHAR2(60 CHAR),
	l                                       VARCHAR2(60 CHAR),
	postalCode                              VARCHAR2(12 CHAR),
	modifytimestamp                         DATE
);
COMMENT ON TABLE CONTACT_INF IS 'Contacts';
COMMENT ON COLUMN CONTACT_INF.DOC__ID IS 'Identificant(cpt)';
COMMENT ON COLUMN CONTACT_INF.givenName IS 'Prénom';
COMMENT ON COLUMN CONTACT_INF.sn IS 'Nom';
COMMENT ON COLUMN CONTACT_INF.cn IS 'Nom complet';
COMMENT ON COLUMN CONTACT_INF.o IS 'Organisation';
COMMENT ON COLUMN CONTACT_INF.mail IS 'Email';
COMMENT ON COLUMN CONTACT_INF.telephoneNumber IS 'Téléphone fixe';
COMMENT ON COLUMN CONTACT_INF.mobile IS 'Téléphone mobile';
COMMENT ON COLUMN CONTACT_INF.facsimiletelephonenumber IS 'Fax';
COMMENT ON COLUMN CONTACT_INF.street IS 'Adresse';
COMMENT ON COLUMN CONTACT_INF.mozillaWorkStreet2 IS 'Adresse complémentaire';
COMMENT ON COLUMN CONTACT_INF.l IS 'Ville';
COMMENT ON COLUMN CONTACT_INF.postalCode IS 'Code Postal';
COMMENT ON COLUMN CONTACT_INF.modifytimestamp IS 'Date MAJ';

-- ---------------------------------------------------------
-- Table CORRESPONDANCE_INF
-- ---------------------------------------------------------
CREATE TABLE CORRESPONDANCE_INF 
( 
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	CHAUSSEE_INF__SENS                      VARCHAR2(6 CHAR) NOT NULL,
	ABS_FIN                                 NUMBER(6) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	AXE_SAE                                 VARCHAR2(60 CHAR) NOT NULL,
	EMPLACE_SAE                             VARCHAR2(60 CHAR) NOT NULL,
	SENS_SAE                                VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CORRESPONDANCE_INF IS 'Correspondance';
COMMENT ON COLUMN CORRESPONDANCE_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN CORRESPONDANCE_INF.CHAUSSEE_INF__SENS IS 'Sens';
COMMENT ON COLUMN CORRESPONDANCE_INF.ABS_FIN IS 'Fin';
COMMENT ON COLUMN CORRESPONDANCE_INF.ABS_DEB IS 'Début';
COMMENT ON COLUMN CORRESPONDANCE_INF.AXE_SAE IS 'Axe SAE';
COMMENT ON COLUMN CORRESPONDANCE_INF.EMPLACE_SAE IS 'Emplacement SAE';
COMMENT ON COLUMN CORRESPONDANCE_INF.SENS_SAE IS 'Sens SAE';

-- ---------------------------------------------------------
-- Table DICTIONNAIRE_INF
-- ---------------------------------------------------------
CREATE TABLE DICTIONNAIRE_INF 
( 
	NOM                                     VARCHAR2(100 CHAR) NOT NULL,
	DESCRIPTION                             VARCHAR2(255 CHAR),
	MOTSCLES                                VARCHAR2(255 CHAR),
	DEFINITION                              VARCHAR2(1000 CHAR)
);
COMMENT ON TABLE DICTIONNAIRE_INF IS 'Dictionnaire';
COMMENT ON COLUMN DICTIONNAIRE_INF.NOM IS 'Nom';
COMMENT ON COLUMN DICTIONNAIRE_INF.DESCRIPTION IS 'Description';
COMMENT ON COLUMN DICTIONNAIRE_INF.MOTSCLES IS 'Mots clés';
COMMENT ON COLUMN DICTIONNAIRE_INF.DEFINITION IS 'Définition';

-- ---------------------------------------------------------
-- Table DOC_INF
-- ---------------------------------------------------------
CREATE TABLE DOC_INF 
( 
	ID                                      NUMBER(6,0) NOT NULL,
	CD_DOC__CODE                            VARCHAR2(15 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(60 CHAR),
	REF                                     VARCHAR2(50 CHAR) NOT NULL
);
COMMENT ON TABLE DOC_INF IS 'Document';
COMMENT ON COLUMN DOC_INF.ID IS 'Identificant(cpt)';
COMMENT ON COLUMN DOC_INF.CD_DOC__CODE IS 'Code document';
COMMENT ON COLUMN DOC_INF.LIBELLE IS 'Libellé';
COMMENT ON COLUMN DOC_INF.REF IS 'Référence';

-- ---------------------------------------------------------
-- Table ECLAIRAGE_INF
-- ---------------------------------------------------------
CREATE TABLE ECLAIRAGE_INF 
( 
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	CHAUSSEE_INF__SENS                      VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	CD_POSIT_INF__POSIT                     VARCHAR2(12 CHAR) NOT NULL,
	CD_ECLAIR_INF__TYPE                     VARCHAR2(25 CHAR) NOT NULL
);
COMMENT ON TABLE ECLAIRAGE_INF IS 'Eclairage';
COMMENT ON COLUMN ECLAIRAGE_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN ECLAIRAGE_INF.CHAUSSEE_INF__SENS IS 'Sens';
COMMENT ON COLUMN ECLAIRAGE_INF.ABS_DEB IS 'Début';
COMMENT ON COLUMN ECLAIRAGE_INF.CD_POSIT_INF__POSIT IS 'Position';
COMMENT ON COLUMN ECLAIRAGE_INF.CD_ECLAIR_INF__TYPE IS 'Eclairage';

-- ---------------------------------------------------------
-- Table EVT_INF
-- ---------------------------------------------------------
CREATE TABLE EVT_INF 
( 
	CD_EVT_INF__TYPE                        VARCHAR2(25 CHAR) NOT NULL,
	ID_EVT                                  NUMBER(9) NOT NULL,
	CD_POSIT_INF__POSIT                     VARCHAR2(12 CHAR),
	NOM_TABLE                               VARCHAR2(60 CHAR) NOT NULL,
	LIAISON                                 VARCHAR2(15 CHAR) NOT NULL,
	SENS                                    VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	ABS_FIN                                 NUMBER(6),
	DATE_REL                                DATE NOT NULL,
	OBSV                                    VARCHAR2(255 CHAR),
	DATE_TRT                                DATE
);
COMMENT ON TABLE EVT_INF IS 'Evénement';
COMMENT ON COLUMN EVT_INF.CD_EVT_INF__TYPE IS 'Type événement';
COMMENT ON COLUMN EVT_INF.ID_EVT IS 'Identifiant Evénement';
COMMENT ON COLUMN EVT_INF.CD_POSIT_INF__POSIT IS 'Position';
COMMENT ON COLUMN EVT_INF.NOM_TABLE IS 'Nom Table';
COMMENT ON COLUMN EVT_INF.LIAISON IS 'Liaison';
COMMENT ON COLUMN EVT_INF.SENS IS 'Sens';
COMMENT ON COLUMN EVT_INF.ABS_DEB IS 'PR début';
COMMENT ON COLUMN EVT_INF.ABS_FIN IS 'PR fin';
COMMENT ON COLUMN EVT_INF.DATE_REL IS 'Date Relevé';
COMMENT ON COLUMN EVT_INF.OBSV IS 'Observation';
COMMENT ON COLUMN EVT_INF.DATE_TRT IS 'Date Traitement';

-- ---------------------------------------------------------
-- Table FAM_DEC_INF
-- ---------------------------------------------------------
CREATE TABLE FAM_DEC_INF 
( 
	FAM_DEC                                 VARCHAR2(6 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE FAM_DEC_INF IS 'Famille découpage';
COMMENT ON COLUMN FAM_DEC_INF.FAM_DEC IS 'Code famille';
COMMENT ON COLUMN FAM_DEC_INF.LIBELLE IS 'Libellé';

-- ---------------------------------------------------------
-- Table WGS_INF
-- ---------------------------------------------------------
CREATE TABLE WGS_INF 
( 
	LINE_INDEX                              NUMBER(2) NOT NULL,
	LAYER_NAME                              VARCHAR2(100 CHAR) NOT NULL,
	LIAISON                                 VARCHAR2(16 CHAR) NOT NULL,
	SENS                                    VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	ABS_FIN                                 NUMBER(6) NOT NULL,
	X1                                      NUMBER(20,10) NOT NULL,
	Y1                                      NUMBER(20,10) NOT NULL,
	X2                                      NUMBER(20,10) NOT NULL,
	Y2                                      NUMBER(20,10) NOT NULL
);
COMMENT ON TABLE WGS_INF IS 'Filaire';
COMMENT ON COLUMN WGS_INF.LINE_INDEX IS 'Index ligne';
COMMENT ON COLUMN WGS_INF.LAYER_NAME IS 'Modèle';
COMMENT ON COLUMN WGS_INF.LIAISON IS 'Liaison';
COMMENT ON COLUMN WGS_INF.SENS IS 'Sens';
COMMENT ON COLUMN WGS_INF.ABS_DEB IS 'Début';
COMMENT ON COLUMN WGS_INF.ABS_FIN IS 'Fin';
COMMENT ON COLUMN WGS_INF.X1 IS 'X1';
COMMENT ON COLUMN WGS_INF.Y1 IS 'Y1';
COMMENT ON COLUMN WGS_INF.X2 IS 'X2';
COMMENT ON COLUMN WGS_INF.Y2 IS 'Y2';

-- ---------------------------------------------------------
-- Table GARE_INF
-- ---------------------------------------------------------
CREATE TABLE GARE_INF 
( 
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	CHAUSSEE_INF__SENS                      VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	CD_GARE_INF__TYPE                       VARCHAR2(60 CHAR) NOT NULL,
	NUM_EXPLOIT                             VARCHAR2(15 CHAR),
	NOM                                     VARCHAR2(60 CHAR),
	DATE_MS                                 DATE,
	OBSERV                                  VARCHAR2(250 CHAR),
	VOI_ENTREE                              NUMBER(2),
	VOI_SORTIE                              NUMBER(2),
	VOI_MIXTE                               NUMBER(2),
	VOI_TSA                                 NUMBER(2),
	X1                                      NUMBER(22,11),
	Y1                                      NUMBER(22,11),
	Z1                                      NUMBER(22,11),
	DATE_RELEVE                             DATE,
	TERRAIN                                 NUMBER
);
COMMENT ON TABLE GARE_INF IS 'Gare';
COMMENT ON COLUMN GARE_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN GARE_INF.CHAUSSEE_INF__SENS IS 'Sens';
COMMENT ON COLUMN GARE_INF.ABS_DEB IS 'Pr';
COMMENT ON COLUMN GARE_INF.CD_GARE_INF__TYPE IS 'Type Gare';
COMMENT ON COLUMN GARE_INF.NUM_EXPLOIT IS 'N° Exploitation';
COMMENT ON COLUMN GARE_INF.NOM IS 'Nom d''usage';
COMMENT ON COLUMN GARE_INF.DATE_MS IS 'Date MS';
COMMENT ON COLUMN GARE_INF.OBSERV IS 'Commentaire';
COMMENT ON COLUMN GARE_INF.VOI_ENTREE IS 'Nbr Voies Entrée';
COMMENT ON COLUMN GARE_INF.VOI_SORTIE IS 'Nbr Voies Sortie';
COMMENT ON COLUMN GARE_INF.VOI_MIXTE IS 'Nbr Voies Mixte';
COMMENT ON COLUMN GARE_INF.VOI_TSA IS 'Nbr Voies TSA';
COMMENT ON COLUMN GARE_INF.X1 IS 'X1';
COMMENT ON COLUMN GARE_INF.Y1 IS 'Y1';
COMMENT ON COLUMN GARE_INF.Z1 IS 'Z1';
COMMENT ON COLUMN GARE_INF.DATE_RELEVE IS 'Date relevé';
COMMENT ON COLUMN GARE_INF.TERRAIN IS 'Terrain';

-- ---------------------------------------------------------
-- Table LIAISON_INF
-- ---------------------------------------------------------
CREATE TABLE LIAISON_INF 
( 
	LIAISON                                 VARCHAR2(15 CHAR) NOT NULL,
	CD_LIAISON_INF__CD_LIAISON              VARCHAR2(5 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(60 CHAR)
);
COMMENT ON TABLE LIAISON_INF IS 'Liaison';
COMMENT ON COLUMN LIAISON_INF.LIAISON IS 'Liaison';
COMMENT ON COLUMN LIAISON_INF.CD_LIAISON_INF__CD_LIAISON IS 'Code';
COMMENT ON COLUMN LIAISON_INF.LIBELLE IS 'Libellé';

-- ---------------------------------------------------------
-- Table OCCUPATION_INF
-- ---------------------------------------------------------
CREATE TABLE OCCUPATION_INF 
( 
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	CHAUSSEE_INF__SENS                      VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	ABS_FIN                                 NUMBER(6),
	CD_OCCUP_INF__TYPE                      VARCHAR2(60 CHAR) NOT NULL,
	CD_OCCUPANT_INF__NOM                    VARCHAR2(60 CHAR) NOT NULL,
	DATE_MS                                 DATE,
	DATE_FV                                 DATE,
	TRAV                                    NUMBER,
	OBS                                     VARCHAR2(255 CHAR)
);
COMMENT ON TABLE OCCUPATION_INF IS 'Occupation';
COMMENT ON COLUMN OCCUPATION_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN OCCUPATION_INF.CHAUSSEE_INF__SENS IS 'Sens';
COMMENT ON COLUMN OCCUPATION_INF.ABS_DEB IS 'Début';
COMMENT ON COLUMN OCCUPATION_INF.ABS_FIN IS 'Fin';
COMMENT ON COLUMN OCCUPATION_INF.CD_OCCUP_INF__TYPE IS 'Type Occupation';
COMMENT ON COLUMN OCCUPATION_INF.CD_OCCUPANT_INF__NOM IS 'Nom';
COMMENT ON COLUMN OCCUPATION_INF.DATE_MS IS 'Date Début';
COMMENT ON COLUMN OCCUPATION_INF.DATE_FV IS 'Date Fin';
COMMENT ON COLUMN OCCUPATION_INF.TRAV IS 'Traversé';
COMMENT ON COLUMN OCCUPATION_INF.OBS IS 'Commentaire';

-- ---------------------------------------------------------
-- Table DSC_OA_INF
-- ---------------------------------------------------------
CREATE TABLE DSC_OA_INF 
( 
	CODE_OA                                 NUMBER(11) NOT NULL,
	NUM_OA                                  VARCHAR2(40 CHAR),
	LIAISON                                 VARCHAR2(15 CHAR) NOT NULL,
	SENS                                    VARCHAR2(6 CHAR) NOT NULL,
	PR_OA                                   VARCHAR2(10 CHAR),
	ABS_DEB                                 NUMBER(6),
	NUM_EXPLOIT                             VARCHAR2(80 CHAR),
	NOM_USAGE                               VARCHAR2(100 CHAR),
	FAMILLE                                 VARCHAR2(80 CHAR),
	TYPE_OUVRAGE                            VARCHAR2(80 CHAR),
	MATERIAUX                               VARCHAR2(80 CHAR),
	DATE_MS                                 DATE,
	NBRE_TABLIERS                           NUMBER(1),
	NBRE_TRAVEE                             NUMBER(2),
	GABARIT                                 NUMBER(3,2),
	LONGUEUR                                NUMBER(6,2),
	LARGEUR                                 NUMBER(4,2),
	SECT_COURANTE                           NUMBER,
	IQOA                                    VARCHAR2(8 CHAR),
	NOTE_URGENCE                            NUMBER(6,2)
);
COMMENT ON TABLE DSC_OA_INF IS 'Ouvrages d''art';
COMMENT ON COLUMN DSC_OA_INF.CODE_OA IS 'IDOA';
COMMENT ON COLUMN DSC_OA_INF.NUM_OA IS 'NumOA';
COMMENT ON COLUMN DSC_OA_INF.LIAISON IS 'Liaison';
COMMENT ON COLUMN DSC_OA_INF.SENS IS 'Sens';
COMMENT ON COLUMN DSC_OA_INF.PR_OA IS 'PR_OA';
COMMENT ON COLUMN DSC_OA_INF.ABS_DEB IS 'Localisation';
COMMENT ON COLUMN DSC_OA_INF.NUM_EXPLOIT IS 'N° d''exploitation';
COMMENT ON COLUMN DSC_OA_INF.NOM_USAGE IS 'Nom d''usage';
COMMENT ON COLUMN DSC_OA_INF.FAMILLE IS 'Famille';
COMMENT ON COLUMN DSC_OA_INF.TYPE_OUVRAGE IS 'Type d''ouvrage';
COMMENT ON COLUMN DSC_OA_INF.MATERIAUX IS 'Matériaux';
COMMENT ON COLUMN DSC_OA_INF.DATE_MS IS 'Date MS';
COMMENT ON COLUMN DSC_OA_INF.NBRE_TABLIERS IS 'Nbre Tabliers';
COMMENT ON COLUMN DSC_OA_INF.NBRE_TRAVEE IS 'Nbre Travées';
COMMENT ON COLUMN DSC_OA_INF.GABARIT IS 'Gabarit (m)';
COMMENT ON COLUMN DSC_OA_INF.LONGUEUR IS 'Longueur (m)';
COMMENT ON COLUMN DSC_OA_INF.LARGEUR IS 'Largeur (m)';
COMMENT ON COLUMN DSC_OA_INF.SECT_COURANTE IS 'Section courante';
COMMENT ON COLUMN DSC_OA_INF.IQOA IS 'Note IQOA';
COMMENT ON COLUMN DSC_OA_INF.NOTE_URGENCE IS 'Niveau d''urgence';

-- ---------------------------------------------------------
-- Table PAVE_VOIE_INF
-- ---------------------------------------------------------
CREATE TABLE PAVE_VOIE_INF 
( 
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	CHAUSSEE_INF__SENS                      VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	ABS_FIN                                 NUMBER(6) NOT NULL,
	CD_VOIE_INF__VOIE                       VARCHAR2(6 CHAR) NOT NULL,
	LARGEUR                                 NUMBER(5,2) NOT NULL,
	DATE_MS                                 DATE NOT NULL
);
COMMENT ON TABLE PAVE_VOIE_INF IS 'Pavés Voies';
COMMENT ON COLUMN PAVE_VOIE_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN PAVE_VOIE_INF.CHAUSSEE_INF__SENS IS 'Sens';
COMMENT ON COLUMN PAVE_VOIE_INF.ABS_DEB IS 'Début';
COMMENT ON COLUMN PAVE_VOIE_INF.ABS_FIN IS 'Fin';
COMMENT ON COLUMN PAVE_VOIE_INF.CD_VOIE_INF__VOIE IS 'Type Voie';
COMMENT ON COLUMN PAVE_VOIE_INF.LARGEUR IS 'Largeur (m)';
COMMENT ON COLUMN PAVE_VOIE_INF.DATE_MS IS 'Date MS';

-- ---------------------------------------------------------
-- Table PK_INF
-- ---------------------------------------------------------
CREATE TABLE PK_INF 
( 
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	CHAUSSEE_INF__SENS                      VARCHAR2(6 CHAR) NOT NULL,
	ABS_CUM                                 NUMBER(6) NOT NULL,
	NUM                                     NUMBER(6) NOT NULL,
	INTER                                   NUMBER(4) NOT NULL
);
COMMENT ON TABLE PK_INF IS 'PK Construction';
COMMENT ON COLUMN PK_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN PK_INF.CHAUSSEE_INF__SENS IS 'Sens';
COMMENT ON COLUMN PK_INF.ABS_CUM IS 'Abscisse cumulée';
COMMENT ON COLUMN PK_INF.NUM IS 'Numéro PK';
COMMENT ON COLUMN PK_INF.INTER IS 'Inter PK';

-- ---------------------------------------------------------
-- Table AIRE__PLACE_INF
-- ---------------------------------------------------------
CREATE TABLE AIRE__PLACE_INF 
( 
	CD_PLACE_INF__PARKING                   VARCHAR2(60 CHAR) NOT NULL,
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	CD_AIRE_INF__TYPE                       VARCHAR2(60 CHAR) NOT NULL,
	CHAUSSEE_INF__SENS                      VARCHAR2(6 CHAR) NOT NULL,
	AIRE_INF__ABS_DEB                       NUMBER(6) NOT NULL,
	NBRE                                    NUMBER(3)
);
COMMENT ON TABLE AIRE__PLACE_INF IS 'Place Parking';
COMMENT ON COLUMN AIRE__PLACE_INF.CD_PLACE_INF__PARKING IS 'Type Parking';
COMMENT ON COLUMN AIRE__PLACE_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN AIRE__PLACE_INF.CD_AIRE_INF__TYPE IS 'Type Aire';
COMMENT ON COLUMN AIRE__PLACE_INF.CHAUSSEE_INF__SENS IS 'Sens';
COMMENT ON COLUMN AIRE__PLACE_INF.AIRE_INF__ABS_DEB IS 'Début';
COMMENT ON COLUMN AIRE__PLACE_INF.NBRE IS 'Nbre de place';

-- ---------------------------------------------------------
-- Table PT_SING_INF
-- ---------------------------------------------------------
CREATE TABLE PT_SING_INF 
( 
	CD_PT_SING_INF__CODE                    VARCHAR2(6 CHAR) NOT NULL,
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	CHAUSSEE_INF__SENS                      VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	NOM_USAGE                               VARCHAR2(60 CHAR),
	LIBELLE                                 VARCHAR2(60 CHAR),
	COMMENTAIRE                             VARCHAR2(1000 CHAR)
);
COMMENT ON TABLE PT_SING_INF IS 'Point singulier';
COMMENT ON COLUMN PT_SING_INF.CD_PT_SING_INF__CODE IS 'Code type';
COMMENT ON COLUMN PT_SING_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN PT_SING_INF.CHAUSSEE_INF__SENS IS 'Sens';
COMMENT ON COLUMN PT_SING_INF.ABS_DEB IS 'Début';
COMMENT ON COLUMN PT_SING_INF.NOM_USAGE IS 'Nom d''usage';
COMMENT ON COLUMN PT_SING_INF.LIBELLE IS 'Libellé';
COMMENT ON COLUMN PT_SING_INF.COMMENTAIRE IS 'Commentaire';

-- ---------------------------------------------------------
-- Table REPERE_INF
-- ---------------------------------------------------------
CREATE TABLE REPERE_INF 
( 
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	CHAUSSEE_INF__SENS                      VARCHAR2(6 CHAR) NOT NULL,
	NUM                                     NUMBER(6) NOT NULL,
	INTER                                   NUMBER(4) NOT NULL,
	ABS_CUM                                 NUMBER(6)
);
COMMENT ON TABLE REPERE_INF IS 'PR Exploitation';
COMMENT ON COLUMN REPERE_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN REPERE_INF.CHAUSSEE_INF__SENS IS 'Sens';
COMMENT ON COLUMN REPERE_INF.NUM IS 'Numéro PR';
COMMENT ON COLUMN REPERE_INF.INTER IS 'Inter PR';
COMMENT ON COLUMN REPERE_INF.ABS_CUM IS 'Abscisse cumulée';

-- ---------------------------------------------------------
-- Table PRESTATAIRE_INF
-- ---------------------------------------------------------
CREATE TABLE PRESTATAIRE_INF 
( 
	CD_PRESTATAIRE_INF__TYPE                VARCHAR2(60 CHAR) NOT NULL,
	NOM                                     VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE PRESTATAIRE_INF IS 'Prestataire';
COMMENT ON COLUMN PRESTATAIRE_INF.CD_PRESTATAIRE_INF__TYPE IS 'Type Prestataire';
COMMENT ON COLUMN PRESTATAIRE_INF.NOM IS 'Enseigne';

-- ---------------------------------------------------------
-- Table AIRE__PRESTATAIRE_INF
-- ---------------------------------------------------------
CREATE TABLE AIRE__PRESTATAIRE_INF 
( 
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	CHAUSSEE_INF__SENS                      VARCHAR2(6 CHAR) NOT NULL,
	AIRE_INF__ABS_DEB                       NUMBER(6) NOT NULL,
	CD_AIRE_INF__TYPE                       VARCHAR2(60 CHAR) NOT NULL,
	CD_PRESTATAIRE_INF__TYPE                VARCHAR2(60 CHAR) NOT NULL,
	PRESTATAIRE_INF__NOM                    VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE AIRE__PRESTATAIRE_INF IS 'Prestataire Aire';
COMMENT ON COLUMN AIRE__PRESTATAIRE_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN AIRE__PRESTATAIRE_INF.CHAUSSEE_INF__SENS IS 'Sens';
COMMENT ON COLUMN AIRE__PRESTATAIRE_INF.AIRE_INF__ABS_DEB IS 'Début';
COMMENT ON COLUMN AIRE__PRESTATAIRE_INF.CD_AIRE_INF__TYPE IS 'Type Aire';
COMMENT ON COLUMN AIRE__PRESTATAIRE_INF.CD_PRESTATAIRE_INF__TYPE IS 'Type Prestataire';
COMMENT ON COLUMN AIRE__PRESTATAIRE_INF.PRESTATAIRE_INF__NOM IS 'Enseigne';

-- ---------------------------------------------------------
-- Table PREV_SGE_INF
-- ---------------------------------------------------------
CREATE TABLE PREV_SGE_INF 
( 
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	CHAUSSEE_INF__SENS                      VARCHAR2(6 CHAR) NOT NULL,
	SCHEMA                                  VARCHAR2(5 CHAR) NOT NULL,
	DATE_DEB                                DATE NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	NATURE                                  VARCHAR2(125 CHAR) NOT NULL,
	NUM_OUVRAGE                             VARCHAR2(20 CHAR) NOT NULL,
	DATE_FIN                                DATE,
	ABS_FIN                                 NUMBER(6),
	CE                                      VARCHAR2(100 CHAR),
	DATE_PUB                                DATE,
	DATE_FINPUB                             DATE,
	DATE_DEMANDE                            DATE,
	NOM_USAGE                               VARCHAR2(30 CHAR),
	COMMENTAIRE                             VARCHAR2(255 CHAR)
);
COMMENT ON TABLE PREV_SGE_INF IS 'Prévision Travaux';
COMMENT ON COLUMN PREV_SGE_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN PREV_SGE_INF.CHAUSSEE_INF__SENS IS 'Sens';
COMMENT ON COLUMN PREV_SGE_INF.SCHEMA IS 'Base métier';
COMMENT ON COLUMN PREV_SGE_INF.DATE_DEB IS 'Date début';
COMMENT ON COLUMN PREV_SGE_INF.ABS_DEB IS 'Début';
COMMENT ON COLUMN PREV_SGE_INF.NATURE IS 'Nature';
COMMENT ON COLUMN PREV_SGE_INF.NUM_OUVRAGE IS 'Num Ouvrage';
COMMENT ON COLUMN PREV_SGE_INF.DATE_FIN IS 'Date fin';
COMMENT ON COLUMN PREV_SGE_INF.ABS_FIN IS 'Fin';
COMMENT ON COLUMN PREV_SGE_INF.CE IS 'Contrainte d''exploit';
COMMENT ON COLUMN PREV_SGE_INF.DATE_PUB IS 'Date Publication';
COMMENT ON COLUMN PREV_SGE_INF.DATE_FINPUB IS 'Date Fin Publication';
COMMENT ON COLUMN PREV_SGE_INF.DATE_DEMANDE IS 'Date demande';
COMMENT ON COLUMN PREV_SGE_INF.NOM_USAGE IS 'Nom d''usage';
COMMENT ON COLUMN PREV_SGE_INF.COMMENTAIRE IS 'Commentaire';

-- ---------------------------------------------------------
-- Table AMENAGEMENT_INF
-- ---------------------------------------------------------
CREATE TABLE AMENAGEMENT_INF 
( 
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	CHAUSSEE_INF__SENS                      VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	ABS_FIN                                 NUMBER(6),
	CD_AMENAG_INF__TYPE_AMENAG              VARCHAR2(60 CHAR) NOT NULL,
	DATE_DEB                                DATE NOT NULL,
	DATE_FIN                                DATE,
	COUT                                    NUMBER(6),
	OBSERV                                  VARCHAR2(255 CHAR)
);
COMMENT ON TABLE AMENAGEMENT_INF IS 'Projet Aménagement';
COMMENT ON COLUMN AMENAGEMENT_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN AMENAGEMENT_INF.CHAUSSEE_INF__SENS IS 'Sens';
COMMENT ON COLUMN AMENAGEMENT_INF.ABS_DEB IS 'Début';
COMMENT ON COLUMN AMENAGEMENT_INF.ABS_FIN IS 'Fin';
COMMENT ON COLUMN AMENAGEMENT_INF.CD_AMENAG_INF__TYPE_AMENAG IS 'Aménagement';
COMMENT ON COLUMN AMENAGEMENT_INF.DATE_DEB IS 'Date début';
COMMENT ON COLUMN AMENAGEMENT_INF.DATE_FIN IS 'Date Fin';
COMMENT ON COLUMN AMENAGEMENT_INF.COUT IS 'Coûts (k€)';
COMMENT ON COLUMN AMENAGEMENT_INF.OBSERV IS 'Commentaire';

-- ---------------------------------------------------------
-- Table REPARTITION_TRAFIC_INF
-- ---------------------------------------------------------
CREATE TABLE REPARTITION_TRAFIC_INF 
( 
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	CHAUSSEE_INF__SENS                      VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	ABS_FIN                                 NUMBER(6),
	ANNEE                                   NUMBER(4) NOT NULL,
	P_PL                                    NUMBER(3)
);
COMMENT ON TABLE REPARTITION_TRAFIC_INF IS 'Répartition Trafic Voie lente';
COMMENT ON COLUMN REPARTITION_TRAFIC_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN REPARTITION_TRAFIC_INF.CHAUSSEE_INF__SENS IS 'Sens';
COMMENT ON COLUMN REPARTITION_TRAFIC_INF.ABS_DEB IS 'PR debut';
COMMENT ON COLUMN REPARTITION_TRAFIC_INF.ABS_FIN IS 'PR fin';
COMMENT ON COLUMN REPARTITION_TRAFIC_INF.ANNEE IS 'Année';
COMMENT ON COLUMN REPARTITION_TRAFIC_INF.P_PL IS 'Répartition trafic PL (%)';

-- ---------------------------------------------------------
-- Table SECTION_TRAFIC_INF
-- ---------------------------------------------------------
CREATE TABLE SECTION_TRAFIC_INF 
( 
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	CHAUSSEE_INF__SENS                      VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	ABS_FIN                                 NUMBER(6),
	CD_CLASS_TRAF_INF__CODE                 VARCHAR2(6 CHAR) NOT NULL,
	TENANT                                  VARCHAR2(60 CHAR),
	ABOUTIS                                 VARCHAR2(60 CHAR)
);
COMMENT ON TABLE SECTION_TRAFIC_INF IS 'Section Trafic';
COMMENT ON COLUMN SECTION_TRAFIC_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN SECTION_TRAFIC_INF.CHAUSSEE_INF__SENS IS 'Sens';
COMMENT ON COLUMN SECTION_TRAFIC_INF.ABS_DEB IS 'Début';
COMMENT ON COLUMN SECTION_TRAFIC_INF.ABS_FIN IS 'Fin';
COMMENT ON COLUMN SECTION_TRAFIC_INF.CD_CLASS_TRAF_INF__CODE IS 'Classe de trafic';
COMMENT ON COLUMN SECTION_TRAFIC_INF.TENANT IS 'Tenant';
COMMENT ON COLUMN SECTION_TRAFIC_INF.ABOUTIS IS 'Aboutissant';

-- ---------------------------------------------------------
-- Table SECURITE_INF
-- ---------------------------------------------------------
CREATE TABLE SECURITE_INF 
( 
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	CHAUSSEE_INF__SENS                      VARCHAR2(6 CHAR) NOT NULL,
	CD_POSIT_INF__POSIT                     VARCHAR2(12 CHAR) NOT NULL,
	CD_SECUR_INF__TYPE                      VARCHAR2(25 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	ABS_FIN                                 NUMBER(6)
);
COMMENT ON TABLE SECURITE_INF IS 'Sécurité';
COMMENT ON COLUMN SECURITE_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN SECURITE_INF.CHAUSSEE_INF__SENS IS 'Sens';
COMMENT ON COLUMN SECURITE_INF.CD_POSIT_INF__POSIT IS 'Position';
COMMENT ON COLUMN SECURITE_INF.CD_SECUR_INF__TYPE IS 'Sécurité';
COMMENT ON COLUMN SECURITE_INF.ABS_DEB IS 'Début';
COMMENT ON COLUMN SECURITE_INF.ABS_FIN IS 'Fin';

-- ---------------------------------------------------------
-- Table AIRE__SERVICE_INF
-- ---------------------------------------------------------
CREATE TABLE AIRE__SERVICE_INF 
( 
	CD_SERVICE_INF__SERVICE                 VARCHAR2(60 CHAR) NOT NULL,
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	CD_AIRE_INF__TYPE                       VARCHAR2(60 CHAR) NOT NULL,
	CHAUSSEE_INF__SENS                      VARCHAR2(6 CHAR) NOT NULL,
	AIRE_INF__ABS_DEB                       NUMBER(6) NOT NULL
);
COMMENT ON TABLE AIRE__SERVICE_INF IS 'Service Aire';
COMMENT ON COLUMN AIRE__SERVICE_INF.CD_SERVICE_INF__SERVICE IS 'Type Service';
COMMENT ON COLUMN AIRE__SERVICE_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN AIRE__SERVICE_INF.CD_AIRE_INF__TYPE IS 'Type Aire';
COMMENT ON COLUMN AIRE__SERVICE_INF.CHAUSSEE_INF__SENS IS 'Sens';
COMMENT ON COLUMN AIRE__SERVICE_INF.AIRE_INF__ABS_DEB IS 'Début';

-- ---------------------------------------------------------
-- Table SYS_USER_INF
-- ---------------------------------------------------------
CREATE TABLE SYS_USER_INF 
( 
	CODE_DBS                                VARCHAR2(50 CHAR) NOT NULL,
	CODE_TABLE                              VARCHAR2(100 CHAR) NOT NULL,
	CODE_COLONNE                            VARCHAR2(100 CHAR) NOT NULL,
	NOM_USER                                VARCHAR2(150 CHAR) NOT NULL,
	CODE_PRP                                VARCHAR2(255 CHAR) NOT NULL,
	VAL_PRP                                 VARCHAR2(500 CHAR) NOT NULL
);
COMMENT ON TABLE SYS_USER_INF IS 'SYS_USER_INF';
COMMENT ON COLUMN SYS_USER_INF.CODE_DBS IS 'SYS_USER_INF__CODE_DBS';
COMMENT ON COLUMN SYS_USER_INF.CODE_TABLE IS 'SYS_USER_INF__CODE_TABLE';
COMMENT ON COLUMN SYS_USER_INF.CODE_COLONNE IS 'SYS_USER_INF__CODE_COLONNE';
COMMENT ON COLUMN SYS_USER_INF.NOM_USER IS 'SYS_USER_INF__NOM_USER';
COMMENT ON COLUMN SYS_USER_INF.CODE_PRP IS 'SYS_USER_INF__CODE_PRP';
COMMENT ON COLUMN SYS_USER_INF.VAL_PRP IS 'SYS_USER_INF__VAL_PRP';

-- ---------------------------------------------------------
-- Table TALUS_INF
-- ---------------------------------------------------------
CREATE TABLE TALUS_INF 
( 
	CD_TALUS_INF__TYPE                      VARCHAR2(25 CHAR) NOT NULL,
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	CHAUSSEE_INF__SENS                      VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	ABS_FIN                                 NUMBER(6),
	HAUT                                    NUMBER(4,2)
);
COMMENT ON TABLE TALUS_INF IS 'Talus';
COMMENT ON COLUMN TALUS_INF.CD_TALUS_INF__TYPE IS 'Type Talus';
COMMENT ON COLUMN TALUS_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN TALUS_INF.CHAUSSEE_INF__SENS IS 'Sens';
COMMENT ON COLUMN TALUS_INF.ABS_DEB IS 'Début';
COMMENT ON COLUMN TALUS_INF.ABS_FIN IS 'Fin';
COMMENT ON COLUMN TALUS_INF.HAUT IS 'hauteur (m)';

-- ---------------------------------------------------------
-- Table TPC_INF
-- ---------------------------------------------------------
CREATE TABLE TPC_INF 
( 
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	CHAUSSEE_INF__SENS                      VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	ABS_FIN                                 NUMBER(6) NOT NULL,
	CD_TPC_INF__CODE                        VARCHAR2(6 CHAR) NOT NULL,
	LARGEUR                                 NUMBER(4,2)
);
COMMENT ON TABLE TPC_INF IS 'Terre plein central';
COMMENT ON COLUMN TPC_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN TPC_INF.CHAUSSEE_INF__SENS IS 'Sens';
COMMENT ON COLUMN TPC_INF.ABS_DEB IS 'Début';
COMMENT ON COLUMN TPC_INF.ABS_FIN IS 'Fin';
COMMENT ON COLUMN TPC_INF.CD_TPC_INF__CODE IS 'Code type';
COMMENT ON COLUMN TPC_INF.LARGEUR IS 'Largeur (m)';

-- ---------------------------------------------------------
-- Table TRAFIC_INF
-- ---------------------------------------------------------
CREATE TABLE TRAFIC_INF 
( 
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	CHAUSSEE_INF__SENS                      VARCHAR2(6 CHAR) NOT NULL,
	ANNEE                                   NUMBER(4) NOT NULL,
	PL                                      NUMBER(4,2),
	TMJA                                    NUMBER(7)
);
COMMENT ON TABLE TRAFIC_INF IS 'Trafic';
COMMENT ON COLUMN TRAFIC_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN TRAFIC_INF.CHAUSSEE_INF__SENS IS 'Sens';
COMMENT ON COLUMN TRAFIC_INF.ANNEE IS 'Année';
COMMENT ON COLUMN TRAFIC_INF.PL IS 'PL (%)';
COMMENT ON COLUMN TRAFIC_INF.TMJA IS 'TMJA';

-- ---------------------------------------------------------
-- Table TR_DEC_INF
-- ---------------------------------------------------------
CREATE TABLE TR_DEC_INF 
( 
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	CHAUSSEE_INF__SENS                      VARCHAR2(6 CHAR) NOT NULL,
	FAM_DEC_INF__FAM_DEC                    VARCHAR2(6 CHAR) NOT NULL,
	CD_DEC_INF__CD_DEC                      VARCHAR2(15 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	ABS_FIN                                 NUMBER(6) NOT NULL
);
COMMENT ON TABLE TR_DEC_INF IS 'Tronçon découpage';
COMMENT ON COLUMN TR_DEC_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN TR_DEC_INF.CHAUSSEE_INF__SENS IS 'Sens';
COMMENT ON COLUMN TR_DEC_INF.FAM_DEC_INF__FAM_DEC IS 'Code famille';
COMMENT ON COLUMN TR_DEC_INF.CD_DEC_INF__CD_DEC IS 'Code decoupage';
COMMENT ON COLUMN TR_DEC_INF.ABS_DEB IS 'Début';
COMMENT ON COLUMN TR_DEC_INF.ABS_FIN IS 'Fin';

-- ---------------------------------------------------------
-- Table CD_AIRE_INF
-- ---------------------------------------------------------
CREATE TABLE CD_AIRE_INF 
( 
	TYPE                                    VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_AIRE_INF IS 'Type Aires';
COMMENT ON COLUMN CD_AIRE_INF.TYPE IS 'Type Aire';

-- ---------------------------------------------------------
-- Table CD_AMENAG_INF
-- ---------------------------------------------------------
CREATE TABLE CD_AMENAG_INF 
( 
	TYPE_AMENAG                             VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_AMENAG_INF IS 'Type Aménagement';
COMMENT ON COLUMN CD_AMENAG_INF.TYPE_AMENAG IS 'Aménagement';

-- ---------------------------------------------------------
-- Table CD_BIF_INF
-- ---------------------------------------------------------
CREATE TABLE CD_BIF_INF 
( 
	TYPE                                    VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_BIF_INF IS 'Type Bifurcation';
COMMENT ON COLUMN CD_BIF_INF.TYPE IS 'Type Bifurcation';

-- ---------------------------------------------------------
-- Table CD_DOC_INF
-- ---------------------------------------------------------
CREATE TABLE CD_DOC_INF 
( 
	CODE                                    VARCHAR2(15 CHAR) NOT NULL,
	PATH                                    VARCHAR2(255 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_DOC_INF IS 'Type de document';
COMMENT ON COLUMN CD_DOC_INF.CODE IS 'Code document';
COMMENT ON COLUMN CD_DOC_INF.PATH IS 'Répertoire';
COMMENT ON COLUMN CD_DOC_INF.LIBELLE IS 'Libellé';

-- ---------------------------------------------------------
-- Table CD_EVT_INF
-- ---------------------------------------------------------
CREATE TABLE CD_EVT_INF 
( 
	TYPE                                    VARCHAR2(25 CHAR) NOT NULL,
	IMPACT                                  NUMBER
);
COMMENT ON TABLE CD_EVT_INF IS 'Type d''événement';
COMMENT ON COLUMN CD_EVT_INF.TYPE IS 'Type événement';
COMMENT ON COLUMN CD_EVT_INF.IMPACT IS 'Impact métier';

-- ---------------------------------------------------------
-- Table CD_ECLAIR_INF
-- ---------------------------------------------------------
CREATE TABLE CD_ECLAIR_INF 
( 
	TYPE                                    VARCHAR2(25 CHAR) NOT NULL
);
COMMENT ON TABLE CD_ECLAIR_INF IS 'Type Eclairage';
COMMENT ON COLUMN CD_ECLAIR_INF.TYPE IS 'Eclairage';

-- ---------------------------------------------------------
-- Table CD_GARE_INF
-- ---------------------------------------------------------
CREATE TABLE CD_GARE_INF 
( 
	TYPE                                    VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_GARE_INF IS 'Type Gare';
COMMENT ON COLUMN CD_GARE_INF.TYPE IS 'Type Gare';

-- ---------------------------------------------------------
-- Table CD_LIAISON_INF
-- ---------------------------------------------------------
CREATE TABLE CD_LIAISON_INF 
( 
	CD_LIAISON                              VARCHAR2(5 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_LIAISON_INF IS 'Type Liaison';
COMMENT ON COLUMN CD_LIAISON_INF.CD_LIAISON IS 'Code';
COMMENT ON COLUMN CD_LIAISON_INF.LIBELLE IS 'Libellé';

-- ---------------------------------------------------------
-- Table CD_OCCUPANT_INF
-- ---------------------------------------------------------
CREATE TABLE CD_OCCUPANT_INF 
( 
	NOM                                     VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_OCCUPANT_INF IS 'Type Occupant';
COMMENT ON COLUMN CD_OCCUPANT_INF.NOM IS 'Nom';

-- ---------------------------------------------------------
-- Table CD_OCCUP_INF
-- ---------------------------------------------------------
CREATE TABLE CD_OCCUP_INF 
( 
	TYPE                                    VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_OCCUP_INF IS 'Type Occupation';
COMMENT ON COLUMN CD_OCCUP_INF.TYPE IS 'Type Occupation';

-- ---------------------------------------------------------
-- Table CD_PLACE_INF
-- ---------------------------------------------------------
CREATE TABLE CD_PLACE_INF 
( 
	PARKING                                 VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_PLACE_INF IS 'Type parking';
COMMENT ON COLUMN CD_PLACE_INF.PARKING IS 'Type Parking';

-- ---------------------------------------------------------
-- Table CD_PT_SING_INF
-- ---------------------------------------------------------
CREATE TABLE CD_PT_SING_INF 
( 
	CODE                                    VARCHAR2(6 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_PT_SING_INF IS 'Type Point Singulier';
COMMENT ON COLUMN CD_PT_SING_INF.CODE IS 'Code type';
COMMENT ON COLUMN CD_PT_SING_INF.LIBELLE IS 'Libellé';

-- ---------------------------------------------------------
-- Table CD_PRESTATAIRE_INF
-- ---------------------------------------------------------
CREATE TABLE CD_PRESTATAIRE_INF 
( 
	TYPE                                    VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_PRESTATAIRE_INF IS 'Type Prestataire';
COMMENT ON COLUMN CD_PRESTATAIRE_INF.TYPE IS 'Type Prestataire';

-- ---------------------------------------------------------
-- Table CD_SECUR_INF
-- ---------------------------------------------------------
CREATE TABLE CD_SECUR_INF 
( 
	TYPE                                    VARCHAR2(25 CHAR) NOT NULL
);
COMMENT ON TABLE CD_SECUR_INF IS 'Type Sécurité';
COMMENT ON COLUMN CD_SECUR_INF.TYPE IS 'Sécurité';

-- ---------------------------------------------------------
-- Table CD_SERVICE_INF
-- ---------------------------------------------------------
CREATE TABLE CD_SERVICE_INF 
( 
	SERVICE                                 VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_SERVICE_INF IS 'Type Service';
COMMENT ON COLUMN CD_SERVICE_INF.SERVICE IS 'Type Service';

-- ---------------------------------------------------------
-- Table CD_TALUS_INF
-- ---------------------------------------------------------
CREATE TABLE CD_TALUS_INF 
( 
	TYPE                                    VARCHAR2(25 CHAR) NOT NULL
);
COMMENT ON TABLE CD_TALUS_INF IS 'Type Talus';
COMMENT ON COLUMN CD_TALUS_INF.TYPE IS 'Type Talus';

-- ---------------------------------------------------------
-- Table CD_TPC_INF
-- ---------------------------------------------------------
CREATE TABLE CD_TPC_INF 
( 
	CODE                                    VARCHAR2(6 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_TPC_INF IS 'Type TPC';
COMMENT ON COLUMN CD_TPC_INF.CODE IS 'Code type';
COMMENT ON COLUMN CD_TPC_INF.LIBELLE IS 'Libellé';

-- ---------------------------------------------------------
-- Table CD_CLIM_INF
-- ---------------------------------------------------------
CREATE TABLE CD_CLIM_INF 
( 
	CODE                                    VARCHAR2(25 CHAR) NOT NULL
);
COMMENT ON TABLE CD_CLIM_INF IS 'Type Zone Climatique';
COMMENT ON COLUMN CD_CLIM_INF.CODE IS 'Type Climat';

-- ---------------------------------------------------------
-- Table CD_SENSIBLE_INF
-- ---------------------------------------------------------
CREATE TABLE CD_SENSIBLE_INF 
( 
	CODE                                    VARCHAR2(25 CHAR) NOT NULL
);
COMMENT ON TABLE CD_SENSIBLE_INF IS 'Type Zone Sensible';
COMMENT ON COLUMN CD_SENSIBLE_INF.CODE IS 'Type sensible';

-- ---------------------------------------------------------
-- Table CL_VOIE_INF
-- ---------------------------------------------------------
CREATE TABLE CL_VOIE_INF 
( 
	CD_VOIE_INF__VOIE                       VARCHAR2(6 CHAR) NOT NULL,
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	CHAUSSEE_INF__SENS                      VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	ABS_FIN                                 NUMBER(6) NOT NULL,
	NUM                                     NUMBER(1),
	NBRE                                    NUMBER(1),
	NUM_VNR                                 NUMBER(1) NOT NULL,
	NBRE_VNR                                NUMBER(1) NOT NULL
);
COMMENT ON TABLE CL_VOIE_INF IS 'Voies';
COMMENT ON COLUMN CL_VOIE_INF.CD_VOIE_INF__VOIE IS 'Type Voie';
COMMENT ON COLUMN CL_VOIE_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN CL_VOIE_INF.CHAUSSEE_INF__SENS IS 'Sens';
COMMENT ON COLUMN CL_VOIE_INF.ABS_DEB IS 'Début';
COMMENT ON COLUMN CL_VOIE_INF.ABS_FIN IS 'Fin';
COMMENT ON COLUMN CL_VOIE_INF.NUM IS 'Numéro Voie';
COMMENT ON COLUMN CL_VOIE_INF.NBRE IS 'Nbre de voies';
COMMENT ON COLUMN CL_VOIE_INF.NUM_VNR IS 'Num Voie total';
COMMENT ON COLUMN CL_VOIE_INF.NBRE_VNR IS 'Nbre Voie total';

-- ---------------------------------------------------------
-- Table SENSIBLE_INF
-- ---------------------------------------------------------
CREATE TABLE SENSIBLE_INF 
( 
	CD_SENSIBLE_INF__CODE                   VARCHAR2(25 CHAR) NOT NULL,
	LIAISON_INF__LIAISON                    VARCHAR2(15 CHAR) NOT NULL,
	CHAUSSEE_INF__SENS                      VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	ABS_FIN                                 NUMBER(6),
	LIBELLE                                 VARCHAR2(60 CHAR)
);
COMMENT ON TABLE SENSIBLE_INF IS 'Zone Sensible';
COMMENT ON COLUMN SENSIBLE_INF.CD_SENSIBLE_INF__CODE IS 'Type sensible';
COMMENT ON COLUMN SENSIBLE_INF.LIAISON_INF__LIAISON IS 'Liaison';
COMMENT ON COLUMN SENSIBLE_INF.CHAUSSEE_INF__SENS IS 'Sens';
COMMENT ON COLUMN SENSIBLE_INF.ABS_DEB IS 'Début';
COMMENT ON COLUMN SENSIBLE_INF.ABS_FIN IS 'Fin';
COMMENT ON COLUMN SENSIBLE_INF.LIBELLE IS 'Libelle';

