/*################################################################################################*/
/* Script     : OH_Tables.sql                                                                     */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

-- ---------------------------------------------------------
-- Table SYS_PRP_OH
-- ---------------------------------------------------------

CREATE TABLE SYS_PRP_OH 
( 
	CODE_TABLE                    VARCHAR2(60 CHAR)        NOT NULL,
	CODE_COLONNE                  VARCHAR2(60 CHAR)        NOT NULL,
	NOM_USER                      VARCHAR2(30 CHAR)        NOT NULL,
	CODE_PRP                      VARCHAR2(60 CHAR)        NOT NULL,
	VAL_PRP                       VARCHAR2(255 CHAR)       );
COMMENT ON TABLE SYS_PRP_OH IS 'MétaDonnées du schéma OH';

-- ---------------------------------------------------------
-- Table SYS_INSTANCE_OH
-- ---------------------------------------------------------

CREATE TABLE SYS_INSTANCE_OH 
( 
	CODE                   VARCHAR2(100 CHAR) NOT NULL,
	VALEUR                 CLOB);
COMMENT ON TABLE SYS_INSTANCE_OH IS 'Informations du schéma OH';

-- ---------------------------------------------------------
-- Table BPU_OH
-- ---------------------------------------------------------
CREATE TABLE BPU_OH 
( 
	ID_BPU                                  NUMBER(7) NOT NULL,
	CD_UNITE_OH__UNITE                      VARCHAR2(12 CHAR),
	CD_TRAVAUX_OH__CODE                     VARCHAR2(60 CHAR) NOT NULL,
	TECHN                                   VARCHAR2(255 CHAR) NOT NULL,
	PRIX                                    NUMBER(9),
	DATE_MAJ                                DATE,
	FREQ                                    NUMBER(3),
	PRECO_VST                               NUMBER,
	REALIS_VST                              NUMBER
);
COMMENT ON TABLE BPU_OH IS 'Bordereau Prix';
COMMENT ON COLUMN BPU_OH.ID_BPU IS 'Identifiant Bordereau';
COMMENT ON COLUMN BPU_OH.CD_UNITE_OH__UNITE IS 'Unité';
COMMENT ON COLUMN BPU_OH.CD_TRAVAUX_OH__CODE IS 'Type travaux';
COMMENT ON COLUMN BPU_OH.TECHN IS 'Technique';
COMMENT ON COLUMN BPU_OH.PRIX IS 'Prix Unitaire (€)';
COMMENT ON COLUMN BPU_OH.DATE_MAJ IS 'Date MAJ';
COMMENT ON COLUMN BPU_OH.FREQ IS 'Fréquence (mois)';
COMMENT ON COLUMN BPU_OH.PRECO_VST IS 'Préconisation Visite';
COMMENT ON COLUMN BPU_OH.REALIS_VST IS 'Entretien réalisable';

-- ---------------------------------------------------------
-- Table CAMP_OH
-- ---------------------------------------------------------
CREATE TABLE CAMP_OH 
( 
	ID_CAMP                                 VARCHAR2(100 CHAR) NOT NULL,
	CD_PRESTA_OH__PRESTATAIRE               VARCHAR2(50 CHAR) NOT NULL,
	CD_TYPE_PV_OH__CODE                     VARCHAR2(15 CHAR) NOT NULL,
	ANNEE                                   NUMBER(4) NOT NULL,
	DATER                                   DATE NOT NULL,
	DATEG                                   DATE,
	USERG                                   VARCHAR2(250 CHAR),
	OBSERV                                  VARCHAR2(500 CHAR)
);
COMMENT ON TABLE CAMP_OH IS 'Campagne';
COMMENT ON COLUMN CAMP_OH.ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN CAMP_OH.CD_PRESTA_OH__PRESTATAIRE IS 'Prestataire';
COMMENT ON COLUMN CAMP_OH.CD_TYPE_PV_OH__CODE IS 'Type de PV';
COMMENT ON COLUMN CAMP_OH.ANNEE IS 'Année';
COMMENT ON COLUMN CAMP_OH.DATER IS 'Date maxi retour';
COMMENT ON COLUMN CAMP_OH.DATEG IS 'Date génération';
COMMENT ON COLUMN CAMP_OH.USERG IS 'Nom Créateur';
COMMENT ON COLUMN CAMP_OH.OBSERV IS 'Commentaire';

-- ---------------------------------------------------------
-- Table CD_CHAPITRE_OH
-- ---------------------------------------------------------
CREATE TABLE CD_CHAPITRE_OH 
( 
	ID_CHAP                                 NUMBER(7) NOT NULL,
	LIBELLE                                 VARCHAR2(500 CHAR) NOT NULL,
	ORDRE_CHAP                              NUMBER(7) NOT NULL,
	PONDERATION                             NUMBER(3)
);
COMMENT ON TABLE CD_CHAPITRE_OH IS 'Chapitre';
COMMENT ON COLUMN CD_CHAPITRE_OH.ID_CHAP IS 'Identifiant chapitre';
COMMENT ON COLUMN CD_CHAPITRE_OH.LIBELLE IS 'Libellé chapitre';
COMMENT ON COLUMN CD_CHAPITRE_OH.ORDRE_CHAP IS 'N° ordre chapitre';
COMMENT ON COLUMN CD_CHAPITRE_OH.PONDERATION IS 'Pondération';

-- ---------------------------------------------------------
-- Table CLS_OH
-- ---------------------------------------------------------
CREATE TABLE CLS_OH 
( 
	ID                                      NUMBER(6,0) NOT NULL,
	TABLE_NAME                              VARCHAR2(30 CHAR) NOT NULL,
	KEY_VALUE                               VARCHAR2(500 CHAR) NOT NULL
);
COMMENT ON TABLE CLS_OH IS 'Classeurs';
COMMENT ON COLUMN CLS_OH.ID IS 'Identifiant du classeur(cpt)';
COMMENT ON COLUMN CLS_OH.TABLE_NAME IS 'Table';
COMMENT ON COLUMN CLS_OH.KEY_VALUE IS 'Enregistrement';

-- ---------------------------------------------------------
-- Table CD_CONCLUSION_OH
-- ---------------------------------------------------------
CREATE TABLE CD_CONCLUSION_OH 
( 
	ID_CONC                                 NUMBER(7) NOT NULL,
	LIBELLE                                 VARCHAR2(500 CHAR) NOT NULL,
	ORDRE                                   NUMBER(7) NOT NULL
);
COMMENT ON TABLE CD_CONCLUSION_OH IS 'Code conclusion';
COMMENT ON COLUMN CD_CONCLUSION_OH.ID_CONC IS 'Identifiant conclusion';
COMMENT ON COLUMN CD_CONCLUSION_OH.LIBELLE IS 'Libellé conclusion';
COMMENT ON COLUMN CD_CONCLUSION_OH.ORDRE IS 'N° ordre conclusion';

-- ---------------------------------------------------------
-- Table CD_QUALITE_OH
-- ---------------------------------------------------------
CREATE TABLE CD_QUALITE_OH 
( 
	QUALITE                                 VARCHAR2(25 CHAR) NOT NULL
);
COMMENT ON TABLE CD_QUALITE_OH IS 'Code Qualité';
COMMENT ON COLUMN CD_QUALITE_OH.QUALITE IS 'Niveau qualité';

-- ---------------------------------------------------------
-- Table CD_CONCLUSION__INSP_OH
-- ---------------------------------------------------------
CREATE TABLE CD_CONCLUSION__INSP_OH 
( 
	CAMP_OH__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	DSC_OH__NUM_OH                          VARCHAR2(20 CHAR) NOT NULL,
	CD_CONCLUSION_OH__ID_CONC               NUMBER(7) NOT NULL,
	CONTENU                                 VARCHAR2(1000 CHAR)
);
COMMENT ON TABLE CD_CONCLUSION__INSP_OH IS 'Conclusions';
COMMENT ON COLUMN CD_CONCLUSION__INSP_OH.CAMP_OH__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN CD_CONCLUSION__INSP_OH.DSC_OH__NUM_OH IS 'NumOH';
COMMENT ON COLUMN CD_CONCLUSION__INSP_OH.CD_CONCLUSION_OH__ID_CONC IS 'Identifiant conclusion';
COMMENT ON COLUMN CD_CONCLUSION__INSP_OH.CONTENU IS 'Contenu';

-- ---------------------------------------------------------
-- Table CD_CONCLUSION__INSP_TMP_OH
-- ---------------------------------------------------------
CREATE TABLE CD_CONCLUSION__INSP_TMP_OH 
( 
	CAMP_OH__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	DSC_TEMP_OH__NUM_OH                     VARCHAR2(20 CHAR) NOT NULL,
	CD_CONCLUSION_OH__ID_CONC               NUMBER(7) NOT NULL,
	CONTENU                                 VARCHAR2(1000 CHAR)
);
COMMENT ON TABLE CD_CONCLUSION__INSP_TMP_OH IS 'Conclusions temporaire';
COMMENT ON COLUMN CD_CONCLUSION__INSP_TMP_OH.CAMP_OH__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN CD_CONCLUSION__INSP_TMP_OH.DSC_TEMP_OH__NUM_OH IS 'NumOH';
COMMENT ON COLUMN CD_CONCLUSION__INSP_TMP_OH.CD_CONCLUSION_OH__ID_CONC IS 'Identifiant conclusion';
COMMENT ON COLUMN CD_CONCLUSION__INSP_TMP_OH.CONTENU IS 'Contenu';

-- ---------------------------------------------------------
-- Table CONTACT_OH
-- ---------------------------------------------------------
CREATE TABLE CONTACT_OH 
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
COMMENT ON TABLE CONTACT_OH IS 'Contacts';
COMMENT ON COLUMN CONTACT_OH.DOC__ID IS 'Id document';
COMMENT ON COLUMN CONTACT_OH.GIVENNAME IS 'Prénom';
COMMENT ON COLUMN CONTACT_OH.SN IS 'Nom';
COMMENT ON COLUMN CONTACT_OH.CN IS 'Nom complet';
COMMENT ON COLUMN CONTACT_OH.O IS 'Organisation';
COMMENT ON COLUMN CONTACT_OH.MAIL IS 'Email';
COMMENT ON COLUMN CONTACT_OH.TELEPHONENUMBER IS 'Téléphone fixe';
COMMENT ON COLUMN CONTACT_OH.MOBILE IS 'Téléphone mobile';
COMMENT ON COLUMN CONTACT_OH.FACSIMILETELEPHONENUMBER IS 'Fax';
COMMENT ON COLUMN CONTACT_OH.STREET IS 'Adresse';
COMMENT ON COLUMN CONTACT_OH.MOZILLAWORKSTREET2 IS 'Adresse complémentaire';
COMMENT ON COLUMN CONTACT_OH.L IS 'Ville';
COMMENT ON COLUMN CONTACT_OH.POSTALCODE IS 'Code Postal';
COMMENT ON COLUMN CONTACT_OH.MODIFYTIMESTAMP IS 'Date MAJ';

-- ---------------------------------------------------------
-- Table CLS_DOC_OH
-- ---------------------------------------------------------
CREATE TABLE CLS_DOC_OH 
( 
	CLS__ID                                 NUMBER(6) NOT NULL,
	DOC__ID                                 NUMBER(6) NOT NULL,
	DEFAUT                                  NUMBER,
	DOSSIER                                 VARCHAR2(15 CHAR)
);
COMMENT ON TABLE CLS_DOC_OH IS 'Contenu du classeur';
COMMENT ON COLUMN CLS_DOC_OH.CLS__ID IS 'Identifiant du classeur(cpt)';
COMMENT ON COLUMN CLS_DOC_OH.DOC__ID IS 'Id document';
COMMENT ON COLUMN CLS_DOC_OH.DEFAUT IS 'Document par défaut';
COMMENT ON COLUMN CLS_DOC_OH.DOSSIER IS 'Dossier';

-- ---------------------------------------------------------
-- Table CD_CONTRAINTE_OH
-- ---------------------------------------------------------
CREATE TABLE CD_CONTRAINTE_OH 
( 
	TYPE                                    VARCHAR2(100 CHAR) NOT NULL
);
COMMENT ON TABLE CD_CONTRAINTE_OH IS 'Contrainte exploitation';
COMMENT ON COLUMN CD_CONTRAINTE_OH.TYPE IS 'Contrainte exploit';

-- ---------------------------------------------------------
-- Table ELT_INSP_OH
-- ---------------------------------------------------------
CREATE TABLE ELT_INSP_OH 
( 
	GRP_OH__ID_GRP                          NUMBER(7) NOT NULL,
	PRT_OH__ID_PRT                          NUMBER(7) NOT NULL,
	SPRT_OH__ID_SPRT                        NUMBER(7) NOT NULL,
	ELT_OH__ID_ELEM                         NUMBER(7) NOT NULL,
	CAMP_OH__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	DSC_OH__NUM_OH                          VARCHAR2(20 CHAR) NOT NULL,
	INDICE                                  NUMBER(2) NOT NULL,
	OBS                                     VARCHAR2(255 CHAR)
);
COMMENT ON TABLE ELT_INSP_OH IS 'Détail Inspection';
COMMENT ON COLUMN ELT_INSP_OH.GRP_OH__ID_GRP IS 'Identifiant Groupe';
COMMENT ON COLUMN ELT_INSP_OH.PRT_OH__ID_PRT IS 'Identifiant Partie';
COMMENT ON COLUMN ELT_INSP_OH.SPRT_OH__ID_SPRT IS 'Identifiant Sous Partie';
COMMENT ON COLUMN ELT_INSP_OH.ELT_OH__ID_ELEM IS 'Identifiant élément';
COMMENT ON COLUMN ELT_INSP_OH.CAMP_OH__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN ELT_INSP_OH.DSC_OH__NUM_OH IS 'NumOH';
COMMENT ON COLUMN ELT_INSP_OH.INDICE IS 'Indice';
COMMENT ON COLUMN ELT_INSP_OH.OBS IS 'Observations';

-- ---------------------------------------------------------
-- Table ELT_INSP_TMP_OH
-- ---------------------------------------------------------
CREATE TABLE ELT_INSP_TMP_OH 
( 
	CAMP_OH__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	DSC_TEMP_OH__NUM_OH                     VARCHAR2(20 CHAR) NOT NULL,
	GRP_OH__ID_GRP                          NUMBER(7) NOT NULL,
	PRT_OH__ID_PRT                          NUMBER(7) NOT NULL,
	SPRT_OH__ID_SPRT                        NUMBER(7) NOT NULL,
	ELT_OH__ID_ELEM                         NUMBER(7) NOT NULL,
	INDICE                                  NUMBER(2) NOT NULL,
	OBS                                     VARCHAR2(255 CHAR)
);
COMMENT ON TABLE ELT_INSP_TMP_OH IS 'Détail Inspection temporaire';
COMMENT ON COLUMN ELT_INSP_TMP_OH.CAMP_OH__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN ELT_INSP_TMP_OH.DSC_TEMP_OH__NUM_OH IS 'NumOH';
COMMENT ON COLUMN ELT_INSP_TMP_OH.GRP_OH__ID_GRP IS 'Identifiant Groupe';
COMMENT ON COLUMN ELT_INSP_TMP_OH.PRT_OH__ID_PRT IS 'Identifiant Partie';
COMMENT ON COLUMN ELT_INSP_TMP_OH.SPRT_OH__ID_SPRT IS 'Identifiant Sous Partie';
COMMENT ON COLUMN ELT_INSP_TMP_OH.ELT_OH__ID_ELEM IS 'Identifiant élément';
COMMENT ON COLUMN ELT_INSP_TMP_OH.INDICE IS 'Indice';
COMMENT ON COLUMN ELT_INSP_TMP_OH.OBS IS 'Observations';

-- ---------------------------------------------------------
-- Table SPRT_VST_OH
-- ---------------------------------------------------------
CREATE TABLE SPRT_VST_OH 
( 
	CAMP_OH__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	DSC_OH__NUM_OH                          VARCHAR2(20 CHAR) NOT NULL,
	CD_CHAPITRE_OH__ID_CHAP                 NUMBER(7) NOT NULL,
	CD_LIGNE_OH__ID_LIGNE                   NUMBER(7) NOT NULL,
	INDICE                                  NUMBER(7) NOT NULL,
	OBS                                     VARCHAR2(500 CHAR)
);
COMMENT ON TABLE SPRT_VST_OH IS 'Détail visite';
COMMENT ON COLUMN SPRT_VST_OH.CAMP_OH__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN SPRT_VST_OH.DSC_OH__NUM_OH IS 'NumOH';
COMMENT ON COLUMN SPRT_VST_OH.CD_CHAPITRE_OH__ID_CHAP IS 'Identifiant chapitre';
COMMENT ON COLUMN SPRT_VST_OH.CD_LIGNE_OH__ID_LIGNE IS 'Identifiant ligne';
COMMENT ON COLUMN SPRT_VST_OH.INDICE IS 'Indice';
COMMENT ON COLUMN SPRT_VST_OH.OBS IS 'Observation';

-- ---------------------------------------------------------
-- Table DICTIONNAIRE_OH
-- ---------------------------------------------------------
CREATE TABLE DICTIONNAIRE_OH 
( 
	NOM                                     VARCHAR2(100 CHAR) NOT NULL,
	DESCRIPTION                             VARCHAR2(255 CHAR),
	DEFINITION                              VARCHAR2(500 CHAR),
	MOTSCLES                                VARCHAR2(255 CHAR)
);
COMMENT ON TABLE DICTIONNAIRE_OH IS 'Dictionnaire';
COMMENT ON COLUMN DICTIONNAIRE_OH.NOM IS 'Nom';
COMMENT ON COLUMN DICTIONNAIRE_OH.DESCRIPTION IS 'Description';
COMMENT ON COLUMN DICTIONNAIRE_OH.DEFINITION IS 'Définition';
COMMENT ON COLUMN DICTIONNAIRE_OH.MOTSCLES IS 'Mots clés';

-- ---------------------------------------------------------
-- Table DOC_OH
-- ---------------------------------------------------------
CREATE TABLE DOC_OH 
( 
	ID                                      NUMBER(6,0) NOT NULL,
	CD_DOC__CODE                            VARCHAR2(15 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(100 CHAR),
	REF                                     VARCHAR2(50 CHAR) NOT NULL
);
COMMENT ON TABLE DOC_OH IS 'Documents';
COMMENT ON COLUMN DOC_OH.ID IS 'Id document';
COMMENT ON COLUMN DOC_OH.CD_DOC__CODE IS 'Code';
COMMENT ON COLUMN DOC_OH.LIBELLE IS 'Libellé';
COMMENT ON COLUMN DOC_OH.REF IS 'Réference (fichier)';

-- ---------------------------------------------------------
-- Table CD_EAU_OH
-- ---------------------------------------------------------
CREATE TABLE CD_EAU_OH 
( 
	EAU                                     VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_EAU_OH IS 'Eaux collectées';
COMMENT ON COLUMN CD_EAU_OH.EAU IS 'Eaux collectées';

-- ---------------------------------------------------------
-- Table CD_ECOUL_OH
-- ---------------------------------------------------------
CREATE TABLE CD_ECOUL_OH 
( 
	ECOUL                                   VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_ECOUL_OH IS 'Ecoulement';
COMMENT ON COLUMN CD_ECOUL_OH.ECOUL IS 'Ecoulement';

-- ---------------------------------------------------------
-- Table ELT_OH
-- ---------------------------------------------------------
CREATE TABLE ELT_OH 
( 
	GRP_OH__ID_GRP                          NUMBER(7) NOT NULL,
	PRT_OH__ID_PRT                          NUMBER(7) NOT NULL,
	SPRT_OH__ID_SPRT                        NUMBER(7) NOT NULL,
	ID_ELEM                                 NUMBER(7) NOT NULL,
	LIBE                                    VARCHAR2(500 CHAR) NOT NULL,
	ORDRE                                   NUMBER(7) NOT NULL,
	AIDE                                    VARCHAR2(500 CHAR),
	INDICE1                                 VARCHAR2(500 CHAR),
	INDICE2                                 VARCHAR2(500 CHAR),
	INDICE3                                 VARCHAR2(500 CHAR)
);
COMMENT ON TABLE ELT_OH IS 'Elément';
COMMENT ON COLUMN ELT_OH.GRP_OH__ID_GRP IS 'Identifiant Groupe';
COMMENT ON COLUMN ELT_OH.PRT_OH__ID_PRT IS 'Identifiant Partie';
COMMENT ON COLUMN ELT_OH.SPRT_OH__ID_SPRT IS 'Identifiant Sous Partie';
COMMENT ON COLUMN ELT_OH.ID_ELEM IS 'Identifiant élément';
COMMENT ON COLUMN ELT_OH.LIBE IS 'Elément';
COMMENT ON COLUMN ELT_OH.ORDRE IS 'N° Ordre';
COMMENT ON COLUMN ELT_OH.AIDE IS 'Aide à la saisie';
COMMENT ON COLUMN ELT_OH.INDICE1 IS 'Indice1';
COMMENT ON COLUMN ELT_OH.INDICE2 IS 'Indice2';
COMMENT ON COLUMN ELT_OH.INDICE3 IS 'Indice3';

-- ---------------------------------------------------------
-- Table CD_ENTETE_OH
-- ---------------------------------------------------------
CREATE TABLE CD_ENTETE_OH 
( 
	ID_ENTETE                               NUMBER(7) NOT NULL,
	CD_COMPOSANT_OH__TYPE_COMP              VARCHAR2(6 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(500 CHAR) NOT NULL,
	ORDRE_ENT                               NUMBER(7) NOT NULL,
	GUIDE                                   VARCHAR2(500 CHAR)
);
COMMENT ON TABLE CD_ENTETE_OH IS 'Entête';
COMMENT ON COLUMN CD_ENTETE_OH.ID_ENTETE IS 'Identifiant Entête';
COMMENT ON COLUMN CD_ENTETE_OH.CD_COMPOSANT_OH__TYPE_COMP IS 'Type';
COMMENT ON COLUMN CD_ENTETE_OH.LIBELLE IS 'Libellé Entête';
COMMENT ON COLUMN CD_ENTETE_OH.ORDRE_ENT IS 'N° ordre Entête';
COMMENT ON COLUMN CD_ENTETE_OH.GUIDE IS 'Guide';

-- ---------------------------------------------------------
-- Table CD_ENTP_OH
-- ---------------------------------------------------------
CREATE TABLE CD_ENTP_OH 
( 
	ENTREPRISE                              VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_ENTP_OH IS 'Entreprise';
COMMENT ON COLUMN CD_ENTP_OH.ENTREPRISE IS 'Entreprise';

-- ---------------------------------------------------------
-- Table CD_ETUDE_OH
-- ---------------------------------------------------------
CREATE TABLE CD_ETUDE_OH 
( 
	ETUDE                                   VARCHAR2(65 CHAR) NOT NULL
);
COMMENT ON TABLE CD_ETUDE_OH IS 'Etude et Expertise';
COMMENT ON COLUMN CD_ETUDE_OH.ETUDE IS 'Etude-Expertise';

-- ---------------------------------------------------------
-- Table EVT_OH
-- ---------------------------------------------------------
CREATE TABLE EVT_OH 
( 
	CD_EVT_OH__TYPE                         VARCHAR2(25 CHAR) NOT NULL,
	DSC_OH__NUM_OH                          VARCHAR2(20 CHAR) NOT NULL,
	DATE_REL                                DATE NOT NULL,
	DATE_TRT                                DATE,
	OBSV                                    VARCHAR2(255 CHAR)
);
COMMENT ON TABLE EVT_OH IS 'Evénement';
COMMENT ON COLUMN EVT_OH.CD_EVT_OH__TYPE IS 'Type événement';
COMMENT ON COLUMN EVT_OH.DSC_OH__NUM_OH IS 'NumOH';
COMMENT ON COLUMN EVT_OH.DATE_REL IS 'Date Relevé';
COMMENT ON COLUMN EVT_OH.DATE_TRT IS 'Date Traitement';
COMMENT ON COLUMN EVT_OH.OBSV IS 'Observation';

-- ---------------------------------------------------------
-- Table CD_FAM_OH
-- ---------------------------------------------------------
CREATE TABLE CD_FAM_OH 
( 
	FAMILLE                                 VARCHAR2(20 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(60 CHAR)
);
COMMENT ON TABLE CD_FAM_OH IS 'Famille';
COMMENT ON COLUMN CD_FAM_OH.FAMILLE IS 'Famille';
COMMENT ON COLUMN CD_FAM_OH.LIBELLE IS 'Libellé';

-- ---------------------------------------------------------
-- Table GRP_OH
-- ---------------------------------------------------------
CREATE TABLE GRP_OH 
( 
	ID_GRP                                  NUMBER(7) NOT NULL,
	LIBG                                    VARCHAR2(500 CHAR) NOT NULL,
	ORDRE                                   NUMBER(7) NOT NULL
);
COMMENT ON TABLE GRP_OH IS 'Groupe';
COMMENT ON COLUMN GRP_OH.ID_GRP IS 'Identifiant Groupe';
COMMENT ON COLUMN GRP_OH.LIBG IS 'Groupe';
COMMENT ON COLUMN GRP_OH.ORDRE IS 'N° Ordre';

-- ---------------------------------------------------------
-- Table HISTO_NOTE_OH
-- ---------------------------------------------------------
CREATE TABLE HISTO_NOTE_OH 
( 
	DSC_OH__NUM_OH                          VARCHAR2(20 CHAR) NOT NULL,
	DATE_NOTE                               DATE NOT NULL,
	CD_ORIGIN_OH__ORIGINE                   VARCHAR2(20 CHAR) NOT NULL,
	NOTE1                                   NUMBER(1),
	NOTE2                                   NUMBER(1),
	NOTE3                                   NUMBER(1),
	NOTE4                                   NUMBER(1),
	NOTE5                                   NUMBER(1),
	URGENCE                                 VARCHAR2(5 CHAR),
	SECURITE                                NUMBER,
	PRIORITAIRE                             NUMBER
);
COMMENT ON TABLE HISTO_NOTE_OH IS 'Historique note';
COMMENT ON COLUMN HISTO_NOTE_OH.DSC_OH__NUM_OH IS 'NumOH';
COMMENT ON COLUMN HISTO_NOTE_OH.DATE_NOTE IS 'Date Note';
COMMENT ON COLUMN HISTO_NOTE_OH.CD_ORIGIN_OH__ORIGINE IS 'Origine Note';
COMMENT ON COLUMN HISTO_NOTE_OH.NOTE1 IS 'Note Abords Amont';
COMMENT ON COLUMN HISTO_NOTE_OH.NOTE2 IS 'Note Protection Amont';
COMMENT ON COLUMN HISTO_NOTE_OH.NOTE3 IS 'Note Conduit';
COMMENT ON COLUMN HISTO_NOTE_OH.NOTE4 IS 'Note Protection Aval';
COMMENT ON COLUMN HISTO_NOTE_OH.NOTE5 IS 'Note Abords Aval';
COMMENT ON COLUMN HISTO_NOTE_OH.URGENCE IS 'Niveau Urgence';
COMMENT ON COLUMN HISTO_NOTE_OH.SECURITE IS 'Problème de sécurité';
COMMENT ON COLUMN HISTO_NOTE_OH.PRIORITAIRE IS 'Urgence traitement';

-- ---------------------------------------------------------
-- Table DSC_CAMP_OH
-- ---------------------------------------------------------
CREATE TABLE DSC_CAMP_OH 
( 
	DSC_OH__NUM_OH                          VARCHAR2(20 CHAR) NOT NULL,
	CAMP_OH__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	REALISER                                NUMBER
);
COMMENT ON TABLE DSC_CAMP_OH IS 'Historique Surveillances';
COMMENT ON COLUMN DSC_CAMP_OH.DSC_OH__NUM_OH IS 'NumOH';
COMMENT ON COLUMN DSC_CAMP_OH.CAMP_OH__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN DSC_CAMP_OH.REALISER IS 'Contrôle Réalisé';

-- ---------------------------------------------------------
-- Table INSPECTEUR_OH
-- ---------------------------------------------------------
CREATE TABLE INSPECTEUR_OH 
( 
	NOM                                     VARCHAR2(60 CHAR) NOT NULL,
	CD_PRESTA_OH__PRESTATAIRE               VARCHAR2(50 CHAR) NOT NULL,
	FONC                                    VARCHAR2(60 CHAR)
);
COMMENT ON TABLE INSPECTEUR_OH IS 'Inspecteur';
COMMENT ON COLUMN INSPECTEUR_OH.NOM IS 'Nom inspecteur';
COMMENT ON COLUMN INSPECTEUR_OH.CD_PRESTA_OH__PRESTATAIRE IS 'Prestataire';
COMMENT ON COLUMN INSPECTEUR_OH.FONC IS 'Fonction';

-- ---------------------------------------------------------
-- Table INSP_OH
-- ---------------------------------------------------------
CREATE TABLE INSP_OH 
( 
	CAMP_OH__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	DSC_OH__NUM_OH                          VARCHAR2(20 CHAR) NOT NULL,
	CD_METEO_OH__METEO                      VARCHAR2(60 CHAR),
	INSPECTEUR_OH__NOM                      VARCHAR2(60 CHAR),
	CD_ETUDE_OH__ETUDE                      VARCHAR2(65 CHAR),
	ETAT                                    VARCHAR2(25 CHAR) NOT NULL,
	DATEV                                   DATE,
	TEMPERATURE                             NUMBER(4,2),
	MOYEN                                   VARCHAR2(500 CHAR),
	CONDITIONS                              VARCHAR2(500 CHAR),
	NOM_VALID                               VARCHAR2(250 CHAR),
	DATE_VALID                              DATE,
	DESC_INVA                               VARCHAR2(1000 CHAR),
	PRIORITAIRE                             VARCHAR2(1000 CHAR),
	SECURITE                                VARCHAR2(1000 CHAR),
	NOTE1                                   NUMBER(1),
	NOTE2                                   NUMBER(1),
	NOTE3                                   NUMBER(1),
	NOTE4                                   NUMBER(1),
	NOTE5                                   NUMBER(1),
	URGENCE                                 VARCHAR2(5 CHAR),
	QUALITE                                 VARCHAR2(25 CHAR)
);
COMMENT ON TABLE INSP_OH IS 'Inspection';
COMMENT ON COLUMN INSP_OH.CAMP_OH__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN INSP_OH.DSC_OH__NUM_OH IS 'NumOH';
COMMENT ON COLUMN INSP_OH.CD_METEO_OH__METEO IS 'Météo';
COMMENT ON COLUMN INSP_OH.INSPECTEUR_OH__NOM IS 'Nom inspecteur';
COMMENT ON COLUMN INSP_OH.CD_ETUDE_OH__ETUDE IS 'Etude-Expertise';
COMMENT ON COLUMN INSP_OH.ETAT IS 'Statut visite';
COMMENT ON COLUMN INSP_OH.DATEV IS 'Date de visite';
COMMENT ON COLUMN INSP_OH.TEMPERATURE IS 'Température';
COMMENT ON COLUMN INSP_OH.MOYEN IS 'Moyen utilisé';
COMMENT ON COLUMN INSP_OH.CONDITIONS IS 'Condition particulière';
COMMENT ON COLUMN INSP_OH.NOM_VALID IS 'Nom Valideur';
COMMENT ON COLUMN INSP_OH.DATE_VALID IS 'Date Validation';
COMMENT ON COLUMN INSP_OH.DESC_INVA IS 'Description invalide';
COMMENT ON COLUMN INSP_OH.PRIORITAIRE IS 'Urgence traitement';
COMMENT ON COLUMN INSP_OH.SECURITE IS 'Problème de sécurité';
COMMENT ON COLUMN INSP_OH.NOTE1 IS 'Abords amont';
COMMENT ON COLUMN INSP_OH.NOTE2 IS 'Protection amont';
COMMENT ON COLUMN INSP_OH.NOTE3 IS 'Conduit';
COMMENT ON COLUMN INSP_OH.NOTE4 IS 'Protection aval';
COMMENT ON COLUMN INSP_OH.NOTE5 IS 'Abordst aval';
COMMENT ON COLUMN INSP_OH.URGENCE IS 'Niveau urgence';
COMMENT ON COLUMN INSP_OH.QUALITE IS 'Image qualité';

-- ---------------------------------------------------------
-- Table INSP_TMP_OH
-- ---------------------------------------------------------
CREATE TABLE INSP_TMP_OH 
( 
	CAMP_OH__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	DSC_TEMP_OH__NUM_OH                     VARCHAR2(20 CHAR) NOT NULL,
	INSPECTEUR_OH__NOM                      VARCHAR2(60 CHAR),
	CD_ETUDE_OH__ETUDE                      VARCHAR2(65 CHAR),
	CD_METEO_OH__METEO                      VARCHAR2(60 CHAR),
	ETAT                                    VARCHAR2(25 CHAR) NOT NULL,
	DATEV                                   DATE,
	TEMPERATURE                             NUMBER(4,2),
	MOYEN                                   VARCHAR2(500 CHAR),
	CONDITIONS                              VARCHAR2(500 CHAR),
	NOM_VALID                               VARCHAR2(250 CHAR),
	DATE_VALID                              DATE,
	DESC_INVA                               VARCHAR2(1000 CHAR),
	PRIORITAIRE                             VARCHAR2(1000 CHAR),
	SECURITE                                VARCHAR2(1000 CHAR),
	NOTE1                                   NUMBER(1),
	NOTE2                                   NUMBER(1),
	NOTE3                                   NUMBER(1),
	NOTE4                                   NUMBER(1),
	NOTE5                                   NUMBER(1),
	URGENCE                                 VARCHAR2(5 CHAR),
	QUALITE                                 VARCHAR2(25 CHAR)
);
COMMENT ON TABLE INSP_TMP_OH IS 'Inspection temporaire';
COMMENT ON COLUMN INSP_TMP_OH.CAMP_OH__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN INSP_TMP_OH.DSC_TEMP_OH__NUM_OH IS 'NumOH';
COMMENT ON COLUMN INSP_TMP_OH.INSPECTEUR_OH__NOM IS 'Nom inspecteur';
COMMENT ON COLUMN INSP_TMP_OH.CD_ETUDE_OH__ETUDE IS 'Etude-Expertise';
COMMENT ON COLUMN INSP_TMP_OH.CD_METEO_OH__METEO IS 'Météo';
COMMENT ON COLUMN INSP_TMP_OH.ETAT IS 'Statut visite';
COMMENT ON COLUMN INSP_TMP_OH.DATEV IS 'Date de visite';
COMMENT ON COLUMN INSP_TMP_OH.TEMPERATURE IS 'Température';
COMMENT ON COLUMN INSP_TMP_OH.MOYEN IS 'Moyen utilisé';
COMMENT ON COLUMN INSP_TMP_OH.CONDITIONS IS 'Condition particulière';
COMMENT ON COLUMN INSP_TMP_OH.NOM_VALID IS 'Nom Valideur';
COMMENT ON COLUMN INSP_TMP_OH.DATE_VALID IS 'Date Validation';
COMMENT ON COLUMN INSP_TMP_OH.DESC_INVA IS 'Description invalide';
COMMENT ON COLUMN INSP_TMP_OH.PRIORITAIRE IS 'Urgence traitement';
COMMENT ON COLUMN INSP_TMP_OH.SECURITE IS 'Problème de sécurité';
COMMENT ON COLUMN INSP_TMP_OH.NOTE1 IS 'Abords amont';
COMMENT ON COLUMN INSP_TMP_OH.NOTE2 IS 'Protection amont';
COMMENT ON COLUMN INSP_TMP_OH.NOTE3 IS 'Conduit';
COMMENT ON COLUMN INSP_TMP_OH.NOTE4 IS 'Protection aval';
COMMENT ON COLUMN INSP_TMP_OH.NOTE5 IS 'Abordst aval';
COMMENT ON COLUMN INSP_TMP_OH.URGENCE IS 'Niveau urgence';
COMMENT ON COLUMN INSP_TMP_OH.QUALITE IS 'Image qualité';

-- ---------------------------------------------------------
-- Table CD_LIGNE_OH
-- ---------------------------------------------------------
CREATE TABLE CD_LIGNE_OH 
( 
	CD_CHAPITRE_OH__ID_CHAP                 NUMBER(7) NOT NULL,
	ID_LIGNE                                NUMBER(7) NOT NULL,
	LIBELLE                                 VARCHAR2(500 CHAR) NOT NULL,
	ORDRE_LIGNE                             NUMBER(7) NOT NULL
);
COMMENT ON TABLE CD_LIGNE_OH IS 'Ligne';
COMMENT ON COLUMN CD_LIGNE_OH.CD_CHAPITRE_OH__ID_CHAP IS 'Identifiant chapitre';
COMMENT ON COLUMN CD_LIGNE_OH.ID_LIGNE IS 'Identifiant ligne';
COMMENT ON COLUMN CD_LIGNE_OH.LIBELLE IS 'Libellé Ligne';
COMMENT ON COLUMN CD_LIGNE_OH.ORDRE_LIGNE IS 'N° ordre ligne';

-- ---------------------------------------------------------
-- Table CD_MO_OH
-- ---------------------------------------------------------
CREATE TABLE CD_MO_OH 
( 
	MO                                      VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_MO_OH IS 'Maitre d''ouvrage';
COMMENT ON COLUMN CD_MO_OH.MO IS 'Maitre d''ouvrage';

-- ---------------------------------------------------------
-- Table CD_MAT_OH
-- ---------------------------------------------------------
CREATE TABLE CD_MAT_OH 
( 
	CODE                                    VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_MAT_OH IS 'Matériaux';
COMMENT ON COLUMN CD_MAT_OH.CODE IS 'Matériaux';

-- ---------------------------------------------------------
-- Table CD_METEO_OH
-- ---------------------------------------------------------
CREATE TABLE CD_METEO_OH 
( 
	METEO                                   VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_METEO_OH IS 'Météo';
COMMENT ON COLUMN CD_METEO_OH.METEO IS 'Météo';

-- ---------------------------------------------------------
-- Table NATURE_TRAV_OH
-- ---------------------------------------------------------
CREATE TABLE NATURE_TRAV_OH 
( 
	CD_TRAVAUX_OH__CODE                     VARCHAR2(60 CHAR) NOT NULL,
	NATURE                                  VARCHAR2(100 CHAR) NOT NULL
);
COMMENT ON TABLE NATURE_TRAV_OH IS 'Nature travaux';
COMMENT ON COLUMN NATURE_TRAV_OH.CD_TRAVAUX_OH__CODE IS 'Type travaux';
COMMENT ON COLUMN NATURE_TRAV_OH.NATURE IS 'Nature travaux';

-- ---------------------------------------------------------
-- Table CD_NOM_EAU_OH
-- ---------------------------------------------------------
CREATE TABLE CD_NOM_EAU_OH 
( 
	NOM                                     VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_NOM_EAU_OH IS 'Nom du cours d''eau';
COMMENT ON COLUMN CD_NOM_EAU_OH.NOM IS 'Nom cours d''eau';

-- ---------------------------------------------------------
-- Table CD_ORIGIN_OH
-- ---------------------------------------------------------
CREATE TABLE CD_ORIGIN_OH 
( 
	ORIGINE                                 VARCHAR2(20 CHAR) NOT NULL
);
COMMENT ON TABLE CD_ORIGIN_OH IS 'Origine Note';
COMMENT ON COLUMN CD_ORIGIN_OH.ORIGINE IS 'Origine Note';

-- ---------------------------------------------------------
-- Table DSC_OH
-- ---------------------------------------------------------
CREATE TABLE DSC_OH 
( 
	LIAISON                                 VARCHAR2(15 CHAR) NOT NULL,
	SENS                                    VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	ABS_FIN                                 NUMBER(6),
	NUM_OH                                  VARCHAR2(20 CHAR) NOT NULL,
	CD_FAM_OH__FAMILLE                      VARCHAR2(20 CHAR) NOT NULL,
	CD_TYPE_OH__TYPE                        VARCHAR2(60 CHAR) NOT NULL,
	CD_SOUS_TYPE_OH__SOUS_TYPE              VARCHAR2(60 CHAR),
	CD_OUV_OH__OUV                          VARCHAR2(60 CHAR),
	CD_MAT_OH__CODE                         VARCHAR2(60 CHAR),
	CD_ENTP_OH__ENTREPRISE                  VARCHAR2(60 CHAR),
	CD_ECOUL_OH__ECOUL                      VARCHAR2(60 CHAR),
	CD_EXT_OH__TYPE                         VARCHAR2(60 CHAR),
	CD_EAU_OH__EAU                          VARCHAR2(60 CHAR),
	CD_TETE_AM_OH__TETE_AM                  VARCHAR2(60 CHAR),
	CD_TETE_AV_OH__TETE_AV                  VARCHAR2(60 CHAR),
	CD_PRO_AM_OH__PROTECT                   VARCHAR2(60 CHAR),
	CD_PRO_AV_OH__PROTECT                   VARCHAR2(60 CHAR),
	NUM_EXPLOIT                             VARCHAR2(30 CHAR),
	DATE_MS                                 DATE,
	LONGUEUR                                NUMBER(7,2),
	HAUTEUR                                 NUMBER(4),
	BIAIS                                   NUMBER(3),
	PENTE                                   NUMBER(4,2),
	PORTEE                                  NUMBER(4),
	JUM                                     NUMBER(2),
	ELEM                                    NUMBER(2),
	REGARD                                  NUMBER(2),
	PERCHE                                  NUMBER,
	CD_NOM_EAU_OH__NOM                      VARCHAR2(60 CHAR),
	PHE                                     NUMBER(4),
	DEBIT                                   NUMBER(3),
	NOTE1                                   NUMBER(1),
	NOTE2                                   NUMBER(1),
	NOTE3                                   NUMBER(1),
	NOTE4                                   NUMBER(1),
	NOTE5                                   NUMBER(1),
	URGENCE                                 VARCHAR2(5 CHAR),
	CD_QUALITE_OH__QUALITE                  VARCHAR2(25 CHAR),
	DESC_INVA                               VARCHAR2(1000 CHAR),
	PRIORITAIRE                             NUMBER,
	PROSURV_ANNEE                           NUMBER(4),
	DERN_INSP                               DATE,
	ARCHIVE                                 VARCHAR2(255 CHAR),
	COMMENTAIRE                             VARCHAR2(1000 CHAR),
	VULNERABLE                              NUMBER,
	LOI                                     NUMBER,
	FAUNE                                   NUMBER,
	DERN_VST                                DATE,
	NOTE_VST                                VARCHAR2(5 CHAR),
	CD_MO_OH__MO                            VARCHAR2(60 CHAR),
	OUV_AVAL                                VARCHAR2(200 CHAR),
	SECURITE                                NUMBER,
	X1                                      NUMBER(22,11),
	Y1                                      NUMBER(22,11),
	Z1                                      NUMBER(22,11),
	X2                                      NUMBER(22,11),
	Y2                                      NUMBER(22,11),
	Z2                                      NUMBER(22,11),
	DATE_RELEVE                             DATE,
	TERRAIN                                 NUMBER
);
COMMENT ON TABLE DSC_OH IS 'Ouvrage Hydraulique';
COMMENT ON COLUMN DSC_OH.LIAISON IS 'Liaison';
COMMENT ON COLUMN DSC_OH.SENS IS 'Sens';
COMMENT ON COLUMN DSC_OH.ABS_DEB IS 'PR';
COMMENT ON COLUMN DSC_OH.ABS_FIN IS 'Pr fin';
COMMENT ON COLUMN DSC_OH.NUM_OH IS 'NumOH';
COMMENT ON COLUMN DSC_OH.CD_FAM_OH__FAMILLE IS 'Famille';
COMMENT ON COLUMN DSC_OH.CD_TYPE_OH__TYPE IS 'Type OH';
COMMENT ON COLUMN DSC_OH.CD_SOUS_TYPE_OH__SOUS_TYPE IS 'Sous type OH';
COMMENT ON COLUMN DSC_OH.CD_OUV_OH__OUV IS 'Profil';
COMMENT ON COLUMN DSC_OH.CD_MAT_OH__CODE IS 'Matériaux';
COMMENT ON COLUMN DSC_OH.CD_ENTP_OH__ENTREPRISE IS 'Entreprise';
COMMENT ON COLUMN DSC_OH.CD_ECOUL_OH__ECOUL IS 'Ecoulement';
COMMENT ON COLUMN DSC_OH.CD_EXT_OH__TYPE IS 'Type exutoire';
COMMENT ON COLUMN DSC_OH.CD_EAU_OH__EAU IS 'Eaux collectées';
COMMENT ON COLUMN DSC_OH.CD_TETE_AM_OH__TETE_AM IS 'Tête amont';
COMMENT ON COLUMN DSC_OH.CD_TETE_AV_OH__TETE_AV IS 'Tête aval';
COMMENT ON COLUMN DSC_OH.CD_PRO_AM_OH__PROTECT IS 'Protection Amont';
COMMENT ON COLUMN DSC_OH.CD_PRO_AV_OH__PROTECT IS 'Protection Aval';
COMMENT ON COLUMN DSC_OH.NUM_EXPLOIT IS 'N° d''exploitation';
COMMENT ON COLUMN DSC_OH.DATE_MS IS 'Date MS';
COMMENT ON COLUMN DSC_OH.LONGUEUR IS 'Longueur (m)';
COMMENT ON COLUMN DSC_OH.HAUTEUR IS 'Hauteur (mm)';
COMMENT ON COLUMN DSC_OH.BIAIS IS 'Biais (degré)';
COMMENT ON COLUMN DSC_OH.PENTE IS 'Pente (%)';
COMMENT ON COLUMN DSC_OH.PORTEE IS 'Portée - Ø (mm)';
COMMENT ON COLUMN DSC_OH.JUM IS 'Jumellé';
COMMENT ON COLUMN DSC_OH.ELEM IS 'Nbre élément';
COMMENT ON COLUMN DSC_OH.REGARD IS 'Nbre regard';
COMMENT ON COLUMN DSC_OH.PERCHE IS 'Ouvrage Perché';
COMMENT ON COLUMN DSC_OH.CD_NOM_EAU_OH__NOM IS 'Nom cours d''eau';
COMMENT ON COLUMN DSC_OH.PHE IS 'Niveau PHE (mm)';
COMMENT ON COLUMN DSC_OH.DEBIT IS 'Débit-projet';
COMMENT ON COLUMN DSC_OH.NOTE1 IS 'Note Abords Amont';
COMMENT ON COLUMN DSC_OH.NOTE2 IS 'Note Protection Amont';
COMMENT ON COLUMN DSC_OH.NOTE3 IS 'Note Conduit';
COMMENT ON COLUMN DSC_OH.NOTE4 IS 'Note Protection Aval';
COMMENT ON COLUMN DSC_OH.NOTE5 IS 'Note Abord Aval';
COMMENT ON COLUMN DSC_OH.URGENCE IS 'Niveau Urgence';
COMMENT ON COLUMN DSC_OH.CD_QUALITE_OH__QUALITE IS 'Niveau qualité';
COMMENT ON COLUMN DSC_OH.DESC_INVA IS 'Description invalide';
COMMENT ON COLUMN DSC_OH.PRIORITAIRE IS 'Urgence traitement';
COMMENT ON COLUMN DSC_OH.PROSURV_ANNEE IS 'Prochaine Inspection';
COMMENT ON COLUMN DSC_OH.DERN_INSP IS 'Dernière Inspection';
COMMENT ON COLUMN DSC_OH.ARCHIVE IS 'Archive';
COMMENT ON COLUMN DSC_OH.COMMENTAIRE IS 'Commentaire';
COMMENT ON COLUMN DSC_OH.VULNERABLE IS 'Vulnérabilité';
COMMENT ON COLUMN DSC_OH.LOI IS 'Loi sur l''eau';
COMMENT ON COLUMN DSC_OH.FAUNE IS 'Aménagement petite faune';
COMMENT ON COLUMN DSC_OH.DERN_VST IS 'Dernière Visite';
COMMENT ON COLUMN DSC_OH.NOTE_VST IS 'Note Visite';
COMMENT ON COLUMN DSC_OH.CD_MO_OH__MO IS 'Maitre d''ouvrage';
COMMENT ON COLUMN DSC_OH.OUV_AVAL IS 'Connexion Aval';
COMMENT ON COLUMN DSC_OH.SECURITE IS 'Problème de sécurité';
COMMENT ON COLUMN DSC_OH.X1 IS 'X1';
COMMENT ON COLUMN DSC_OH.Y1 IS 'Y1';
COMMENT ON COLUMN DSC_OH.Z1 IS 'Z1';
COMMENT ON COLUMN DSC_OH.X2 IS 'X2';
COMMENT ON COLUMN DSC_OH.Y2 IS 'Y2';
COMMENT ON COLUMN DSC_OH.Z2 IS 'Z2';
COMMENT ON COLUMN DSC_OH.DATE_RELEVE IS 'Date relevé';
COMMENT ON COLUMN DSC_OH.TERRAIN IS 'Terrain';

-- ---------------------------------------------------------
-- Table DSC_TEMP_OH
-- ---------------------------------------------------------
CREATE TABLE DSC_TEMP_OH 
( 
	CAMP_OH__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	NUM_OH                                  VARCHAR2(20 CHAR) NOT NULL,
	CD_PRO_AM_OH__PROTECT                   VARCHAR2(60 CHAR),
	CD_OUV_OH__OUV                          VARCHAR2(60 CHAR),
	CD_EXT_OH__TYPE                         VARCHAR2(60 CHAR),
	DSC_OH__NUM_OH                          VARCHAR2(20 CHAR),
	CD_TETE_AM_OH__TETE_AM                  VARCHAR2(60 CHAR),
	CD_NOM_EAU_OH__NOM                      VARCHAR2(60 CHAR),
	CD_TYPE_OH__TYPE                        VARCHAR2(60 CHAR) NOT NULL,
	CD_EAU_OH__EAU                          VARCHAR2(60 CHAR),
	CD_ECOUL_OH__ECOUL                      VARCHAR2(60 CHAR),
	CD_MAT_OH__CODE                         VARCHAR2(60 CHAR),
	CD_TETE_AV_OH__TETE_AV                  VARCHAR2(60 CHAR),
	CD_MO_OH__MO                            VARCHAR2(60 CHAR),
	CD_ENTP_OH__ENTREPRISE                  VARCHAR2(60 CHAR),
	CD_FAM_OH__FAMILLE                      VARCHAR2(20 CHAR) NOT NULL,
	CD_PRO_AV_OH__PROTECT                   VARCHAR2(60 CHAR),
	CD_SOUS_TYPE_OH__SOUS_TYPE              VARCHAR2(60 CHAR),
	LIAISON                                 VARCHAR2(15 CHAR) NOT NULL,
	SENS                                    VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	ABS_FIN                                 NUMBER(6),
	NUM_EXPLOIT                             VARCHAR2(30 CHAR),
	DATE_MS                                 DATE,
	LONGUEUR                                NUMBER(7,2),
	HAUTEUR                                 NUMBER(4),
	BIAIS                                   NUMBER(3),
	PENTE                                   NUMBER(4,2),
	PORTEE                                  NUMBER(4),
	JUM                                     NUMBER(2),
	ELEM                                    NUMBER(2),
	REGARD                                  NUMBER(2),
	PERCHE                                  NUMBER,
	VULNERABLE                              NUMBER,
	FAUNE                                   NUMBER,
	LOI                                     NUMBER,
	PHE                                     NUMBER(4),
	DEBIT                                   NUMBER(3),
	OUV_AVAL                                VARCHAR2(200 CHAR),
	NOTE1                                   NUMBER(1),
	NOTE2                                   NUMBER(1),
	NOTE3                                   NUMBER(1),
	NOTE4                                   NUMBER(1),
	NOTE5                                   NUMBER(1),
	URGENCE                                 VARCHAR2(5 CHAR),
	DESC_INVA                               VARCHAR2(1000 CHAR),
	SECURITE                                NUMBER,
	PRIORITAIRE                             NUMBER,
	PROSURV_ANNEE                           NUMBER(4),
	DERN_INSP                               DATE,
	DERN_VST                                DATE,
	NOTE_VST                                VARCHAR2(5 CHAR),
	ARCHIVE                                 VARCHAR2(255 CHAR),
	COMMENTAIRE                             VARCHAR2(1000 CHAR),
	X1                                      NUMBER(22,11),
	Y1                                      NUMBER(22,11),
	Z1                                      NUMBER(22,11),
	X2                                      NUMBER(22,11),
	Y2                                      NUMBER(22,11),
	Z2                                      NUMBER(22,11),
	DATE_RELEVE                             DATE,
	TERRAIN                                 NUMBER
);
COMMENT ON TABLE DSC_TEMP_OH IS 'Ouvrage Hydraulique temporaire';
COMMENT ON COLUMN DSC_TEMP_OH.CAMP_OH__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN DSC_TEMP_OH.NUM_OH IS 'NumOH';
COMMENT ON COLUMN DSC_TEMP_OH.CD_PRO_AM_OH__PROTECT IS 'Protection Amont';
COMMENT ON COLUMN DSC_TEMP_OH.CD_OUV_OH__OUV IS 'Profil';
COMMENT ON COLUMN DSC_TEMP_OH.CD_EXT_OH__TYPE IS 'Type exutoire';
COMMENT ON COLUMN DSC_TEMP_OH.DSC_OH__NUM_OH IS 'NumOH2';
COMMENT ON COLUMN DSC_TEMP_OH.CD_TETE_AM_OH__TETE_AM IS 'Tête amont';
COMMENT ON COLUMN DSC_TEMP_OH.CD_NOM_EAU_OH__NOM IS 'Nom cours d''eau';
COMMENT ON COLUMN DSC_TEMP_OH.CD_TYPE_OH__TYPE IS 'Type OH';
COMMENT ON COLUMN DSC_TEMP_OH.CD_EAU_OH__EAU IS 'Eaux collectées';
COMMENT ON COLUMN DSC_TEMP_OH.CD_ECOUL_OH__ECOUL IS 'Ecoulement';
COMMENT ON COLUMN DSC_TEMP_OH.CD_MAT_OH__CODE IS 'Matériaux';
COMMENT ON COLUMN DSC_TEMP_OH.CD_TETE_AV_OH__TETE_AV IS 'Tête aval';
COMMENT ON COLUMN DSC_TEMP_OH.CD_MO_OH__MO IS 'Maitre d''ouvrage';
COMMENT ON COLUMN DSC_TEMP_OH.CD_ENTP_OH__ENTREPRISE IS 'Entreprise';
COMMENT ON COLUMN DSC_TEMP_OH.CD_FAM_OH__FAMILLE IS 'Famille';
COMMENT ON COLUMN DSC_TEMP_OH.CD_PRO_AV_OH__PROTECT IS 'Protection Aval';
COMMENT ON COLUMN DSC_TEMP_OH.CD_SOUS_TYPE_OH__SOUS_TYPE IS 'Sous type OH';
COMMENT ON COLUMN DSC_TEMP_OH.LIAISON IS 'Liaison';
COMMENT ON COLUMN DSC_TEMP_OH.SENS IS 'Sens';
COMMENT ON COLUMN DSC_TEMP_OH.ABS_DEB IS 'PR';
COMMENT ON COLUMN DSC_TEMP_OH.ABS_FIN IS 'Pr fin';
COMMENT ON COLUMN DSC_TEMP_OH.NUM_EXPLOIT IS 'N° d''exploitation';
COMMENT ON COLUMN DSC_TEMP_OH.DATE_MS IS 'Date MS';
COMMENT ON COLUMN DSC_TEMP_OH.LONGUEUR IS 'Longueur (m)';
COMMENT ON COLUMN DSC_TEMP_OH.HAUTEUR IS 'Hauteur (mm)';
COMMENT ON COLUMN DSC_TEMP_OH.BIAIS IS 'Biais (degré)';
COMMENT ON COLUMN DSC_TEMP_OH.PENTE IS 'Pente (%)';
COMMENT ON COLUMN DSC_TEMP_OH.PORTEE IS 'Portée - Ø (mm)';
COMMENT ON COLUMN DSC_TEMP_OH.JUM IS 'Jumellé';
COMMENT ON COLUMN DSC_TEMP_OH.ELEM IS 'Nbre élément';
COMMENT ON COLUMN DSC_TEMP_OH.REGARD IS 'Nbre regard';
COMMENT ON COLUMN DSC_TEMP_OH.PERCHE IS 'Ouvrage Perché';
COMMENT ON COLUMN DSC_TEMP_OH.VULNERABLE IS 'Vulnérabilité';
COMMENT ON COLUMN DSC_TEMP_OH.FAUNE IS 'Aménagement petite faune';
COMMENT ON COLUMN DSC_TEMP_OH.LOI IS 'Loi sur l''eau';
COMMENT ON COLUMN DSC_TEMP_OH.PHE IS 'Niveau PHE (mm)';
COMMENT ON COLUMN DSC_TEMP_OH.DEBIT IS 'Débit-projet';
COMMENT ON COLUMN DSC_TEMP_OH.OUV_AVAL IS 'Connexion Aval';
COMMENT ON COLUMN DSC_TEMP_OH.NOTE1 IS 'Note Abords Amont';
COMMENT ON COLUMN DSC_TEMP_OH.NOTE2 IS 'Note Protection Amont';
COMMENT ON COLUMN DSC_TEMP_OH.NOTE3 IS 'Note Conduit';
COMMENT ON COLUMN DSC_TEMP_OH.NOTE4 IS 'Note Protection Aval';
COMMENT ON COLUMN DSC_TEMP_OH.NOTE5 IS 'Note Abord Aval';
COMMENT ON COLUMN DSC_TEMP_OH.URGENCE IS 'Niveau Urgence';
COMMENT ON COLUMN DSC_TEMP_OH.DESC_INVA IS 'Description invalide';
COMMENT ON COLUMN DSC_TEMP_OH.SECURITE IS 'Problème de sécurité';
COMMENT ON COLUMN DSC_TEMP_OH.PRIORITAIRE IS 'Urgence traitement';
COMMENT ON COLUMN DSC_TEMP_OH.PROSURV_ANNEE IS 'Prochaine Inspection';
COMMENT ON COLUMN DSC_TEMP_OH.DERN_INSP IS 'Dernière Inspection';
COMMENT ON COLUMN DSC_TEMP_OH.DERN_VST IS 'Dernière Visite';
COMMENT ON COLUMN DSC_TEMP_OH.NOTE_VST IS 'Note Visite';
COMMENT ON COLUMN DSC_TEMP_OH.ARCHIVE IS 'Archive';
COMMENT ON COLUMN DSC_TEMP_OH.COMMENTAIRE IS 'Commentaire';
COMMENT ON COLUMN DSC_TEMP_OH.X1 IS 'X1';
COMMENT ON COLUMN DSC_TEMP_OH.Y1 IS 'Y1';
COMMENT ON COLUMN DSC_TEMP_OH.Z1 IS 'Z1';
COMMENT ON COLUMN DSC_TEMP_OH.X2 IS 'X2';
COMMENT ON COLUMN DSC_TEMP_OH.Y2 IS 'Y2';
COMMENT ON COLUMN DSC_TEMP_OH.Z2 IS 'Z2';
COMMENT ON COLUMN DSC_TEMP_OH.DATE_RELEVE IS 'Date relevé';
COMMENT ON COLUMN DSC_TEMP_OH.TERRAIN IS 'Terrain';

-- ---------------------------------------------------------
-- Table PRT_OH
-- ---------------------------------------------------------
CREATE TABLE PRT_OH 
( 
	GRP_OH__ID_GRP                          NUMBER(7) NOT NULL,
	ID_PRT                                  NUMBER(7) NOT NULL,
	LIBP                                    VARCHAR2(500 CHAR) NOT NULL,
	ORDRE                                   NUMBER(7) NOT NULL
);
COMMENT ON TABLE PRT_OH IS 'Partie';
COMMENT ON COLUMN PRT_OH.GRP_OH__ID_GRP IS 'Identifiant Groupe';
COMMENT ON COLUMN PRT_OH.ID_PRT IS 'Identifiant Partie';
COMMENT ON COLUMN PRT_OH.LIBP IS 'Partie';
COMMENT ON COLUMN PRT_OH.ORDRE IS 'N° Ordre';

-- ---------------------------------------------------------
-- Table PHOTO_INSP_OH
-- ---------------------------------------------------------
CREATE TABLE PHOTO_INSP_OH 
( 
	ID                                      VARCHAR2(30 CHAR) NOT NULL,
	CAMP_OH__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	DSC_OH__NUM_OH                          VARCHAR2(20 CHAR) NOT NULL,
	COMMENTAIRE                             VARCHAR2(100 CHAR)
);
COMMENT ON TABLE PHOTO_INSP_OH IS 'Photo de l''ouvrage';
COMMENT ON COLUMN PHOTO_INSP_OH.ID IS 'Identifiant2';
COMMENT ON COLUMN PHOTO_INSP_OH.CAMP_OH__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN PHOTO_INSP_OH.DSC_OH__NUM_OH IS 'NumOH';
COMMENT ON COLUMN PHOTO_INSP_OH.COMMENTAIRE IS 'Commentaire';

-- ---------------------------------------------------------
-- Table PHOTO_INSP_TMP_OH
-- ---------------------------------------------------------
CREATE TABLE PHOTO_INSP_TMP_OH 
( 
	ID                                      VARCHAR2(30 CHAR) NOT NULL,
	CAMP_OH__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	DSC_TEMP_OH__NUM_OH                     VARCHAR2(20 CHAR) NOT NULL,
	COMMENTAIRE                             VARCHAR2(100 CHAR)
);
COMMENT ON TABLE PHOTO_INSP_TMP_OH IS 'Photo de l''ouvrage temporaire';
COMMENT ON COLUMN PHOTO_INSP_TMP_OH.ID IS 'Identifiant2';
COMMENT ON COLUMN PHOTO_INSP_TMP_OH.CAMP_OH__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN PHOTO_INSP_TMP_OH.DSC_TEMP_OH__NUM_OH IS 'NumOH';
COMMENT ON COLUMN PHOTO_INSP_TMP_OH.COMMENTAIRE IS 'Commentaire';

-- ---------------------------------------------------------
-- Table PHOTO_ELT_INSP_OH
-- ---------------------------------------------------------
CREATE TABLE PHOTO_ELT_INSP_OH 
( 
	GRP_OH__ID_GRP                          NUMBER(7) NOT NULL,
	PRT_OH__ID_PRT                          NUMBER(7) NOT NULL,
	SPRT_OH__ID_SPRT                        NUMBER(7) NOT NULL,
	CAMP_OH__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	ELT_OH__ID_ELEM                         NUMBER(7) NOT NULL,
	DSC_OH__NUM_OH                          VARCHAR2(20 CHAR) NOT NULL,
	ID                                      VARCHAR2(50 CHAR) NOT NULL,
	COMMENTAIRE                             VARCHAR2(100 CHAR)
);
COMMENT ON TABLE PHOTO_ELT_INSP_OH IS 'Photo éléments inspectés';
COMMENT ON COLUMN PHOTO_ELT_INSP_OH.GRP_OH__ID_GRP IS 'Identifiant Groupe';
COMMENT ON COLUMN PHOTO_ELT_INSP_OH.PRT_OH__ID_PRT IS 'Identifiant Partie';
COMMENT ON COLUMN PHOTO_ELT_INSP_OH.SPRT_OH__ID_SPRT IS 'Identifiant Sous Partie';
COMMENT ON COLUMN PHOTO_ELT_INSP_OH.CAMP_OH__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN PHOTO_ELT_INSP_OH.ELT_OH__ID_ELEM IS 'Identifiant élément';
COMMENT ON COLUMN PHOTO_ELT_INSP_OH.DSC_OH__NUM_OH IS 'NumOH';
COMMENT ON COLUMN PHOTO_ELT_INSP_OH.ID IS 'Identifiant de la photo';
COMMENT ON COLUMN PHOTO_ELT_INSP_OH.COMMENTAIRE IS 'Commentaire';

-- ---------------------------------------------------------
-- Table PHOTO_ELT_INSP_TMP_OH
-- ---------------------------------------------------------
CREATE TABLE PHOTO_ELT_INSP_TMP_OH 
( 
	GRP_OH__ID_GRP                          NUMBER(7) NOT NULL,
	PRT_OH__ID_PRT                          NUMBER(7) NOT NULL,
	SPRT_OH__ID_SPRT                        NUMBER(7) NOT NULL,
	CAMP_OH__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	DSC_TEMP_OH__NUM_OH                     VARCHAR2(20 CHAR) NOT NULL,
	ELT_OH__ID_ELEM                         NUMBER(7) NOT NULL,
	ID                                      VARCHAR2(50 CHAR) NOT NULL,
	COMMENTAIRE                             VARCHAR2(100 CHAR)
);
COMMENT ON TABLE PHOTO_ELT_INSP_TMP_OH IS 'Photo éléments inspectés temporaire';
COMMENT ON COLUMN PHOTO_ELT_INSP_TMP_OH.GRP_OH__ID_GRP IS 'Identifiant Groupe';
COMMENT ON COLUMN PHOTO_ELT_INSP_TMP_OH.PRT_OH__ID_PRT IS 'Identifiant Partie';
COMMENT ON COLUMN PHOTO_ELT_INSP_TMP_OH.SPRT_OH__ID_SPRT IS 'Identifiant Sous Partie';
COMMENT ON COLUMN PHOTO_ELT_INSP_TMP_OH.CAMP_OH__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN PHOTO_ELT_INSP_TMP_OH.DSC_TEMP_OH__NUM_OH IS 'NumOH';
COMMENT ON COLUMN PHOTO_ELT_INSP_TMP_OH.ELT_OH__ID_ELEM IS 'Identifiant élément';
COMMENT ON COLUMN PHOTO_ELT_INSP_TMP_OH.ID IS 'Identifiant de la photo';
COMMENT ON COLUMN PHOTO_ELT_INSP_TMP_OH.COMMENTAIRE IS 'Commentaire';

-- ---------------------------------------------------------
-- Table PHOTO_SPRT_VST_OH
-- ---------------------------------------------------------
CREATE TABLE PHOTO_SPRT_VST_OH 
( 
	CAMP_OH__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	DSC_OH__NUM_OH                          VARCHAR2(20 CHAR) NOT NULL,
	CD_CHAPITRE_OH__ID_CHAP                 NUMBER(7) NOT NULL,
	CD_LIGNE_OH__ID_LIGNE                   NUMBER(7) NOT NULL,
	ID                                      VARCHAR2(50 CHAR) NOT NULL,
	COMMENTAIRE                             VARCHAR2(100 CHAR)
);
COMMENT ON TABLE PHOTO_SPRT_VST_OH IS 'Photo sous-parties visitées';
COMMENT ON COLUMN PHOTO_SPRT_VST_OH.CAMP_OH__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN PHOTO_SPRT_VST_OH.DSC_OH__NUM_OH IS 'NumOH';
COMMENT ON COLUMN PHOTO_SPRT_VST_OH.CD_CHAPITRE_OH__ID_CHAP IS 'Identifiant chapitre';
COMMENT ON COLUMN PHOTO_SPRT_VST_OH.CD_LIGNE_OH__ID_LIGNE IS 'Identifiant ligne';
COMMENT ON COLUMN PHOTO_SPRT_VST_OH.ID IS 'Identifiant de la photo';
COMMENT ON COLUMN PHOTO_SPRT_VST_OH.COMMENTAIRE IS 'Commentaire';

-- ---------------------------------------------------------
-- Table PHOTO_VST_OH
-- ---------------------------------------------------------
CREATE TABLE PHOTO_VST_OH 
( 
	ID                                      VARCHAR2(30 CHAR) NOT NULL,
	CAMP_OH__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	DSC_OH__NUM_OH                          VARCHAR2(20 CHAR) NOT NULL,
	COMMENTAIRE                             VARCHAR2(100 CHAR)
);
COMMENT ON TABLE PHOTO_VST_OH IS 'Photo vst oh';
COMMENT ON COLUMN PHOTO_VST_OH.ID IS 'photo vst oh id';
COMMENT ON COLUMN PHOTO_VST_OH.CAMP_OH__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN PHOTO_VST_OH.DSC_OH__NUM_OH IS 'NumOH';
COMMENT ON COLUMN PHOTO_VST_OH.COMMENTAIRE IS 'photo vst oh commentaire';

-- ---------------------------------------------------------
-- Table CD_PRECO__SPRT_VST_OH
-- ---------------------------------------------------------
CREATE TABLE CD_PRECO__SPRT_VST_OH 
( 
	CAMP_OH__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	DSC_OH__NUM_OH                          VARCHAR2(20 CHAR) NOT NULL,
	CD_CHAPITRE_OH__ID_CHAP                 NUMBER(7) NOT NULL,
	CD_LIGNE_OH__ID_LIGNE                   NUMBER(7) NOT NULL,
	BPU_OH__ID_BPU                          NUMBER(7) NOT NULL,
	REALISE                                 NUMBER
);
COMMENT ON TABLE CD_PRECO__SPRT_VST_OH IS 'Préconisation';
COMMENT ON COLUMN CD_PRECO__SPRT_VST_OH.CAMP_OH__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN CD_PRECO__SPRT_VST_OH.DSC_OH__NUM_OH IS 'NumOH';
COMMENT ON COLUMN CD_PRECO__SPRT_VST_OH.CD_CHAPITRE_OH__ID_CHAP IS 'Identifiant chapitre';
COMMENT ON COLUMN CD_PRECO__SPRT_VST_OH.CD_LIGNE_OH__ID_LIGNE IS 'Identifiant ligne';
COMMENT ON COLUMN CD_PRECO__SPRT_VST_OH.BPU_OH__ID_BPU IS 'Identifiant Bordereau';
COMMENT ON COLUMN CD_PRECO__SPRT_VST_OH.REALISE IS 'Entretien réalisé';

-- ---------------------------------------------------------
-- Table CD_PRESTA_OH
-- ---------------------------------------------------------
CREATE TABLE CD_PRESTA_OH 
( 
	PRESTATAIRE                             VARCHAR2(50 CHAR) NOT NULL
);
COMMENT ON TABLE CD_PRESTA_OH IS 'Prestataire';
COMMENT ON COLUMN CD_PRESTA_OH.PRESTATAIRE IS 'Prestataire';

-- ---------------------------------------------------------
-- Table PREVISION_OH
-- ---------------------------------------------------------
CREATE TABLE PREVISION_OH 
( 
	DSC_OH__NUM_OH                          VARCHAR2(20 CHAR) NOT NULL,
	BPU_OH__ID_BPU                          NUMBER(7) NOT NULL,
	DATE_DEBUT                              DATE NOT NULL,
	CD_CONTRAINTE_OH__TYPE                  VARCHAR2(100 CHAR),
	DATE_FIN                                DATE,
	MONTANT                                 NUMBER(9),
	DATE_DEM_PUB                            DATE,
	COMMENTAIRE                             VARCHAR2(255 CHAR),
	REALISE                                 NUMBER
);
COMMENT ON TABLE PREVISION_OH IS 'Prévisions';
COMMENT ON COLUMN PREVISION_OH.DSC_OH__NUM_OH IS 'NumOH';
COMMENT ON COLUMN PREVISION_OH.BPU_OH__ID_BPU IS 'Identifiant Bordereau';
COMMENT ON COLUMN PREVISION_OH.DATE_DEBUT IS 'Date début';
COMMENT ON COLUMN PREVISION_OH.CD_CONTRAINTE_OH__TYPE IS 'Contrainte exploit';
COMMENT ON COLUMN PREVISION_OH.DATE_FIN IS 'Date fin';
COMMENT ON COLUMN PREVISION_OH.MONTANT IS 'Coûts (€)';
COMMENT ON COLUMN PREVISION_OH.DATE_DEM_PUB IS 'Date demande publication';
COMMENT ON COLUMN PREVISION_OH.COMMENTAIRE IS 'Commentaire';
COMMENT ON COLUMN PREVISION_OH.REALISE IS 'Réalisé';

-- ---------------------------------------------------------
-- Table CD_PRO_AM_OH
-- ---------------------------------------------------------
CREATE TABLE CD_PRO_AM_OH 
( 
	PROTECT                                 VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_PRO_AM_OH IS 'Protection Amont';
COMMENT ON COLUMN CD_PRO_AM_OH.PROTECT IS 'Protection Amont';

-- ---------------------------------------------------------
-- Table CD_PRO_AV_OH
-- ---------------------------------------------------------
CREATE TABLE CD_PRO_AV_OH 
( 
	PROTECT                                 VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_PRO_AV_OH IS 'Protection Aval';
COMMENT ON COLUMN CD_PRO_AV_OH.PROTECT IS 'Protection Aval';

-- ---------------------------------------------------------
-- Table ENTETE_OH
-- ---------------------------------------------------------
CREATE TABLE ENTETE_OH 
( 
	CAMP_OH__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	DSC_OH__NUM_OH                          VARCHAR2(20 CHAR) NOT NULL,
	CD_ENTETE_OH__ID_ENTETE                 NUMBER(7) NOT NULL,
	VALEUR                                  VARCHAR2(250 CHAR)
);
COMMENT ON TABLE ENTETE_OH IS 'Saisie entête';
COMMENT ON COLUMN ENTETE_OH.CAMP_OH__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN ENTETE_OH.DSC_OH__NUM_OH IS 'NumOH';
COMMENT ON COLUMN ENTETE_OH.CD_ENTETE_OH__ID_ENTETE IS 'Identifiant Entête';
COMMENT ON COLUMN ENTETE_OH.VALEUR IS 'Valeur';

-- ---------------------------------------------------------
-- Table SEUIL_QUALITE_OH
-- ---------------------------------------------------------
CREATE TABLE SEUIL_QUALITE_OH 
( 
	CD_QUALITE_OH__QUALITE                  VARCHAR2(25 CHAR) NOT NULL,
	INDICE_URGENCE                          VARCHAR2(5 CHAR) NOT NULL
);
COMMENT ON TABLE SEUIL_QUALITE_OH IS 'Seuil qualité';
COMMENT ON COLUMN SEUIL_QUALITE_OH.CD_QUALITE_OH__QUALITE IS 'Niveau qualité';
COMMENT ON COLUMN SEUIL_QUALITE_OH.INDICE_URGENCE IS 'Indice urgence';

-- ---------------------------------------------------------
-- Table SEUIL_URGENCE_OH
-- ---------------------------------------------------------
CREATE TABLE SEUIL_URGENCE_OH 
( 
	ORDRE                                   NUMBER(9) NOT NULL,
	NBR_NOTE                                NUMBER(9),
	VAL_NOTE                                NUMBER(9),
	INDICE                                  NUMBER(9)
);
COMMENT ON TABLE SEUIL_URGENCE_OH IS 'Seuil urgence';
COMMENT ON COLUMN SEUIL_URGENCE_OH.ORDRE IS 'No Ordre';
COMMENT ON COLUMN SEUIL_URGENCE_OH.NBR_NOTE IS '>= Nbre de note';
COMMENT ON COLUMN SEUIL_URGENCE_OH.VAL_NOTE IS 'Valeur de note';
COMMENT ON COLUMN SEUIL_URGENCE_OH.INDICE IS 'Ind dégradation';

-- ---------------------------------------------------------
-- Table SPRT_OH
-- ---------------------------------------------------------
CREATE TABLE SPRT_OH 
( 
	GRP_OH__ID_GRP                          NUMBER(7) NOT NULL,
	PRT_OH__ID_PRT                          NUMBER(7) NOT NULL,
	ID_SPRT                                 NUMBER(7) NOT NULL,
	LIBS                                    VARCHAR2(500 CHAR) NOT NULL,
	ORDRE                                   NUMBER(7) NOT NULL
);
COMMENT ON TABLE SPRT_OH IS 'Sous Partie';
COMMENT ON COLUMN SPRT_OH.GRP_OH__ID_GRP IS 'Identifiant Groupe';
COMMENT ON COLUMN SPRT_OH.PRT_OH__ID_PRT IS 'Identifiant Partie';
COMMENT ON COLUMN SPRT_OH.ID_SPRT IS 'Identifiant Sous Partie';
COMMENT ON COLUMN SPRT_OH.LIBS IS 'Sous Partie';
COMMENT ON COLUMN SPRT_OH.ORDRE IS 'N° Ordre';

-- ---------------------------------------------------------
-- Table CD_SOUS_TYPE_OH
-- ---------------------------------------------------------
CREATE TABLE CD_SOUS_TYPE_OH 
( 
	SOUS_TYPE                               VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_SOUS_TYPE_OH IS 'Sous Type Ouvrage';
COMMENT ON COLUMN CD_SOUS_TYPE_OH.SOUS_TYPE IS 'Sous type OH';

-- ---------------------------------------------------------
-- Table SYS_USER_OH
-- ---------------------------------------------------------
CREATE TABLE SYS_USER_OH 
( 
	CODE_DBS                                VARCHAR2(50 CHAR) NOT NULL,
	CODE_TABLE                              VARCHAR2(100 CHAR) NOT NULL,
	CODE_COLONNE                            VARCHAR2(100 CHAR) NOT NULL,
	NOM_USER                                VARCHAR2(150 CHAR) NOT NULL,
	CODE_PRP                                VARCHAR2(255 CHAR) NOT NULL,
	VAL_PRP                                 VARCHAR2(500 CHAR) NOT NULL
);
COMMENT ON TABLE SYS_USER_OH IS 'SYS_USER_OH';
COMMENT ON COLUMN SYS_USER_OH.CODE_DBS IS 'SYS_USER_OH__CODE_DBS';
COMMENT ON COLUMN SYS_USER_OH.CODE_TABLE IS 'SYS_USER_OH__CODE_TABLE';
COMMENT ON COLUMN SYS_USER_OH.CODE_COLONNE IS 'SYS_USER_OH__CODE_COLONNE';
COMMENT ON COLUMN SYS_USER_OH.NOM_USER IS 'SYS_USER_OH__NOM_USER';
COMMENT ON COLUMN SYS_USER_OH.CODE_PRP IS 'SYS_USER_OH__CODE_PRP';
COMMENT ON COLUMN SYS_USER_OH.VAL_PRP IS 'SYS_USER_OH__VAL_PRP';

-- ---------------------------------------------------------
-- Table TRAVAUX_OH
-- ---------------------------------------------------------
CREATE TABLE TRAVAUX_OH 
( 
	DSC_OH__NUM_OH                          VARCHAR2(20 CHAR) NOT NULL,
	CD_TRAVAUX_OH__CODE                     VARCHAR2(60 CHAR) NOT NULL,
	NATURE_TRAV_OH__NATURE                  VARCHAR2(100 CHAR) NOT NULL,
	DATE_RCP                                DATE NOT NULL,
	CD_ENTP_OH__ENTREPRISE                  VARCHAR2(60 CHAR) NOT NULL,
	DATE_FIN_GAR                            DATE,
	COUT                                    NUMBER(9),
	MARCHE                                  VARCHAR2(25 CHAR),
	COMMENTAIRE                             VARCHAR2(500 CHAR)
);
COMMENT ON TABLE TRAVAUX_OH IS 'Travaux';
COMMENT ON COLUMN TRAVAUX_OH.DSC_OH__NUM_OH IS 'NumOH';
COMMENT ON COLUMN TRAVAUX_OH.CD_TRAVAUX_OH__CODE IS 'Type travaux';
COMMENT ON COLUMN TRAVAUX_OH.NATURE_TRAV_OH__NATURE IS 'Nature travaux';
COMMENT ON COLUMN TRAVAUX_OH.DATE_RCP IS 'Date Réception';
COMMENT ON COLUMN TRAVAUX_OH.CD_ENTP_OH__ENTREPRISE IS 'Entreprise';
COMMENT ON COLUMN TRAVAUX_OH.DATE_FIN_GAR IS 'Fin de garantie';
COMMENT ON COLUMN TRAVAUX_OH.COUT IS 'Coûts (€)';
COMMENT ON COLUMN TRAVAUX_OH.MARCHE IS 'No Marché';
COMMENT ON COLUMN TRAVAUX_OH.COMMENTAIRE IS 'Commentaire';

-- ---------------------------------------------------------
-- Table CD_COMPOSANT_OH
-- ---------------------------------------------------------
CREATE TABLE CD_COMPOSANT_OH 
( 
	TYPE_COMP                               VARCHAR2(6 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(60 CHAR)
);
COMMENT ON TABLE CD_COMPOSANT_OH IS 'Type Composant';
COMMENT ON COLUMN CD_COMPOSANT_OH.TYPE_COMP IS 'Type';
COMMENT ON COLUMN CD_COMPOSANT_OH.LIBELLE IS 'Libellé';

-- ---------------------------------------------------------
-- Table CD_DOC_OH
-- ---------------------------------------------------------
CREATE TABLE CD_DOC_OH 
( 
	CODE                                    VARCHAR2(15 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(60 CHAR),
	PATH                                    VARCHAR2(255 CHAR)
);
COMMENT ON TABLE CD_DOC_OH IS 'Type de document';
COMMENT ON COLUMN CD_DOC_OH.CODE IS 'Code';
COMMENT ON COLUMN CD_DOC_OH.LIBELLE IS 'Libellé';
COMMENT ON COLUMN CD_DOC_OH.PATH IS 'Répertoire';

-- ---------------------------------------------------------
-- Table CD_EVT_OH
-- ---------------------------------------------------------
CREATE TABLE CD_EVT_OH 
( 
	TYPE                                    VARCHAR2(25 CHAR) NOT NULL,
	IMPACT                                  NUMBER
);
COMMENT ON TABLE CD_EVT_OH IS 'Type d''événement';
COMMENT ON COLUMN CD_EVT_OH.TYPE IS 'Type événement';
COMMENT ON COLUMN CD_EVT_OH.IMPACT IS 'Impact métier';

-- ---------------------------------------------------------
-- Table CD_EXT_OH
-- ---------------------------------------------------------
CREATE TABLE CD_EXT_OH 
( 
	TYPE                                    VARCHAR2(60 CHAR) NOT NULL,
	IS_OH                                   NUMBER NOT NULL,
	IS_BSN                                  NUMBER NOT NULL
);
COMMENT ON TABLE CD_EXT_OH IS 'Type Exutoire';
COMMENT ON COLUMN CD_EXT_OH.TYPE IS 'Type exutoire';
COMMENT ON COLUMN CD_EXT_OH.IS_OH IS 'Exutoire OH';
COMMENT ON COLUMN CD_EXT_OH.IS_BSN IS 'Exétoire Bassin';

-- ---------------------------------------------------------
-- Table CD_OUV_OH
-- ---------------------------------------------------------
CREATE TABLE CD_OUV_OH 
( 
	OUV                                     VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_OUV_OH IS 'Type Ouverture';
COMMENT ON COLUMN CD_OUV_OH.OUV IS 'Profil';

-- ---------------------------------------------------------
-- Table CD_TYPE_OH
-- ---------------------------------------------------------
CREATE TABLE CD_TYPE_OH 
( 
	TYPE                                    VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_TYPE_OH IS 'Type Ouvrage';
COMMENT ON COLUMN CD_TYPE_OH.TYPE IS 'Type OH';

-- ---------------------------------------------------------
-- Table CD_TYPE_PV_OH
-- ---------------------------------------------------------
CREATE TABLE CD_TYPE_PV_OH 
( 
	CODE                                    VARCHAR2(15 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(60 CHAR) NOT NULL,
	CYCLE                                   NUMBER(6),
	COUT                                    NUMBER(6)
);
COMMENT ON TABLE CD_TYPE_PV_OH IS 'Type PV';
COMMENT ON COLUMN CD_TYPE_PV_OH.CODE IS 'Type de PV';
COMMENT ON COLUMN CD_TYPE_PV_OH.LIBELLE IS 'Libellé';
COMMENT ON COLUMN CD_TYPE_PV_OH.CYCLE IS 'Cycle';
COMMENT ON COLUMN CD_TYPE_PV_OH.COUT IS 'Coût unitaire (€)';

-- ---------------------------------------------------------
-- Table CD_TETE_AM_OH
-- ---------------------------------------------------------
CREATE TABLE CD_TETE_AM_OH 
( 
	TETE_AM                                 VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_TETE_AM_OH IS 'Type Tête amont';
COMMENT ON COLUMN CD_TETE_AM_OH.TETE_AM IS 'Tête amont';

-- ---------------------------------------------------------
-- Table CD_TETE_AV_OH
-- ---------------------------------------------------------
CREATE TABLE CD_TETE_AV_OH 
( 
	TETE_AV                                 VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_TETE_AV_OH IS 'Type Tête aval';
COMMENT ON COLUMN CD_TETE_AV_OH.TETE_AV IS 'Tête aval';

-- ---------------------------------------------------------
-- Table CD_TRAVAUX_OH
-- ---------------------------------------------------------
CREATE TABLE CD_TRAVAUX_OH 
( 
	CODE                                    VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_TRAVAUX_OH IS 'Type travaux';
COMMENT ON COLUMN CD_TRAVAUX_OH.CODE IS 'Type travaux';

-- ---------------------------------------------------------
-- Table CD_UNITE_OH
-- ---------------------------------------------------------
CREATE TABLE CD_UNITE_OH 
( 
	UNITE                                   VARCHAR2(12 CHAR) NOT NULL
);
COMMENT ON TABLE CD_UNITE_OH IS 'unité';
COMMENT ON COLUMN CD_UNITE_OH.UNITE IS 'Unité';

-- ---------------------------------------------------------
-- Table VST_OH
-- ---------------------------------------------------------
CREATE TABLE VST_OH 
( 
	CAMP_OH__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	DSC_OH__NUM_OH                          VARCHAR2(20 CHAR) NOT NULL,
	INSPECTEUR_OH__NOM                      VARCHAR2(60 CHAR),
	ETAT                                    VARCHAR2(25 CHAR) NOT NULL,
	DATEV                                   DATE,
	PRIORITAIRE                             NUMBER,
	OBSERV                                  VARCHAR2(500 CHAR),
	NOTE_VST                                VARCHAR2(5 CHAR)
);
COMMENT ON TABLE VST_OH IS 'Visite';
COMMENT ON COLUMN VST_OH.CAMP_OH__ID_CAMP IS 'Identifiant Campagne';
COMMENT ON COLUMN VST_OH.DSC_OH__NUM_OH IS 'NumOH';
COMMENT ON COLUMN VST_OH.INSPECTEUR_OH__NOM IS 'Nom inspecteur';
COMMENT ON COLUMN VST_OH.ETAT IS 'Statut visite';
COMMENT ON COLUMN VST_OH.DATEV IS 'Date de visite';
COMMENT ON COLUMN VST_OH.PRIORITAIRE IS 'Urgence traitement';
COMMENT ON COLUMN VST_OH.OBSERV IS 'Observation';
COMMENT ON COLUMN VST_OH.NOTE_VST IS 'Note Visite';

