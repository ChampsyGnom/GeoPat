/*################################################################################################*/
/* Script     : WEB_Tables.sql                                                                    */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

-- ---------------------------------------------------------
-- Table SYS_PRP_WEB
-- ---------------------------------------------------------

CREATE TABLE SYS_PRP_WEB 
( 
	CODE_TABLE                    VARCHAR2(60 CHAR)        NOT NULL,
	CODE_COLONNE                  VARCHAR2(60 CHAR)        NOT NULL,
	NOM_USER                      VARCHAR2(30 CHAR)        NOT NULL,
	CODE_PRP                      VARCHAR2(60 CHAR)        NOT NULL,
	VAL_PRP                       VARCHAR2(255 CHAR)       );
COMMENT ON TABLE SYS_PRP_WEB IS 'MétaDonnées du schéma WEB';

-- ---------------------------------------------------------
-- Table SYS_INSTANCE_WEB
-- ---------------------------------------------------------

CREATE TABLE SYS_INSTANCE_WEB 
( 
	CODE                   VARCHAR2(100 CHAR) NOT NULL,
	VALEUR                 CLOB);
COMMENT ON TABLE SYS_INSTANCE_WEB IS 'Informations du schéma WEB';

-- ---------------------------------------------------------
-- Table MODELE_WEB__NODE_WEB
-- ---------------------------------------------------------
CREATE TABLE MODELE_WEB__NODE_WEB 
( 
	NODE_WEB__ID                            NUMBER(6) NOT NULL,
	MODELE_WEB__ID                          NUMBER(6) NOT NULL,
	MAP_ORDER                               NUMBER(3),
	STYLE_WEB__ID                           NUMBER(20)
);
COMMENT ON TABLE MODELE_WEB__NODE_WEB IS 'Contenu des modèles';
COMMENT ON COLUMN MODELE_WEB__NODE_WEB.NODE_WEB__ID IS 'Identifiant du noeud';
COMMENT ON COLUMN MODELE_WEB__NODE_WEB.MODELE_WEB__ID IS 'Identifiant du modèle';
COMMENT ON COLUMN MODELE_WEB__NODE_WEB.MAP_ORDER IS 'Ordre de la couche dans la carte';
COMMENT ON COLUMN MODELE_WEB__NODE_WEB.STYLE_WEB__ID IS 'Style du noeud pour le modèle';

-- ---------------------------------------------------------
-- Table SYS_USER_WEB
-- ---------------------------------------------------------
CREATE TABLE SYS_USER_WEB 
( 
	CODE_DBS                                VARCHAR2(50 CHAR) NOT NULL,
	CODE_TABLE                              VARCHAR2(200 CHAR) NOT NULL,
	CODE_COLONNE                            VARCHAR2(200 CHAR) NOT NULL,
	NOM_USER                                VARCHAR2(200 CHAR) NOT NULL,
	CODE_PRP                                VARCHAR2(255 CHAR) NOT NULL,
	VAL_PRP                                 VARCHAR2(255 CHAR) NOT NULL
);
COMMENT ON TABLE SYS_USER_WEB IS 'Informations utilisateurs';
COMMENT ON COLUMN SYS_USER_WEB.CODE_DBS IS 'Code dbs';
COMMENT ON COLUMN SYS_USER_WEB.CODE_TABLE IS 'Code table';
COMMENT ON COLUMN SYS_USER_WEB.CODE_COLONNE IS 'Code colonne';
COMMENT ON COLUMN SYS_USER_WEB.NOM_USER IS 'Code utilisateur';
COMMENT ON COLUMN SYS_USER_WEB.CODE_PRP IS 'Code propriétée';
COMMENT ON COLUMN SYS_USER_WEB.VAL_PRP IS 'Valeur propriétée';

-- ---------------------------------------------------------
-- Table MODELE_WEB
-- ---------------------------------------------------------
CREATE TABLE MODELE_WEB 
( 
	ID                                      NUMBER(6,0) NOT NULL,
	CD_MODELE_WEB__CODE                     VARCHAR2(50 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(255 CHAR) NOT NULL,
	IS_PUBLIC                               NUMBER
);
COMMENT ON TABLE MODELE_WEB IS 'Modèle';
COMMENT ON COLUMN MODELE_WEB.ID IS 'Identifiant du modèle';
COMMENT ON COLUMN MODELE_WEB.CD_MODELE_WEB__CODE IS 'Code du type de modèle (SIG_REF_DETAIL SIG_REF_SCHEMA)';
COMMENT ON COLUMN MODELE_WEB.LIBELLE IS 'Libellé du modèle';
COMMENT ON COLUMN MODELE_WEB.IS_PUBLIC IS 'Public';

-- ---------------------------------------------------------
-- Table NODE_WEB
-- ---------------------------------------------------------
CREATE TABLE NODE_WEB 
( 
	ID                                      NUMBER(6,0) NOT NULL,
	CD_NODE_WEB__NAME                       VARCHAR2(255 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(255 CHAR) NOT NULL,
	PARENT_ID                               NUMBER(10),
	TREE_ORDER                              NUMBER(3)
);
COMMENT ON TABLE NODE_WEB IS 'Noeuds du tableau de bord';
COMMENT ON COLUMN NODE_WEB.ID IS 'Identifiant du noeud';
COMMENT ON COLUMN NODE_WEB.CD_NODE_WEB__NAME IS 'Type de noeud';
COMMENT ON COLUMN NODE_WEB.LIBELLE IS 'Libellé';
COMMENT ON COLUMN NODE_WEB.PARENT_ID IS 'Identifiant du noeud parent';
COMMENT ON COLUMN NODE_WEB.TREE_ORDER IS 'Ordre du noeud dans le parent';

-- ---------------------------------------------------------
-- Table NODE_PARAM_WEB
-- ---------------------------------------------------------
CREATE TABLE NODE_PARAM_WEB 
( 
	NODE_WEB__ID                            NUMBER(6) NOT NULL,
	CODE                                    VARCHAR2(255 CHAR) NOT NULL,
	VALEUR                                  VARCHAR2(255 CHAR) NOT NULL
);
COMMENT ON TABLE NODE_PARAM_WEB IS 'Paramètres des noeuds';
COMMENT ON COLUMN NODE_PARAM_WEB.NODE_WEB__ID IS 'Identifiant du noeud';
COMMENT ON COLUMN NODE_PARAM_WEB.CODE IS 'Code du paramètre';
COMMENT ON COLUMN NODE_PARAM_WEB.VALEUR IS 'Valeur du paramètre';

-- ---------------------------------------------------------
-- Table STYLE_RULE_WEB
-- ---------------------------------------------------------
CREATE TABLE STYLE_RULE_WEB 
( 
	ID                                      NUMBER(6,0) NOT NULL,
	STYLE_WEB__ID                           NUMBER(6) NOT NULL,
	LIBELLE                                 VARCHAR2(255 CHAR) NOT NULL,
	INCREMENT_RANGE                         NUMBER(20,6),
	IS_ACTIVE                               NUMBER NOT NULL,
	MAX_RANGE                               NUMBER(20,6),
	MIN_RANGE                               NUMBER(20,6),
	MAX_VALUE                               NUMBER(20,6),
	MIN_VALUE                               NUMBER(20,6),
	UNIQUE_VALUE                            VARCHAR2(255 CHAR),
	POINT_SIZE                              NUMBER(3) NOT NULL,
	POINT_STROKE_COLOR                      VARCHAR2(10 CHAR) NOT NULL,
	POINT_STROKE_OPACITY                    NUMBER(3) NOT NULL,
	POINT_STROKE_STYLE                      VARCHAR2(50 CHAR) NOT NULL,
	POINT_STROKE_SIZE                       NUMBER(3) NOT NULL,
	POINT_FILL_COLOR                        VARCHAR2(10 CHAR) NOT NULL,
	POINT_FILL_OPACITY                      NUMBER(3) NOT NULL,
	POINT_SYMBOL                            VARCHAR2(50 CHAR) NOT NULL,
	POINT_IMAGE                             VARCHAR2(255 CHAR) NOT NULL,
	LINE_SIZE                               NUMBER(3) NOT NULL,
	LINE_STROKE_COLOR                       VARCHAR2(10 CHAR) NOT NULL,
	LINE_STROKE_OPACITY                     NUMBER(3) NOT NULL,
	LINE_STROKE_STYLE                       VARCHAR2(50 CHAR) NOT NULL,
	POLY_STROKE_COLOR                       VARCHAR2(10 CHAR) NOT NULL,
	POLY_STROKE_OPACITY                     NUMBER(3) NOT NULL,
	POLY_STROKE_STYLE                       VARCHAR2(50 CHAR) NOT NULL,
	POLY_STROKE_SIZE                        NUMBER(3) NOT NULL,
	POLY_FILL_COLOR                         VARCHAR2(10 CHAR) NOT NULL,
	POLY_FILL_OPACITY                       NUMBER(3) NOT NULL
);
COMMENT ON TABLE STYLE_RULE_WEB IS 'Règles d''un styles (une seul règle si pas analyse)';
COMMENT ON COLUMN STYLE_RULE_WEB.ID IS 'Identifiant de la règle';
COMMENT ON COLUMN STYLE_RULE_WEB.STYLE_WEB__ID IS 'Identifiant du style';
COMMENT ON COLUMN STYLE_RULE_WEB.LIBELLE IS 'Libellé de la règle';
COMMENT ON COLUMN STYLE_RULE_WEB.INCREMENT_RANGE IS 'Increment des classe de valeurs';
COMMENT ON COLUMN STYLE_RULE_WEB.IS_ACTIVE IS 'La règle de style est active';
COMMENT ON COLUMN STYLE_RULE_WEB.MAX_RANGE IS 'Borne maximale des classe de valeurs';
COMMENT ON COLUMN STYLE_RULE_WEB.MIN_RANGE IS 'Borne minimal des classe de valeurs';
COMMENT ON COLUMN STYLE_RULE_WEB.MAX_VALUE IS 'Valeur maximal de la classe de valeur';
COMMENT ON COLUMN STYLE_RULE_WEB.MIN_VALUE IS 'Valeur minimal de la classe de valeur';
COMMENT ON COLUMN STYLE_RULE_WEB.UNIQUE_VALUE IS 'Valeur unique de la règle';
COMMENT ON COLUMN STYLE_RULE_WEB.POINT_SIZE IS 'Taille des points';
COMMENT ON COLUMN STYLE_RULE_WEB.POINT_STROKE_COLOR IS 'Couleur du contour des points';
COMMENT ON COLUMN STYLE_RULE_WEB.POINT_STROKE_OPACITY IS 'Opacité du contour des points';
COMMENT ON COLUMN STYLE_RULE_WEB.POINT_STROKE_STYLE IS 'Style du contour des points';
COMMENT ON COLUMN STYLE_RULE_WEB.POINT_STROKE_SIZE IS 'Taille du contour des points';
COMMENT ON COLUMN STYLE_RULE_WEB.POINT_FILL_COLOR IS 'Couleur de remplissage des points';
COMMENT ON COLUMN STYLE_RULE_WEB.POINT_FILL_OPACITY IS 'Opacité du remplissage des points';
COMMENT ON COLUMN STYLE_RULE_WEB.POINT_SYMBOL IS 'Symbole des points';
COMMENT ON COLUMN STYLE_RULE_WEB.POINT_IMAGE IS 'Image des points';
COMMENT ON COLUMN STYLE_RULE_WEB.LINE_SIZE IS 'Taille des lignes';
COMMENT ON COLUMN STYLE_RULE_WEB.LINE_STROKE_COLOR IS 'Couleur des lignes';
COMMENT ON COLUMN STYLE_RULE_WEB.LINE_STROKE_OPACITY IS 'Opacité des lignes';
COMMENT ON COLUMN STYLE_RULE_WEB.LINE_STROKE_STYLE IS 'Style des lignes';
COMMENT ON COLUMN STYLE_RULE_WEB.POLY_STROKE_COLOR IS 'Couleur des contours des polygones';
COMMENT ON COLUMN STYLE_RULE_WEB.POLY_STROKE_OPACITY IS 'Opacité des contours des polygones';
COMMENT ON COLUMN STYLE_RULE_WEB.POLY_STROKE_STYLE IS 'Style du contours des polygones';
COMMENT ON COLUMN STYLE_RULE_WEB.POLY_STROKE_SIZE IS 'Taille du contour des polygones';
COMMENT ON COLUMN STYLE_RULE_WEB.POLY_FILL_COLOR IS 'Couleur de remplissage des polygones';
COMMENT ON COLUMN STYLE_RULE_WEB.POLY_FILL_OPACITY IS 'Opacité du remplissage des polygones';

-- ---------------------------------------------------------
-- Table STYLE_WEB
-- ---------------------------------------------------------
CREATE TABLE STYLE_WEB 
( 
	ID                                      NUMBER(6,0) NOT NULL,
	SCHEMA_NAME                             VARCHAR2(255 CHAR),
	TABLE_NAME                              VARCHAR2(255 CHAR),
	COLUMN_NAME                             VARCHAR2(255 CHAR),
	LIBELLE                                 VARCHAR2(255 CHAR) NOT NULL,
	DEFAUT                                  NUMBER NOT NULL
);
COMMENT ON TABLE STYLE_WEB IS 'Style d''un couche';
COMMENT ON COLUMN STYLE_WEB.ID IS 'Identifiant du style';
COMMENT ON COLUMN STYLE_WEB.SCHEMA_NAME IS 'Nom du schéma (optionel)';
COMMENT ON COLUMN STYLE_WEB.TABLE_NAME IS 'Nom de la table (optionel)';
COMMENT ON COLUMN STYLE_WEB.COLUMN_NAME IS 'Nom de la colonne (optionel)';
COMMENT ON COLUMN STYLE_WEB.LIBELLE IS 'Libellé du style';
COMMENT ON COLUMN STYLE_WEB.DEFAUT IS 'Style par défaut';

-- ---------------------------------------------------------
-- Table NODE_WEB__STYLE_WEB
-- ---------------------------------------------------------
CREATE TABLE NODE_WEB__STYLE_WEB 
( 
	NODE_WEB__ID                            NUMBER(6) NOT NULL,
	STYLE_WEB__ID                           NUMBER(6) NOT NULL
);
COMMENT ON TABLE NODE_WEB__STYLE_WEB IS 'Styles du noeud';
COMMENT ON COLUMN NODE_WEB__STYLE_WEB.NODE_WEB__ID IS 'Identifiant du noeud';
COMMENT ON COLUMN NODE_WEB__STYLE_WEB.STYLE_WEB__ID IS 'Identifiant du style';

-- ---------------------------------------------------------
-- Table CD_MODELE_WEB
-- ---------------------------------------------------------
CREATE TABLE CD_MODELE_WEB 
( 
	CODE                                    VARCHAR2(50 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(255 CHAR) NOT NULL
);
COMMENT ON TABLE CD_MODELE_WEB IS 'Type de modèle (détail schématique synoptique)';
COMMENT ON COLUMN CD_MODELE_WEB.CODE IS 'Code du type de modèle (SIG_REF_DETAIL SIG_REF_SCHEMA)';
COMMENT ON COLUMN CD_MODELE_WEB.LIBELLE IS 'Nom du type de modele (detail synoptique schématique)';

-- ---------------------------------------------------------
-- Table CD_NODE_WEB
-- ---------------------------------------------------------
CREATE TABLE CD_NODE_WEB 
( 
	NAME                                    VARCHAR2(255 CHAR) NOT NULL
);
COMMENT ON TABLE CD_NODE_WEB IS 'Type de noeud du tableau de bord';
COMMENT ON COLUMN CD_NODE_WEB.NAME IS 'Type de noeud';

