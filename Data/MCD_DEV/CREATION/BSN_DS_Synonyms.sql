/*################################################################################################*/
/* Script     : BSN_DS_Synonyms.sql                                                               */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

CREATE OR REPLACE  SYNONYM DS_ADMIN.SYS_INSTANCE_BSN FOR BSN.SYS_INSTANCE_BSN;
CREATE OR REPLACE  SYNONYM DS_VALID.SYS_INSTANCE_BSN FOR BSN.SYS_INSTANCE_BSN;
CREATE OR REPLACE  SYNONYM DS_CONSULT.SYS_INSTANCE_BSN FOR BSN.SYS_INSTANCE_BSN;
-- Synonym du role BSN_ADMIN pour le sch�ma DS
CREATE OR REPLACE SYNONYM BSN_ADMIN.BPU_COLOR_DS FOR DS.BPU_COLOR_DS;
CREATE OR REPLACE SYNONYM BSN_ADMIN.AGREGE_DS FOR DS.AGREGE_DS;
CREATE OR REPLACE SYNONYM BSN_ADMIN.MAT_DS FOR DS.MAT_DS;
CREATE OR REPLACE SYNONYM BSN_ADMIN.MAT_PARAM_DS FOR DS.MAT_PARAM_DS;
CREATE OR REPLACE SYNONYM BSN_ADMIN.NODE_DS FOR DS.NODE_DS;
CREATE OR REPLACE SYNONYM BSN_ADMIN.NODE_PARAM_DS FOR DS.NODE_PARAM_DS;
CREATE OR REPLACE SYNONYM BSN_ADMIN.PON_DS FOR DS.PON_DS;
CREATE OR REPLACE SYNONYM BSN_ADMIN.PON_PARAM_DS FOR DS.PON_PARAM_DS;
CREATE OR REPLACE SYNONYM BSN_ADMIN.SIM_CALCUL_DS FOR DS.SIM_CALCUL_DS;
CREATE OR REPLACE SYNONYM BSN_ADMIN.SIM_CALCUL_FIS_DS FOR DS.SIM_CALCUL_FIS_DS;
CREATE OR REPLACE SYNONYM BSN_ADMIN.SIM_CALCUL_TRAFIC_DS FOR DS.SIM_CALCUL_TRAFIC_DS;
CREATE OR REPLACE SYNONYM BSN_ADMIN.SIM_DVP_DS FOR DS.SIM_DVP_DS;
CREATE OR REPLACE SYNONYM BSN_ADMIN.SIM_DVP_VALUES_DS FOR DS.SIM_DVP_VALUES_DS;
CREATE OR REPLACE SYNONYM BSN_ADMIN.SIM_ENTRETIEN_DS FOR DS.SIM_ENTRETIEN_DS;
CREATE OR REPLACE SYNONYM BSN_ADMIN.SIM_ETUDE_DS FOR DS.SIM_ETUDE_DS;
CREATE OR REPLACE SYNONYM BSN_ADMIN.SIM_FIS_CLASSE_DS FOR DS.SIM_FIS_CLASSE_DS;
CREATE OR REPLACE SYNONYM BSN_ADMIN.SIM_FIS_DS FOR DS.SIM_FIS_DS;
CREATE OR REPLACE SYNONYM BSN_ADMIN.SIM_FIS_VALUES_DS FOR DS.SIM_FIS_VALUES_DS;
CREATE OR REPLACE SYNONYM BSN_ADMIN.SIM_REC_DS FOR DS.SIM_REC_DS;
CREATE OR REPLACE SYNONYM BSN_ADMIN.SIM_REC_VALUES_DS FOR DS.SIM_REC_VALUES_DS;
CREATE OR REPLACE SYNONYM BSN_ADMIN.SIM_RESULT_DS FOR DS.SIM_RESULT_DS;
CREATE OR REPLACE SYNONYM BSN_ADMIN.TRAFIC_COLOR_DS FOR DS.TRAFIC_COLOR_DS;
CREATE OR REPLACE SYNONYM BSN_ADMIN.TREE_DS FOR DS.TREE_DS;
CREATE OR REPLACE SYNONYM BSN_ADMIN.TREE_RESULT_DS FOR DS.TREE_RESULT_DS;
CREATE OR REPLACE SYNONYM BSN_ADMIN.TREE_RESULT_PAVE_DS FOR DS.TREE_RESULT_PAVE_DS;
CREATE OR REPLACE SYNONYM BSN_ADMIN.TREE_RESULT_PAVE_VOIE_DS FOR DS.TREE_RESULT_PAVE_VOIE_DS;
CREATE OR REPLACE  SYNONYM BSN_ADMIN.SYS_PRP_DS FOR DS.SYS_PRP_DS;
-- Synonym du role BSN_CONSULT pour le sch�ma DS
CREATE OR REPLACE SYNONYM BSN_CONSULT.BPU_COLOR_DS FOR DS.BPU_COLOR_DS;
CREATE OR REPLACE SYNONYM BSN_CONSULT.AGREGE_DS FOR DS.AGREGE_DS;
CREATE OR REPLACE SYNONYM BSN_CONSULT.MAT_DS FOR DS.MAT_DS;
CREATE OR REPLACE SYNONYM BSN_CONSULT.MAT_PARAM_DS FOR DS.MAT_PARAM_DS;
CREATE OR REPLACE SYNONYM BSN_CONSULT.NODE_DS FOR DS.NODE_DS;
CREATE OR REPLACE SYNONYM BSN_CONSULT.NODE_PARAM_DS FOR DS.NODE_PARAM_DS;
CREATE OR REPLACE SYNONYM BSN_CONSULT.PON_DS FOR DS.PON_DS;
CREATE OR REPLACE SYNONYM BSN_CONSULT.PON_PARAM_DS FOR DS.PON_PARAM_DS;
CREATE OR REPLACE SYNONYM BSN_CONSULT.SIM_CALCUL_DS FOR DS.SIM_CALCUL_DS;
CREATE OR REPLACE SYNONYM BSN_CONSULT.SIM_CALCUL_FIS_DS FOR DS.SIM_CALCUL_FIS_DS;
CREATE OR REPLACE SYNONYM BSN_CONSULT.SIM_CALCUL_TRAFIC_DS FOR DS.SIM_CALCUL_TRAFIC_DS;
CREATE OR REPLACE SYNONYM BSN_CONSULT.SIM_DVP_DS FOR DS.SIM_DVP_DS;
CREATE OR REPLACE SYNONYM BSN_CONSULT.SIM_DVP_VALUES_DS FOR DS.SIM_DVP_VALUES_DS;
CREATE OR REPLACE SYNONYM BSN_CONSULT.SIM_ENTRETIEN_DS FOR DS.SIM_ENTRETIEN_DS;
CREATE OR REPLACE SYNONYM BSN_CONSULT.SIM_ETUDE_DS FOR DS.SIM_ETUDE_DS;
CREATE OR REPLACE SYNONYM BSN_CONSULT.SIM_FIS_CLASSE_DS FOR DS.SIM_FIS_CLASSE_DS;
CREATE OR REPLACE SYNONYM BSN_CONSULT.SIM_FIS_DS FOR DS.SIM_FIS_DS;
CREATE OR REPLACE SYNONYM BSN_CONSULT.SIM_FIS_VALUES_DS FOR DS.SIM_FIS_VALUES_DS;
CREATE OR REPLACE SYNONYM BSN_CONSULT.SIM_REC_DS FOR DS.SIM_REC_DS;
CREATE OR REPLACE SYNONYM BSN_CONSULT.SIM_REC_VALUES_DS FOR DS.SIM_REC_VALUES_DS;
CREATE OR REPLACE SYNONYM BSN_CONSULT.SIM_RESULT_DS FOR DS.SIM_RESULT_DS;
CREATE OR REPLACE SYNONYM BSN_CONSULT.TRAFIC_COLOR_DS FOR DS.TRAFIC_COLOR_DS;
CREATE OR REPLACE SYNONYM BSN_CONSULT.TREE_DS FOR DS.TREE_DS;
CREATE OR REPLACE SYNONYM BSN_CONSULT.TREE_RESULT_DS FOR DS.TREE_RESULT_DS;
CREATE OR REPLACE SYNONYM BSN_CONSULT.TREE_RESULT_PAVE_DS FOR DS.TREE_RESULT_PAVE_DS;
CREATE OR REPLACE SYNONYM BSN_CONSULT.TREE_RESULT_PAVE_VOIE_DS FOR DS.TREE_RESULT_PAVE_VOIE_DS;
CREATE OR REPLACE  SYNONYM BSN_CONSULT.SYS_PRP_DS FOR DS.SYS_PRP_DS;
-- Synonym du role BSN_VALID pour le sch�ma DS
CREATE OR REPLACE SYNONYM BSN_VALID.BPU_COLOR_DS FOR DS.BPU_COLOR_DS;
CREATE OR REPLACE SYNONYM BSN_VALID.AGREGE_DS FOR DS.AGREGE_DS;
CREATE OR REPLACE SYNONYM BSN_VALID.MAT_DS FOR DS.MAT_DS;
CREATE OR REPLACE SYNONYM BSN_VALID.MAT_PARAM_DS FOR DS.MAT_PARAM_DS;
CREATE OR REPLACE SYNONYM BSN_VALID.NODE_DS FOR DS.NODE_DS;
CREATE OR REPLACE SYNONYM BSN_VALID.NODE_PARAM_DS FOR DS.NODE_PARAM_DS;
CREATE OR REPLACE SYNONYM BSN_VALID.PON_DS FOR DS.PON_DS;
CREATE OR REPLACE SYNONYM BSN_VALID.PON_PARAM_DS FOR DS.PON_PARAM_DS;
CREATE OR REPLACE SYNONYM BSN_VALID.SIM_CALCUL_DS FOR DS.SIM_CALCUL_DS;
CREATE OR REPLACE SYNONYM BSN_VALID.SIM_CALCUL_FIS_DS FOR DS.SIM_CALCUL_FIS_DS;
CREATE OR REPLACE SYNONYM BSN_VALID.SIM_CALCUL_TRAFIC_DS FOR DS.SIM_CALCUL_TRAFIC_DS;
CREATE OR REPLACE SYNONYM BSN_VALID.SIM_DVP_DS FOR DS.SIM_DVP_DS;
CREATE OR REPLACE SYNONYM BSN_VALID.SIM_DVP_VALUES_DS FOR DS.SIM_DVP_VALUES_DS;
CREATE OR REPLACE SYNONYM BSN_VALID.SIM_ENTRETIEN_DS FOR DS.SIM_ENTRETIEN_DS;
CREATE OR REPLACE SYNONYM BSN_VALID.SIM_ETUDE_DS FOR DS.SIM_ETUDE_DS;
CREATE OR REPLACE SYNONYM BSN_VALID.SIM_FIS_CLASSE_DS FOR DS.SIM_FIS_CLASSE_DS;
CREATE OR REPLACE SYNONYM BSN_VALID.SIM_FIS_DS FOR DS.SIM_FIS_DS;
CREATE OR REPLACE SYNONYM BSN_VALID.SIM_FIS_VALUES_DS FOR DS.SIM_FIS_VALUES_DS;
CREATE OR REPLACE SYNONYM BSN_VALID.SIM_REC_DS FOR DS.SIM_REC_DS;
CREATE OR REPLACE SYNONYM BSN_VALID.SIM_REC_VALUES_DS FOR DS.SIM_REC_VALUES_DS;
CREATE OR REPLACE SYNONYM BSN_VALID.SIM_RESULT_DS FOR DS.SIM_RESULT_DS;
CREATE OR REPLACE SYNONYM BSN_VALID.TRAFIC_COLOR_DS FOR DS.TRAFIC_COLOR_DS;
CREATE OR REPLACE SYNONYM BSN_VALID.TREE_DS FOR DS.TREE_DS;
CREATE OR REPLACE SYNONYM BSN_VALID.TREE_RESULT_DS FOR DS.TREE_RESULT_DS;
CREATE OR REPLACE SYNONYM BSN_VALID.TREE_RESULT_PAVE_DS FOR DS.TREE_RESULT_PAVE_DS;
CREATE OR REPLACE SYNONYM BSN_VALID.TREE_RESULT_PAVE_VOIE_DS FOR DS.TREE_RESULT_PAVE_VOIE_DS;
CREATE OR REPLACE  SYNONYM BSN_VALID.SYS_PRP_DS FOR DS.SYS_PRP_DS;
