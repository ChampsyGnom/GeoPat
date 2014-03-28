/*################################################################################################*/
/* Script     : MAPINFO_Tables.sql                                                                */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

-- ---------------------------------------------------------
-- Table SYS_PRP_MAPINFO
-- ---------------------------------------------------------

CREATE TABLE SYS_PRP_MAPINFO 
( 
	CODE_TABLE                    VARCHAR2(60 CHAR)        NOT NULL,
	CODE_COLONNE                  VARCHAR2(60 CHAR)        NOT NULL,
	NOM_USER                      VARCHAR2(30 CHAR)        NOT NULL,
	CODE_PRP                      VARCHAR2(60 CHAR)        NOT NULL,
	VAL_PRP                       VARCHAR2(255 CHAR)       );
COMMENT ON TABLE SYS_PRP_MAPINFO IS 'MétaDonnées du schéma MAPINFO';

-- ---------------------------------------------------------
-- Table SYS_INSTANCE_MAPINFO
-- ---------------------------------------------------------

CREATE TABLE SYS_INSTANCE_MAPINFO 
( 
	CODE                   VARCHAR2(100 CHAR) NOT NULL,
	VALEUR                 CLOB);
COMMENT ON TABLE SYS_INSTANCE_MAPINFO IS 'Informations du schéma MAPINFO';

-- ---------------------------------------------------------
-- Table TB_MAP
-- ---------------------------------------------------------
CREATE TABLE TB_MAP 
( 
	TB_MODELE__MODELE                       VARCHAR2(50 CHAR) NOT NULL,
	TB_TEMPLATE__TPL                        VARCHAR2(50 CHAR) NOT NULL,
	TB_GROUPE__GROUPE                       VARCHAR2(50 CHAR) NOT NULL,
	MAP                                     VARCHAR2(50 CHAR) NOT NULL,
	TITRE                                   VARCHAR2(50 CHAR) NOT NULL,
	OBJTYPE                                 NUMBER(9),
	RANG                                    NUMBER(2),
	MAP_ORDER                               NUMBER(2) NOT NULL,
	OWNER                                   VARCHAR2(50 CHAR) NOT NULL,
	ISGEOCODE                               NUMBER(1),
	CHEMIN                                  VARCHAR2(254 CHAR) NOT NULL
);
COMMENT ON TABLE TB_MAP IS 'Cartes';
COMMENT ON COLUMN TB_MAP.TB_MODELE__MODELE IS 'Nom';
COMMENT ON COLUMN TB_MAP.TB_TEMPLATE__TPL IS 'Template';
COMMENT ON COLUMN TB_MAP.TB_GROUPE__GROUPE IS 'Groupe';
COMMENT ON COLUMN TB_MAP.MAP IS 'Carte';
COMMENT ON COLUMN TB_MAP.TITRE IS 'Titre';
COMMENT ON COLUMN TB_MAP.OBJTYPE IS 'Type objet';
COMMENT ON COLUMN TB_MAP.RANG IS 'Rang';
COMMENT ON COLUMN TB_MAP.MAP_ORDER IS 'Order';
COMMENT ON COLUMN TB_MAP.OWNER IS 'Schéma';
COMMENT ON COLUMN TB_MAP.ISGEOCODE IS 'Est gécodé';
COMMENT ON COLUMN TB_MAP.CHEMIN IS 'Chemin';

-- ---------------------------------------------------------
-- Table TB_MAP_CFG
-- ---------------------------------------------------------
CREATE TABLE TB_MAP_CFG 
( 
	TB_MODELE__MODELE                       VARCHAR2(50 CHAR) NOT NULL,
	TB_TEMPLATE__TPL                        VARCHAR2(50 CHAR) NOT NULL,
	TB_GROUPE__GROUPE                       VARCHAR2(50 CHAR) NOT NULL,
	TB_MAP__MAP                             VARCHAR2(50 CHAR) NOT NULL,
	USERCODE                                VARCHAR2(50 CHAR) NOT NULL,
	CODE_PRP                                VARCHAR2(50 CHAR) NOT NULL,
	VAL_PRP                                 VARCHAR2(254 CHAR) NOT NULL
);
COMMENT ON TABLE TB_MAP_CFG IS 'Configuration des cartes';
COMMENT ON COLUMN TB_MAP_CFG.TB_MODELE__MODELE IS 'Nom';
COMMENT ON COLUMN TB_MAP_CFG.TB_TEMPLATE__TPL IS 'Template';
COMMENT ON COLUMN TB_MAP_CFG.TB_GROUPE__GROUPE IS 'Groupe';
COMMENT ON COLUMN TB_MAP_CFG.TB_MAP__MAP IS 'Carte';
COMMENT ON COLUMN TB_MAP_CFG.USERCODE IS 'Utilisateur';
COMMENT ON COLUMN TB_MAP_CFG.CODE_PRP IS 'Propriétée';
COMMENT ON COLUMN TB_MAP_CFG.VAL_PRP IS 'Valeur';

-- ---------------------------------------------------------
-- Table TB_GROUPE_CFG
-- ---------------------------------------------------------
CREATE TABLE TB_GROUPE_CFG 
( 
	TB_MODELE__MODELE                       VARCHAR2(50 CHAR) NOT NULL,
	TB_TEMPLATE__TPL                        VARCHAR2(50 CHAR) NOT NULL,
	TB_GROUPE__GROUPE                       VARCHAR2(50 CHAR) NOT NULL,
	USERCODE                                VARCHAR2(50 CHAR) NOT NULL,
	CODE_PRP                                VARCHAR2(50 CHAR) NOT NULL,
	VAL_PRP                                 VARCHAR2(254 CHAR)
);
COMMENT ON TABLE TB_GROUPE_CFG IS 'Configuration des groupes';
COMMENT ON COLUMN TB_GROUPE_CFG.TB_MODELE__MODELE IS 'Nom';
COMMENT ON COLUMN TB_GROUPE_CFG.TB_TEMPLATE__TPL IS 'Template';
COMMENT ON COLUMN TB_GROUPE_CFG.TB_GROUPE__GROUPE IS 'Groupe';
COMMENT ON COLUMN TB_GROUPE_CFG.USERCODE IS 'Utilisateur';
COMMENT ON COLUMN TB_GROUPE_CFG.CODE_PRP IS 'Propriété';
COMMENT ON COLUMN TB_GROUPE_CFG.VAL_PRP IS 'Valeur';

-- ---------------------------------------------------------
-- Table TB_MODELE_CFG
-- ---------------------------------------------------------
CREATE TABLE TB_MODELE_CFG 
( 
	TB_MODELE__MODELE                       VARCHAR2(50 CHAR) NOT NULL,
	USERCODE                                VARCHAR2(50 CHAR) NOT NULL,
	CODE_PRP                                VARCHAR2(50 CHAR) NOT NULL,
	VAL_PRP                                 VARCHAR2(50 CHAR) NOT NULL
);
COMMENT ON TABLE TB_MODELE_CFG IS 'Configuration des modèles';
COMMENT ON COLUMN TB_MODELE_CFG.TB_MODELE__MODELE IS 'Nom';
COMMENT ON COLUMN TB_MODELE_CFG.USERCODE IS 'Utilisateur';
COMMENT ON COLUMN TB_MODELE_CFG.CODE_PRP IS 'Propriété';
COMMENT ON COLUMN TB_MODELE_CFG.VAL_PRP IS 'Valeur';

-- ---------------------------------------------------------
-- Table TB_TEMPLATE_CFG
-- ---------------------------------------------------------
CREATE TABLE TB_TEMPLATE_CFG 
( 
	TB_MODELE__MODELE                       VARCHAR2(50 CHAR) NOT NULL,
	TB_TEMPLATE__TPL                        VARCHAR2(50 CHAR) NOT NULL,
	USERCODE                                VARCHAR2(50 CHAR) NOT NULL,
	CODE_PRP                                VARCHAR2(20 CHAR) NOT NULL,
	VAL_PRP                                 VARCHAR2(254 CHAR) NOT NULL
);
COMMENT ON TABLE TB_TEMPLATE_CFG IS 'Configuration des templates';
COMMENT ON COLUMN TB_TEMPLATE_CFG.TB_MODELE__MODELE IS 'Nom';
COMMENT ON COLUMN TB_TEMPLATE_CFG.TB_TEMPLATE__TPL IS 'Template';
COMMENT ON COLUMN TB_TEMPLATE_CFG.USERCODE IS 'Utilisateur';
COMMENT ON COLUMN TB_TEMPLATE_CFG.CODE_PRP IS 'Propriétée';
COMMENT ON COLUMN TB_TEMPLATE_CFG.VAL_PRP IS 'Valeur';

-- ---------------------------------------------------------
-- Table TB_GROUPE
-- ---------------------------------------------------------
CREATE TABLE TB_GROUPE 
( 
	TB_MODELE__MODELE                       VARCHAR2(50 CHAR) NOT NULL,
	TB_TEMPLATE__TPL                        VARCHAR2(50 CHAR) NOT NULL,
	GROUPE                                  VARCHAR2(50 CHAR) NOT NULL,
	TITRE                                   VARCHAR2(50 CHAR) NOT NULL,
	RANG                                    NUMBER(9) NOT NULL,
	CHEMIN                                  VARCHAR2(254 CHAR),
	BOARDVISIBLE                            NUMBER(1)
);
COMMENT ON TABLE TB_GROUPE IS 'Groupe';
COMMENT ON COLUMN TB_GROUPE.TB_MODELE__MODELE IS 'Nom';
COMMENT ON COLUMN TB_GROUPE.TB_TEMPLATE__TPL IS 'Template';
COMMENT ON COLUMN TB_GROUPE.GROUPE IS 'Groupe';
COMMENT ON COLUMN TB_GROUPE.TITRE IS 'Titre';
COMMENT ON COLUMN TB_GROUPE.RANG IS 'Rang';
COMMENT ON COLUMN TB_GROUPE.CHEMIN IS 'Chemin';
COMMENT ON COLUMN TB_GROUPE.BOARDVISIBLE IS 'Afficher';

-- ---------------------------------------------------------
-- Table TB_MODELE
-- ---------------------------------------------------------
CREATE TABLE TB_MODELE 
( 
	MODELE                                  VARCHAR2(50 CHAR) NOT NULL,
	ORDRE                                   NUMBER(2),
	LAYER_NAME                              VARCHAR2(50 CHAR) NOT NULL,
	PATH                                    VARCHAR2(255 CHAR) NOT NULL,
	TYPE_MODELE                             NUMBER(1) NOT NULL
);
COMMENT ON TABLE TB_MODELE IS 'Modèle';
COMMENT ON COLUMN TB_MODELE.MODELE IS 'Nom';
COMMENT ON COLUMN TB_MODELE.ORDRE IS 'Ordre';
COMMENT ON COLUMN TB_MODELE.LAYER_NAME IS 'Couche MAPINFO';
COMMENT ON COLUMN TB_MODELE.PATH IS 'Fichier REF';
COMMENT ON COLUMN TB_MODELE.TYPE_MODELE IS 'Type de modèle';

-- ---------------------------------------------------------
-- Table CD_MOTS_RESERVE
-- ---------------------------------------------------------
CREATE TABLE CD_MOTS_RESERVE 
( 
	KEYWORD                                 VARCHAR2(50 CHAR) NOT NULL
);
COMMENT ON TABLE CD_MOTS_RESERVE IS 'Mots réservé Oracle';
COMMENT ON COLUMN CD_MOTS_RESERVE.KEYWORD IS 'Mot clef';

-- ---------------------------------------------------------
-- Table TB_ANA_THEMA
-- ---------------------------------------------------------
CREATE TABLE TB_ANA_THEMA 
( 
	USERCODE                                VARCHAR2(50 CHAR) NOT NULL,
	MAP                                     VARCHAR2(50 CHAR) NOT NULL,
	MODELE                                  VARCHAR2(100 CHAR) NOT NULL,
	CODE_PRP                                VARCHAR2(50 CHAR) NOT NULL,
	VAL_PRP                                 VARCHAR2(254 CHAR)
);
COMMENT ON TABLE TB_ANA_THEMA IS 'Sauvegarde des Analyses';
COMMENT ON COLUMN TB_ANA_THEMA.USERCODE IS 'Nom User';
COMMENT ON COLUMN TB_ANA_THEMA.MAP IS 'Carte';
COMMENT ON COLUMN TB_ANA_THEMA.MODELE IS 'Nom Modele';
COMMENT ON COLUMN TB_ANA_THEMA.CODE_PRP IS 'Code Prp';
COMMENT ON COLUMN TB_ANA_THEMA.VAL_PRP IS 'Valeur Prp';

-- ---------------------------------------------------------
-- Table SI_MODEL_PREDEF
-- ---------------------------------------------------------
CREATE TABLE SI_MODEL_PREDEF 
( 
	NOMTABLE                                VARCHAR2(100 CHAR) NOT NULL,
	NOMSCHEMA                               VARCHAR2(100 CHAR) NOT NULL,
	NOM_MODEL                               VARCHAR2(100 CHAR) NOT NULL
);
COMMENT ON TABLE SI_MODEL_PREDEF IS 'Si Model Predef';
COMMENT ON COLUMN SI_MODEL_PREDEF.NOMTABLE IS 'Si Model Predef  NomTable';
COMMENT ON COLUMN SI_MODEL_PREDEF.NOMSCHEMA IS 'Si Model Predef  NomSchema';
COMMENT ON COLUMN SI_MODEL_PREDEF.NOM_MODEL IS 'Si Model Predef  NomModel';

-- ---------------------------------------------------------
-- Table SI_PRP
-- ---------------------------------------------------------
CREATE TABLE SI_PRP 
( 
	CODE_PRP                                VARCHAR2(50 CHAR) NOT NULL,
	VAL_PRP                                 VARCHAR2(1024 CHAR) NOT NULL
);
COMMENT ON TABLE SI_PRP IS 'Si Prp';
COMMENT ON COLUMN SI_PRP.CODE_PRP IS 'Si Prp  Code Prp';
COMMENT ON COLUMN SI_PRP.VAL_PRP IS 'Si Prp  Val Prp';

-- ---------------------------------------------------------
-- Table SI_STYLE_VALEUR
-- ---------------------------------------------------------
CREATE TABLE SI_STYLE_VALEUR 
( 
	SI_MODEL__NOM_MODEL                     VARCHAR2(100 CHAR) NOT NULL,
	SI_ZONE__NOM_ZONE                       VARCHAR2(50 CHAR) NOT NULL,
	VALEUR                                  VARCHAR2(100 CHAR) NOT NULL,
	COULEUR                                 VARCHAR2(9 CHAR),
	BORDER                                  NUMBER(1),
	TAILLE                                  NUMBER(2),
	REPRESENTATION                          VARCHAR2(20 CHAR),
	CHEMIN                                  VARCHAR2(1024 CHAR),
	FONT_NAME                               VARCHAR2(50 CHAR),
	FONT_CHAR                               NUMBER(3),
	OPACITY                                 NUMBER(3,2)
);
COMMENT ON TABLE SI_STYLE_VALEUR IS 'Si Style Valeur';
COMMENT ON COLUMN SI_STYLE_VALEUR.SI_MODEL__NOM_MODEL IS 'Si Model  Nom Model';
COMMENT ON COLUMN SI_STYLE_VALEUR.SI_ZONE__NOM_ZONE IS 'Si Zone  Nom Zone';
COMMENT ON COLUMN SI_STYLE_VALEUR.VALEUR IS 'Si Style Valeur  Valeur';
COMMENT ON COLUMN SI_STYLE_VALEUR.COULEUR IS 'Si Style Valeur  Couleur';
COMMENT ON COLUMN SI_STYLE_VALEUR.BORDER IS 'Si Style Valeur  Border';
COMMENT ON COLUMN SI_STYLE_VALEUR.TAILLE IS 'Si Style Valeur  Taille';
COMMENT ON COLUMN SI_STYLE_VALEUR.REPRESENTATION IS 'Si Style Valeur  Representation';
COMMENT ON COLUMN SI_STYLE_VALEUR.CHEMIN IS 'Si Style Valeur  Chemin';
COMMENT ON COLUMN SI_STYLE_VALEUR.FONT_NAME IS 'Si Style Valeur Font Name';
COMMENT ON COLUMN SI_STYLE_VALEUR.FONT_CHAR IS 'Si Style Valeur Font Char';
COMMENT ON COLUMN SI_STYLE_VALEUR.OPACITY IS 'Si Style Valeur  Opacity';

-- ---------------------------------------------------------
-- Table SI_ZONE
-- ---------------------------------------------------------
CREATE TABLE SI_ZONE 
( 
	SI_MODEL__NOM_MODEL                     VARCHAR2(100 CHAR) NOT NULL,
	NOM_ZONE                                VARCHAR2(50 CHAR) NOT NULL,
	SCHEMA_ZONE                             VARCHAR2(100 CHAR),
	TABLE_ZONE                              VARCHAR2(100 CHAR),
	FIELD_ZONE                              VARCHAR2(100 CHAR),
	TYPE_ZONE                               VARCHAR2(25 CHAR),
	POSITION                                NUMBER(2),
	HAUTEUR                                 NUMBER(3),
	VALEUR                                  VARCHAR2(100 CHAR),
	VALEUR_SUB                              VARCHAR2(100 CHAR),
	ANNEE_MESURE                            NUMBER(4),
	POSITION_ETIQUETTE                      VARCHAR2(20 CHAR),
	CHAMP_ETIQUETTE                         VARCHAR2(50 CHAR),
	WITHCOTE                                NUMBER(1)
);
COMMENT ON TABLE SI_ZONE IS 'Si Zone';
COMMENT ON COLUMN SI_ZONE.SI_MODEL__NOM_MODEL IS 'Si Model  Nom Model';
COMMENT ON COLUMN SI_ZONE.NOM_ZONE IS 'Si Zone  Nom Zone';
COMMENT ON COLUMN SI_ZONE.SCHEMA_ZONE IS 'Si Zone  Schema Zone';
COMMENT ON COLUMN SI_ZONE.TABLE_ZONE IS 'Si Zone  Table Zone';
COMMENT ON COLUMN SI_ZONE.FIELD_ZONE IS 'Si Zone  Field Zone';
COMMENT ON COLUMN SI_ZONE.TYPE_ZONE IS 'Si Zone  Type Zone';
COMMENT ON COLUMN SI_ZONE.POSITION IS 'Si Zone  Position';
COMMENT ON COLUMN SI_ZONE.HAUTEUR IS 'Si Zone  Hauteur';
COMMENT ON COLUMN SI_ZONE.VALEUR IS 'Si Zone  Valeur';
COMMENT ON COLUMN SI_ZONE.VALEUR_SUB IS 'Si Zone  Valeur Sub';
COMMENT ON COLUMN SI_ZONE.ANNEE_MESURE IS 'Si Zone  Annee Mesure';
COMMENT ON COLUMN SI_ZONE.POSITION_ETIQUETTE IS 'Si Zone  Position Etiquette';
COMMENT ON COLUMN SI_ZONE.CHAMP_ETIQUETTE IS 'Si Zone  Champ Etiquette';
COMMENT ON COLUMN SI_ZONE.WITHCOTE IS 'Si Zone  WithCote';

-- ---------------------------------------------------------
-- Table SI_MODEL
-- ---------------------------------------------------------
CREATE TABLE SI_MODEL 
( 
	NOM_MODEL                               VARCHAR2(100 CHAR) NOT NULL
);
COMMENT ON TABLE SI_MODEL IS 'SI_MODEL';
COMMENT ON COLUMN SI_MODEL.NOM_MODEL IS 'Si Model  Nom Model';

-- ---------------------------------------------------------
-- Table SYS_USER_MAPINFO
-- ---------------------------------------------------------
CREATE TABLE SYS_USER_MAPINFO 
( 
	CODE_DBS                                VARCHAR2(50 CHAR) NOT NULL,
	CODE_TABLE                              VARCHAR2(100 CHAR) NOT NULL,
	CODE_COLONNE                            VARCHAR2(100 CHAR) NOT NULL,
	NOM_USER                                VARCHAR2(150 CHAR) NOT NULL,
	CODE_PRP                                VARCHAR2(255 CHAR) NOT NULL,
	VAL_PRP                                 VARCHAR2(500 CHAR) NOT NULL
);
COMMENT ON TABLE SYS_USER_MAPINFO IS 'SYS_USER_MAPINFO';
COMMENT ON COLUMN SYS_USER_MAPINFO.CODE_DBS IS 'SYS_USER_MAPINFO__CODE_DBS';
COMMENT ON COLUMN SYS_USER_MAPINFO.CODE_TABLE IS 'SYS_USER_MAPINFO__CODE_TABLE';
COMMENT ON COLUMN SYS_USER_MAPINFO.CODE_COLONNE IS 'SYS_USER_MAPINFO__CODE_COLONNE';
COMMENT ON COLUMN SYS_USER_MAPINFO.NOM_USER IS 'SYS_USER_MAPINFO__NOM_USER';
COMMENT ON COLUMN SYS_USER_MAPINFO.CODE_PRP IS 'SYS_USER_MAPINFO__CODE_PRP';
COMMENT ON COLUMN SYS_USER_MAPINFO.VAL_PRP IS 'SYS_USER_MAPINFO__VAL_PRP';

-- ---------------------------------------------------------
-- Table TB_MAP_METIER
-- ---------------------------------------------------------
CREATE TABLE TB_MAP_METIER 
( 
	SCHEMA_NAME                             VARCHAR2(20 CHAR) NOT NULL,
	TABLE_NAME                              VARCHAR2(50 CHAR) NOT NULL,
	TITLE                                   VARCHAR2(50 CHAR),
	MAP_ORDER                               NUMBER(2),
	RANG                                    NUMBER(2),
	OBJTYPE                                 NUMBER(2)
);
COMMENT ON TABLE TB_MAP_METIER IS 'Tb Map Metier';
COMMENT ON COLUMN TB_MAP_METIER.SCHEMA_NAME IS 'Tb Map Metier  Schema Name';
COMMENT ON COLUMN TB_MAP_METIER.TABLE_NAME IS 'Tb Map Metier  Table Name';
COMMENT ON COLUMN TB_MAP_METIER.TITLE IS 'Tb Map Metier  Title';
COMMENT ON COLUMN TB_MAP_METIER.MAP_ORDER IS 'Tb Map Metier  Map Order';
COMMENT ON COLUMN TB_MAP_METIER.RANG IS 'Tb Map Metier  Rang';
COMMENT ON COLUMN TB_MAP_METIER.OBJTYPE IS 'Tb Map Metier  ObjType';

-- ---------------------------------------------------------
-- Table TB_MAP_METIER_CFG
-- ---------------------------------------------------------
CREATE TABLE TB_MAP_METIER_CFG 
( 
	TB_MAP_METIER__SCHEMA_NAME              VARCHAR2(20 CHAR) NOT NULL,
	TB_MAP_METIER__TABLE_NAME               VARCHAR2(50 CHAR) NOT NULL,
	USERCODE                                VARCHAR2(50 CHAR) NOT NULL,
	CODE_PRP                                VARCHAR2(50 CHAR) NOT NULL,
	VAL_PRP                                 VARCHAR2(254 CHAR) NOT NULL
);
COMMENT ON TABLE TB_MAP_METIER_CFG IS 'Tb Map Metier Cfg';
COMMENT ON COLUMN TB_MAP_METIER_CFG.TB_MAP_METIER__SCHEMA_NAME IS 'Tb Map Metier  Schema Name';
COMMENT ON COLUMN TB_MAP_METIER_CFG.TB_MAP_METIER__TABLE_NAME IS 'Tb Map Metier  Table Name';
COMMENT ON COLUMN TB_MAP_METIER_CFG.USERCODE IS 'Tb Map Metier Cfg  Usercode';
COMMENT ON COLUMN TB_MAP_METIER_CFG.CODE_PRP IS 'Tb Map Metier Cfg  Code Prp';
COMMENT ON COLUMN TB_MAP_METIER_CFG.VAL_PRP IS 'Tb Map Metier Cfg  Val Prp';

-- ---------------------------------------------------------
-- Table TB_MAP_METIER_COLUMNS
-- ---------------------------------------------------------
CREATE TABLE TB_MAP_METIER_COLUMNS 
( 
	TB_MAP_METIER__SCHEMA_NAME              VARCHAR2(20 CHAR) NOT NULL,
	TB_MAP_METIER__TABLE_NAME               VARCHAR2(50 CHAR) NOT NULL,
	COL_NAME                                VARCHAR2(100 CHAR) NOT NULL,
	COL_LIBELLE                             VARCHAR2(50 CHAR) NOT NULL,
	COL_ORDER                               NUMBER(2),
	COL_VISIBLE                             NUMBER(2)
);
COMMENT ON TABLE TB_MAP_METIER_COLUMNS IS 'Tb Map Metier Columns';
COMMENT ON COLUMN TB_MAP_METIER_COLUMNS.TB_MAP_METIER__SCHEMA_NAME IS 'Tb Map Metier  Schema Name';
COMMENT ON COLUMN TB_MAP_METIER_COLUMNS.TB_MAP_METIER__TABLE_NAME IS 'Tb Map Metier  Table Name';
COMMENT ON COLUMN TB_MAP_METIER_COLUMNS.COL_NAME IS 'Tb Map Metier Columns  Col Name';
COMMENT ON COLUMN TB_MAP_METIER_COLUMNS.COL_LIBELLE IS 'Tb Map Metier Columns  Col Libelle';
COMMENT ON COLUMN TB_MAP_METIER_COLUMNS.COL_ORDER IS 'Tb Map Metier Columns  Col Order';
COMMENT ON COLUMN TB_MAP_METIER_COLUMNS.COL_VISIBLE IS 'Tb Map Metier Columns  Col Visible';

-- ---------------------------------------------------------
-- Table TB_MAP_GEO_STYLE
-- ---------------------------------------------------------
CREATE TABLE TB_MAP_GEO_STYLE 
( 
	MAP                                     VARCHAR2(50 CHAR) NOT NULL,
	USERNAME                                VARCHAR2(50 CHAR) NOT NULL,
	REPRESENTATION                          VARCHAR2(50 CHAR) NOT NULL,
	COLOR                                   NUMBER(10) NOT NULL,
	WIDTH                                   NUMBER(2) NOT NULL,
	FONT                                    VARCHAR2(50 CHAR),
	ASCII                                   NUMBER(3),
	STYLE                                   NUMBER(5),
	INTERLEAVED                             NUMBER(1),
	BORDERCOLOR                             NUMBER(10),
	BORDERSTYLE                             NUMBER(5),
	REGIONBACKGROUND                        NUMBER(10)
);
COMMENT ON TABLE TB_MAP_GEO_STYLE IS 'TB_MAP_GEO_STYLE';
COMMENT ON COLUMN TB_MAP_GEO_STYLE.MAP IS 'Map';
COMMENT ON COLUMN TB_MAP_GEO_STYLE.USERNAME IS 'UserName';
COMMENT ON COLUMN TB_MAP_GEO_STYLE.REPRESENTATION IS 'Représentation';
COMMENT ON COLUMN TB_MAP_GEO_STYLE.COLOR IS 'Couleur';
COMMENT ON COLUMN TB_MAP_GEO_STYLE.WIDTH IS 'Largeur';
COMMENT ON COLUMN TB_MAP_GEO_STYLE.FONT IS 'Police';
COMMENT ON COLUMN TB_MAP_GEO_STYLE.ASCII IS 'Code ASCII';
COMMENT ON COLUMN TB_MAP_GEO_STYLE.STYLE IS 'Style';
COMMENT ON COLUMN TB_MAP_GEO_STYLE.INTERLEAVED IS 'Interleaved';
COMMENT ON COLUMN TB_MAP_GEO_STYLE.BORDERCOLOR IS 'BorderColor';
COMMENT ON COLUMN TB_MAP_GEO_STYLE.BORDERSTYLE IS 'BorderStyle';
COMMENT ON COLUMN TB_MAP_GEO_STYLE.REGIONBACKGROUND IS 'RegionBackground';

-- ---------------------------------------------------------
-- Table TB_TEMPLATE
-- ---------------------------------------------------------
CREATE TABLE TB_TEMPLATE 
( 
	TB_MODELE__MODELE                       VARCHAR2(50 CHAR) NOT NULL,
	TPL                                     VARCHAR2(50 CHAR) NOT NULL,
	TITRE                                   VARCHAR2(50 CHAR) NOT NULL,
	RANG                                    NUMBER(9) NOT NULL,
	CHEMIN                                  VARCHAR2(254 CHAR),
	ISGEOCODE                               NUMBER(1)
);
COMMENT ON TABLE TB_TEMPLATE IS 'Template';
COMMENT ON COLUMN TB_TEMPLATE.TB_MODELE__MODELE IS 'Nom';
COMMENT ON COLUMN TB_TEMPLATE.TPL IS 'Template';
COMMENT ON COLUMN TB_TEMPLATE.TITRE IS 'Titre';
COMMENT ON COLUMN TB_TEMPLATE.RANG IS 'Rang';
COMMENT ON COLUMN TB_TEMPLATE.CHEMIN IS 'Chemin';
COMMENT ON COLUMN TB_TEMPLATE.ISGEOCODE IS 'Est géocodé';

