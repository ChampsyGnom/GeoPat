/*################################################################################################*/
/* Script     : BSN_Tables.sql                                                                    */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

-- ---------------------------------------------------------
-- Table SYS_PRP_BSN
-- ---------------------------------------------------------

CREATE TABLE SYS_PRP_BSN 
( 
	CODE_TABLE                    VARCHAR2(60 CHAR)        NOT NULL,
	CODE_COLONNE                  VARCHAR2(60 CHAR)        NOT NULL,
	NOM_USER                      VARCHAR2(30 CHAR)        NOT NULL,
	CODE_PRP                      VARCHAR2(60 CHAR)        NOT NULL,
	VAL_PRP                       VARCHAR2(255 CHAR)       );
COMMENT ON TABLE SYS_PRP_BSN IS 'MétaDonnées du schéma BSN';

-- ---------------------------------------------------------
-- Table SYS_INSTANCE_BSN
-- ---------------------------------------------------------

CREATE TABLE SYS_INSTANCE_BSN 
( 
	CODE                   VARCHAR2(100 CHAR) NOT NULL,
	VALEUR                 CLOB);
COMMENT ON TABLE SYS_INSTANCE_BSN IS 'Informations du schéma BSN';

-- ---------------------------------------------------------
-- Table DSC_BSN
-- ---------------------------------------------------------
CREATE TABLE DSC_BSN 
( 
	NUM_BSN                                 VARCHAR2(20 CHAR) NOT NULL,
	NUM_EXPLOIT                             VARCHAR2(30 CHAR),
	ABS_DEB                                 NUMBER(6) NOT NULL,
	SENS                                    VARCHAR2(6 CHAR) NOT NULL,
	LIAISON                                 VARCHAR2(15 CHAR) NOT NULL,
	CD_FAM_BSN__FAMILLE                     VARCHAR2(60 CHAR) NOT NULL,
	CD_TYPE_BSN__TYPE                       VARCHAR2(60 CHAR) NOT NULL,
	DATE_MS                                 DATE,
	SURF_VERSANT                            NUMBER(8,2),
	DEBIT_MAX                               NUMBER(6),
	NOTE1                                   NUMBER(1),
	NOTE2                                   NUMBER(1),
	NOTE3                                   NUMBER(1),
	NOTE4                                   NUMBER(1),
	URGENCE                                 VARCHAR2(5 CHAR),
	CD_QUALITE_BSN__QUALITE                 VARCHAR2(25 CHAR),
	DESC_INVA                               VARCHAR2(1000 CHAR),
	PRIORITAIRE                             NUMBER,
	PROSURV_ANNEE                           NUMBER(4),
	DERN_INSP                               DATE,
	ARCHIVE                                 VARCHAR2(255 CHAR),
	VEHICULE                                VARCHAR2(255 CHAR),
	PIETON                                  VARCHAR2(255 CHAR),
	CD_ACCES_BSN__VACCES                    VARCHAR2(60 CHAR),
	DERN_VST                                DATE,
	NOTE_VST                                VARCHAR2(5 CHAR),
	CD_PERMEABLE_BSN__TYPE                  VARCHAR2(60 CHAR),
	CD_SOUS_TYPE_BSN__NAT_SENSIB            VARCHAR2(60 CHAR),
	CD_FREQUENCE_BSN__FREQ                  VARCHAR2(25 CHAR),
	VOL_UTIL                                NUMBER(6),
	VOL_MOR                                 NUMBER(6),
	VOL_POLL                                NUMBER(6),
	VOL_INCEN                               NUMBER(6),
	DUREE_PLUIE                             NUMBER(6),
	FAUNE_FLORE                             VARCHAR2(60 CHAR),
	TPS_CONCENT                             NUMBER(6),
	OUV_AVAL                                VARCHAR2(200 CHAR),
	COMMENTAIRE                             VARCHAR2(1000 CHAR),
	LOI_EAU                                 NUMBER,
	EAUX_COLLECT                            VARCHAR2(200 CHAR),
	CD_EXT_BSN__TYPE                        VARCHAR2(60 CHAR),
	CD_ENTP_BSN__ENTREPRISE                 VARCHAR2(60 CHAR),
	SECURITE                                NUMBER,
	X1                                      NUMBER(22,11),
	Y1                                      NUMBER(22,11),
	Z1                                      NUMBER(22,11),
	DATE_RELEVE                             DATE,
	TERRAIN                                 NUMBER
);
COMMENT ON TABLE DSC_BSN IS 'Bassin';
COMMENT ON COLUMN DSC_BSN.NUM_BSN IS 'N° Bassin';
COMMENT ON COLUMN DSC_BSN.NUM_EXPLOIT IS 'N° d''exploitation';
COMMENT ON COLUMN DSC_BSN.ABS_DEB IS 'PR';
COMMENT ON COLUMN DSC_BSN.SENS IS 'Sens';
COMMENT ON COLUMN DSC_BSN.LIAISON IS 'Liaison';
COMMENT ON COLUMN DSC_BSN.CD_FAM_BSN__FAMILLE IS 'Dénomination';
COMMENT ON COLUMN DSC_BSN.CD_TYPE_BSN__TYPE IS 'Sensibilité du milieu';
COMMENT ON COLUMN DSC_BSN.DATE_MS IS 'Date MS';
COMMENT ON COLUMN DSC_BSN.SURF_VERSANT IS 'Surf. bassin versant ext. (ha)';
COMMENT ON COLUMN DSC_BSN.DEBIT_MAX IS 'Sortie débit fuite  (l/s)';
COMMENT ON COLUMN DSC_BSN.NOTE1 IS 'Note Structure';
COMMENT ON COLUMN DSC_BSN.NOTE2 IS 'Note Equipements';
COMMENT ON COLUMN DSC_BSN.NOTE3 IS 'Note Abords-Végétation';
COMMENT ON COLUMN DSC_BSN.NOTE4 IS 'Note Sécurité';
COMMENT ON COLUMN DSC_BSN.URGENCE IS 'Niveau Urgence';
COMMENT ON COLUMN DSC_BSN.CD_QUALITE_BSN__QUALITE IS 'Niveau qualité';
COMMENT ON COLUMN DSC_BSN.DESC_INVA IS 'Description invalide';
COMMENT ON COLUMN DSC_BSN.PRIORITAIRE IS 'Urgence traitement';
COMMENT ON COLUMN DSC_BSN.PROSURV_ANNEE IS 'Prochaine Inspection';
COMMENT ON COLUMN DSC_BSN.DERN_INSP IS 'Dernière Inspection';
COMMENT ON COLUMN DSC_BSN.ARCHIVE IS 'Archive';
COMMENT ON COLUMN DSC_BSN.VEHICULE IS 'Accès véhicule';
COMMENT ON COLUMN DSC_BSN.PIETON IS 'Accès piéton';
COMMENT ON COLUMN DSC_BSN.CD_ACCES_BSN__VACCES IS 'Voie d''accès';
COMMENT ON COLUMN DSC_BSN.DERN_VST IS 'Dernière Visite';
COMMENT ON COLUMN DSC_BSN.NOTE_VST IS 'Note Visite';
COMMENT ON COLUMN DSC_BSN.CD_PERMEABLE_BSN__TYPE IS 'Perméabilité';
COMMENT ON COLUMN DSC_BSN.CD_SOUS_TYPE_BSN__NAT_SENSIB IS 'Nature sensibilité';
COMMENT ON COLUMN DSC_BSN.CD_FREQUENCE_BSN__FREQ IS 'Fréquence';
COMMENT ON COLUMN DSC_BSN.VOL_UTIL IS 'Volume utile (m3)';
COMMENT ON COLUMN DSC_BSN.VOL_MOR IS 'Volume mort (m3)';
COMMENT ON COLUMN DSC_BSN.VOL_POLL IS 'Volume polluant (m3)';
COMMENT ON COLUMN DSC_BSN.VOL_INCEN IS 'Volume eau incendie (m3)';
COMMENT ON COLUMN DSC_BSN.DUREE_PLUIE IS 'Durée des pluies (h)';
COMMENT ON COLUMN DSC_BSN.FAUNE_FLORE IS 'Sensibilité Faune et flore';
COMMENT ON COLUMN DSC_BSN.TPS_CONCENT IS 'Tps de concentration (mn)';
COMMENT ON COLUMN DSC_BSN.OUV_AVAL IS 'Connexion Aval';
COMMENT ON COLUMN DSC_BSN.COMMENTAIRE IS 'Commentaire';
COMMENT ON COLUMN DSC_BSN.LOI_EAU IS 'Loi sur l''eau';
COMMENT ON COLUMN DSC_BSN.EAUX_COLLECT IS 'Eaux collectées';
COMMENT ON COLUMN DSC_BSN.CD_EXT_BSN__TYPE IS 'Exutoire';
COMMENT ON COLUMN DSC_BSN.CD_ENTP_BSN__ENTREPRISE IS 'Entreprise';
COMMENT ON COLUMN DSC_BSN.SECURITE IS 'Problème de sécurité';
COMMENT ON COLUMN DSC_BSN.X1 IS 'X1';
COMMENT ON COLUMN DSC_BSN.Y1 IS 'Y1';
COMMENT ON COLUMN DSC_BSN.Z1 IS 'Z1';
COMMENT ON COLUMN DSC_BSN.DATE_RELEVE IS 'Date relevé';
COMMENT ON COLUMN DSC_BSN.TERRAIN IS 'Terrain';

-- ---------------------------------------------------------
-- Table DSC_TEMP_BSN
-- ---------------------------------------------------------
CREATE TABLE DSC_TEMP_BSN 
( 
	CAMP_BSN__ID_CAMP                       VARCHAR2(100 CHAR) NOT NULL,
	NUM_BSN                                 VARCHAR2(20 CHAR) NOT NULL,
	DSC_BSN__NUM_BSN                        VARCHAR2(20 CHAR),
	CD_PERMEABLE_BSN__TYPE                  VARCHAR2(60 CHAR),
	CD_SOUS_TYPE_BSN__NAT_SENSIB            VARCHAR2(60 CHAR),
	CD_EXT_BSN__TYPE                        VARCHAR2(60 CHAR),
	CD_TYPE_BSN__TYPE                       VARCHAR2(60 CHAR) NOT NULL,
	CD_ACCES_BSN__VACCES                    VARCHAR2(60 CHAR),
	CD_FAM_BSN__FAMILLE                     VARCHAR2(60 CHAR) NOT NULL,
	CD_FREQUENCE_BSN__FREQ                  VARCHAR2(25 CHAR),
	CD_ENTP_BSN__ENTREPRISE                 VARCHAR2(60 CHAR),
	NUM_EXPLOIT                             VARCHAR2(30 CHAR),
	LIAISON                                 VARCHAR2(15 CHAR) NOT NULL,
	SENS                                    VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	DATE_MS                                 DATE,
	VOL_UTIL                                NUMBER(6),
	VOL_MOR                                 NUMBER(6),
	VOL_POLL                                NUMBER(6),
	VOL_INCEN                               NUMBER(6),
	DUREE_PLUIE                             NUMBER(6),
	FAUNE_FLORE                             VARCHAR2(60 CHAR),
	SURF_VERSANT                            NUMBER(8,2),
	DEBIT_MAX                               NUMBER(6),
	TPS_CONCENT                             NUMBER(6),
	VEHICULE                                VARCHAR2(255 CHAR),
	PIETON                                  VARCHAR2(255 CHAR),
	NOTE1                                   NUMBER(1),
	NOTE2                                   NUMBER(1),
	NOTE3                                   NUMBER(1),
	NOTE4                                   NUMBER(1),
	URGENCE                                 VARCHAR2(5 CHAR),
	DESC_INVA                               VARCHAR2(1000 CHAR),
	SECURITE                                NUMBER,
	PRIORITAIRE                             NUMBER,
	PROSURV_ANNEE                           NUMBER(4),
	DERN_INSP                               DATE,
	DERN_VST                                DATE,
	NOTE_VST                                VARCHAR2(5 CHAR),
	ARCHIVE                                 VARCHAR2(255 CHAR),
	OUV_AVAL                                VARCHAR2(200 CHAR),
	LOI_EAU                                 NUMBER,
	EAUX_COLLECT                            VARCHAR2(200 CHAR),
	COMMENTAIRE                             VARCHAR2(1000 CHAR),
	X1                                      NUMBER(22,11),
	Y1                                      NUMBER(22,11),
	Z1                                      NUMBER(22,11),
	DATE_RELEVE                             DATE,
	TERRAIN                                 NUMBER
);
COMMENT ON TABLE DSC_TEMP_BSN IS 'Bassin temporaire';
COMMENT ON COLUMN DSC_TEMP_BSN.CAMP_BSN__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN DSC_TEMP_BSN.NUM_BSN IS 'N° Bassin';
COMMENT ON COLUMN DSC_TEMP_BSN.DSC_BSN__NUM_BSN IS 'N° Bassin2';
COMMENT ON COLUMN DSC_TEMP_BSN.CD_PERMEABLE_BSN__TYPE IS 'Perméabilité';
COMMENT ON COLUMN DSC_TEMP_BSN.CD_SOUS_TYPE_BSN__NAT_SENSIB IS 'Nature sensibilité';
COMMENT ON COLUMN DSC_TEMP_BSN.CD_EXT_BSN__TYPE IS 'Exutoire';
COMMENT ON COLUMN DSC_TEMP_BSN.CD_TYPE_BSN__TYPE IS 'Sensibilité du milieu';
COMMENT ON COLUMN DSC_TEMP_BSN.CD_ACCES_BSN__VACCES IS 'Voie d''accès';
COMMENT ON COLUMN DSC_TEMP_BSN.CD_FAM_BSN__FAMILLE IS 'Dénomination';
COMMENT ON COLUMN DSC_TEMP_BSN.CD_FREQUENCE_BSN__FREQ IS 'Fréquence';
COMMENT ON COLUMN DSC_TEMP_BSN.CD_ENTP_BSN__ENTREPRISE IS 'Entreprise';
COMMENT ON COLUMN DSC_TEMP_BSN.NUM_EXPLOIT IS 'N° d''exploitation';
COMMENT ON COLUMN DSC_TEMP_BSN.LIAISON IS 'Liaison';
COMMENT ON COLUMN DSC_TEMP_BSN.SENS IS 'Sens';
COMMENT ON COLUMN DSC_TEMP_BSN.ABS_DEB IS 'PR';
COMMENT ON COLUMN DSC_TEMP_BSN.DATE_MS IS 'Date MS';
COMMENT ON COLUMN DSC_TEMP_BSN.VOL_UTIL IS 'Volume utile (m3)';
COMMENT ON COLUMN DSC_TEMP_BSN.VOL_MOR IS 'Volume mort (m3)';
COMMENT ON COLUMN DSC_TEMP_BSN.VOL_POLL IS 'Volume polluant (m3)';
COMMENT ON COLUMN DSC_TEMP_BSN.VOL_INCEN IS 'Volume eau incendie (m3)';
COMMENT ON COLUMN DSC_TEMP_BSN.DUREE_PLUIE IS 'Durée des pluies (h)';
COMMENT ON COLUMN DSC_TEMP_BSN.FAUNE_FLORE IS 'Sensibilité Faune et flore';
COMMENT ON COLUMN DSC_TEMP_BSN.SURF_VERSANT IS 'Surf. bassin versant ext. (ha)';
COMMENT ON COLUMN DSC_TEMP_BSN.DEBIT_MAX IS 'Sortie débit fuite  (l/s)';
COMMENT ON COLUMN DSC_TEMP_BSN.TPS_CONCENT IS 'Tps de concentration (mn)';
COMMENT ON COLUMN DSC_TEMP_BSN.VEHICULE IS 'Accès véhicule';
COMMENT ON COLUMN DSC_TEMP_BSN.PIETON IS 'Accès piéton';
COMMENT ON COLUMN DSC_TEMP_BSN.NOTE1 IS 'Note Structure';
COMMENT ON COLUMN DSC_TEMP_BSN.NOTE2 IS 'Note Equipements';
COMMENT ON COLUMN DSC_TEMP_BSN.NOTE3 IS 'Note Abords-Végétation';
COMMENT ON COLUMN DSC_TEMP_BSN.NOTE4 IS 'Note Sécurité';
COMMENT ON COLUMN DSC_TEMP_BSN.URGENCE IS 'Niveau Urgence';
COMMENT ON COLUMN DSC_TEMP_BSN.DESC_INVA IS 'Description invalide';
COMMENT ON COLUMN DSC_TEMP_BSN.SECURITE IS 'Problème de sécurité';
COMMENT ON COLUMN DSC_TEMP_BSN.PRIORITAIRE IS 'Urgence traitement';
COMMENT ON COLUMN DSC_TEMP_BSN.PROSURV_ANNEE IS 'Prochaine Inspection';
COMMENT ON COLUMN DSC_TEMP_BSN.DERN_INSP IS 'Dernière Inspection';
COMMENT ON COLUMN DSC_TEMP_BSN.DERN_VST IS 'Dernière Visite';
COMMENT ON COLUMN DSC_TEMP_BSN.NOTE_VST IS 'Note Visite';
COMMENT ON COLUMN DSC_TEMP_BSN.ARCHIVE IS 'Archive';
COMMENT ON COLUMN DSC_TEMP_BSN.OUV_AVAL IS 'Connexion Aval';
COMMENT ON COLUMN DSC_TEMP_BSN.LOI_EAU IS 'Loi sur l''eau';
COMMENT ON COLUMN DSC_TEMP_BSN.EAUX_COLLECT IS 'Eaux collectées';
COMMENT ON COLUMN DSC_TEMP_BSN.COMMENTAIRE IS 'Commentaire';
COMMENT ON COLUMN DSC_TEMP_BSN.X1 IS 'X1';
COMMENT ON COLUMN DSC_TEMP_BSN.Y1 IS 'Y1';
COMMENT ON COLUMN DSC_TEMP_BSN.Z1 IS 'Z1';
COMMENT ON COLUMN DSC_TEMP_BSN.DATE_RELEVE IS 'Date relevé';
COMMENT ON COLUMN DSC_TEMP_BSN.TERRAIN IS 'Terrain';

-- ---------------------------------------------------------
-- Table BPU_BSN
-- ---------------------------------------------------------
CREATE TABLE BPU_BSN 
( 
	ID_BPU                                  NUMBER(7) NOT NULL,
	CD_TRAVAUX_BSN__CODE                    VARCHAR2(60 CHAR) NOT NULL,
	CD_UNITE_BSN__UNITE                     VARCHAR2(12 CHAR),
	TECHN                                   VARCHAR2(255 CHAR) NOT NULL,
	PRIX                                    NUMBER(9),
	DATE_MAJ                                DATE,
	FREQ                                    NUMBER(3),
	PRECO_VST                               NUMBER,
	REALIS_VST                              NUMBER
);
COMMENT ON TABLE BPU_BSN IS 'Bordereau Prix';
COMMENT ON COLUMN BPU_BSN.ID_BPU IS 'Identifiant Bordereau';
COMMENT ON COLUMN BPU_BSN.CD_TRAVAUX_BSN__CODE IS 'Type travaux';
COMMENT ON COLUMN BPU_BSN.CD_UNITE_BSN__UNITE IS 'Unité';
COMMENT ON COLUMN BPU_BSN.TECHN IS 'Technique';
COMMENT ON COLUMN BPU_BSN.PRIX IS 'Prix Unitaire';
COMMENT ON COLUMN BPU_BSN.DATE_MAJ IS 'Date MAJ';
COMMENT ON COLUMN BPU_BSN.FREQ IS 'Fréquence (mois)';
COMMENT ON COLUMN BPU_BSN.PRECO_VST IS 'Préconisation Visite';
COMMENT ON COLUMN BPU_BSN.REALIS_VST IS 'Entretien réalisable';

-- ---------------------------------------------------------
-- Table CAMP_BSN
-- ---------------------------------------------------------
CREATE TABLE CAMP_BSN 
( 
	ID_CAMP                                 VARCHAR2(100 CHAR) NOT NULL,
	CD_PRESTA_BSN__PRESTATAIRE              VARCHAR2(50 CHAR) NOT NULL,
	CD_TYPE_PV_BSN__CODE                    VARCHAR2(15 CHAR) NOT NULL,
	ANNEE                                   NUMBER(4) NOT NULL,
	DATER                                   DATE NOT NULL,
	DATEG                                   DATE,
	USERG                                   VARCHAR2(255 CHAR),
	OBSERV                                  VARCHAR2(255 CHAR)
);
COMMENT ON TABLE CAMP_BSN IS 'Campagne';
COMMENT ON COLUMN CAMP_BSN.ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN CAMP_BSN.CD_PRESTA_BSN__PRESTATAIRE IS 'Prestataire';
COMMENT ON COLUMN CAMP_BSN.CD_TYPE_PV_BSN__CODE IS 'Type de PV';
COMMENT ON COLUMN CAMP_BSN.ANNEE IS 'Année';
COMMENT ON COLUMN CAMP_BSN.DATER IS 'Date maxi retour';
COMMENT ON COLUMN CAMP_BSN.DATEG IS 'Date génération';
COMMENT ON COLUMN CAMP_BSN.USERG IS 'Nom créateur';
COMMENT ON COLUMN CAMP_BSN.OBSERV IS 'Commentaire';

-- ---------------------------------------------------------
-- Table CD_CHAPITRE_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_CHAPITRE_BSN 
( 
	ID_CHAP                                 NUMBER(7) NOT NULL,
	LIBELLE                                 VARCHAR2(500 CHAR) NOT NULL,
	ORDRE_CHAP                              NUMBER(7) NOT NULL,
	PONDERATION                             NUMBER(3)
);
COMMENT ON TABLE CD_CHAPITRE_BSN IS 'Chapitre';
COMMENT ON COLUMN CD_CHAPITRE_BSN.ID_CHAP IS 'Identifiant chapitre';
COMMENT ON COLUMN CD_CHAPITRE_BSN.LIBELLE IS 'Libellé chapitre';
COMMENT ON COLUMN CD_CHAPITRE_BSN.ORDRE_CHAP IS 'N° ordre chapitre';
COMMENT ON COLUMN CD_CHAPITRE_BSN.PONDERATION IS 'Pondération';

-- ---------------------------------------------------------
-- Table CLS_BSN
-- ---------------------------------------------------------
CREATE TABLE CLS_BSN 
( 
	ID                                      NUMBER(6,0) NOT NULL,
	TABLE_NAME                              VARCHAR2(30 CHAR) NOT NULL,
	KEY_VALUE                               VARCHAR2(500 CHAR) NOT NULL
);
COMMENT ON TABLE CLS_BSN IS 'Classeurs';
COMMENT ON COLUMN CLS_BSN.ID IS 'Identifiant du classeur(cpt)';
COMMENT ON COLUMN CLS_BSN.TABLE_NAME IS 'Table';
COMMENT ON COLUMN CLS_BSN.KEY_VALUE IS 'Enregistrement';

-- ---------------------------------------------------------
-- Table CD_CONCLUSION_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_CONCLUSION_BSN 
( 
	ID_CONC                                 NUMBER(7) NOT NULL,
	LIBELLE                                 VARCHAR2(500 CHAR) NOT NULL,
	ORDRE                                   NUMBER(7) NOT NULL
);
COMMENT ON TABLE CD_CONCLUSION_BSN IS 'Code conclusion';
COMMENT ON COLUMN CD_CONCLUSION_BSN.ID_CONC IS 'Identifiant Conclusion';
COMMENT ON COLUMN CD_CONCLUSION_BSN.LIBELLE IS 'Libellé Conclusion';
COMMENT ON COLUMN CD_CONCLUSION_BSN.ORDRE IS 'N° oredre Conclusion';

-- ---------------------------------------------------------
-- Table CD_QUALITE_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_QUALITE_BSN 
( 
	QUALITE                                 VARCHAR2(25 CHAR) NOT NULL
);
COMMENT ON TABLE CD_QUALITE_BSN IS 'Code Qualité';
COMMENT ON COLUMN CD_QUALITE_BSN.QUALITE IS 'Niveau qualité';

-- ---------------------------------------------------------
-- Table CD_CONCLUSION__INSP_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_CONCLUSION__INSP_BSN 
( 
	CAMP_BSN__ID_CAMP                       VARCHAR2(100 CHAR) NOT NULL,
	DSC_BSN__NUM_BSN                        VARCHAR2(20 CHAR) NOT NULL,
	CD_CONCLUSION_BSN__ID_CONC              NUMBER(7) NOT NULL,
	CONTENU                                 VARCHAR2(1000 CHAR)
);
COMMENT ON TABLE CD_CONCLUSION__INSP_BSN IS 'Conclusions';
COMMENT ON COLUMN CD_CONCLUSION__INSP_BSN.CAMP_BSN__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN CD_CONCLUSION__INSP_BSN.DSC_BSN__NUM_BSN IS 'N° Bassin';
COMMENT ON COLUMN CD_CONCLUSION__INSP_BSN.CD_CONCLUSION_BSN__ID_CONC IS 'Identifiant Conclusion';
COMMENT ON COLUMN CD_CONCLUSION__INSP_BSN.CONTENU IS 'Contenu';

-- ---------------------------------------------------------
-- Table CD_CONCLUSION__INSP_TMP_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_CONCLUSION__INSP_TMP_BSN 
( 
	CAMP_BSN__ID_CAMP                       VARCHAR2(100 CHAR) NOT NULL,
	DSC_TEMP_BSN__NUM_BSN                   VARCHAR2(20 CHAR) NOT NULL,
	CD_CONCLUSION_BSN__ID_CONC              NUMBER(7) NOT NULL,
	CONTENU                                 VARCHAR2(1000 CHAR)
);
COMMENT ON TABLE CD_CONCLUSION__INSP_TMP_BSN IS 'Conclusions temporaire';
COMMENT ON COLUMN CD_CONCLUSION__INSP_TMP_BSN.CAMP_BSN__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN CD_CONCLUSION__INSP_TMP_BSN.DSC_TEMP_BSN__NUM_BSN IS 'N° Bassin';
COMMENT ON COLUMN CD_CONCLUSION__INSP_TMP_BSN.CD_CONCLUSION_BSN__ID_CONC IS 'Identifiant Conclusion';
COMMENT ON COLUMN CD_CONCLUSION__INSP_TMP_BSN.CONTENU IS 'Contenu';

-- ---------------------------------------------------------
-- Table CONTACT_BSN
-- ---------------------------------------------------------
CREATE TABLE CONTACT_BSN 
( 
	DOC__ID                                 NUMBER(6) NOT NULL,
	GIVENNAME                               VARCHAR2(60 CHAR),
	SN                                      VARCHAR2(60 CHAR),
	CN                                      VARCHAR2(125 CHAR),
	O                                       VARCHAR2(60 CHAR),
	MAIL                                    VARCHAR2(60 CHAR),
	TELEPHONENUMBER                         VARCHAR2(20 CHAR),
	MOBILE                                  VARCHAR2(20 CHAR),
	FACSIMILETELEPHONENUMBER                VARCHAR2(20 CHAR),
	STREET                                  VARCHAR2(60 CHAR),
	MOZILLAWORKSTREET2                      VARCHAR2(60 CHAR),
	L                                       VARCHAR2(60 CHAR),
	POSTALCODE                              VARCHAR2(12 CHAR),
	MODIFYTIMESTAMP                         DATE
);
COMMENT ON TABLE CONTACT_BSN IS 'Contacts';
COMMENT ON COLUMN CONTACT_BSN.DOC__ID IS 'Id document';
COMMENT ON COLUMN CONTACT_BSN.GIVENNAME IS 'Prénom';
COMMENT ON COLUMN CONTACT_BSN.SN IS 'Nom';
COMMENT ON COLUMN CONTACT_BSN.CN IS 'Nom complet';
COMMENT ON COLUMN CONTACT_BSN.O IS 'Organisation';
COMMENT ON COLUMN CONTACT_BSN.MAIL IS 'Email';
COMMENT ON COLUMN CONTACT_BSN.TELEPHONENUMBER IS 'Téléphone fixe';
COMMENT ON COLUMN CONTACT_BSN.MOBILE IS 'Téléphone mobile';
COMMENT ON COLUMN CONTACT_BSN.FACSIMILETELEPHONENUMBER IS 'Fax';
COMMENT ON COLUMN CONTACT_BSN.STREET IS 'Adresse';
COMMENT ON COLUMN CONTACT_BSN.MOZILLAWORKSTREET2 IS 'Adresse complémentaire';
COMMENT ON COLUMN CONTACT_BSN.L IS 'Ville';
COMMENT ON COLUMN CONTACT_BSN.POSTALCODE IS 'Code Postal';
COMMENT ON COLUMN CONTACT_BSN.MODIFYTIMESTAMP IS 'Date MAJ';

-- ---------------------------------------------------------
-- Table CLS_DOC_BSN
-- ---------------------------------------------------------
CREATE TABLE CLS_DOC_BSN 
( 
	CLS__ID                                 NUMBER(6) NOT NULL,
	DOC__ID                                 NUMBER(6) NOT NULL,
	DEFAUT                                  NUMBER,
	DOSSIER                                 VARCHAR2(15 CHAR)
);
COMMENT ON TABLE CLS_DOC_BSN IS 'Contenu du classeur';
COMMENT ON COLUMN CLS_DOC_BSN.CLS__ID IS 'Identifiant du classeur(cpt)';
COMMENT ON COLUMN CLS_DOC_BSN.DOC__ID IS 'Id document';
COMMENT ON COLUMN CLS_DOC_BSN.DEFAUT IS 'Document par défaut';
COMMENT ON COLUMN CLS_DOC_BSN.DOSSIER IS 'Dossier';

-- ---------------------------------------------------------
-- Table CD_CONTRAINTE_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_CONTRAINTE_BSN 
( 
	TYPE                                    VARCHAR2(100 CHAR) NOT NULL
);
COMMENT ON TABLE CD_CONTRAINTE_BSN IS 'Contrainte exploitation';
COMMENT ON COLUMN CD_CONTRAINTE_BSN.TYPE IS 'Contrainte exploit';

-- ---------------------------------------------------------
-- Table EQUIPEMENT_BSN
-- ---------------------------------------------------------
CREATE TABLE EQUIPEMENT_BSN 
( 
	DSC_BSN__NUM_BSN                        VARCHAR2(20 CHAR) NOT NULL,
	CD_FAMEQP_BSN__FAM                      VARCHAR2(25 CHAR) NOT NULL,
	CD_TYPEQP_BSN__TYPE                     VARCHAR2(60 CHAR) NOT NULL,
	POSITION                                VARCHAR2(60 CHAR) NOT NULL,
	DATE_MS                                 DATE,
	COMMENTAIRE                             VARCHAR2(500 CHAR)
);
COMMENT ON TABLE EQUIPEMENT_BSN IS 'Détail Equipement';
COMMENT ON COLUMN EQUIPEMENT_BSN.DSC_BSN__NUM_BSN IS 'N° Bassin';
COMMENT ON COLUMN EQUIPEMENT_BSN.CD_FAMEQP_BSN__FAM IS 'Famille EQP';
COMMENT ON COLUMN EQUIPEMENT_BSN.CD_TYPEQP_BSN__TYPE IS 'Type EQP';
COMMENT ON COLUMN EQUIPEMENT_BSN.POSITION IS 'Identification';
COMMENT ON COLUMN EQUIPEMENT_BSN.DATE_MS IS 'Date MS';
COMMENT ON COLUMN EQUIPEMENT_BSN.COMMENTAIRE IS 'Commentaire';

-- ---------------------------------------------------------
-- Table ELT_INSP_BSN
-- ---------------------------------------------------------
CREATE TABLE ELT_INSP_BSN 
( 
	GRP_BSN__ID_GRP                         NUMBER(7) NOT NULL,
	PRT_BSN__ID_PRT                         NUMBER(7) NOT NULL,
	SPRT_BSN__ID_SPRT                       NUMBER(7) NOT NULL,
	ELT_BSN__ID_ELEM                        NUMBER(7) NOT NULL,
	CAMP_BSN__ID_CAMP                       VARCHAR2(100 CHAR) NOT NULL,
	DSC_BSN__NUM_BSN                        VARCHAR2(20 CHAR) NOT NULL,
	INDICE                                  NUMBER(2) NOT NULL,
	OBS                                     VARCHAR2(255 CHAR)
);
COMMENT ON TABLE ELT_INSP_BSN IS 'Détail Inspection';
COMMENT ON COLUMN ELT_INSP_BSN.GRP_BSN__ID_GRP IS 'Identifiant Groupe';
COMMENT ON COLUMN ELT_INSP_BSN.PRT_BSN__ID_PRT IS 'Identifiant Partie';
COMMENT ON COLUMN ELT_INSP_BSN.SPRT_BSN__ID_SPRT IS 'Identifiant Sous Partie';
COMMENT ON COLUMN ELT_INSP_BSN.ELT_BSN__ID_ELEM IS 'Identifiant Elément';
COMMENT ON COLUMN ELT_INSP_BSN.CAMP_BSN__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN ELT_INSP_BSN.DSC_BSN__NUM_BSN IS 'N° Bassin';
COMMENT ON COLUMN ELT_INSP_BSN.INDICE IS 'Indice';
COMMENT ON COLUMN ELT_INSP_BSN.OBS IS 'Observation';

-- ---------------------------------------------------------
-- Table ELT_INSP_TMP_BSN
-- ---------------------------------------------------------
CREATE TABLE ELT_INSP_TMP_BSN 
( 
	CAMP_BSN__ID_CAMP                       VARCHAR2(100 CHAR) NOT NULL,
	DSC_TEMP_BSN__NUM_BSN                   VARCHAR2(20 CHAR) NOT NULL,
	GRP_BSN__ID_GRP                         NUMBER(7) NOT NULL,
	PRT_BSN__ID_PRT                         NUMBER(7) NOT NULL,
	SPRT_BSN__ID_SPRT                       NUMBER(7) NOT NULL,
	ELT_BSN__ID_ELEM                        NUMBER(7) NOT NULL,
	INDICE                                  NUMBER(2) NOT NULL,
	OBS                                     VARCHAR2(255 CHAR)
);
COMMENT ON TABLE ELT_INSP_TMP_BSN IS 'Détail Inspection temporaire';
COMMENT ON COLUMN ELT_INSP_TMP_BSN.CAMP_BSN__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN ELT_INSP_TMP_BSN.DSC_TEMP_BSN__NUM_BSN IS 'N° Bassin';
COMMENT ON COLUMN ELT_INSP_TMP_BSN.GRP_BSN__ID_GRP IS 'Identifiant Groupe';
COMMENT ON COLUMN ELT_INSP_TMP_BSN.PRT_BSN__ID_PRT IS 'Identifiant Partie';
COMMENT ON COLUMN ELT_INSP_TMP_BSN.SPRT_BSN__ID_SPRT IS 'Identifiant Sous Partie';
COMMENT ON COLUMN ELT_INSP_TMP_BSN.ELT_BSN__ID_ELEM IS 'Identifiant Elément';
COMMENT ON COLUMN ELT_INSP_TMP_BSN.INDICE IS 'Indice';
COMMENT ON COLUMN ELT_INSP_TMP_BSN.OBS IS 'Observation';

-- ---------------------------------------------------------
-- Table SPRT_VST_BSN
-- ---------------------------------------------------------
CREATE TABLE SPRT_VST_BSN 
( 
	CAMP_BSN__ID_CAMP                       VARCHAR2(100 CHAR) NOT NULL,
	DSC_BSN__NUM_BSN                        VARCHAR2(20 CHAR) NOT NULL,
	CD_CHAPITRE_BSN__ID_CHAP                NUMBER(7) NOT NULL,
	CD_LIGNE_BSN__ID_LIGNE                  NUMBER(7) NOT NULL,
	INDICE                                  NUMBER(2) NOT NULL,
	OBS                                     VARCHAR2(255 CHAR)
);
COMMENT ON TABLE SPRT_VST_BSN IS 'Détail visite';
COMMENT ON COLUMN SPRT_VST_BSN.CAMP_BSN__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN SPRT_VST_BSN.DSC_BSN__NUM_BSN IS 'N° Bassin';
COMMENT ON COLUMN SPRT_VST_BSN.CD_CHAPITRE_BSN__ID_CHAP IS 'Identifiant chapitre';
COMMENT ON COLUMN SPRT_VST_BSN.CD_LIGNE_BSN__ID_LIGNE IS 'Identifiant ligne';
COMMENT ON COLUMN SPRT_VST_BSN.INDICE IS 'Indice';
COMMENT ON COLUMN SPRT_VST_BSN.OBS IS 'Observation';

-- ---------------------------------------------------------
-- Table DICTIONNAIRE_BSN
-- ---------------------------------------------------------
CREATE TABLE DICTIONNAIRE_BSN 
( 
	NOM                                     VARCHAR2(100 CHAR) NOT NULL,
	DESCRIPTION                             VARCHAR2(255 CHAR),
	DEFINITION                              VARCHAR2(500 CHAR),
	MOTSCLES                                VARCHAR2(255 CHAR)
);
COMMENT ON TABLE DICTIONNAIRE_BSN IS 'Dictionnaire';
COMMENT ON COLUMN DICTIONNAIRE_BSN.NOM IS 'Nom';
COMMENT ON COLUMN DICTIONNAIRE_BSN.DESCRIPTION IS 'Description';
COMMENT ON COLUMN DICTIONNAIRE_BSN.DEFINITION IS 'Définition';
COMMENT ON COLUMN DICTIONNAIRE_BSN.MOTSCLES IS 'Mots clés';

-- ---------------------------------------------------------
-- Table CD_FREQUENCE_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_FREQUENCE_BSN 
( 
	FREQ                                    VARCHAR2(25 CHAR) NOT NULL
);
COMMENT ON TABLE CD_FREQUENCE_BSN IS 'Dimensionnement';
COMMENT ON COLUMN CD_FREQUENCE_BSN.FREQ IS 'Fréquence';

-- ---------------------------------------------------------
-- Table DOC_BSN
-- ---------------------------------------------------------
CREATE TABLE DOC_BSN 
( 
	ID                                      NUMBER(6,0) NOT NULL,
	CD_DOC__CODE                            VARCHAR2(15 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(100 CHAR),
	REF                                     VARCHAR2(50 CHAR) NOT NULL
);
COMMENT ON TABLE DOC_BSN IS 'Documents';
COMMENT ON COLUMN DOC_BSN.ID IS 'Id document';
COMMENT ON COLUMN DOC_BSN.CD_DOC__CODE IS 'Code';
COMMENT ON COLUMN DOC_BSN.LIBELLE IS 'Libellé';
COMMENT ON COLUMN DOC_BSN.REF IS 'Réference (fichier)';

-- ---------------------------------------------------------
-- Table ELT_BSN
-- ---------------------------------------------------------
CREATE TABLE ELT_BSN 
( 
	GRP_BSN__ID_GRP                         NUMBER(7) NOT NULL,
	PRT_BSN__ID_PRT                         NUMBER(7) NOT NULL,
	SPRT_BSN__ID_SPRT                       NUMBER(7) NOT NULL,
	ID_ELEM                                 NUMBER(7) NOT NULL,
	LIBE                                    VARCHAR2(500 CHAR) NOT NULL,
	ORDRE                                   NUMBER(7) NOT NULL,
	AIDE                                    VARCHAR2(500 CHAR),
	INDICE1                                 VARCHAR2(500 CHAR),
	INDICE2                                 VARCHAR2(500 CHAR),
	INDICE3                                 VARCHAR2(500 CHAR)
);
COMMENT ON TABLE ELT_BSN IS 'Elément';
COMMENT ON COLUMN ELT_BSN.GRP_BSN__ID_GRP IS 'Identifiant Groupe';
COMMENT ON COLUMN ELT_BSN.PRT_BSN__ID_PRT IS 'Identifiant Partie';
COMMENT ON COLUMN ELT_BSN.SPRT_BSN__ID_SPRT IS 'Identifiant Sous Partie';
COMMENT ON COLUMN ELT_BSN.ID_ELEM IS 'Identifiant Elément';
COMMENT ON COLUMN ELT_BSN.LIBE IS 'Elément';
COMMENT ON COLUMN ELT_BSN.ORDRE IS 'N° Ordre';
COMMENT ON COLUMN ELT_BSN.AIDE IS 'Aide à la saisie';
COMMENT ON COLUMN ELT_BSN.INDICE1 IS 'Indice1';
COMMENT ON COLUMN ELT_BSN.INDICE2 IS 'Indice2';
COMMENT ON COLUMN ELT_BSN.INDICE3 IS 'Indice3';

-- ---------------------------------------------------------
-- Table CD_ENTETE_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_ENTETE_BSN 
( 
	ID_ENTETE                               NUMBER(7) NOT NULL,
	CD_COMPOSANT_BSN__TYPE_COMP             VARCHAR2(6 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(500 CHAR) NOT NULL,
	ORDRE_ENT                               NUMBER(7) NOT NULL,
	GUIDE                                   VARCHAR2(500 CHAR)
);
COMMENT ON TABLE CD_ENTETE_BSN IS 'Entête';
COMMENT ON COLUMN CD_ENTETE_BSN.ID_ENTETE IS 'Identifiant Entête';
COMMENT ON COLUMN CD_ENTETE_BSN.CD_COMPOSANT_BSN__TYPE_COMP IS 'Type Composant';
COMMENT ON COLUMN CD_ENTETE_BSN.LIBELLE IS 'Libellé Entête';
COMMENT ON COLUMN CD_ENTETE_BSN.ORDRE_ENT IS 'N° ordre Entête';
COMMENT ON COLUMN CD_ENTETE_BSN.GUIDE IS 'Guide';

-- ---------------------------------------------------------
-- Table CD_ENTP_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_ENTP_BSN 
( 
	ENTREPRISE                              VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_ENTP_BSN IS 'Entreprise';
COMMENT ON COLUMN CD_ENTP_BSN.ENTREPRISE IS 'Entreprise';

-- ---------------------------------------------------------
-- Table CD_ETUDE_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_ETUDE_BSN 
( 
	ETUDE                                   VARCHAR2(65 CHAR) NOT NULL
);
COMMENT ON TABLE CD_ETUDE_BSN IS 'Etude et Expertise';
COMMENT ON COLUMN CD_ETUDE_BSN.ETUDE IS 'Etude-Expertise';

-- ---------------------------------------------------------
-- Table EVT_BSN
-- ---------------------------------------------------------
CREATE TABLE EVT_BSN 
( 
	CD_EVT_BSN__TYPE                        VARCHAR2(25 CHAR) NOT NULL,
	DSC_BSN__NUM_BSN                        VARCHAR2(20 CHAR) NOT NULL,
	DATE_REL                                DATE NOT NULL,
	DATE_TRT                                DATE,
	OBSV                                    VARCHAR2(255 CHAR)
);
COMMENT ON TABLE EVT_BSN IS 'Evénement';
COMMENT ON COLUMN EVT_BSN.CD_EVT_BSN__TYPE IS 'Type événement';
COMMENT ON COLUMN EVT_BSN.DSC_BSN__NUM_BSN IS 'N° Bassin';
COMMENT ON COLUMN EVT_BSN.DATE_REL IS 'Date Relevé';
COMMENT ON COLUMN EVT_BSN.DATE_TRT IS 'Date Traitement';
COMMENT ON COLUMN EVT_BSN.OBSV IS 'Observation';

-- ---------------------------------------------------------
-- Table CD_EXT_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_EXT_BSN 
( 
	TYPE                                    VARCHAR2(60 CHAR) NOT NULL,
	IS_BSN                                  NUMBER NOT NULL,
	IS_OH                                   NUMBER NOT NULL
);
COMMENT ON TABLE CD_EXT_BSN IS 'Exutoire';
COMMENT ON COLUMN CD_EXT_BSN.TYPE IS 'Exutoire';
COMMENT ON COLUMN CD_EXT_BSN.IS_BSN IS 'Bassin';
COMMENT ON COLUMN CD_EXT_BSN.IS_OH IS 'Ouvrage hydraulique';

-- ---------------------------------------------------------
-- Table CD_FAM_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_FAM_BSN 
( 
	FAMILLE                                 VARCHAR2(60 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(60 CHAR)
);
COMMENT ON TABLE CD_FAM_BSN IS 'Famille';
COMMENT ON COLUMN CD_FAM_BSN.FAMILLE IS 'Dénomination';
COMMENT ON COLUMN CD_FAM_BSN.LIBELLE IS 'Libellé';

-- ---------------------------------------------------------
-- Table CD_FAMEQP_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_FAMEQP_BSN 
( 
	FAM                                     VARCHAR2(25 CHAR) NOT NULL
);
COMMENT ON TABLE CD_FAMEQP_BSN IS 'Famille Equipement';
COMMENT ON COLUMN CD_FAMEQP_BSN.FAM IS 'Famille EQP';

-- ---------------------------------------------------------
-- Table GEOMETRIE_BSN
-- ---------------------------------------------------------
CREATE TABLE GEOMETRIE_BSN 
( 
	DSC_BSN__NUM_BSN                        VARCHAR2(20 CHAR) NOT NULL,
	SURF                                    NUMBER(7,2),
	PROF                                    NUMBER(4,2),
	PENTE                                   NUMBER(4,2),
	PERIMETRE                               NUMBER(7,2)
);
COMMENT ON TABLE GEOMETRIE_BSN IS 'Géométrie bassin';
COMMENT ON COLUMN GEOMETRIE_BSN.DSC_BSN__NUM_BSN IS 'N° Bassin';
COMMENT ON COLUMN GEOMETRIE_BSN.SURF IS 'Surf. Bassin (m²)';
COMMENT ON COLUMN GEOMETRIE_BSN.PROF IS 'Prof. Bassin (m)';
COMMENT ON COLUMN GEOMETRIE_BSN.PENTE IS 'Pente Talus (%)';
COMMENT ON COLUMN GEOMETRIE_BSN.PERIMETRE IS 'Périmètre clôture (m)';

-- ---------------------------------------------------------
-- Table GRP_BSN
-- ---------------------------------------------------------
CREATE TABLE GRP_BSN 
( 
	ID_GRP                                  NUMBER(7) NOT NULL,
	LIBG                                    VARCHAR2(500 CHAR) NOT NULL,
	ORDRE                                   NUMBER(7) NOT NULL
);
COMMENT ON TABLE GRP_BSN IS 'Groupe';
COMMENT ON COLUMN GRP_BSN.ID_GRP IS 'Identifiant Groupe';
COMMENT ON COLUMN GRP_BSN.LIBG IS 'Groupe';
COMMENT ON COLUMN GRP_BSN.ORDRE IS 'No Ordre';

-- ---------------------------------------------------------
-- Table HISTO_NOTE_BSN
-- ---------------------------------------------------------
CREATE TABLE HISTO_NOTE_BSN 
( 
	DSC_BSN__NUM_BSN                        VARCHAR2(20 CHAR) NOT NULL,
	DATE_NOTE                               DATE NOT NULL,
	CD_ORIGIN_BSN__ORIGINE                  VARCHAR2(20 CHAR) NOT NULL,
	NOTE1                                   NUMBER(1),
	NOTE2                                   NUMBER(1),
	NOTE3                                   NUMBER(1),
	NOTE4                                   NUMBER(1),
	URGENCE                                 VARCHAR2(5 CHAR),
	SECURITE                                NUMBER,
	PRIORITAIRE                             NUMBER
);
COMMENT ON TABLE HISTO_NOTE_BSN IS 'Historique note';
COMMENT ON COLUMN HISTO_NOTE_BSN.DSC_BSN__NUM_BSN IS 'N° Bassin';
COMMENT ON COLUMN HISTO_NOTE_BSN.DATE_NOTE IS 'Date Note';
COMMENT ON COLUMN HISTO_NOTE_BSN.CD_ORIGIN_BSN__ORIGINE IS 'Origine Note';
COMMENT ON COLUMN HISTO_NOTE_BSN.NOTE1 IS 'Note Structure';
COMMENT ON COLUMN HISTO_NOTE_BSN.NOTE2 IS 'Note Equipements';
COMMENT ON COLUMN HISTO_NOTE_BSN.NOTE3 IS 'Note Abords-Végétation';
COMMENT ON COLUMN HISTO_NOTE_BSN.NOTE4 IS 'Note Sécurité';
COMMENT ON COLUMN HISTO_NOTE_BSN.URGENCE IS 'Niveau Urgence';
COMMENT ON COLUMN HISTO_NOTE_BSN.SECURITE IS 'Problème de sécurité';
COMMENT ON COLUMN HISTO_NOTE_BSN.PRIORITAIRE IS 'Urgence traitement';

-- ---------------------------------------------------------
-- Table DSC_CAMP_BSN
-- ---------------------------------------------------------
CREATE TABLE DSC_CAMP_BSN 
( 
	DSC_BSN__NUM_BSN                        VARCHAR2(20 CHAR) NOT NULL,
	CAMP_BSN__ID_CAMP                       VARCHAR2(100 CHAR) NOT NULL,
	REALISER                                NUMBER
);
COMMENT ON TABLE DSC_CAMP_BSN IS 'Historique Surveillances';
COMMENT ON COLUMN DSC_CAMP_BSN.DSC_BSN__NUM_BSN IS 'N° Bassin';
COMMENT ON COLUMN DSC_CAMP_BSN.CAMP_BSN__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN DSC_CAMP_BSN.REALISER IS 'Contrôle Réalisé';

-- ---------------------------------------------------------
-- Table IMPLUVIUM_BSN
-- ---------------------------------------------------------
CREATE TABLE IMPLUVIUM_BSN 
( 
	DSC_BSN__NUM_BSN                        VARCHAR2(20 CHAR) NOT NULL,
	LIAISON                                 VARCHAR2(15 CHAR) NOT NULL,
	SENS                                    VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	ABS_FIN                                 NUMBER(6) NOT NULL,
	SURFACE                                 NUMBER(6,2),
	COMMENTAIRE                             VARCHAR2(500 CHAR)
);
COMMENT ON TABLE IMPLUVIUM_BSN IS 'Impluvium';
COMMENT ON COLUMN IMPLUVIUM_BSN.DSC_BSN__NUM_BSN IS 'N° Bassin';
COMMENT ON COLUMN IMPLUVIUM_BSN.LIAISON IS 'Liaison';
COMMENT ON COLUMN IMPLUVIUM_BSN.SENS IS 'Sens';
COMMENT ON COLUMN IMPLUVIUM_BSN.ABS_DEB IS 'PR début';
COMMENT ON COLUMN IMPLUVIUM_BSN.ABS_FIN IS 'PR fin';
COMMENT ON COLUMN IMPLUVIUM_BSN.SURFACE IS 'Surface (ha)';
COMMENT ON COLUMN IMPLUVIUM_BSN.COMMENTAIRE IS 'Commentaire';

-- ---------------------------------------------------------
-- Table INSPECTEUR_BSN
-- ---------------------------------------------------------
CREATE TABLE INSPECTEUR_BSN 
( 
	NOM                                     VARCHAR2(60 CHAR) NOT NULL,
	CD_PRESTA_BSN__PRESTATAIRE              VARCHAR2(50 CHAR) NOT NULL,
	FONC                                    VARCHAR2(60 CHAR)
);
COMMENT ON TABLE INSPECTEUR_BSN IS 'Inspecteur';
COMMENT ON COLUMN INSPECTEUR_BSN.NOM IS 'Nom inspecteur';
COMMENT ON COLUMN INSPECTEUR_BSN.CD_PRESTA_BSN__PRESTATAIRE IS 'Prestataire';
COMMENT ON COLUMN INSPECTEUR_BSN.FONC IS 'Fonction';

-- ---------------------------------------------------------
-- Table INSP_BSN
-- ---------------------------------------------------------
CREATE TABLE INSP_BSN 
( 
	CAMP_BSN__ID_CAMP                       VARCHAR2(100 CHAR) NOT NULL,
	DSC_BSN__NUM_BSN                        VARCHAR2(20 CHAR) NOT NULL,
	CD_METEO_BSN__METEO                     VARCHAR2(60 CHAR),
	INSPECTEUR_BSN__NOM                     VARCHAR2(60 CHAR),
	CD_ETUDE_BSN__ETUDE                     VARCHAR2(65 CHAR),
	ETAT                                    VARCHAR2(25 CHAR) NOT NULL,
	DATEV                                   DATE,
	TEMPERATURE                             NUMBER(4,2),
	MOYEN                                   VARCHAR2(500 CHAR),
	CONDITIONS                              VARCHAR2(500 CHAR),
	DATE_VALID                              DATE,
	NOM_VALID                               VARCHAR2(250 CHAR),
	DESC_INVA                               VARCHAR2(1000 CHAR),
	SECURITE                                VARCHAR2(1000 CHAR),
	PRIORITAIRE                             VARCHAR2(1000 CHAR),
	NOTE1                                   NUMBER(1),
	NOTE2                                   NUMBER(1),
	NOTE3                                   NUMBER(1),
	NOTE4                                   NUMBER(1),
	URGENCE                                 VARCHAR2(5 CHAR),
	QUALITE                                 VARCHAR2(25 CHAR)
);
COMMENT ON TABLE INSP_BSN IS 'Inspection';
COMMENT ON COLUMN INSP_BSN.CAMP_BSN__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN INSP_BSN.DSC_BSN__NUM_BSN IS 'N° Bassin';
COMMENT ON COLUMN INSP_BSN.CD_METEO_BSN__METEO IS 'Météo';
COMMENT ON COLUMN INSP_BSN.INSPECTEUR_BSN__NOM IS 'Nom inspecteur';
COMMENT ON COLUMN INSP_BSN.CD_ETUDE_BSN__ETUDE IS 'Etude-Expertise';
COMMENT ON COLUMN INSP_BSN.ETAT IS 'Statut visite';
COMMENT ON COLUMN INSP_BSN.DATEV IS 'Date de visite';
COMMENT ON COLUMN INSP_BSN.TEMPERATURE IS 'Température';
COMMENT ON COLUMN INSP_BSN.MOYEN IS 'Moyen utilisé';
COMMENT ON COLUMN INSP_BSN.CONDITIONS IS 'Condition particulière';
COMMENT ON COLUMN INSP_BSN.DATE_VALID IS 'Date Validation';
COMMENT ON COLUMN INSP_BSN.NOM_VALID IS 'Nom Valideur';
COMMENT ON COLUMN INSP_BSN.DESC_INVA IS 'Description invalide';
COMMENT ON COLUMN INSP_BSN.SECURITE IS 'Problème de sécurité';
COMMENT ON COLUMN INSP_BSN.PRIORITAIRE IS 'Urgence traitement';
COMMENT ON COLUMN INSP_BSN.NOTE1 IS 'Note Structure';
COMMENT ON COLUMN INSP_BSN.NOTE2 IS 'Note Equipements';
COMMENT ON COLUMN INSP_BSN.NOTE3 IS 'Note Abords-Végétation';
COMMENT ON COLUMN INSP_BSN.NOTE4 IS 'Note Sécurité';
COMMENT ON COLUMN INSP_BSN.URGENCE IS 'Niveau Urgence';
COMMENT ON COLUMN INSP_BSN.QUALITE IS 'Image qualité';

-- ---------------------------------------------------------
-- Table INSP_TMP_BSN
-- ---------------------------------------------------------
CREATE TABLE INSP_TMP_BSN 
( 
	CAMP_BSN__ID_CAMP                       VARCHAR2(100 CHAR) NOT NULL,
	DSC_TEMP_BSN__NUM_BSN                   VARCHAR2(20 CHAR) NOT NULL,
	INSPECTEUR_BSN__NOM                     VARCHAR2(60 CHAR),
	CD_METEO_BSN__METEO                     VARCHAR2(60 CHAR),
	CD_ETUDE_BSN__ETUDE                     VARCHAR2(65 CHAR),
	ETAT                                    VARCHAR2(25 CHAR) NOT NULL,
	DATEV                                   DATE,
	TEMPERATURE                             NUMBER(4,2),
	MOYEN                                   VARCHAR2(500 CHAR),
	CONDITIONS                              VARCHAR2(500 CHAR),
	DATE_VALID                              DATE,
	NOM_VALID                               VARCHAR2(250 CHAR),
	DESC_INVA                               VARCHAR2(1000 CHAR),
	SECURITE                                VARCHAR2(1000 CHAR),
	PRIORITAIRE                             VARCHAR2(1000 CHAR),
	NOTE1                                   NUMBER(1),
	NOTE2                                   NUMBER(1),
	NOTE3                                   NUMBER(1),
	NOTE4                                   NUMBER(1),
	URGENCE                                 VARCHAR2(5 CHAR),
	QUALITE                                 VARCHAR2(25 CHAR)
);
COMMENT ON TABLE INSP_TMP_BSN IS 'Inspection temporaire';
COMMENT ON COLUMN INSP_TMP_BSN.CAMP_BSN__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN INSP_TMP_BSN.DSC_TEMP_BSN__NUM_BSN IS 'N° Bassin';
COMMENT ON COLUMN INSP_TMP_BSN.INSPECTEUR_BSN__NOM IS 'Nom inspecteur';
COMMENT ON COLUMN INSP_TMP_BSN.CD_METEO_BSN__METEO IS 'Météo';
COMMENT ON COLUMN INSP_TMP_BSN.CD_ETUDE_BSN__ETUDE IS 'Etude-Expertise';
COMMENT ON COLUMN INSP_TMP_BSN.ETAT IS 'Statut visite';
COMMENT ON COLUMN INSP_TMP_BSN.DATEV IS 'Date de visite';
COMMENT ON COLUMN INSP_TMP_BSN.TEMPERATURE IS 'Température';
COMMENT ON COLUMN INSP_TMP_BSN.MOYEN IS 'Moyen utilisé';
COMMENT ON COLUMN INSP_TMP_BSN.CONDITIONS IS 'Condition particulière';
COMMENT ON COLUMN INSP_TMP_BSN.DATE_VALID IS 'Date Validation';
COMMENT ON COLUMN INSP_TMP_BSN.NOM_VALID IS 'Nom Valideur';
COMMENT ON COLUMN INSP_TMP_BSN.DESC_INVA IS 'Description invalide';
COMMENT ON COLUMN INSP_TMP_BSN.SECURITE IS 'Problème de sécurité';
COMMENT ON COLUMN INSP_TMP_BSN.PRIORITAIRE IS 'Urgence traitement';
COMMENT ON COLUMN INSP_TMP_BSN.NOTE1 IS 'Note Structure';
COMMENT ON COLUMN INSP_TMP_BSN.NOTE2 IS 'Note Equipements';
COMMENT ON COLUMN INSP_TMP_BSN.NOTE3 IS 'Note Abords-Végétation';
COMMENT ON COLUMN INSP_TMP_BSN.NOTE4 IS 'Note Sécurité';
COMMENT ON COLUMN INSP_TMP_BSN.URGENCE IS 'Niveau Urgence';
COMMENT ON COLUMN INSP_TMP_BSN.QUALITE IS 'Image qualité';

-- ---------------------------------------------------------
-- Table CD_LIGNE_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_LIGNE_BSN 
( 
	CD_CHAPITRE_BSN__ID_CHAP                NUMBER(7) NOT NULL,
	ID_LIGNE                                NUMBER(7) NOT NULL,
	LIBELLE                                 VARCHAR2(500 CHAR) NOT NULL,
	ORDRE_LIGNE                             NUMBER(7) NOT NULL
);
COMMENT ON TABLE CD_LIGNE_BSN IS 'Ligne';
COMMENT ON COLUMN CD_LIGNE_BSN.CD_CHAPITRE_BSN__ID_CHAP IS 'Identifiant chapitre';
COMMENT ON COLUMN CD_LIGNE_BSN.ID_LIGNE IS 'Identifiant ligne';
COMMENT ON COLUMN CD_LIGNE_BSN.LIBELLE IS 'Libellé Ligne';
COMMENT ON COLUMN CD_LIGNE_BSN.ORDRE_LIGNE IS 'N° ordre ligne';

-- ---------------------------------------------------------
-- Table CD_METEO_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_METEO_BSN 
( 
	METEO                                   VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_METEO_BSN IS 'Météo';
COMMENT ON COLUMN CD_METEO_BSN.METEO IS 'Météo';

-- ---------------------------------------------------------
-- Table CD_SOUS_TYPE_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_SOUS_TYPE_BSN 
( 
	NAT_SENSIB                              VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_SOUS_TYPE_BSN IS 'Nature sensibilité';
COMMENT ON COLUMN CD_SOUS_TYPE_BSN.NAT_SENSIB IS 'Nature sensibilité';

-- ---------------------------------------------------------
-- Table NATURE_TRAV_BSN
-- ---------------------------------------------------------
CREATE TABLE NATURE_TRAV_BSN 
( 
	CD_TRAVAUX_BSN__CODE                    VARCHAR2(60 CHAR) NOT NULL,
	NATURE                                  VARCHAR2(100 CHAR) NOT NULL
);
COMMENT ON TABLE NATURE_TRAV_BSN IS 'Nature travaux';
COMMENT ON COLUMN NATURE_TRAV_BSN.CD_TRAVAUX_BSN__CODE IS 'Type travaux';
COMMENT ON COLUMN NATURE_TRAV_BSN.NATURE IS 'Nature travaux';

-- ---------------------------------------------------------
-- Table CD_ORIGIN_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_ORIGIN_BSN 
( 
	ORIGINE                                 VARCHAR2(20 CHAR) NOT NULL
);
COMMENT ON TABLE CD_ORIGIN_BSN IS 'Origine Note';
COMMENT ON COLUMN CD_ORIGIN_BSN.ORIGINE IS 'Origine Note';

-- ---------------------------------------------------------
-- Table PRT_BSN
-- ---------------------------------------------------------
CREATE TABLE PRT_BSN 
( 
	GRP_BSN__ID_GRP                         NUMBER(7) NOT NULL,
	ID_PRT                                  NUMBER(7) NOT NULL,
	LIBP                                    VARCHAR2(500 CHAR) NOT NULL,
	ORDRE                                   NUMBER(7) NOT NULL
);
COMMENT ON TABLE PRT_BSN IS 'Partie';
COMMENT ON COLUMN PRT_BSN.GRP_BSN__ID_GRP IS 'Identifiant Groupe';
COMMENT ON COLUMN PRT_BSN.ID_PRT IS 'Identifiant Partie';
COMMENT ON COLUMN PRT_BSN.LIBP IS 'Partie';
COMMENT ON COLUMN PRT_BSN.ORDRE IS 'N° Ordre';

-- ---------------------------------------------------------
-- Table CD_PERMEABLE_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_PERMEABLE_BSN 
( 
	TYPE                                    VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_PERMEABLE_BSN IS 'Perméabilité';
COMMENT ON COLUMN CD_PERMEABLE_BSN.TYPE IS 'Perméabilité';

-- ---------------------------------------------------------
-- Table PHOTO_INSP_BSN
-- ---------------------------------------------------------
CREATE TABLE PHOTO_INSP_BSN 
( 
	ID                                      VARCHAR2(30 CHAR) NOT NULL,
	CAMP_BSN__ID_CAMP                       VARCHAR2(100 CHAR) NOT NULL,
	DSC_BSN__NUM_BSN                        VARCHAR2(20 CHAR) NOT NULL,
	COMMENTAIRE                             VARCHAR2(100 CHAR)
);
COMMENT ON TABLE PHOTO_INSP_BSN IS 'Photo de l''ouvrage';
COMMENT ON COLUMN PHOTO_INSP_BSN.ID IS 'Identifiant';
COMMENT ON COLUMN PHOTO_INSP_BSN.CAMP_BSN__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN PHOTO_INSP_BSN.DSC_BSN__NUM_BSN IS 'N° Bassin';
COMMENT ON COLUMN PHOTO_INSP_BSN.COMMENTAIRE IS 'Commentaire';

-- ---------------------------------------------------------
-- Table PHOTO_INSP_TMP_BSN
-- ---------------------------------------------------------
CREATE TABLE PHOTO_INSP_TMP_BSN 
( 
	ID                                      VARCHAR2(30 CHAR) NOT NULL,
	CAMP_BSN__ID_CAMP                       VARCHAR2(100 CHAR) NOT NULL,
	DSC_TEMP_BSN__NUM_BSN                   VARCHAR2(20 CHAR) NOT NULL,
	COMMENTAIRE                             VARCHAR2(100 CHAR)
);
COMMENT ON TABLE PHOTO_INSP_TMP_BSN IS 'Photo de l''ouvrage temporaire';
COMMENT ON COLUMN PHOTO_INSP_TMP_BSN.ID IS 'Identifiant';
COMMENT ON COLUMN PHOTO_INSP_TMP_BSN.CAMP_BSN__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN PHOTO_INSP_TMP_BSN.DSC_TEMP_BSN__NUM_BSN IS 'N° Bassin';
COMMENT ON COLUMN PHOTO_INSP_TMP_BSN.COMMENTAIRE IS 'Commentaire';

-- ---------------------------------------------------------
-- Table PHOTO_ELT_INSP_BSN
-- ---------------------------------------------------------
CREATE TABLE PHOTO_ELT_INSP_BSN 
( 
	GRP_BSN__ID_GRP                         NUMBER(7) NOT NULL,
	PRT_BSN__ID_PRT                         NUMBER(7) NOT NULL,
	SPRT_BSN__ID_SPRT                       NUMBER(7) NOT NULL,
	CAMP_BSN__ID_CAMP                       VARCHAR2(100 CHAR) NOT NULL,
	ELT_BSN__ID_ELEM                        NUMBER(7) NOT NULL,
	DSC_BSN__NUM_BSN                        VARCHAR2(20 CHAR) NOT NULL,
	ID                                      VARCHAR2(50 CHAR) NOT NULL,
	COMMENTAIRE                             VARCHAR2(100 CHAR)
);
COMMENT ON TABLE PHOTO_ELT_INSP_BSN IS 'Photo éléments inspectés';
COMMENT ON COLUMN PHOTO_ELT_INSP_BSN.GRP_BSN__ID_GRP IS 'Identifiant Groupe';
COMMENT ON COLUMN PHOTO_ELT_INSP_BSN.PRT_BSN__ID_PRT IS 'Identifiant Partie';
COMMENT ON COLUMN PHOTO_ELT_INSP_BSN.SPRT_BSN__ID_SPRT IS 'Identifiant Sous Partie';
COMMENT ON COLUMN PHOTO_ELT_INSP_BSN.CAMP_BSN__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN PHOTO_ELT_INSP_BSN.ELT_BSN__ID_ELEM IS 'Identifiant Elément';
COMMENT ON COLUMN PHOTO_ELT_INSP_BSN.DSC_BSN__NUM_BSN IS 'N° Bassin';
COMMENT ON COLUMN PHOTO_ELT_INSP_BSN.ID IS 'Identifiant de la photo';
COMMENT ON COLUMN PHOTO_ELT_INSP_BSN.COMMENTAIRE IS 'Commentaire';

-- ---------------------------------------------------------
-- Table PHOTO_ELT_INSP_TMP_BSN
-- ---------------------------------------------------------
CREATE TABLE PHOTO_ELT_INSP_TMP_BSN 
( 
	GRP_BSN__ID_GRP                         NUMBER(7) NOT NULL,
	PRT_BSN__ID_PRT                         NUMBER(7) NOT NULL,
	SPRT_BSN__ID_SPRT                       NUMBER(7) NOT NULL,
	CAMP_BSN__ID_CAMP                       VARCHAR2(100 CHAR) NOT NULL,
	DSC_TEMP_BSN__NUM_BSN                   VARCHAR2(20 CHAR) NOT NULL,
	ELT_BSN__ID_ELEM                        NUMBER(7) NOT NULL,
	ID                                      VARCHAR2(50 CHAR) NOT NULL,
	COMMENTAIRE                             VARCHAR2(100 CHAR)
);
COMMENT ON TABLE PHOTO_ELT_INSP_TMP_BSN IS 'Photo éléments inspectés temporaire';
COMMENT ON COLUMN PHOTO_ELT_INSP_TMP_BSN.GRP_BSN__ID_GRP IS 'Identifiant Groupe';
COMMENT ON COLUMN PHOTO_ELT_INSP_TMP_BSN.PRT_BSN__ID_PRT IS 'Identifiant Partie';
COMMENT ON COLUMN PHOTO_ELT_INSP_TMP_BSN.SPRT_BSN__ID_SPRT IS 'Identifiant Sous Partie';
COMMENT ON COLUMN PHOTO_ELT_INSP_TMP_BSN.CAMP_BSN__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN PHOTO_ELT_INSP_TMP_BSN.DSC_TEMP_BSN__NUM_BSN IS 'N° Bassin';
COMMENT ON COLUMN PHOTO_ELT_INSP_TMP_BSN.ELT_BSN__ID_ELEM IS 'Identifiant Elément';
COMMENT ON COLUMN PHOTO_ELT_INSP_TMP_BSN.ID IS 'Identifiant de la photo';
COMMENT ON COLUMN PHOTO_ELT_INSP_TMP_BSN.COMMENTAIRE IS 'Commentaire';

-- ---------------------------------------------------------
-- Table PHOTO_SPRT_VST_BSN
-- ---------------------------------------------------------
CREATE TABLE PHOTO_SPRT_VST_BSN 
( 
	CAMP_BSN__ID_CAMP                       VARCHAR2(100 CHAR) NOT NULL,
	DSC_BSN__NUM_BSN                        VARCHAR2(20 CHAR) NOT NULL,
	CD_CHAPITRE_BSN__ID_CHAP                NUMBER(7) NOT NULL,
	CD_LIGNE_BSN__ID_LIGNE                  NUMBER(7) NOT NULL,
	ID                                      VARCHAR2(50 CHAR) NOT NULL,
	COMMENTAIRE                             VARCHAR2(100 CHAR)
);
COMMENT ON TABLE PHOTO_SPRT_VST_BSN IS 'Photo sous-parties visitées';
COMMENT ON COLUMN PHOTO_SPRT_VST_BSN.CAMP_BSN__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN PHOTO_SPRT_VST_BSN.DSC_BSN__NUM_BSN IS 'N° Bassin';
COMMENT ON COLUMN PHOTO_SPRT_VST_BSN.CD_CHAPITRE_BSN__ID_CHAP IS 'Identifiant chapitre';
COMMENT ON COLUMN PHOTO_SPRT_VST_BSN.CD_LIGNE_BSN__ID_LIGNE IS 'Identifiant ligne';
COMMENT ON COLUMN PHOTO_SPRT_VST_BSN.ID IS 'Identifiant de la photo';
COMMENT ON COLUMN PHOTO_SPRT_VST_BSN.COMMENTAIRE IS 'Commentaire';

-- ---------------------------------------------------------
-- Table PHOTO_VST_BSN
-- ---------------------------------------------------------
CREATE TABLE PHOTO_VST_BSN 
( 
	ID                                      VARCHAR2(30 CHAR) NOT NULL,
	CAMP_BSN__ID_CAMP                       VARCHAR2(100 CHAR) NOT NULL,
	DSC_BSN__NUM_BSN                        VARCHAR2(20 CHAR) NOT NULL,
	COMMENTAIRE                             VARCHAR2(100 CHAR)
);
COMMENT ON TABLE PHOTO_VST_BSN IS 'Photo vst bassin';
COMMENT ON COLUMN PHOTO_VST_BSN.ID IS 'photo vst BSN id';
COMMENT ON COLUMN PHOTO_VST_BSN.CAMP_BSN__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN PHOTO_VST_BSN.DSC_BSN__NUM_BSN IS 'N° Bassin';
COMMENT ON COLUMN PHOTO_VST_BSN.COMMENTAIRE IS 'photo vst BSN commentaire';

-- ---------------------------------------------------------
-- Table CD_PRECO__SPRT_VST_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_PRECO__SPRT_VST_BSN 
( 
	CAMP_BSN__ID_CAMP                       VARCHAR2(100 CHAR) NOT NULL,
	DSC_BSN__NUM_BSN                        VARCHAR2(20 CHAR) NOT NULL,
	CD_CHAPITRE_BSN__ID_CHAP                NUMBER(7) NOT NULL,
	CD_LIGNE_BSN__ID_LIGNE                  NUMBER(7) NOT NULL,
	BPU_BSN__ID_BPU                         NUMBER(7) NOT NULL,
	REALISE                                 NUMBER
);
COMMENT ON TABLE CD_PRECO__SPRT_VST_BSN IS 'Préconisation';
COMMENT ON COLUMN CD_PRECO__SPRT_VST_BSN.CAMP_BSN__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN CD_PRECO__SPRT_VST_BSN.DSC_BSN__NUM_BSN IS 'N° Bassin';
COMMENT ON COLUMN CD_PRECO__SPRT_VST_BSN.CD_CHAPITRE_BSN__ID_CHAP IS 'Identifiant chapitre';
COMMENT ON COLUMN CD_PRECO__SPRT_VST_BSN.CD_LIGNE_BSN__ID_LIGNE IS 'Identifiant ligne';
COMMENT ON COLUMN CD_PRECO__SPRT_VST_BSN.BPU_BSN__ID_BPU IS 'Identifiant Bordereau';
COMMENT ON COLUMN CD_PRECO__SPRT_VST_BSN.REALISE IS 'Entretien réalisé';

-- ---------------------------------------------------------
-- Table CD_PRESTA_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_PRESTA_BSN 
( 
	PRESTATAIRE                             VARCHAR2(50 CHAR) NOT NULL
);
COMMENT ON TABLE CD_PRESTA_BSN IS 'Prestataire';
COMMENT ON COLUMN CD_PRESTA_BSN.PRESTATAIRE IS 'Prestataire';

-- ---------------------------------------------------------
-- Table PREVISION_BSN
-- ---------------------------------------------------------
CREATE TABLE PREVISION_BSN 
( 
	DSC_BSN__NUM_BSN                        VARCHAR2(20 CHAR) NOT NULL,
	BPU_BSN__ID_BPU                         NUMBER(7) NOT NULL,
	DATE_DEBUT                              DATE NOT NULL,
	CD_CONTRAINTE_BSN__TYPE                 VARCHAR2(100 CHAR),
	DATE_FIN                                DATE,
	MONTANT                                 NUMBER(9),
	DATE_DEM_PUB                            DATE,
	COMMENTAIRE                             VARCHAR2(255 CHAR),
	REALISE                                 NUMBER
);
COMMENT ON TABLE PREVISION_BSN IS 'Prévisions';
COMMENT ON COLUMN PREVISION_BSN.DSC_BSN__NUM_BSN IS 'N° Bassin';
COMMENT ON COLUMN PREVISION_BSN.BPU_BSN__ID_BPU IS 'Identifiant Bordereau';
COMMENT ON COLUMN PREVISION_BSN.DATE_DEBUT IS 'Date début';
COMMENT ON COLUMN PREVISION_BSN.CD_CONTRAINTE_BSN__TYPE IS 'Contrainte exploit';
COMMENT ON COLUMN PREVISION_BSN.DATE_FIN IS 'Date fin';
COMMENT ON COLUMN PREVISION_BSN.MONTANT IS 'Coûts';
COMMENT ON COLUMN PREVISION_BSN.DATE_DEM_PUB IS 'Date demande publication';
COMMENT ON COLUMN PREVISION_BSN.COMMENTAIRE IS 'Commentaire';
COMMENT ON COLUMN PREVISION_BSN.REALISE IS 'Réalisé';

-- ---------------------------------------------------------
-- Table CD_ROLE_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_ROLE_BSN 
( 
	ROLE                                    VARCHAR2(25 CHAR) NOT NULL
);
COMMENT ON TABLE CD_ROLE_BSN IS 'Rôle du bassin';
COMMENT ON COLUMN CD_ROLE_BSN.ROLE IS 'Rôle';

-- ---------------------------------------------------------
-- Table CD_ROLE__DSC_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_ROLE__DSC_BSN 
( 
	DSC_BSN__NUM_BSN                        VARCHAR2(20 CHAR) NOT NULL,
	CD_ROLE_BSN__ROLE                       VARCHAR2(25 CHAR) NOT NULL
);
COMMENT ON TABLE CD_ROLE__DSC_BSN IS 'Rôles';
COMMENT ON COLUMN CD_ROLE__DSC_BSN.DSC_BSN__NUM_BSN IS 'N° Bassin';
COMMENT ON COLUMN CD_ROLE__DSC_BSN.CD_ROLE_BSN__ROLE IS 'Rôle';

-- ---------------------------------------------------------
-- Table ENTETE_BSN
-- ---------------------------------------------------------
CREATE TABLE ENTETE_BSN 
( 
	CAMP_BSN__ID_CAMP                       VARCHAR2(100 CHAR) NOT NULL,
	DSC_BSN__NUM_BSN                        VARCHAR2(20 CHAR) NOT NULL,
	CD_ENTETE_BSN__ID_ENTETE                NUMBER(7) NOT NULL,
	VALEUR                                  VARCHAR2(250 CHAR)
);
COMMENT ON TABLE ENTETE_BSN IS 'Saisie entête';
COMMENT ON COLUMN ENTETE_BSN.CAMP_BSN__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN ENTETE_BSN.DSC_BSN__NUM_BSN IS 'N° Bassin';
COMMENT ON COLUMN ENTETE_BSN.CD_ENTETE_BSN__ID_ENTETE IS 'Identifiant Entête';
COMMENT ON COLUMN ENTETE_BSN.VALEUR IS 'Valeur';

-- ---------------------------------------------------------
-- Table CD_TYPE_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_TYPE_BSN 
( 
	TYPE                                    VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_TYPE_BSN IS 'Sensibilité du milieu';
COMMENT ON COLUMN CD_TYPE_BSN.TYPE IS 'Sensibilité du milieu';

-- ---------------------------------------------------------
-- Table SEUIL_QUALITE_BSN
-- ---------------------------------------------------------
CREATE TABLE SEUIL_QUALITE_BSN 
( 
	CD_QUALITE_BSN__QUALITE                 VARCHAR2(25 CHAR) NOT NULL,
	INDICE_URGENCE                          VARCHAR2(5 CHAR) NOT NULL
);
COMMENT ON TABLE SEUIL_QUALITE_BSN IS 'Seuil qualité';
COMMENT ON COLUMN SEUIL_QUALITE_BSN.CD_QUALITE_BSN__QUALITE IS 'Niveau qualité';
COMMENT ON COLUMN SEUIL_QUALITE_BSN.INDICE_URGENCE IS 'Indice urgence';

-- ---------------------------------------------------------
-- Table SEUIL_URGENCE_BSN
-- ---------------------------------------------------------
CREATE TABLE SEUIL_URGENCE_BSN 
( 
	ORDRE                                   NUMBER(9) NOT NULL,
	NBR_NOTE                                NUMBER(9),
	VAL_NOTE                                NUMBER(9),
	INDICE                                  NUMBER(9)
);
COMMENT ON TABLE SEUIL_URGENCE_BSN IS 'Seuil urgence';
COMMENT ON COLUMN SEUIL_URGENCE_BSN.ORDRE IS 'No Ordre';
COMMENT ON COLUMN SEUIL_URGENCE_BSN.NBR_NOTE IS '>= Nbre de note';
COMMENT ON COLUMN SEUIL_URGENCE_BSN.VAL_NOTE IS 'Valeur de note';
COMMENT ON COLUMN SEUIL_URGENCE_BSN.INDICE IS 'Ind dégradation';

-- ---------------------------------------------------------
-- Table SPRT_BSN
-- ---------------------------------------------------------
CREATE TABLE SPRT_BSN 
( 
	GRP_BSN__ID_GRP                         NUMBER(7) NOT NULL,
	PRT_BSN__ID_PRT                         NUMBER(7) NOT NULL,
	ID_SPRT                                 NUMBER(7) NOT NULL,
	LIBS                                    VARCHAR2(500 CHAR) NOT NULL,
	ORDRE                                   NUMBER(7) NOT NULL
);
COMMENT ON TABLE SPRT_BSN IS 'Sous Partie';
COMMENT ON COLUMN SPRT_BSN.GRP_BSN__ID_GRP IS 'Identifiant Groupe';
COMMENT ON COLUMN SPRT_BSN.PRT_BSN__ID_PRT IS 'Identifiant Partie';
COMMENT ON COLUMN SPRT_BSN.ID_SPRT IS 'Identifiant Sous Partie';
COMMENT ON COLUMN SPRT_BSN.LIBS IS 'Sous Partie';
COMMENT ON COLUMN SPRT_BSN.ORDRE IS 'N° Ordre';

-- ---------------------------------------------------------
-- Table SYS_USER_BSN
-- ---------------------------------------------------------
CREATE TABLE SYS_USER_BSN 
( 
	CODE_DBS                                VARCHAR2(50 CHAR) NOT NULL,
	CODE_TABLE                              VARCHAR2(100 CHAR) NOT NULL,
	CODE_COLONNE                            VARCHAR2(100 CHAR) NOT NULL,
	NOM_USER                                VARCHAR2(150 CHAR) NOT NULL,
	CODE_PRP                                VARCHAR2(255 CHAR) NOT NULL,
	VAL_PRP                                 VARCHAR2(500 CHAR) NOT NULL
);
COMMENT ON TABLE SYS_USER_BSN IS 'SYS_USER_BSN';
COMMENT ON COLUMN SYS_USER_BSN.CODE_DBS IS 'SYS_USER_BSN__CODE_DBS';
COMMENT ON COLUMN SYS_USER_BSN.CODE_TABLE IS 'SYS_USER_BSN__CODE_TABLE';
COMMENT ON COLUMN SYS_USER_BSN.CODE_COLONNE IS 'SYS_USER_BSN__CODE_COLONNE';
COMMENT ON COLUMN SYS_USER_BSN.NOM_USER IS 'SYS_USER_BSN__NOM_USER';
COMMENT ON COLUMN SYS_USER_BSN.CODE_PRP IS 'SYS_USER_BSN__CODE_PRP';
COMMENT ON COLUMN SYS_USER_BSN.VAL_PRP IS 'SYS_USER_BSN__VAL_PRP';

-- ---------------------------------------------------------
-- Table TRAVAUX_BSN
-- ---------------------------------------------------------
CREATE TABLE TRAVAUX_BSN 
( 
	DSC_BSN__NUM_BSN                        VARCHAR2(20 CHAR) NOT NULL,
	CD_TRAVAUX_BSN__CODE                    VARCHAR2(60 CHAR) NOT NULL,
	NATURE_TRAV_BSN__NATURE                 VARCHAR2(100 CHAR) NOT NULL,
	DATE_RCP                                DATE NOT NULL,
	CD_ENTP_BSN__ENTREPRISE                 VARCHAR2(60 CHAR) NOT NULL,
	DATE_FIN_GAR                            DATE,
	COUT                                    NUMBER(9),
	MARCHE                                  VARCHAR2(25 CHAR),
	COMMENTAIRE                             VARCHAR2(500 CHAR)
);
COMMENT ON TABLE TRAVAUX_BSN IS 'Travaux';
COMMENT ON COLUMN TRAVAUX_BSN.DSC_BSN__NUM_BSN IS 'N° Bassin';
COMMENT ON COLUMN TRAVAUX_BSN.CD_TRAVAUX_BSN__CODE IS 'Type travaux';
COMMENT ON COLUMN TRAVAUX_BSN.NATURE_TRAV_BSN__NATURE IS 'Nature travaux';
COMMENT ON COLUMN TRAVAUX_BSN.DATE_RCP IS 'Date Réception';
COMMENT ON COLUMN TRAVAUX_BSN.CD_ENTP_BSN__ENTREPRISE IS 'Entreprise';
COMMENT ON COLUMN TRAVAUX_BSN.DATE_FIN_GAR IS 'Fin de garantie';
COMMENT ON COLUMN TRAVAUX_BSN.COUT IS 'Coût';
COMMENT ON COLUMN TRAVAUX_BSN.MARCHE IS 'No Marché';
COMMENT ON COLUMN TRAVAUX_BSN.COMMENTAIRE IS 'Commentaire';

-- ---------------------------------------------------------
-- Table CD_ACCES_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_ACCES_BSN 
( 
	VACCES                                  VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_ACCES_BSN IS 'Type Accès';
COMMENT ON COLUMN CD_ACCES_BSN.VACCES IS 'Voie d''accès';

-- ---------------------------------------------------------
-- Table CD_COMPOSANT_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_COMPOSANT_BSN 
( 
	TYPE_COMP                               VARCHAR2(6 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(60 CHAR)
);
COMMENT ON TABLE CD_COMPOSANT_BSN IS 'Type Composant';
COMMENT ON COLUMN CD_COMPOSANT_BSN.TYPE_COMP IS 'Type Composant';
COMMENT ON COLUMN CD_COMPOSANT_BSN.LIBELLE IS 'Libellé';

-- ---------------------------------------------------------
-- Table CD_DOC_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_DOC_BSN 
( 
	CODE                                    VARCHAR2(15 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(60 CHAR),
	PATH                                    VARCHAR2(255 CHAR)
);
COMMENT ON TABLE CD_DOC_BSN IS 'Type de document';
COMMENT ON COLUMN CD_DOC_BSN.CODE IS 'Code';
COMMENT ON COLUMN CD_DOC_BSN.LIBELLE IS 'Libellé';
COMMENT ON COLUMN CD_DOC_BSN.PATH IS 'Répertoire';

-- ---------------------------------------------------------
-- Table CD_EVT_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_EVT_BSN 
( 
	TYPE                                    VARCHAR2(25 CHAR) NOT NULL,
	IMPACT                                  NUMBER
);
COMMENT ON TABLE CD_EVT_BSN IS 'Type d''événement';
COMMENT ON COLUMN CD_EVT_BSN.TYPE IS 'Type événement';
COMMENT ON COLUMN CD_EVT_BSN.IMPACT IS 'Impact métier';

-- ---------------------------------------------------------
-- Table CD_TYPEQP_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_TYPEQP_BSN 
( 
	CD_FAMEQP_BSN__FAM                      VARCHAR2(25 CHAR) NOT NULL,
	TYPE                                    VARCHAR2(60 CHAR) NOT NULL,
	GARANTIE                                NUMBER(3),
	DVT                                     NUMBER(3)
);
COMMENT ON TABLE CD_TYPEQP_BSN IS 'Type Equipement';
COMMENT ON COLUMN CD_TYPEQP_BSN.CD_FAMEQP_BSN__FAM IS 'Famille EQP';
COMMENT ON COLUMN CD_TYPEQP_BSN.TYPE IS 'Type EQP';
COMMENT ON COLUMN CD_TYPEQP_BSN.GARANTIE IS 'Garantie (mois)';
COMMENT ON COLUMN CD_TYPEQP_BSN.DVT IS 'Durée de vie (mois)';

-- ---------------------------------------------------------
-- Table CD_TYPE_PV_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_TYPE_PV_BSN 
( 
	CODE                                    VARCHAR2(15 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(60 CHAR) NOT NULL,
	CYCLE                                   NUMBER(6),
	COUT                                    NUMBER(6)
);
COMMENT ON TABLE CD_TYPE_PV_BSN IS 'Type PV';
COMMENT ON COLUMN CD_TYPE_PV_BSN.CODE IS 'Type de PV';
COMMENT ON COLUMN CD_TYPE_PV_BSN.LIBELLE IS 'Libellé';
COMMENT ON COLUMN CD_TYPE_PV_BSN.CYCLE IS 'Cycle';
COMMENT ON COLUMN CD_TYPE_PV_BSN.COUT IS 'Coût unitaire';

-- ---------------------------------------------------------
-- Table CD_TRAVAUX_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_TRAVAUX_BSN 
( 
	CODE                                    VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_TRAVAUX_BSN IS 'Type travaux';
COMMENT ON COLUMN CD_TRAVAUX_BSN.CODE IS 'Type travaux';

-- ---------------------------------------------------------
-- Table CD_UNITE_BSN
-- ---------------------------------------------------------
CREATE TABLE CD_UNITE_BSN 
( 
	UNITE                                   VARCHAR2(12 CHAR) NOT NULL
);
COMMENT ON TABLE CD_UNITE_BSN IS 'Unité';
COMMENT ON COLUMN CD_UNITE_BSN.UNITE IS 'Unité';

-- ---------------------------------------------------------
-- Table VST_BSN
-- ---------------------------------------------------------
CREATE TABLE VST_BSN 
( 
	CAMP_BSN__ID_CAMP                       VARCHAR2(100 CHAR) NOT NULL,
	DSC_BSN__NUM_BSN                        VARCHAR2(20 CHAR) NOT NULL,
	INSPECTEUR_BSN__NOM                     VARCHAR2(60 CHAR),
	ETAT                                    VARCHAR2(25 CHAR) NOT NULL,
	DATEV                                   DATE,
	PRIORITAIRE                             NUMBER,
	OBSERV                                  VARCHAR2(500 CHAR),
	NOTE_VST                                VARCHAR2(5 CHAR)
);
COMMENT ON TABLE VST_BSN IS 'Visite';
COMMENT ON COLUMN VST_BSN.CAMP_BSN__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN VST_BSN.DSC_BSN__NUM_BSN IS 'N° Bassin';
COMMENT ON COLUMN VST_BSN.INSPECTEUR_BSN__NOM IS 'Nom inspecteur';
COMMENT ON COLUMN VST_BSN.ETAT IS 'Statut visite';
COMMENT ON COLUMN VST_BSN.DATEV IS 'Date de visite';
COMMENT ON COLUMN VST_BSN.PRIORITAIRE IS 'Urgence traitement';
COMMENT ON COLUMN VST_BSN.OBSERV IS 'Observation';
COMMENT ON COLUMN VST_BSN.NOTE_VST IS 'Note Visite';

