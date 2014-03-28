/*################################################################################################*/
/* Script     : OA_Tables.sql                                                                     */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

-- ---------------------------------------------------------
-- Table SYS_PRP_OA
-- ---------------------------------------------------------

CREATE TABLE SYS_PRP_OA 
( 
	CODE_TABLE                    VARCHAR2(60 CHAR)        NOT NULL,
	CODE_COLONNE                  VARCHAR2(60 CHAR)        NOT NULL,
	NOM_USER                      VARCHAR2(30 CHAR)        NOT NULL,
	CODE_PRP                      VARCHAR2(60 CHAR)        NOT NULL,
	VAL_PRP                       VARCHAR2(255 CHAR)       );
COMMENT ON TABLE SYS_PRP_OA IS 'MétaDonnées du schéma OA';

-- ---------------------------------------------------------
-- Table SYS_INSTANCE_OA
-- ---------------------------------------------------------

CREATE TABLE SYS_INSTANCE_OA 
( 
	CODE                   VARCHAR2(100 CHAR) NOT NULL,
	VALEUR                 CLOB);
COMMENT ON TABLE SYS_INSTANCE_OA IS 'Informations du schéma OA';

-- ---------------------------------------------------------
-- Table APPUIS_OA
-- ---------------------------------------------------------
CREATE TABLE APPUIS_OA 
( 
	DSC_OA__NUM_OA                          VARCHAR2(20 CHAR) NOT NULL,
	CD_FAM_APPUI_OA__FAM_APP                VARCHAR2(60 CHAR) NOT NULL,
	CD_APPUI_OA__APP                        VARCHAR2(60 CHAR) NOT NULL,
	CD_APP_APPUI_OA__APPUI                  VARCHAR2(60 CHAR) NOT NULL,
	NBR_APPAREIL                            NUMBER(2),
	DATE_MS                                 DATE,
	COMMENTAIRE                             VARCHAR2(255 CHAR)
);
COMMENT ON TABLE APPUIS_OA IS 'Appuis';
COMMENT ON COLUMN APPUIS_OA.DSC_OA__NUM_OA IS 'NumOA';
COMMENT ON COLUMN APPUIS_OA.CD_FAM_APPUI_OA__FAM_APP IS 'Famille d''appuis';
COMMENT ON COLUMN APPUIS_OA.CD_APPUI_OA__APP IS 'Type d''appui';
COMMENT ON COLUMN APPUIS_OA.CD_APP_APPUI_OA__APPUI IS 'Type app appui';
COMMENT ON COLUMN APPUIS_OA.NBR_APPAREIL IS 'Nbr app. appui';
COMMENT ON COLUMN APPUIS_OA.DATE_MS IS 'Date MS app appui';
COMMENT ON COLUMN APPUIS_OA.COMMENTAIRE IS 'Commentaire';

-- ---------------------------------------------------------
-- Table ARCHIVE_3_OA
-- ---------------------------------------------------------
CREATE TABLE ARCHIVE_3_OA 
( 
	DATE_CALC                               DATE NOT NULL,
	NBRE                                    NUMBER(4) NOT NULL,
	SURF                                    NUMBER(9) NOT NULL,
	ETAT_3X                                 VARCHAR2(3 CHAR) NOT NULL,
	DELAI                                   NUMBER(3),
	ETAT_LOLF                               NUMBER(6,2),
	MONTANT                                 NUMBER(9),
	OBSV                                    VARCHAR2(255 CHAR)
);
COMMENT ON TABLE ARCHIVE_3_OA IS 'Archive Etat';
COMMENT ON COLUMN ARCHIVE_3_OA.DATE_CALC IS 'Date Calcul';
COMMENT ON COLUMN ARCHIVE_3_OA.NBRE IS 'Nbre Total OA';
COMMENT ON COLUMN ARCHIVE_3_OA.SURF IS 'Surf totale';
COMMENT ON COLUMN ARCHIVE_3_OA.ETAT_3X IS 'Etat 3x';
COMMENT ON COLUMN ARCHIVE_3_OA.DELAI IS 'Délai';
COMMENT ON COLUMN ARCHIVE_3_OA.ETAT_LOLF IS 'Etat Lolf';
COMMENT ON COLUMN ARCHIVE_3_OA.MONTANT IS 'Montant pénalité';
COMMENT ON COLUMN ARCHIVE_3_OA.OBSV IS 'Commentaire';

-- ---------------------------------------------------------
-- Table BPU_OA
-- ---------------------------------------------------------
CREATE TABLE BPU_OA 
( 
	ID_BPU                                  NUMBER(7) NOT NULL,
	CD_TRAVAUX_OA__CODE                     VARCHAR2(60 CHAR) NOT NULL,
	CD_UNITE_OA__UNITE                      VARCHAR2(12 CHAR),
	TECHN                                   VARCHAR2(255 CHAR) NOT NULL,
	PRIX                                    NUMBER(9) NOT NULL,
	DATE_MAJ                                DATE,
	FREQ                                    NUMBER(3),
	PRECO_VST                               NUMBER,
	REALIS_VST                              NUMBER
);
COMMENT ON TABLE BPU_OA IS 'Bordereau Prix';
COMMENT ON COLUMN BPU_OA.ID_BPU IS 'Identifiant Bordereau';
COMMENT ON COLUMN BPU_OA.CD_TRAVAUX_OA__CODE IS 'Type Travaux';
COMMENT ON COLUMN BPU_OA.CD_UNITE_OA__UNITE IS 'Unité';
COMMENT ON COLUMN BPU_OA.TECHN IS 'Technique';
COMMENT ON COLUMN BPU_OA.PRIX IS 'Prix Unitaire (€)';
COMMENT ON COLUMN BPU_OA.DATE_MAJ IS 'Date MAJ';
COMMENT ON COLUMN BPU_OA.FREQ IS 'Fréquence (mois)';
COMMENT ON COLUMN BPU_OA.PRECO_VST IS 'Préconisation Visite';
COMMENT ON COLUMN BPU_OA.REALIS_VST IS 'Entretien réalisable';

-- ---------------------------------------------------------
-- Table CD_BE_OA
-- ---------------------------------------------------------
CREATE TABLE CD_BE_OA 
( 
	BUREAU                                  VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_BE_OA IS 'Bureau d''étude';
COMMENT ON COLUMN CD_BE_OA.BUREAU IS 'Bureau d''étude';

-- ---------------------------------------------------------
-- Table CAMP_OA
-- ---------------------------------------------------------
CREATE TABLE CAMP_OA 
( 
	ID_CAMP                                 VARCHAR2(100 CHAR) NOT NULL,
	CD_TYPE_PV_OA__CODE                     VARCHAR2(15 CHAR) NOT NULL,
	CD_PRESTA_OA__PRESTATAIRE               VARCHAR2(50 CHAR) NOT NULL,
	ANNEE                                   NUMBER(4) NOT NULL,
	DATER                                   DATE NOT NULL,
	DATEG                                   DATE,
	USERG                                   VARCHAR2(255 CHAR),
	OBSERV                                  VARCHAR2(255 CHAR)
);
COMMENT ON TABLE CAMP_OA IS 'Campagne';
COMMENT ON COLUMN CAMP_OA.ID_CAMP IS 'Identifiant campagne';
COMMENT ON COLUMN CAMP_OA.CD_TYPE_PV_OA__CODE IS 'Type de PV';
COMMENT ON COLUMN CAMP_OA.CD_PRESTA_OA__PRESTATAIRE IS 'Prestataire';
COMMENT ON COLUMN CAMP_OA.ANNEE IS 'Année';
COMMENT ON COLUMN CAMP_OA.DATER IS 'Date maxi retour';
COMMENT ON COLUMN CAMP_OA.DATEG IS 'Date génération';
COMMENT ON COLUMN CAMP_OA.USERG IS 'Nom créateur';
COMMENT ON COLUMN CAMP_OA.OBSERV IS 'Commentaire';

-- ---------------------------------------------------------
-- Table CD_PRECO__SPRT_VST_OA
-- ---------------------------------------------------------
CREATE TABLE CD_PRECO__SPRT_VST_OA 
( 
	DSC_OA__NUM_OA                          VARCHAR2(20 CHAR) NOT NULL,
	CAMP_OA__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	BPU_OA__ID_BPU                          NUMBER(7) NOT NULL,
	CD_PRECO__SPRT_VST_OH__REALISE          NUMBER
);
COMMENT ON TABLE CD_PRECO__SPRT_VST_OA IS 'CD_PRECO__SPRT_VST_OA';
COMMENT ON COLUMN CD_PRECO__SPRT_VST_OA.DSC_OA__NUM_OA IS 'NumOA';
COMMENT ON COLUMN CD_PRECO__SPRT_VST_OA.CAMP_OA__ID_CAMP IS 'Identifiant campagne';
COMMENT ON COLUMN CD_PRECO__SPRT_VST_OA.BPU_OA__ID_BPU IS 'Identifiant Bordereau';
COMMENT ON COLUMN CD_PRECO__SPRT_VST_OA.CD_PRECO__SPRT_VST_OH__REALISE IS 'Entretien réalisé';

-- ---------------------------------------------------------
-- Table CD_CHAPITRE_OA
-- ---------------------------------------------------------
CREATE TABLE CD_CHAPITRE_OA 
( 
	ID_CHAP                                 NUMBER(7) NOT NULL,
	LIBELLE                                 VARCHAR2(500 CHAR) NOT NULL,
	ORDRE_CHAP                              NUMBER(7) NOT NULL,
	PONDERATION                             NUMBER(3)
);
COMMENT ON TABLE CD_CHAPITRE_OA IS 'Chapitre';
COMMENT ON COLUMN CD_CHAPITRE_OA.ID_CHAP IS 'Identifiant chapitre';
COMMENT ON COLUMN CD_CHAPITRE_OA.LIBELLE IS 'Libellé chapitre';
COMMENT ON COLUMN CD_CHAPITRE_OA.ORDRE_CHAP IS 'N° ordre chapitre';
COMMENT ON COLUMN CD_CHAPITRE_OA.PONDERATION IS 'Pondération';

-- ---------------------------------------------------------
-- Table CLS_OA
-- ---------------------------------------------------------
CREATE TABLE CLS_OA 
( 
	ID                                      NUMBER(6,0) NOT NULL,
	TABLE_NAME                              VARCHAR2(30 CHAR) NOT NULL,
	KEY_VALUE                               VARCHAR2(1000 CHAR) NOT NULL
);
COMMENT ON TABLE CLS_OA IS 'Classeurs';
COMMENT ON COLUMN CLS_OA.ID IS 'Identifiant du classeur(cpt)';
COMMENT ON COLUMN CLS_OA.TABLE_NAME IS 'Table';
COMMENT ON COLUMN CLS_OA.KEY_VALUE IS 'Enregistrement';

-- ---------------------------------------------------------
-- Table CD_CONCLUSION_OA
-- ---------------------------------------------------------
CREATE TABLE CD_CONCLUSION_OA 
( 
	ID_CONC                                 NUMBER(7) NOT NULL,
	LIBELLE                                 VARCHAR2(500 CHAR) NOT NULL,
	ORDRE                                   NUMBER(7) NOT NULL
);
COMMENT ON TABLE CD_CONCLUSION_OA IS 'Code conclusion';
COMMENT ON COLUMN CD_CONCLUSION_OA.ID_CONC IS 'Identifiant conclusion';
COMMENT ON COLUMN CD_CONCLUSION_OA.LIBELLE IS 'Libellé conclusion';
COMMENT ON COLUMN CD_CONCLUSION_OA.ORDRE IS 'N° ordre conclusion';

-- ---------------------------------------------------------
-- Table CD_IQOA_OA
-- ---------------------------------------------------------
CREATE TABLE CD_IQOA_OA 
( 
	NOTE_IQOA                               VARCHAR2(3 CHAR) NOT NULL,
	COMMENTAIRE                             VARCHAR2(1000 CHAR)
);
COMMENT ON TABLE CD_IQOA_OA IS 'Code IQOA';
COMMENT ON COLUMN CD_IQOA_OA.NOTE_IQOA IS 'Note IQOA';
COMMENT ON COLUMN CD_IQOA_OA.COMMENTAIRE IS 'Commentaire';

-- ---------------------------------------------------------
-- Table CD_QUALITE_OA
-- ---------------------------------------------------------
CREATE TABLE CD_QUALITE_OA 
( 
	CD_IQOA_OA__NOTE_IQOA                   VARCHAR2(3 CHAR) NOT NULL,
	QUALITE                                 VARCHAR2(25 CHAR) NOT NULL
);
COMMENT ON TABLE CD_QUALITE_OA IS 'Code qualité';
COMMENT ON COLUMN CD_QUALITE_OA.CD_IQOA_OA__NOTE_IQOA IS 'Note IQOA';
COMMENT ON COLUMN CD_QUALITE_OA.QUALITE IS 'Niveau qualité';

-- ---------------------------------------------------------
-- Table CD_TECH_OA
-- ---------------------------------------------------------
CREATE TABLE CD_TECH_OA 
( 
	TECHNIQUE                               VARCHAR2(12 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(60 CHAR),
	GARANTIE                                NUMBER(3),
	DVT                                     NUMBER(3)
);
COMMENT ON TABLE CD_TECH_OA IS 'Code Technique';
COMMENT ON COLUMN CD_TECH_OA.TECHNIQUE IS 'Technique';
COMMENT ON COLUMN CD_TECH_OA.LIBELLE IS 'Libellé';
COMMENT ON COLUMN CD_TECH_OA.GARANTIE IS 'Garantie (mois)';
COMMENT ON COLUMN CD_TECH_OA.DVT IS 'Durée de vie (mois)';

-- ---------------------------------------------------------
-- Table CD_CONCLUSION__INSP_OA
-- ---------------------------------------------------------
CREATE TABLE CD_CONCLUSION__INSP_OA 
( 
	DSC_OA__NUM_OA                          VARCHAR2(20 CHAR) NOT NULL,
	CAMP_OA__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	CD_CONCLUSION_OA__ID_CONC               NUMBER(7) NOT NULL,
	CONTENU                                 VARCHAR2(1000 CHAR)
);
COMMENT ON TABLE CD_CONCLUSION__INSP_OA IS 'Conclusions';
COMMENT ON COLUMN CD_CONCLUSION__INSP_OA.DSC_OA__NUM_OA IS 'NumOA';
COMMENT ON COLUMN CD_CONCLUSION__INSP_OA.CAMP_OA__ID_CAMP IS 'Identifiant campagne';
COMMENT ON COLUMN CD_CONCLUSION__INSP_OA.CD_CONCLUSION_OA__ID_CONC IS 'Identifiant conclusion';
COMMENT ON COLUMN CD_CONCLUSION__INSP_OA.CONTENU IS 'Contenu';

-- ---------------------------------------------------------
-- Table CD_CONCLUSION__INSP_TMP_OA
-- ---------------------------------------------------------
CREATE TABLE CD_CONCLUSION__INSP_TMP_OA 
( 
	CAMP_OA__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	DSC_TEMP_OA__NUM_OA                     VARCHAR2(20 CHAR) NOT NULL,
	CD_CONCLUSION_OA__ID_CONC               NUMBER(7) NOT NULL,
	CONTENU                                 VARCHAR2(1000 CHAR)
);
COMMENT ON TABLE CD_CONCLUSION__INSP_TMP_OA IS 'Conclusions temporaire';
COMMENT ON COLUMN CD_CONCLUSION__INSP_TMP_OA.CAMP_OA__ID_CAMP IS 'Identifiant campagne';
COMMENT ON COLUMN CD_CONCLUSION__INSP_TMP_OA.DSC_TEMP_OA__NUM_OA IS 'NumOA';
COMMENT ON COLUMN CD_CONCLUSION__INSP_TMP_OA.CD_CONCLUSION_OA__ID_CONC IS 'Identifiant conclusion';
COMMENT ON COLUMN CD_CONCLUSION__INSP_TMP_OA.CONTENU IS 'Contenu';

-- ---------------------------------------------------------
-- Table CONTACT_OA
-- ---------------------------------------------------------
CREATE TABLE CONTACT_OA 
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
COMMENT ON TABLE CONTACT_OA IS 'Contacts';
COMMENT ON COLUMN CONTACT_OA.DOC__ID IS 'Identifiant document(cpt)';
COMMENT ON COLUMN CONTACT_OA.GIVENNAME IS 'Prénom';
COMMENT ON COLUMN CONTACT_OA.SN IS 'Nom';
COMMENT ON COLUMN CONTACT_OA.CN IS 'Nom complet';
COMMENT ON COLUMN CONTACT_OA.O IS 'Organisation';
COMMENT ON COLUMN CONTACT_OA.MAIL IS 'Email';
COMMENT ON COLUMN CONTACT_OA.TELEPHONENUMBER IS 'Téléphone fixe';
COMMENT ON COLUMN CONTACT_OA.MOBILE IS 'Téléphone mobile';
COMMENT ON COLUMN CONTACT_OA.FACSIMILETELEPHONENUMBER IS 'Fax';
COMMENT ON COLUMN CONTACT_OA.STREET IS 'Adresse';
COMMENT ON COLUMN CONTACT_OA.MOZILLAWORKSTREET2 IS 'Adresse complémentaire';
COMMENT ON COLUMN CONTACT_OA.L IS 'Ville';
COMMENT ON COLUMN CONTACT_OA.POSTALCODE IS 'Code Postal';
COMMENT ON COLUMN CONTACT_OA.MODIFYTIMESTAMP IS 'Date MAJ';

-- ---------------------------------------------------------
-- Table CLS_DOC_OA
-- ---------------------------------------------------------
CREATE TABLE CLS_DOC_OA 
( 
	CLS__ID                                 NUMBER(6) NOT NULL,
	DOC__ID                                 NUMBER(6) NOT NULL,
	DEFAUT                                  NUMBER,
	DOSSIER                                 VARCHAR2(15 CHAR)
);
COMMENT ON TABLE CLS_DOC_OA IS 'Contenu du classeur';
COMMENT ON COLUMN CLS_DOC_OA.CLS__ID IS 'Identifiant du classeur(cpt)';
COMMENT ON COLUMN CLS_DOC_OA.DOC__ID IS 'Identifiant document(cpt)';
COMMENT ON COLUMN CLS_DOC_OA.DEFAUT IS 'Document par défaut';
COMMENT ON COLUMN CLS_DOC_OA.DOSSIER IS 'Dossier';

-- ---------------------------------------------------------
-- Table CD_CONTRAINTE_OA
-- ---------------------------------------------------------
CREATE TABLE CD_CONTRAINTE_OA 
( 
	TYPE                                    VARCHAR2(100 CHAR) NOT NULL
);
COMMENT ON TABLE CD_CONTRAINTE_OA IS 'Contrainte d''exploitation';
COMMENT ON COLUMN CD_CONTRAINTE_OA.TYPE IS 'Contrainte Exploit.';

-- ---------------------------------------------------------
-- Table ELT_INSP_OA
-- ---------------------------------------------------------
CREATE TABLE ELT_INSP_OA 
( 
	DSC_OA__NUM_OA                          VARCHAR2(20 CHAR) NOT NULL,
	CAMP_OA__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	GRP_OA__ID_GRP                          NUMBER(7) NOT NULL,
	PRT_OA__ID_PRT                          NUMBER(7) NOT NULL,
	SPRT_OA__ID_SPRT                        NUMBER(7) NOT NULL,
	ELT_OA__ID_ELEM                         NUMBER(7) NOT NULL,
	INDICE                                  NUMBER(2) NOT NULL,
	OBS                                     VARCHAR2(255 CHAR)
);
COMMENT ON TABLE ELT_INSP_OA IS 'Détail inspection';
COMMENT ON COLUMN ELT_INSP_OA.DSC_OA__NUM_OA IS 'NumOA';
COMMENT ON COLUMN ELT_INSP_OA.CAMP_OA__ID_CAMP IS 'Identifiant campagne';
COMMENT ON COLUMN ELT_INSP_OA.GRP_OA__ID_GRP IS 'Identifiant Groupe';
COMMENT ON COLUMN ELT_INSP_OA.PRT_OA__ID_PRT IS 'Identifiant Partie';
COMMENT ON COLUMN ELT_INSP_OA.SPRT_OA__ID_SPRT IS 'Identifiant Sous Partie';
COMMENT ON COLUMN ELT_INSP_OA.ELT_OA__ID_ELEM IS 'Identifiant élément';
COMMENT ON COLUMN ELT_INSP_OA.INDICE IS 'Indice';
COMMENT ON COLUMN ELT_INSP_OA.OBS IS 'Observations';

-- ---------------------------------------------------------
-- Table ELT_INSP_TMP_OA
-- ---------------------------------------------------------
CREATE TABLE ELT_INSP_TMP_OA 
( 
	CAMP_OA__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	DSC_TEMP_OA__NUM_OA                     VARCHAR2(20 CHAR) NOT NULL,
	GRP_OA__ID_GRP                          NUMBER(7) NOT NULL,
	PRT_OA__ID_PRT                          NUMBER(7) NOT NULL,
	SPRT_OA__ID_SPRT                        NUMBER(7) NOT NULL,
	ELT_OA__ID_ELEM                         NUMBER(7) NOT NULL,
	INDICE                                  NUMBER(2) NOT NULL,
	OBS                                     VARCHAR2(255 CHAR)
);
COMMENT ON TABLE ELT_INSP_TMP_OA IS 'Détail inspection temporaire';
COMMENT ON COLUMN ELT_INSP_TMP_OA.CAMP_OA__ID_CAMP IS 'Identifiant campagne';
COMMENT ON COLUMN ELT_INSP_TMP_OA.DSC_TEMP_OA__NUM_OA IS 'NumOA';
COMMENT ON COLUMN ELT_INSP_TMP_OA.GRP_OA__ID_GRP IS 'Identifiant Groupe';
COMMENT ON COLUMN ELT_INSP_TMP_OA.PRT_OA__ID_PRT IS 'Identifiant Partie';
COMMENT ON COLUMN ELT_INSP_TMP_OA.SPRT_OA__ID_SPRT IS 'Identifiant Sous Partie';
COMMENT ON COLUMN ELT_INSP_TMP_OA.ELT_OA__ID_ELEM IS 'Identifiant élément';
COMMENT ON COLUMN ELT_INSP_TMP_OA.INDICE IS 'Indice';
COMMENT ON COLUMN ELT_INSP_TMP_OA.OBS IS 'Observations';

-- ---------------------------------------------------------
-- Table SPRT_VST_OA
-- ---------------------------------------------------------
CREATE TABLE SPRT_VST_OA 
( 
	DSC_OA__NUM_OA                          VARCHAR2(20 CHAR) NOT NULL,
	CAMP_OA__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	CD_CHAPITRE_OA__ID_CHAP                 NUMBER(7) NOT NULL,
	CD_LIGNE_OA__ID_LIGNE                   NUMBER(7) NOT NULL,
	INDICE                                  NUMBER(7) NOT NULL,
	OBS                                     VARCHAR2(500 CHAR)
);
COMMENT ON TABLE SPRT_VST_OA IS 'Détail visite';
COMMENT ON COLUMN SPRT_VST_OA.DSC_OA__NUM_OA IS 'NumOA';
COMMENT ON COLUMN SPRT_VST_OA.CAMP_OA__ID_CAMP IS 'Identifiant campagne';
COMMENT ON COLUMN SPRT_VST_OA.CD_CHAPITRE_OA__ID_CHAP IS 'Identifiant chapitre';
COMMENT ON COLUMN SPRT_VST_OA.CD_LIGNE_OA__ID_LIGNE IS 'Identifiant ligne';
COMMENT ON COLUMN SPRT_VST_OA.INDICE IS 'Indice';
COMMENT ON COLUMN SPRT_VST_OA.OBS IS 'Observations';

-- ---------------------------------------------------------
-- Table DICTIONNAIRE_OA
-- ---------------------------------------------------------
CREATE TABLE DICTIONNAIRE_OA 
( 
	NOM                                     VARCHAR2(100 CHAR) NOT NULL,
	DESCRIPTION                             VARCHAR2(255 CHAR),
	DEFINITION                              VARCHAR2(1000 CHAR),
	MOTSCLES                                VARCHAR2(255 CHAR)
);
COMMENT ON TABLE DICTIONNAIRE_OA IS 'Dictionnaire';
COMMENT ON COLUMN DICTIONNAIRE_OA.NOM IS 'Nom';
COMMENT ON COLUMN DICTIONNAIRE_OA.DESCRIPTION IS 'Description';
COMMENT ON COLUMN DICTIONNAIRE_OA.DEFINITION IS 'Définition';
COMMENT ON COLUMN DICTIONNAIRE_OA.MOTSCLES IS 'Mots clés';

-- ---------------------------------------------------------
-- Table DOC_OA
-- ---------------------------------------------------------
CREATE TABLE DOC_OA 
( 
	ID                                      NUMBER(6,0) NOT NULL,
	CD_DOC__CODE                            VARCHAR2(15 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(100 CHAR),
	REF                                     VARCHAR2(50 CHAR) NOT NULL
);
COMMENT ON TABLE DOC_OA IS 'Documents';
COMMENT ON COLUMN DOC_OA.ID IS 'Identifiant document(cpt)';
COMMENT ON COLUMN DOC_OA.CD_DOC__CODE IS 'Code';
COMMENT ON COLUMN DOC_OA.LIBELLE IS 'Libellé';
COMMENT ON COLUMN DOC_OA.REF IS 'Réference(fichier)';

-- ---------------------------------------------------------
-- Table DSC__ARCHIVE_3_OA
-- ---------------------------------------------------------
CREATE TABLE DSC__ARCHIVE_3_OA 
( 
	ARCHIVE_3_OA__DATE_CALC                 DATE NOT NULL,
	DSC_OA__NUM_OA                          VARCHAR2(20 CHAR) NOT NULL,
	NOTE3X                                  VARCHAR2(3 CHAR) NOT NULL,
	ECARTE                                  NUMBER
);
COMMENT ON TABLE DSC__ARCHIVE_3_OA IS 'DSC__ARCHIVE_3_OA';
COMMENT ON COLUMN DSC__ARCHIVE_3_OA.ARCHIVE_3_OA__DATE_CALC IS 'Date Calcul';
COMMENT ON COLUMN DSC__ARCHIVE_3_OA.DSC_OA__NUM_OA IS 'NumOA';
COMMENT ON COLUMN DSC__ARCHIVE_3_OA.NOTE3X IS 'Note 3x';
COMMENT ON COLUMN DSC__ARCHIVE_3_OA.ECARTE IS 'Ouvrage écarté';

-- ---------------------------------------------------------
-- Table ELT_OA
-- ---------------------------------------------------------
CREATE TABLE ELT_OA 
( 
	GRP_OA__ID_GRP                          NUMBER(7) NOT NULL,
	PRT_OA__ID_PRT                          NUMBER(7) NOT NULL,
	SPRT_OA__ID_SPRT                        NUMBER(7) NOT NULL,
	ID_ELEM                                 NUMBER(7) NOT NULL,
	LIBE                                    VARCHAR2(500 CHAR) NOT NULL,
	ORDRE                                   NUMBER(7) NOT NULL,
	AIDE                                    VARCHAR2(500 CHAR),
	INDICE1                                 VARCHAR2(500 CHAR),
	INDICE2                                 VARCHAR2(500 CHAR),
	INDICE3                                 VARCHAR2(500 CHAR)
);
COMMENT ON TABLE ELT_OA IS 'Elément';
COMMENT ON COLUMN ELT_OA.GRP_OA__ID_GRP IS 'Identifiant Groupe';
COMMENT ON COLUMN ELT_OA.PRT_OA__ID_PRT IS 'Identifiant Partie';
COMMENT ON COLUMN ELT_OA.SPRT_OA__ID_SPRT IS 'Identifiant Sous Partie';
COMMENT ON COLUMN ELT_OA.ID_ELEM IS 'Identifiant élément';
COMMENT ON COLUMN ELT_OA.LIBE IS 'Elément';
COMMENT ON COLUMN ELT_OA.ORDRE IS 'N° Ordre';
COMMENT ON COLUMN ELT_OA.AIDE IS 'Aide à la saisie';
COMMENT ON COLUMN ELT_OA.INDICE1 IS 'Indice1';
COMMENT ON COLUMN ELT_OA.INDICE2 IS 'Indice2';
COMMENT ON COLUMN ELT_OA.INDICE3 IS 'Indice3';

-- ---------------------------------------------------------
-- Table CD_ENTETE_OA
-- ---------------------------------------------------------
CREATE TABLE CD_ENTETE_OA 
( 
	ID_ENTETE                               NUMBER(7) NOT NULL,
	CD_COMPOSANT_OA__TYPE_COMP              VARCHAR2(6 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(500 CHAR) NOT NULL,
	ORDRE_ENT                               NUMBER(7) NOT NULL,
	GUIDE                                   VARCHAR2(500 CHAR)
);
COMMENT ON TABLE CD_ENTETE_OA IS 'Entête';
COMMENT ON COLUMN CD_ENTETE_OA.ID_ENTETE IS 'Identifiant Entête';
COMMENT ON COLUMN CD_ENTETE_OA.CD_COMPOSANT_OA__TYPE_COMP IS 'Type';
COMMENT ON COLUMN CD_ENTETE_OA.LIBELLE IS 'Libellé Entête';
COMMENT ON COLUMN CD_ENTETE_OA.ORDRE_ENT IS 'N° ordre Entête';
COMMENT ON COLUMN CD_ENTETE_OA.GUIDE IS 'Guide';

-- ---------------------------------------------------------
-- Table CD_ENTP_OA
-- ---------------------------------------------------------
CREATE TABLE CD_ENTP_OA 
( 
	ENTREPRISE                              VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_ENTP_OA IS 'Entreprise';
COMMENT ON COLUMN CD_ENTP_OA.ENTREPRISE IS 'Entreprise';

-- ---------------------------------------------------------
-- Table EQUIPEMENT_OA
-- ---------------------------------------------------------
CREATE TABLE EQUIPEMENT_OA 
( 
	DSC_OA__NUM_OA                          VARCHAR2(20 CHAR) NOT NULL,
	TABLIER_OA__NUM_TAB                     NUMBER(1) NOT NULL,
	COTE                                    VARCHAR2(1 CHAR) NOT NULL,
	CD_DPR_OA__DPR                          VARCHAR2(60 CHAR),
	CD_GC_OA__GARDE_CORPS                   VARCHAR2(60 CHAR),
	DATE_DPR                                DATE,
	DATE_GC                                 DATE,
	COMMENTAIRE                             VARCHAR2(255 CHAR)
);
COMMENT ON TABLE EQUIPEMENT_OA IS 'Equipements';
COMMENT ON COLUMN EQUIPEMENT_OA.DSC_OA__NUM_OA IS 'NumOA';
COMMENT ON COLUMN EQUIPEMENT_OA.TABLIER_OA__NUM_TAB IS 'N° Tablier';
COMMENT ON COLUMN EQUIPEMENT_OA.COTE IS 'Coté';
COMMENT ON COLUMN EQUIPEMENT_OA.CD_DPR_OA__DPR IS 'Dispositif de retenue';
COMMENT ON COLUMN EQUIPEMENT_OA.CD_GC_OA__GARDE_CORPS IS 'Garde-corps';
COMMENT ON COLUMN EQUIPEMENT_OA.DATE_DPR IS 'Date MS DPR';
COMMENT ON COLUMN EQUIPEMENT_OA.DATE_GC IS 'Date MS GC';
COMMENT ON COLUMN EQUIPEMENT_OA.COMMENTAIRE IS 'Commentaire';

-- ---------------------------------------------------------
-- Table CD_ETUDE_OA
-- ---------------------------------------------------------
CREATE TABLE CD_ETUDE_OA 
( 
	ETUDE                                   VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_ETUDE_OA IS 'Etude et Expertise';
COMMENT ON COLUMN CD_ETUDE_OA.ETUDE IS 'Etude-Expertise';

-- ---------------------------------------------------------
-- Table EVT_OA
-- ---------------------------------------------------------
CREATE TABLE EVT_OA 
( 
	CD_EVT_OA__TYPE                         VARCHAR2(25 CHAR) NOT NULL,
	DSC_OA__NUM_OA                          VARCHAR2(20 CHAR) NOT NULL,
	DATE_REL                                DATE NOT NULL,
	DATE_TRT                                DATE,
	OBSV                                    VARCHAR2(255 CHAR)
);
COMMENT ON TABLE EVT_OA IS 'Evénement';
COMMENT ON COLUMN EVT_OA.CD_EVT_OA__TYPE IS 'Type événement';
COMMENT ON COLUMN EVT_OA.DSC_OA__NUM_OA IS 'NumOA';
COMMENT ON COLUMN EVT_OA.DATE_REL IS 'Date Relevé';
COMMENT ON COLUMN EVT_OA.DATE_TRT IS 'Date Traitement';
COMMENT ON COLUMN EVT_OA.OBSV IS 'Observation';

-- ---------------------------------------------------------
-- Table CD_FAM_OA
-- ---------------------------------------------------------
CREATE TABLE CD_FAM_OA 
( 
	FAMILLE                                 VARCHAR2(20 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(60 CHAR)
);
COMMENT ON TABLE CD_FAM_OA IS 'Famille d''ouvrage';
COMMENT ON COLUMN CD_FAM_OA.FAMILLE IS 'Famille';
COMMENT ON COLUMN CD_FAM_OA.LIBELLE IS 'Libellé';

-- ---------------------------------------------------------
-- Table CD_FAM_APPUI_OA
-- ---------------------------------------------------------
CREATE TABLE CD_FAM_APPUI_OA 
( 
	FAM_APP                                 VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_FAM_APPUI_OA IS 'Familles d''appuis';
COMMENT ON COLUMN CD_FAM_APPUI_OA.FAM_APP IS 'Famille d''appuis';

-- ---------------------------------------------------------
-- Table CD_GEST_OA
-- ---------------------------------------------------------
CREATE TABLE CD_GEST_OA 
( 
	GESTIONNAIRE                            VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_GEST_OA IS 'Gestionnaire de la voirie';
COMMENT ON COLUMN CD_GEST_OA.GESTIONNAIRE IS 'Gestionnaire';

-- ---------------------------------------------------------
-- Table GRP_OA
-- ---------------------------------------------------------
CREATE TABLE GRP_OA 
( 
	ID_GRP                                  NUMBER(7) NOT NULL,
	LIBG                                    VARCHAR2(500 CHAR) NOT NULL,
	ORDRE                                   NUMBER(7) NOT NULL
);
COMMENT ON TABLE GRP_OA IS 'Groupe';
COMMENT ON COLUMN GRP_OA.ID_GRP IS 'Identifiant Groupe';
COMMENT ON COLUMN GRP_OA.LIBG IS 'Groupe';
COMMENT ON COLUMN GRP_OA.ORDRE IS 'N° Ordre';

-- ---------------------------------------------------------
-- Table CD_HIERARCHIE_OA
-- ---------------------------------------------------------
CREATE TABLE CD_HIERARCHIE_OA 
( 
	HIERARCHIE                              VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_HIERARCHIE_OA IS 'Hiérarchie';
COMMENT ON COLUMN CD_HIERARCHIE_OA.HIERARCHIE IS 'Caractère stratégique';

-- ---------------------------------------------------------
-- Table HISTO_NOTE_OA
-- ---------------------------------------------------------
CREATE TABLE HISTO_NOTE_OA 
( 
	DSC_OA__NUM_OA                          VARCHAR2(20 CHAR) NOT NULL,
	DATE_NOTE                               DATE NOT NULL,
	CD_ORIGIN_OA__ORIGINE                   VARCHAR2(20 CHAR) NOT NULL,
	NOTE_IQOA                               VARCHAR2(3 CHAR),
	NOTE1                                   NUMBER(1),
	NOTE2                                   NUMBER(1),
	NOTE3                                   NUMBER(1),
	URGENCE                                 VARCHAR2(5 CHAR),
	SECURITE                                NUMBER,
	PRIORITAIRE                             NUMBER NOT NULL
);
COMMENT ON TABLE HISTO_NOTE_OA IS 'Historique note';
COMMENT ON COLUMN HISTO_NOTE_OA.DSC_OA__NUM_OA IS 'NumOA';
COMMENT ON COLUMN HISTO_NOTE_OA.DATE_NOTE IS 'Date Note';
COMMENT ON COLUMN HISTO_NOTE_OA.CD_ORIGIN_OA__ORIGINE IS 'Origine';
COMMENT ON COLUMN HISTO_NOTE_OA.NOTE_IQOA IS 'Note IQOA';
COMMENT ON COLUMN HISTO_NOTE_OA.NOTE1 IS 'Note Appuis';
COMMENT ON COLUMN HISTO_NOTE_OA.NOTE2 IS 'Note Tablier';
COMMENT ON COLUMN HISTO_NOTE_OA.NOTE3 IS 'Note Equipement';
COMMENT ON COLUMN HISTO_NOTE_OA.URGENCE IS 'Niveau Urgence';
COMMENT ON COLUMN HISTO_NOTE_OA.SECURITE IS 'Problème de sécurité';
COMMENT ON COLUMN HISTO_NOTE_OA.PRIORITAIRE IS 'Urgence Traitement';

-- ---------------------------------------------------------
-- Table DSC_CAMP_OA
-- ---------------------------------------------------------
CREATE TABLE DSC_CAMP_OA 
( 
	DSC_OA__NUM_OA                          VARCHAR2(20 CHAR) NOT NULL,
	CAMP_OA__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	REALISER                                NUMBER
);
COMMENT ON TABLE DSC_CAMP_OA IS 'Historique Surveillances';
COMMENT ON COLUMN DSC_CAMP_OA.DSC_OA__NUM_OA IS 'NumOA';
COMMENT ON COLUMN DSC_CAMP_OA.CAMP_OA__ID_CAMP IS 'Identifiant campagne';
COMMENT ON COLUMN DSC_CAMP_OA.REALISER IS 'Contrôle réalisé';

-- ---------------------------------------------------------
-- Table INSPECTEUR_OA
-- ---------------------------------------------------------
CREATE TABLE INSPECTEUR_OA 
( 
	NOM                                     VARCHAR2(60 CHAR) NOT NULL,
	CD_PRESTA_OA__PRESTATAIRE               VARCHAR2(50 CHAR) NOT NULL,
	FONC                                    VARCHAR2(60 CHAR)
);
COMMENT ON TABLE INSPECTEUR_OA IS 'Inspecteur';
COMMENT ON COLUMN INSPECTEUR_OA.NOM IS 'Nom inspecteur';
COMMENT ON COLUMN INSPECTEUR_OA.CD_PRESTA_OA__PRESTATAIRE IS 'Prestataire';
COMMENT ON COLUMN INSPECTEUR_OA.FONC IS 'Fonction';

-- ---------------------------------------------------------
-- Table INSP_OA
-- ---------------------------------------------------------
CREATE TABLE INSP_OA 
( 
	CAMP_OA__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	DSC_OA__NUM_OA                          VARCHAR2(20 CHAR) NOT NULL,
	CD_METEO_OA__METEO                      VARCHAR2(60 CHAR),
	CD_IQOA_OA__NOTE_IQOA                   VARCHAR2(3 CHAR) NOT NULL,
	INSPECTEUR_OA__NOM                      VARCHAR2(60 CHAR),
	CD_ETUDE_OA__ETUDE                      VARCHAR2(60 CHAR),
	ETAT                                    VARCHAR2(25 CHAR) NOT NULL,
	DATEV                                   DATE,
	TEMPERATURE                             NUMBER(4,2),
	MOYEN                                   VARCHAR2(500 CHAR),
	CONDITIONS                              VARCHAR2(500 CHAR),
	DATE_VALID                              DATE,
	NOM_VALID                               VARCHAR2(255 CHAR),
	DESC_INVA                               VARCHAR2(1000 CHAR),
	PRIORITAIRE                             VARCHAR2(1000 CHAR),
	SECURITE                                VARCHAR2(1000 CHAR),
	NOTE1                                   NUMBER(1),
	NOTE2                                   NUMBER(1),
	NOTE3                                   NUMBER(1),
	URGENCE                                 VARCHAR2(5 CHAR),
	QUALITE                                 VARCHAR2(25 CHAR)
);
COMMENT ON TABLE INSP_OA IS 'Inspection';
COMMENT ON COLUMN INSP_OA.CAMP_OA__ID_CAMP IS 'Identifiant campagne';
COMMENT ON COLUMN INSP_OA.DSC_OA__NUM_OA IS 'NumOA';
COMMENT ON COLUMN INSP_OA.CD_METEO_OA__METEO IS 'Condition météo';
COMMENT ON COLUMN INSP_OA.CD_IQOA_OA__NOTE_IQOA IS 'Note IQOA';
COMMENT ON COLUMN INSP_OA.INSPECTEUR_OA__NOM IS 'Nom inspecteur';
COMMENT ON COLUMN INSP_OA.CD_ETUDE_OA__ETUDE IS 'Etude-Expertise';
COMMENT ON COLUMN INSP_OA.ETAT IS 'Statut visite';
COMMENT ON COLUMN INSP_OA.DATEV IS 'Date de visite';
COMMENT ON COLUMN INSP_OA.TEMPERATURE IS 'Température';
COMMENT ON COLUMN INSP_OA.MOYEN IS 'Moyens utilisés';
COMMENT ON COLUMN INSP_OA.CONDITIONS IS 'Conditions particulières';
COMMENT ON COLUMN INSP_OA.DATE_VALID IS 'Date validation';
COMMENT ON COLUMN INSP_OA.NOM_VALID IS 'Nom valideur';
COMMENT ON COLUMN INSP_OA.DESC_INVA IS 'Description invalide';
COMMENT ON COLUMN INSP_OA.PRIORITAIRE IS 'Urgence traitement';
COMMENT ON COLUMN INSP_OA.SECURITE IS 'Problème de sécurité';
COMMENT ON COLUMN INSP_OA.NOTE1 IS 'Appuis-Fondations';
COMMENT ON COLUMN INSP_OA.NOTE2 IS 'Tabliers';
COMMENT ON COLUMN INSP_OA.NOTE3 IS 'Equipements';
COMMENT ON COLUMN INSP_OA.URGENCE IS 'Niveau urgence';
COMMENT ON COLUMN INSP_OA.QUALITE IS 'Image qualité';

-- ---------------------------------------------------------
-- Table INSP_TMP_OA
-- ---------------------------------------------------------
CREATE TABLE INSP_TMP_OA 
( 
	CAMP_OA__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	DSC_TEMP_OA__NUM_OA                     VARCHAR2(20 CHAR) NOT NULL,
	CD_IQOA_OA__NOTE_IQOA                   VARCHAR2(3 CHAR) NOT NULL,
	CD_METEO_OA__METEO                      VARCHAR2(60 CHAR),
	CD_ETUDE_OA__ETUDE                      VARCHAR2(60 CHAR),
	INSPECTEUR_OA__NOM                      VARCHAR2(60 CHAR),
	ETAT                                    VARCHAR2(25 CHAR) NOT NULL,
	DATEV                                   DATE,
	TEMPERATURE                             NUMBER(4,2),
	MOYEN                                   VARCHAR2(500 CHAR),
	CONDITIONS                              VARCHAR2(500 CHAR),
	DATE_VALID                              DATE,
	NOM_VALID                               VARCHAR2(255 CHAR),
	DESC_INVA                               VARCHAR2(1000 CHAR),
	PRIORITAIRE                             VARCHAR2(1000 CHAR),
	SECURITE                                VARCHAR2(1000 CHAR),
	NOTE1                                   NUMBER(1),
	NOTE2                                   NUMBER(1),
	NOTE3                                   NUMBER(1),
	URGENCE                                 VARCHAR2(5 CHAR),
	QUALITE                                 VARCHAR2(25 CHAR)
);
COMMENT ON TABLE INSP_TMP_OA IS 'Inspection temporaire';
COMMENT ON COLUMN INSP_TMP_OA.CAMP_OA__ID_CAMP IS 'Identifiant campagne';
COMMENT ON COLUMN INSP_TMP_OA.DSC_TEMP_OA__NUM_OA IS 'NumOA';
COMMENT ON COLUMN INSP_TMP_OA.CD_IQOA_OA__NOTE_IQOA IS 'Note IQOA';
COMMENT ON COLUMN INSP_TMP_OA.CD_METEO_OA__METEO IS 'Condition météo';
COMMENT ON COLUMN INSP_TMP_OA.CD_ETUDE_OA__ETUDE IS 'Etude-Expertise';
COMMENT ON COLUMN INSP_TMP_OA.INSPECTEUR_OA__NOM IS 'Nom inspecteur';
COMMENT ON COLUMN INSP_TMP_OA.ETAT IS 'Statut visite';
COMMENT ON COLUMN INSP_TMP_OA.DATEV IS 'Date de visite';
COMMENT ON COLUMN INSP_TMP_OA.TEMPERATURE IS 'Température';
COMMENT ON COLUMN INSP_TMP_OA.MOYEN IS 'Moyens utilisés';
COMMENT ON COLUMN INSP_TMP_OA.CONDITIONS IS 'Conditions particulières';
COMMENT ON COLUMN INSP_TMP_OA.DATE_VALID IS 'Date validation';
COMMENT ON COLUMN INSP_TMP_OA.NOM_VALID IS 'Nom valideur';
COMMENT ON COLUMN INSP_TMP_OA.DESC_INVA IS 'Description invalide';
COMMENT ON COLUMN INSP_TMP_OA.PRIORITAIRE IS 'Urgence traitement';
COMMENT ON COLUMN INSP_TMP_OA.SECURITE IS 'Problème de sécurité';
COMMENT ON COLUMN INSP_TMP_OA.NOTE1 IS 'Appuis-Fondations';
COMMENT ON COLUMN INSP_TMP_OA.NOTE2 IS 'Tabliers';
COMMENT ON COLUMN INSP_TMP_OA.NOTE3 IS 'Equipements';
COMMENT ON COLUMN INSP_TMP_OA.URGENCE IS 'Niveau urgence';
COMMENT ON COLUMN INSP_TMP_OA.QUALITE IS 'Image qualité';

-- ---------------------------------------------------------
-- Table JOINT_OA
-- ---------------------------------------------------------
CREATE TABLE JOINT_OA 
( 
	DSC_OA__NUM_OA                          VARCHAR2(20 CHAR) NOT NULL,
	TABLIER_OA__NUM_TAB                     NUMBER(1) NOT NULL,
	NUM_JOINT                               NUMBER(2) NOT NULL,
	CD_JOINT_OA__TYPE                       VARCHAR2(60 CHAR) NOT NULL,
	DATE_MS                                 DATE,
	LONGUEUR                                NUMBER(4,2),
	COMMENTAIRE                             VARCHAR2(255 CHAR)
);
COMMENT ON TABLE JOINT_OA IS 'Joints de chaussées';
COMMENT ON COLUMN JOINT_OA.DSC_OA__NUM_OA IS 'NumOA';
COMMENT ON COLUMN JOINT_OA.TABLIER_OA__NUM_TAB IS 'N° Tablier';
COMMENT ON COLUMN JOINT_OA.NUM_JOINT IS 'N° joint';
COMMENT ON COLUMN JOINT_OA.CD_JOINT_OA__TYPE IS 'Joint';
COMMENT ON COLUMN JOINT_OA.DATE_MS IS 'Date de MS';
COMMENT ON COLUMN JOINT_OA.LONGUEUR IS 'Longueur joint';
COMMENT ON COLUMN JOINT_OA.COMMENTAIRE IS 'Commentaire';

-- ---------------------------------------------------------
-- Table CD_LIGNE_OA
-- ---------------------------------------------------------
CREATE TABLE CD_LIGNE_OA 
( 
	CD_CHAPITRE_OA__ID_CHAP                 NUMBER(7) NOT NULL,
	ID_LIGNE                                NUMBER(7) NOT NULL,
	LIBELLE                                 VARCHAR2(500 CHAR) NOT NULL,
	ORDRE_LIGNE                             NUMBER(7) NOT NULL
);
COMMENT ON TABLE CD_LIGNE_OA IS 'Ligne';
COMMENT ON COLUMN CD_LIGNE_OA.CD_CHAPITRE_OA__ID_CHAP IS 'Identifiant chapitre';
COMMENT ON COLUMN CD_LIGNE_OA.ID_LIGNE IS 'Identifiant ligne';
COMMENT ON COLUMN CD_LIGNE_OA.LIBELLE IS 'Libellé Ligne';
COMMENT ON COLUMN CD_LIGNE_OA.ORDRE_LIGNE IS 'N° ordre ligne';

-- ---------------------------------------------------------
-- Table CD_MO_OA
-- ---------------------------------------------------------
CREATE TABLE CD_MO_OA 
( 
	MAITRE_OUVR                             VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_MO_OA IS 'Maitre d''ouvrage';
COMMENT ON COLUMN CD_MO_OA.MAITRE_OUVR IS 'Maitre d''ouvrage';

-- ---------------------------------------------------------
-- Table CD_MAT_OA
-- ---------------------------------------------------------
CREATE TABLE CD_MAT_OA 
( 
	MATERIAUX                               VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_MAT_OA IS 'Matériaux';
COMMENT ON COLUMN CD_MAT_OA.MATERIAUX IS 'Matériaux';

-- ---------------------------------------------------------
-- Table CD_METEO_OA
-- ---------------------------------------------------------
CREATE TABLE CD_METEO_OA 
( 
	METEO                                   VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_METEO_OA IS 'Météo';
COMMENT ON COLUMN CD_METEO_OA.METEO IS 'Condition météo';

-- ---------------------------------------------------------
-- Table NATURE_TRAV_OA
-- ---------------------------------------------------------
CREATE TABLE NATURE_TRAV_OA 
( 
	CD_TRAVAUX_OA__CODE                     VARCHAR2(60 CHAR) NOT NULL,
	NATURE                                  VARCHAR2(100 CHAR) NOT NULL
);
COMMENT ON TABLE NATURE_TRAV_OA IS 'Nature travaux';
COMMENT ON COLUMN NATURE_TRAV_OA.CD_TRAVAUX_OA__CODE IS 'Type Travaux';
COMMENT ON COLUMN NATURE_TRAV_OA.NATURE IS 'Nature travaux';

-- ---------------------------------------------------------
-- Table CD_OCCUPANT_OA
-- ---------------------------------------------------------
CREATE TABLE CD_OCCUPANT_OA 
( 
	NOM                                     VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_OCCUPANT_OA IS 'Occupant';
COMMENT ON COLUMN CD_OCCUPANT_OA.NOM IS 'Nom occupant';

-- ---------------------------------------------------------
-- Table OCCUPATION_OA
-- ---------------------------------------------------------
CREATE TABLE OCCUPATION_OA 
( 
	DSC_OA__NUM_OA                          VARCHAR2(20 CHAR) NOT NULL,
	CD_OCCUPANT_OA__NOM                     VARCHAR2(60 CHAR) NOT NULL,
	CD_OCCUP_OA__TYPE                       VARCHAR2(60 CHAR) NOT NULL,
	DATE_MS                                 DATE,
	DATE_FV                                 DATE,
	TRAV                                    NUMBER,
	NUM_CONV                                VARCHAR2(60 CHAR),
	OBSERV                                  VARCHAR2(255 CHAR)
);
COMMENT ON TABLE OCCUPATION_OA IS 'Occupations';
COMMENT ON COLUMN OCCUPATION_OA.DSC_OA__NUM_OA IS 'NumOA';
COMMENT ON COLUMN OCCUPATION_OA.CD_OCCUPANT_OA__NOM IS 'Nom occupant';
COMMENT ON COLUMN OCCUPATION_OA.CD_OCCUP_OA__TYPE IS 'Type Occupation';
COMMENT ON COLUMN OCCUPATION_OA.DATE_MS IS 'Date Début';
COMMENT ON COLUMN OCCUPATION_OA.DATE_FV IS 'Date Fin';
COMMENT ON COLUMN OCCUPATION_OA.TRAV IS 'Traversé';
COMMENT ON COLUMN OCCUPATION_OA.NUM_CONV IS 'N° convention';
COMMENT ON COLUMN OCCUPATION_OA.OBSERV IS 'Commentaires';

-- ---------------------------------------------------------
-- Table CD_ORIGIN_OA
-- ---------------------------------------------------------
CREATE TABLE CD_ORIGIN_OA 
( 
	ORIGINE                                 VARCHAR2(20 CHAR) NOT NULL
);
COMMENT ON TABLE CD_ORIGIN_OA IS 'Origine Note IQOA';
COMMENT ON COLUMN CD_ORIGIN_OA.ORIGINE IS 'Origine';

-- ---------------------------------------------------------
-- Table DSC_OA
-- ---------------------------------------------------------
CREATE TABLE DSC_OA 
( 
	LIAISON                                 VARCHAR2(15 CHAR) NOT NULL,
	SENS                                    VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	ABS_FIN                                 NUMBER(6),
	NUM_OA                                  VARCHAR2(20 CHAR) NOT NULL,
	NUM_EXPLOIT                             VARCHAR2(30 CHAR),
	NOM_USAGE                               VARCHAR2(255 CHAR),
	CD_FAM_OA__FAMILLE                      VARCHAR2(20 CHAR) NOT NULL,
	CD_TYPE_OA__TYPE                        VARCHAR2(20 CHAR) NOT NULL,
	VPF                                     VARCHAR2(60 CHAR),
	DATE_MS                                 DATE,
	CD_TABLIER_OA__TABLIER                  VARCHAR2(60 CHAR),
	NBPILESINTER                            NUMBER(2),
	LONG_MAX_TRAV                           NUMBER(5,2),
	GAB_MINI                                NUMBER(5,2),
	GAB_GRA                                 NUMBER,
	CD_GEST_OA__GESTIONNAIRE                VARCHAR2(60 CHAR),
	CD_ENTP_OA__ENTREPRISE                  VARCHAR2(60 CHAR),
	CD_BE_OA__BUREAU                        VARCHAR2(60 CHAR),
	CD_MO_OA__MAITRE_OUVR                   VARCHAR2(60 CHAR),
	CD_CHARGE_OA__SURCHARGE                 VARCHAR2(60 CHAR),
	NOTE1                                   NUMBER(1),
	NOTE2                                   NUMBER(1),
	NOTE3                                   NUMBER(1),
	URGENCE                                 VARCHAR2(5 CHAR),
	DESC_INVA                               VARCHAR2(1000 CHAR),
	PRIORITAIRE                             NUMBER,
	PROSURV_ANNEE                           NUMBER(4),
	DERN_INSP                               DATE,
	CD_FOND_OA__TYPE                        VARCHAR2(60 CHAR),
	SISMICITE                               NUMBER,
	IMMERGE                                 NUMBER,
	CD_MAT_OA__MATERIAUX                    VARCHAR2(60 CHAR),
	DEVIATION                               NUMBER(5,2),
	TRAVURE                                 NUMBER(2),
	BIAIS                                   NUMBER(3),
	LONG_BIAISE                             NUMBER(6,2),
	LARG_BIAISE                             NUMBER(4,2),
	LARG_TRAV                               NUMBER(4,2),
	LARG_GS                                 NUMBER(4,2),
	SURF_TABLIER                            NUMBER(8,2),
	DALLE                                   NUMBER,
	CORN                                    NUMBER,
	LANTERNEAU                              NUMBER,
	EQUIP_VST                               NUMBER,
	TRAFIC_VPF                              NUMBER(6),
	SURF_VPF                                NUMBER(8,2),
	CD_QUALITE_OA__QUALITE                  VARCHAR2(25 CHAR),
	ARCHIVE                                 VARCHAR2(255 CHAR),
	COMMENTAIRE                             VARCHAR2(1000 CHAR),
	CD_IQOA_OA__NOTE_IQOA                   VARCHAR2(3 CHAR),
	CD_HIERARCHIE_OA__HIERARCHIE            VARCHAR2(60 CHAR),
	DATE_CONST                              DATE,
	DERN_VST                                DATE,
	NOTE_VST                                VARCHAR2(5 CHAR),
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
COMMENT ON TABLE DSC_OA IS 'Ouvrages d''Art';
COMMENT ON COLUMN DSC_OA.LIAISON IS 'Liaison';
COMMENT ON COLUMN DSC_OA.SENS IS 'Sens';
COMMENT ON COLUMN DSC_OA.ABS_DEB IS 'PR début';
COMMENT ON COLUMN DSC_OA.ABS_FIN IS 'PR Fin';
COMMENT ON COLUMN DSC_OA.NUM_OA IS 'NumOA';
COMMENT ON COLUMN DSC_OA.NUM_EXPLOIT IS 'N° d''exploitation';
COMMENT ON COLUMN DSC_OA.NOM_USAGE IS 'Nom d''usage';
COMMENT ON COLUMN DSC_OA.CD_FAM_OA__FAMILLE IS 'Famille';
COMMENT ON COLUMN DSC_OA.CD_TYPE_OA__TYPE IS 'Type';
COMMENT ON COLUMN DSC_OA.VPF IS 'Voie portée ou franchie';
COMMENT ON COLUMN DSC_OA.DATE_MS IS 'Date MS';
COMMENT ON COLUMN DSC_OA.CD_TABLIER_OA__TABLIER IS 'Type tablier';
COMMENT ON COLUMN DSC_OA.NBPILESINTER IS 'Nb piles intermédiaires';
COMMENT ON COLUMN DSC_OA.LONG_MAX_TRAV IS 'Long max travée (m)';
COMMENT ON COLUMN DSC_OA.GAB_MINI IS 'Gabarit (m)';
COMMENT ON COLUMN DSC_OA.GAB_GRA IS 'Gabarit GRA';
COMMENT ON COLUMN DSC_OA.CD_GEST_OA__GESTIONNAIRE IS 'Gestionnaire';
COMMENT ON COLUMN DSC_OA.CD_ENTP_OA__ENTREPRISE IS 'Entreprise';
COMMENT ON COLUMN DSC_OA.CD_BE_OA__BUREAU IS 'Bureau d''étude';
COMMENT ON COLUMN DSC_OA.CD_MO_OA__MAITRE_OUVR IS 'Maitre d''ouvrage';
COMMENT ON COLUMN DSC_OA.CD_CHARGE_OA__SURCHARGE IS 'Surcharge';
COMMENT ON COLUMN DSC_OA.NOTE1 IS 'Note Appuis / Fondations';
COMMENT ON COLUMN DSC_OA.NOTE2 IS 'Note Tabliers';
COMMENT ON COLUMN DSC_OA.NOTE3 IS 'Note Equipement';
COMMENT ON COLUMN DSC_OA.URGENCE IS 'Niveau Urgence';
COMMENT ON COLUMN DSC_OA.DESC_INVA IS 'Description invalide';
COMMENT ON COLUMN DSC_OA.PRIORITAIRE IS 'Urgence Traitement';
COMMENT ON COLUMN DSC_OA.PROSURV_ANNEE IS 'Prochaine Inspection';
COMMENT ON COLUMN DSC_OA.DERN_INSP IS 'Dernière Inspection';
COMMENT ON COLUMN DSC_OA.CD_FOND_OA__TYPE IS 'Fondation';
COMMENT ON COLUMN DSC_OA.SISMICITE IS 'Sismicité';
COMMENT ON COLUMN DSC_OA.IMMERGE IS 'Fondation immergé';
COMMENT ON COLUMN DSC_OA.CD_MAT_OA__MATERIAUX IS 'Matériaux';
COMMENT ON COLUMN DSC_OA.DEVIATION IS 'Longueur déviation (km)';
COMMENT ON COLUMN DSC_OA.TRAVURE IS 'Nombre de travée';
COMMENT ON COLUMN DSC_OA.BIAIS IS 'Biais (grad)';
COMMENT ON COLUMN DSC_OA.LONG_BIAISE IS 'Longueur biaise (m)';
COMMENT ON COLUMN DSC_OA.LARG_BIAISE IS 'Largeur entre bordure (m)';
COMMENT ON COLUMN DSC_OA.LARG_TRAV IS 'Largeur droite (m)';
COMMENT ON COLUMN DSC_OA.LARG_GS IS 'Largeur entre GS (m)';
COMMENT ON COLUMN DSC_OA.SURF_TABLIER IS 'Surface tablier (m²)';
COMMENT ON COLUMN DSC_OA.DALLE IS 'Dalle de transition';
COMMENT ON COLUMN DSC_OA.CORN IS 'Corniche';
COMMENT ON COLUMN DSC_OA.LANTERNEAU IS 'Lanterneau';
COMMENT ON COLUMN DSC_OA.EQUIP_VST IS 'Equipement de visite';
COMMENT ON COLUMN DSC_OA.TRAFIC_VPF IS 'Trafic Voie portée';
COMMENT ON COLUMN DSC_OA.SURF_VPF IS 'Surf voie (m²)';
COMMENT ON COLUMN DSC_OA.CD_QUALITE_OA__QUALITE IS 'Niveau qualité';
COMMENT ON COLUMN DSC_OA.ARCHIVE IS 'Archive';
COMMENT ON COLUMN DSC_OA.COMMENTAIRE IS 'Commentaire';
COMMENT ON COLUMN DSC_OA.CD_IQOA_OA__NOTE_IQOA IS 'Note IQOA';
COMMENT ON COLUMN DSC_OA.CD_HIERARCHIE_OA__HIERARCHIE IS 'Caractère stratégique';
COMMENT ON COLUMN DSC_OA.DATE_CONST IS 'Date construction';
COMMENT ON COLUMN DSC_OA.DERN_VST IS 'Dernière Visite';
COMMENT ON COLUMN DSC_OA.NOTE_VST IS 'Note Visite';
COMMENT ON COLUMN DSC_OA.SECURITE IS 'Problème de sécurité';
COMMENT ON COLUMN DSC_OA.X1 IS 'X1';
COMMENT ON COLUMN DSC_OA.Y1 IS 'Y1';
COMMENT ON COLUMN DSC_OA.Z1 IS 'Z1';
COMMENT ON COLUMN DSC_OA.X2 IS 'X2';
COMMENT ON COLUMN DSC_OA.Y2 IS 'Y2';
COMMENT ON COLUMN DSC_OA.Z2 IS 'Z2';
COMMENT ON COLUMN DSC_OA.DATE_RELEVE IS 'Date relevé';
COMMENT ON COLUMN DSC_OA.TERRAIN IS 'Terrain';

-- ---------------------------------------------------------
-- Table DSC_TEMP_OA
-- ---------------------------------------------------------
CREATE TABLE DSC_TEMP_OA 
( 
	CAMP_OA__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	NUM_OA                                  VARCHAR2(20 CHAR) NOT NULL,
	CD_BE_OA__BUREAU                        VARCHAR2(60 CHAR),
	CD_GEST_OA__GESTIONNAIRE                VARCHAR2(60 CHAR),
	CD_CHARGE_OA__SURCHARGE                 VARCHAR2(60 CHAR),
	CD_TYPE_OA__TYPE                        VARCHAR2(20 CHAR) NOT NULL,
	DSC_OA__NUM_OA                          VARCHAR2(20 CHAR),
	CD_ENTP_OA__ENTREPRISE                  VARCHAR2(60 CHAR),
	CD_TABLIER_OA__TABLIER                  VARCHAR2(60 CHAR),
	CD_FOND_OA__TYPE                        VARCHAR2(60 CHAR),
	CD_MAT_OA__MATERIAUX                    VARCHAR2(60 CHAR),
	CD_MO_OA__MAITRE_OUVR                   VARCHAR2(60 CHAR),
	CD_FAM_OA__FAMILLE                      VARCHAR2(20 CHAR) NOT NULL,
	LIAISON                                 VARCHAR2(15 CHAR) NOT NULL,
	SENS                                    VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	ABS_FIN                                 NUMBER(6),
	NUM_EXPLOIT                             VARCHAR2(30 CHAR),
	NOM_USAGE                               VARCHAR2(255 CHAR),
	DATE_CONST                              DATE,
	DATE_MS                                 DATE,
	VPF                                     VARCHAR2(60 CHAR),
	TRAFIC_VPF                              NUMBER(6),
	DEVIATION                               NUMBER(5,2),
	NBPILESINTER                            NUMBER(2),
	TRAVURE                                 NUMBER(2),
	LONG_MAX_TRAV                           NUMBER(5,2),
	GAB_MINI                                NUMBER(5,2),
	GAB_GRA                                 NUMBER,
	BIAIS                                   NUMBER(3),
	LONG_BIAISE                             NUMBER(6,2),
	LARG_TRAV                               NUMBER(4,2),
	LARG_BIAISE                             NUMBER(4,2),
	LARG_GS                                 NUMBER(4,2),
	SURF_TABLIER                            NUMBER(8,2),
	SURF_VPF                                NUMBER(8,2),
	IMMERGE                                 NUMBER,
	SISMICITE                               NUMBER,
	DALLE                                   NUMBER,
	CORN                                    NUMBER,
	LANTERNEAU                              NUMBER,
	EQUIP_VST                               NUMBER,
	NOTE1                                   NUMBER(1),
	NOTE2                                   NUMBER(1),
	NOTE3                                   NUMBER(1),
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
COMMENT ON TABLE DSC_TEMP_OA IS 'Ouvrages d''Art temporaire';
COMMENT ON COLUMN DSC_TEMP_OA.CAMP_OA__ID_CAMP IS 'Identifiant campagne';
COMMENT ON COLUMN DSC_TEMP_OA.NUM_OA IS 'NumOA';
COMMENT ON COLUMN DSC_TEMP_OA.CD_BE_OA__BUREAU IS 'Bureau d''étude';
COMMENT ON COLUMN DSC_TEMP_OA.CD_GEST_OA__GESTIONNAIRE IS 'Gestionnaire';
COMMENT ON COLUMN DSC_TEMP_OA.CD_CHARGE_OA__SURCHARGE IS 'Surcharge';
COMMENT ON COLUMN DSC_TEMP_OA.CD_TYPE_OA__TYPE IS 'Type';
COMMENT ON COLUMN DSC_TEMP_OA.DSC_OA__NUM_OA IS 'NumOA2';
COMMENT ON COLUMN DSC_TEMP_OA.CD_ENTP_OA__ENTREPRISE IS 'Entreprise';
COMMENT ON COLUMN DSC_TEMP_OA.CD_TABLIER_OA__TABLIER IS 'Type tablier';
COMMENT ON COLUMN DSC_TEMP_OA.CD_FOND_OA__TYPE IS 'Fondation';
COMMENT ON COLUMN DSC_TEMP_OA.CD_MAT_OA__MATERIAUX IS 'Matériaux';
COMMENT ON COLUMN DSC_TEMP_OA.CD_MO_OA__MAITRE_OUVR IS 'Maitre d''ouvrage';
COMMENT ON COLUMN DSC_TEMP_OA.CD_FAM_OA__FAMILLE IS 'Famille';
COMMENT ON COLUMN DSC_TEMP_OA.LIAISON IS 'Liaison';
COMMENT ON COLUMN DSC_TEMP_OA.SENS IS 'Sens';
COMMENT ON COLUMN DSC_TEMP_OA.ABS_DEB IS 'PR début';
COMMENT ON COLUMN DSC_TEMP_OA.ABS_FIN IS 'PR Fin';
COMMENT ON COLUMN DSC_TEMP_OA.NUM_EXPLOIT IS 'N° d''exploitation';
COMMENT ON COLUMN DSC_TEMP_OA.NOM_USAGE IS 'Nom d''usage';
COMMENT ON COLUMN DSC_TEMP_OA.DATE_CONST IS 'Date construction';
COMMENT ON COLUMN DSC_TEMP_OA.DATE_MS IS 'Date MS';
COMMENT ON COLUMN DSC_TEMP_OA.VPF IS 'Voie portée ou franchie';
COMMENT ON COLUMN DSC_TEMP_OA.TRAFIC_VPF IS 'Trafic Voie portée';
COMMENT ON COLUMN DSC_TEMP_OA.DEVIATION IS 'Longueur déviation (km)';
COMMENT ON COLUMN DSC_TEMP_OA.NBPILESINTER IS 'Nb piles intermédiaires';
COMMENT ON COLUMN DSC_TEMP_OA.TRAVURE IS 'Nombre de travée';
COMMENT ON COLUMN DSC_TEMP_OA.LONG_MAX_TRAV IS 'Long max travée (m)';
COMMENT ON COLUMN DSC_TEMP_OA.GAB_MINI IS 'Gabarit (m)';
COMMENT ON COLUMN DSC_TEMP_OA.GAB_GRA IS 'Gabarit GRA';
COMMENT ON COLUMN DSC_TEMP_OA.BIAIS IS 'Biais (grad)';
COMMENT ON COLUMN DSC_TEMP_OA.LONG_BIAISE IS 'Longueur biaise (m)';
COMMENT ON COLUMN DSC_TEMP_OA.LARG_TRAV IS 'Largeur droite (m)';
COMMENT ON COLUMN DSC_TEMP_OA.LARG_BIAISE IS 'Largeur entre bordure (m)';
COMMENT ON COLUMN DSC_TEMP_OA.LARG_GS IS 'Largeur entre GS (m)';
COMMENT ON COLUMN DSC_TEMP_OA.SURF_TABLIER IS 'Surface tablier (m²)';
COMMENT ON COLUMN DSC_TEMP_OA.SURF_VPF IS 'Surf voie (m²)';
COMMENT ON COLUMN DSC_TEMP_OA.IMMERGE IS 'Fondation immergé';
COMMENT ON COLUMN DSC_TEMP_OA.SISMICITE IS 'Sismicité';
COMMENT ON COLUMN DSC_TEMP_OA.DALLE IS 'Dalle de transition';
COMMENT ON COLUMN DSC_TEMP_OA.CORN IS 'Corniche';
COMMENT ON COLUMN DSC_TEMP_OA.LANTERNEAU IS 'Lanterneau';
COMMENT ON COLUMN DSC_TEMP_OA.EQUIP_VST IS 'Equipement de visite';
COMMENT ON COLUMN DSC_TEMP_OA.NOTE1 IS 'Note Appuis / Fondations';
COMMENT ON COLUMN DSC_TEMP_OA.NOTE2 IS 'Note Tabliers';
COMMENT ON COLUMN DSC_TEMP_OA.NOTE3 IS 'Note Equipement';
COMMENT ON COLUMN DSC_TEMP_OA.URGENCE IS 'Niveau Urgence';
COMMENT ON COLUMN DSC_TEMP_OA.DESC_INVA IS 'Description invalide';
COMMENT ON COLUMN DSC_TEMP_OA.SECURITE IS 'Problème de sécurité';
COMMENT ON COLUMN DSC_TEMP_OA.PRIORITAIRE IS 'Urgence Traitement';
COMMENT ON COLUMN DSC_TEMP_OA.PROSURV_ANNEE IS 'Prochaine Inspection';
COMMENT ON COLUMN DSC_TEMP_OA.DERN_INSP IS 'Dernière Inspection';
COMMENT ON COLUMN DSC_TEMP_OA.DERN_VST IS 'Dernière Visite';
COMMENT ON COLUMN DSC_TEMP_OA.NOTE_VST IS 'Note Visite';
COMMENT ON COLUMN DSC_TEMP_OA.ARCHIVE IS 'Archive';
COMMENT ON COLUMN DSC_TEMP_OA.COMMENTAIRE IS 'Commentaire';
COMMENT ON COLUMN DSC_TEMP_OA.X1 IS 'X1';
COMMENT ON COLUMN DSC_TEMP_OA.Y1 IS 'Y1';
COMMENT ON COLUMN DSC_TEMP_OA.Z1 IS 'Z1';
COMMENT ON COLUMN DSC_TEMP_OA.X2 IS 'X2';
COMMENT ON COLUMN DSC_TEMP_OA.Y2 IS 'Y2';
COMMENT ON COLUMN DSC_TEMP_OA.Z2 IS 'Z2';
COMMENT ON COLUMN DSC_TEMP_OA.DATE_RELEVE IS 'Date relevé';
COMMENT ON COLUMN DSC_TEMP_OA.TERRAIN IS 'Terrain';

-- ---------------------------------------------------------
-- Table PRT_OA
-- ---------------------------------------------------------
CREATE TABLE PRT_OA 
( 
	GRP_OA__ID_GRP                          NUMBER(7) NOT NULL,
	ID_PRT                                  NUMBER(7) NOT NULL,
	LIBP                                    VARCHAR2(500 CHAR) NOT NULL,
	ORDRE                                   NUMBER(7) NOT NULL
);
COMMENT ON TABLE PRT_OA IS 'Partie';
COMMENT ON COLUMN PRT_OA.GRP_OA__ID_GRP IS 'Identifiant Groupe';
COMMENT ON COLUMN PRT_OA.ID_PRT IS 'Identifiant Partie';
COMMENT ON COLUMN PRT_OA.LIBP IS 'Partie';
COMMENT ON COLUMN PRT_OA.ORDRE IS 'No Ordre';

-- ---------------------------------------------------------
-- Table PHOTO_INSP_OA
-- ---------------------------------------------------------
CREATE TABLE PHOTO_INSP_OA 
( 
	ID                                      VARCHAR2(30 CHAR) NOT NULL,
	DSC_OA__NUM_OA                          VARCHAR2(20 CHAR) NOT NULL,
	CAMP_OA__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	COMMENTAIRE                             VARCHAR2(100 CHAR)
);
COMMENT ON TABLE PHOTO_INSP_OA IS 'Photo de l''ouvrage';
COMMENT ON COLUMN PHOTO_INSP_OA.ID IS 'Identifiant';
COMMENT ON COLUMN PHOTO_INSP_OA.DSC_OA__NUM_OA IS 'NumOA';
COMMENT ON COLUMN PHOTO_INSP_OA.CAMP_OA__ID_CAMP IS 'Identifiant campagne';
COMMENT ON COLUMN PHOTO_INSP_OA.COMMENTAIRE IS 'Commentaire';

-- ---------------------------------------------------------
-- Table PHOTO_INSP_TMP_OA
-- ---------------------------------------------------------
CREATE TABLE PHOTO_INSP_TMP_OA 
( 
	ID                                      VARCHAR2(30 CHAR) NOT NULL,
	CAMP_OA__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	DSC_TEMP_OA__NUM_OA                     VARCHAR2(20 CHAR) NOT NULL,
	COMMENTAIRE                             VARCHAR2(100 CHAR)
);
COMMENT ON TABLE PHOTO_INSP_TMP_OA IS 'Photo de l''ouvrage temporaire';
COMMENT ON COLUMN PHOTO_INSP_TMP_OA.ID IS 'Identifiant';
COMMENT ON COLUMN PHOTO_INSP_TMP_OA.CAMP_OA__ID_CAMP IS 'Identifiant campagne';
COMMENT ON COLUMN PHOTO_INSP_TMP_OA.DSC_TEMP_OA__NUM_OA IS 'NumOA';
COMMENT ON COLUMN PHOTO_INSP_TMP_OA.COMMENTAIRE IS 'Commentaire';

-- ---------------------------------------------------------
-- Table PHOTO_VST_OA
-- ---------------------------------------------------------
CREATE TABLE PHOTO_VST_OA 
( 
	ID                                      VARCHAR2(30 CHAR) NOT NULL,
	DSC_OA__NUM_OA                          VARCHAR2(20 CHAR) NOT NULL,
	CAMP_OA__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	COMMENTAIRE                             VARCHAR2(100 CHAR)
);
COMMENT ON TABLE PHOTO_VST_OA IS 'Photo de l''ouvrage VST';
COMMENT ON COLUMN PHOTO_VST_OA.ID IS 'Identifiant';
COMMENT ON COLUMN PHOTO_VST_OA.DSC_OA__NUM_OA IS 'NumOA';
COMMENT ON COLUMN PHOTO_VST_OA.CAMP_OA__ID_CAMP IS 'Identifiant campagne';
COMMENT ON COLUMN PHOTO_VST_OA.COMMENTAIRE IS 'Commentaire';

-- ---------------------------------------------------------
-- Table PHOTO_ELT_INSP_OA
-- ---------------------------------------------------------
CREATE TABLE PHOTO_ELT_INSP_OA 
( 
	GRP_OA__ID_GRP                          NUMBER(7) NOT NULL,
	PRT_OA__ID_PRT                          NUMBER(7) NOT NULL,
	SPRT_OA__ID_SPRT                        NUMBER(7) NOT NULL,
	DSC_OA__NUM_OA                          VARCHAR2(20 CHAR) NOT NULL,
	CAMP_OA__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	ELT_OA__ID_ELEM                         NUMBER(7) NOT NULL,
	ID                                      VARCHAR2(50 CHAR) NOT NULL,
	COMMENTAIRE                             VARCHAR2(100 CHAR)
);
COMMENT ON TABLE PHOTO_ELT_INSP_OA IS 'Photo éléments inspectés';
COMMENT ON COLUMN PHOTO_ELT_INSP_OA.GRP_OA__ID_GRP IS 'Identifiant Groupe';
COMMENT ON COLUMN PHOTO_ELT_INSP_OA.PRT_OA__ID_PRT IS 'Identifiant Partie';
COMMENT ON COLUMN PHOTO_ELT_INSP_OA.SPRT_OA__ID_SPRT IS 'Identifiant Sous Partie';
COMMENT ON COLUMN PHOTO_ELT_INSP_OA.DSC_OA__NUM_OA IS 'NumOA';
COMMENT ON COLUMN PHOTO_ELT_INSP_OA.CAMP_OA__ID_CAMP IS 'Identifiant campagne';
COMMENT ON COLUMN PHOTO_ELT_INSP_OA.ELT_OA__ID_ELEM IS 'Identifiant élément';
COMMENT ON COLUMN PHOTO_ELT_INSP_OA.ID IS 'Identifiant de la photo';
COMMENT ON COLUMN PHOTO_ELT_INSP_OA.COMMENTAIRE IS 'Commentaire';

-- ---------------------------------------------------------
-- Table PHOTO_ELT_INSP_TMP_OA
-- ---------------------------------------------------------
CREATE TABLE PHOTO_ELT_INSP_TMP_OA 
( 
	GRP_OA__ID_GRP                          NUMBER(7) NOT NULL,
	PRT_OA__ID_PRT                          NUMBER(7) NOT NULL,
	SPRT_OA__ID_SPRT                        NUMBER(7) NOT NULL,
	CAMP_OA__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	DSC_TEMP_OA__NUM_OA                     VARCHAR2(20 CHAR) NOT NULL,
	ELT_OA__ID_ELEM                         NUMBER(7) NOT NULL,
	ID                                      VARCHAR2(50 CHAR) NOT NULL,
	COMMENTAIRE                             VARCHAR2(100 CHAR)
);
COMMENT ON TABLE PHOTO_ELT_INSP_TMP_OA IS 'Photo éléments inspectés temporaire';
COMMENT ON COLUMN PHOTO_ELT_INSP_TMP_OA.GRP_OA__ID_GRP IS 'Identifiant Groupe';
COMMENT ON COLUMN PHOTO_ELT_INSP_TMP_OA.PRT_OA__ID_PRT IS 'Identifiant Partie';
COMMENT ON COLUMN PHOTO_ELT_INSP_TMP_OA.SPRT_OA__ID_SPRT IS 'Identifiant Sous Partie';
COMMENT ON COLUMN PHOTO_ELT_INSP_TMP_OA.CAMP_OA__ID_CAMP IS 'Identifiant campagne';
COMMENT ON COLUMN PHOTO_ELT_INSP_TMP_OA.DSC_TEMP_OA__NUM_OA IS 'NumOA';
COMMENT ON COLUMN PHOTO_ELT_INSP_TMP_OA.ELT_OA__ID_ELEM IS 'Identifiant élément';
COMMENT ON COLUMN PHOTO_ELT_INSP_TMP_OA.ID IS 'Identifiant de la photo';
COMMENT ON COLUMN PHOTO_ELT_INSP_TMP_OA.COMMENTAIRE IS 'Commentaire';

-- ---------------------------------------------------------
-- Table PHOTO_SPRT_VST_OA
-- ---------------------------------------------------------
CREATE TABLE PHOTO_SPRT_VST_OA 
( 
	DSC_OA__NUM_OA                          VARCHAR2(20 CHAR) NOT NULL,
	CAMP_OA__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	CD_CHAPITRE_OA__ID_CHAP                 NUMBER(7) NOT NULL,
	CD_LIGNE_OA__ID_LIGNE                   NUMBER(7) NOT NULL,
	ID                                      VARCHAR2(50 CHAR) NOT NULL,
	COMMENTAIRE                             VARCHAR2(100 CHAR)
);
COMMENT ON TABLE PHOTO_SPRT_VST_OA IS 'Photo sous-parties visitées';
COMMENT ON COLUMN PHOTO_SPRT_VST_OA.DSC_OA__NUM_OA IS 'NumOA';
COMMENT ON COLUMN PHOTO_SPRT_VST_OA.CAMP_OA__ID_CAMP IS 'Identifiant campagne';
COMMENT ON COLUMN PHOTO_SPRT_VST_OA.CD_CHAPITRE_OA__ID_CHAP IS 'Identifiant chapitre';
COMMENT ON COLUMN PHOTO_SPRT_VST_OA.CD_LIGNE_OA__ID_LIGNE IS 'Identifiant ligne';
COMMENT ON COLUMN PHOTO_SPRT_VST_OA.ID IS 'Identifiant de la photo';
COMMENT ON COLUMN PHOTO_SPRT_VST_OA.COMMENTAIRE IS 'Commentaire';

-- ---------------------------------------------------------
-- Table CD_PRESTA_OA
-- ---------------------------------------------------------
CREATE TABLE CD_PRESTA_OA 
( 
	PRESTATAIRE                             VARCHAR2(50 CHAR) NOT NULL
);
COMMENT ON TABLE CD_PRESTA_OA IS 'Prestataire';
COMMENT ON COLUMN CD_PRESTA_OA.PRESTATAIRE IS 'Prestataire';

-- ---------------------------------------------------------
-- Table PREVISION_OA
-- ---------------------------------------------------------
CREATE TABLE PREVISION_OA 
( 
	DSC_OA__NUM_OA                          VARCHAR2(20 CHAR) NOT NULL,
	BPU_OA__ID_BPU                          NUMBER(7) NOT NULL,
	DATE_DEBUT                              DATE NOT NULL,
	CD_CONTRAINTE_OA__TYPE                  VARCHAR2(100 CHAR),
	DATE_FIN                                DATE,
	MONTANT                                 NUMBER(9),
	DATE_DEM_PUB                            DATE,
	COMMENTAIRE                             VARCHAR2(255 CHAR),
	REALISE                                 NUMBER
);
COMMENT ON TABLE PREVISION_OA IS 'Prévisions';
COMMENT ON COLUMN PREVISION_OA.DSC_OA__NUM_OA IS 'NumOA';
COMMENT ON COLUMN PREVISION_OA.BPU_OA__ID_BPU IS 'Identifiant Bordereau';
COMMENT ON COLUMN PREVISION_OA.DATE_DEBUT IS 'Date début';
COMMENT ON COLUMN PREVISION_OA.CD_CONTRAINTE_OA__TYPE IS 'Contrainte Exploit.';
COMMENT ON COLUMN PREVISION_OA.DATE_FIN IS 'Date fin';
COMMENT ON COLUMN PREVISION_OA.MONTANT IS 'Coûts (€)';
COMMENT ON COLUMN PREVISION_OA.DATE_DEM_PUB IS 'Date demande publication';
COMMENT ON COLUMN PREVISION_OA.COMMENTAIRE IS 'Commentaire';
COMMENT ON COLUMN PREVISION_OA.REALISE IS 'Réalisé';

-- ---------------------------------------------------------
-- Table ENTETE_OA
-- ---------------------------------------------------------
CREATE TABLE ENTETE_OA 
( 
	DSC_OA__NUM_OA                          VARCHAR2(20 CHAR) NOT NULL,
	CAMP_OA__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	CD_ENTETE_OA__ID_ENTETE                 NUMBER(7) NOT NULL,
	VALEUR                                  VARCHAR2(250 CHAR)
);
COMMENT ON TABLE ENTETE_OA IS 'Saisie entête';
COMMENT ON COLUMN ENTETE_OA.DSC_OA__NUM_OA IS 'NumOA';
COMMENT ON COLUMN ENTETE_OA.CAMP_OA__ID_CAMP IS 'Identifiant campagne';
COMMENT ON COLUMN ENTETE_OA.CD_ENTETE_OA__ID_ENTETE IS 'Identifiant Entête';
COMMENT ON COLUMN ENTETE_OA.VALEUR IS 'Valeur';

-- ---------------------------------------------------------
-- Table SEUIL_URGENCE_OA
-- ---------------------------------------------------------
CREATE TABLE SEUIL_URGENCE_OA 
( 
	ORDRE                                   NUMBER(9) NOT NULL,
	NBR_NOTE                                NUMBER(9),
	VAL_NOTE                                NUMBER(9),
	INDICE                                  NUMBER(9)
);
COMMENT ON TABLE SEUIL_URGENCE_OA IS 'Seuil Urgence';
COMMENT ON COLUMN SEUIL_URGENCE_OA.ORDRE IS 'No Ordre';
COMMENT ON COLUMN SEUIL_URGENCE_OA.NBR_NOTE IS '>= Nbre de Note';
COMMENT ON COLUMN SEUIL_URGENCE_OA.VAL_NOTE IS 'Valeur Note';
COMMENT ON COLUMN SEUIL_URGENCE_OA.INDICE IS 'Indice dégradation';

-- ---------------------------------------------------------
-- Table SPRT_OA
-- ---------------------------------------------------------
CREATE TABLE SPRT_OA 
( 
	GRP_OA__ID_GRP                          NUMBER(7) NOT NULL,
	PRT_OA__ID_PRT                          NUMBER(7) NOT NULL,
	ID_SPRT                                 NUMBER(7) NOT NULL,
	LIBS                                    VARCHAR2(500 CHAR) NOT NULL,
	ORDRE                                   NUMBER(7) NOT NULL
);
COMMENT ON TABLE SPRT_OA IS 'Sous partie';
COMMENT ON COLUMN SPRT_OA.GRP_OA__ID_GRP IS 'Identifiant Groupe';
COMMENT ON COLUMN SPRT_OA.PRT_OA__ID_PRT IS 'Identifiant Partie';
COMMENT ON COLUMN SPRT_OA.ID_SPRT IS 'Identifiant Sous Partie';
COMMENT ON COLUMN SPRT_OA.LIBS IS 'Sous Partie';
COMMENT ON COLUMN SPRT_OA.ORDRE IS 'No Ordre';

-- ---------------------------------------------------------
-- Table SYS_USER_OA
-- ---------------------------------------------------------
CREATE TABLE SYS_USER_OA 
( 
	CODE_DBS                                VARCHAR2(50 CHAR) NOT NULL,
	CODE_TABLE                              VARCHAR2(100 CHAR) NOT NULL,
	CODE_COLONNE                            VARCHAR2(100 CHAR) NOT NULL,
	NOM_USER                                VARCHAR2(150 CHAR) NOT NULL,
	CODE_PRP                                VARCHAR2(255 CHAR) NOT NULL,
	VAL_PRP                                 VARCHAR2(500 CHAR) NOT NULL
);
COMMENT ON TABLE SYS_USER_OA IS 'SYS_USER_OA';
COMMENT ON COLUMN SYS_USER_OA.CODE_DBS IS 'SYS_USER_OA__CODE_DBS';
COMMENT ON COLUMN SYS_USER_OA.CODE_TABLE IS 'SYS_USER_OA__CODE_TABLE';
COMMENT ON COLUMN SYS_USER_OA.CODE_COLONNE IS 'SYS_USER_OA__CODE_COLONNE';
COMMENT ON COLUMN SYS_USER_OA.NOM_USER IS 'SYS_USER_OA__NOM_USER';
COMMENT ON COLUMN SYS_USER_OA.CODE_PRP IS 'SYS_USER_OA__CODE_PRP';
COMMENT ON COLUMN SYS_USER_OA.VAL_PRP IS 'SYS_USER_OA__VAL_PRP';

-- ---------------------------------------------------------
-- Table TABLIER_OA
-- ---------------------------------------------------------
CREATE TABLE TABLIER_OA 
( 
	DSC_OA__NUM_OA                          VARCHAR2(20 CHAR) NOT NULL,
	NUM_TAB                                 NUMBER(1) NOT NULL,
	CD_ENTP_OA__ENTREPRISE                  VARCHAR2(60 CHAR),
	CD_TECH_OA__TECHNIQUE                   VARCHAR2(12 CHAR),
	CD_CHAPE_OA__CHAPE                      VARCHAR2(60 CHAR),
	DATE_MS_CHAPE                           DATE,
	SURF_CHAPE                              NUMBER(5,2),
	EPAIS_CHAPE                             NUMBER(4,2),
	DATE_MS_BB                              DATE,
	EPAIS                                   NUMBER(4,2),
	GRANULO                                 VARCHAR2(8 CHAR),
	COMMENTAIRE                             VARCHAR2(255 CHAR)
);
COMMENT ON TABLE TABLIER_OA IS 'Tabliers';
COMMENT ON COLUMN TABLIER_OA.DSC_OA__NUM_OA IS 'NumOA';
COMMENT ON COLUMN TABLIER_OA.NUM_TAB IS 'N° Tablier';
COMMENT ON COLUMN TABLIER_OA.CD_ENTP_OA__ENTREPRISE IS 'Entreprise';
COMMENT ON COLUMN TABLIER_OA.CD_TECH_OA__TECHNIQUE IS 'Technique';
COMMENT ON COLUMN TABLIER_OA.CD_CHAPE_OA__CHAPE IS 'Type chape d''étanchéité';
COMMENT ON COLUMN TABLIER_OA.DATE_MS_CHAPE IS 'Date MS chape';
COMMENT ON COLUMN TABLIER_OA.SURF_CHAPE IS 'Surf chape (m²)';
COMMENT ON COLUMN TABLIER_OA.EPAIS_CHAPE IS 'Epaisseur Chape (cm)';
COMMENT ON COLUMN TABLIER_OA.DATE_MS_BB IS 'Date_MS Enrobé';
COMMENT ON COLUMN TABLIER_OA.EPAIS IS 'Epaisseur enrobé(cm)';
COMMENT ON COLUMN TABLIER_OA.GRANULO IS 'Granulométrie';
COMMENT ON COLUMN TABLIER_OA.COMMENTAIRE IS 'Commentaire';

-- ---------------------------------------------------------
-- Table TRAVAUX_OA
-- ---------------------------------------------------------
CREATE TABLE TRAVAUX_OA 
( 
	DSC_OA__NUM_OA                          VARCHAR2(20 CHAR) NOT NULL,
	CD_TRAVAUX_OA__CODE                     VARCHAR2(60 CHAR) NOT NULL,
	NATURE_TRAV_OA__NATURE                  VARCHAR2(100 CHAR) NOT NULL,
	DATE_RCP                                DATE NOT NULL,
	CD_ENTP_OA__ENTREPRISE                  VARCHAR2(60 CHAR),
	DATE_FIN_GAR                            DATE,
	COUT                                    NUMBER(9),
	MARCHE                                  VARCHAR2(25 CHAR),
	COMMENTAIRE                             VARCHAR2(1000 CHAR)
);
COMMENT ON TABLE TRAVAUX_OA IS 'Travaux';
COMMENT ON COLUMN TRAVAUX_OA.DSC_OA__NUM_OA IS 'NumOA';
COMMENT ON COLUMN TRAVAUX_OA.CD_TRAVAUX_OA__CODE IS 'Type Travaux';
COMMENT ON COLUMN TRAVAUX_OA.NATURE_TRAV_OA__NATURE IS 'Nature travaux';
COMMENT ON COLUMN TRAVAUX_OA.DATE_RCP IS 'Date Réception';
COMMENT ON COLUMN TRAVAUX_OA.CD_ENTP_OA__ENTREPRISE IS 'Entreprise';
COMMENT ON COLUMN TRAVAUX_OA.DATE_FIN_GAR IS 'Fin de garantie';
COMMENT ON COLUMN TRAVAUX_OA.COUT IS 'Coûts (€)';
COMMENT ON COLUMN TRAVAUX_OA.MARCHE IS 'No Marché';
COMMENT ON COLUMN TRAVAUX_OA.COMMENTAIRE IS 'Commentaire';

-- ---------------------------------------------------------
-- Table CD_COMPOSANT_OA
-- ---------------------------------------------------------
CREATE TABLE CD_COMPOSANT_OA 
( 
	TYPE_COMP                               VARCHAR2(6 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(60 CHAR)
);
COMMENT ON TABLE CD_COMPOSANT_OA IS 'Type Composant';
COMMENT ON COLUMN CD_COMPOSANT_OA.TYPE_COMP IS 'Type';
COMMENT ON COLUMN CD_COMPOSANT_OA.LIBELLE IS 'Libellé';

-- ---------------------------------------------------------
-- Table CD_CHARGE_OA
-- ---------------------------------------------------------
CREATE TABLE CD_CHARGE_OA 
( 
	SURCHARGE                               VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_CHARGE_OA IS 'Type de surcharges';
COMMENT ON COLUMN CD_CHARGE_OA.SURCHARGE IS 'Surcharge';

-- ---------------------------------------------------------
-- Table CD_EVT_OA
-- ---------------------------------------------------------
CREATE TABLE CD_EVT_OA 
( 
	TYPE                                    VARCHAR2(25 CHAR) NOT NULL,
	IMPACT                                  NUMBER
);
COMMENT ON TABLE CD_EVT_OA IS 'Type d''événement';
COMMENT ON COLUMN CD_EVT_OA.TYPE IS 'Type événement';
COMMENT ON COLUMN CD_EVT_OA.IMPACT IS 'Impact métier';

-- ---------------------------------------------------------
-- Table CD_TYPE_OA
-- ---------------------------------------------------------
CREATE TABLE CD_TYPE_OA 
( 
	TYPE                                    VARCHAR2(20 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(60 CHAR)
);
COMMENT ON TABLE CD_TYPE_OA IS 'Type d''ouvrage';
COMMENT ON COLUMN CD_TYPE_OA.TYPE IS 'Type';
COMMENT ON COLUMN CD_TYPE_OA.LIBELLE IS 'Libellé';

-- ---------------------------------------------------------
-- Table CD_OCCUP_OA
-- ---------------------------------------------------------
CREATE TABLE CD_OCCUP_OA 
( 
	TYPE                                    VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_OCCUP_OA IS 'Type Occupation';
COMMENT ON COLUMN CD_OCCUP_OA.TYPE IS 'Type Occupation';

-- ---------------------------------------------------------
-- Table CD_TYPE_PV_OA
-- ---------------------------------------------------------
CREATE TABLE CD_TYPE_PV_OA 
( 
	CODE                                    VARCHAR2(15 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(60 CHAR) NOT NULL,
	CYCLE                                   NUMBER(6),
	COUT                                    NUMBER(6)
);
COMMENT ON TABLE CD_TYPE_PV_OA IS 'Type PV';
COMMENT ON COLUMN CD_TYPE_PV_OA.CODE IS 'Type de PV';
COMMENT ON COLUMN CD_TYPE_PV_OA.LIBELLE IS 'Libellé';
COMMENT ON COLUMN CD_TYPE_PV_OA.CYCLE IS 'Cycle';
COMMENT ON COLUMN CD_TYPE_PV_OA.COUT IS 'Coût unitaire (€)';

-- ---------------------------------------------------------
-- Table CD_TRAVAUX_OA
-- ---------------------------------------------------------
CREATE TABLE CD_TRAVAUX_OA 
( 
	CODE                                    VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_TRAVAUX_OA IS 'Type travaux';
COMMENT ON COLUMN CD_TRAVAUX_OA.CODE IS 'Type Travaux';

-- ---------------------------------------------------------
-- Table CD_APP_APPUI_OA
-- ---------------------------------------------------------
CREATE TABLE CD_APP_APPUI_OA 
( 
	APPUI                                   VARCHAR2(60 CHAR) NOT NULL,
	GARANTIE                                NUMBER(3),
	DVT                                     NUMBER(3)
);
COMMENT ON TABLE CD_APP_APPUI_OA IS 'Types d''appareil d'' appui';
COMMENT ON COLUMN CD_APP_APPUI_OA.APPUI IS 'Type app appui';
COMMENT ON COLUMN CD_APP_APPUI_OA.GARANTIE IS 'Garantie (mois)';
COMMENT ON COLUMN CD_APP_APPUI_OA.DVT IS 'Durée de vie (mois)';

-- ---------------------------------------------------------
-- Table CD_APPUI_OA
-- ---------------------------------------------------------
CREATE TABLE CD_APPUI_OA 
( 
	APP                                     VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_APPUI_OA IS 'Types d''appuis';
COMMENT ON COLUMN CD_APPUI_OA.APP IS 'Type d''appui';

-- ---------------------------------------------------------
-- Table CD_CHAPE_OA
-- ---------------------------------------------------------
CREATE TABLE CD_CHAPE_OA 
( 
	CHAPE                                   VARCHAR2(60 CHAR) NOT NULL,
	GARANTIE                                NUMBER(3),
	DVT                                     NUMBER(3)
);
COMMENT ON TABLE CD_CHAPE_OA IS 'Types de chape';
COMMENT ON COLUMN CD_CHAPE_OA.CHAPE IS 'Type chape d''étanchéité';
COMMENT ON COLUMN CD_CHAPE_OA.GARANTIE IS 'Garantie (mois)';
COMMENT ON COLUMN CD_CHAPE_OA.DVT IS 'Durée de vie (mois)';

-- ---------------------------------------------------------
-- Table CD_DPR_OA
-- ---------------------------------------------------------
CREATE TABLE CD_DPR_OA 
( 
	DPR                                     VARCHAR2(60 CHAR) NOT NULL,
	GARANTIE                                NUMBER(3),
	DVT                                     NUMBER(3)
);
COMMENT ON TABLE CD_DPR_OA IS 'Types de dispositif de retenue';
COMMENT ON COLUMN CD_DPR_OA.DPR IS 'Dispositif de retenue';
COMMENT ON COLUMN CD_DPR_OA.GARANTIE IS 'Garantie (mois)';
COMMENT ON COLUMN CD_DPR_OA.DVT IS 'Durée de vie (mois)';

-- ---------------------------------------------------------
-- Table CD_DOC_OA
-- ---------------------------------------------------------
CREATE TABLE CD_DOC_OA 
( 
	CODE                                    VARCHAR2(15 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(60 CHAR),
	PATH                                    VARCHAR2(255 CHAR)
);
COMMENT ON TABLE CD_DOC_OA IS 'Types de document';
COMMENT ON COLUMN CD_DOC_OA.CODE IS 'Code';
COMMENT ON COLUMN CD_DOC_OA.LIBELLE IS 'Libellé';
COMMENT ON COLUMN CD_DOC_OA.PATH IS 'Répertoire';

-- ---------------------------------------------------------
-- Table CD_FOND_OA
-- ---------------------------------------------------------
CREATE TABLE CD_FOND_OA 
( 
	TYPE                                    VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_FOND_OA IS 'Types de fondation';
COMMENT ON COLUMN CD_FOND_OA.TYPE IS 'Fondation';

-- ---------------------------------------------------------
-- Table CD_GC_OA
-- ---------------------------------------------------------
CREATE TABLE CD_GC_OA 
( 
	GARDE_CORPS                             VARCHAR2(60 CHAR) NOT NULL,
	GARANTIE                                NUMBER(3),
	DVT                                     NUMBER(3)
);
COMMENT ON TABLE CD_GC_OA IS 'Types de garde-corps';
COMMENT ON COLUMN CD_GC_OA.GARDE_CORPS IS 'Garde-corps';
COMMENT ON COLUMN CD_GC_OA.GARANTIE IS 'Garantie (mois)';
COMMENT ON COLUMN CD_GC_OA.DVT IS 'Durée de vie (mois)';

-- ---------------------------------------------------------
-- Table CD_JOINT_OA
-- ---------------------------------------------------------
CREATE TABLE CD_JOINT_OA 
( 
	TYPE                                    VARCHAR2(60 CHAR) NOT NULL,
	GARANTIE                                NUMBER(3),
	DVT                                     NUMBER(3)
);
COMMENT ON TABLE CD_JOINT_OA IS 'Types de joint';
COMMENT ON COLUMN CD_JOINT_OA.TYPE IS 'Joint';
COMMENT ON COLUMN CD_JOINT_OA.GARANTIE IS 'Garantie';
COMMENT ON COLUMN CD_JOINT_OA.DVT IS 'Durée de vie (mois)';

-- ---------------------------------------------------------
-- Table CD_TABLIER_OA
-- ---------------------------------------------------------
CREATE TABLE CD_TABLIER_OA 
( 
	TABLIER                                 VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE CD_TABLIER_OA IS 'Types de tablier';
COMMENT ON COLUMN CD_TABLIER_OA.TABLIER IS 'Type tablier';

-- ---------------------------------------------------------
-- Table CD_UNITE_OA
-- ---------------------------------------------------------
CREATE TABLE CD_UNITE_OA 
( 
	UNITE                                   VARCHAR2(12 CHAR) NOT NULL
);
COMMENT ON TABLE CD_UNITE_OA IS 'unité';
COMMENT ON COLUMN CD_UNITE_OA.UNITE IS 'Unité';

-- ---------------------------------------------------------
-- Table VST_OA
-- ---------------------------------------------------------
CREATE TABLE VST_OA 
( 
	CAMP_OA__ID_CAMP                        VARCHAR2(100 CHAR) NOT NULL,
	DSC_OA__NUM_OA                          VARCHAR2(20 CHAR) NOT NULL,
	INSPECTEUR_OA__NOM                      VARCHAR2(60 CHAR),
	ETAT                                    VARCHAR2(25 CHAR) NOT NULL,
	DATEV                                   DATE,
	PRIORITAIRE                             NUMBER,
	OBSERV                                  VARCHAR2(500 CHAR),
	NOTE_VST                                VARCHAR2(5 CHAR)
);
COMMENT ON TABLE VST_OA IS 'Visite';
COMMENT ON COLUMN VST_OA.CAMP_OA__ID_CAMP IS 'Identifiant campagne';
COMMENT ON COLUMN VST_OA.DSC_OA__NUM_OA IS 'NumOA';
COMMENT ON COLUMN VST_OA.INSPECTEUR_OA__NOM IS 'Nom inspecteur';
COMMENT ON COLUMN VST_OA.ETAT IS 'Statut visite';
COMMENT ON COLUMN VST_OA.DATEV IS 'Date de visite';
COMMENT ON COLUMN VST_OA.PRIORITAIRE IS 'Urgence traitement';
COMMENT ON COLUMN VST_OA.OBSERV IS 'Observation';
COMMENT ON COLUMN VST_OA.NOTE_VST IS 'Note Visite';

