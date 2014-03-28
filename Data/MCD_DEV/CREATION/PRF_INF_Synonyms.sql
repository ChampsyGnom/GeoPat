/*################################################################################################*/
/* Script     : PRF_INF_Synonyms.sql                                                              */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

CREATE OR REPLACE  SYNONYM INF_ADMIN.SYS_INSTANCE_PRF FOR PRF.SYS_INSTANCE_PRF;
CREATE OR REPLACE  SYNONYM INF_VALID.SYS_INSTANCE_PRF FOR PRF.SYS_INSTANCE_PRF;
CREATE OR REPLACE  SYNONYM INF_CONSULT.SYS_INSTANCE_PRF FOR PRF.SYS_INSTANCE_PRF;
-- Synonym du role PRF_ADMIN pour le sch�ma INF
CREATE OR REPLACE SYNONYM PRF_ADMIN.ACCIDENT_INF FOR INF.ACCIDENT_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.AIRE_INF FOR INF.AIRE_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.PR_OLD_INF FOR INF.PR_OLD_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.BIFURCATION_INF FOR INF.BIFURCATION_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.BRETELLE_INF FOR INF.BRETELLE_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CHAUSSEE_INF FOR INF.CHAUSSEE_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_CLASS_TRAF_INF FOR INF.CD_CLASS_TRAF_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CLS_INF FOR INF.CLS_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CLIM_INF FOR INF.CLIM_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CLS_DOC_INF FOR INF.CLS_DOC_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_DEC_INF FOR INF.CD_DEC_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_POSIT_INF FOR INF.CD_POSIT_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_VOIE_INF FOR INF.CD_VOIE_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CONTACT_INF FOR INF.CONTACT_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CORRESPONDANCE_INF FOR INF.CORRESPONDANCE_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.DICTIONNAIRE_INF FOR INF.DICTIONNAIRE_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.DOC_INF FOR INF.DOC_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.ECLAIRAGE_INF FOR INF.ECLAIRAGE_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.EVT_INF FOR INF.EVT_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.FAM_DEC_INF FOR INF.FAM_DEC_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.WGS_INF FOR INF.WGS_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.GARE_INF FOR INF.GARE_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.LIAISON_INF FOR INF.LIAISON_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.OCCUPATION_INF FOR INF.OCCUPATION_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.DSC_OA_INF FOR INF.DSC_OA_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.PAVE_VOIE_INF FOR INF.PAVE_VOIE_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.PK_INF FOR INF.PK_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.AIRE__PLACE_INF FOR INF.AIRE__PLACE_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.PT_SING_INF FOR INF.PT_SING_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.REPERE_INF FOR INF.REPERE_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.PRESTATAIRE_INF FOR INF.PRESTATAIRE_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.AIRE__PRESTATAIRE_INF FOR INF.AIRE__PRESTATAIRE_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.PREV_SGE_INF FOR INF.PREV_SGE_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.AMENAGEMENT_INF FOR INF.AMENAGEMENT_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.REPARTITION_TRAFIC_INF FOR INF.REPARTITION_TRAFIC_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.SECTION_TRAFIC_INF FOR INF.SECTION_TRAFIC_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.SECURITE_INF FOR INF.SECURITE_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.AIRE__SERVICE_INF FOR INF.AIRE__SERVICE_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.SYS_USER_INF FOR INF.SYS_USER_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.TALUS_INF FOR INF.TALUS_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.TPC_INF FOR INF.TPC_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.TRAFIC_INF FOR INF.TRAFIC_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.TR_DEC_INF FOR INF.TR_DEC_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_AIRE_INF FOR INF.CD_AIRE_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_AMENAG_INF FOR INF.CD_AMENAG_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_BIF_INF FOR INF.CD_BIF_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_DOC_INF FOR INF.CD_DOC_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_EVT_INF FOR INF.CD_EVT_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_ECLAIR_INF FOR INF.CD_ECLAIR_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_GARE_INF FOR INF.CD_GARE_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_LIAISON_INF FOR INF.CD_LIAISON_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_OCCUPANT_INF FOR INF.CD_OCCUPANT_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_OCCUP_INF FOR INF.CD_OCCUP_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_PLACE_INF FOR INF.CD_PLACE_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_PT_SING_INF FOR INF.CD_PT_SING_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_PRESTATAIRE_INF FOR INF.CD_PRESTATAIRE_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_SECUR_INF FOR INF.CD_SECUR_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_SERVICE_INF FOR INF.CD_SERVICE_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_TALUS_INF FOR INF.CD_TALUS_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_TPC_INF FOR INF.CD_TPC_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_CLIM_INF FOR INF.CD_CLIM_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_SENSIBLE_INF FOR INF.CD_SENSIBLE_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CL_VOIE_INF FOR INF.CL_VOIE_INF;
CREATE OR REPLACE SYNONYM PRF_ADMIN.SENSIBLE_INF FOR INF.SENSIBLE_INF;
CREATE OR REPLACE  SYNONYM PRF_ADMIN.PR_TO_ABS FOR INF.PR_TO_ABS;
CREATE OR REPLACE  SYNONYM PRF_ADMIN.ABS_TO_PR FOR INF.ABS_TO_PR;
CREATE OR REPLACE  SYNONYM PRF_ADMIN.ABS_TO_WGS FOR INF.ABS_TO_WGS;
CREATE OR REPLACE  SYNONYM PRF_ADMIN.WGS_TO_NUM_OUVRAGES FOR INF.WGS_TO_NUM_OUVRAGES;
CREATE OR REPLACE  SYNONYM PRF_ADMIN.ABS_TO_WGS_LINE FOR INF.ABS_TO_WGS_LINE;
CREATE OR REPLACE  SYNONYM PRF_ADMIN.GET_DECOUPAGE FOR INF.GET_DECOUPAGE;
CREATE OR REPLACE  SYNONYM PRF_ADMIN.WGS_DISTANCE FOR INF.WGS_DISTANCE;
CREATE OR REPLACE  SYNONYM PRF_ADMIN.ST_ASGEOJSON FOR INF.ST_ASGEOJSON;
CREATE OR REPLACE  SYNONYM PRF_ADMIN.SYS_PRP_INF FOR INF.SYS_PRP_INF;
CREATE OR REPLACE  SYNONYM PRF_ADMIN.SEQ_CLS_INF FOR INF.SEQ_CLS_INF;
CREATE OR REPLACE  SYNONYM PRF_ADMIN.SEQ_DOC_INF FOR INF.SEQ_DOC_INF;
-- Synonym du role PRF_CONSULT pour le sch�ma INF
CREATE OR REPLACE SYNONYM PRF_CONSULT.ACCIDENT_INF FOR INF.ACCIDENT_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.AIRE_INF FOR INF.AIRE_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.PR_OLD_INF FOR INF.PR_OLD_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.BIFURCATION_INF FOR INF.BIFURCATION_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.BRETELLE_INF FOR INF.BRETELLE_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CHAUSSEE_INF FOR INF.CHAUSSEE_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_CLASS_TRAF_INF FOR INF.CD_CLASS_TRAF_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CLS_INF FOR INF.CLS_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CLIM_INF FOR INF.CLIM_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CLS_DOC_INF FOR INF.CLS_DOC_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_DEC_INF FOR INF.CD_DEC_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_POSIT_INF FOR INF.CD_POSIT_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_VOIE_INF FOR INF.CD_VOIE_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CONTACT_INF FOR INF.CONTACT_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CORRESPONDANCE_INF FOR INF.CORRESPONDANCE_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.DICTIONNAIRE_INF FOR INF.DICTIONNAIRE_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.DOC_INF FOR INF.DOC_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.ECLAIRAGE_INF FOR INF.ECLAIRAGE_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.EVT_INF FOR INF.EVT_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.FAM_DEC_INF FOR INF.FAM_DEC_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.WGS_INF FOR INF.WGS_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.GARE_INF FOR INF.GARE_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.LIAISON_INF FOR INF.LIAISON_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.OCCUPATION_INF FOR INF.OCCUPATION_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.DSC_OA_INF FOR INF.DSC_OA_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.PAVE_VOIE_INF FOR INF.PAVE_VOIE_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.PK_INF FOR INF.PK_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.AIRE__PLACE_INF FOR INF.AIRE__PLACE_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.PT_SING_INF FOR INF.PT_SING_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.REPERE_INF FOR INF.REPERE_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.PRESTATAIRE_INF FOR INF.PRESTATAIRE_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.AIRE__PRESTATAIRE_INF FOR INF.AIRE__PRESTATAIRE_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.PREV_SGE_INF FOR INF.PREV_SGE_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.AMENAGEMENT_INF FOR INF.AMENAGEMENT_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.REPARTITION_TRAFIC_INF FOR INF.REPARTITION_TRAFIC_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.SECTION_TRAFIC_INF FOR INF.SECTION_TRAFIC_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.SECURITE_INF FOR INF.SECURITE_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.AIRE__SERVICE_INF FOR INF.AIRE__SERVICE_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.SYS_USER_INF FOR INF.SYS_USER_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.TALUS_INF FOR INF.TALUS_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.TPC_INF FOR INF.TPC_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.TRAFIC_INF FOR INF.TRAFIC_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.TR_DEC_INF FOR INF.TR_DEC_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_AIRE_INF FOR INF.CD_AIRE_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_AMENAG_INF FOR INF.CD_AMENAG_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_BIF_INF FOR INF.CD_BIF_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_DOC_INF FOR INF.CD_DOC_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_EVT_INF FOR INF.CD_EVT_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_ECLAIR_INF FOR INF.CD_ECLAIR_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_GARE_INF FOR INF.CD_GARE_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_LIAISON_INF FOR INF.CD_LIAISON_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_OCCUPANT_INF FOR INF.CD_OCCUPANT_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_OCCUP_INF FOR INF.CD_OCCUP_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_PLACE_INF FOR INF.CD_PLACE_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_PT_SING_INF FOR INF.CD_PT_SING_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_PRESTATAIRE_INF FOR INF.CD_PRESTATAIRE_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_SECUR_INF FOR INF.CD_SECUR_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_SERVICE_INF FOR INF.CD_SERVICE_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_TALUS_INF FOR INF.CD_TALUS_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_TPC_INF FOR INF.CD_TPC_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_CLIM_INF FOR INF.CD_CLIM_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_SENSIBLE_INF FOR INF.CD_SENSIBLE_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CL_VOIE_INF FOR INF.CL_VOIE_INF;
CREATE OR REPLACE SYNONYM PRF_CONSULT.SENSIBLE_INF FOR INF.SENSIBLE_INF;
CREATE OR REPLACE  SYNONYM PRF_CONSULT.PR_TO_ABS FOR INF.PR_TO_ABS;
CREATE OR REPLACE  SYNONYM PRF_CONSULT.ABS_TO_PR FOR INF.ABS_TO_PR;
CREATE OR REPLACE  SYNONYM PRF_CONSULT.ABS_TO_WGS FOR INF.ABS_TO_WGS;
CREATE OR REPLACE  SYNONYM PRF_CONSULT.WGS_TO_NUM_OUVRAGES FOR INF.WGS_TO_NUM_OUVRAGES;
CREATE OR REPLACE  SYNONYM PRF_CONSULT.ABS_TO_WGS_LINE FOR INF.ABS_TO_WGS_LINE;
CREATE OR REPLACE  SYNONYM PRF_CONSULT.GET_DECOUPAGE FOR INF.GET_DECOUPAGE;
CREATE OR REPLACE  SYNONYM PRF_CONSULT.WGS_DISTANCE FOR INF.WGS_DISTANCE;
CREATE OR REPLACE  SYNONYM PRF_CONSULT.ST_ASGEOJSON FOR INF.ST_ASGEOJSON;
CREATE OR REPLACE  SYNONYM PRF_CONSULT.SYS_PRP_INF FOR INF.SYS_PRP_INF;
CREATE OR REPLACE  SYNONYM PRF_CONSULT.SEQ_CLS_INF FOR INF.SEQ_CLS_INF;
CREATE OR REPLACE  SYNONYM PRF_CONSULT.SEQ_DOC_INF FOR INF.SEQ_DOC_INF;
