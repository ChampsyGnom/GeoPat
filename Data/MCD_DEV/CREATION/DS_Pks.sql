/*################################################################################################*/
/* Script     : DS_Pks.sql                                                                        */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

ALTER TABLE MAT_DS
ADD CONSTRAINT MAT_DS_PK
PRIMARY KEY (CODE) 
USING INDEX
;

ALTER TABLE PON_DS
ADD CONSTRAINT PON_DS_PK
PRIMARY KEY (CODE) 
USING INDEX
;

ALTER TABLE MAT_PARAM_DS
ADD CONSTRAINT MAT_PARAM_DS_PK
PRIMARY KEY (MAT_DS__CODE,X,Y) 
USING INDEX
;

ALTER TABLE PON_PARAM_DS
ADD CONSTRAINT PON_PARAM_DS_PK
PRIMARY KEY (PON_DS__CODE,INDIC) 
USING INDEX
;

ALTER TABLE TREE_DS
ADD CONSTRAINT TREE_DS_PK
PRIMARY KEY (ID) 
USING INDEX
;

ALTER TABLE NODE_DS
ADD CONSTRAINT NODE_DS_PK
PRIMARY KEY (TREE_DS__ID,ID) 
USING INDEX
;

ALTER TABLE NODE_PARAM_DS
ADD CONSTRAINT NODE_PARAM_DS_PK
PRIMARY KEY (TREE_DS__ID,NODE_DS__ID,ID) 
USING INDEX
;

ALTER TABLE BPU_COLOR_DS
ADD CONSTRAINT BPU_COLOR_DS_PK
PRIMARY KEY (CODE) 
USING INDEX
;

ALTER TABLE TREE_RESULT_PAVE_DS
ADD CONSTRAINT TREE_RESULT_PAVE_DS_PK
PRIMARY KEY (TREE_DS__ID,TREE_RESULT_DS__ID,LIAISON,SENS,ABS_DEB) 
USING INDEX
;

ALTER TABLE TREE_RESULT_PAVE_VOIE_DS
ADD CONSTRAINT TREE_RESULT_PAVE_VOIE_DS_PK
PRIMARY KEY (TREE_DS__ID,TREE_RESULT_DS__ID,TREE_RESULT_PAVE_DS__LIAISON,TREE_RESULT_PAVE_DS__SENS,TREE_RESULT_PAVE_DS__ABS_DEB,VOIE) 
USING INDEX
;

ALTER TABLE TREE_RESULT_DS
ADD CONSTRAINT TREE_RESULT_DS_PK
PRIMARY KEY (TREE_DS__ID,ID) 
USING INDEX
;

ALTER TABLE SIM_DVP_DS
ADD CONSTRAINT SIM_DVP_DS_PK
PRIMARY KEY (ID) 
USING INDEX
;

ALTER TABLE SIM_REC_DS
ADD CONSTRAINT SIM_REC_DS_PK
PRIMARY KEY (ID) 
USING INDEX
;

ALTER TABLE SIM_FIS_DS
ADD CONSTRAINT SIM_FIS_DS_PK
PRIMARY KEY (ID) 
USING INDEX
;

ALTER TABLE SIM_FIS_CLASSE_DS
ADD CONSTRAINT SIM_FIS_CLASSE_DS_PK
PRIMARY KEY (SIM_FIS_DS__ID,ID) 
USING INDEX
;

ALTER TABLE SIM_REC_VALUES_DS
ADD CONSTRAINT SIM_REC_VALUES_DS_PK
PRIMARY KEY (SIM_REC_DS__ID,ANNEE) 
USING INDEX
;

ALTER TABLE SIM_DVP_VALUES_DS
ADD CONSTRAINT SIM_DVP_VALUES_DS_PK
PRIMARY KEY (SIM_DVP_DS__ID,ANNEE) 
USING INDEX
;

ALTER TABLE SIM_FIS_VALUES_DS
ADD CONSTRAINT SIM_FIS_VALUES_DS_PK
PRIMARY KEY (SIM_FIS_DS__ID,SIM_FIS_CLASSE_DS__ID,ANNEE) 
USING INDEX
;

ALTER TABLE SIM_CALCUL_TRAFIC_DS
ADD CONSTRAINT SIM_CALCUL_TRAFIC_DS_PK
PRIMARY KEY (ID) 
USING INDEX
;

ALTER TABLE SIM_RESULT_DS
ADD CONSTRAINT SIM_RESULT_DS_PK
PRIMARY KEY (SIM_CALCUL_TRAFIC_DS__ID,SIM_FIS_DS__ID,LIAISON,SENS,ABS_DEB,ANNEE) 
USING INDEX
;

ALTER TABLE SIM_CALCUL_FIS_DS
ADD CONSTRAINT SIM_CALCUL_FIS_DS_PK
PRIMARY KEY (SIM_CALCUL_TRAFIC_DS__ID,SIM_FIS_DS__ID) 
USING INDEX
;

ALTER TABLE SIM_ENTRETIEN_DS
ADD CONSTRAINT SIM_ENTRETIEN_DS_PK
PRIMARY KEY (ID) 
USING INDEX
;

ALTER TABLE SIM_ETUDE_DS
ADD CONSTRAINT SIM_ETUDE_DS_PK
PRIMARY KEY (ID) 
USING INDEX
;

ALTER TABLE SIM_CALCUL_DS
ADD CONSTRAINT SIM_CALCUL_DS_PK
PRIMARY KEY (ID) 
USING INDEX
;

ALTER TABLE TRAFIC_COLOR_DS
ADD CONSTRAINT TRAFIC_COLOR_DS_PK
PRIMARY KEY (CODE) 
USING INDEX
;

ALTER TABLE AGREGE_DS
ADD CONSTRAINT AGREGE_DS_PK
PRIMARY KEY (CODE) 
USING INDEX
;

