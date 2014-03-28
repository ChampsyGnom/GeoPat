/*################################################################################################*/
/* Script     : DS_Tables.sql                                                                     */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

-- ---------------------------------------------------------
-- Table SYS_PRP_DS
-- ---------------------------------------------------------

CREATE TABLE SYS_PRP_DS 
( 
	CODE_TABLE                    VARCHAR2(60 CHAR)        NOT NULL,
	CODE_COLONNE                  VARCHAR2(60 CHAR)        NOT NULL,
	NOM_USER                      VARCHAR2(30 CHAR)        NOT NULL,
	CODE_PRP                      VARCHAR2(60 CHAR)        NOT NULL,
	VAL_PRP                       VARCHAR2(255 CHAR)       );
COMMENT ON TABLE SYS_PRP_DS IS 'MétaDonnées du schéma DS';

-- ---------------------------------------------------------
-- Table SYS_INSTANCE_DS
-- ---------------------------------------------------------

CREATE TABLE SYS_INSTANCE_DS 
( 
	CODE                   VARCHAR2(100 CHAR) NOT NULL,
	VALEUR                 CLOB);
COMMENT ON TABLE SYS_INSTANCE_DS IS 'Informations du schéma DS';

-- ---------------------------------------------------------
-- Table BPU_COLOR_DS
-- ---------------------------------------------------------
CREATE TABLE BPU_COLOR_DS 
( 
	CODE                                    VARCHAR2(30 CHAR) NOT NULL,
	COLOR                                   VARCHAR2(11 CHAR)
);
COMMENT ON TABLE BPU_COLOR_DS IS 'BPU_COLOR_DS';
COMMENT ON COLUMN BPU_COLOR_DS.CODE IS 'BPU_COLOR_DS__CODE';
COMMENT ON COLUMN BPU_COLOR_DS.COLOR IS 'BPU_COLOR_DS__COLOR';

-- ---------------------------------------------------------
-- Table AGREGE_DS
-- ---------------------------------------------------------
CREATE TABLE AGREGE_DS 
( 
	CODE                                    VARCHAR2(15 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(200 CHAR) NOT NULL,
	SRC_AGR                                 VARCHAR2(15 CHAR),
	SRC_INDIC                               VARCHAR2(15 CHAR),
	SEUIL1                                  NUMBER(12,2),
	SEUIL2                                  NUMBER(12,2),
	SEUIL3                                  NUMBER(12,2),
	SEUIL4                                  NUMBER(12,2),
	VALEUR_SENS                             VARCHAR2(2 CHAR),
	VALEUR_ABS                              NUMBER
);
COMMENT ON TABLE AGREGE_DS IS 'Indicateur agrégés';
COMMENT ON COLUMN AGREGE_DS.CODE IS 'AGREGE_DS__CODE';
COMMENT ON COLUMN AGREGE_DS.LIBELLE IS 'AGREGE_DS__LIBELLE';
COMMENT ON COLUMN AGREGE_DS.SRC_AGR IS 'AGREGE_DS__SRC_AGR';
COMMENT ON COLUMN AGREGE_DS.SRC_INDIC IS 'AGREGE_DS__SRC_INDIC';
COMMENT ON COLUMN AGREGE_DS.SEUIL1 IS 'AGREGE_DS__SEUIL1';
COMMENT ON COLUMN AGREGE_DS.SEUIL2 IS 'AGREGE_DS__SEUIL2';
COMMENT ON COLUMN AGREGE_DS.SEUIL3 IS 'AGREGE_DS__SEUIL3';
COMMENT ON COLUMN AGREGE_DS.SEUIL4 IS 'AGREGE_DS__SEUIL4';
COMMENT ON COLUMN AGREGE_DS.VALEUR_SENS IS 'AGREGE_DS__VALEUR_SENS';
COMMENT ON COLUMN AGREGE_DS.VALEUR_ABS IS 'AGREGE_DS__VALEUR_ABS';

-- ---------------------------------------------------------
-- Table MAT_DS
-- ---------------------------------------------------------
CREATE TABLE MAT_DS 
( 
	CODE                                    VARCHAR2(15 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(200 CHAR) NOT NULL,
	AGR_X                                   VARCHAR2(15 CHAR),
	INDIC_X                                 VARCHAR2(15 CHAR),
	AGR_Y                                   VARCHAR2(15 CHAR),
	INDIC_Y                                 VARCHAR2(15 CHAR)
);
COMMENT ON TABLE MAT_DS IS 'MAT_DS';
COMMENT ON COLUMN MAT_DS.CODE IS 'MAT_DS__CODE';
COMMENT ON COLUMN MAT_DS.LIBELLE IS 'MAT_DS__LIBELLE';
COMMENT ON COLUMN MAT_DS.AGR_X IS 'MAT_DS__AGR_X';
COMMENT ON COLUMN MAT_DS.INDIC_X IS 'MAT_DS__INDIC_X';
COMMENT ON COLUMN MAT_DS.AGR_Y IS 'MAT_DS__AGR_Y';
COMMENT ON COLUMN MAT_DS.INDIC_Y IS 'MAT_DS__INDIC_Y';

-- ---------------------------------------------------------
-- Table MAT_PARAM_DS
-- ---------------------------------------------------------
CREATE TABLE MAT_PARAM_DS 
( 
	MAT_DS__CODE                            VARCHAR2(15 CHAR) NOT NULL,
	X                                       NUMBER(9) NOT NULL,
	Y                                       NUMBER(9) NOT NULL,
	VALEUR                                  NUMBER(9) NOT NULL
);
COMMENT ON TABLE MAT_PARAM_DS IS 'MAT_PARAM_DS';
COMMENT ON COLUMN MAT_PARAM_DS.MAT_DS__CODE IS 'MAT_DS__CODE';
COMMENT ON COLUMN MAT_PARAM_DS.X IS 'MAT_PARAM_DS__X';
COMMENT ON COLUMN MAT_PARAM_DS.Y IS 'MAT_PARAM_DS__Y';
COMMENT ON COLUMN MAT_PARAM_DS.VALEUR IS 'MAT_PARAM_DS__VALEUR';

-- ---------------------------------------------------------
-- Table NODE_DS
-- ---------------------------------------------------------
CREATE TABLE NODE_DS 
( 
	TREE_DS__ID                             NUMBER(9) NOT NULL,
	ID                                      NUMBER(9) NOT NULL,
	LIBELLE                                 VARCHAR2(200 CHAR),
	TYPE                                    VARCHAR2(100 CHAR) NOT NULL,
	PARENT_ID                               NUMBER(9) NOT NULL,
	TECHNIQUE                               VARCHAR2(100 CHAR),
	STRUCTURE                               VARCHAR2(100 CHAR),
	NB_SI                                   NUMBER(9),
	IS_FOR_TRUE                             NUMBER(9) NOT NULL
);
COMMENT ON TABLE NODE_DS IS 'NODE_DS';
COMMENT ON COLUMN NODE_DS.TREE_DS__ID IS 'TREE_DS__ID';
COMMENT ON COLUMN NODE_DS.ID IS 'NODE_DS__ID';
COMMENT ON COLUMN NODE_DS.LIBELLE IS 'NODE_DS__LIBELLE';
COMMENT ON COLUMN NODE_DS.TYPE IS 'NODE_DS__TYPE';
COMMENT ON COLUMN NODE_DS.PARENT_ID IS 'NODE_DS__PARENT_ID';
COMMENT ON COLUMN NODE_DS.TECHNIQUE IS 'NODE_DS__TECHNIQUE';
COMMENT ON COLUMN NODE_DS.STRUCTURE IS 'NODE_DS__STRUCTURE';
COMMENT ON COLUMN NODE_DS.NB_SI IS 'NODE_DS__NB_SI';
COMMENT ON COLUMN NODE_DS.IS_FOR_TRUE IS 'NODE_DS__IS_FOR_TRUE';

-- ---------------------------------------------------------
-- Table NODE_PARAM_DS
-- ---------------------------------------------------------
CREATE TABLE NODE_PARAM_DS 
( 
	TREE_DS__ID                             NUMBER(9) NOT NULL,
	NODE_DS__ID                             NUMBER(9) NOT NULL,
	ID                                      NUMBER(9) NOT NULL,
	AGR                                     VARCHAR2(20 CHAR),
	INDIC                                   VARCHAR2(20 CHAR),
	COMPARE_VALUE                           NUMBER(9),
	COMPARE_OP                              VARCHAR2(50 CHAR)
);
COMMENT ON TABLE NODE_PARAM_DS IS 'NODE_PARAM_DS';
COMMENT ON COLUMN NODE_PARAM_DS.TREE_DS__ID IS 'TREE_DS__ID';
COMMENT ON COLUMN NODE_PARAM_DS.NODE_DS__ID IS 'NODE_DS__ID';
COMMENT ON COLUMN NODE_PARAM_DS.ID IS 'NODE_PARAM_DS__ID';
COMMENT ON COLUMN NODE_PARAM_DS.AGR IS 'NODE_PARAM_DS__AGR';
COMMENT ON COLUMN NODE_PARAM_DS.INDIC IS 'NODE_PARAM_DS__INDIC';
COMMENT ON COLUMN NODE_PARAM_DS.COMPARE_VALUE IS 'NODE_PARAM_DS__COMPARE_VALUE';
COMMENT ON COLUMN NODE_PARAM_DS.COMPARE_OP IS 'NODE_PARAM_DS__COMPARE_OP';

-- ---------------------------------------------------------
-- Table PON_DS
-- ---------------------------------------------------------
CREATE TABLE PON_DS 
( 
	CODE                                    VARCHAR2(15 CHAR) NOT NULL,
	LIBELLE                                 VARCHAR2(200 CHAR) NOT NULL,
	AGR                                     VARCHAR2(15 CHAR)
);
COMMENT ON TABLE PON_DS IS 'PON_DS';
COMMENT ON COLUMN PON_DS.CODE IS 'PON_DS__CODE';
COMMENT ON COLUMN PON_DS.LIBELLE IS 'PON_DS__LIBELLE';
COMMENT ON COLUMN PON_DS.AGR IS 'PON_DS__AGR';

-- ---------------------------------------------------------
-- Table PON_PARAM_DS
-- ---------------------------------------------------------
CREATE TABLE PON_PARAM_DS 
( 
	PON_DS__CODE                            VARCHAR2(15 CHAR) NOT NULL,
	INDIC                                   VARCHAR2(12 CHAR) NOT NULL,
	POID                                    NUMBER(9) NOT NULL
);
COMMENT ON TABLE PON_PARAM_DS IS 'PON_PARAM_DS';
COMMENT ON COLUMN PON_PARAM_DS.PON_DS__CODE IS 'PON_DS__CODE';
COMMENT ON COLUMN PON_PARAM_DS.INDIC IS 'PON_PARAM_DS__INDIC';
COMMENT ON COLUMN PON_PARAM_DS.POID IS 'PON_PARAM_DS__POID';

-- ---------------------------------------------------------
-- Table SIM_CALCUL_DS
-- ---------------------------------------------------------
CREATE TABLE SIM_CALCUL_DS 
( 
	ID                                      NUMBER(9) NOT NULL,
	SIM_ETUDE_DS__ID                        NUMBER(9) NOT NULL,
	LIBELLE                                 VARCHAR2(100 CHAR),
	"COMMENT"                                 VARCHAR2(2000 CHAR)
);
COMMENT ON TABLE SIM_CALCUL_DS IS 'SIM_CALCUL_DS';
COMMENT ON COLUMN SIM_CALCUL_DS.ID IS 'SIM_CALCUL_DS__ID';
COMMENT ON COLUMN SIM_CALCUL_DS.SIM_ETUDE_DS__ID IS 'SIM_ETUDE_DS__ID';
COMMENT ON COLUMN SIM_CALCUL_DS.LIBELLE IS 'SIM_CALCUL_DS__LIBELLE';
COMMENT ON COLUMN SIM_CALCUL_DS.COMMENT IS 'SIM_CALCUL_DS__COMMENT';

-- ---------------------------------------------------------
-- Table SIM_CALCUL_FIS_DS
-- ---------------------------------------------------------
CREATE TABLE SIM_CALCUL_FIS_DS 
( 
	SIM_CALCUL_TRAFIC_DS__ID                NUMBER(9) NOT NULL,
	SIM_FIS_DS__ID                          NUMBER(9) NOT NULL
);
COMMENT ON TABLE SIM_CALCUL_FIS_DS IS 'SIM_CALCUL_FIS_DS';
COMMENT ON COLUMN SIM_CALCUL_FIS_DS.SIM_CALCUL_TRAFIC_DS__ID IS 'SIM_CALCUL_TRAFIC_DS__ID';
COMMENT ON COLUMN SIM_CALCUL_FIS_DS.SIM_FIS_DS__ID IS 'SIM_FIS_DS__ID';

-- ---------------------------------------------------------
-- Table SIM_CALCUL_TRAFIC_DS
-- ---------------------------------------------------------
CREATE TABLE SIM_CALCUL_TRAFIC_DS 
( 
	ID                                      NUMBER(9) NOT NULL,
	SIM_CALCUL_DS__ID                       NUMBER(9) NOT NULL,
	SIM_ENTRETIEN_DS__ID                    NUMBER(9),
	SIM_DVP_DS__ID                          NUMBER(9),
	SIM_REC_DS__ID                          NUMBER(9),
	TRAFIC                                  VARCHAR2(10 CHAR) NOT NULL
);
COMMENT ON TABLE SIM_CALCUL_TRAFIC_DS IS 'SIM_CALCUL_TRAFIC_DS';
COMMENT ON COLUMN SIM_CALCUL_TRAFIC_DS.ID IS 'SIM_CALCUL_TRAFIC_DS__ID';
COMMENT ON COLUMN SIM_CALCUL_TRAFIC_DS.SIM_CALCUL_DS__ID IS 'SIM_CALCUL_DS__ID';
COMMENT ON COLUMN SIM_CALCUL_TRAFIC_DS.SIM_ENTRETIEN_DS__ID IS 'SIM_ENTRETIEN_DS__ID';
COMMENT ON COLUMN SIM_CALCUL_TRAFIC_DS.SIM_DVP_DS__ID IS 'SIM_DVP_DS__ID';
COMMENT ON COLUMN SIM_CALCUL_TRAFIC_DS.SIM_REC_DS__ID IS 'SIM_REC_DS__ID';
COMMENT ON COLUMN SIM_CALCUL_TRAFIC_DS.TRAFIC IS 'SIM_CALCUL_TRAFIC_DS__TRAFIC';

-- ---------------------------------------------------------
-- Table SIM_DVP_DS
-- ---------------------------------------------------------
CREATE TABLE SIM_DVP_DS 
( 
	ID                                      NUMBER(9) NOT NULL,
	SIM_ETUDE_DS__ID                        NUMBER(9) NOT NULL,
	LIBELLE                                 VARCHAR2(100 CHAR),
	COULEUR                                 VARCHAR2(12 CHAR) NOT NULL
);
COMMENT ON TABLE SIM_DVP_DS IS 'SIM_DVP_DS';
COMMENT ON COLUMN SIM_DVP_DS.ID IS 'SIM_DVP_DS__ID';
COMMENT ON COLUMN SIM_DVP_DS.SIM_ETUDE_DS__ID IS 'SIM_ETUDE_DS__ID';
COMMENT ON COLUMN SIM_DVP_DS.LIBELLE IS 'SIM_DVP_DS__LIBELLE';
COMMENT ON COLUMN SIM_DVP_DS.COULEUR IS 'SIM_DVP_DS__COULEUR';

-- ---------------------------------------------------------
-- Table SIM_DVP_VALUES_DS
-- ---------------------------------------------------------
CREATE TABLE SIM_DVP_VALUES_DS 
( 
	SIM_DVP_DS__ID                          NUMBER(9) NOT NULL,
	ANNEE                                   NUMBER(9) NOT NULL,
	VALEUR                                  NUMBER(9) NOT NULL
);
COMMENT ON TABLE SIM_DVP_VALUES_DS IS 'SIM_DVP_VALUES_DS';
COMMENT ON COLUMN SIM_DVP_VALUES_DS.SIM_DVP_DS__ID IS 'SIM_DVP_DS__ID';
COMMENT ON COLUMN SIM_DVP_VALUES_DS.ANNEE IS 'SIM_DVP_VALUES_DS__ANNEE';
COMMENT ON COLUMN SIM_DVP_VALUES_DS.VALEUR IS 'SIM_DVP_VALUES_DS__VALEUR';

-- ---------------------------------------------------------
-- Table SIM_ENTRETIEN_DS
-- ---------------------------------------------------------
CREATE TABLE SIM_ENTRETIEN_DS 
( 
	ID                                      NUMBER(9) NOT NULL,
	SIM_ETUDE_DS__ID                        NUMBER(9) NOT NULL,
	AGE                                     NUMBER(4) NOT NULL,
	EPAISSEUR                               NUMBER(6,2),
	LIBELLE                                 VARCHAR2(100 CHAR),
	COULEUR                                 VARCHAR2(12 CHAR) NOT NULL
);
COMMENT ON TABLE SIM_ENTRETIEN_DS IS 'SIM_ENTRETIEN_DS';
COMMENT ON COLUMN SIM_ENTRETIEN_DS.ID IS 'SIM_ENTRETIEN_DS__ID';
COMMENT ON COLUMN SIM_ENTRETIEN_DS.SIM_ETUDE_DS__ID IS 'SIM_ETUDE_DS__ID';
COMMENT ON COLUMN SIM_ENTRETIEN_DS.AGE IS 'SIM_ENTRETIEN_DS__AGE';
COMMENT ON COLUMN SIM_ENTRETIEN_DS.EPAISSEUR IS 'SIM_ENTRETIEN_DS__EPAISSEUR';
COMMENT ON COLUMN SIM_ENTRETIEN_DS.LIBELLE IS 'SIM_ENTRETIEN_DS__LIBELLE';
COMMENT ON COLUMN SIM_ENTRETIEN_DS.COULEUR IS 'SIM_ENTRETIEN_DS__COULEUR';

-- ---------------------------------------------------------
-- Table SIM_ETUDE_DS
-- ---------------------------------------------------------
CREATE TABLE SIM_ETUDE_DS 
( 
	ID                                      NUMBER(9) NOT NULL,
	LIBELLE                                 VARCHAR2(100 CHAR),
	ANNEE_MIN                               NUMBER(9) NOT NULL,
	ANNEE_MAX                               NUMBER(9) NOT NULL,
	ANNEE_MIN_CALCUL                        NUMBER(9) NOT NULL,
	ANNEE_MAX_CALCUL                        NUMBER(9) NOT NULL
);
COMMENT ON TABLE SIM_ETUDE_DS IS 'SIM_ETUDE_DS';
COMMENT ON COLUMN SIM_ETUDE_DS.ID IS 'SIM_ETUDE_DS__ID';
COMMENT ON COLUMN SIM_ETUDE_DS.LIBELLE IS 'SIM_ETUDE_DS__LIBELLE';
COMMENT ON COLUMN SIM_ETUDE_DS.ANNEE_MIN IS 'SIM_ETUDE_DS__ANNEE_MIN';
COMMENT ON COLUMN SIM_ETUDE_DS.ANNEE_MAX IS 'SIM_ETUDE_DS__ANNEE_MAX';
COMMENT ON COLUMN SIM_ETUDE_DS.ANNEE_MIN_CALCUL IS 'SIM_ETUDE_DS__ANNEE_MIN_CALCUL';
COMMENT ON COLUMN SIM_ETUDE_DS.ANNEE_MAX_CALCUL IS 'SIM_ETUDE_DS__ANNEE_MAX_CALCUL';

-- ---------------------------------------------------------
-- Table SIM_FIS_CLASSE_DS
-- ---------------------------------------------------------
CREATE TABLE SIM_FIS_CLASSE_DS 
( 
	SIM_FIS_DS__ID                          NUMBER(9) NOT NULL,
	ID                                      NUMBER(9) NOT NULL,
	COULEUR                                 VARCHAR2(12 CHAR) NOT NULL,
	PERCENT_MIN                             NUMBER(9) NOT NULL,
	PERCENT_MAX                             NUMBER(9) NOT NULL
);
COMMENT ON TABLE SIM_FIS_CLASSE_DS IS 'SIM_FIS_CLASSE_DS';
COMMENT ON COLUMN SIM_FIS_CLASSE_DS.SIM_FIS_DS__ID IS 'SIM_FIS_DS__ID';
COMMENT ON COLUMN SIM_FIS_CLASSE_DS.ID IS 'SIM_FIS_CLASSE_DS__ID';
COMMENT ON COLUMN SIM_FIS_CLASSE_DS.COULEUR IS 'SIM_FIS_CLASSE_DS__COULEUR';
COMMENT ON COLUMN SIM_FIS_CLASSE_DS.PERCENT_MIN IS 'SIM_FIS_CLASSE_DS__PERCENT_MIN';
COMMENT ON COLUMN SIM_FIS_CLASSE_DS.PERCENT_MAX IS 'SIM_FIS_CLASSE_DS__PERCENT_MAX';

-- ---------------------------------------------------------
-- Table SIM_FIS_DS
-- ---------------------------------------------------------
CREATE TABLE SIM_FIS_DS 
( 
	ID                                      NUMBER(9) NOT NULL,
	SIM_ETUDE_DS__ID                        NUMBER(9) NOT NULL,
	LIBELLE                                 VARCHAR2(100 CHAR),
	COULEUR                                 VARCHAR2(12 CHAR) NOT NULL
);
COMMENT ON TABLE SIM_FIS_DS IS 'SIM_FIS_DS';
COMMENT ON COLUMN SIM_FIS_DS.ID IS 'SIM_FIS_DS__ID';
COMMENT ON COLUMN SIM_FIS_DS.SIM_ETUDE_DS__ID IS 'SIM_ETUDE_DS__ID';
COMMENT ON COLUMN SIM_FIS_DS.LIBELLE IS 'SIM_FIS_DS__LIBELLE';
COMMENT ON COLUMN SIM_FIS_DS.COULEUR IS 'SIM_FIS_DS__COULEUR';

-- ---------------------------------------------------------
-- Table SIM_FIS_VALUES_DS
-- ---------------------------------------------------------
CREATE TABLE SIM_FIS_VALUES_DS 
( 
	SIM_FIS_DS__ID                          NUMBER(9) NOT NULL,
	SIM_FIS_CLASSE_DS__ID                   NUMBER(9) NOT NULL,
	ANNEE                                   NUMBER(9) NOT NULL,
	VALEUR                                  NUMBER(9) NOT NULL
);
COMMENT ON TABLE SIM_FIS_VALUES_DS IS 'SIM_FIS_VALUES_DS';
COMMENT ON COLUMN SIM_FIS_VALUES_DS.SIM_FIS_DS__ID IS 'SIM_FIS_DS__ID';
COMMENT ON COLUMN SIM_FIS_VALUES_DS.SIM_FIS_CLASSE_DS__ID IS 'SIM_FIS_CLASSE_DS__ID';
COMMENT ON COLUMN SIM_FIS_VALUES_DS.ANNEE IS 'SIM_FIS_VALUES_DS__ANNEE';
COMMENT ON COLUMN SIM_FIS_VALUES_DS.VALEUR IS 'SIM_FIS_VALUES_DS__VALEUR';

-- ---------------------------------------------------------
-- Table SIM_REC_DS
-- ---------------------------------------------------------
CREATE TABLE SIM_REC_DS 
( 
	ID                                      NUMBER(9) NOT NULL,
	SIM_ETUDE_DS__ID                        NUMBER(9) NOT NULL,
	LIBELLE                                 VARCHAR2(100 CHAR),
	COULEUR                                 VARCHAR2(12 CHAR) NOT NULL,
	DURREE_SERVICE                          NUMBER(9) NOT NULL
);
COMMENT ON TABLE SIM_REC_DS IS 'SIM_REC_DS';
COMMENT ON COLUMN SIM_REC_DS.ID IS 'SIM_REC_DS__ID';
COMMENT ON COLUMN SIM_REC_DS.SIM_ETUDE_DS__ID IS 'SIM_ETUDE_DS__ID';
COMMENT ON COLUMN SIM_REC_DS.LIBELLE IS 'SIM_REC_DS__LIBELLE';
COMMENT ON COLUMN SIM_REC_DS.COULEUR IS 'SIM_REC_DS__COULEUR';
COMMENT ON COLUMN SIM_REC_DS.DURREE_SERVICE IS 'SIM_REC_DS__DURREE_SERVICE';

-- ---------------------------------------------------------
-- Table SIM_REC_VALUES_DS
-- ---------------------------------------------------------
CREATE TABLE SIM_REC_VALUES_DS 
( 
	SIM_REC_DS__ID                          NUMBER(9) NOT NULL,
	ANNEE                                   NUMBER(9) NOT NULL,
	VALEUR                                  NUMBER(9) NOT NULL
);
COMMENT ON TABLE SIM_REC_VALUES_DS IS 'SIM_REC_VALUES_DS';
COMMENT ON COLUMN SIM_REC_VALUES_DS.SIM_REC_DS__ID IS 'SIM_REC_DS__ID';
COMMENT ON COLUMN SIM_REC_VALUES_DS.ANNEE IS 'SIM_REC_VALUES_DS__ANNEE';
COMMENT ON COLUMN SIM_REC_VALUES_DS.VALEUR IS 'SIM_REC_VALUES_DS__VALEUR';

-- ---------------------------------------------------------
-- Table SIM_RESULT_DS
-- ---------------------------------------------------------
CREATE TABLE SIM_RESULT_DS 
( 
	SIM_CALCUL_TRAFIC_DS__ID                NUMBER(9) NOT NULL,
	SIM_FIS_DS__ID                          NUMBER(9) NOT NULL,
	LIAISON                                 VARCHAR2(15 CHAR) NOT NULL,
	SENS                                    VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	ANNEE                                   NUMBER(4) NOT NULL,
	ABS_FIN                                 NUMBER(6) NOT NULL,
	DVR                                     NUMBER(4) NOT NULL,
	FIS                                     NUMBER(4) NOT NULL,
	LINEAIRE                                NUMBER(8) NOT NULL,
	SURFACE                                 NUMBER(8) NOT NULL,
	EPAISSEUR                               NUMBER(8) NOT NULL
);
COMMENT ON TABLE SIM_RESULT_DS IS 'SIM_RESULT_DS';
COMMENT ON COLUMN SIM_RESULT_DS.SIM_CALCUL_TRAFIC_DS__ID IS 'SIM_CALCUL_TRAFIC_DS__ID';
COMMENT ON COLUMN SIM_RESULT_DS.SIM_FIS_DS__ID IS 'SIM_FIS_DS__ID';
COMMENT ON COLUMN SIM_RESULT_DS.LIAISON IS 'SIM_RESULT_DS__LIAISON';
COMMENT ON COLUMN SIM_RESULT_DS.SENS IS 'SIM_RESULT_DS__SENS';
COMMENT ON COLUMN SIM_RESULT_DS.ABS_DEB IS 'SIM_RESULT_DS__ABS_DEB';
COMMENT ON COLUMN SIM_RESULT_DS.ANNEE IS 'SIM_RESULT_DS__ANNEE';
COMMENT ON COLUMN SIM_RESULT_DS.ABS_FIN IS 'SIM_RESULT_DS__ABS_FIN';
COMMENT ON COLUMN SIM_RESULT_DS.DVR IS 'SIM_RESULT_DS__DVP';
COMMENT ON COLUMN SIM_RESULT_DS.FIS IS 'SIM_RESULT_DS__FIS';
COMMENT ON COLUMN SIM_RESULT_DS.LINEAIRE IS 'SIM_RESULT_DS__LINEAIRE';
COMMENT ON COLUMN SIM_RESULT_DS.SURFACE IS 'SIM_RESULT_DS__SURFACE';
COMMENT ON COLUMN SIM_RESULT_DS.EPAISSEUR IS 'SIM_RESULT_DS__EPAISSEUR';

-- ---------------------------------------------------------
-- Table TRAFIC_COLOR_DS
-- ---------------------------------------------------------
CREATE TABLE TRAFIC_COLOR_DS 
( 
	CODE                                    VARCHAR2(10 CHAR) NOT NULL,
	COLOR                                   VARCHAR2(11 CHAR)
);
COMMENT ON TABLE TRAFIC_COLOR_DS IS 'TRAFIC_COLOR_DS';
COMMENT ON COLUMN TRAFIC_COLOR_DS.CODE IS 'TRAFIC_COLOR_DS__CODE';
COMMENT ON COLUMN TRAFIC_COLOR_DS.COLOR IS 'TRAFIC_COLOR_DS__COLOR';

-- ---------------------------------------------------------
-- Table TREE_DS
-- ---------------------------------------------------------
CREATE TABLE TREE_DS 
( 
	ID                                      NUMBER(9) NOT NULL,
	LIBELLE                                 VARCHAR2(200 CHAR)
);
COMMENT ON TABLE TREE_DS IS 'TREE_DS';
COMMENT ON COLUMN TREE_DS.ID IS 'TREE_DS__ID';
COMMENT ON COLUMN TREE_DS.LIBELLE IS 'TREE_DS__LIBELLE';

-- ---------------------------------------------------------
-- Table TREE_RESULT_DS
-- ---------------------------------------------------------
CREATE TABLE TREE_RESULT_DS 
( 
	TREE_DS__ID                             NUMBER(9) NOT NULL,
	ID                                      NUMBER(9) NOT NULL,
	LIBELLE                                 VARCHAR2(100 CHAR) NOT NULL
);
COMMENT ON TABLE TREE_RESULT_DS IS 'TREE_RESULT_DS';
COMMENT ON COLUMN TREE_RESULT_DS.TREE_DS__ID IS 'TREE_DS__ID';
COMMENT ON COLUMN TREE_RESULT_DS.ID IS 'TREE_RESULT_DS__ID';
COMMENT ON COLUMN TREE_RESULT_DS.LIBELLE IS 'TREE_RESULT_DS__LIBELLE';

-- ---------------------------------------------------------
-- Table TREE_RESULT_PAVE_DS
-- ---------------------------------------------------------
CREATE TABLE TREE_RESULT_PAVE_DS 
( 
	TREE_DS__ID                             NUMBER(9) NOT NULL,
	TREE_RESULT_DS__ID                      NUMBER(9) NOT NULL,
	LIAISON                                 VARCHAR2(15 CHAR) NOT NULL,
	SENS                                    VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	ABS_FIN                                 NUMBER(6) NOT NULL,
	TECHNIQUE                               VARCHAR2(25 CHAR) NOT NULL
);
COMMENT ON TABLE TREE_RESULT_PAVE_DS IS 'TREE_RESULT_PAVE_DS';
COMMENT ON COLUMN TREE_RESULT_PAVE_DS.TREE_DS__ID IS 'TREE_DS__ID';
COMMENT ON COLUMN TREE_RESULT_PAVE_DS.TREE_RESULT_DS__ID IS 'TREE_RESULT_DS__ID';
COMMENT ON COLUMN TREE_RESULT_PAVE_DS.LIAISON IS 'TREE_RESULT_PAVE_DS__LIAISON';
COMMENT ON COLUMN TREE_RESULT_PAVE_DS.SENS IS 'TREE_RESULT_PAVE_DS__SENS';
COMMENT ON COLUMN TREE_RESULT_PAVE_DS.ABS_DEB IS 'TREE_RESULT_PAVE_DS__ABS_DEB';
COMMENT ON COLUMN TREE_RESULT_PAVE_DS.ABS_FIN IS 'TREE_RESULT_PAVE_DS__ABS_FIN';
COMMENT ON COLUMN TREE_RESULT_PAVE_DS.TECHNIQUE IS 'TREE_RESULT_PAVE_DS__TECHNIQUE';

-- ---------------------------------------------------------
-- Table TREE_RESULT_PAVE_VOIE_DS
-- ---------------------------------------------------------
CREATE TABLE TREE_RESULT_PAVE_VOIE_DS 
( 
	TREE_DS__ID                             NUMBER(9) NOT NULL,
	TREE_RESULT_DS__ID                      NUMBER(9) NOT NULL,
	TREE_RESULT_PAVE_DS__LIAISON            VARCHAR2(15 CHAR) NOT NULL,
	TREE_RESULT_PAVE_DS__SENS               VARCHAR2(6 CHAR) NOT NULL,
	TREE_RESULT_PAVE_DS__ABS_DEB            NUMBER(6) NOT NULL,
	VOIE                                    VARCHAR2(6 CHAR) NOT NULL,
	ABS_DEB                                 NUMBER(6) NOT NULL,
	ABS_FIN                                 NUMBER(6) NOT NULL
);
COMMENT ON TABLE TREE_RESULT_PAVE_VOIE_DS IS 'TREE_RESULT_PAVE_VOIE_DS';
COMMENT ON COLUMN TREE_RESULT_PAVE_VOIE_DS.TREE_DS__ID IS 'TREE_DS__ID';
COMMENT ON COLUMN TREE_RESULT_PAVE_VOIE_DS.TREE_RESULT_DS__ID IS 'TREE_RESULT_DS__ID';
COMMENT ON COLUMN TREE_RESULT_PAVE_VOIE_DS.TREE_RESULT_PAVE_DS__LIAISON IS 'TREE_RESULT_PAVE_DS__LIAISON';
COMMENT ON COLUMN TREE_RESULT_PAVE_VOIE_DS.TREE_RESULT_PAVE_DS__SENS IS 'TREE_RESULT_PAVE_DS__SENS';
COMMENT ON COLUMN TREE_RESULT_PAVE_VOIE_DS.TREE_RESULT_PAVE_DS__ABS_DEB IS 'TREE_RESULT_PAVE_DS__ABS_DEB';
COMMENT ON COLUMN TREE_RESULT_PAVE_VOIE_DS.VOIE IS 'TREE_RESULT_PAVE_VOIE_DS__VOIE';
COMMENT ON COLUMN TREE_RESULT_PAVE_VOIE_DS.ABS_DEB IS 'TREE_RESULT_PAVE_VOIE_DS__ABS_DEB';
COMMENT ON COLUMN TREE_RESULT_PAVE_VOIE_DS.ABS_FIN IS 'TREE_RESULT_PAVE_VOIE_DS__ABS_FIN';

