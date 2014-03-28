/*################################################################################################*/
/* Script     : PRF_Tables.sql                                                                    */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

-- ---------------------------------------------------------
-- Table SYS_PRP_PRF
-- ---------------------------------------------------------

CREATE TABLE SYS_PRP_PRF 
( 
	CODE_TABLE                    VARCHAR2(60 CHAR)        NOT NULL,
	CODE_COLONNE                  VARCHAR2(60 CHAR)        NOT NULL,
	NOM_USER                      VARCHAR2(30 CHAR)        NOT NULL,
	CODE_PRP                      VARCHAR2(60 CHAR)        NOT NULL,
	VAL_PRP                       VARCHAR2(255 CHAR)       );
COMMENT ON TABLE SYS_PRP_PRF IS 'MétaDonnées du schéma PRF';

-- ---------------------------------------------------------
-- Table SYS_INSTANCE_PRF
-- ---------------------------------------------------------

CREATE TABLE SYS_INSTANCE_PRF 
( 
	CODE                   VARCHAR2(100 CHAR) NOT NULL,
	VALEUR                 CLOB);
COMMENT ON TABLE SYS_INSTANCE_PRF IS 'Informations du schéma PRF';

-- ---------------------------------------------------------
-- Table BM_PROFIL_TABLE
-- ---------------------------------------------------------
CREATE TABLE BM_PROFIL_TABLE 
( 
	BM_PROFIL__PROFIL                       VARCHAR2(20 CHAR) NOT NULL,
	BM_TABLE__NOM                           VARCHAR2(30 CHAR) NOT NULL,
	ECRIRE                                  NUMBER NOT NULL,
	IMPORTER                                NUMBER NOT NULL,
	AFFICHER                                NUMBER
);
COMMENT ON TABLE BM_PROFIL_TABLE IS 'Droit par table';
COMMENT ON COLUMN BM_PROFIL_TABLE.BM_PROFIL__PROFIL IS 'Profil';
COMMENT ON COLUMN BM_PROFIL_TABLE.BM_TABLE__NOM IS 'Nom';
COMMENT ON COLUMN BM_PROFIL_TABLE.ECRIRE IS 'Ecrire';
COMMENT ON COLUMN BM_PROFIL_TABLE.IMPORTER IS 'Importer';
COMMENT ON COLUMN BM_PROFIL_TABLE.AFFICHER IS 'Afficher';

-- ---------------------------------------------------------
-- Table BM_PARAM
-- ---------------------------------------------------------
CREATE TABLE BM_PARAM 
( 
	CODE                                    VARCHAR2(25 CHAR) NOT NULL,
	VALEUR                                  VARCHAR2(500 CHAR)
);
COMMENT ON TABLE BM_PARAM IS 'Paramètres';
COMMENT ON COLUMN BM_PARAM.CODE IS 'CODE';
COMMENT ON COLUMN BM_PARAM.VALEUR IS 'VALEUR';

-- ---------------------------------------------------------
-- Table BM_PROFIL
-- ---------------------------------------------------------
CREATE TABLE BM_PROFIL 
( 
	PROFIL                                  VARCHAR2(20 CHAR) NOT NULL,
	BM_SCHEMA__SCHEMA                       VARCHAR2(20 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE BM_PROFIL IS 'Profil BM';
COMMENT ON COLUMN BM_PROFIL.PROFIL IS 'Profil';
COMMENT ON COLUMN BM_PROFIL.BM_SCHEMA__SCHEMA IS 'Code schéma';
COMMENT ON COLUMN BM_PROFIL.LIBELLE IS 'Libellé';

-- ---------------------------------------------------------
-- Table BM_USER_PROFIL
-- ---------------------------------------------------------
CREATE TABLE BM_USER_PROFIL 
( 
	BM_USER__LOGIN                          VARCHAR2(50 CHAR) NOT NULL,
	BM_PROFIL__PROFIL                       VARCHAR2(20 CHAR) NOT NULL
);
COMMENT ON TABLE BM_USER_PROFIL IS 'Profil d''un utilisateur';
COMMENT ON COLUMN BM_USER_PROFIL.BM_USER__LOGIN IS 'Domaine_Login';
COMMENT ON COLUMN BM_USER_PROFIL.BM_PROFIL__PROFIL IS 'Profil';

-- ---------------------------------------------------------
-- Table BM_SCHEMA
-- ---------------------------------------------------------
CREATE TABLE BM_SCHEMA 
( 
	SCHEMA                                  VARCHAR2(20 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(200 CHAR) NOT NULL
);
COMMENT ON TABLE BM_SCHEMA IS 'Schéma BM';
COMMENT ON COLUMN BM_SCHEMA.SCHEMA IS 'Code schéma';
COMMENT ON COLUMN BM_SCHEMA.LIBELLE IS 'Libellé';

-- ---------------------------------------------------------
-- Table SYS_LANG
-- ---------------------------------------------------------
CREATE TABLE SYS_LANG 
( 
	CODE_APP                                VARCHAR2(50 CHAR) NOT NULL,
	CODE_PRP                                VARCHAR2(1000 CHAR) NOT NULL,
	VAL_PRP                                 VARCHAR2(1000 CHAR),
	SORT_TRAD                               NUMBER(6)
);
COMMENT ON TABLE SYS_LANG IS 'SYS_LANG';
COMMENT ON COLUMN SYS_LANG.CODE_APP IS 'CODE_APP';
COMMENT ON COLUMN SYS_LANG.CODE_PRP IS 'CODE_PRP';
COMMENT ON COLUMN SYS_LANG.VAL_PRP IS 'VAL_PRP';
COMMENT ON COLUMN SYS_LANG.SORT_TRAD IS 'SORT_TRAD';

-- ---------------------------------------------------------
-- Table BM_TABLE
-- ---------------------------------------------------------
CREATE TABLE BM_TABLE 
( 
	NOM                                     VARCHAR2(30 CHAR) NOT NULL,
	BM_SCHEMA__SCHEMA                       VARCHAR2(20 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(60 CHAR) NOT NULL
);
COMMENT ON TABLE BM_TABLE IS 'Table BM';
COMMENT ON COLUMN BM_TABLE.NOM IS 'Nom';
COMMENT ON COLUMN BM_TABLE.BM_SCHEMA__SCHEMA IS 'Code schéma';
COMMENT ON COLUMN BM_TABLE.LIBELLE IS 'Libellé';

-- ---------------------------------------------------------
-- Table BM_USER
-- ---------------------------------------------------------
CREATE TABLE BM_USER 
( 
	LOGIN                                   VARCHAR2(50 CHAR) NOT NULL,
	NOM                                     VARCHAR2(60 CHAR),
	PRENOM                                  VARCHAR2(60 CHAR),
	PASSWORDS                               VARCHAR2(100 CHAR),
	FAM_DEC_INF                             VARCHAR2(6 CHAR),
	CD_DEC_INF                              VARCHAR2(15 CHAR)
);
COMMENT ON TABLE BM_USER IS 'Utilisateur BM';
COMMENT ON COLUMN BM_USER.LOGIN IS 'Domaine_Login';
COMMENT ON COLUMN BM_USER.NOM IS 'Nom';
COMMENT ON COLUMN BM_USER.PRENOM IS 'Prénom';
COMMENT ON COLUMN BM_USER.PASSWORDS IS 'Passwords';
COMMENT ON COLUMN BM_USER.FAM_DEC_INF IS 'Famille de découpage';
COMMENT ON COLUMN BM_USER.CD_DEC_INF IS 'Code de découpage';

